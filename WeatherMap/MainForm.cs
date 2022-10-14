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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WeatherMap
{
    public partial class MainForm : Form
    {
        private readonly MapForm _mapForm = new MapForm();
        private readonly SettingsForm _settingsForm = new SettingsForm();
        private readonly Exceptions _exceptions = new Exceptions();

        public MainForm()
        {
            // disable window resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle; this.MaximizeBox = false;
            InitializeComponent();
        }

        private void btnChooseOnMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (_mapForm.ShowDialog() != DialogResult.OK)
                return;
        }
        
        // render map window 
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) 
                return;

            // TEST
            
            ApiCalls apiCalls = new ApiCalls();
            
            string data = apiCalls.getJsonResponseString(tbSearch.Text);
            if (_exceptions.validateJsonAnswer(data) == false) 
            {
                MessageBox.Show("Pls, check your input correctness.", "No results found :(", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
                return; 
            }

            // END_TEST
            _mapForm.ShowDialog();
        }
        
        // render settings window
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_settingsForm.ShowDialog() != DialogResult.OK)
                return;
        }
    }
}