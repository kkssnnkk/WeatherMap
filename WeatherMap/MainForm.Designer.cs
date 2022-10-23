namespace WeatherMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lText = new System.Windows.Forms.Label();
            this.btnChooseOnMap = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lLocation = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.lTemp = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lText
            // 
            this.lText.AutoSize = true;
            this.lText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lText.Location = new System.Drawing.Point(11, 27);
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
            this.btnChooseOnMap.Location = new System.Drawing.Point(136, 22);
            this.btnChooseOnMap.Name = "btnChooseOnMap";
            this.btnChooseOnMap.Size = new System.Drawing.Size(135, 31);
            this.btnChooseOnMap.TabIndex = 2;
            this.btnChooseOnMap.Text = "Choose on map";
            this.btnChooseOnMap.UseVisualStyleBackColor = true;
            this.btnChooseOnMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnChooseOnMap_MouseClick);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lLocation);
            this.groupBox.Controls.Add(this.lStatus);
            this.groupBox.Controls.Add(this.lTemp);
            this.groupBox.Controls.Add(this.pictureBox);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox.Location = new System.Drawing.Point(0, 89);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(283, 302);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            // 
            // lLocation
            // 
            this.lLocation.AutoSize = true;
            this.lLocation.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLocation.Location = new System.Drawing.Point(87, 19);
            this.lLocation.Margin = new System.Windows.Forms.Padding(3);
            this.lLocation.Name = "lLocation";
            this.lLocation.Size = new System.Drawing.Size(90, 25);
            this.lLocation.TabIndex = 0;
            this.lLocation.Text = "lLocation";
            this.lLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStatus.Location = new System.Drawing.Point(98, 127);
            this.lStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(59, 21);
            this.lStatus.TabIndex = 3;
            this.lStatus.Text = "aboba";
            // 
            // lTemp
            // 
            this.lTemp.AutoSize = true;
            this.lTemp.Font = new System.Drawing.Font("Segoe UI", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTemp.Location = new System.Drawing.Point(46, 50);
            this.lTemp.Margin = new System.Windows.Forms.Padding(3);
            this.lTemp.Name = "lTemp";
            this.lTemp.Size = new System.Drawing.Size(171, 71);
            this.lTemp.TabIndex = 1;
            this.lTemp.Text = "lTemp";
            this.lTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lCity
            // 
            this.pictureBox.Location = new System.Drawing.Point(93, 157);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(64, 64);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.settingsMenu });
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
            // cbSearch
            // 
            this.cbSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(11, 54);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(260, 29);
            this.cbSearch.TabIndex = 2;
            this.cbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbSearch_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 391);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.groupBox);
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
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lText;
        private System.Windows.Forms.Button btnChooseOnMap;
        private System.Windows.Forms.GroupBox groupBox;
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