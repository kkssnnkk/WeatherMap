using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.ObjectModel;

namespace WeatherMap
{
    public partial class MainForm : Form
    {
        private readonly MapForm _mapForm = new MapForm();
        private readonly SettingsForm _settingsForm = new SettingsForm();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            _mapForm.ShowDialog();
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            _settingsForm.ShowDialog();
        }
    }
}