using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    internal class Rook : Piece
    {
        private string moveTo;
        private Control moveToControl;
        private char fromFile = 'z';

        public Rook(string moveTo, Control moveToControl)
        {
            this.moveTo = moveTo;
            this.moveToControl = moveToControl;
        }

        public Rook(string moveTo, Control moveToControl, char fromFile)
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
            string[] from = {file+(row+1).ToString(), file + (row + 2).ToString(), file + (row + 3).ToString(), file + (row + 4).ToString(), file + (row + 5).ToString(), file + (row + 6).ToString(), file + (row + 7).ToString(),
                             file+(row-1).ToString(), file + (row - 2).ToString(), file + (row - 3).ToString(), file + (row - 4).ToString(), file + (row - 5).ToString(), file + (row - 6).ToString(), file + (row - 7).ToString(),
                             (char)(file+1)+row.ToString(), (char)(file+2)+row.ToString(), (char)(file+3)+row.ToString(), (char)(file+4)+row.ToString(), (char)(file+5)+row.ToString(), (char)(file+6)+row.ToString(), (char)(file+7)+row.ToString(),
                             (char)(file-1)+row.ToString(), (char)(file-2)+row.ToString(), (char)(file-3)+row.ToString(), (char)(file-4)+row.ToString(), (char)(file-5)+row.ToString(), (char)(file-6)+row.ToString(), (char)(file-7)+row.ToString(), };
            
            return from;
        }

        

        public override string findControl(Control[] controls)
        {
            string rook = "";
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
                if (controls[i] != null && (string)controls[i].Tag == (color + " rook"))
                {
                    Console.WriteLine(controls[i].Name);
                    if(fromFile == 'z')
                    {
                        if (tag == null)
                        {
                            rook = controls[i].Name;
                            index = i;
                        }
                        else if (!tag.Contains(color))
                        {
                            rook = controls[i].Name;
                            index = i;
                        }
                        else
                        {
                            rook = "";
                        }
                    }
                    else if (controls[i].Name[0] == fromFile)
                    {
                        if (tag == null)
                        {
                            rook = controls[i].Name;
                            index = i;
                        }
                        else if (!tag.Contains(color))
                        {
                            rook = controls[i].Name;
                            index = i;
                        }
                        else
                        {
                            rook = "";
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
            else
                start = 21;
            for (int i = start; i < index; i++)
            {
                if (controls[i] != null)
                {
                    if (controls[i].BackgroundImage != null)
                    {
                        rook = "";
                        break;
                    }
                }
            }
            return rook;
        }
    }
}
