using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplu_miscare
{
    class Cloud
    {
        //coordonatele pentru locatia la nori
        int x;
     
        int y;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return Y; } set { Y = value; } }
        Rectangle rectangle = new Rectangle();
        public void DrawCloud(Graphics graphics,int x,int y)
        {
            this.x = x;
            this.y = y;
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Width = 80;
            rectangle.Height = 30;
            graphics.FillEllipse(new SolidBrush(Color.FromArgb(120, 254, 255, 255)), rectangle);


        }
    }
}
