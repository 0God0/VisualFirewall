namespace VisualFirewall
{
    partial class FireWallWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            packetContorlBox = new GroupBox();
            startMonitoring = new Button();
            fireWallControlBox = new GroupBox();
            label1 = new Label();
            ipBlockCountLable = new Label();
            globalConfigBox = new GroupBox();
            infoBoxLable = new Label();
            label2 = new Label();
            ManualAddIp = new TextBox();
            packetContorlBox.SuspendLayout();
            fireWallControlBox.SuspendLayout();
            SuspendLayout();
            // 
            // packetContorlBox
            // 
            packetContorlBox.Controls.Add(startMonitoring);
            packetContorlBox.Font = new Font("Microsoft YaHei UI", 12F);
            packetContorlBox.ForeColor = SystemColors.MenuHighlight;
            packetContorlBox.Location = new Point(12, 29);
            packetContorlBox.Name = "packetContorlBox";
            packetContorlBox.RightToLeft = RightToLeft.No;
            packetContorlBox.Size = new Size(400, 640);
            packetContorlBox.TabIndex = 0;
            packetContorlBox.TabStop = false;
            packetContorlBox.Text = "数据包控制";
            packetContorlBox.Paint += PacketContorl_Paint;
            // 
            // startMonitoring
            // 
            startMonitoring.Location = new Point(117, 65);
            startMonitoring.Name = "startMonitoring";
            startMonitoring.Size = new Size(97, 53);
            startMonitoring.TabIndex = 0;
            startMonitoring.Text = "开始监听";
            startMonitoring.UseVisualStyleBackColor = true;
            startMonitoring.Click += startMonitoring_Click;
            // 
            // fireWallControlBox
            // 
            fireWallControlBox.Controls.Add(ManualAddIp);
            fireWallControlBox.Controls.Add(label1);
            fireWallControlBox.Controls.Add(ipBlockCountLable);
            fireWallControlBox.Font = new Font("Microsoft YaHei UI", 12F);
            fireWallControlBox.ForeColor = SystemColors.MenuHighlight;
            fireWallControlBox.Location = new Point(852, 29);
            fireWallControlBox.Name = "fireWallControlBox";
            fireWallControlBox.RightToLeft = RightToLeft.No;
            fireWallControlBox.Size = new Size(400, 640);
            fireWallControlBox.TabIndex = 1;
            fireWallControlBox.TabStop = false;
            fireWallControlBox.Text = "防火墙控制";
            // 
            // label1
            // 
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(113, 31);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 2;
            label1.Text = "IP屏蔽数：";
            // 
            // ipBlockCountLable
            // 
            ipBlockCountLable.ForeColor = Color.Red;
            ipBlockCountLable.Location = new Point(213, 31);
            ipBlockCountLable.Name = "ipBlockCountLable";
            ipBlockCountLable.Size = new Size(80, 20);
            ipBlockCountLable.TabIndex = 1;
            ipBlockCountLable.Text = "0";
            // 
            // globalConfigBox
            // 
            globalConfigBox.Font = new Font("Microsoft YaHei UI", 12F);
            globalConfigBox.ForeColor = SystemColors.MenuHighlight;
            globalConfigBox.Location = new Point(431, 29);
            globalConfigBox.Name = "globalConfigBox";
            globalConfigBox.RightToLeft = RightToLeft.No;
            globalConfigBox.Size = new Size(400, 300);
            globalConfigBox.TabIndex = 2;
            globalConfigBox.TabStop = false;
            globalConfigBox.Text = "全局设置";
            // 
            // infoBoxLable
            // 
            infoBoxLable.BorderStyle = BorderStyle.FixedSingle;
            infoBoxLable.ForeColor = SystemColors.MenuHighlight;
            infoBoxLable.Location = new Point(431, 389);
            infoBoxLable.Name = "infoBoxLable";
            infoBoxLable.Padding = new Padding(3);
            infoBoxLable.Size = new Size(400, 280);
            infoBoxLable.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F);
            label2.ForeColor = SystemColors.MenuHighlight;
            label2.Location = new Point(602, 352);
            label2.Name = "label2";
            label2.Size = new Size(58, 21);
            label2.TabIndex = 4;
            label2.Text = "信息窗";
            // 
            // ManualAddIp
            // 
            ManualAddIp.Location = new Point(39, 78);
            ManualAddIp.Name = "ManualAddIp";
            ManualAddIp.Size = new Size(303, 28);
            ManualAddIp.TabIndex = 1;
            // 
            // FireWallWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(label2);
            Controls.Add(infoBoxLable);
            Controls.Add(globalConfigBox);
            Controls.Add(fireWallControlBox);
            Controls.Add(packetContorlBox);
            Font = new Font("Microsoft YaHei UI", 9F);
            Margin = new Padding(2);
            Name = "FireWallWindow";
            Text = "FireWall";
            Load += FireWallWindow_Load;
            packetContorlBox.ResumeLayout(false);
            fireWallControlBox.ResumeLayout(false);
            fireWallControlBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox packetContorlBox;
        private GroupBox fireWallControlBox;
        private GroupBox globalConfigBox;
        private Label ipBlockCountLable;
        private Label label1;
        private Label infoBoxLable;
        private Label label2;
        private Button startMonitoring;
        private TextBox ManualAddIp;
    }
}
