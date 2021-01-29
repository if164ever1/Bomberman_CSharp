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
        Sost[,] map;
        int step;

        public Player(PictureBox _player, PictureBox[,] _mapPic, Sost[,]_map)
        {
            player = _player;
            mapPic = _mapPic;
            map = _map;
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
            if(IsEmpty(ref sx,ref sy))
                player.Location = new Point(player.Location.X + sx, player.Location.Y + sy);
        }

        private bool IsEmpty(ref int sx, ref int sy)
        {
            Point playerPoint = MyNowPoint();

            if (sx > 0 && map[playerPoint.X + 1, playerPoint.Y] == Sost.empty)
                return true;
            if (sx < 0 && map[playerPoint.X - 1, playerPoint.Y] == Sost.empty)
                return true;
            if (sy > 0 && map[playerPoint.X, playerPoint.Y+1] == Sost.empty)
                return true;
            if (sy < 0 && map[playerPoint.X, playerPoint.Y-1] == Sost.empty)
                return true;

            int playerRight = player.Location.X + player.Size.Width;
            int playerLeft = player.Location.X;
            int playerDown = player.Location.Y + player.Size.Height;
            int playerUp = player.Location.Y;

            int rightWallLeft = mapPic[playerPoint.X + 1, playerPoint.Y].Location.X;
            int leftWallRight = mapPic[playerPoint.X - 1, playerPoint.Y].Location.X + mapPic[playerPoint.X - 1, playerPoint.Y].Size.Width;
            int downWallUp = mapPic[playerPoint.X, playerPoint.Y + 1].Location.Y;
            int upWallDown = mapPic[playerPoint.X, playerPoint.Y - 1].Location.Y + mapPic[playerPoint.X, playerPoint.Y - 1].Size.Height;

            if (sx > 0 && playerRight + sx > rightWallLeft)
                sx = rightWallLeft - playerRight;
            if(sx<0 && playerLeft + sx < leftWallRight)
                sx = leftWallRight - playerLeft;
            if (sy > 0 && playerDown + sy > downWallUp)
                sy = downWallUp - playerDown;
            if (sy < 0 && playerUp + sy < upWallDown)
                sy = upWallDown - playerUp;

            return true;
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
