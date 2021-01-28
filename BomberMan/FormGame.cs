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
        public labelScore()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            MainBoard board = new MainBoard(panelGame);
        }

        private void aboutGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The game Bomberman!!!");
        }

        private void aboutAutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ihor Zadorozhniak");
        }
    }
}
