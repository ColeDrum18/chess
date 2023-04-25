using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    internal class Bishop
    {
        public static string[] movement(string moveTo)
        {
            Char[] aToH = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            char file = moveTo[0];
            int row = int.Parse(moveTo[1].ToString());
            string[] from = { (char)(file+1) + (row+1).ToString(), (char)(file + 2) + (row + 2).ToString(), (char)(file + 3) + (row + 3).ToString(), (char)(file + 4) + (row + 4).ToString(), (char)(file + 5) + (row + 5).ToString(), (char)(file + 6) + (row + 6).ToString(), (char)(file + 7) + (row + 7).ToString(),
                               (char)(file - 1) + (row+1).ToString(), (char)(file - 2) + (row + 2).ToString(), (char)(file - 3) + (row + 3).ToString(), (char)(file - 4) + (row + 4).ToString(), (char)(file - 5) + (row + 5).ToString(), (char)(file - 6) + (row + 6).ToString(), (char)(file - 7) + (row + 7).ToString(),
                               (char)(file+1) + (row-1).ToString(), (char)(file + 2) + (row - 2).ToString(), (char)(file + 3) + (row - 3).ToString(), (char)(file + 4) + (row - 4).ToString(), (char)(file + 5) + (row - 5).ToString(), (char)(file + 6) + (row - 6).ToString(), (char)(file + 7) + (row - 7).ToString(),
                               (char)(file-1) + (row-1).ToString(), (char)(file - 2) + (row - 2).ToString(), (char)(file - 3) + (row - 3).ToString(), (char)(file - 4) + (row - 4).ToString(), (char)(file - 5) + (row - 5).ToString(), (char)(file - 6) + (row - 6).ToString(), (char)(file - 7) + (row - 7).ToString(),};
            //for(int i = 0; i < from.Length; i++)
            //{
              //  Console.WriteLine(from[i]);
                //if (!aToH.Contains(from[i][0]))
                //{
                 //   from[i] = "";
                //}
                
            //}

            return from;
        }

        public static string findControl(Control[] controls, Control moveTo)
        {
            string bishop = "";
            string tag = (string)moveTo.Tag;
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
                if (controls[i] != null && (string)controls[i].Tag == (color + " bishop"))
                {
                    if (tag == null)
                    {
                        bishop = controls[i].Name;
                        index = i;
                        break;
                    }
                    else if (!tag.Contains(color))
                    {
                        bishop = controls[i].Name;
                        index = i;
                        break;
                    }
                    else
                    {
                        bishop = "";
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
            for(int i = start; i < index; i++)
            {
                if (controls[i] != null)
                {
                    if (controls[i].BackgroundImage != null)
                    {
                        bishop = "";
                        break;
                    }
                }
            }
            return bishop;
        }
    }
}
