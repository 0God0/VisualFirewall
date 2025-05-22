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
            //TODO: ��̬��ȡ���ζ˿�
            fireWallBlock = new FireWallBlockPort(new List<int> { 25101,20602 });
        }

        public static string GenerateRandomIp() {
            Random random = new Random();
            // �����ĸ�0-255֮��������
            int octet1 = random.Next(0, 256);
            int octet2 = random.Next(0, 256);
            int octet3 = random.Next(0, 256);
            int octet4 = random.Next(0, 256);

            // ��ϳ�IP��ַ�ַ���
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
                infoBoxLable.Text += $"������ {detectedIps.Count} ��IP\n";
            } catch (UnauthorizedAccessException) {
                infoBoxLable.Text += "���Թ���Ա������г���\n";
            } catch (Exception ex) {
                infoBoxLable.Text += $"��������: {ex.Message}\n";
            }

        }
    }
}
