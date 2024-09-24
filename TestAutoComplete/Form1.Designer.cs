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
            intelligenceLite.IntelligenceItem intelligenceItem1 = new intelligenceLite.IntelligenceItem();
            intelligenceLite.IntelligenceItem intelligenceItem2 = new intelligenceLite.IntelligenceItem();
            intelligenceLite.IntelligenceItem intelligenceItem3 = new intelligenceLite.IntelligenceItem();
            intelligenceLite.IntelligenceItem intelligenceItem4 = new intelligenceLite.IntelligenceItem();
            intelligenceLite.IntelligenceItem intelligenceItem5 = new intelligenceLite.IntelligenceItem();
            intelligenceLite.IntelligenceItem intelligenceItem6 = new intelligenceLite.IntelligenceItem();
            intelligenceLite.IntelligenceItem intelligenceItem7 = new intelligenceLite.IntelligenceItem();
            intelligenceLite.IntelligenceItem intelligenceItem8 = new intelligenceLite.IntelligenceItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.intelligenceMenu1 = new intelligenceLite.IntelligenceMenu();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-delete-48.png");
            this.imageList1.Images.SetKeyName(1, "icons8-select-all-48.png");
            this.imageList1.Images.SetKeyName(2, "icons8-cut-48.png");
            this.imageList1.Images.SetKeyName(3, "icons8-paste-48.png");
            this.imageList1.Images.SetKeyName(4, "icons8-copy-48.png");
            this.imageList1.Images.SetKeyName(5, "icons8-redo-48.png");
            this.imageList1.Images.SetKeyName(6, "icons8-visual-basic-48.png");
            this.imageList1.Images.SetKeyName(7, "icons8-javascript-48.png");
            this.imageList1.Images.SetKeyName(8, "icons8-python-48.png");
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
            this.intelligenceMenu1.AppearInterval = 100;
            this.intelligenceMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.intelligenceMenu1.Border = true;
            this.intelligenceMenu1.BorderColor = System.Drawing.Color.LimeGreen;
            this.intelligenceMenu1.BorderSize = ((byte)(2));
            this.intelligenceMenu1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intelligenceMenu1.ForeColor = System.Drawing.Color.White;
            this.intelligenceMenu1.HighlightingColor = System.Drawing.Color.LimeGreen;
            this.intelligenceMenu1.ImageList = this.imageList1;
            intelligenceItem1.Icon = ((System.Drawing.Image)(resources.GetObject("intelligenceItem1.Icon")));
            intelligenceItem1.ImageIndex = -1;
            intelligenceItem1.MenuText = null;
            intelligenceItem1.SymbolColor = System.Drawing.Color.Crimson;
            intelligenceItem1.SymbolIcon = "";
            intelligenceItem1.SymbolSize = ((byte)(10));
            intelligenceItem1.Text = "Android";
            intelligenceItem1.ToolTipText = null;
            intelligenceItem1.ToolTipTitle = null;
            intelligenceItem2.Icon = null;
            intelligenceItem2.ImageIndex = -1;
            intelligenceItem2.MenuText = null;
            intelligenceItem2.SymbolColor = System.Drawing.Color.Crimson;
            intelligenceItem2.SymbolIcon = "";
            intelligenceItem2.SymbolSize = ((byte)(10));
            intelligenceItem2.Text = "Windows";
            intelligenceItem2.ToolTipText = null;
            intelligenceItem2.ToolTipTitle = null;
            intelligenceItem3.Icon = null;
            intelligenceItem3.ImageIndex = -1;
            intelligenceItem3.MenuText = null;
            intelligenceItem3.SymbolColor = System.Drawing.Color.Crimson;
            intelligenceItem3.SymbolIcon = "";
            intelligenceItem3.SymbolSize = ((byte)(10));
            intelligenceItem3.Text = "Linux";
            intelligenceItem3.ToolTipText = null;
            intelligenceItem3.ToolTipTitle = null;
            intelligenceItem4.Icon = null;
            intelligenceItem4.ImageIndex = -1;
            intelligenceItem4.MenuText = null;
            intelligenceItem4.SymbolColor = System.Drawing.Color.Crimson;
            intelligenceItem4.SymbolIcon = "";
            intelligenceItem4.SymbolSize = ((byte)(10));
            intelligenceItem4.Text = "Microsoft";
            intelligenceItem4.ToolTipText = null;
            intelligenceItem4.ToolTipTitle = null;
            intelligenceItem5.Icon = null;
            intelligenceItem5.ImageIndex = -1;
            intelligenceItem5.MenuText = null;
            intelligenceItem5.SymbolColor = System.Drawing.Color.Crimson;
            intelligenceItem5.SymbolIcon = "";
            intelligenceItem5.SymbolSize = ((byte)(10));
            intelligenceItem5.Text = "Micro";
            intelligenceItem5.ToolTipText = null;
            intelligenceItem5.ToolTipTitle = null;
            intelligenceItem6.Icon = null;
            intelligenceItem6.ImageIndex = -1;
            intelligenceItem6.MenuText = null;
            intelligenceItem6.SymbolColor = System.Drawing.Color.Crimson;
            intelligenceItem6.SymbolIcon = "";
            intelligenceItem6.SymbolSize = ((byte)(10));
            intelligenceItem6.Text = "Google";
            intelligenceItem6.ToolTipText = null;
            intelligenceItem6.ToolTipTitle = null;
            intelligenceItem7.Icon = null;
            intelligenceItem7.ImageIndex = -1;
            intelligenceItem7.MenuText = null;
            intelligenceItem7.SymbolColor = System.Drawing.Color.Crimson;
            intelligenceItem7.SymbolIcon = "";
            intelligenceItem7.SymbolSize = ((byte)(10));
            intelligenceItem7.Text = "Golden";
            intelligenceItem7.ToolTipText = null;
            intelligenceItem7.ToolTipTitle = null;
            intelligenceItem8.Icon = null;
            intelligenceItem8.ImageIndex = -1;
            intelligenceItem8.MenuText = null;
            intelligenceItem8.SymbolColor = System.Drawing.Color.Crimson;
            intelligenceItem8.SymbolIcon = "";
            intelligenceItem8.SymbolSize = ((byte)(10));
            intelligenceItem8.Text = "Apple";
            intelligenceItem8.ToolTipText = null;
            intelligenceItem8.ToolTipTitle = null;
            this.intelligenceMenu1.Items = new intelligenceLite.IntelligenceItem[] {
        intelligenceItem1,
        intelligenceItem2,
        intelligenceItem3,
        intelligenceItem4,
        intelligenceItem5,
        intelligenceItem6,
        intelligenceItem7,
        intelligenceItem8};
            this.intelligenceMenu1.LeftPadding = 28;
            this.intelligenceMenu1.MinFragmentLength = 1;
            this.intelligenceMenu1.SelectedBackColor = System.Drawing.Color.LimeGreen;
            this.intelligenceMenu1.SelectedBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.intelligenceMenu1.SelectedForeColor = System.Drawing.Color.White;
            this.intelligenceMenu1.Style = intelligenceLite.Styles.Fusion;
            this.intelligenceMenu1.TargetControlWrapper = null;
            this.intelligenceMenu1.Theme = intelligenceLite.Themes.Dark;
            this.intelligenceMenu1.ThemeColor = System.Drawing.Color.LimeGreen;
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

