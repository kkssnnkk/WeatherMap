using System.Windows.Forms;

namespace WeatherMap
{
    public partial class SettingsForm : Form
    {
        private readonly MainForm _mainForm = new MainForm();
        
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainForm.ApplySettings();
        }
    }
}