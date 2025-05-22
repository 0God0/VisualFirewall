using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using NetFwTypeLib;

public class FireWallBlockPort {
    private const string RuleName = "持续屏蔽端口攻击IP";
    private const string BlocklistFile = /*@"D:\FireWallBlock\"*/"FirewallBlockList.txt";
    private readonly List<int> TargetPort;
    private readonly HashSet<string> BlockedIps = new HashSet<string>();

    private Action<string> LogAction = (s) => Debug.WriteLine(s);

    public FireWallBlockPort(List<int> ports) {
        TargetPort = ports;
    }

    public void AddBlockPort(int port) {
        TargetPort.Add(port);
    }

    public void UpdateBlocklist(IEnumerable<string> newIps) {
        // 获取防火墙策略
        var firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
            Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

        // 读取历史记录
        var historicIps = LoadHistoricIps();

        // 获取现有规则中的IP
        var existingRules = FindRulesByDisplayName(firewallPolicy, RuleName);
        var existingIps = GetIpsFromRules(existingRules);

        // 合并所有IP（新IP + 历史记录 + 现有规则IP）
        var allIps = historicIps
            .Union(newIps)
            .Union(existingIps)
            .Distinct()
            .ToList();

        // 更新持久化存储
        SaveHistoricIps(allIps);

        // 删除旧规则
        RemoveExistingRules(firewallPolicy, existingRules);

        // 创建新规则
        CreateNewRule(firewallPolicy, allIps);
    }

    private List<string> LoadHistoricIps() {
        try {
            return File.Exists(BlocklistFile) ?
                File.ReadAllLines(BlocklistFile)
                    .Where(ip => /*Regex.IsMatch(ip, @"^\d+\.\d+\.\d+\.\d+$")*/System.Net.IPAddress.TryParse(ip,out _))
                    .ToList() : new List<string>();
        } catch {
            return new List<string>();
        }
    }

    private void SaveHistoricIps(List<string> ips) {
        try {
            File.WriteAllLines(BlocklistFile, ips);
        } catch { /* 处理写入异常 */ }
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

    private List<string> GetIpsFromRules(IEnumerable<INetFwRule> rules) {
        return rules
            .SelectMany(r => r.RemoteAddresses?
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                ?? Array.Empty<string>())
            .Select(addr => addr.Contains('/') ? addr.Split('/')[0] : addr) // 只取IP部分
            .Distinct()
            .ToList();
    }

    private void RemoveExistingRules(INetFwPolicy2 policy, List<INetFwRule> rules) {
        foreach (var rule in rules) {
            try {
                policy.Rules.Remove(rule.Name);
            } catch { /* 处理删除异常 */ }
        }
    }

    private void CreateNewRule(INetFwPolicy2 policy, List<string> ips) {
        if (ips.Count == 0) return;

        var rule = (INetFwRule)Activator.CreateInstance(
            Type.GetTypeFromProgID("HNetCfg.FWRule"));

        rule.Name = RuleName;
        rule.Description = $"最后更新：{DateTime.Now:yyyyMMdd-HHmmss}";
        rule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
        rule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
        rule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
        rule.LocalPorts = string.Join(",", TargetPort);
        rule.RemoteAddresses = string.Join(",", ips);
        rule.Enabled = true;

        policy.Rules.Add(rule);
    }
}