using Newtonsoft.Json.Linq;
using System;
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
        
        public MainForm()
        {
            InitializeComponent();
        }

        public void btnChooseOnMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (_mapForm.ShowDialog() != DialogResult.OK)
                return;
            
            // client will dispose after api call
            var data = _apiCalls.GetJsonResponseStringByCoords(_mapForm.Coords.Lat, _mapForm.Coords.Lng); 
           
            if (!_exceptions.ValidateJsonAnswer(data))
            {
                MessageBox.Show(@"Unexpected error.", @"No results found :(", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // do sth with api response...
        }

        // render map window 
        public void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter || !_exceptions.ValidateSearchQuery(tbSearch.Text)) 
                return;

            JObject joResponse = JObject.Parse(_apiCalls.GetJsonResponseString(tbSearch.Text));

            JObject ojObject = (JObject)joResponse["request"];

            JArray array = (JArray)ojObject["request"];

            int temp = int.Parse(array[0].ToString());

            /*if (!_exceptions.ValidateJsonAnswer()) 
            {
                MessageBox.Show(@"Pls, check your input correctness.", @"No results found :(", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
                return; 
            }*/

            // do sth with api response...
            }

        // render settings window
        public void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_settingsForm.ShowDialog() != DialogResult.OK)
                return;
        }
    }
}