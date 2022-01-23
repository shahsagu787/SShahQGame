/*
 * Project : SShahQGame
 * Purpose : To Submit Assignment 
 * Revesion History : Created By Sagar Shah on November 2021
 * 
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

namespace SShahQGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static PlayGame play;
        static DesignForm designForm;
        //method to open Design window
        private void btnDesign_Click(object sender, EventArgs e)
        {
            designForm = new DesignForm();
            play = new PlayGame();
            play.Hide();
            designForm.Show();
           
        }

        //method for exit button 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            designForm = new DesignForm();
            play = new PlayGame();
            designForm.Hide();
            play.Show();
        }
    }
}
