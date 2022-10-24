using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace WeatherMap
{
    public partial class SettingsForm : Form
    {
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