using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Cost_of_Art
{
    abstract class ClsShape
    {

        string fill;
        string outline;
        double thickness;
        string shdesc;

        public double Thickness
        {
            get => thickness;
            set => thickness = value;
        }

        public string Outline
        {
            get => outline;
            set => outline = value;
        }

        public string Fill
        {
            get => fill;
            set => fill = value;
        }
        public string Shdesc { get => shdesc; set => shdesc = value; }

        public abstract ClsShape creatshape();

        public static void printcolor()
        {
            Console.WriteLine("1. Black\n2. Blue\n3. Green\n4. Indigo\n5. Orange\n6. Red\n7. Violet\n8. Yellow\n9. White\n\nPlease enter a value from 1 to 9 inclusive.");

        }
    }
}