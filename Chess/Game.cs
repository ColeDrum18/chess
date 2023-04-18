using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Game
    {
        public static int turn { get; set; } = 1;
        public static int player { get; set; } = 1;

        public static void Win(string color)
        {
            // win message
        }

        public static void Draw()
        {
            // draw message
        }
    }
}
