using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using WeatherMap.OpenWeatherMapClasses;


namespace WeatherMap.Forms
{
    public partial class MainForm : Form
    {
        private static readonly MapForm MapForm = new MapForm();
        private static readonly SettingsForm SettingsForm = new SettingsForm();
        private static readonly AboutAuthorsForm AboutAuthorsForm = new AboutAuthorsForm();
        private static readonly AboutAppForm AboutAppForm = new AboutAppForm();

        private readonly OpenWeatherMapApi _openWeatherMapApi = new OpenWeatherMapApi("b71815a25d967af19c11e1da4ebad8b8");

        private readonly Exceptions _exceptions = new Exceptions();
        private readonly Algorithms _algorithms = new Algorithms();
        private readonly AutoSave _autoSave = new AutoSave();

        private static float _lLocationFontSize;
        private static float _lTempFontSize;
        private static float _lStatusFontSize;

        public MainForm()
        {
            InitializeComponent();
            setAppStateFromLastSave();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            _lLocationFontSize = lLocation.Font.Size;
            _lTempFontSize = lTemp.Font.Size;
            _lStatusFontSize = lStatus.Font.Size;
        }

        // read app last state
        public void setAppStateFromLastSave() 
        {
            var data = _autoSave.getAppLastState();

            // this
            cbSearch.Text = data.seacrh_field;
            lTemp.Text = data.temperature;
            lLocation.Text = data.location;
            lStatus.Text = data.status;
        }

        // save app state
        public void saveData() 
        {
            var data = _autoSave.getSaveDataStructure();

            // this
            data.status = lStatus.Text;
            data.temperature = lTemp.Text;
            data.location = lLocation.Text;
            data.seacrh_field = cbSearch.Text;

            // settings 
            if (SettingsForm.rbUkrainian.Checked) 
            {
                data.language = "ua";
            }
            if (SettingsForm.rbEnglish.Checked)
            {
                data.language = "us";
            }

            data.font_size = SettingsForm.tbFontSize.Value;

            if (SettingsForm.rbLight.Checked)
            {
                data.theme = "Light";
            }
            if (SettingsForm.rbDark.Checked)
            {
                data.theme = "Dark";
            }

            _autoSave.saveAppState(data);
        }

        private static Font ChangeFontSize(Control label, float newFontSize)
        {
            return new Font(label.Font.Name, newFontSize, label.Font.Style, label.Font.Unit, label.Font.GdiCharSet);
        }

        public void ApplySettings()
        {
            /*switch (SettingsForm.cbLocalization.Text)
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
            }*/

            if (SettingsForm.rbLight.Checked)
            {
                /*  Main Form  */
                ActiveForm.ForeColor =
                lText.ForeColor =
                btnChooseOnMap.ForeColor =
                cbSearch.ForeColor =
                lLocation.ForeColor =
                lTemp.ForeColor =
                lStatus.ForeColor =
                settingsMenu.ForeColor =
                helpMenu.ForeColor =
                aboutAppMenu.ForeColor =
                aboutAuthorsMenu.ForeColor =
                Color.FromArgb(255, 0, 0, 0);

                ActiveForm.BackColor =
                lText.BackColor =
                lLocation.BackColor =
                lTemp.BackColor =
                lStatus.BackColor =
                settingsMenu.BackColor =
                menuStrip.BackColor =
                menuStrip.BackColor =
                helpMenu.BackColor =
                aboutAppMenu.BackColor =
                aboutAuthorsMenu.BackColor =
                Color.FromArgb(255, 240, 240, 240);
                
                btnChooseOnMap.BackColor = cbSearch.BackColor = Color.FromArgb(255, 255, 255, 255);

                /*  Settings Form  */
                SettingsForm.ForeColor = 
                SettingsForm.gbLanguage.ForeColor = 
                SettingsForm.rbEnglish.ForeColor = 
                SettingsForm.rbUkrainian.ForeColor =
                SettingsForm.gbFontSize.ForeColor =
                SettingsForm.tbFontSize.ForeColor =
                SettingsForm.gbTheme.ForeColor =
                SettingsForm.rbLight.ForeColor =
                SettingsForm.rbDark.ForeColor =
                Color.FromArgb(255, 0, 0, 0);

                SettingsForm.BackColor = 
                SettingsForm.gbLanguage.BackColor = 
                SettingsForm.rbEnglish.BackColor = 
                SettingsForm.rbUkrainian.BackColor = 
                SettingsForm.gbFontSize.BackColor = 
                SettingsForm.tbFontSize.BackColor = 
                SettingsForm.gbTheme.BackColor = 
                SettingsForm.rbLight.BackColor = 
                SettingsForm.rbDark.BackColor = 
                Color.FromArgb(255, 240, 240, 240);
            }
            else if (SettingsForm.rbDark.Checked)
            {
                /*  Main Form  */
                ActiveForm.ForeColor =
                lText.ForeColor =
                btnChooseOnMap.ForeColor =
                cbSearch.ForeColor =
                lLocation.ForeColor =
                lTemp.ForeColor =
                lStatus.ForeColor =
                settingsMenu.ForeColor = 
                helpMenu.ForeColor =
                aboutAppMenu.ForeColor =
                aboutAuthorsMenu.ForeColor =
                Color.FromArgb(255, 255, 255, 255);

                ActiveForm.BackColor =
                lText.BackColor =
                btnChooseOnMap.BackColor =
                cbSearch.BackColor =
                lLocation.BackColor =
                lTemp.BackColor =
                lStatus.BackColor =
                settingsMenu.BackColor =
                helpMenu.BackColor =
                menuStrip.BackColor =
                aboutAppMenu.BackColor =
                aboutAuthorsMenu.BackColor =
                Color.FromArgb(255, 36, 36, 36);

                /*  Settings Form  */
                SettingsForm.ForeColor =
                SettingsForm.gbLanguage.ForeColor =
                SettingsForm.rbEnglish.ForeColor =
                SettingsForm.rbUkrainian.ForeColor =
                SettingsForm.gbFontSize.ForeColor =
                SettingsForm.tbFontSize.ForeColor =
                SettingsForm.gbTheme.ForeColor =
                SettingsForm.rbLight.ForeColor =
                SettingsForm.rbDark.ForeColor =
                Color.FromArgb(255, 255, 255, 255);

                SettingsForm.BackColor =
                SettingsForm.gbLanguage.BackColor =
                SettingsForm.rbEnglish.BackColor =
                SettingsForm.rbUkrainian.BackColor =
                SettingsForm.gbFontSize.BackColor =
                SettingsForm.tbFontSize.BackColor =
                SettingsForm.gbTheme.BackColor =
                SettingsForm.rbLight.BackColor =
                SettingsForm.rbDark.BackColor =
                Color.FromArgb(255, 36, 36, 36);
            }
        }

