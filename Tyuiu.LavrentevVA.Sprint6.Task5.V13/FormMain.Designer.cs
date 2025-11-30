namespace Tyuiu.LavrentevVA.Sprint6.Task5.V13
{
    partial class FormMain
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
            f = new Button();
            SuspendLayout();
            // 
            // f
            // 
            f.BackColor = Color.Green;
            f.Location = new Point(754, 12);
            f.Name = "f";
            f.Size = new Size(86, 70);
            f.TabIndex = 0;
            f.Text = "Выполнить";
            f.UseVisualStyleBackColor = false;
            f.Click += this.button1_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 450);
            Controls.Add(f);
            Name = "FormMain";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button f;
    }
}
