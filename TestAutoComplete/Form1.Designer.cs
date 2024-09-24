namespace TestAutoComplete
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.intelligenceMenu1 = new intelligenceLite.IntelligenceMenu();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.intelligenceMenu1.SetIntelligenceMenu(this.richTextBox1, this.intelligenceMenu1);
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(891, 506);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // intelligenceMenu1
            // 
            this.intelligenceMenu1.AllowsTabKey = true;
            this.intelligenceMenu1.AppearInterval = 100;
            this.intelligenceMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.intelligenceMenu1.Border = true;
            this.intelligenceMenu1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.intelligenceMenu1.BorderSize = ((byte)(2));
            this.intelligenceMenu1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intelligenceMenu1.ForeColor = System.Drawing.Color.White;
            this.intelligenceMenu1.HighlightingColor = System.Drawing.Color.IndianRed;
            this.intelligenceMenu1.ImageList = null;
            this.intelligenceMenu1.Items = new string[] {
        "Apple",
        "App",
        "Microsoft",
        "Micro",
        "Google",
        "Golden",
        "Android",
        "Facebook",
        "Meta",
        "Windows",
        "Linux"};
            this.intelligenceMenu1.MinFragmentLength = 1;
            this.intelligenceMenu1.SelectedBackColor = System.Drawing.Color.BlueViolet;
            this.intelligenceMenu1.SelectedBackColor2 = System.Drawing.Color.DodgerBlue;
            this.intelligenceMenu1.SelectedForeColor = System.Drawing.Color.White;
            this.intelligenceMenu1.TargetControlWrapper = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 506);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private intelligenceLite.IntelligenceMenu intelligenceMenu1;
    }
}

