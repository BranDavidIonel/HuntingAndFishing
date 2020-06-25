using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplu_miscare
{
    class MoveDeer
    {
        int x;
        int y;
        int maxX;//domeniu maxim in care se poate misca animalul
        int maxY; 
        Random rand=new Random(); //trbuie sa fac animalul sa se miste la intamplare
        // sa apara la intamplare undeva pe harta
       public MoveDeer() {
            x = rand.Next(0, 1300);
            y= rand.Next(0, 700);

        }
        public int getX() {
            return x;
        }
      public   int getY() {
            return y;
        }
       public int MoveDeerX(int xin) {
            x = xin + rand.Next(0, 5);
            return x;
        }
       public int MoveDeerY(int yin)
        {
            y = yin + rand.Next(0, 5);
            return y;
        }
        public void setMaxX(int x) {
            maxX = x;
        }
        public void setMaxY(int Y)
        {
            maxY = Y;
        }
        public int getmaxX() {
            return maxX;
        }
        public int getmaxY()
        {
            return maxY;
        }

    }
}
