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
    internal class Game
    {
        public static int turn { get; set; } = 1;
        public static bool EP { get; set; } = false;

        public static bool LongCastle(Control a1,Control b1, Control c1, Control d1, Control e1)
        {
            string color;
            if (turn % 2 == 1)
                color = "white";
            else
                color = "black";
            if ((string)a1.Tag == color + " rook" && (string)e1.Tag == color + " king" && b1.BackgroundImage == null && c1.BackgroundImage == null && d1.BackgroundImage == null)
            {
                return true;
            }
            else
                return false;
        }

        public static void ShortCastle(Control h1, Control g1, Control f1, Control e1)
        {
            string color;
            if (turn % 2 == 1)
                color = "white";
            else
                color = "black";
            if ((string)h1.Tag == color + " rook" && (string)e1.Tag == color + " king" && f1.BackgroundImage == null && g1.BackgroundImage == null)
            {
                h1.BackgroundImage = null;
                h1.Tag = null;
                e1.BackgroundImage = null;
                e1.Tag = null;
                g1.BackgroundImage = Resources.whiteKing;
                g1.Tag = "white king";
                f1.BackgroundImage = Resources.whiteRook;
                f1.Tag = "white rook";
                EP = false;
                turn++;
            }
            
        }

        public static void EnPassant(Control take, Control moveTo, Control current)
        {
            string color;
            System.Drawing.Bitmap image;
            if(turn %2 == 1)
            {
                color = "white";
                image = Resources.whitePawn;
            }
            else
            {
                color = "black";
                image = Resources.blackPawn;
            }
            take.BackgroundImage = null;
            take.Tag = null;
            moveTo.BackgroundImage = image;
            moveTo.Tag = color + " pawn";
            current.BackgroundImage = null;
            current.Tag = null;

        }
    }
}
