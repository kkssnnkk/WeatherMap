namespace WeatherMap.Forms
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
            this.tbFontSize = new System.Windows.Forms.TrackBar();
            this.rbLight = new System.Windows.Forms.RadioButton();
            this.rbDark = new System.Windows.Forms.RadioButton();
            this.gbTheme = new System.Windows.Forms.GroupBox();
            this.gbLanguage = new System.Windows.Forms.GroupBox();
            this.rbEnglish = new System.Windows.Forms.RadioButton();
            this.rbUkrainian = new System.Windows.Forms.RadioButton();
            this.gbFontSize = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).BeginInit();
            this.gbTheme.SuspendLayout();
            this.gbLanguage.SuspendLayout();
            this.gbFontSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbFontSize
            // 
            this.tbFontSize.Location = new System.Drawing.Point(6, 23);
            this.tbFontSize.Maximum = 5;
            this.tbFontSize.Minimum = 1;
            this.tbFontSize.Name = "tbFontSize";
            this.tbFontSize.Size = new System.Drawing.Size(214, 45);
            this.tbFontSize.TabIndex = 10;
            this.tbFontSize.Value = 3;
            // 
            // rbLight
            // 
            this.rbLight.AutoSize = true;
            this.rbLight.Checked = true;
            this.rbLight.Location = new System.Drawing.Point(6, 28);
            this.rbLight.Name = "rbLight";
            this.rbLight.Size = new System.Drawing.Size(63, 25);
            this.rbLight.TabIndex = 11;
            this.rbLight.TabStop = true;
            this.rbLight.Text = "Light";
            this.rbLight.UseVisualStyleBackColor = true;
            // 
            // rbDark
            // 
            this.rbDark.AutoSize = true;
            this.rbDark.Location = new System.Drawing.Point(90, 28);
            this.rbDark.Name = "rbDark";
            this.rbDark.Size = new System.Drawing.Size(61, 25);
            this.rbDark.TabIndex = 12;
            this.rbDark.TabStop = true;
            this.rbDark.Text = "Dark";
            this.rbDark.UseVisualStyleBackColor = true;
            // 
            // gbTheme
            // 
            this.gbTheme.BackColor = System.Drawing.Color.White;
            this.gbTheme.Controls.Add(this.rbLight);
            this.gbTheme.Controls.Add(this.rbDark);
            this.gbTheme.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTheme.Location = new System.Drawing.Point(12, 172);
            this.gbTheme.Name = "gbTheme";
            this.gbTheme.Size = new System.Drawing.Size(226, 74);
            this.gbTheme.TabIndex = 13;
            this.gbTheme.TabStop = false;
            this.gbTheme.Text = "Theme";
            // 
            // gbLanguage
            // 
            this.gbLanguage.Controls.Add(this.rbEnglish);
            this.gbLanguage.Controls.Add(this.rbUkrainian);
            this.gbLanguage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLanguage.Location = new System.Drawing.Point(12, 12);
            this.gbLanguage.Name = "gbLanguage";
            this.gbLanguage.Size = new System.Drawing.Size(226, 74);
            this.gbLanguage.TabIndex = 14;
            this.gbLanguage.TabStop = false;
            this.gbLanguage.Text = "Language";
            // 
            // rbEnglish
            // 
            this.rbEnglish.AutoSize = true;
            this.rbEnglish.Checked = true;
            this.rbEnglish.Location = new System.Drawing.Point(6, 28);
            this.rbEnglish.Name = "rbEnglish";
            this.rbEnglish.Size = new System.Drawing.Size(78, 25);
            this.rbEnglish.TabIndex = 11;
            this.rbEnglish.TabStop = true;
            this.rbEnglish.Text = "English";
            this.rbEnglish.UseVisualStyleBackColor = true;
            // 
            // rbUkrainian
            // 
            this.rbUkrainian.AutoSize = true;
            this.rbUkrainian.Location = new System.Drawing.Point(90, 28);
            this.rbUkrainian.Name = "rbUkrainian";
            this.rbUkrainian.Size = new System.Drawing.Size(95, 25);
            this.rbUkrainian.TabIndex = 12;
            this.rbUkrainian.TabStop = true;
            this.rbUkrainian.Text = "Ukrainian";
            this.rbUkrainian.UseVisualStyleBackColor = true;
            // 
            // gbFontSize
            // 
            this.gbFontSize.Controls.Add(this.tbFontSize);
            this.gbFontSize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFontSize.Location = new System.Drawing.Point(12, 92);
            this.gbFontSize.Name = "gbFontSize";
            this.gbFontSize.Size = new System.Drawing.Size(226, 74);
            this.gbFontSize.TabIndex = 15;
            this.gbFontSize.TabStop = false;
            this.gbFontSize.Text = "Font size";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(250, 257);
            this.Controls.Add(this.gbFontSize);
            this.Controls.Add(this.gbLanguage);
            this.Controls.Add(this.gbTheme);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).EndInit();
            this.gbTheme.ResumeLayout(false);
            this.gbTheme.PerformLayout();
            this.gbLanguage.ResumeLayout(false);
            this.gbLanguage.PerformLayout();
            this.gbFontSize.ResumeLayout(false);
            this.gbFontSize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TrackBar tbFontSize;
        public System.Windows.Forms.RadioButton rbLight;
        public System.Windows.Forms.RadioButton rbDark;
        public System.Windows.Forms.GroupBox gbTheme;
        public System.Windows.Forms.GroupBox gbLanguage;
        public System.Windows.Forms.RadioButton rbEnglish;
        public System.Windows.Forms.RadioButton rbUkrainian;
        public System.Windows.Forms.GroupBox gbFontSize;
    }
}