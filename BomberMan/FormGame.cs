using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BomberMan
{
    public partial class labelScore : Form
    {
        MainBoard board;
        public labelScore()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            board = new MainBoard(panelGame);
        }

        private void aboutGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The game Bomberman!!!");
        }

        private void aboutAutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ihor Zadorozhniak");
        }

       private void labelScore_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left: board.MovePlayer(Arrows.left);break;
                case Keys.Right: board.MovePlayer(Arrows.right); break;
                case Keys.Up: board.MovePlayer(Arrows.up); break;
                case Keys.Down: board.MovePlayer(Arrows.down); break;
            }
        }
    }
}
