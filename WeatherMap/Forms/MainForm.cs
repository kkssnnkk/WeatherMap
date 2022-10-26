using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using WeatherMap.OpenWeatherMapClasses;
using WeatherMap.WeatherStackClasses;

namespace WeatherMap.Forms
{
    public partial class MainForm : Form
    {
        private static readonly MapForm MapForm = new MapForm();
        private static readonly SettingsForm SettingsForm = new SettingsForm();
        
        private readonly WeatherStackApi _weatherStackApi = new WeatherStackApi("");
        private readonly OpenWeatherMapApi _openWeatherMapApi = new OpenWeatherMapApi("");
        private readonly Exceptions _exceptions = new Exceptions();

        private static float _lLocationFontSize;
        private static float _lTempFontSize;
        private static float _lStatusFontSize;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            _lLocationFontSize = lLocation.Font.Size; 
            _lTempFontSize = lTemp.Font.Size; 
            _lStatusFontSize = lStatus.Font.Size;
        }

        private static Font ChangeFontSize(Control label, float newFontSize)
        {
            return new Font(label.Font.Name, newFontSize, label.Font.Style, label.Font.Unit, label.Font.GdiCharSet);
        }

        public void ApplySettings()
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
                    lLocation.Font = ChangeFontSize(lLocation, _lLocationFontSize + 1.0F);
                    lTemp.Font = ChangeFontSize(lTemp, _lTempFontSize + 1.0F);
                    lStatus.Font = ChangeFontSize(lStatus, _lStatusFontSize + 1.0F);
                    break;
                case 2:
                    lLocation.Font = ChangeFontSize(lLocation, _lLocationFontSize + 2.0F);
                    lTemp.Font = ChangeFontSize(lTemp, _lTempFontSize + 2.0F);
                    lStatus.Font = ChangeFontSize(lStatus, _lStatusFontSize + 2.0F);
                    break;
                case 3:
                    lLocation.Font = ChangeFontSize(lLocation, _lLocationFontSize + 3.0F);
                    lTemp.Font = ChangeFontSize(lTemp, _lTempFontSize + 3.0F);
                    lStatus.Font = ChangeFontSize(lStatus, _lStatusFontSize + 3.0F);
                    break;
                case 4:
                    lLocation.Font = ChangeFontSize(lLocation, _lLocationFontSize + 4.0F);
                    lTemp.Font = ChangeFontSize(lTemp, _lTempFontSize + 4.0F);
                    lStatus.Font = ChangeFontSize(lStatus, _lStatusFontSize + 4.0F);
                    break;
                case 5:
                    lLocation.Font = ChangeFontSize(lLocation, _lLocationFontSize + 5.0F);
                    lTemp.Font = ChangeFontSize(lTemp, _lTempFontSize + 5.0F);
                    lStatus.Font = ChangeFontSize(lStatus, _lStatusFontSize + 5.0F);
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
            label.Location = new Point(tabPage1.Width / 2 - label.Width / 2, label.Location.Y);
        }
        
        private void UpdateInfoFromOWM(QueryResponse queryResponse)
        {
            lLocation.Text = queryResponse.Name;
            CenterElement(lLocation);
            
            lTemp.Text = queryResponse.Main.Temperature.CelsiusCurrent.ToString(CultureInfo.InvariantCulture);
            CenterElement(lTemp);

            lStatus.Text = queryResponse.WeatherList[0].Main;
            CenterElement(lStatus);
        }
        
        private void UpdateInfoFromWS(QueryResponse queryResponse)
        {
            lLocation.Text = queryResponse.Name;
            CenterElement(lLocation);
            
            lTemp.Text = queryResponse.Main.Temperature.CelsiusCurrent.ToString(CultureInfo.InvariantCulture);
            CenterElement(lTemp);

            lStatus.Text = queryResponse.WeatherList[0].Main;
            CenterElement(lStatus);
        }

        // render map window 
        private void btnChooseOnMap_MouseClick(object sender, MouseEventArgs e)
        {
            MapForm.ShowDialog();

            if (!_exceptions.ValidateCoords(MapForm.Coords.Lat, MapForm.Coords.Lng)) 
                return;
            
            // client will dispose after api call
            switch (SettingsForm.cbApi.Text)
            {
                case "OpenWeatherMap":
                    UpdateInfoFromOWM(new QueryResponse(_openWeatherMapApi.GetJsonResponseStringByCoords(MapForm.Coords.Lat, MapForm.Coords.Lng)));
                    break;
                case "WeatherStack":
                    UpdateInfoFromWS(new QueryResponse(_weatherStackApi.GetJsonResponseStringByCoords(MapForm.Coords.Lat, MapForm.Coords.Lng)));
                    break;
            }
        }
        
        private void cbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // only the enter key is pressed and validate request
            if (e.KeyData != Keys.Enter || !_exceptions.ValidateSearchQuery(cbSearch.Text))
                return;

            cbSearch.Items.Add(cbSearch.Text);

            if (cbSearch.Items.Count > 5)
                cbSearch.Items.RemoveAt(0);

            // client will dispose after api call
            switch (SettingsForm.cbApi.Text)
            {
                case "OpenWeatherMap":
                    UpdateInfoFromOWM(new QueryResponse(_openWeatherMapApi.GetJsonResponseStringByName(cbSearch.Text)));
                    break;
                case "WeatherStack":
                    UpdateInfoFromWS(new QueryResponse(_weatherStackApi.GetJsonResponseStringByName(cbSearch.Text)));
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

        private void lLocation_TextChanged(object sender, EventArgs e)
        {
            tabControl.SelectedTab.Text = lLocation.Text;
        }

        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            contextMenuStrip1.Show((Control)sender, e.Location, ToolStripDropDownDirection.Default);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "addTab":
                    tabControl.TabPages.Add("New Tab");
                    break;
                case "removeTab":
                    if (tabControl.TabCount == 1)
                    {
                        MessageBox.Show(@"You cannot delete a single tab", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    tabControl.TabPages.Remove(tabControl.SelectedTab);
                    break;
            }
        }
    }
}