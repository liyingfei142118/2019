namespace 交换机模拟
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.from = new System.Windows.Forms.ComboBox();
            this.to = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.send = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.infos1 = new System.Windows.Forms.TextBox();
            this.infos2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mac1 = new System.Windows.Forms.TextBox();
            this.mac2 = new System.Windows.Forms.TextBox();
            this.mac3 = new System.Windows.Forms.TextBox();
            this.mac4 = new System.Windows.Forms.TextBox();
            this.mac5 = new System.Windows.Forms.TextBox();
            this.mac6 = new System.Windows.Forms.TextBox();
            this.clears1 = new System.Windows.Forms.Button();
            this.clears2 = new System.Windows.Forms.Button();
            this.text = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.c1Info = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.c2Info = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.c3Info = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.c4Info = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.c5Info = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.c6Info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            // 
            // from
            // 
            this.from.FormattingEnabled = true;
            this.from.Location = new System.Drawing.Point(42, 64);
            this.from.Margin = new System.Windows.Forms.Padding(2);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(92, 20);
            this.from.TabIndex = 1;
            // 
            // to
            // 
            this.to.FormattingEnabled = true;
            this.to.Location = new System.Drawing.Point(165, 64);
            this.to.Margin = new System.Windows.Forms.Padding(2);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(92, 20);
            this.to.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "To:";
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(270, 64);
            this.send.Margin = new System.Windows.Forms.Padding(2);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(56, 20);
            this.send.TabIndex = 4;
            this.send.Text = "发送";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "S1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "S2:";
            // 
            // infos1
            // 
            this.infos1.Location = new System.Drawing.Point(359, 26);
            this.infos1.Margin = new System.Windows.Forms.Padding(2);
            this.infos1.Multiline = true;
            this.infos1.Name = "infos1";
            this.infos1.ReadOnly = true;
            this.infos1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infos1.Size = new System.Drawing.Size(372, 143);
            this.infos1.TabIndex = 7;
            this.infos1.TextChanged += new System.EventHandler(this.infos1_TextChanged);
            // 
            // infos2
            // 
            this.infos2.Location = new System.Drawing.Point(358, 188);
            this.infos2.Margin = new System.Windows.Forms.Padding(2);
            this.infos2.Multiline = true;
            this.infos2.Name = "infos2";
            this.infos2.ReadOnly = true;
            this.infos2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infos2.Size = new System.Drawing.Size(372, 149);
            this.infos2.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "C1 Mac:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 170);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "C2 Mac:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 209);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "C3 Mac:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 248);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "C4 Mac:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 284);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "C5 Mac:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 318);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "C6 Mac:";
            // 
            // mac1
            // 
            this.mac1.Location = new System.Drawing.Point(70, 131);
            this.mac1.Margin = new System.Windows.Forms.Padding(2);
            this.mac1.Name = "mac1";
            this.mac1.Size = new System.Drawing.Size(170, 21);
            this.mac1.TabIndex = 15;
            this.mac1.TextChanged += new System.EventHandler(this.mac1_TextChanged);
            // 
            // mac2
            // 
            this.mac2.Location = new System.Drawing.Point(70, 167);
            this.mac2.Margin = new System.Windows.Forms.Padding(2);
            this.mac2.Name = "mac2";
            this.mac2.Size = new System.Drawing.Size(170, 21);
            this.mac2.TabIndex = 16;
            this.mac2.TextChanged += new System.EventHandler(this.mac2_TextChanged);
            // 
            // mac3
            // 
            this.mac3.Location = new System.Drawing.Point(70, 206);
            this.mac3.Margin = new System.Windows.Forms.Padding(2);
            this.mac3.Name = "mac3";
            this.mac3.Size = new System.Drawing.Size(170, 21);
            this.mac3.TabIndex = 17;
            this.mac3.TextChanged += new System.EventHandler(this.mac3_TextChanged);
            // 
            // mac4
            // 
            this.mac4.Location = new System.Drawing.Point(70, 246);
            this.mac4.Margin = new System.Windows.Forms.Padding(2);
            this.mac4.Name = "mac4";
            this.mac4.Size = new System.Drawing.Size(170, 21);
            this.mac4.TabIndex = 18;
            this.mac4.TextChanged += new System.EventHandler(this.mac4_TextChanged);
            // 
            // mac5
            // 
            this.mac5.Location = new System.Drawing.Point(70, 282);
            this.mac5.Margin = new System.Windows.Forms.Padding(2);
            this.mac5.Name = "mac5";
            this.mac5.Size = new System.Drawing.Size(170, 21);
            this.mac5.TabIndex = 19;
            this.mac5.TextChanged += new System.EventHandler(this.mac5_TextChanged);
            // 
            // mac6
            // 
            this.mac6.Location = new System.Drawing.Point(70, 316);
            this.mac6.Margin = new System.Windows.Forms.Padding(2);
            this.mac6.Name = "mac6";
            this.mac6.Size = new System.Drawing.Size(170, 21);
            this.mac6.TabIndex = 20;
            this.mac6.TextChanged += new System.EventHandler(this.mac6_TextChanged);
            // 
            // clears1
            // 
            this.clears1.Location = new System.Drawing.Point(748, 26);
            this.clears1.Margin = new System.Windows.Forms.Padding(2);
            this.clears1.Name = "clears1";
            this.clears1.Size = new System.Drawing.Size(56, 18);
            this.clears1.TabIndex = 21;
            this.clears1.Text = "Clear";
            this.clears1.UseVisualStyleBackColor = true;
            this.clears1.Click += new System.EventHandler(this.clears1_Click);
            // 
            // clears2
            // 
            this.clears2.Location = new System.Drawing.Point(748, 188);
            this.clears2.Margin = new System.Windows.Forms.Padding(2);
            this.clears2.Name = "clears2";
            this.clears2.Size = new System.Drawing.Size(56, 18);
            this.clears2.TabIndex = 22;
            this.clears2.Text = "Clear";
            this.clears2.UseVisualStyleBackColor = true;
            this.clears2.Click += new System.EventHandler(this.clears2_Click);
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(42, 22);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(215, 21);
            this.text.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "text:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 364);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "C1:";
            // 
            // c1Info
            // 
            this.c1Info.Location = new System.Drawing.Point(47, 364);
            this.c1Info.Multiline = true;
            this.c1Info.Name = "c1Info";
            this.c1Info.ReadOnly = true;
            this.c1Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c1Info.Size = new System.Drawing.Size(210, 131);
            this.c1Info.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(280, 364);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 27;
            this.label13.Text = "C2:";
            // 
            // c2Info
            // 
            this.c2Info.Location = new System.Drawing.Point(310, 364);
            this.c2Info.Multiline = true;
            this.c2Info.Name = "c2Info";
            this.c2Info.ReadOnly = true;
            this.c2Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c2Info.Size = new System.Drawing.Size(217, 131);
            this.c2Info.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(553, 364);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 12);
            this.label14.TabIndex = 29;
            this.label14.Text = "C3:";
            // 
            // c3Info
            // 
            this.c3Info.Location = new System.Drawing.Point(582, 364);
            this.c3Info.Multiline = true;
            this.c3Info.Name = "c3Info";
            this.c3Info.ReadOnly = true;
            this.c3Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c3Info.Size = new System.Drawing.Size(213, 131);
            this.c3Info.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 512);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 12);
            this.label15.TabIndex = 31;
            this.label15.Text = "C4:";
            // 
            // c4Info
            // 
            this.c4Info.Location = new System.Drawing.Point(47, 512);
            this.c4Info.Multiline = true;
            this.c4Info.Name = "c4Info";
            this.c4Info.ReadOnly = true;
            this.c4Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c4Info.Size = new System.Drawing.Size(210, 134);
            this.c4Info.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(282, 511);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 12);
            this.label16.TabIndex = 33;
            this.label16.Text = "C5:";
            // 
            // c5Info
            // 
            this.c5Info.Location = new System.Drawing.Point(310, 512);
            this.c5Info.Multiline = true;
            this.c5Info.Name = "c5Info";
            this.c5Info.ReadOnly = true;
            this.c5Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c5Info.Size = new System.Drawing.Size(217, 134);
            this.c5Info.TabIndex = 34;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(555, 511);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 12);
            this.label17.TabIndex = 35;
            this.label17.Text = "C6:";
            // 
            // c6Info
            // 
            this.c6Info.Location = new System.Drawing.Point(582, 512);
            this.c6Info.Multiline = true;
            this.c6Info.Name = "c6Info";
            this.c6Info.ReadOnly = true;
            this.c6Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c6Info.Size = new System.Drawing.Size(213, 134);
            this.c6Info.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 764);
            this.Controls.Add(this.c6Info);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.c5Info);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.c4Info);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.c3Info);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.c2Info);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.c1Info);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.text);
            this.Controls.Add(this.clears2);
            this.Controls.Add(this.clears1);
            this.Controls.Add(this.mac6);
            this.Controls.Add(this.mac5);
            this.Controls.Add(this.mac4);
            this.Controls.Add(this.mac3);
            this.Controls.Add(this.mac2);
            this.Controls.Add(this.mac1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.infos2);
            this.Controls.Add(this.infos1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.send);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.to);
            this.Controls.Add(this.from);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "交换机模拟";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox from;
        private System.Windows.Forms.ComboBox to;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox infos1;
        public System.Windows.Forms.TextBox infos2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox mac1;
        private System.Windows.Forms.TextBox mac2;
        private System.Windows.Forms.TextBox mac3;
        private System.Windows.Forms.TextBox mac4;
        private System.Windows.Forms.TextBox mac5;
        private System.Windows.Forms.TextBox mac6;
        private System.Windows.Forms.Button clears1;
        private System.Windows.Forms.Button clears2;
        private System.Windows.Forms.TextBox text;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox c1Info;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox c2Info;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox c3Info;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox c4Info;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox c5Info;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox c6Info;
    }
}

