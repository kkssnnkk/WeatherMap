using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace WeatherMap
{
    public partial class MainForm : Form
    {
        private readonly MapForm _mapForm = new MapForm();
        private readonly SettingsForm _settingsForm = new SettingsForm();
        private readonly Exceptions _exceptions = new Exceptions();
        private readonly ApiCalls _apiCalls = new ApiCalls();
        NumberFormatInfo NFI = new NumberFormatInfo()
        {
            NumberDecimalSeparator = ".",
        };
        
        public MainForm()
        {
            InitializeComponent();
        }

        public void UpdateInfo(JObject data)
        {
            lCity.Text = data["location"]["timezone_id"].ToString() + "\n" + data["location"]["region"].ToString();

            lCity.Location = new Point(groupBox1.Width / 2 - lCity.Width / 2, lCity.Location.Y);

            lTemp.Text = data["current"]["temperature"].ToString() + " °C";

            pictureBox1.Load(data["current"]["weather_icons"][0].ToString());

            lStatus.Text = data["current"]["weather_descriptions"][0].ToString();
        }

        public void btnChooseOnMap_MouseClick(object sender, MouseEventArgs e)
        {
            _mapForm.ShowDialog();
            
            // client will dispose after api call
            var data = _apiCalls.GetJsonResponseStringByCoords(_mapForm.Coords.Lat, _mapForm.Coords.Lng); 
           
            if (!_exceptions.ValidateJsonAnswer(data))
            {
                MessageBox.Show(@"Unexpected error.", @"No results found :(", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateInfo(JObject.Parse(data));
        }

        // render settings window
        public void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_settingsForm.ShowDialog() != DialogResult.OK)
                return;
        }

        // render map window 
        private void cbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter || !_exceptions.ValidateSearchQuery(cbSearch.Text))
                return;

            var data = _apiCalls.GetJsonResponseString(cbSearch.Text);

            if (!_exceptions.ValidateJsonAnswer(data))
            {
                MessageBox.Show(@"Pls, check your input correctness.", @"No results found :(", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateInfo(JObject.Parse(data));
        }
    }
}