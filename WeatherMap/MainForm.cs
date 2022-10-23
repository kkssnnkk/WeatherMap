using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WeatherMap
{
    public partial class MainForm : Form
    {
        private readonly MapForm _mapForm = new MapForm();
        private readonly SettingsForm _settingsForm = new SettingsForm();
        private readonly Exceptions _exceptions = new Exceptions();
        private readonly ApiCalls _apiCalls = new ApiCalls();
        
        public MainForm()
        {
            InitializeComponent();
            _exceptions.runProcessLurking(); // ensures that the process will be closed (will avoid BG stucking)
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
            if (!_exceptions.ValidateCoords(_mapForm.Coords.Lat, _mapForm.Coords.Lng)) return;
            // client will dispose after api call
            UpdateInfo(JObject.Parse(_apiCalls.GetJsonResponseStringByCoords(_mapForm.Coords.Lat, _mapForm.Coords.Lng)));
        }
        
        private void cbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // only the enter key is pressed and validate request
            if (e.KeyData != Keys.Enter || !_exceptions.ValidateSearchQuery(cbSearch.Text))
                return;

            // client will dispose after api call
            UpdateInfo(JObject.Parse(_apiCalls.GetJsonResponseString(cbSearch.Text)));
        }
        
        // render settings window
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settingsForm.ShowDialog();
        }
    }
}