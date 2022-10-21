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
using System.Globalization;

namespace WeatherMap
{
    public partial class MapForm : Form
    {
        // мітки на карті
        private readonly GMapOverlay _points = new GMapOverlay("Points");
        // мітка
        private GMapMarker _point;
        private string _location = "Zaporizhzhia";
        public PointLatLng Coords;
        NumberFormatInfo NFI = new NumberFormatInfo()
        {
            NumberDecimalSeparator = ".",
        };

        public MapForm()
        {
            InitializeComponent();
            SetupMap();
        }

        private void SetPointer(PointLatLng point)
        {
            if (_points.Markers.Any()) // якщо є мітка
                _points.Markers.Clear(); // чистимо список міток
            
            // створюємо нову мітку
            _point = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
            
            // текст мітки
            _point.ToolTipText = $"Lat: {point.Lat}\nLng: {point.Lng}"; 
            
            // додаєм мітку у список міток
            _points.Markers.Add(_point); 
            
            // центруємо карту
            map.Position = point; 
        }

        // поверне кординати мітки за певним запитом
        private PointLatLng GetCoords(string location) 
        {
            GMapControl mapControl = new GMapControl();
            
            mapControl.SetPositionByKeywords(location);
            
            PointLatLng point = new PointLatLng(mapControl.Position.Lat, mapControl.Position.Lng);

            Coords = new PointLatLng(mapControl.Position.Lat, mapControl.Position.Lng);

            return point;
        }

        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle) 
                return;

            // створюємо кординати мітки
            PointLatLng point = map.FromLocalToLatLng(e.X, e.Y);  
            
            // встановлюємо нову мітку
            SetPointer(point); 
            
            // зберігаємо lat / lng для доступу з main форми
            Coords = new PointLatLng(map.Position.Lat, map.Position.Lng); 
        }

        private void SetupMap() 
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
            // відображення на карті міток зі списка Points
            map.Overlays.Add(_points); 
            // встановлюємо мітку
            SetPointer(GetCoords(_location)); 
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
