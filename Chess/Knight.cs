﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Chess
{
    internal class Knight : Piece
    {
        private string moveTo;
        private Control moveToControl;

        public Knight(string moveTo, Control moveToControl)
        {
            this.moveTo = moveTo;
            this.moveToControl = moveToControl;
        }
        public override string[] movement()
        {
            Char[] aToH = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            char file = moveTo[0];
            char lfile = (char)(file - 1);
            char l2file = (char)(file - 2);
            char rfile = (char)(file + 1);
            char r2file = (char)(file + 2);
            int row = int.Parse(moveTo[1].ToString());
            int uprow = row + 1;
            int up2row = row + 2;
            int downrow = row - 1;
            int down2row = row - 2;
            

            
            string[] from = {lfile + up2row.ToString(), lfile + down2row.ToString(), 
            rfile+up2row.ToString(), rfile + down2row.ToString(), l2file + uprow.ToString(),
            l2file+downrow.ToString(), r2file+uprow.ToString(), r2file+downrow.ToString()};

            return from;
        }

        public string[] movement(char fromFile)
        {
            int row = int.Parse(moveTo[1].ToString());
            string[] from = { fromFile + (row+1).ToString(), fromFile + (row+1).ToString(), fromFile + (row+2).ToString(), fromFile + (row-2).ToString()};
            return from;
        }

        public override string findControl(Control[] controls)
        {
            string knight = "";
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
                if (controls[i] != null && (string)controls[i].Tag == (color + " knight"))
                {
                    if (tag == null)
                    {
                        knight = controls[i].Name;
                        break;
                    }
                    else if (!tag.Contains(color))
                    {
                        knight = controls[i].Name;
                        break;
                    }
                    else
                    {
                        knight = "";
                    }
                }
            }
            return knight;
        }
    }
}
