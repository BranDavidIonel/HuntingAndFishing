using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplu_miscare
{
    class Content
    {

        //coordonatele la caracterul meu 
        int x;
        int y;

        public int Y { get => y; set => y = value; }
        public int X { get => x; set => x = value; }

        //verific daca este in apa sau nu 
        public bool isBlue(int x, int y) {
            Bitmap myBitmap = exemplu_miscare.Properties.Resources.bk3;
            // extrag pixelul pe care se afla player-ul 
            if (x > 0 && y > 0&&x<1360)
            {
                Color pixelColor = myBitmap.GetPixel(x, y);


                if (pixelColor.B > 160 && pixelColor.A > 180)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else {
                return false;
            }
       
                    
                
            

        }
        //verific daca este in port sau nu ca sa stiu daca merge in barca sau nu
        public bool isInHarbor(int x, int y)
        {

            //primul port
            if ((x > 350 && x < 374) && (y >420 && y < 443))
            {

                return true;
            }
            //al doilea port
            if ((x > 1200 && x < 1231) && (y > 15 && y < 39))
            {

                return true;
            }
            return false;

        }
    }
}
