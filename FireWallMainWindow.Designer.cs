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
            label3 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            addIPButton = new Button();
            remIPButton = new Button();
            ipInput = new TextBox();
            reLoadButton = new Button();
            label1 = new Label();
            ipBlockCountLable = new Label();
            globalConfigBox = new GroupBox();
            label2 = new Label();
            infoBox = new TextBox();
            packetContorlBox.SuspendLayout();
            fireWallControlBox.SuspendLayout();
            panel1.SuspendLayout();
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
            startMonitoring.Location = new Point(280, 26);
            startMonitoring.Name = "startMonitoring";
            startMonitoring.Size = new Size(97, 53);
            startMonitoring.TabIndex = 0;
            startMonitoring.Text = "开始监听";
            startMonitoring.UseVisualStyleBackColor = true;
            startMonitoring.Click += startMonitoring_Click;
            // 
            // fireWallControlBox
            // 
            fireWallControlBox.Controls.Add(label3);
            fireWallControlBox.Controls.Add(panel1);
            fireWallControlBox.Controls.Add(reLoadButton);
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F);
            label3.ForeColor = SystemColors.MenuHighlight;
            label3.Location = new Point(153, 323);
            label3.Name = "label3";
            label3.Size = new Size(105, 21);
            label3.TabIndex = 7;
            label3.Text = "IP地址操作区";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(addIPButton);
            panel1.Controls.Add(remIPButton);
            panel1.Controls.Add(ipInput);
            panel1.Location = new Point(16, 360);
            panel1.Name = "panel1";
            panel1.Size = new Size(369, 265);
            panel1.TabIndex = 6;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Microsoft YaHei UI", 12F);
            label4.ForeColor = SystemColors.Desktop;
            label4.Location = new Point(36, 171);
            label4.Name = "label4";
            label4.Size = new Size(94, 66);
            label4.TabIndex = 8;
            label4.Text = "IP输入区：";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // addIPButton
            // 
            addIPButton.ForeColor = Color.Red;
            addIPButton.Location = new Point(136, 205);
            addIPButton.Name = "addIPButton";
            addIPButton.Size = new Size(96, 32);
            addIPButton.TabIndex = 3;
            addIPButton.Text = "屏蔽此IP";
            addIPButton.UseVisualStyleBackColor = true;
            addIPButton.Click += addIPButton_Click;
            // 
            // remIPButton
            // 
            remIPButton.ForeColor = Color.Lime;
            remIPButton.Location = new Point(243, 205);
            remIPButton.Name = "remIPButton";
            remIPButton.Size = new Size(96, 32);
            remIPButton.TabIndex = 4;
            remIPButton.Text = "移除此IP";
            remIPButton.UseVisualStyleBackColor = true;
            remIPButton.Click += remIPButton_Click;
            // 
            // ipInput
            // 
            ipInput.Location = new Point(136, 171);
            ipInput.Name = "ipInput";
            ipInput.Size = new Size(203, 28);
            ipInput.TabIndex = 1;
            // 
            // reLoadButton
            // 
            reLoadButton.Location = new Point(260, 38);
            reLoadButton.Name = "reLoadButton";
            reLoadButton.Size = new Size(96, 32);
            reLoadButton.TabIndex = 5;
            reLoadButton.Text = "刷新";
            reLoadButton.UseVisualStyleBackColor = true;
            reLoadButton.Click += reLoadButton_Click;
            // 
            // label1
            // 
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(53, 42);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 2;
            label1.Text = "IP屏蔽数：";
            // 
            // ipBlockCountLable
            // 
            ipBlockCountLable.ForeColor = Color.Red;
            ipBlockCountLable.Location = new Point(164, 42);
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
            // infoBox
            // 
            infoBox.BackColor = Color.White;
            infoBox.Location = new Point(431, 389);
            infoBox.Multiline = true;
            infoBox.Name = "infoBox";
            infoBox.ReadOnly = true;
            infoBox.ScrollBars = ScrollBars.Horizontal;
            infoBox.Size = new Size(400, 280);
            infoBox.TabIndex = 5;
            infoBox.TextChanged += infoBox_TextChanged;
            // 
            // FireWallWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1264, 681);
            Controls.Add(infoBox);
            Controls.Add(label2);
            Controls.Add(globalConfigBox);
            Controls.Add(fireWallControlBox);
            Controls.Add(packetContorlBox);
            Font = new Font("Microsoft YaHei UI", 9F);
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FireWallWindow";
            Text = "FireWall";
            Load += FireWallWindow_Load;
            packetContorlBox.ResumeLayout(false);
            fireWallControlBox.ResumeLayout(false);
            fireWallControlBox.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox packetContorlBox;
        private GroupBox fireWallControlBox;
        private GroupBox globalConfigBox;
        private Label ipBlockCountLable;
        private Label label1;
        private Label label2;
        private Button startMonitoring;
        private TextBox ipInput;
        private Button addIPButton;
        private Button remIPButton;
        private Button reLoadButton;
        private Label label3;
        private Panel panel1;
        private Label label4;
        private TextBox infoBox;
    }
}
