namespace WeatherMap.Forms
{
    public partial class SettingsForm : System.Windows.Forms.Form
    {
        private readonly Exceptions _exceptions = new Exceptions();
        private readonly AutoSave _autoSave = new AutoSave();

        public SettingsForm()
        {
            InitializeComponent();
            setDataFromLastSave();
        }

        public void setDataFromLastSave()
        {
            var data = _autoSave.getAppLastState();

            // settings
            if (data.language == "us") 
            {
                rbEnglish.Checked = true;
                rbUkrainian.Checked = false;
            }
            if (data.language == "ua")
            {
                rbEnglish.Checked = false;
                rbUkrainian.Checked = true;
            }

            if (data.theme == "Dark") 
            {
                rbLight.Checked = false;
                rbDark.Checked = true;
            }
            if (data.theme == "Light")
            {
                rbLight.Checked = true;
                rbDark.Checked = false;
            }

            tbFontSize.Value = data.font_size;
        }

        private void rbLight_CheckedChanged(object sender, System.EventArgs e)
        {
            /*if (rbLight.Checked)
            {
                *//*  Settings Form  *//*
                ActiveForm.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                ActiveForm.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                
                gbLanguage.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                gbLanguage.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                rbEnglish.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                rbEnglish.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                rbUkrainian.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                rbUkrainian.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);

                gbFontSize.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                gbFontSize.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                tbFontSize.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                tbFontSize.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);

                gbTheme.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                gbTheme.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                rbLight.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                rbLight.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                rbDark.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                rbDark.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);

                *//*  Main Form  *//*
                
            }*/
        }

        private void rbDark_CheckedChanged(object sender, System.EventArgs e)
        {
            /*if (rbDark.Checked)
            {
                ActiveForm.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                ActiveForm.BackColor = System.Drawing.Color.FromArgb(255, 36, 36, 36);

                gbLanguage.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                gbLanguage.BackColor = System.Drawing.Color.FromArgb(255, 36, 36, 36);
                rbEnglish.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                rbEnglish.BackColor = System.Drawing.Color.FromArgb(255, 36, 36, 36);
                rbUkrainian.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                rbUkrainian.BackColor = System.Drawing.Color.FromArgb(255, 36, 36, 36);

                gbFontSize.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                gbFontSize.BackColor = System.Drawing.Color.FromArgb(255, 36, 36, 36);
                tbFontSize.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                tbFontSize.BackColor = System.Drawing.Color.FromArgb(255, 36, 36, 36);

                gbTheme.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                gbTheme.BackColor = System.Drawing.Color.FromArgb(255, 36, 36, 36);
                rbLight.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                rbLight.BackColor = System.Drawing.Color.FromArgb(255, 36, 36, 36);
                rbDark.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                rbDark.BackColor = System.Drawing.Color.FromArgb(255, 36, 36, 36);
            }*/
        }
    }
}