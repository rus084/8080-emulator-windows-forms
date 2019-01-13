namespace WindowsFormsApp1
{
    partial class Assembler
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дизасемблироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ассемблироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.дизасемблироватьToolStripMenuItem,
            this.ассемблироватьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(362, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // дизасемблироватьToolStripMenuItem
            // 
            this.дизасемблироватьToolStripMenuItem.Name = "дизасемблироватьToolStripMenuItem";
            this.дизасемблироватьToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.дизасемблироватьToolStripMenuItem.Text = "Дизасемблировать";
            this.дизасемблироватьToolStripMenuItem.Click += new System.EventHandler(this.дизасемблироватьToolStripMenuItem_Click);
            // 
            // ассемблироватьToolStripMenuItem
            // 
            this.ассемблироватьToolStripMenuItem.Name = "ассемблироватьToolStripMenuItem";
            this.ассемблироватьToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.ассемблироватьToolStripMenuItem.Text = "Ассемблировать";
            this.ассемблироватьToolStripMenuItem.Click += new System.EventHandler(this.ассемблироватьToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(362, 251);
            this.textBox1.TabIndex = 1;
            // 
            // Assembler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 275);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Assembler";
            this.Text = "Assembler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Assembler_FormClosing);
            this.Load += new System.EventHandler(this.Assembler_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дизасемблироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ассемблироватьToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}