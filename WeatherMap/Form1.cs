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
    public partial class Form1 : Form
    {
        public GMapOverlay points = new GMapOverlay("points"); // метки на карте
        public GMapMarker point; // метка

        public Form1()
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
            map.Overlays.Add(points); // отображение на карте меток из списка points
            setPointer(getCoords("Zaporizhzhia, Ukraine")); // устанавливаем метку
        }

        private void setPointer(PointLatLng point)
        {
            if (points.Markers.Count() > 0) // если меток больше чем одна
                points.Markers.Clear();

            this.point = new GMarkerGoogle(point, GMarkerGoogleType.red_dot); // создаём новую метку
            this.point.ToolTipText = $"Lat: {point.Lat}\nLng: {point.Lng}"; // текст метки
            points.Markers.Add(this.point); // закидываем метку в список меток
            map.Position = point; // центрируем карту
        }

        private PointLatLng getCoords(string q) // вернёт координаты метки по опр. запросу
        {
            GMapControl m = new GMapControl();
            m.SetPositionByKeywords(q);
            PointLatLng point = new PointLatLng(m.Position.Lat, m.Position.Lng);
            return point;
        }

        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                PointLatLng point = map.FromLocalToLatLng(e.X, e.Y); // создаём координаты метки 
                setPointer(point); // устанавливаем новую метку
            }
        }
    }
}
