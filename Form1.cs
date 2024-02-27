using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GMap.NET.MapProviders.StrucRoads.SnappedPoint;

namespace GeographicInformationSystem1
{
    public partial class Form1 : Form
    {
        GMapOverlay layer1;
        List<Cars> list;
        public Form1()
        {
            InitializeComponent();
            InitializeMap();
            CreateCarOList();

        }

        private void CreateCarOList()
        {
            list = new List<Cars>();
            list.Add(new Cars("50CX863", "TRACK", "Baku", "Yardımlı", new PointLatLng(40.39,49.86)));
            list.Add(new Cars("10CX863", "MINUVAN", "Baku", "Gedebek", new PointLatLng(40.39, 45.76)));
            list.Add(new Cars("44SS433", "CARAVAN", "Baku", "Ucar", new PointLatLng(40.39, 47.86)));
            list.Add(new Cars("50KL555", "JEEP", "Baku", "Ankara", new PointLatLng(40.39, 32.99)));
            list.Add(new Cars("50MM233", "TRACTOR", "Baku", "Chorum", new PointLatLng(40.39, 34.88)));






        }

        private void InitializeMap()
        {
            map.DragButton=MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;//you can change map type
            map.Position = new GMap.NET.PointLatLng(36.0, 42.0);
            map.Zoom = 4;
            map.MinZoom = 3;
            map.MaxZoom = 25;
            layer1 = new GMapOverlay();

            //creat overlay for adding all components on the map
            //GMapOverlay layer1 = new GMapOverlay();
            //first of all  adding layer1 on the map
            map.Overlays.Add(layer1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointLatLng location1 = new PointLatLng(Convert.ToDouble(textBoxLatitude.Text),
                                                    Convert.ToDouble(textBoxLengthitude.Text));
            GMarkerGoogle marker = new GMarkerGoogle(location1, GMarkerGoogleType.blue_dot);
            marker.ToolTipText = "Location1\nFrom Anywhere\nto AnyWhere";
            marker.ToolTip.Fill = Brushes.Black;
            marker.ToolTip.Foreground = Brushes.White;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new Size(10, 10);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;//always
            marker.Tag = 101;
            
            //then adding markers
            //Warning if you first adding marker then marker has been standing wrong place
            layer1.Markers.Add(marker);
            

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            map.Dispose();
            Application.Exit();
        }

        private void map_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            //int markerId = (int)item.Tag;
            //Console.WriteLine($"push on the marker which id is{markerId}");

            string lisencePlateOfSelectedCar = (string)item.Tag;
            foreach(Cars car in list)
            {
                if (lisencePlateOfSelectedCar.Equals(car.Lisence_plate))
                {
                    textBox3.Text = lisencePlateOfSelectedCar;
                    textBox4.Text = car.Carstype;
                    textBox5.Text=car.From;
                    textBox6.Text=car.To;
                    break;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            PointLatLng location2 = new PointLatLng(Convert.ToDouble(textBox2.Text),
                                                    Convert.ToDouble(textBox1.Text));
            GMarkerGoogle marker2 = new GMarkerGoogle(location2, GMarkerGoogleType.red_dot);
            marker2.Tag = 102;
            layer1.Markers.Add(marker2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(Cars cars in list)
            {
                GMarkerGoogle markerTemp = new GMarkerGoogle(cars.Location, GMarkerGoogleType.green_dot);
                markerTemp.ToolTipText = cars.ToString();
                markerTemp.Tag = cars.Lisence_plate;

                layer1.Markers.Add(markerTemp);
                markerTemp.ToolTipMode = MarkerTooltipMode.Always;
            }
        }
    }
}
