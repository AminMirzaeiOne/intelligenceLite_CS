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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.intelligenceMenu1 = new intelligenceLite.IntelligenceMenu();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.DimGray;
            this.imageList1.Images.SetKeyName(0, "icons8-delete-48.png");
            this.imageList1.Images.SetKeyName(1, "icons8-select-all-48.png");
            this.imageList1.Images.SetKeyName(2, "icons8-cut-48.png");
            this.imageList1.Images.SetKeyName(3, "icons8-paste-48.png");
            this.imageList1.Images.SetKeyName(4, "icons8-copy-48.png");
            this.imageList1.Images.SetKeyName(5, "icons8-edit-48.png");
            this.imageList1.Images.SetKeyName(6, "icons8-visual-basic-48.png");
            this.imageList1.Images.SetKeyName(7, "icons8-javascript-48.png");
            this.imageList1.Images.SetKeyName(8, "icons8-python-48.png");
            this.imageList1.Images.SetKeyName(9, "icons8-c++-48.png");
            this.imageList1.Images.SetKeyName(10, "icons8-c-sharp-logo-48.png");
            this.imageList1.Images.SetKeyName(11, "icons8-gmail-48.png");
            this.imageList1.Images.SetKeyName(12, "icons8-instagram-48.png");
            this.imageList1.Images.SetKeyName(13, "icons8-github-48.png");
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
            this.intelligenceMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.intelligenceMenu1.Border = true;
            this.intelligenceMenu1.BorderColor = System.Drawing.Color.Violet;
            this.intelligenceMenu1.BorderSize = ((byte)(2));
            this.intelligenceMenu1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intelligenceMenu1.ForeColor = System.Drawing.Color.White;
            this.intelligenceMenu1.HighlightingColor = System.Drawing.Color.Violet;
            this.intelligenceMenu1.ImageList = this.imageList1;
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
            this.intelligenceMenu1.SelectedBackColor = System.Drawing.Color.Violet;
            this.intelligenceMenu1.SelectedBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(238)))), ((int)(((byte)(130)))), ((int)(((byte)(238)))));
            this.intelligenceMenu1.SelectedForeColor = System.Drawing.Color.White;
            this.intelligenceMenu1.TargetControlWrapper = null;
            this.intelligenceMenu1.Theme = intelligenceLite.Themes.Dark;
            this.intelligenceMenu1.ThemeColor = System.Drawing.Color.Violet;
            this.intelligenceMenu1.ThemeColorEnable = true;
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
        private System.Windows.Forms.ImageList imageList1;
    }
}

