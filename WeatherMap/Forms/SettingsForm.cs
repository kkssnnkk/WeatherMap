using System.Windows.Forms;

namespace WeatherMap.Forms
{
    public partial class SettingsForm : Form
    {
        private static readonly MainForm MainForm = new MainForm();
        
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.ApplySettings();
        }
    }
}