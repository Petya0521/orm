using FruitsOrm10.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruitsOrm10
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( "1 for console, 2for worm");
            string start = Console.ReadLine();
            if (start == "2")
            {
                Form1 form = new Form1();
                Application.Run(form);
            }
            else
            {
                Display d = new Display();
                d.ShowMenu();
            }
        }
    }
}
