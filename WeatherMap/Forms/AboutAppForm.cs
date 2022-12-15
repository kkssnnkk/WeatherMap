using System.Diagnostics;
using System.Windows.Forms;

namespace WeatherMap.Forms
{
    public partial class AboutAppForm : Form
    {
        public AboutAppForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://openweathermap.org/");
        }
    }
}