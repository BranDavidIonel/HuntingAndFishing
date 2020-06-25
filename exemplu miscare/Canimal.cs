using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplu_miscare
{
    class Canimal:CImageBase
    {
        private Rectangle animalHotspot = new Rectangle();

        //foldarul si numarul la imagine
        public Canimal(int nr,string  folder) : base(folder,nr)
        {
            //aici se face zona in care se inpusca animalul
            animalHotspot.X = Left ;
            animalHotspot.Y = Top+10 ;
            animalHotspot.Width = 150;
            animalHotspot.Height = 150;
        }
        public void Uptate(int X, int Y) {
            Left = X;
            Top = Y;
            animalHotspot.X = Left ;
            animalHotspot.Y = Top ;
            
        }
        public bool Hit(int X, int Y) {
            Rectangle r = new Rectangle(X, Y, 1, 1);
            if (animalHotspot.Contains(r)) {
                return true;
            }
            return false;
        }
    }
}
