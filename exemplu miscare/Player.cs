using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exemplu_miscare
{
    class Player
    {
        //int x;
        //int y;
        // daca nu este "isboat" adica obijnuit cauta vanat in padure este la inceput de joc sau poate sa fie barca 

        //merge cu barca
        bool isBoat=false;
        Rectangle rectangle_player;
        Rectangle rectangle_boat;
        public Player() {
            this.rectangle_player.X = 40;
            this.rectangle_player.Y = 120;
            this.rectangle_player.Width = 10;
            this.rectangle_player.Height = 10;
            this.rectangle_boat.Width = 20;
            this.rectangle_boat.Height = 8;
            //this.x = rectangle_player.X;
            //this.y = rectangle_player.Y;

        }
       public void setRectanglePlayer(int x, int y) {
            this.rectangle_player.X = x;
            this.rectangle_player.Y = y;
            this.rectangle_boat.X = x;
            this.rectangle_boat.Y = y;
            //this.x = x;
            //this.y = y;

        }
      public  void paintPlayer(PaintEventArgs paint) {
            Graphics graphics = paint.Graphics;
            if (!IsBoat)
            {

                graphics.FillRectangle(new SolidBrush(Color.BlueViolet), rectangle_player);
            }
            else {

                graphics.FillEllipse(new SolidBrush(Color.Bisque), rectangle_player.X,rectangle_player.Y,rectangle_boat.Width,rectangle_boat.Height);
            }
            

        }
        public int X { get { return rectangle_player.X; } set { rectangle_player.X = value; } }
        public int Y { get { return rectangle_player.Y; } set { rectangle_player.Y = value; } }
        public bool IsBoat { get { return isBoat; } set { isBoat = value; } }
    }
}
