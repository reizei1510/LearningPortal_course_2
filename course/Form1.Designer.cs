namespace course
{
    partial class Form_Tasks
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
        private void InitializeComponent()
        {
            rtb_Tasks = new RichTextBox();
            tb_Task1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tb_Task2 = new TextBox();
            label3 = new Label();
            tb_Task3 = new TextBox();
            label4 = new Label();
            tb_Task4 = new TextBox();
            label5 = new Label();
            tb_Task5 = new TextBox();
            btn_Continue = new Button();
            btn_CheckAnswers = new Button();
            label6 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            btn_Info = new Button();
            rtb_Status = new RichTextBox();
            btn_Again = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // rtb_Tasks
            // 
            rtb_Tasks.Location = new Point(12, 12);
            rtb_Tasks.Name = "rtb_Tasks";
            rtb_Tasks.ReadOnly = true;
            rtb_Tasks.Size = new Size(311, 374);
            rtb_Tasks.TabIndex = 0;
            rtb_Tasks.Text = "";
            // 
            // tb_Task1
            // 
            tb_Task1.BorderStyle = BorderStyle.None;
            tb_Task1.Location = new Point(1, 1);
            tb_Task1.Name = "tb_Task1";
            tb_Task1.Size = new Size(130, 16);
            tb_Task1.TabIndex = 1;
            tb_Task1.TextChanged += tb_Task1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(378, 59);
            label1.Name = "label1";
            label1.Size = new Size(16, 15);
            label1.TabIndex = 2;
            label1.Text = "1:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(378, 117);
            label2.Name = "label2";
            label2.Size = new Size(16, 15);
            label2.TabIndex = 3;
            label2.Text = "2:";
            // 
            // tb_Task2
            // 
            tb_Task2.BorderStyle = BorderStyle.None;
            tb_Task2.Location = new Point(1, 1);
            tb_Task2.Name = "tb_Task2";
            tb_Task2.Size = new Size(130, 16);
            tb_Task2.TabIndex = 4;
            tb_Task2.TextChanged += tb_Task2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(378, 175);
            label3.Name = "label3";
            label3.Size = new Size(16, 15);
            label3.TabIndex = 5;
            label3.Text = "3:";
            // 
            // tb_Task3
            // 
            tb_Task3.BorderStyle = BorderStyle.None;
            tb_Task3.Location = new Point(1, 1);
            tb_Task3.Name = "tb_Task3";
            tb_Task3.Size = new Size(130, 16);
            tb_Task3.TabIndex = 6;
            tb_Task3.TextChanged += tb_Task3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(378, 233);
            label4.Name = "label4";
            label4.Size = new Size(16, 15);
            label4.TabIndex = 7;
            label4.Text = "4:";
            // 
            // tb_Task4
            // 
            tb_Task4.BorderStyle = BorderStyle.None;
            tb_Task4.Location = new Point(1, 1);
            tb_Task4.Name = "tb_Task4";
            tb_Task4.Size = new Size(130, 16);
            tb_Task4.TabIndex = 8;
            tb_Task4.TextChanged += tb_Task4_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(378, 291);
            label5.Name = "label5";
            label5.Size = new Size(16, 15);
            label5.TabIndex = 9;
            label5.Text = "5:";
            // 
            // tb_Task5
            // 
            tb_Task5.BorderStyle = BorderStyle.None;
            tb_Task5.Location = new Point(1, 1);
            tb_Task5.Name = "tb_Task5";
            tb_Task5.Size = new Size(130, 16);
            tb_Task5.TabIndex = 10;
            tb_Task5.TextChanged += tb_Task5_TextChanged;
            // 
            // btn_Continue
            // 
            btn_Continue.Location = new Point(456, 366);
            btn_Continue.Name = "btn_Continue";
            btn_Continue.Size = new Size(93, 23);
            btn_Continue.TabIndex = 11;
            btn_Continue.Text = "Продолжить";
            btn_Continue.UseVisualStyleBackColor = true;
            btn_Continue.Click += btn_Continue_Click;
            // 
            // btn_CheckAnswers
            // 
            btn_CheckAnswers.Location = new Point(357, 366);
            btn_CheckAnswers.Name = "btn_CheckAnswers";
            btn_CheckAnswers.Size = new Size(93, 23);
            btn_CheckAnswers.TabIndex = 12;
            btn_CheckAnswers.Text = "Проверить";
            btn_CheckAnswers.UseVisualStyleBackColor = true;
            btn_CheckAnswers.Click += btn_CheckAnswers_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(357, 400);
            label6.Margin = new Padding(3, 8, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 13;
            label6.Text = "_";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(tb_Task1);
            panel1.Location = new Point(399, 58);
            panel1.Margin = new Padding(3, 20, 3, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(132, 18);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(tb_Task2);
            panel2.Location = new Point(400, 116);
            panel2.Margin = new Padding(3, 20, 3, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(132, 18);
            panel2.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Controls.Add(tb_Task3);
            panel3.Location = new Point(399, 174);
            panel3.Margin = new Padding(3, 20, 3, 20);
            panel3.Name = "panel3";
            panel3.Size = new Size(132, 18);
            panel3.TabIndex = 17;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Black;
            panel4.Controls.Add(tb_Task4);
            panel4.Location = new Point(399, 232);
            panel4.Margin = new Padding(3, 20, 3, 20);
            panel4.Name = "panel4";
            panel4.Size = new Size(132, 18);
            panel4.TabIndex = 18;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Black;
            panel5.Controls.Add(tb_Task5);
            panel5.Location = new Point(399, 290);
            panel5.Margin = new Padding(3, 20, 3, 20);
            panel5.Name = "panel5";
            panel5.Size = new Size(132, 18);
            panel5.TabIndex = 19;
            // 
            // btn_Info
            // 
            btn_Info.Location = new Point(555, 366);
            btn_Info.Name = "btn_Info";
            btn_Info.Size = new Size(26, 23);
            btn_Info.TabIndex = 20;
            btn_Info.Text = "?";
            btn_Info.UseVisualStyleBackColor = true;
            btn_Info.Click += btn_Info_Click;
            // 
            // rtb_Status
            // 
            rtb_Status.Location = new Point(605, 12);
            rtb_Status.Name = "rtb_Status";
            rtb_Status.ReadOnly = true;
            rtb_Status.Size = new Size(311, 358);
            rtb_Status.TabIndex = 21;
            rtb_Status.Text = "";
            rtb_Status.Visible = false;
            // 
            // btn_Again
            // 
            btn_Again.Location = new Point(12, 392);
            btn_Again.Name = "btn_Again";
            btn_Again.Size = new Size(111, 23);
            btn_Again.TabIndex = 22;
            btn_Again.Text = "Начать заново";
            btn_Again.UseVisualStyleBackColor = true;
            btn_Again.Click += btn_Again_Click;
            // 
            // Form_Tasks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 427);
            Controls.Add(btn_Again);
            Controls.Add(rtb_Status);
            Controls.Add(btn_Info);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(btn_CheckAnswers);
            Controls.Add(btn_Continue);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rtb_Tasks);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_Tasks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "КЕГЭ";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtb_Tasks;
        private TextBox tb_Task1;
        private Label label1;
        private Label label2;
        private TextBox tb_Task2;
        private Label label3;
        private TextBox tb_Task3;
        private Label label4;
        private TextBox tb_Task4;
        private Label label5;
        private TextBox tb_Task5;
        private Button btn_Continue;
        private Button btn_CheckAnswers;
        private Label label6;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Button btn_Info;
        private RichTextBox rtb_Status;
        private Button btn_Again;
    }
}