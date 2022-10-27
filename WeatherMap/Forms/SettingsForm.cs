using System.Windows.Forms;

namespace WeatherMap.Forms
{
    public partial class SettingsForm : Form
    {
        private static readonly MainForm MainForm = new MainForm();
        private readonly Exceptions _exceptions = new Exceptions();

        public SettingsForm()
        {
            InitializeComponent();
            setDataFromLastSave();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.ApplySettings();
        }

        public void setDataFromLastSave()
        {
            var data = _exceptions.getAppLastState();

            // settings
            cbApi.Text = data.api;
            cbLocalization.Text = data.language;
            tbFontSize.Value = data.font_size;
            cbTheme.Text = data.theme;
        }
    }
}