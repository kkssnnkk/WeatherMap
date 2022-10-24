using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WeatherMap
{
    public partial class MainForm : Form
    {
        private readonly MapForm _mapForm = new MapForm();
        private static readonly SettingsForm SettingsForm = new SettingsForm();
        private readonly Exceptions _exceptions = new Exceptions();
        private readonly WeatherStackApi _weatherStackApi = new WeatherStackApi("f89ee63dd27c064a028c39511344acdb");
        private readonly OpenWeatherMapApi _openWeatherMapApi = new OpenWeatherMapApi("b71815a25d967af19c11e1da4ebad8b8");
        
        public MainForm()
        {
            InitializeComponent();
        }

        public static void ApplySettings()
        {
            switch (SettingsForm.cbLocalization.Text)
            {
                case "English":
                    break;
                case "Ukrainian":
                    break;
            }

            switch (SettingsForm.tbFontSize.Value)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }

            switch (SettingsForm.cbBold.Checked)
            {
                case true:
                    break;
                case false:
                    break;
            }

            switch (SettingsForm.cbTheme.Text)
            {
                case "Light":
                    break;
                case "Dark":
                    break;
            }
        }

        private void CenterElement(Label label)
        {
            label.Location = new Point(groupBox.Width / 2 - label.Width / 2, label.Location.Y);
        }
        
        private void UpdateInfo(JObject data)
        {
            if (!_exceptions.ValidateJsonAnswer(data))
                return;

            pictureBox.Load(data["current"]["weather_icons"]?[0]?.ToString());
            
            lLocation.Text = $@"{data["location"]["name"]} | {data["location"]["country"]}";
            CenterElement(lLocation);

            lTemp.Text = $@"{data["current"]["temperature"]}°";
            CenterElement(lTemp);

            lStatus.Text = data["current"]["weather_descriptions"]?[0]?.ToString();
            CenterElement(lStatus);
        }

        // render map window 
        private void btnChooseOnMap_MouseClick(object sender, MouseEventArgs e)
        {
            _mapForm.ShowDialog();

            if (!_exceptions.ValidateCoords(_mapForm.Coords.Lat, _mapForm.Coords.Lng)) 
                return;
            
            if (!_exceptions.ValidateCoords(_mapForm.Coords.Lat, _mapForm.Coords.Lng)) 
                return;
            
            // client will dispose after api call
            switch (SettingsForm.cbApi.Text)
            {
                case "WeatherStack":
                    UpdateInfo(JObject.Parse(_weatherStackApi.GetJsonResponseStringByCoords(_mapForm.Coords.Lat, _mapForm.Coords.Lng)));
                    break;
                case "OpenWeatherMap":
                    UpdateInfo(JObject.Parse(_openWeatherMapApi.GetJsonResponseStringByCoords(_mapForm.Coords.Lat, _mapForm.Coords.Lng)));
                    break;
            }
        }
        
        private void cbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // only the enter key is pressed and validate request
            if (e.KeyData != Keys.Enter || !_exceptions.ValidateSearchQuery(cbSearch.Text))
                return;

            // client will dispose after api call
            switch (SettingsForm.cbApi.Text)
            {
                case "WeatherStack":
                    UpdateInfo(JObject.Parse(_weatherStackApi.GetJsonResponseStringByName(cbSearch.Text)));
                    break;
                case "OpenWeatherMap":
                    UpdateInfo(JObject.Parse(_openWeatherMapApi.GetJsonResponseStringByName(cbSearch.Text)));
                    break;
            }
        }
        
        // render settings window
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _exceptions.ValidateExit(e);
        }
    }
}