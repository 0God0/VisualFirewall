using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using NetFwTypeLib;
#pragma warning disable CS8600
#pragma warning disable CS8604
public class FireWallBlockPort {
    private const string BaseName = "持续屏蔽端口攻击IP";
    private const string BlocklistFile = "FirewallBlockList";
    private const string BlocklistCountFile = "FirewallBlockCount";
    private readonly List<int> targetPort;
    private readonly HashSet<string> blockedIps;
    private int ruleCount;

    private Action<string> logAction;

    public FireWallBlockPort(List<int> ports) : this(ports, s => Debug.WriteLine(s)) { }
    public FireWallBlockPort(List<int> ports, Action<string> log) {
        logAction = log;
        logAction("防火墙模块开始初始化，正在加载历史记录...\n");
        ruleCount = File.Exists(BlocklistCountFile) ? int.Parse(File.ReadLines(BlocklistCountFile).FirstOrDefault()) : 1;
        targetPort = ports;
        blockedIps = LoadHistoricIps();
        logAction($"历史记录加载完成，当前屏蔽IP数量: {blockedIps.Count} 个");
    }

    public void AddBlockPort(int port) {
        if (0 <= port && port <= 65535) targetPort.Add(port);
        else logAction($"端口 {port} 不在有效范围内 (0-65535)");
    }

    public void changeLogAction(Action<string> ac) {
        logAction = ac;
    }

    private string getRuleName(int count) {
        return $"{BaseName}-{count}";
    }

    public int getBlockedIPCount() {
        return blockedIps.Count;
    }

    public void addIPs(HashSet<string> addips) {
        logAction("正在请求添加IP · · ·");
        if (addips.Count == 0 || addips == null) {
            logAction("要添加的IP不可为空");
            return;
        }
        logAction("-------------------------------添加屏蔽IP--------------------------------");
        int oldIPCount = blockedIps.Count;
        int ipCount = addips.Count;
        logAction($"当前屏蔽IP数 {oldIPCount} 个，需求屏蔽数 {ipCount}");
        try {
            addips.RemoveWhere(ip => !System.Net.IPAddress.TryParse(ip, out _));
            logAction($"检测到 {ipCount - addips.Count} 个IP不符合规则，已移除");

            blockedIps.UnionWith(addips);

            UpdateBlocklist(addips);
            int newIPCount = blockedIps.Count;
            logAction($"执行完毕，本次屏蔽数 {newIPCount - oldIPCount} 个IP，当前IP数 {newIPCount}");
        } catch (UnauthorizedAccessException) {
            MessageBox.Show("请以管理员身份运行程序", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        } catch (Exception ex) {
            logAction($"发生错误: {ex.Message}");
        }
        logAction("-----------------------------------------------------------------------------");
    }

    public void removeIPs(HashSet<string> remips) {
        logAction("正在请求移除IP · · ·");
        if (remips.Count == 0 || remips == null) {
            logAction("要移除的IP不可为空");
            return;
        }
        logAction("------------------------------移除屏蔽IP--------------------------------");
        int oldIPCount = blockedIps.Count;
        int ipCount = remips.Count;
        logAction($"当前屏蔽IP数 {oldIPCount} 个，需求移除数 {ipCount}");
        try {
            remips.RemoveWhere(ip => !System.Net.IPAddress.TryParse(ip, out _));
            logAction($"检测到 {ipCount - remips.Count} 个IP不符合规则，已移除");

            foreach (var ip in remips) blockedIps.Remove(ip);

            UpdateBlocklist(remips);
            int newIPCount = blockedIps.Count;
            logAction($"执行完毕，本次移除数 {oldIPCount - newIPCount} 个IP，当前IP数 {newIPCount}");
        } catch (UnauthorizedAccessException) {
            MessageBox.Show("请以管理员身份运行程序", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        } catch (Exception ex) {
            logAction($"发生错误: {ex.Message}");
        }
        logAction("-----------------------------------------------------------------------------");
    }

    private void UpdateBlocklist(IEnumerable<string> newIps) {

        var firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
        var ipBatches = blockedIps
            .Select((ip, idx) => new { ip, idx })
            .GroupBy(x => x.idx / 9999)
            .Select(g => g.Select(x => x.ip).ToList())
            .ToList();

        // 先清理所有旧规则
        for (int i = 1; i <= ruleCount; i++) {
            RemoveExistingRules(firewallPolicy, FindRulesByDisplayName(firewallPolicy, getRuleName(i)));
        }

        // 重新生成规则
        for (int i = 0; i < ipBatches.Count; i++) {
            var batch = ipBatches[i];
            CreateNewRule(firewallPolicy, batch, getRuleName(i + 1));
        }
        ruleCount = ipBatches.Count;

        // 存储
        SaveHistoricIps(blockedIps, ruleCount);
    }

    private HashSet<string> LoadHistoricIps() {
        try {
            return File.Exists(BlocklistFile) ?
                File.ReadAllLines(BlocklistFile)
                    .Where(ip => System.Net.IPAddress.TryParse(ip, out _))
                    .ToHashSet() : new HashSet<string>();
        } catch {
            return new HashSet<string>();
        }
    }

    private void SaveHistoricIps(HashSet<string> ips, int count) {
        try {
            File.WriteAllText(BlocklistCountFile, count.ToString());
            File.WriteAllLines(BlocklistFile, ips);
        } catch (Exception ex) {
            logAction($"保存屏蔽IP列表失败: {ex.Message}");
        }
    }

    private List<INetFwRule> FindRulesByDisplayName(INetFwPolicy2 policy, string name) {
        return policy.Rules.OfType<INetFwRule>()
            .Where(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) // 使用 Name 而非 DisplayName
            .ToList();
    }

    //private List<string> GetIpsFromRules(IEnumerable<INetFwRule> rules) {
    //    return rules
    //        .SelectMany(r => r.RemoteAddresses?
    //            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
    //            ?? Array.Empty<string>())
    //        .Distinct()
    //        .ToList();
    //}

    private HashSet<string> GetIpsFromRules(IEnumerable<INetFwRule> rules) {
        return rules
            .SelectMany(r => r.RemoteAddresses?
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                ?? Array.Empty<string>())
            .Select(addr => addr.Contains('/') ? addr.Split('/')[0] : addr) // 只取IP部分
            .Distinct()
            .ToHashSet();
    }

    private void RemoveExistingRules(INetFwPolicy2 policy, List<INetFwRule> rules) {
        foreach (var rule in rules) {
            try {
                policy.Rules.Remove(rule.Name);
            } catch (Exception e) {
                logAction($"删除规则失败: {e.Message}");
            }
        }
    }

    private void CreateNewRule(INetFwPolicy2 policy, List<string> ips, string ruleName) {

        if (ips.Count == 0) return;

        var rule = (INetFwRule)Activator.CreateInstance(
            Type.GetTypeFromProgID("HNetCfg.FWRule"));

        rule.Name = ruleName;
        rule.Description = $"最后更新：{DateTime.Now:yyyyMMdd-HHmmss}";
        rule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
        rule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
        rule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
        rule.LocalPorts = string.Join(",", targetPort);
        rule.RemoteAddresses = string.Join(",", ips);
        rule.Enabled = true;

        policy.Rules.Add(rule);
    }
}