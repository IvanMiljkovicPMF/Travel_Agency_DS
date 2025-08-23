namespace UI.Forms
{
    partial class ClientsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            labelWelcome = new Label();
            menu = new MenuStrip();
            clientsToolStripMenuItem = new ToolStripMenuItem();
            packageToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(labelWelcome, 0, 0);
            tableLayoutPanel1.Controls.Add(menu, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Size = new Size(1482, 853);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelWelcome
            // 
            labelWelcome.Anchor = AnchorStyles.Left;
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe Print", 31.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelWelcome.ForeColor = SystemColors.HotTrack;
            labelWelcome.Location = new Point(3, 0);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(0, 85);
            labelWelcome.TabIndex = 0;
            labelWelcome.TextAlign = ContentAlignment.TopCenter;
            // 
            // menu
            // 
            menu.Anchor = AnchorStyles.None;
            menu.Dock = DockStyle.None;
            menu.GripMargin = new Padding(6);
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { clientsToolStripMenuItem, packageToolStripMenuItem });
            menu.Location = new Point(665, 113);
            menu.Name = "menu";
            menu.Size = new Size(152, 28);
            menu.TabIndex = 1;
            menu.Text = "menuStrip1";
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(67, 24);
            clientsToolStripMenuItem.Text = "Clients";
            // 
            // packageToolStripMenuItem
            // 
            packageToolStripMenuItem.Name = "packageToolStripMenuItem";
            packageToolStripMenuItem.Size = new Size(77, 24);
            packageToolStripMenuItem.Text = "Package";
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1482, 853);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menu;
            Name = "ClientsForm";
            Text = "Global Escapes";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label labelWelcome;
        private MenuStrip menu;
        private ToolStripMenuItem clientsToolStripMenuItem;
        private ToolStripMenuItem packageToolStripMenuItem;
    }
}