using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoApp.Cui;
using BingoApp.Domein;

namespace BingoApp.StartUp
{
    public class Startup
    {
        public class StartUp
        {
            public static void Main(string[] args)
            {
                CuiBingoApp bingoApp = new ();
                bingoApp.Run();
            }
        }
    }
}