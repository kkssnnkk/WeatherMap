using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace WeatherMap.Forms
{
    public partial class MapForm : Form
    {
        // point on map
        private readonly GMapOverlay _points = new GMapOverlay("points");
        
        private readonly GMapControl _mapControl = new GMapControl();
        
        // point
        private GMapMarker _point;
        
        public PointLatLng Coords;
        
        // default location
        private new const string Location = "Zaporizhzhya";

        // formatting floating point types
        private readonly NumberFormatInfo _nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };

        public MapForm()
        {
            InitializeComponent();
            InitializeMap();
        }
        
        // initialize default settings for map
        private void InitializeMap() 
        {
            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            
            // setting minimal zoom
            map.MinZoom = 2;
            
            // setting maximal zoom
            map.MaxZoom = 16;
            
            // setting default zoom
            map.Zoom = 10;
            
            // setting mouse wheel zoom type
            map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            
            // setting ability to move the map
            map.CanDragMap = true;
            
            // setting mouse button for drag map
            map.DragButton = MouseButtons.Left;
            
            map.ShowCenter = false;
            
            map.ShowTileGridLines = false;
            
            // display of points from the points list on the map
            map.Overlays.Add(_points); 
            
            // set the default point
            SetPointer(GetCoords(Location));
        }

        // will set the point on map
        private void SetPointer(PointLatLng point)
        {
            // if there are points
            if (_points.Markers.Any())
            {
                // clear the points list
                _points.Markers.Clear();
            }

            // create a new point
            _point = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
            
            // point text
            _point.ToolTipText = $"Lat: {point.Lat.ToString(_nfi)}\nLng: {point.Lng.ToString(_nfi)}"; 
            
            // add the point to point list
            _points.Markers.Add(_point); 
            
            // center map
            map.Position = point;
        }

        // will return the point coordinates on a given location name
        private PointLatLng GetCoords(string location) 
        {
            // setting coords by location
            _mapControl.SetPositionByKeywords(location);
            
            // write coords
            Coords = new PointLatLng(_mapControl.Position.Lat, _mapControl.Position.Lng);
            
            return Coords;
        }

        // mouse click event for map
        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            // only the middle button is pressed
            if (e.Button != MouseButtons.Middle)
                return;

            // we create the coordinates of the point and store the lat / lng for access from the main form
            Coords = map.FromLocalToLatLng(e.X, e.Y);  
            
            // setting new point
            SetPointer(Coords);
        }

        // button click event
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}