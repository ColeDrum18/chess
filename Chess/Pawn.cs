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
    internal class Pawn : Piece
    {
        private string moveTo;
        private Control moveToControl;
        public Pawn(string moveTo, Control moveToControl)
        {
            this.moveTo = moveTo;
            this.moveToControl = moveToControl;
        }
        public override string[] movement() 
        {
            char file = moveTo[0];
           
            int num = int.Parse(moveTo[1].ToString());
            if (Game.turn % 2 == 1)
            {
                
                if (num == 4)
                {
                    string[] from = { file + (num - 1).ToString(), file + (num - 2).ToString(), (char)(file -1) + (num - 1).ToString(), (char)(file+1) + (num - 1).ToString() };
                    return from;
                }
                else
                {
                    string[] from = { file + (num - 1).ToString(), (char)(file-1) + (num - 1).ToString(), (char)(file+1) + (num - 1).ToString() };
                    return from;
                }
            }
            else
            {
                if (num == 5)
                {
                    string[] from = { file + (num + 1).ToString(), file + (num + 2).ToString(), (char)(file-1) + (num + 1).ToString(), (char)(file+1) + (num + 1).ToString() };
                    return from;
                }
                else
                {
                    string[] from = { file + (num + 1).ToString(), (char)(file-1) + (num + 1).ToString(), (char)(file+1) + (num + 1).ToString() };
                    return from;
                }
            }
            
        }

        public override string findControl(Control[] controls)
        {
            string pawn = "";
            string tag = (string)moveToControl.Tag;
            int x = controls.Length;
            string color;
            string opponent;
            bool two = false;
            if(Game.turn%2 == 1)
            {
                color = "white";
                opponent = "black";
            }
            else
            {
                color = "black";
                opponent = "white";
            }
            for(int i = 0; i < controls.Length; i++)
            {
                if (controls[i] != null && (string)controls[i].Tag ==  (color+" pawn"))
                {
                    if(i >= x-2)
                    {
                        if (Game.EP && (string)controls[0].Tag == opponent+" pawn")
                        {
                            Game.EnPassant(controls[0], moveToControl, controls[i]);
                            Game.EP = false;
                            pawn = "";
                            break;
                        }
                        if(moveToControl.BackgroundImage == null)
                        {
                            pawn = "";
                        }
                        else if(!tag.Contains(color))
                        {
                            Game.EP = false;
                            pawn = controls[i].Name;
                            break;
                        }
                        else
                        {
                            pawn = "";
                        }
                    }
                    else if(moveToControl.BackgroundImage == null)
                    {
                        pawn = controls[i].Name;
                        if (i == 1)
                            two = true;
                        else
                            Game.EP = false;
                        break;
                    }
                    else
                    {
                        pawn = "";
                    }
                }
            }
            if(two)
            {
                if (controls[0].BackgroundImage != null)
                {
                    pawn = "";
                }
                else
                    Game.EP = true;
            }
            return pawn;
        }
    }
}
