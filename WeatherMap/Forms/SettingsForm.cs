using System.Windows.Forms;

namespace WeatherMap.Forms
{
    public partial class SettingsForm : Form
    {
        private static readonly MainForm MainForm = new MainForm();
        private readonly Exceptions _exceptions = new Exceptions();
        private readonly AutoSave _autoSave = new AutoSave();

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
            var data = _autoSave.getAppLastState();

            // settings
            cbLocalization.Text = data.language;
            tbFontSize.Value = data.font_size;
            cbTheme.Text = data.theme;
        }
    }
}