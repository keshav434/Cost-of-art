using System;
using System.IO;
using System.Reflection;

//static
namespace The_Cost_of_Art
{
    class Program
    {
        static string shapetype;
        static void Main(string[] args)
        {
            ClsShape sh;
        start:
            int menuoption = printmainmenu();
            if (menuoption == 3)
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
                return;
            }
            else if (menuoption == 1)
            {
            startpainting:
                Painting pnt = new Painting();
                Console.WriteLine("Please enter the title of your painting.");
                pnt.Title = Console.ReadLine().Trim();
                if (pnt.Title.Length < 4)
                {
                    Console.WriteLine(pnt.Title + " is not a valid title. A title must be at least 4 characters long after leading and trailing whitespace is removed.");
                    goto startpainting;
                }
                bool add = true;
                while (add)
                {
                    int shapemenuoption = printshapemenu(pnt.Title);
                    if (shapemenuoption == 5)
                    {
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        return;
                    }

                    sh = retObj(shapemenuoption);
                    ClsShape shape = sh.creatshape();
                    if (shape != null)
                    {
                        pnt.shapes.Add(shape);
                    }
                    Console.WriteLine("do you want to add more shape,press y or Y to add or n or N to save paining.");
                    string ans = Console.ReadLine();
                    if (ans == "n" || ans == "N")
                    {
                        add = false;
                    }
                }
                if (pnt.savepainting(pnt.Title))
                {
                    Console.WriteLine("Painting is saved sucessfully");
                    goto start;
                }
            }
            else if (menuoption == 2)
            {
            edit:
                Painting pnt = new Painting();
                string selectedpaintingpath = pnt.getpainings();

                if (selectedpaintingpath != string.Empty)
                {
                    pnt = pnt.loadpaining(selectedpaintingpath);
                    int shapeeditmenuoption = printpaintingeditmenu();
                    if (shapeeditmenuoption == 1)
                    {
                        //add a shape
                        bool addshape = true;
                        while (addshape)
                        {
                            int shapemenuoption = printshapemenu(pnt.Title);
                            sh = retObj(shapemenuoption);
                            pnt.shapes.Add(sh.creatshape());
                            Console.WriteLine("do you want to add more shape,press y or Y to add or n or N to save paining.");
                            string ansadd = Console.ReadLine();
                            if (ansadd == "n" || ansadd == "N")
                            {
                                addshape = false;
                            }
                        }
                        if (pnt.appendpainings(pnt))
                        {
                            Console.WriteLine("Painting is updated sucessfully");
                        }

                    }
                    else if (shapeeditmenuoption == 2)
                    {
                        //edit a shape
                        string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Assembly.GetExecutingAssembly().ToString()).ToString()).ToString()).ToString()) + @"\Paintings\" + pnt.Title + ".pnt";
                        Console.WriteLine("Select shape to edit");
                        pnt.printeditpainings(pnt);
                        int shapecount = Convert.ToInt32(Console.ReadLine());
                        string newshapeline = string.Empty;
                        if (pnt.shapes[shapecount].Shdesc.Contains("Square"))
                        {
                            newshapeline = Square.printpaintingeditactionmenu(pnt.shapes[shapecount].Shdesc);
                            pnt.shapes[shapecount].Shdesc = newshapeline;
                        }
                        else if (pnt.shapes[shapecount].Shdesc.Contains("Rectangle"))
                        {
                            newshapeline = Rectangle.printpaintingeditactionmenu(pnt.shapes[shapecount].Shdesc);
                            pnt.shapes[shapecount].Shdesc = newshapeline;
                        }
                        else if (pnt.shapes[shapecount].Shdesc.Contains("Triangle"))
                        {
                            newshapeline = Triangle.printpaintingeditactionmenu(pnt.shapes[shapecount].Shdesc);
                            pnt.shapes[shapecount].Shdesc = newshapeline;
                        }
                        else if (pnt.shapes[shapecount].Shdesc.Contains("Circle"))
                        {
                            newshapeline = Circle.printpaintingeditactionmenu(pnt.shapes[shapecount].Shdesc);
                            pnt.shapes[shapecount].Shdesc = newshapeline;
                        }

                        pnt.savepainting(pnt.Title);

