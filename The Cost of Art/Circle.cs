using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Cost_of_Art
{
    class Circle : ClsShape
    {
        int radius;
        double Pi = 3.16;
        public int Radius
        {
            get => radius;
            set => radius = value;
        }

        public override ClsShape creatshape()
        {
            printCircle();
            if (validate(this))
            {
                Shdesc = (string.Concat(this.GetType().Name, "{Fill:", Fill, ",Radius:", Radius, ",Outline:", Outline, ",Thickness:", Thickness, "}"));
                return this;
            }
            else
            {
                Console.WriteLine("invalid Circle parameters");
                return null;
            }
        }
        public ClsShape loadcircle(string Shdesc)
        {
            Circle cir = new Circle();
            cir.Shdesc = Shdesc;
            Shdesc = Shdesc.Substring(7, Shdesc.Length - 8);
            string[] prop = Shdesc.Split(",");
            foreach (string p in prop)
            {
                if (p.Contains("Fill"))
                {
                    cir.Fill = p.Replace("Fill:", "");
                }
                else if (p.Contains("Radius"))
                {
                    cir.Radius = Convert.ToInt32(p.Replace("Radius:", ""));
                }
                else if (p.Contains("Outline"))
                {
                    cir.Outline = (p.Replace("Outline:", ""));
                }
                else if (p.Contains("Thickness"))
                {
                    cir.Thickness = Convert.ToDouble(p.Replace("Thickness:", ""));
                }
            }

            return cir;

        }


        public static string printpaintingeditactionmenu(string item)
        {
            item = item.Replace("Circle{", "");
            item = item.Replace("}", "");
        paintingeditactionmenu:
            Console.WriteLine("Please select an action");
            Console.WriteLine("1. change radius.");
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
                Console.WriteLine("enter new Radius:");
                int newheight = Convert.ToInt32(Console.ReadLine());

                temp[1] = "Radius:" + newheight;

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
            string retstring = "Circle{";
            foreach (string s in temp)
            {
                retstring = retstring + s + ",";

            }

            return (retstring.Substring(0, retstring.Length - 1) + "}");
        }

        private void printCircle()
        {
            Console.WriteLine("Please Enter's the circle's radius");
            Radius = Convert.ToInt32(Console.ReadLine());
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


        public bool validate(Circle cir)
        {

            if ((cir.radius >= 5 && cir.radius <= 50) && (cir.Thickness >= 0.1 && cir.Thickness <= 5) && (Enum.IsDefined(typeof(Colors), cir.Outline)) && (Enum.IsDefined(typeof(Colors), cir.Fill)))
            {
                return true;
            }
            return false;
        }

        public Circle loadcirclelocal(string Shdesc)
        {
            Circle cir = new Circle();
            cir.Shdesc = Shdesc;
            Shdesc = Shdesc.Substring(7, Shdesc.Length - 8);
            string[] prop = Shdesc.Split(",");
            foreach (string p in prop)
            {
                if (p.Contains("Fill"))
                {
                    cir.Fill = p.Replace("Fill:", "");
                }
                else if (p.Contains("Radius"))
                {
                    cir.Radius = Convert.ToInt32(p.Replace("Radius:", "").Replace("}", ""));
                }
                else if (p.Contains("Outline"))
                {
                    cir.Outline = (p.Replace("Outline:", ""));
                }
                else if (p.Contains("Thickness"))
                {
                    cir.Thickness = Convert.ToDouble(p.Replace("Thickness:", ""));
                }
            }

            return cir;

        }

        public Circle area(string Shdesc, out double fillarea, out double outlinearea)
        {
            Circle cir = loadcirclelocal(Shdesc);
            fillarea = Pi * cir.Radius * cir.Radius;
            outlinearea = 2 * Pi * cir.Radius * cir.Thickness;
            return cir;
        }


    }
}

