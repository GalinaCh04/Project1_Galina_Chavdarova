using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace zad2_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyle();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Format());
        }
    }
}