                        Console.WriteLine("Painting is updated sucessfully");

                    }




                    else if (shapeeditmenuoption == 3)
                    {
                        //remove a shape
                        string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Assembly.GetExecutingAssembly().ToString()).ToString()).ToString()).ToString()) + @"\Paintings\" + pnt.Title + ".pnt";
                        Console.WriteLine("Select shape to remove");
                        pnt.printeditpainings(pnt);
                        int shapecount = Convert.ToInt32(Console.ReadLine());
                        pnt.shapes.RemoveAt(shapecount);
                        pnt.savepainting(pnt.Title);

                        Console.WriteLine("Painting is updated sucessfully");

                    }
                    else if (shapeeditmenuoption == 4)
                    {
                        getpaintshop(pnt);
                    }
                    else if (shapeeditmenuoption == 5)
                    {
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        return;
                    }
                    Console.WriteLine("Would you like to continue editing? Please answer y or Y for Yes, or N or n for No.");
                    string ans = Console.ReadLine();
                    if (ans.ToUpper() == "Y")
                    {
                        goto edit;
                    }
                    else
                    {
                        Console.WriteLine("Below are available paint shops to get quote:");
                        getpaintshop(pnt);

                    }
                }
                else
                {
                    goto start;
                }
            }

        }

        public static int printmainmenu()
        {
        mainmenu:
            Console.WriteLine("Please select an action.\n1. Create new painting.\n2. Load painting from file.\n3. Exit program.\n\nPlease enter a value from 1 to 3 inclusive.");
            //Console.WriteLine("Please select an action");
            //Console.WriteLine("1. Create new painting.");
            //Console.WriteLine("2. Load painting from file.");
            //Console.WriteLine("3. Exit program.");
            //Console.WriteLine("\nPlease enter a value from 1 to 3 inclusive.");
            int menuoption = Convert.ToInt32(Console.ReadLine());

            if (menuoption < 1 || menuoption > 3)
            {
                Console.WriteLine(menuoption + " is not a value from 1 to 3 inclusive.");
                goto mainmenu;

            }
            return menuoption;
        }
        public static int printshapemenu(string title)
        {
        shapemenu:
            Console.WriteLine("Please select shape to add to " + title + ".\n1. Square.\n2. Rectangle.\n3. Circle.\n4. Triangle.\n5. Exit program.\n\nPlease enter a value from 1 to 5 inclusive.");

            //Console.WriteLine("Please select shape to add to " + title + ".");
            //Console.WriteLine("1. Square");
            //Console.WriteLine("2. Rectangle");
            //Console.WriteLine("3. Circle");
            //Console.WriteLine("4. Triangle");
            //Console.WriteLine("5. Exit program");
            //Console.WriteLine("\nPlease entrer a value from 1 to 5 inclusive");
            int menuoption = Convert.ToInt32(Console.ReadLine());

            if (menuoption < 1 || menuoption > 5)
            {
                Console.WriteLine(menuoption + " is not a value from 1 to 3 inclusive.");
                goto shapemenu;

            }
            return menuoption;
        }

        public static int printpaintingeditmenu()
        {
        paintingeditmenu:
            Console.WriteLine("Please select an action");
            Console.WriteLine("1. add a shape.");
            Console.WriteLine("2. Edit existing shape.");
            Console.WriteLine("3. remove existing shape.");
            Console.WriteLine("4. Stop editing shape.");
            Console.WriteLine("5. Exit program.");
            Console.WriteLine("Please enter a value from 1 to 5 inclusive.");
            int menuoption = Convert.ToInt32(Console.ReadLine());

            if (menuoption < 1 || menuoption > 5)
            {
                Console.WriteLine(menuoption + " is not a value from 1 to 5 inclusive.");
                goto paintingeditmenu;

            }
            return menuoption;
        }

        public static ClsShape retObj(int shape)
        {
            if (shape == 1)
            {
                shapetype = "Square";
                return new Square();
            }
            else if (shape == 2)
            {
                shapetype = "Rectangle";
                return new Rectangle();
            }
            else if (shape == 3)
            {
                shapetype = "Circle";
                return new Circle();
            }
            else if (shape == 4)
            {
                shapetype = "Triangle";
                return new Triangle();
            }

            else { return null; }

        }

        public static void getpaintshop(Painting pnt)
        {
            paintloader pl = new paintloader();
            string selectedshop = pl.getpaintshops("*");
            paintshop ps = pl.loadshop(selectedshop);

            if (selectedshop == string.Empty)
            {
                Console.WriteLine("Incorrect paint shop, please try again.");
                getpaintshop(pnt);
            }
            else
            {
                // is supply available
                if (pl.issupplyavailable(ps, pnt))
                {
                    //get quote

                    pl.getquote(ps, pnt);
                }
                else
                {
                    Console.Write("Supply not available, please selected different shop");
                    getpaintshop(pnt);
                }
            }
        }

    }
}