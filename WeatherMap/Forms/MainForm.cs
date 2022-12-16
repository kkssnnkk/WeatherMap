using System;
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

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetAppStateFromLastSave();
            ApplySettings();
            UpdateInfoFromApi(new QueryResponse(_openWeatherMapApi.GetJsonResponseStringByName(cbSearch.Text)));
        }

        // read app last state
        public void SetAppStateFromLastSave() 
        {
            var data = _autoSave.GetAppLastState();
            
            cbSearch.Text = data.SearchField;

            SettingsForm.rbEnglish.Checked   = data.English;
            SettingsForm.rbUkrainian.Checked = data.Ukrainian;
            SettingsForm.rbLight.Checked     = data.Light;
            SettingsForm.rbDark.Checked      = data.Dark;
            SettingsForm.tbFontSize.Value    = data.FontSize;
        }

        // save app state
        public void SaveData() 
        {
            var data = _autoSave.GetSaveDataStructure();
            
            data.SearchField = cbSearch.Text;

            data.English   = SettingsForm.rbEnglish.Checked;
            data.Ukrainian = SettingsForm.rbUkrainian.Checked;
            data.Light     = SettingsForm.rbLight.Checked;
            data.Dark      = SettingsForm.rbDark.Checked;
            data.FontSize  = SettingsForm.tbFontSize.Value;

            _autoSave.SaveAppState(data);
        }

        public void ApplySettings()
        {
            if (SettingsForm.rbEnglish.Checked)
            {

            }
            else if (SettingsForm.rbUkrainian.Checked)
            {

            }

            switch (SettingsForm.tbFontSize.Value)
            {
                case 1:
                    lLocation.Font = new Font(lLocation.Font.Name, 10F);
                    lTemp.Font     = new Font(lTemp.Font.Name, 36F);
                    lStatus.Font   = new Font(lStatus.Font.Name, 8F);
                    break;
                case 2:
                    lLocation.Font = new Font(lLocation.Font.Name, 12F);
                    lTemp.Font     = new Font(lTemp.Font.Name, 38F);
                    lStatus.Font   = new Font(lStatus.Font.Name, 10F);
                    break;
                case 3:
                    lLocation.Font = new Font(lLocation.Font.Name, 14F);
                    lTemp.Font     = new Font(lTemp.Font.Name, 40F);
                    lStatus.Font   = new Font(lStatus.Font.Name, 12F);
                    break;
                case 4:
                    lLocation.Font = new Font(lLocation.Font.Name, 16F);
                    lTemp.Font     = new Font(lTemp.Font.Name, 42F);
                    lStatus.Font   = new Font(lStatus.Font.Name, 14F);
                    break;
                case 5:
                    lLocation.Font = new Font(lLocation.Font.Name, 18F);
                    lTemp.Font     = new Font(lTemp.Font.Name, 44F);
                    lStatus.Font   = new Font(lStatus.Font.Name, 16F);
                    break;
            }

            if (SettingsForm.rbLight.Checked)
            {
                /*  Main Form  */
                ForeColor =              lText.ForeColor =            btnChooseOnMap.ForeColor =
                cbSearch.ForeColor =     lLocation.ForeColor =        lTemp.ForeColor =
                lStatus.ForeColor =      settingsMenu.ForeColor =     helpMenu.ForeColor =
                aboutAppMenu.ForeColor = aboutAuthorsMenu.ForeColor = Color.FromArgb(255, 0, 0, 0);

                BackColor =              lText.BackColor =            lLocation.BackColor =
                lTemp.BackColor =        lStatus.BackColor =          settingsMenu.BackColor =
                menuStrip.BackColor =    menuStrip.BackColor =        helpMenu.BackColor =
                aboutAppMenu.BackColor = aboutAuthorsMenu.BackColor = Color.FromArgb(255, 240, 240, 240);
                
                btnChooseOnMap.BackColor = cbSearch.BackColor = Color.FromArgb(255, 255, 255, 255);

                /*  Settings Form  */
                SettingsForm.ForeColor =            SettingsForm.gbLanguage.ForeColor =  
                SettingsForm.rbEnglish.ForeColor =  SettingsForm.rbUkrainian.ForeColor = 
                SettingsForm.gbFontSize.ForeColor = SettingsForm.tbFontSize.ForeColor =
                SettingsForm.gbTheme.ForeColor =    SettingsForm.rbLight.ForeColor = 
                SettingsForm.rbDark.ForeColor =     Color.FromArgb(255, 0, 0, 0);

                SettingsForm.BackColor =            SettingsForm.gbLanguage.BackColor = 
                SettingsForm.rbEnglish.BackColor =  SettingsForm.rbUkrainian.BackColor = 
                SettingsForm.gbFontSize.BackColor = SettingsForm.tbFontSize.BackColor = 
                SettingsForm.gbTheme.BackColor =    SettingsForm.rbLight.BackColor = 
                SettingsForm.rbDark.BackColor =     Color.FromArgb(255, 240, 240, 240);

                /* About authors */
                AboutAuthorsForm.ForeColor        = AboutAuthorsForm.pictureBox1.ForeColor =
                AboutAuthorsForm.label1.ForeColor = AboutAuthorsForm.label2.ForeColor =
                AboutAuthorsForm.label3.ForeColor = AboutAuthorsForm.label4.ForeColor =
                AboutAuthorsForm.label5.ForeColor = Color.FromArgb(255, 0, 0, 0);

                AboutAuthorsForm.BackColor        = AboutAuthorsForm.pictureBox1.BackColor =
                AboutAuthorsForm.label1.BackColor = AboutAuthorsForm.label2.BackColor =
                AboutAuthorsForm.label3.BackColor = AboutAuthorsForm.label4.BackColor =
                AboutAuthorsForm.label5.BackColor = Color.FromArgb(255, 240, 240, 240);

                /* About app */
                AboutAppForm.ForeColor        = AboutAppForm.pictureBox1.ForeColor =
                AboutAppForm.label1.ForeColor = Color.FromArgb(255, 0, 0, 0);
                 
                AboutAppForm.BackColor        = AboutAppForm.pictureBox1.BackColor =
                AboutAppForm.label1.BackColor = Color.FromArgb(255, 240, 240, 240);

                /* Map form */
                MapForm.ForeColor = MapForm.btnConfirm.ForeColor = Color.FromArgb(255, 0, 0, 0);
                MapForm.BackColor = MapForm.btnConfirm.BackColor = Color.FromArgb(255, 240, 240, 240);
            }
            else if (SettingsForm.rbDark.Checked)
            {
                /*  Main Form  */
                ForeColor =              lText.ForeColor =            btnChooseOnMap.ForeColor =
                cbSearch.ForeColor =     lLocation.ForeColor =        lTemp.ForeColor =
                lStatus.ForeColor =      settingsMenu.ForeColor =     helpMenu.ForeColor =
                aboutAppMenu.ForeColor = aboutAuthorsMenu.ForeColor = Color.FromArgb(255, 255, 255, 255);

                BackColor =           lText.BackColor =        btnChooseOnMap.BackColor =
                cbSearch.BackColor =  lLocation.BackColor =    lTemp.BackColor =
                lStatus.BackColor =   settingsMenu.BackColor = helpMenu.BackColor =
                menuStrip.BackColor = aboutAppMenu.BackColor = aboutAuthorsMenu.BackColor =
                Color.FromArgb(255, 36, 36, 36);

                /*  Settings Form  */
                SettingsForm.ForeColor =            SettingsForm.gbLanguage.ForeColor =
                SettingsForm.rbEnglish.ForeColor =  SettingsForm.rbUkrainian.ForeColor =
                SettingsForm.gbFontSize.ForeColor = SettingsForm.tbFontSize.ForeColor =
                SettingsForm.gbTheme.ForeColor =    SettingsForm.rbLight.ForeColor =
                SettingsForm.rbDark.ForeColor =     Color.FromArgb(255, 255, 255, 255);

                SettingsForm.BackColor =            SettingsForm.gbLanguage.BackColor =
                SettingsForm.rbEnglish.BackColor =  SettingsForm.rbUkrainian.BackColor =
                SettingsForm.gbFontSize.BackColor = SettingsForm.tbFontSize.BackColor =
                SettingsForm.gbTheme.BackColor =    SettingsForm.rbLight.BackColor =
                SettingsForm.rbDark.BackColor =     Color.FromArgb(255, 36, 36, 36);

                /* About authors */
                AboutAuthorsForm.ForeColor        = AboutAuthorsForm.pictureBox1.ForeColor = 
                AboutAuthorsForm.label1.ForeColor = AboutAuthorsForm.label2.ForeColor = 
                AboutAuthorsForm.label3.ForeColor = AboutAuthorsForm.label4.ForeColor = 
                AboutAuthorsForm.label5.ForeColor = Color.FromArgb(255, 255, 255, 255);

                AboutAuthorsForm.BackColor        = AboutAuthorsForm.pictureBox1.BackColor =
                AboutAuthorsForm.label1.BackColor = AboutAuthorsForm.label2.BackColor =
                AboutAuthorsForm.label3.BackColor = AboutAuthorsForm.label4.BackColor = 
                AboutAuthorsForm.label5.BackColor = Color.FromArgb(255, 36, 36, 36);

                /* About app */
                AboutAppForm.ForeColor        = AboutAppForm.pictureBox1.ForeColor = 
                AboutAppForm.label1.ForeColor = Color.FromArgb(255, 255, 255, 255);

                AboutAppForm.BackColor = AboutAppForm.pictureBox1.BackColor =
                AboutAppForm.label1.BackColor = Color.FromArgb(255, 36, 36, 36);

                /* Map form */
                MapForm.ForeColor = MapForm.btnConfirm.ForeColor = Color.FromArgb(255, 255, 255, 255);
                MapForm.BackColor = MapForm.btnConfirm.BackColor = Color.FromArgb(255, 36, 36, 36);
            }
        }

        private void CenterElement(Control control)
        {
            control.Location = new Point(ClientSize.Width / 2 - control.Width / 2, control.Location.Y);
        }
        
        private void UpdateInfoFromApi(QueryResponse queryResponse)
        {
            try
            {
                _exceptions.ValidateJsonAnswer(queryResponse);
            }
            catch (BadResponseException exc)
            {
                ShowErrorMsg(exc.Message, @"Request Error");
                return;
            }

            lLocation.Text = queryResponse.Name;

            if (queryResponse.Sys.Country == "RU")
            {
                lTemp.Text = @"-100°C";
                lStatus.Text = @"Heavy shower snow";
            }
            else
            {
                lTemp.Text = Math.Round(queryResponse.Main.Temperature.CelsiusCurrent).ToString(CultureInfo.InvariantCulture) + @"°C";
                lStatus.Text = queryResponse.WeatherList[0].Main;
            }

            pictureBox.Load($"http://openweathermap.org/img/wn/{queryResponse.WeatherList[0].Icon}@2x.png");

            CenterElement(pictureBox);
            CenterElement(lLocation);
            CenterElement(lTemp);
            CenterElement(lStatus);            
        }

        // render map window 
        private void btnChooseOnMap_MouseClick(object sender, MouseEventArgs e)
        {
            try 
            {
                // openFormSafely returns DialogResult if needed
                _exceptions.OpenFormSafely(MapForm);
            } 
            catch (FormNotOpenedException exc) 
            {
                ShowErrorMsg(exc.Message, "Error");
            }

            try
            {
                _exceptions.ValidateCoords(MapForm.Coords.Lat, MapForm.Coords.Lng);
            }
            catch (CoordsException) 
            {
                return;
            }
            
            UpdateInfoFromApi(new QueryResponse(_openWeatherMapApi.GetJsonResponseStringByCoords(MapForm.Coords.Lat, MapForm.Coords.Lng)));    
        }
        
        private void cbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // only the enter key is pressed and validate request
            if (e.KeyData != Keys.Enter)
            {
                return;
            }

            try
            {
                _exceptions.ValidateSearchQuery(cbSearch.Text);
            }
            catch (NaTException)
            {
                return;
            }

            UpdateInfoFromApi(new QueryResponse(_openWeatherMapApi.GetJsonResponseStringByName(cbSearch.Text)));
        }
        
        // render settings window
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // openFormSafely returns DialogResult if needed
                _exceptions.OpenFormSafely(SettingsForm);
            }
            catch (FormNotOpenedException exc)
            {
                ShowErrorMsg(exc.Message, "Error");
            }

            ApplySettings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
            try
            {
                _exceptions.ValidateExit(e);
            }
            catch (AppOnCloseException exc)
            {
                ShowErrorMsg(exc.Message, @"Warning");
            }
        }

        private void aboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // openFormSafely returns DialogResult if needed
                _exceptions.OpenFormSafely(AboutAppForm);
            }
            catch (FormNotOpenedException exc)
            {
                ShowErrorMsg(exc.Message, "Error");
            }
        }

        private void aboutAuthorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // openFormSafely returns DialogResult if needed
                _exceptions.OpenFormSafely(AboutAuthorsForm);
            }
            catch (FormNotOpenedException exc)
            {
                ShowErrorMsg(exc.Message, "Error");
            }
        }

        private static void ShowErrorMsg(string text, string caption) 
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cbSearch_DropDown(object sender, EventArgs e)
        {
            cbSearch.Items.Clear();
            
            if (cbSearch.Text.Length == 0)
            {
                return;
            }
            
            var cities = _algorithms.FindMatches(cbSearch.Text);

            foreach (var item in cities)
            {
                cbSearch.Items.Add(item);
            }
        }
    }
}