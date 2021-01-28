using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BomberMan
{
    enum Sost
    {
        empty,
        wall,
        brick,
        bomb,
        fire,
        prise
    }

    class MainBoard
    {
        Panel panelGame;
        public PictureBox[,] mapPic;
        Sost[,] map;
        int sizeX = 17;
        int sizeY = 11;
        static Random random = new Random();
        Player player;
        public MainBoard(Panel panel)
        {
            panelGame = panel;

            int boxSize;

            if ((panelGame.Width / sizeX) < (panelGame.Height / sizeY))
                boxSize = panelGame.Width / sizeX;
            else
                boxSize = panelGame.Height / sizeY;


            InitStartMap(boxSize);
            InitStartPlayer(boxSize);
        }

        private void InitStartMap(int boxSize)
        {
            mapPic = new PictureBox[sizeX, sizeY];
            panelGame.Controls.Clear();

            map = new Sost[sizeX, sizeY];

            

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (x == 0 || y == 0 || x == sizeX-1 || y == sizeY-1)
                        CreatePlace(new Point(x, y), boxSize, Sost.wall);
                    else if(x % 2 == 0 && y%2 ==0)
                        CreatePlace(new Point(x, y), boxSize, Sost.wall);
                        else if(random.Next(3)==0)
                            CreatePlace(new Point(x, y), boxSize, Sost.brick);
                    else
                        CreatePlace(new Point(x, y), boxSize, Sost.empty);
                }
            }
            changeSost(new Point(1, 1), Sost.empty);
            changeSost(new Point(2, 1), Sost.empty);
            changeSost(new Point(1, 2), Sost.empty);
        }

        private void CreatePlace(Point point, int boxSize, Sost sost)
        {
            PictureBox picture = new PictureBox();
            picture.Location = new Point(point.X *(boxSize-1), point.Y*(boxSize-1));
            picture.Size = new Size(boxSize, boxSize);
            //picture.BorderStyle = BorderStyle.FixedSingle;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            mapPic[point.X, point.Y] = picture;
            changeSost(point, sost);
            panelGame.Controls.Add(picture);
            
        }

        private void changeSost(Point p, Sost s)
        {
            switch (s)
            {
                case Sost.wall:
                    mapPic[p.X, p.Y].Image = Properties.Resources.wall;
                    break;
                case Sost.brick:
                    mapPic[p.X, p.Y].Image = Properties.Resources.brick;
                    break;
                case Sost.bomb:
                    mapPic[p.X, p.Y].Image = Properties.Resources.bomba;
                    break;
                case Sost.fire:
                    mapPic[p.X, p.Y].Image = Properties.Resources.fire;
                    break;
                case Sost.prise:
                    mapPic[p.X, p.Y].Image = Properties.Resources.prise;
                    break;
                default:
                    mapPic[p.X, p.Y].Image = Properties.Resources.ground;
                    break;
            }
            map[p.X, p.Y] = s;
        }

        private void InitStartPlayer(int boxSize)
        {
            int x = 1; int y = 1;
            PictureBox picture = new PictureBox();
            picture.Location = new Point(x * (boxSize) + 7, y * (boxSize) + 3);
            picture.Size = new Size(boxSize-14, boxSize-6);
            picture.Image = Properties.Resources.hero;
            picture.BackgroundImage = Properties.Resources.ground;
            picture.BackgroundImageLayout = ImageLayout.Stretch;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            panelGame.Controls.Add(picture);
            picture.BringToFront();
            player = new Player(picture);
        }
    }
}
