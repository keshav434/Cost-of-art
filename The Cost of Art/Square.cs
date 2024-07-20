using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Cost_of_Art
{
    class Square : ClsShape
    {
        int height;

        public int Height
        {
            get => height;
            set => height = value;
        }

        public override ClsShape creatshape()
        {
            printSquare();
            if (validate(this))
            {
                Shdesc = (string.Concat(this.GetType().Name, "{Fill:", Fill, ",Height:", Height, ",Outline:", Outline, ",Thickness:", Thickness, "}"));
                return this;
            }
            else
            {
                Console.WriteLine("invalid Square parameters");
                return null;
            }
        }
        public ClsShape loadsquare(string Shdesc)
        {
            Square sq = new Square();
            sq.Shdesc = Shdesc;
            Shdesc = Shdesc.Substring(7, Shdesc.Length - 8);
            string[] prop = Shdesc.Split(",");
            foreach (string p in prop)
            {
                if (p.Contains("Fill"))
                {
                    sq.Fill = p.Replace("Fill:", "");
                }
                else if (p.Contains("Height"))
                {
                    sq.Height = Convert.ToInt32(p.Replace("Height:", ""));
                }
                else if (p.Contains("Outline"))
                {
                    sq.Outline = (p.Replace("Outline:", ""));
                }
                else if (p.Contains("Thickness"))
                {
                    sq.Thickness = Convert.ToDouble(p.Replace("Thickness:", ""));
                }
            }

            return sq;

        }


        public static string printpaintingeditactionmenu(string item)
        {
            item = item.Replace("Square{", "");
            item = item.Replace("}", "");
        paintingeditactionmenu:
            Console.WriteLine("Please select an action");
            Console.WriteLine("1. change height.");
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
                Console.WriteLine("enter new height:");
                int newheight = Convert.ToInt32(Console.ReadLine());

                temp[1] = "Height:" + newheight;

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
            string retstring = "Square{";
            foreach (string s in temp)
            {
                retstring = retstring + s + ",";

            }

            return (retstring.Substring(0, retstring.Length - 1) + "}");
        }

        private void printSquare()
        {
            Console.WriteLine("Please enter the square's height.\nPlease enter a value from 5 to 50 inclusive.");
            Height = Convert.ToInt32(Console.ReadLine());
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
            Console.WriteLine("Please enter the outline thickness.\nPlease enter a value from 0.1 to 5 inclusive.");
            Thickness = Convert.ToDouble(Console.ReadLine());
        }


        public bool validate(Square sq)
        {

            if ((sq.height >= 5 && sq.height <= 50) && (sq.Thickness >= 0.1 && sq.Thickness <= 5) && (Enum.IsDefined(typeof(Colors), sq.Outline)) && (Enum.IsDefined(typeof(Colors), sq.Fill)))
            {
                return true;
            }
            return false;
        }

        public Square loadsquarelocal(string Shdesc)
        {
            Square sq = new Square();
            sq.Shdesc = Shdesc;
            Shdesc = Shdesc.Substring(7, Shdesc.Length - 8);
            string[] prop = Shdesc.Split(",");
            foreach (string p in prop)
            {
                if (p.Contains("Fill"))
                {
                    sq.Fill = p.Replace("Fill:", "");
                }
                else if (p.Contains("Height"))
                {
                    sq.Height = Convert.ToInt32(p.Replace("Height:", ""));
                }
                else if (p.Contains("Outline"))
                {
                    sq.Outline = (p.Replace("Outline:", ""));
                }
                else if (p.Contains("Thickness"))
                {
                    sq.Thickness = Convert.ToDouble(p.Replace("Thickness:", ""));
                }
            }

            return sq;

        }

        public Square area(string Shdesc, out double fillarea, out double outlinearea)
        {
            Square sq = loadsquarelocal(Shdesc);
            fillarea = sq.Height * sq.Height;
            outlinearea = 4 * sq.Height * sq.Thickness;
            return sq;
        }

    }
}