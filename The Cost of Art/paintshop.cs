using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Cost_of_Art
{
    class paintshop
    {
        string shoptitle;
        public List<paintcolor> ptcolor = new List<paintcolor>();


        public string Shoptitle { get => shoptitle; set => shoptitle = value; }

        public paintcolor loadcsvshopcolor(string Shdesc)
        {
            
            paintcolor pc = new paintcolor();
            try
            {
                pc.Colordesc = Shdesc;

                string[] prop = Shdesc.Split(",");
                pc.Colorname = prop[0];
                pc.Color = prop[1];
                pc.Coverage = Convert.ToInt32(prop[2]);
                pc.Price = Convert.ToDouble(prop[3]);
                pc.Coverageunit = "CM2PerML";
                pc.Priceunit = "PencePerML";
            }
            catch (Exception ex) { }

            return pc;

        }

        public paintcolor loadtxtshopcolor(string Shdesc)
        {
            paintcolor pc = new paintcolor();

            pc.Colordesc = Shdesc.Substring(6, Shdesc.Length - 7);
            string[] prop = pc.Colordesc.Split(",");

            foreach (string p in prop)
            {
                if (p.Contains("Name"))
                {
                    pc.Colorname = p.Replace("Name:", "");
                }
                else if (p.Contains("Colour"))
                {
                    pc.Color = (p.Replace("Colour:", ""));
                }
                else if (p.Contains("CM^2PerLitre"))
                {
                    pc.Coverageunit = "CM^2PerLitre";
                    pc.Coverage = Convert.ToDouble(p.Replace("CM^2PerLitre:", ""));
                }
                else if (p.Contains("CM^2PerML"))
                {
                    pc.Coverageunit = "CM^2PerML";
                    pc.Coverage = Convert.ToDouble(p.Replace("CM^2PerML:", ""));
                }
                else if (p.Contains("PencePerML"))
                {
                    pc.Priceunit = "PencePerML";
                    pc.Price = Convert.ToDouble(p.Replace("PencePerML:", ""));
                }
                else if (p.Contains("PricePerLitre"))
                {
                    pc.Priceunit = "PricePerLitre";
                    pc.Price = Convert.ToDouble(p.Replace("PricePerLitre:", ""));
                }
            }
            return pc;

        }
    }
}