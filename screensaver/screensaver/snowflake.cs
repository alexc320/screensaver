using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace screensaver
{
    public class snowflake
    {
        public int X;
        public int Y;
        public int Size;
        public int SpeedX;
        public int SpeedY;
        public snowflake(int x, int y, int size, int speedX, int speedY)
        {
            X = x;
            Y = y;
            Size = size;
            SpeedX = speedX;
            SpeedY = speedY;
        }
    }
}
