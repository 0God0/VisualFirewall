using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Windows.Forms;

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
            fireWallBlock = new FireWallBlockPort(new List<int> { 25101, 20602 }, message => infoBox.Text += message + Environment.NewLine);
            Task.Run(() => {
                while (true) {
                    ipBlockCountLable.Text = fireWallBlock.getBlockedIPCount().ToString();
                    Thread.Sleep(1000);
                }
            });
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



        }

        private async void addIPButton_Click(object sender, EventArgs e) {
            addIPButton.Enabled = false;
            HashSet<string> ip = new HashSet<string>();
            ip.Add(ipInput.Text.Trim());
            await Task.Run(() => fireWallBlock.addIPs(ip));
            addIPButton.Enabled = true;
        }

        private async void remIPButton_Click(object sender, EventArgs e) {
            remIPButton.Enabled = false;
            HashSet<string> ip = new HashSet<string>();
            ip.Add(ipInput.Text.Trim());
            await Task.Run(() => fireWallBlock.removeIPs(ip));
            remIPButton.Enabled = true;
        }

        private void infoBox_TextChanged(object sender, EventArgs e) {
            if (infoBox.Text.Length > 2000) {
                infoBox.Text = string.Empty;
            }
            infoBox.SelectionStart = infoBox.Text.Length;
            infoBox.ScrollToCaret();
        }

        private void reLoadButton_Click(object sender, EventArgs e) {
            ipBlockCountLable.Text = fireWallBlock.getBlockedIPCount().ToString();
        }
    }
}
