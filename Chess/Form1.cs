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
            bool gameWon = false;
            Char[] aToH = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            if (txtMove.Text != "")
            {
                if (aToH.Contains(txtMove.Text[0]))
                {
                    string space = txtMove.Text;
                    var moveTo = this.Controls.Find(txtMove.Text, true);
                    Pawn P = new Pawn(space, moveTo[0]);
                    string[] potential = P.movement();
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


                    string pawn = P.findControl(spots);
                    if (pawn != "")
                    {
                        var moveFrom = this.Controls.Find(pawn, true);
                        if (Game.turn % 2 == 1)
                        {
                            if ((string)moveTo[0].Tag == "black king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.whitePawn;
                            moveTo[0].Tag = "white pawn";
                        }
                        else
                        {
                            if ((string)moveTo[0].Tag == "white king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.blackPawn;
                            moveTo[0].Tag = "black pawn";
                        }
                        moveFrom[0].BackgroundImage = null;
                        moveFrom[0].Tag = null;
                        Game.turn++;
                    }

                }
                else if (txtMove.Text[0] == 'N' && aToH.Contains(txtMove.Text[1]))
                {
                    string space;
                    if (txtMove.Text.Length == 3)
                        space = txtMove.Text[1] + txtMove.Text[2].ToString();
                    else
                        space = txtMove.Text[2] + txtMove.Text[3].ToString();
                    var moveTo = this.Controls.Find(space, true);
                    Knight N = new Knight(space, moveTo[0]);
                    string[] potential;
                    if (txtMove.Text.Length == 3)
                        potential = N.movement();
                    else
                        potential = N.movement(txtMove.Text[1]);
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


                    string knight = N.findControl(spots);
                    if (knight != "")
                    {
                        var moveFrom = this.Controls.Find(knight, true);
                        if (Game.turn % 2 == 1)
                        {
                            if ((string)moveTo[0].Tag == "black king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.whiteKnight;
                            moveTo[0].Tag = "white knight";
                        }
                        else
                        {
                            if ((string)moveTo[0].Tag == "white king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.blackKnight;
                            moveTo[0].Tag = "black knight";
                        }
                        moveFrom[0].BackgroundImage = null;
                        moveFrom[0].Tag = null;
                        Game.EP = false;
                        Game.turn++;
                    }
                }
                else if (txtMove.Text[0] == 'B' && aToH.Contains(txtMove.Text[1]))
                {
                    string space = txtMove.Text[1] + txtMove.Text[2].ToString();
                    var moveTo = this.Controls.Find(space, true);
                    Bishop B = new Bishop(space, moveTo[0]);
                    string[] potential = B.movement();
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


                    string bishop = B.findControl(spots);
                    if (bishop != "")
                    {
                        var moveFrom = this.Controls.Find(bishop, true);
                        if (Game.turn % 2 == 1)
                        {
                            if ((string)moveTo[0].Tag == "black king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.whiteBishop;
                            moveTo[0].Tag = "white bishop";
                        }
                        else
                        {
                            if ((string)moveTo[0].Tag == "white king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.blackBishop;
                            moveTo[0].Tag = "black bishop";
                        }
                        moveFrom[0].BackgroundImage = null;
                        moveFrom[0].Tag = null;
                        Game.turn++;
                    }
                }
                else if (txtMove.Text[0] == 'R' && aToH.Contains(txtMove.Text[1]))
                {
                    string space;
                    if (txtMove.Text.Length == 3)
                        space = txtMove.Text[1] + txtMove.Text[2].ToString();
                    else
                        space = txtMove.Text[2] + txtMove.Text[3].ToString();
                    Console.WriteLine(space);
                    var moveTo = this.Controls.Find(space, true);
                    Rook R;
                    if (txtMove.Text.Length == 3)
                        R = new Rook(space, moveTo[0]);
                    else
                        R = new Rook(space, moveTo[0], txtMove.Text[1]);
                    string[] potential = R.movement();
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


                    string rook = R.findControl(spots);
                    if (rook != "")
                    {
                        var moveFrom = this.Controls.Find(rook, true);
                        if (Game.turn % 2 == 1)
                        {
                            if ((string)moveTo[0].Tag == "black king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.whiteRook;
                            moveTo[0].Tag = "white rook";
                        }
                        else
                        {
                            if ((string)moveTo[0].Tag == "white king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.blackRook;
                            moveTo[0].Tag = "black rook";
                        }
                        moveFrom[0].BackgroundImage = null;
                        moveFrom[0].Tag = null;
                        Game.EP = false;
                        Game.turn++;
                    }
                }
                else if (txtMove.Text[0] == 'Q' && aToH.Contains(txtMove.Text[1]))
                {
                    string space;
                    if (txtMove.Text.Length == 3)
                        space = txtMove.Text[1] + txtMove.Text[2].ToString();
                    else
                        space = txtMove.Text[2] + txtMove.Text[3].ToString();
                    Console.WriteLine(space);
                    var moveTo = this.Controls.Find(space, true);
                    Queen Q;
                    if (txtMove.Text.Length == 3)
                        Q = new Queen(space, moveTo[0]);
                    else
                        Q = new Queen(space, moveTo[0], txtMove.Text[1]);
                    string[] potential = Q.movement();
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


                    string queen = Q.findControl(spots);
                    if (queen != "")
                    {
                        var moveFrom = this.Controls.Find(queen, true);
                        if (Game.turn % 2 == 1)
                        {
                            if ((string)moveTo[0].Tag == "black king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.whiteQueen;
                            moveTo[0].Tag = "white queen";
                        }
                        else
                        {
                            if ((string)moveTo[0].Tag == "white king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.blackQueen;
                            moveTo[0].Tag = "black queen";
                        }
                        moveFrom[0].BackgroundImage = null;
                        moveFrom[0].Tag = null;
                        Game.EP = false;
                        Game.turn++;
                    }
                }
                else if (txtMove.Text[0] == 'K' && aToH.Contains(txtMove.Text[1]))
                {
                    string space = txtMove.Text[1] + txtMove.Text[2].ToString();
                    var moveTo = this.Controls.Find(space, true);
                    King K = new King(space, moveTo[0]);
                    string[] potential = K.movement();
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


                    string king = K.findControl(spots);
                    if (king != "")
                    {
                        var moveFrom = this.Controls.Find(king, true);
                        if (Game.turn % 2 == 1)
                        {
                            if ((string)moveTo[0].Tag == "black king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.whiteKing;
                            moveTo[0].Tag = "white king";
                        }
                        else
                        {
                            if ((string)moveTo[0].Tag == "white king")
                            {
                                gameWon = true;
                            }
                            moveTo[0].BackgroundImage = Resources.blackKing;
                            moveTo[0].Tag = "black king";
                        }
                        moveFrom[0].BackgroundImage = null;
                        moveFrom[0].Tag = null;
                        Game.EP = false;
                        Game.turn++;
                    }
                }
                else if (txtMove.Text == "O-O-O")
                {
                    if (Game.LongCastle(a1, b1, c1, d1, e1))
                    {
                        a1.BackgroundImage = null;
                        a1.Tag = null;
                        e1.BackgroundImage = null;
                        e1.Tag = null;
                        c1.BackgroundImage = Resources.whiteKing;
                        c1.Tag = "white king";
                        d1.BackgroundImage = Resources.whiteRook;
                        d1.Tag = "white rook";
                        Game.EP = false;
                        Game.turn++;
                    }


                }
                else if (txtMove.Text == "O-O")
                {
                    Game.ShortCastle(h1, g1, f1, e1);


                }
                if (gameWon)
                {
                    if (Game.turn % 2 == 1)
                        txtMove.Text = "White wins";
                    else
                        txtMove.Text = "Black Wins";
                    txtMove.Enabled = false;
                }
                else
                {
                    txtMove.Text = "";
                    txtMove.Focus();
                }
            }
            
        }

        private void Enter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                btnMove_Click(sender, e);
        }

       
    }
          

}

