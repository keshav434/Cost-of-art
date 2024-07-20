using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace The_Cost_of_Art
{
    public enum Colors
    {
        Black, Blue, Green, Indigo, Orange, Red, Violet, Yellow, White
    };
    class Painting
    {
        private string title;

        public string Title
        {
            get => title;
            set => title = value;
        }

        public List<ClsShape> shapes = new List<ClsShape>();

        public bool savepainting(string paintingtitle)
        {
            string fileName = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Assembly.GetExecutingAssembly().ToString()).ToString()).ToString()).ToString()) + @"\Paintings\" + Title + ".pnt";
            // Check if file already exists. If yes, delete it.    
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // Create a new file    
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine("Title: " + Title);
                foreach (ClsShape sh in shapes)
                {
                    sw.WriteLine(sh.Shdesc);
                }

            }
            return true;
        }

        public string getpainings()
        {
            string paintingpath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Assembly.GetExecutingAssembly().ToString()).ToString()).ToString()).ToString()) + @"\Paintings\";
            string[] paintings = Directory.GetFiles(paintingpath, "*.pnt");

            Console.WriteLine("Please select a file");
            int i = 1;
            foreach (string item in paintings)
            {
                Console.WriteLine(i.ToString() + ". " + item);
                i++;
            }

            int selectedpainting = Convert.ToInt32(Console.ReadLine());
            string valresult = validatepainting(paintings[selectedpainting - 1]);
            if (valresult == string.Empty)
            {
                Console.WriteLine("Painting is not valid\n");
                return (string.Empty);

            }

            return paintings[selectedpainting - 1];

        }

        private string validatepainting(string paintingpath)
        {
            Painting pn = new Painting();
            string[] lines = System.IO.File.ReadAllLines(paintingpath);
            int i = 0;
            foreach (string item in lines)
            {
                if (i == 0)
                {
                    pn.title = item;
                }
                else
                {
                    //validate shapes
                    if (item.StartsWith("Square"))
                    {
                        Square sq = new Square();
                        sq = sq.loadsquarelocal(item);
                        if (sq.validate(sq) == false)
                        {
                            Console.WriteLine(@"Paintins\" + pn.title + " is in incorrect format.");
                            return string.Empty;
                        }
                    }
                    else if (item.StartsWith("Rectangle"))
                    {
                        Rectangle rec = new Rectangle();
                        rec = rec.loadrectanglelocal(item);
                        if (rec.validate(rec) == false)
                        {
                            Console.WriteLine(@"Paintins\" + pn.title + " is in incorrect format.");
                            return string.Empty;
                        }
                    }
                    else if (item.StartsWith("Triangle"))
                    {
                        Triangle tri = new Triangle();
                        tri = tri.loadtrianglelocal(item);
                        if (tri.validate(tri) == false)
                        {
                            Console.WriteLine(@"Paintins\" + pn.title + " is in incorrect format.");
                            return string.Empty;
                        }
                    }
                    else if (item.StartsWith("Circle"))
                    {
                        Circle cir = new Circle();
                        cir = cir.loadcirclelocal(item);
                        if (cir.validate(cir) == false)
                        {
                            Console.WriteLine(@"Paintins\" + pn.title + " is in incorrect format.");
                            return string.Empty;
                        }
                    }
                    else
                    { return string.Empty; }
                }
                i++;
            }
            return pn.title;
        }

        public bool appendpainings(Painting pnt)
        {
            pnt.savepainting(pnt.Title);

            return true;
        }

        public bool printeditpainings(Painting pt)
        {

            int i = 0;

            foreach (ClsShape item in pt.shapes)
            {

                if (item.Shdesc.Contains("Square"))
                {
                    Square sq = new Square();
                    sq = sq.loadsquarelocal(item.Shdesc);
                    Console.WriteLine(i.ToString() + "." + sq.Fill + " Square with a height of " + sq.Height + "cm and a" + sq.Thickness + "cm thick" + sq.Outline + " outline");
                }
                else if (item.Shdesc.Contains("Rectangle"))
                {
                    Rectangle rec = new Rectangle();
                    rec = rec.loadrectanglelocal(item.Shdesc);
                    Console.WriteLine(i.ToString() + "." + rec.Fill + " Rectangle with a height of " + rec.Height + "cm and " + " a widht of " + rec.Width + "cm and a" + rec.Thickness + "cm thick" + rec.Outline + " outline");
                }
                else if (item.Shdesc.Contains("Circle"))
                {
                    Circle cir = new Circle();
                    cir = cir.loadcirclelocal(item.Shdesc);
                    Console.WriteLine(i.ToString() + "." + cir.Fill + " Circle with a radius of " + cir.Radius + "cm and a" + cir.Thickness + "cm thick" + cir.Outline + " outline");
                }
                else if (item.Shdesc.Contains("Triangle"))
                {
                    Triangle tri = new Triangle();
                    tri = tri.loadtrianglelocal(item.Shdesc);
                    Console.WriteLine(i.ToString() + "." + tri.Fill + " Triangle with a side of " + tri.Side + "cm and a" + tri.Thickness + "cm thick" + tri.Outline + " outline");
                }


                i++;
            }



            return true;
        }

        public Painting loadpaining(string paintingpath)
        {
            Painting pt = new Painting();
            string[] lines = System.IO.File.ReadAllLines(paintingpath);

            pt.title = lines[0].Replace("Title:", "").Trim();
            foreach (string item in lines)
            {

                if (item.StartsWith("Square"))
                {
                    Square sq = new Square();
                    pt.shapes.Add(sq.loadsquare(item));
                }
                else if (item.StartsWith("Rectangle"))
                {
                    Rectangle rec = new Rectangle();
                    pt.shapes.Add(rec.loadrectangle(item));
                }      // todo for other shapes
                else if  (item.StartsWith("Circle"))
                {
                    Circle cir = new Circle();
                    pt.shapes.Add(cir.loadcircle(item));
                }      // todo for other shapes
                else if (item.StartsWith("Triangle"))
                {
                    Triangle tri = new Triangle();
                    pt.shapes.Add(tri.loadtriangle(item));
                }      // todo for other shapes

            }

            return pt;
        }
    }

}