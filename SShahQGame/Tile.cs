using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SShahQGame
{
    public class Tile : PictureBox
    {
        private PlayGame play;
        private int rows, col;

        public int X_axis, Y_axis;
        public int TileTypeNumber;

        Tile(PlayGame play,int rows, int col)
        {
            this.rows = rows;
            this.col = col;
            this.play = play;
            
        }

       /* public void GeneratePictureBox(int itemNumber, int i, int j)
        {
            PictureBox tile = new PictureBox();

            tile.BorderStyle = BorderStyle.FixedSingle;

            tile.Width = 70;
            tile.Height = 70;
            tile.SizeMode = PictureBoxSizeMode.StretchImage;
            tile.Visible = true;
            // tile.BorderStyle = BorderStyle.Fixed3D;
            tile.Left += x;
            tile.Top += y;
            tile.Tag = itemNumber + "#" + i + "#" + j;
            //tile.Location = new Point(i,j);
            //gamePanel.Visible = true;
            gamePanel.Controls.Add(tile);



            switch (itemNumber)
            {
                case 0:
                    tile.Image = null;
                    break;
                case 1:
                    tile.Image = Properties.Resources.Wall;
                    break;
                case 2:
                    tile.Image = Properties.Resources.RedDoor;
                    break;
                case 3:
                    tile.Image = Properties.Resources.GreenDoor;

                    break;
                case 4:
                    tile.Image = Properties.Resources.RedBox;
                    NumberOfBoxes += 1;
                    break;
                case 5:
                    tile.Image = Properties.Resources.GreenBox;
                    NumberOfBoxes += 1;
                    break;
            }



            tile.Click += tile_Click;

        }

*/





    }
}
