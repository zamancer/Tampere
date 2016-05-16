using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tampere
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new PlaysTvArchiver().Run();

            new DesktopCleaner().Run();

            Console.Read();
        }
    }
}
