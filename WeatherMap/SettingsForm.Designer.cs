namespace WeatherMap
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lLocalization = new System.Windows.Forms.Label();
            this.lSize = new System.Windows.Forms.Label();
            this.lTheme = new System.Windows.Forms.Label();
            this.cbLocalization = new System.Windows.Forms.ComboBox();
            this.cbTheme = new System.Windows.Forms.ComboBox();
            this.cbApi = new System.Windows.Forms.ComboBox();
            this.lApi = new System.Windows.Forms.Label();
            this.tbFontSize = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lLocalization
            // 
            this.lLocalization.AutoSize = true;
            this.lLocalization.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLocalization.Location = new System.Drawing.Point(18, 18);
            this.lLocalization.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lLocalization.Name = "lLocalization";
            this.lLocalization.Size = new System.Drawing.Size(139, 32);
            this.lLocalization.TabIndex = 0;
            this.lLocalization.Text = "Localization";
            // 
            // lSize
            // 
            this.lSize.AutoSize = true;
            this.lSize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSize.Location = new System.Drawing.Point(18, 114);
            this.lSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lSize.Name = "lSize";
            this.lSize.Size = new System.Drawing.Size(109, 32);
            this.lSize.TabIndex = 1;
            this.lSize.Text = "Font size";
            // 
            // lTheme
            // 
            this.lTheme.AutoSize = true;
            this.lTheme.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTheme.Location = new System.Drawing.Point(18, 209);
            this.lTheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lTheme.Name = "lTheme";
            this.lTheme.Size = new System.Drawing.Size(88, 32);
            this.lTheme.TabIndex = 2;
            this.lTheme.Text = "Theme";
            // 
            // cbLocalization
            // 
            this.cbLocalization.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLocalization.FormattingEnabled = true;
            this.cbLocalization.Items.AddRange(new object[] {
            "Ukrainian",
            "English"});
            this.cbLocalization.Location = new System.Drawing.Point(18, 60);
            this.cbLocalization.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLocalization.Name = "cbLocalization";
            this.cbLocalization.Size = new System.Drawing.Size(319, 40);
            this.cbLocalization.TabIndex = 3;
            this.cbLocalization.Text = "English";
            // 
            // cbTheme
            // 
            this.cbTheme.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbTheme.FormattingEnabled = true;
            this.cbTheme.Items.AddRange(new object[] {
            "Dark",
            "Light"});
            this.cbTheme.Location = new System.Drawing.Point(18, 251);
            this.cbTheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTheme.Name = "cbTheme";
            this.cbTheme.Size = new System.Drawing.Size(319, 40);
            this.cbTheme.TabIndex = 5;
            this.cbTheme.Text = "Light";
            // 
            // cbApi
            // 
            this.cbApi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbApi.FormattingEnabled = true;
            this.cbApi.Items.AddRange(new object[] {
            "OpenWeatherMap"});
            this.cbApi.Location = new System.Drawing.Point(18, 357);
            this.cbApi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbApi.Name = "cbApi";
            this.cbApi.Size = new System.Drawing.Size(319, 40);
            this.cbApi.TabIndex = 8;
            this.cbApi.Text = "OpenWeatherMap";
            // 
            // lApi
            // 
            this.lApi.AutoSize = true;
            this.lApi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lApi.Location = new System.Drawing.Point(18, 315);
            this.lApi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lApi.Name = "lApi";
            this.lApi.Size = new System.Drawing.Size(49, 32);
            this.lApi.TabIndex = 9;
            this.lApi.Text = "Api";
            // 
            // tbFontSize
            // 
            this.tbFontSize.Location = new System.Drawing.Point(18, 155);
            this.tbFontSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFontSize.Maximum = 5;
            this.tbFontSize.Name = "tbFontSize";
            this.tbFontSize.Size = new System.Drawing.Size(321, 69);
            this.tbFontSize.TabIndex = 10;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(357, 435);
            this.Controls.Add(this.tbFontSize);
            this.Controls.Add(this.lApi);
            this.Controls.Add(this.cbApi);
            this.Controls.Add(this.cbTheme);
            this.Controls.Add(this.cbLocalization);
            this.Controls.Add(this.lTheme);
            this.Controls.Add(this.lSize);
            this.Controls.Add(this.lLocalization);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Label lApi;
        private System.Windows.Forms.Label lLocalization;
        private System.Windows.Forms.Label lSize;
        private System.Windows.Forms.Label lTheme;
        public System.Windows.Forms.ComboBox cbLocalization;
        public System.Windows.Forms.ComboBox cbTheme;
        public System.Windows.Forms.TrackBar tbFontSize;
        public System.Windows.Forms.ComboBox cbApi;
    }
}