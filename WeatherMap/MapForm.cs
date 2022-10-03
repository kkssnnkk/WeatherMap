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

namespace WeatherMap
{
    public partial class MapForm : Form
    {
        private GMapOverlay Points = new GMapOverlay("Points"); // мітки на карті
        private GMapMarker Point; // мітка

        public MapForm()
        {
            InitializeComponent();
        }

        private void map_Load(object sender, EventArgs e)
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
            map.Overlays.Add(Points); // відображення на карті міток зі списка Points
            SetPointer(GetCoords("Zaporizhzhia, Ukraine")); // встановлюємо мітку
        }

        private void SetPointer(PointLatLng point)
        {
            if (Points.Markers.Any()) // якщо є мітка
                Points.Markers.Clear(); // чистимо список міток

            this.Point = new GMarkerGoogle(point, GMarkerGoogleType.red_dot); // створюємо нову мітку
            this.Point.ToolTipText = $"Lat: {point.Lat}\nLng: {point.Lng}"; // текст мітки
            
            Points.Markers.Add(this.Point); // додаєм мітку у список міток
            
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
        }
    }
}