        private void CenterElement(Label label)
        {
            label.Location = new Point(ClientSize.Width / 2 - label.Width / 2, label.Location.Y);
        }
        
        private void UpdateInfoFromOWM(QueryResponse queryResponse)
        {
            try
            {
                _exceptions.ValidateJsonAnswer(queryResponse);
            }
            catch (BadResponseException exc)
            {
                showErrorMsg(exc.Message, @"Request Error");
                return;
            }

            lLocation.Text = queryResponse.Name;
            CenterElement(lLocation);
            
            if (queryResponse.Sys.Country == "RU")
            {
                lTemp.Text = "-100°C";
                lStatus.Text = "Heavy shower snow";
            }
            else
            {
                lTemp.Text = Math.Round(queryResponse.Main.Temperature.CelsiusCurrent).ToString(CultureInfo.InvariantCulture) + "°C";
                lStatus.Text = queryResponse.WeatherList[0].Main;
            }

            CenterElement(lTemp);
            CenterElement(lStatus);            
        }

        // render map window 
        private void btnChooseOnMap_MouseClick(object sender, MouseEventArgs e)
        {
            try 
            {
                // openFormSafely returns DialogResult if needed
                _exceptions.openFormSafely(MapForm);
            } 
            catch (FormNotOpenedException exc) 
            {
                showErrorMsg(exc.Message, "Error");
            }

            try
            {
                _exceptions.ValidateCoords(MapForm.Coords.Lat, MapForm.Coords.Lng);
            }
            catch (CoordsException) 
            {
                return;
            }
            
            UpdateInfoFromOWM(new QueryResponse(_openWeatherMapApi.GetJsonResponseStringByCoords(MapForm.Coords.Lat, MapForm.Coords.Lng)));    
        }
        
        private void cbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // only the enter key is pressed and validate request
            if (e.KeyData != Keys.Enter)
                return;

            try
            {
                _exceptions.ValidateSearchQuery(cbSearch.Text);
            }
            catch (NaTException)
            {
                return;
            }

            UpdateInfoFromOWM(new QueryResponse(_openWeatherMapApi.GetJsonResponseStringByName(cbSearch.Text)));
        }
        
        // render settings window
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // openFormSafely returns DialogResult if needed
                _exceptions.openFormSafely(SettingsForm);
            }
            catch (FormNotOpenedException exc)
            {
                showErrorMsg(exc.Message, "Error");
            }

            ApplySettings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveData();
            try
            {
                _exceptions.ValidateExit(e);
            }
            catch (AppOnCloseExcption exc)
            {
                showErrorMsg(exc.Message, @"Warning");
                return;
            }
        }

        private void aboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // openFormSafely returns DialogResult if needed
                _exceptions.openFormSafely(AboutAppForm);
            }
            catch (FormNotOpenedException exc)
            {
                showErrorMsg(exc.Message, "Error");
            }
        }

        private void aboutAuthorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // openFormSafely returns DialogResult if needed
                _exceptions.openFormSafely(AboutAuthorsForm);
            }
            catch (FormNotOpenedException exc)
            {
                showErrorMsg(exc.Message, "Error");
            }
        }

        private void showErrorMsg(string text1, string text2) 
        {
            MessageBox.Show(text1, text2, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbSearch_DropDown(object sender, EventArgs e)
        {
            if (cbSearch.Text.Length == 0)
            {
                cbSearch.Items.Clear();
                return;
            }
            
            cbSearch.Items.Clear();
            
            List<string> Cities = _algorithms.FindMatches(cbSearch.Text);

            foreach (var i in Cities)
            {
                cbSearch.Items.Add(i);
            }
        }
    }
}