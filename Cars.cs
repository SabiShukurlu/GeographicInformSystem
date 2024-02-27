using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeographicInformationSystem1
{
    internal class Cars
    {
        private string lisence_plate;
        private string carstype;
        private string from;
        private string to;
        private PointLatLng location;

        public Cars(string lisence_plate, string carstype, string from, string to,PointLatLng location)
        {
            this.Lisence_plate = lisence_plate;
            this.Carstype = carstype;
            this.From = from;
            this.To = to;
            this.Location = location;
        }

        public string Lisence_plate { get => lisence_plate; set => lisence_plate = value; }
        public string Carstype { get => carstype; set => carstype = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public PointLatLng Location { get => location; set => location = value; }

        public override string ToString()
        {
            string str="\n" + lisence_plate + "\n" + carstype + "\n" + from + "\n" + to;
            return str;
        }
    }
}
