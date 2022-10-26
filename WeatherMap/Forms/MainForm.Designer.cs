namespace WeatherMap.Forms
{
    partial class MainForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lText = new System.Windows.Forms.Label();
            this.btnChooseOnMap = new System.Windows.Forms.Button();
            this.lLocation = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.lTemp = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAuthorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTab = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTab = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lText
            // 
            this.lText.AutoSize = true;
            this.lText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lText.Location = new System.Drawing.Point(12, 27);
            this.lText.Margin = new System.Windows.Forms.Padding(3);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(124, 21);
            this.lText.TabIndex = 1;
            this.lText.Text = "Enter location or";
            // 
            // btnChooseOnMap
            // 
            this.btnChooseOnMap.AutoSize = true;
            this.btnChooseOnMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChooseOnMap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChooseOnMap.Location = new System.Drawing.Point(137, 22);
            this.btnChooseOnMap.Name = "btnChooseOnMap";
            this.btnChooseOnMap.Size = new System.Drawing.Size(135, 31);
            this.btnChooseOnMap.TabIndex = 2;
            this.btnChooseOnMap.Text = "Choose on map";
            this.btnChooseOnMap.UseVisualStyleBackColor = true;
            this.btnChooseOnMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnChooseOnMap_MouseClick);
            // 
            // lLocation
            // 
            this.lLocation.AutoSize = true;
            this.lLocation.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLocation.Location = new System.Drawing.Point(78, 6);
            this.lLocation.Margin = new System.Windows.Forms.Padding(3);
            this.lLocation.Name = "lLocation";
            this.lLocation.Size = new System.Drawing.Size(90, 25);
            this.lLocation.TabIndex = 0;
            this.lLocation.Text = "lLocation";
            this.lLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lLocation.TextChanged += new System.EventHandler(this.lLocation_TextChanged);
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStatus.Location = new System.Drawing.Point(94, 114);
            this.lStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(59, 21);
            this.lStatus.TabIndex = 3;
            this.lStatus.Text = "lStatus";
            // 
            // lTemp
            // 
            this.lTemp.AutoSize = true;
            this.lTemp.Font = new System.Drawing.Font("Segoe UI", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTemp.Location = new System.Drawing.Point(38, 37);
            this.lTemp.Margin = new System.Windows.Forms.Padding(3);
            this.lTemp.Name = "lTemp";
            this.lTemp.Size = new System.Drawing.Size(171, 71);
            this.lTemp.TabIndex = 1;
            this.lTemp.Text = "lTemp";
            this.lTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(94, 144);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(64, 64);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.settingsMenu, this.helpToolStripMenuItem });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(283, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // settingsMenu
            // 
            this.settingsMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(61, 20);
            this.settingsMenu.Text = "Settings";
            this.settingsMenu.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.aboutAppToolStripMenuItem, this.aboutAuthorsToolStripMenuItem });
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutAppToolStripMenuItem
            // 
            this.aboutAppToolStripMenuItem.Name = "aboutAppToolStripMenuItem";
            this.aboutAppToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutAppToolStripMenuItem.Text = "About app";
            this.aboutAppToolStripMenuItem.Click += new System.EventHandler(this.aboutAppToolStripMenuItem_Click);
            // 
            // aboutAuthorsToolStripMenuItem
            // 
            this.aboutAuthorsToolStripMenuItem.Name = "aboutAuthorsToolStripMenuItem";
            this.aboutAuthorsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutAuthorsToolStripMenuItem.Text = "About authors";
            this.aboutAuthorsToolStripMenuItem.Click += new System.EventHandler(this.aboutAuthorsToolStripMenuItem_Click);
            // 
            // cbSearch
            // 
            this.cbSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(12, 54);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(260, 29);
            this.cbSearch.TabIndex = 2;
            this.cbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbSearch_KeyDown);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(12, 89);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(260, 263);
            this.tabControl.TabIndex = 6;
            this.tabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox);
            this.tabPage1.Controls.Add(this.lStatus);
            this.tabPage1.Controls.Add(this.lLocation);
            this.tabPage1.Controls.Add(this.lTemp);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(252, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Tab";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addTab, this.removeTab });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // addTab
            // 
            this.addTab.Name = "addTab";
            this.addTab.Size = new System.Drawing.Size(138, 22);
            this.addTab.Text = "Add Tab";
            // 
            // removeTab
            // 
            this.removeTab.Name = "removeTab";
            this.removeTab.Size = new System.Drawing.Size(138, 22);
            this.removeTab.Text = "Remove Tab";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 364);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.btnChooseOnMap);
            this.Controls.Add(this.lText);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WeatherMap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAuthorsToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem addTab;
        private System.Windows.Forms.ToolStripMenuItem removeTab;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;

        private System.Windows.Forms.Label lText;
        private System.Windows.Forms.Button btnChooseOnMap;
        private System.Windows.Forms.Label lTemp;
        private System.Windows.Forms.Label lLocation;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsMenu;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lStatus;
    }
    #endregion
}