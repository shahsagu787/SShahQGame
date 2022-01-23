/*
 * Project : SShahQGame
 * Revesion History : Created By Sagar Shah on November 2021
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SShahQGame
{
    public partial class DesignForm : Form
    {
       
        int Rows = 0, Columns = 0;
        int x = 10, y = 10;
        int[,] board;
        Button selectedButton = new Button();
        bool isTileGenerated = false;
      
        


        public DesignForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            btnNone.Image = (Image) new Bitmap(Properties.Resources.None,new Size(60, 60));
            btnNone.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnWall.Image = (Image)new Bitmap(Properties.Resources.Wall, new Size(60, 60));
            btnWall.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnRedDoor.Image = (Image)new Bitmap(Properties.Resources.RedDoor, new Size(60, 60));
            btnRedDoor.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnGreenDoor.Image = (Image)new Bitmap(Properties.Resources.GreenDoor, new Size(60, 60));
            btnGreenDoor.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnRedBox.Image = (Image)new Bitmap(Properties.Resources.RedBox, new Size(60, 60));
            btnRedBox.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnGreenBox.Image = (Image)new Bitmap(Properties.Resources.GreenBox, new Size(60, 60));
            btnGreenBox.TextImageRelation = TextImageRelation.ImageBeforeText;
            
        }




        //Methods for menu
        #region Menu
        //To Exit from Drawing Window
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        //Method to save level design in txt file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int boxes = 0, doors = 0, walls = 0;
            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.DefaultExt = "txt";
            fileDialog.Title = "Save";
            fileDialog.FileName = "saveGame1";
            fileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream;
                StreamWriter sw;
                if ((stream = fileDialog.OpenFile()) != null)
                {
                    sw = new StreamWriter(stream);

                    sw.WriteLine(Rows);
                    sw.WriteLine(Columns);

                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {

                            sw.WriteLine(i);
                            sw.WriteLine(j);
                            sw.WriteLine(board[i, j]);

                            if (board[i, j] == 1)
                            {
                                walls += 1;
                            }
                            else if (board[i, j] == 2 || board[i, j] == 3)
                            {
                                doors += 1;
                            }
                            else if (board[i, j] == 4 || board[i, j] == 5)
                            {
                                boxes += 1;
                            }
                        }

                    }

                    sw.Close();
                    stream.Close();
                    MessageBox.Show("File Saved Successfully.\nTotal Walls : " + walls + "\nTotal Doors : " + doors + "\nTotal Boxes : " + boxes,
                            "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion




        //Methods to select tool to draw level
        #region Tool Picker       
        private void btnNone_Click(object sender, EventArgs e)
        {
            selectedButton = (Button)sender;
        }

        private void btnWall_Click(object sender, EventArgs e)
        {
            selectedButton = (Button)sender;
        }

        private void btnRedDoor_Click(object sender, EventArgs e)
        {
            selectedButton = (Button)sender;
        }

        private void btnGreenDoor_Click(object sender, EventArgs e)
        {
            selectedButton = (Button)sender;
        }

        private void btnRedBox_Click(object sender, EventArgs e)
        {
            selectedButton = (Button)sender;
        }

        private void btnGreenBox_Click(object sender, EventArgs e)
        {
            selectedButton = (Button)sender;
        }

        #endregion





        //Methods to generate PictureBoxes (tiles) to draw the level
        #region Generate Tiles
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (!isTileGenerated)
                {
                    Rows = int.Parse(txtRows.Text);
                    Columns = int.Parse(txtColumns.Text);

                    board = new int[Rows, Columns];

                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {

                            string str = i + "," + j;
                            GeneratePictureBox(str);
                            board[i, j] = 0;
                            x += 70;

                        }
                        y += 70;
                        x = 10;
                    }
                    isTileGenerated = true;
                }
                else
                {
                    MessageBox.Show("Game Level Design Board is already generated !!! \nYou cannot generate it again. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch
            {
                MessageBox.Show("Please provide valid data for rows and columns (Both must be integers)", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GeneratePictureBox(string str)
        {
            PictureBox tile = new PictureBox();

            tile.BorderStyle = BorderStyle.FixedSingle;

            tile.Width = 70;
            tile.Height = 70;
            tile.SizeMode = PictureBoxSizeMode.StretchImage;
            tile.Visible = true;
            tile.BorderStyle = BorderStyle.Fixed3D;
            tile.Left += x;
            tile.Top += y;
            tile.Tag = str;
            panelPlayGround.Visible = true;
            panelPlayGround.Controls.Add(tile);
            tile.Click += tile_Click;

        }

        #endregion





        //Method for assign selected tool(wall, red box, green box, red door, geen door, none) to the tile
        #region Tool Assigning
        private void tile_Click(object sender, EventArgs e)
        {
            PictureBox pbTile = (PictureBox)sender;
            string[] index = pbTile.Tag.ToString().Split(',');

            switch (selectedButton.Text)
            {

                case "None":
                    pbTile.Image = null;
                    board[int.Parse(index[0]), int.Parse(index[1])] = 0; 
                    break;
                case "Wall":
                    pbTile.Image = Properties.Resources.Wall;
                    board[int.Parse(index[0]), int.Parse(index[1])] = 1;
                    break;
                case "Red Door":
                    pbTile.Image = Properties.Resources.RedDoor;
                    board[int.Parse(index[0]), int.Parse(index[1])] = 2;
                    break;
                case "Green Door":
                    pbTile.Image = Properties.Resources.GreenDoor;
                    board[int.Parse(index[0]), int.Parse(index[1])] = 3;
                    break;
                case "Red Box":
                    pbTile.Image = Properties.Resources.RedBox;
                    board[int.Parse(index[0]), int.Parse(index[1])] = 4;
                    break;
                case "Green Box":
                    pbTile.Image = Properties.Resources.GreenBox;
                    board[int.Parse(index[0]), int.Parse(index[1])] = 5;
                    break;
                default:
                    MessageBox.Show("Nothing is selected");
                    break;
            }
           
        }

        #endregion


    }
}
