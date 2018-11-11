namespace SpaceForms
{
    partial class SpaceForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartToolStripMenuItem,
            this.PauseToolStripMenuItem,
            this.RecordsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // StartToolStripMenuItem
            // 
            resources.ApplyResources(this.StartToolStripMenuItem, "StartToolStripMenuItem");
            this.StartToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            this.StartToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // PauseToolStripMenuItem
            // 
            resources.ApplyResources(this.PauseToolStripMenuItem, "PauseToolStripMenuItem");
            this.PauseToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.PauseToolStripMenuItem.Name = "PauseToolStripMenuItem";
            this.PauseToolStripMenuItem.Click += new System.EventHandler(this.PauseToolStripMenuItem_Click);
            // 
            // RecordsToolStripMenuItem
            // 
            resources.ApplyResources(this.RecordsToolStripMenuItem, "RecordsToolStripMenuItem");
            this.RecordsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.RecordsToolStripMenuItem.Name = "RecordsToolStripMenuItem";
            // 
            // ExitToolStripMenuItem
            // 
            resources.ApplyResources(this.ExitToolStripMenuItem, "ExitToolStripMenuItem");
            this.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // SpaceForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SpaceForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}

