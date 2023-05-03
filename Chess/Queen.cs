using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    internal class Queen : Piece
    {
        private string moveTo;
        private Control moveToControl;
        private char fromFile = 'z';

        public Queen(string moveTo, Control moveToControl)
        {
            this.moveTo = moveTo;
            this.moveToControl = moveToControl;
        }
        public Queen(string moveTo, Control moveToControl, char fromFile)
        {
            this.moveTo = moveTo;
            this.moveToControl = moveToControl;
            this.fromFile = fromFile;
        }

        public override string[] movement()
        {
            Char[] aToH = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            char file = moveTo[0];
            int row = int.Parse(moveTo[1].ToString());
            string[] from = { (char)(file+1) + (row+1).ToString(), (char)(file + 2) + (row + 2).ToString(), (char)(file + 3) + (row + 3).ToString(), (char)(file + 4) + (row + 4).ToString(), (char)(file + 5) + (row + 5).ToString(), (char)(file + 6) + (row + 6).ToString(), (char)(file + 7) + (row + 7).ToString(),
                               (char)(file - 1) + (row+1).ToString(), (char)(file - 2) + (row + 2).ToString(), (char)(file - 3) + (row + 3).ToString(), (char)(file - 4) + (row + 4).ToString(), (char)(file - 5) + (row + 5).ToString(), (char)(file - 6) + (row + 6).ToString(), (char)(file - 7) + (row + 7).ToString(),
                               (char)(file+1) + (row-1).ToString(), (char)(file + 2) + (row - 2).ToString(), (char)(file + 3) + (row - 3).ToString(), (char)(file + 4) + (row - 4).ToString(), (char)(file + 5) + (row - 5).ToString(), (char)(file + 6) + (row - 6).ToString(), (char)(file + 7) + (row - 7).ToString(),
                               (char)(file-1) + (row-1).ToString(), (char)(file - 2) + (row - 2).ToString(), (char)(file - 3) + (row - 3).ToString(), (char)(file - 4) + (row - 4).ToString(), (char)(file - 5) + (row - 5).ToString(), (char)(file - 6) + (row - 6).ToString(), (char)(file - 7) + (row - 7).ToString(),
                               file+(row+1).ToString(), file + (row + 2).ToString(), file + (row + 3).ToString(), file + (row + 4).ToString(), file + (row + 5).ToString(), file + (row + 6).ToString(), file + (row + 7).ToString(),
                             file+(row-1).ToString(), file + (row - 2).ToString(), file + (row - 3).ToString(), file + (row - 4).ToString(), file + (row - 5).ToString(), file + (row - 6).ToString(), file + (row - 7).ToString(),
                             (char)(file+1)+row.ToString(), (char)(file+2)+row.ToString(), (char)(file+3)+row.ToString(), (char)(file+4)+row.ToString(), (char)(file+5)+row.ToString(), (char)(file+6)+row.ToString(), (char)(file+7)+row.ToString(),
                             (char)(file-1)+row.ToString(), (char)(file-2)+row.ToString(), (char)(file-3)+row.ToString(), (char)(file-4)+row.ToString(), (char)(file-5)+row.ToString(), (char)(file-6)+row.ToString(), (char)(file-7)+row.ToString(),};

            return from;
        }

        public override string findControl(Control[] controls)
        {
            string queen = "";
            string tag = (string)moveToControl.Tag;
            int x = controls.Length;
            string color;
            int index = 0;
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
                if (controls[i] != null && (string)controls[i].Tag == (color + " queen"))
                {
                    if (fromFile == 'z')
                    {
                        if (tag == null)
                        {
                            queen = controls[i].Name;
                            index = i;
                        }
                        else if (!tag.Contains(color))
                        {
                            queen = controls[i].Name;
                            index = i;
                        }
                        else
                        {
                            queen = "";
                        }
                    }
                    else if (controls[i].Name[0] == fromFile)
                    {
                        if (tag == null)
                        {
                            queen = controls[i].Name;
                            index = i;
                        }
                        else if (!tag.Contains(color))
                        {
                            queen = controls[i].Name;
                            index = i;
                        }
                        else
                        {
                            queen = "";
                        }
                    }
                }
            }
            int start = 0;
            if (index < 7)
                start = 0;
            else if (index < 14)
                start = 7;
            else if (index < 21)
                start = 14;
            else if (index < 28)
                start = 21;
            else if (index < 35)
                start = 28;
            else if (index < 42)
                start = 35;
            else if (index < 49)
                start = 42;
            else
                start = 49;
            for (int i = start; i < index; i++)
            {
                if (controls[i] != null)
                {
                    if (controls[i].BackgroundImage != null)
                    {
                        queen = "";
                        break;
                    }
                }
            }
            return queen;
        }
    }
}
