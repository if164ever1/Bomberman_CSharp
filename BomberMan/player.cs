using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BomberMan
{
    enum Arrows { left, right, up, down }
    class Player
    {
        PictureBox player;
        PictureBox[,] mapPic;
        int step;

        public Player(PictureBox _player, PictureBox[,] _mapPic)
        {
            player = _player;
            mapPic = _mapPic;
            step = 3;
        }
        public void MovePlayer(Arrows arrows)
        {
            switch (arrows)
            {
                case Arrows.left:
                    Move(-step, 0);
                    break;
                case Arrows.right:
                    Move(step, 0);
                    break;
                case Arrows.up:
                    Move(0, -step);
                    break;
                case Arrows.down:
                    Move(0, step);
                    break;
                default:
                    break;
            }
        }
        private void Move(int sx, int sy)
        {
            player.Location = new Point(player.Location.X + sx, player.Location.Y + sy);
        }

        private Point MyNowPoint()
        {
            Point point = new Point();
            {
                point.X = player.Location.X + player.Size.Width/2;
                point.Y = player.Location.Y + player.Size.Height / 2;
            }

            for (int x = 0; x < mapPic.GetLength(0); x++)
            {
                for (int y = 0; y < mapPic.GetLength(1); y++)
                {
                    if( mapPic[x,y].Location.X < point.X && 
                        mapPic[x,y].Location.Y < point.Y && 
                        mapPic[x,y].Location.X + mapPic[x,y].Size.Width > point.X &&
                        mapPic[x,y].Location.Y+mapPic[x,y].Size.Height > point.Y)
                        return new Point(x,y);
                }
            }

            return point;
        }
    }
}
