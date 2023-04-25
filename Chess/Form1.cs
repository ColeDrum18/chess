using Chess.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            Char[] aToH = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            if (aToH.Contains(txtMove.Text[0]))
            {

                string[] potential = Pawn.movement(txtMove.Text);
                Control[] spots = new Control[potential.Length];
                for (int i = 0; i < potential.Length; i++)
                {
                    var tmp = this.Controls.Find(potential[i], true);
                    if (tmp.Length != 0)
                    {
                        spots[i] = tmp[0];
                    }
                    else
                    {
                        spots[i] = null;
                    }
                }

                var moveTo = this.Controls.Find(txtMove.Text, true);
                string pawn = Pawn.findControl(spots, moveTo[0]);
                if (pawn != "")
                {
                    var moveFrom = this.Controls.Find(pawn, true);
                    if (Game.turn % 2 == 1)
                    {
                        moveTo[0].BackgroundImage = Resources.whitePawn;
                        moveTo[0].Tag = "white pawn";
                    }
                    else
                    {
                        moveTo[0].BackgroundImage = Resources.blackPawn;
                        moveTo[0].Tag = "black pawn";
                    }
                    moveFrom[0].BackgroundImage = null;
                    moveFrom[0].Tag = null;
                    Game.turn++;
                }

            }
            else if (txtMove.Text[0] == 'K' && aToH.Contains(txtMove.Text[1]))
            {
                string space = txtMove.Text[1] + txtMove.Text[2].ToString();
                string[] potential = Knight.movement(space);
                Control[] spots = new Control[potential.Length];
                for (int i = 0; i < potential.Length; i++)
                {
                    var tmp = this.Controls.Find(potential[i], true);
                    if (tmp.Length != 0)
                    {
                        spots[i] = tmp[0];
                    }
                    else
                    {
                        spots[i] = null;
                    }
                }

                var moveTo = this.Controls.Find(space, true);
                string knight = Knight.findControl(spots, moveTo[0]);
                if (knight != "")
                {
                    var moveFrom = this.Controls.Find(knight, true);
                    if (Game.turn % 2 == 1)
                    {
                        moveTo[0].BackgroundImage = Resources.whiteKnight;
                        moveTo[0].Tag = "white knight";
                    }
                    else
                    {
                        moveTo[0].BackgroundImage = Resources.blackKnight;
                        moveTo[0].Tag = "black knight";
                    }
                    moveFrom[0].BackgroundImage = null;
                    moveFrom[0].Tag = null;
                    Game.turn++;
                }
            }
            else if (txtMove.Text[0] == 'B' && aToH.Contains(txtMove.Text[1]))
            {
                Console.WriteLine("Bishop");
                string space = txtMove.Text[1] + txtMove.Text[2].ToString();
                string[] potential = Bishop.movement(space);
                Control[] spots = new Control[potential.Length];
                for (int i = 0; i < potential.Length; i++)
                {
                    var tmp = this.Controls.Find(potential[i], true);
                    if (tmp.Length != 0)
                    {
                        spots[i] = tmp[0];
                    }
                    else
                    {
                        spots[i] = null;
                    }
                }

                var moveToB = this.Controls.Find(space, true);
                string bishop = Bishop.findControl(spots, moveToB[0]);
                if (bishop != "")
                {
                    var moveFrom = this.Controls.Find(bishop, true);
                    if (Game.turn % 2 == 1)
                    {
                        moveToB[0].BackgroundImage = Resources.whiteBishop;
                        moveToB[0].Tag = "white bishop";
                    }
                    else
                    {
                        moveToB[0].BackgroundImage = Resources.blackBishop;
                        moveToB[0].Tag = "black bishop";
                    }
                    moveFrom[0].BackgroundImage = null;
                    moveFrom[0].Tag = null;
                    Game.turn++;
                }
            }
            }
        }
            

    }

