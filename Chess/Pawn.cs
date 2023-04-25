using Chess.Properties;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    internal class Pawn
    {

        
        public static string[] movement(string moveTo) 
        {
            char file = moveTo[0];
            char lfile = (char)(file - 1);
            if (file == 'a')
                lfile = 'a';
            char rfile = (char)(file + 1);
            if (file == 'h')
                rfile = 'h';
            int num = int.Parse(moveTo[1].ToString());
            if (Game.turn % 2 == 1)
            {
                
                if (num == 4)
                {
                    string[] from = { file + (num - 1).ToString(), file + (num - 2).ToString(), lfile + (num - 1).ToString(), rfile + (num - 1).ToString() };
                    return from;
                }
                else
                {
                    string[] from = { file + (num - 1).ToString(), lfile + (num - 1).ToString(), rfile + (num - 1).ToString() };
                    return from;
                }
            }
            else
            {
                if (num == 5)
                {
                    string[] from = { file + (num + 1).ToString(), file + (num + 2).ToString(), lfile + (num + 1).ToString(), rfile + (num + 1).ToString() };
                    return from;
                }
                else
                {
                    string[] from = { file + (num + 1).ToString(), lfile + (num + 1).ToString(), rfile + (num + 1).ToString() };
                    return from;
                }
            }
            
        }

        public static string findControl(Control[] controls, Control moveTo)
        {
            string pawn = "";
            string tag = (string)moveTo.Tag;
            int x = controls.Length;
            string color;
            if(Game.turn%2 == 1)
            {
                color = "white";
            }
            else
            {
                color = "black";
            }
            for(int i = 0; i < controls.Length; i++)
            {
                if (controls[i] != null && (string)controls[i].Tag ==  (color+" pawn"))
                {
                    if(i >= x-2)
                    {
                        if(moveTo.BackgroundImage == null)
                        {
                            pawn = "";
                        }
                        else if(!tag.Contains(color))
                        {
                            pawn = controls[i].Name;
                            break;
                        }
                        else
                        {
                            pawn = "";
                        }
                    }
                    else if(moveTo.BackgroundImage == null)
                    {
                        pawn = controls[i].Name;
                        break;
                    }
                    else
                    {
                        pawn = "";
                    }
                }
                else if (controls[i] != null)
                {
                    if (controls[i].BackgroundImage != null && i == 0)
                    {
                        break;
                    }
                }
            }
            return pawn;
        }
    }
}
