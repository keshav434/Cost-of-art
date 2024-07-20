using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Cost_of_Art
{
    class paintcolor
    {
        string colorname;
        string color;
        double coverage;
        string coverageunit;
        double price;
        string colordesc;
        string priceunit;

        public string Colorname { get => colorname; set => colorname = value; }
        public double Coverage { get => coverage; set => coverage = value; }
        public double Price { get => price; set => price = value; }
        public string Colordesc { get => colordesc; set => colordesc = value; }
        public string Color { get => color; set => color = value; }
        public string Coverageunit { get => coverageunit; set => coverageunit = value; }
        public string Priceunit { get => priceunit; set => priceunit = value; }
    }
}