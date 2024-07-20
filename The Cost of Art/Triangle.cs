using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Cost_of_Art
{
    class Triangle : ClsShape
    {
        int side;

        public int Side
        {
            get => side;
            set => side = value;
        }

        public override ClsShape creatshape()
        {
            printTriangle();
            if (validate(this))
            {
                Shdesc = (string.Concat(this.GetType().Name, "{Fill:", Fill, ",Side:", Side, ",Outline:", Outline, ",Thickness:", Thickness, "}"));
                return this;
            }
            else
            {
                Console.WriteLine("invalid Triangle parameters");
                return null;
            }
        }
        public ClsShape loadtriangle(string Shdesc)
        {
            Triangle tri = new Triangle();
            tri.Shdesc = Shdesc;
            Shdesc = Shdesc.Substring(9, Shdesc.Length - 10);
            string[] prop = Shdesc.Split(",");
            foreach (string p in prop)
            {
                if (p.Contains("Fill"))
                {
                    tri.Fill = p.Replace("Fill:", "");
                }
                else if (p.Contains("Side"))
                {
                    tri.Side = Convert.ToInt32(p.Replace("Side:", ""));
                }
                else if (p.Contains("Outline"))
                {
                    tri.Outline = (p.Replace("Outline:", ""));
                }
                else if (p.Contains("Thickness"))
                {
                    tri.Thickness = Convert.ToDouble(p.Replace("Thickness:", ""));
                }
            }

            return tri;

        }


        public static string printpaintingeditactionmenu(string item)
        {
            item = item.Replace("Triangle{", "");
            item = item.Replace("}", "");
        paintingeditactionmenu:
            Console.WriteLine("Please select an action");
            Console.WriteLine("1. change side.");
            Console.WriteLine("2. change fill color.");
            Console.WriteLine("3. change outline color.");
            Console.WriteLine("4. change outline thickness.");
            Console.WriteLine("Please enter a value from 1 to 4 inclusive.");
            int menuoption = Convert.ToInt32(Console.ReadLine());

            if (menuoption < 1 || menuoption > 4)
            {
                Console.WriteLine(menuoption + " is not a value from 1 to 4 inclusive.");
                goto paintingeditactionmenu;

            }
            string[] temp = item.Split(",");
            if (menuoption == 1)
            {
                Console.WriteLine("enter new Side:");
                int newheight = Convert.ToInt32(Console.ReadLine());

                temp[1] = "Side:" + newheight;

            }
            else if (menuoption == 2)
            {
                Console.WriteLine("Please select the fill colour.");
                printcolor();
                string NewFill = "";

                int optionfillcolor = Convert.ToInt32(Console.ReadLine());
                switch (optionfillcolor)
                {
                    case 1:
                        NewFill = "Black";
                        break;
                    case 2:
                        NewFill = "Blue";
                        break;
                    case 3:
                        NewFill = "Green";
                        break;
                    case 4:
                        NewFill = "Indigo";
                        break;
                    case 5:
                        NewFill = "Orange";
                        break;
                    case 6:
                        NewFill = "Red";
                        break;
                    case 7:
                        NewFill = "Violet";
                        break;
                    case 8:
                        NewFill = "Yellow";
                        break;
                    default:
                        NewFill = "White";
                        break;
                }
                temp[0] = "Fill:" + NewFill;

            }//todo
            else if (menuoption == 3)
            {
                Console.WriteLine("Please select the outline colour.");
                printcolor();
                int optionoutlinecolor = Convert.ToInt32(Console.ReadLine());
                string newOutline = "";
                switch (optionoutlinecolor)
                {
                    case 1:
                        newOutline = "Black";
                        break;
                    case 2:
                        newOutline = "Blue";
                        break;
                    case 3:
                        newOutline = "Green";
                        break;
                    case 4:
                        newOutline = "Indigo";
                        break;
                    case 5:
                        newOutline = "Orange";
                        break;
                    case 6:
                        newOutline = "Red";
                        break;
                    case 7:
                        newOutline = "Violet";
                        break;
                    case 8:
                        newOutline = "Yellow";
                        break;
                    default:
                        newOutline = "White";
                        break;
                }
                temp[2] = "Outline:" + newOutline;
            }
            else if (menuoption == 4)
            {
                Console.WriteLine("Enter the Thinkness");
                double newthickness = Convert.ToDouble(Console.ReadLine());

                temp[3] = "Thickness:" + newthickness;
            }
            string retstring = "Triangle{";
            foreach (string s in temp)
            {
                retstring = retstring + s + ",";

            }

            return (retstring.Substring(0, retstring.Length - 1) + "}");
        }

        private void printTriangle()
        {
            Console.WriteLine("Please Enter's the triangle's side");
            Side = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please select the fill colour.");
            printcolor();

            int optionfillcolor = Convert.ToInt32(Console.ReadLine());
            switch (optionfillcolor)
            {
                case 1:
                    Fill = "Black";
                    break;
                case 2:
                    Fill = "Blue";
                    break;
                case 3:
                    Fill = "Green";
                    break;
                case 4:
                    Fill = "Indigo";
                    break;
                case 5:
                    Fill = "Orange";
                    break;
                case 6:
                    Fill = "Red";
                    break;
                case 7:
                    Fill = "Violet";
                    break;
                case 8:
                    Fill = "Yellow";
                    break;
                default:
                    Fill = "White";
                    break;
            }

            Console.WriteLine("Please select the outline colour.");
            printcolor();
            int optionoutlinecolor = Convert.ToInt32(Console.ReadLine());

            switch (optionoutlinecolor)
            {
                case 1:
                    Outline = "Black";
                    break;
                case 2:
                    Outline = "Blue";
                    break;
                case 3:
                    Outline = "Green";
                    break;
                case 4:
                    Outline = "Indigo";
                    break;
                case 5:
                    Outline = "Orange";
                    break;
                case 6:
                    Outline = "Red";
                    break;
                case 7:
                    Outline = "Violet";
                    break;
                case 8:
                    Outline = "Yellow";
                    break;
                default:
                    Outline = "White";
                    break;
            }
            Console.WriteLine("Please Enter's the outline thickness");
            Thickness = Convert.ToDouble(Console.ReadLine());
        }


        public bool validate(Triangle tri)
        {
            // error
            if ((tri.side >= 5 && tri.side <= 50) && (tri.Thickness >= 0.1 && tri.Thickness <= 5) && (Enum.IsDefined(typeof(Colors), tri.Outline)) && (Enum.IsDefined(typeof(Colors), tri.Fill)))
            {
                return true;
            }
            return false;
        }

        public Triangle loadtrianglelocal(string Shdesc)
        {
            Triangle tri = new Triangle();
            tri.Shdesc = Shdesc;
            Shdesc = Shdesc.Substring(9, Shdesc.Length - 10);
            string[] prop = Shdesc.Split(",");
            foreach (string p in prop)
            {
                if (p.Contains("Fill"))
                {
                    tri.Fill = p.Replace("Fill:", "");
                }
                else if (p.Contains("Side"))
                {
                    tri.Side = Convert.ToInt32(p.Replace("Side:", ""));
                }
                else if (p.Contains("Outline"))
                {
                    tri.Outline = (p.Replace("Outline:", ""));
                }
                else if (p.Contains("Thickness"))
                {
                    tri.Thickness = Convert.ToDouble(p.Replace("Thickness:", ""));
                }
            }

            return tri;

        }

        public Triangle area(string Shdesc, out double fillarea, out double outlinearea)
        {
            Triangle tri = loadtrianglelocal(Shdesc);
            fillarea = tri.Side * tri.Side * 1.732;
            outlinearea = 3 * tri.Side * tri.Thickness;
            return tri;
        }


    }

}
