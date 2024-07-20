using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Cost_of_Art
{
    class Rectangle : ClsShape
    {
        double height;
        double width;

        public double Height
        {
            get => height; set => height = value;
        }

        public double Width
        {
            get => width; set => width = value;
        }

        public override ClsShape creatshape()
        {
            printRectangle();
            if (validate(this))
            {
                Shdesc = (string.Concat(this.GetType().Name, "{Fill:", Fill, ",Height:", Height, ",Outline:", Outline, ",Thickness:", Thickness, ",Width:", Width, "}"));
                return this;
            }
            else
            {
                Console.WriteLine("invalid Rectangle parameters");
                return null;
            }


        }


        public ClsShape loadrectangle(string Shdesc)     // reading the file
        {
            Rectangle rec = new Rectangle();
            rec.Shdesc = Shdesc;
            Shdesc = Shdesc.Substring(10, Shdesc.Length - 11);
            string[] prop = Shdesc.Split(",");
            foreach (string p in prop)
            {
                if (p.Contains("Fill"))
                {
                    rec.Fill = p.Replace("Fill:", "");
                }
                else if (p.Contains("Height"))
                {
                    rec.Height = Convert.ToDouble(p.Replace("Height:", ""));
                }
                else if (p.Contains("Width"))
                {
                    rec.Width = Convert.ToDouble(p.Replace("Width:", ""));
                }
                else if (p.Contains("Outline"))
                {
                    rec.Outline = (p.Replace("Outline:", ""));
                }
                else if (p.Contains("Thickness"))
                {
                    rec.Thickness = Convert.ToDouble(p.Replace("Thickness:", ""));
                }
            }

            return rec;

        }


        public bool validate(Rectangle rec)
        {
            try
            {

                if ((rec.height >= 5 && rec.height <= 50) && (rec.width >= 5 && rec.width <= 50) && (rec.Thickness >= 0.1 && rec.Thickness <= 5) && (Enum.IsDefined(typeof(Colors), rec.Outline)) && (Enum.IsDefined(typeof(Colors), rec.Fill)))
                {
                    return true;
                }
            }
            catch (Exception ex)
            { }
            return false;

        }

        public static string printpaintingeditactionmenu(string item)
        {
            item = item.Replace("Rectangle{", "");
            item = item.Replace("}", "");
        paintingeditactionmenu:
            Console.WriteLine("Please select an action");
            Console.WriteLine("1. change height.");
            Console.WriteLine("2. change width");
            Console.WriteLine("3. change fill color.");
            Console.WriteLine("4. change outline color.");
            Console.WriteLine("5. change outline thickness.");
            Console.WriteLine("Please enter a value from 1 to 5 inclusive.");
            int menuoption = Convert.ToInt32(Console.ReadLine());

            if (menuoption < 1 || menuoption > 5)
            {
                Console.WriteLine(menuoption + " is not a value from 1 to 5 inclusive.");
                goto paintingeditactionmenu;

            }
            string[] temp = item.Split(",");
            if (menuoption == 1)
            {
                Console.WriteLine("enter new height:");
                int newheight = Convert.ToInt32(Console.ReadLine());

                temp[1] = "Height:" + newheight;

            }
            else if (menuoption == 2)
            {
                Console.WriteLine("enter new width:");
                int newwidth = Convert.ToInt32(Console.ReadLine());

                temp[4] = "Width:" + newwidth;

            }
            else if (menuoption == 3)
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
            else if (menuoption == 4)
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
            else if (menuoption == 5)
            {
                Console.WriteLine("Enter the Thinkness");
                double newthickness = Convert.ToDouble(Console.ReadLine());

                temp[3] = "Thickness:" + newthickness;
            }
            string retstring = "Rectangle{";
            foreach (string s in temp)
            {
                retstring = retstring + s + ",";

            }

            return (retstring.Substring(0, retstring.Length - 1) + "}");
        }
        private void printRectangle()
        {
            Console.WriteLine("Please enter the rectangle's height.");
            Console.WriteLine("Please enter a value from 5 to 50 inclusive.");
            Height = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the rectangle's width.");
            Console.WriteLine("Please enter a value from 5 to 50 inclusive.");
            Width = Convert.ToInt32(Console.ReadLine());

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


        public Rectangle loadrectanglelocal(string Shdesc)
        {
            Rectangle rec = new Rectangle();
            rec.Shdesc = Shdesc;
            Shdesc = Shdesc.Substring(10, Shdesc.Length - 11);
            string[] prop = Shdesc.Split(",");
            foreach (string p in prop)
            {
                if (p.Contains("Fill"))
                {
                    rec.Fill = p.Replace("Fill:", "");
                }
                else if (p.Contains("Height"))
                {
                    rec.Height = Convert.ToInt32(p.Replace("Height:", ""));
                }
                else if (p.Contains("Width"))
                {
                    rec.Width = Convert.ToInt32(p.Replace("Width:", ""));
                }

                else if (p.Contains("Outline"))
                {
                    rec.Outline = (p.Replace("Outline:", ""));
                }
                else if (p.Contains("Thickness"))
                {
                    rec.Thickness = Convert.ToDouble(p.Replace("Thickness:", ""));
                }
            }

            return rec;

        }

        public Rectangle area(string Shdesc, out double fillarea, out double outlinearea)
        {
            Rectangle rec = loadrectanglelocal(Shdesc);
            fillarea = rec.Height * rec.Width;
            outlinearea = 2 * (rec.Height + rec.Width) * rec.Thickness;
            return rec;
        }

    }
}


