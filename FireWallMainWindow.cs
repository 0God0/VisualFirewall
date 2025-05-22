using System;
using System.Collections.Concurrent;
using System.Net.Sockets;

namespace VisualFirewall {
    public partial class FireWallWindow : Form {

        public FireWallBlockPort fireWallBlock;

        public FireWallWindow() {
            InitializeComponent();
        }

        private void PacketContorl_Paint(object sender, PaintEventArgs e) {
            GroupBox box = (GroupBox)sender;
        }

        private void FireWallWindow_Load(object sender, EventArgs e) {
            //TODO: 动态读取屏蔽端口
            fireWallBlock = new FireWallBlockPort(new List<int> { 25101,20602 });
        }

        public static string GenerateRandomIp() {
            Random random = new Random();
            // 生成四个0-255之间的随机数
            int octet1 = random.Next(0, 256);
            int octet2 = random.Next(0, 256);
            int octet3 = random.Next(0, 256);
            int octet4 = random.Next(0, 256);

            // 组合成IP地址字符串
            return $"{octet1}.{octet2}.{octet3}.{octet4}";
        }

        private void startMonitoring_Click(object sender, EventArgs e) {

            var detectedIps = new List<string>() {
                "1.1.1.1"
            };
            //var detectedIps = new List<string>();
            //for (int i = 0; i < 10000; i++) detectedIps.Add(GenerateRandomIp());
            try {
                fireWallBlock.UpdateBlocklist(detectedIps);
                infoBoxLable.Text += $"已屏蔽 {detectedIps.Count} 个IP\n";
            } catch (UnauthorizedAccessException) {
                infoBoxLable.Text += "请以管理员身份运行程序\n";
            } catch (Exception ex) {
                infoBoxLable.Text += $"发生错误: {ex.Message}\n";
            }

        }
    }
}
