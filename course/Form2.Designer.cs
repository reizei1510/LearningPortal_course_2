namespace course
{
    partial class Form_Again
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btn_Yes = new Button();
            btn_No = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 36);
            label1.Name = "label1";
            label1.Size = new Size(167, 15);
            label1.TabIndex = 0;
            label1.Text = "Начать с первой сложности?";
            // 
            // btn_Yes
            // 
            btn_Yes.Location = new Point(60, 82);
            btn_Yes.Name = "btn_Yes";
            btn_Yes.Size = new Size(75, 23);
            btn_Yes.TabIndex = 1;
            btn_Yes.Text = "Да";
            btn_Yes.UseVisualStyleBackColor = true;
            btn_Yes.Click += btn_Yes_Click;
            // 
            // btn_No
            // 
            btn_No.Location = new Point(213, 82);
            btn_No.Name = "btn_No";
            btn_No.Size = new Size(75, 23);
            btn_No.TabIndex = 2;
            btn_No.Text = "Нет";
            btn_No.UseVisualStyleBackColor = true;
            btn_No.Click += btn_No_Click;
            // 
            // Form_Again
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 130);
            Controls.Add(btn_No);
            Controls.Add(btn_Yes);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_Again";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Подтверждение";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_Yes;
        private Button btn_No;
    }
}