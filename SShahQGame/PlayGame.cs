/*
 * Project : SSahQGame
 * Purpose : To submit assignment
 * Revesion History : Created By Sagar Shah on December 2021
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SShahQGame
{
    public partial class PlayGame : Form
    {
        
        public PlayGame()
        {
            InitializeComponent();
            Init();
        }


        /// <summary>
        ///Method to Reset Every elements and disable buttons 
        /// </summary>
        void Init()
        {
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            btnRight.Enabled = false;
            btnLeft.Enabled = false;
            NumberOfMoves = 0;
            txtMoves.Text = "0";
            txtRemainingBoxes.Text = "0";
            gamePanel.Controls.Clear();

        }


        /// <summary>
        /// Global Variables define and initialize
        /// </summary>
        bool IsBoxSelected = false;
        int[,] board;
        int Rows, Columns;
        int x = 10, y = 10;
        int NumberOfBoxes = 0;
        int NumberOfMoves = 0;
        static PictureBox selectedTile;
        static int selected_X = 0;
        static int selected_Y = 0;
        static int selectedTileType = 0;
        bool isWall = true;

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// return type of tile
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        int GetTileType(int i, int j)
        {
            return board[i, j];
        }

        /// <summary>
        /// method to check winning condition
        /// </summary>
        /// <returns></returns>
        bool WinGame()
        {
            if (txtRemainingBoxes.Text == "0")
            {
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnRight.Enabled = false;
                btnLeft.Enabled = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// method to move box Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Up_Button
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (IsBoxSelected)
            {
               
                //Check whether up tile of selected tile is null or not
                if (board[selected_X - 1, selected_Y] == 0)
                {


                    for (int i = selected_X - 1; i >= 0; i--)
                    {
                        //check whether i tile is red door and selected tile is red box
                        if (GetTileType(i, selected_Y) == 2 && selectedTileType == 4)
                        {
                            NumberOfBoxes -= 1;
                            txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                            selectedTile.Image = null;
                            selectedTile.BackColor = Color.Transparent;
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            board[selected_X, selected_Y] = 0;
                            selectedTile = null;
                            selected_X = -1;
                            selected_Y = -1;
                            selectedTileType = -1;
                            isWall = false;
                            IsBoxSelected = false;
                            NumberOfMoves += 1;
                            txtMoves.Text = NumberOfMoves.ToString();

                           
                            break;

                        }
                        //check whether i tile is green door and selected tile is green box
                        else if (GetTileType(i, selected_Y) == 3 && selectedTileType == 5)
                        {
                            NumberOfBoxes -= 1;
                            txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                            selectedTile.Image = null;
                            selectedTile.BackColor = Color.Transparent;
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            board[selected_X, selected_Y] = 0;
                            selectedTile = null;
                            selected_X = -1;
                            selected_Y = -1;
                            selectedTileType = -1;
                            isWall = false;
                            IsBoxSelected = false;
                            NumberOfMoves += 1;
                            txtMoves.Text = NumberOfMoves.ToString();

                           
                            break;
                        }
                        //check i tile is not null OR check that the i tile is wall or not
                        else if (GetTileType(i, selected_Y) != 0)
                        {
                            isWall = true;
                            board[i+1, selected_Y] = board[selected_X, selected_Y];
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            board[selected_X, selected_Y] = 0;
                            selected_X = i + 1;

                            break;
                        }
                       
                    }

                    //Move selected box upto next tile of wall
                    if (isWall)
                    {

                        foreach (Control item in gamePanel.Controls)
                        {
                            if (item is PictureBox)
                            {

                                if (item.Tag.Equals(0 + "#" + selected_X + "#" + selected_Y))
                                {
                                    SetImage((PictureBox)item, selectedTileType);
                                    item.Tag = selectedTileType + "#" + selected_X + "#" + selected_Y;  
                                    selectedTile.BackColor = Color.Transparent;
                                
                                    selectedTile.Image = null;
                                    item.BackColor = Color.Black;
                                    selectedTile = (PictureBox)item;
                                    Console.WriteLine(selectedTile.Tag);
                                    selectedTile.BackColor = Color.Black;
                                    NumberOfMoves += 1;
                                    txtMoves.Text = NumberOfMoves.ToString();
                                }
                            }
                        }
                    }
                    else if (WinGame())
                    {
                        MessageBox.Show("Win the Game","QGame",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }
                //Check whether up tile of selected tile is RedDoor and selected tile is red box or not
                else if (board[selected_X - 1, selected_Y] == 2 && selectedTileType == 4)
                {
                    NumberOfBoxes -= 1;
                    txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                    selectedTile.Image = null;
                    selectedTile.BackColor = Color.Transparent;
                    selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                    board[selected_X, selected_Y] = 0;
                    selectedTile = null;
                    selected_X = -1;
                    selected_Y = -1;
                    selectedTileType = -1;
                    isWall = false;
                    IsBoxSelected = false;
                    NumberOfMoves += 1;
                    txtMoves.Text = NumberOfMoves.ToString();

                    if (WinGame())
                    {
                        MessageBox.Show("Win the Game", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }
                //Check whether up tile of selected tile is GreenDoor and selected tile is Green box or not
                else if (board[selected_X - 1, selected_Y] == 3 && selectedTileType == 5)
                {
                    NumberOfBoxes -= 1;
                    txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                    selectedTile.Image = null;
                    selectedTile.BackColor = Color.Transparent;
                    selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                    board[selected_X, selected_Y] = 0;
                    selectedTile = null;
                    selected_X = -1;
                    selected_Y = -1;
                    selectedTileType = -1;
                    isWall = false;
                    IsBoxSelected = false;
                    NumberOfMoves += 1;
                    txtMoves.Text = NumberOfMoves.ToString();

                    if (WinGame())
                    {
                        MessageBox.Show("Win the Game", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }



               



            }
            else
            {
                MessageBox.Show("Click On a box to select ", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        /// <summary>
        /// method to move box Left
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Left_Button
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (IsBoxSelected)
            {
                //Check whether left tile of selected tile is null or not
                if (board[selected_X, selected_Y - 1] == 0)
                {

                    
                    for (int i = selected_Y - 1; i >= 0; i--)
                    {
                        //check whether i tile is red door and selected tile is red box
                        if (GetTileType(selected_X, i) == 2 && selectedTileType == 4)
                        {
                            NumberOfBoxes -= 1;
                            txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            selectedTile.Image = null;
                            board[selected_X, selected_Y] = 0;
                            selectedTile.BackColor = Color.Transparent;
                            selectedTile = null;
                            selected_X = -1;
                            selected_Y = -1;
                            selectedTileType = -1;
                            isWall = false;
                            IsBoxSelected = false;
                            NumberOfMoves += 1;
                            txtMoves.Text = NumberOfMoves.ToString();

                            break;

                        }
                        //check whether i tile is green door and selected tile is green box
                        else if (GetTileType(selected_X, i) == 3 && selectedTileType == 5)
                        {
                            NumberOfBoxes -= 1;
                            txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            selectedTile.Image = null;
                            selectedTile.BackColor = Color.Transparent;
                            board[selected_X, selected_Y] = 0;
                            selectedTile = null;
                            selected_X = -1;
                            selected_Y = -1;
                            selectedTileType = -1;
                            isWall = false;
                            IsBoxSelected = false;
                            NumberOfMoves += 1;
                            txtMoves.Text = NumberOfMoves.ToString();

                            break;
                        }
                        //check i tile is not null OR check that the i tile is wall or not
                        else if (GetTileType(selected_X, i) != 0)
                        {
                            isWall = true;
                            board[selected_X, i + 1] = board[selected_X, selected_Y];
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            board[selected_X, selected_Y] = 0;
                            selected_Y = i + 1;

                            break;
                        }
                    }
                   
                    //Move selected box upto next tile of wall
                    if (isWall)
                    {

                        foreach (Control item in gamePanel.Controls)
                        {
                            if (item is PictureBox)
                            {
                                
                                if (item.Tag.Equals(0 + "#" + selected_X + "#" + selected_Y))
                                {
                                   
                                    SetImage((PictureBox)item, selectedTileType);
                                    item.Tag = selectedTileType + "#" + selected_X + "#" + selected_Y;
                                   
                                    selectedTile.BackColor = Color.Transparent;
                                 
                                    selectedTile.Image = null;
                                    item.BackColor = Color.Black;
                                    selectedTile = (PictureBox)item;
                                    
                                    selectedTile.BackColor = Color.Black;
                                    NumberOfMoves += 1;
                                    txtMoves.Text = NumberOfMoves.ToString();
                                }
                            }
                        }
                    }
                    else if (WinGame())
                    {
                        MessageBox.Show("Win the Game", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }
                //Check whether Left tile of selected tile is RedDoor and selected tile is red box or not
                else if (board[selected_X, selected_Y - 1] == 2 && selectedTileType == 4)
                {
                    NumberOfBoxes -= 1;
                    txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                    selectedTile.Image = null;
                    selectedTile.BackColor = Color.Transparent;
                    selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                    board[selected_X, selected_Y] = 0;
                    selectedTile = null;
                    selected_X = -1;
                    selected_Y = -1;
                    selectedTileType = -1;
                    isWall = false;
                    IsBoxSelected = false;
                    NumberOfMoves += 1;
                    txtMoves.Text = NumberOfMoves.ToString();

                    if (WinGame())
                    {
                        MessageBox.Show("Win the Game", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }
                //Check whether Left tile of selected tile is GreenDoor and selected tile is Green box or not
                else if (board[selected_X, selected_Y - 1] == 3 && selectedTileType == 5)
                {
                    NumberOfBoxes -= 1;
                    txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                    selectedTile.Image = null;
                    selectedTile.BackColor = Color.Transparent;
                    selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                    board[selected_X, selected_Y] = 0;
                    selectedTile = null;
                    selected_X = -1;
                    selected_Y = -1;
                    IsBoxSelected = false;
                    isWall = false;
                    selectedTileType = -1;
                    NumberOfMoves += 1;
                    txtMoves.Text = NumberOfMoves.ToString();

                    if (WinGame())
                    {
                        MessageBox.Show("Win the Game", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }


               
            }
            else
            {
                MessageBox.Show("Click On a box to select ", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /// <summary>
        /// method to move box Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Down_Button
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (IsBoxSelected)
            {
              

                if (board[selected_X + 1, selected_Y] == 0)
                {

                    for (int i = selected_X + 1; i <= Columns; i++)
                    {
                        //Console.WriteLine("IN Up METHOD (IN FOR LOOP) : seleted_X = " + selected_X + " selected_Y = " + selected_Y);
                        if (GetTileType(i, selected_Y) == 2 && selectedTileType == 4)
                        {
                            NumberOfBoxes -= 1;
                            txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                            selectedTile.Image = null;
                            selectedTile.BackColor = Color.Transparent;
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            board[selected_X, selected_Y] = 0;
                            selectedTile = null;
                            selected_X = -1;
                            selected_Y = -1;
                            selectedTileType = -1;
                            isWall = false;
                            IsBoxSelected = false;
                            NumberOfMoves += 1;
                            txtMoves.Text = NumberOfMoves.ToString();

                         
                            break;
                        }
                        //check whether i tile is red door and selected tile is red box
                        else if (GetTileType(i, selected_Y) == 3 && selectedTileType == 5)
                        {
                            NumberOfBoxes -= 1;
                            txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                            selectedTile.Image = null;
                            selectedTile.BackColor = Color.Transparent;
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            board[selected_X, selected_Y] = 0;
                            selectedTile = null;
                            selected_X = -1;
                            selected_Y = -1;
                            selectedTileType = -1;
                            isWall = false;
                            IsBoxSelected = false;
                            NumberOfMoves += 1;
                            txtMoves.Text = NumberOfMoves.ToString();

                            
                            break;
                        }
                        //check whether i tile is Green door and selected tile is Green box
                        else if (GetTileType(i, selected_Y) != 0)
                        {
                            isWall = true;
                            board[i - 1, selected_Y] = board[selected_X, selected_Y];
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            board[selected_X, selected_Y] = 0;
                            selected_X = i - 1;

                            break;
                        }
                    }

                    //Move selected box upto next tile of wall
                    if (isWall)
                    {

                        foreach (Control item in gamePanel.Controls)
                        {
                            if (item is PictureBox)
                            {

                                if (item.Tag.Equals(0 + "#" + selected_X + "#" + selected_Y))
                                {
                                    SetImage((PictureBox)item, selectedTileType);
                                    item.Tag = selectedTileType + "#" + selected_X + "#" + selected_Y;
                                    selectedTile.BackColor = Color.Transparent;
                                    selectedTile.Image = null;
                                    selectedTile = (PictureBox)item;
                                    item.BackColor = Color.Black;
                                    selectedTile.BackColor = Color.Black;
                                    NumberOfMoves += 1;
                                    txtMoves.Text = NumberOfMoves.ToString();
                                }
                            }
                        }
                    }
                    else if (WinGame())
                    {
                        MessageBox.Show("Win the Game", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }
                //Check whether Down tile of selected tile is RedDoor and selected tile is red box or not
                else if (board[selected_X + 1, selected_Y] == 2 && selectedTileType == 4)
                {
                    NumberOfBoxes -= 1;
                    txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                    selectedTile.Image = null;
                    selectedTile.BackColor = Color.Transparent;
                    selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                    board[selected_X, selected_Y] = 0;
                    selectedTile = null;
                    selected_X = -1;
                    selected_Y = -1;
                    selectedTileType = -1;
                    isWall = false;
                    IsBoxSelected = false;
                    NumberOfMoves += 1;
                    txtMoves.Text = NumberOfMoves.ToString();

                    if (WinGame())
                    {
                        MessageBox.Show("Win the Game", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }
                //Check whether Down tile of selected tile is GreenDoor and selected tile is Green box or not
                else if (board[selected_X + 1, selected_Y] == 3 && selectedTileType == 5)
                {
                    NumberOfBoxes -= 1;
                    txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                    selectedTile.Image = null;
                    selectedTile.BackColor = Color.Transparent;
                    selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                    board[selected_X, selected_Y] = 0;
                    selectedTile = null;
                    selected_X = -1;
                    selected_Y = -1;
                    selectedTileType = -1;
                    isWall = false;
                    IsBoxSelected = false;
                    NumberOfMoves += 1;
                    txtMoves.Text = NumberOfMoves.ToString();

                    if (WinGame())
                    {
                        MessageBox.Show("Win the Game", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }

            


            }
            else
            {
                MessageBox.Show("Click On a box to select ", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /// <summary>
        /// method to move box Right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Right_Button
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (IsBoxSelected)
            {
               


                if (board[selected_X, selected_Y + 1] == 0)
                {
                    for (int i = selected_Y + 1; i <= Rows; i++)
                    {
                        //check whether i tile is red door and selected tile is red box
                        if (GetTileType(selected_X, i) == 2 && selectedTileType == 4)
                        {
                            NumberOfBoxes -= 1;
                            txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                            selectedTile.Image = null;
                            selectedTile.BackColor = Color.Transparent;
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            board[selected_X, selected_Y] = 0;
                            selectedTile = null;
                            selected_X = -1;
                            selected_Y = -1;
                            selectedTileType = -1;
                            isWall = false;
                            IsBoxSelected = false;
                            NumberOfMoves += 1;
                            txtMoves.Text = NumberOfMoves.ToString();

                            break;

                        }
                        //check whether i tile is Red door and selected tile is Red box
                        else if (GetTileType(selected_X, i) == 3 && selectedTileType == 5)
                        {
                            NumberOfBoxes -= 1;
                            txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                            selectedTile.Image = null;
                            selectedTile.BackColor = Color.Transparent;
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            board[selected_X, selected_Y] = 0;
                            selectedTile = null;
                            selected_X = -1;
                            selected_Y = -1;
                            selectedTileType = -1;
                            isWall = false;
                            IsBoxSelected = false;
                            NumberOfMoves += 1;
                            txtMoves.Text = NumberOfMoves.ToString();

                            
                            break;
                        }
                        //check whether i tile is Green door and selected tile is Green box
                        else if (GetTileType(selected_X, i) != 0 )
                        {
                            isWall = true;
                            board[selected_X, i - 1] = board[selected_X, selected_Y];
                            selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                            board[selected_X, selected_Y] = 0;
                            selected_Y = i - 1;
                          
                            break;
                        }

                    }

                    //Move selected box upto next tile of wall
                    if (isWall)
                    {

                        foreach (Control item in gamePanel.Controls)
                        {
                            if (item is PictureBox)
                            {

                                if (item.Tag.Equals(0 + "#" + selected_X + "#" + selected_Y))
                                {

                                    SetImage((PictureBox)item, selectedTileType);
                                    item.Tag = selectedTileType + "#" + selected_X + "#" + selected_Y;
                                    
                                    selectedTile.BackColor = Color.Transparent;
                                  
                                    selectedTile.Image = null;
                                    item.BackColor = Color.Black;
                                    selectedTile = (PictureBox)item;
                                   
                                    selectedTile.BackColor = Color.Black;
                                    NumberOfMoves += 1;
                                    txtMoves.Text = NumberOfMoves.ToString();
                                }
                            }
                        }
                    }
                    else if (WinGame())
                    {
                        MessageBox.Show("Win the Game", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }
                //Check whether Right tile of selected tile is RedDoor and selected tile is red box or not
                else if (board[selected_X, selected_Y + 1] == 2 && selectedTileType == 4)
                {
                    NumberOfBoxes -= 1;
                    txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                    selectedTile.Image = null;
                    selectedTile.BackColor = Color.Transparent;
                    selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                    board[selected_X, selected_Y] = 0;
                    selectedTile = null;
                    selected_X = -1;
                    selected_Y = -1;
                    selectedTileType = -1;
                    isWall = false;
                    IsBoxSelected = false;
                    NumberOfMoves += 1;
                    txtMoves.Text = NumberOfMoves.ToString();

                    if (WinGame())
                    {
                        MessageBox.Show("Win the Game", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }
                //Check whether Right tile of selected tile is GreenDoor and selected tile is Green box or not
                else if (board[selected_X, selected_Y + 1] == 3 && selectedTileType == 5)
                {
                    NumberOfBoxes -= 1;
                    txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                    selectedTile.Image = null;
                    selectedTile.BackColor = Color.Transparent;
                    selectedTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
                    board[selected_X, selected_Y] = 0;
                    selectedTile = null;
                    selected_X = -1;
                    selected_Y = -1;
                    selectedTileType = -1;
                    isWall = false;
                    IsBoxSelected = false;
                    NumberOfMoves += 1;
                    txtMoves.Text = NumberOfMoves.ToString();

                    if (WinGame())
                    {
                        MessageBox.Show("Win the Game", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gamePanel.Controls.Clear();
                    }
                }





                

            }
            else
            {
                MessageBox.Show("Click On a box to select ", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /// <summary>
        /// Load the level from the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region LoadLevel
        private void loadLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Init();
                NumberOfBoxes = 0;
                x = 10;
                y = 10;
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "txt files (*.txt)|*.txt";
                
                Stream stream;
                gamePanel.Controls.Clear();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFile.FileName;

                    stream = openFile.OpenFile();

                    StreamReader reader = new StreamReader(stream);
                    Rows = int.Parse(reader.ReadLine());
                    Columns = int.Parse(reader.ReadLine());
                    board = new int[Rows, Columns];

                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            board[i, j] = 0;
                        }
                    }



                    while (!reader.EndOfStream)
                    {
                        board[int.Parse(reader.ReadLine()), int.Parse(reader.ReadLine())] = int.Parse(reader.ReadLine());
                    }

                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {

                           
                            GeneratePictureBox(board[i,j],i,j);
                           
                            x += 70;

                        }
                        y += 70;
                        x = 10;
                    }
                    
                }
                txtRemainingBoxes.Text = NumberOfBoxes.ToString();
                btnUp.Enabled = true;
                btnDown.Enabled = true;
                btnRight.Enabled = true;
                btnLeft.Enabled = true;
                

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            
        }
        #endregion

        //generate the tile grid 
        public void GeneratePictureBox(int itemNumber, int i, int j)
        {
            PictureBox tile = new PictureBox();

            tile.Width = 70;
            tile.Height = 70;
            tile.SizeMode = PictureBoxSizeMode.StretchImage;
            tile.Visible = true;
          
            tile.Left += x;
            tile.Top += y;
            tile.Tag = itemNumber+"#"+i+"#"+j;
            if(itemNumber == 4 || itemNumber == 5)
            {
                NumberOfBoxes += 1;
            }
            gamePanel.Controls.Add(tile);

            SetImage(tile, itemNumber);


            tile.Click += tile_Click;

        }

       

        private void tile_Click(object sender, EventArgs e)
        {
            
            PictureBox pbTile = (PictureBox)sender;
            string[] temp = pbTile.Tag.ToString().Split('#');
           
          
            if (temp[0] == "4" || temp[0] == "5")
            {
                if (selectedTile != null)
                {

                    selectedTile.Tag = selectedTileType + "#" + selected_X + "#" + selected_Y;
                    selectedTile.BackColor = Color.Transparent;
                    selectedTile.Padding = new Padding(0);
                }
                selectedTile = pbTile;
               
                selectedTile.BackColor = Color.Black;
                
                selectedTile.Padding = new Padding(3);
                selectedTile.Tag = pbTile.Tag;

                selected_X = int.Parse(temp[1]);
                selected_Y = int.Parse(temp[2]);
                selectedTileType = int.Parse(temp[0]);
              
                IsBoxSelected = true;
              
                pbTile.Tag = 0 + "#" + selected_X + "#" + selected_Y;
            }
        }
        
        /// <summary>
        /// Set the Image to the tile according the tile type
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="itemNumber"></param>
        private void SetImage(PictureBox tile, int itemNumber)
        {
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
                  
                    break;
                case 5:
                    tile.Image = Properties.Resources.GreenBox;
                    
                    break;
            }
        }
        
    }

}

