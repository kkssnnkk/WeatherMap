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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WeatherMap
{
    public partial class MapForm : Form
    {
        private readonly GMapOverlay _points = new GMapOverlay("Points"); // мітки на карті
        private GMapMarker _point; // мітка
        private new string Location = "Kiev";
        public PointLatLng coords;

        public MapForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; this.MaximizeBox = false;
            InitializeComponent();
            setupMap();
        }

        public MapForm(string city) 
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; this.MaximizeBox = false;
            this.Location = city;
            InitializeComponent();
            setupMap();
        }

        private void SetPointer(PointLatLng point)
        {
            if (_points.Markers.Any()) // якщо є мітка
                _points.Markers.Clear(); // чистимо список міток

            this._point = new GMarkerGoogle(point, GMarkerGoogleType.red_dot); // створюємо нову мітку
            this._point.ToolTipText = $"Lat: {point.Lat}\nLng: {point.Lng}"; // текст мітки
            
            _points.Markers.Add(this._point); // додаєм мітку у список міток
            
            map.Position = point; // центруємо карту
        }

        private PointLatLng GetCoords(string q) // поверне кординати мітки за певним запитом
        {
            GMapControl m = new GMapControl();
            
            m.SetPositionByKeywords(q);
            
            PointLatLng point = new PointLatLng(m.Position.Lat, m.Position.Lng);

            return point;
        }

        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle) return;

            PointLatLng point = map.FromLocalToLatLng(e.X, e.Y); // створюємо кординати мітки 
            SetPointer(point); // встановлюємо нову мітку
            this.coords = new PointLatLng(map.Position.Lat, map.Position.Lng); // зберігаємо lat / lng для доступу з main форми
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setupMap() 
        {
            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            map.MinZoom = 2;
            map.MaxZoom = 16;
            map.Zoom = 10;
            map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            map.CanDragMap = true;
            map.DragButton = MouseButtons.Left;
            map.ShowCenter = false;
            map.ShowTileGridLines = false;
            map.Overlays.Add(_points); // відображення на карті міток зі списка Points
            SetPointer(GetCoords(Location)); // встановлюємо мітку
        }
    }
}
