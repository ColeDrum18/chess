using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    abstract class Piece
    {
        // team 1 = white, team 2 = black
        public abstract string[] movement();
        public abstract string findControl(Control[] controls);
    }
}
