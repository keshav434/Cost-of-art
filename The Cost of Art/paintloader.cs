using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace The_Cost_of_Art
{
    class paintloader
    {


        public string getpaintshops(string shoptype)
        {
            string paintshoppath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Assembly.GetExecutingAssembly().ToString()).ToString()).ToString()).ToString()) + @"\Paint Shops\";
            string[] paintshops = Directory.GetFiles(paintshoppath, "*." + shoptype);
            ptshop:
            Console.WriteLine("Please select a paint shop");
            int i = 1;
            foreach (string item in paintshops)
            {
                Console.WriteLine(i.ToString() + ". " + item);
                i++;
            }

            int selectedpainshop = Convert.ToInt32(Console.ReadLine());
            string valresult = validatepaintshop(paintshops[selectedpainshop - 1]);
            if (valresult == string.Empty)
            {
                Console.WriteLine("Paintshop is not valid\n");
                goto ptshop;

            }
            return paintshops[selectedpainshop - 1];

        }

        public paintshop loadshop(string shoppath)
        {
            paintshop ps = new paintshop();
            paintloader pl = new paintloader();
            string[] lines = System.IO.File.ReadAllLines(shoppath);
            if (shoppath.EndsWith(".txt"))
            {

                int i = 0;
                foreach (string item in lines)
                {
                    if (i == 0)
                    { ps.Shoptitle = item.Replace("Name:", ""); }
                    else
                    {
                        ps.ptcolor.Add(ps.loadtxtshopcolor(item));
                    }
                    i++;
                }
            }
            else
            {

                int i = 0;
                foreach (string item in lines)
                {
                    if (i == 0)
                    { ps.Shoptitle = item; }
                    else if (i > 1)
                    {
                        ps.ptcolor.Add(ps.loadcsvshopcolor(item));
                    }
                    i++;
                }
            }

            return ps;
        }
        private string validatepaintshop(string paintshop)
        {
            // string[] lines = System.IO.File.ReadAllLines(paintshop);
            //todo validation
            paintshop ps = loadshop(paintshop);
            if (ps.Shoptitle.Trim().Length < 8)
            {
                return string.Empty;
            }
            else if (ps.ptcolor.Count<=0)
            {
                return string.Empty;
            }
            else 
            {
                foreach (paintcolor pt in ps.ptcolor)
                {
                    if ((pt.Colorname.Trim().Length < 6) && (pt.Coverage >= 1 && pt.Coverage <= 8) && (pt.Price >= 1 && pt.Price <= 10) && (pt.Priceunit != "PencePerML") && (pt.Coverageunit != "CM^2PerML") && (Enum.IsDefined(typeof(Colors), pt.Color)))
                    { return string.Empty; }

                }

            }  

            return ps.Shoptitle;
        }
        
        public bool issupplyavailable(paintshop ps, Painting pt)
        {
            int colormatch = 0;
            foreach (paintcolor coloritem in ps.ptcolor)
            {
                foreach (ClsShape paintitem in pt.shapes)
                {
                    if (coloritem.Color.ToUpper() == paintitem.Fill.ToUpper())
                    {
                        colormatch++;
                    }
                    if (coloritem.Color.ToUpper() == paintitem.Outline.ToUpper())
                    {
                        colormatch++;
                    }
                }
            }
            if (colormatch == pt.shapes.Count * 2)
            {
                return true;
            }
            return false;
        }

        public void getquote(paintshop ps, Painting pt)
        {
            double fillarea = 0;
            double outlinearea = 0;
            List<string> colorlist = new List<string>();
            List<double> arealist = new List<double>();
            List<double> pricelist = new List<double>();
            foreach (ClsShape sh in pt.shapes)
            {
                if (sh.GetType().Name.ToUpper() == "SQUARE")
                {
                    Square sq = new Square();
                    sq = sq.area(sh.Shdesc, out fillarea, out outlinearea);
                    calculatearea(sq.Fill, fillarea, ref colorlist, ref arealist);
                    calculatearea(sq.Outline, outlinearea, ref colorlist, ref arealist);
                }
                else if (sh.GetType().Name.ToUpper() == "RECTANGLE")
                {
                    Rectangle rec = new Rectangle();
                    rec = rec.area(sh.Shdesc, out fillarea, out outlinearea);
                    calculatearea(rec.Fill, fillarea, ref colorlist, ref arealist);
                    calculatearea(rec.Outline, outlinearea, ref colorlist, ref arealist);
                }
                else if (sh.GetType().Name.ToUpper() == "TRIANGLE")
                {
                    Triangle tri = new Triangle();
                    tri = tri.area(sh.Shdesc, out fillarea, out outlinearea);
                    calculatearea(tri.Fill, fillarea, ref colorlist, ref arealist);
                    calculatearea(tri.Outline, outlinearea, ref colorlist, ref arealist);
                }
                else if (sh.GetType().Name.ToUpper() == "CIRCLE")
                {
                    Circle cir = new Circle();
                    cir = cir.area(sh.Shdesc, out fillarea, out outlinearea);
                    calculatearea(cir.Fill, fillarea, ref colorlist, ref arealist);
                    calculatearea(cir.Outline, outlinearea, ref colorlist, ref arealist);
                }
                
            }

            int i = 0;
            double totalcost = 0;
            List<string> quotelist = new List<string>();
            foreach (string x in colorlist)
            {
                for (int j = 0; j < ps.ptcolor.Count(); j++)
                {
                    if (x.ToUpper() == ps.ptcolor[j].Color.ToUpper())
                    {
                        double qty = arealist[i] / ps.ptcolor[j].Coverage;
                        double colorcost = qty * ps.ptcolor[j].Price;
                        // pricelist.Insert(i, colorcost);
                        totalcost = totalcost + colorcost;
                        int k = 0;

                        if (pricelist.Count > 0)
                        {
                            foreach (double d in pricelist)
                            {
                                if (colorcost < d)
                                {
                                    pricelist.Insert(k, colorcost);
                                    quotelist.Insert(k, Math.Round(qty, 2).ToString() + " ml of " + ps.ptcolor[j].Color + " paint at £ " + ps.ptcolor[j].Price + " per ml= £ " + Math.Round(colorcost,2).ToString());
                                }
                                else
                                {
                                    pricelist.Add(colorcost);
                                    quotelist.Add(Math.Round(qty, 2).ToString() + " ml of " + ps.ptcolor[j].Color + " paint at £ " + ps.ptcolor[j].Price + " per ml= £ " + Math.Round(colorcost,2).ToString() );
                                }

                                k++;
                            }
                        }
                        else
                        {
                            pricelist.Add(colorcost);
                            quotelist.Add(Math.Round(qty, 2).ToString() + " ml of " + ps.ptcolor[j].Color + " paint at £ " + ps.ptcolor[j].Price + " per ml= £ " + Math.Round(colorcost, 2).ToString());
                        }

                    }
                }

                i++;
            }

            foreach (string s in quotelist) 
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("The paint will cost £ " + Math.Round(totalcost, 2).ToString());

        }

        private void calculatearea(string color, double area, ref List<string> colorlist, ref List<double> arealist)
        {
            int index = colorlist.IndexOf(color);
            if (index >= 0)
            {
                arealist[index] = arealist[index] + area;
            }
            else
            {
                colorlist.Add(color);
                arealist.Add(area);

            }
        }
    }
}