using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    internal class King : Piece
    {
        private string moveTo;
        private Control moveToControl;
        public King(string moveTo, Control moveToControl)
        {
            this.moveTo = moveTo;
            this.moveToControl = moveToControl;
        }
        public override string[] movement()
        {
            char file = moveTo[0];
            char lfile = (char)(file - 1);
            if (file == 'a')
                lfile = 'a';
            char rfile = (char)(file + 1);
            if (file == 'h')
                rfile = 'h';
            int row = int.Parse(moveTo[1].ToString());

            string[] from = { file + (row+1).ToString(), file + (row-1).ToString(), lfile + row.ToString(), lfile + (row+1).ToString(), lfile + (row-1).ToString(),
                              rfile + row.ToString(), rfile + (row+1).ToString(), rfile + (row-1).ToString()};

            return from;

        }

        public override string findControl(Control[] controls)
        {
            string king = "";
            string tag = (string)moveToControl.Tag;
            int x = controls.Length;
            string color;
            if (Game.turn % 2 == 1)
            {
                color = "white";
            }
            else
            {
                color = "black";
            }
            for (int i = 0; i < controls.Length; i++)
            {
                if (controls[i] != null && (string)controls[i].Tag == (color + " king"))
                {
                    if (tag == null)
                    {
                        king = controls[i].Name;
                        break;
                    }
                    else if (!tag.Contains(color))
                    {
                        king = controls[i].Name;
                        break;
                    }
                    else
                    {
                        king = "";
                    }
                }
            }
            return king;
        }
    
    }
}
