using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exemplu_miscare
{
    class Animal_up
    {
        public Graphics graphics_animal; //cum arara animalul din form principal
        public Rectangle rectangle_animal; //pozitia animalului din form principal
        private Pen pen_animal;  //vroiam sa il folosesc ca culoare pt animale din form principal
        private int type_animal; //tipul animalului 0 este caprioara,1 iepure...
        private bool look_animal = false;
        private bool see_hit = false;   // ca sa stiu daca trebuie sa apara animalul in(form secundar)
        private const int how_see2 = 5;//animalul in departare 
        private const int how_see1 = 10;// animalul in apropiere

        public int Type_animal {
            get => type_animal;
            set => type_animal = value;
        }

       
        public Animal_up()
        {
            graphics_animal = null;
            rectangle_animal = new Rectangle(20, 20, 10, 10);
        }
        Animal_up(Graphics graphics, Rectangle rectangle, Pen pen)
        {
            this.graphics_animal = graphics;
            this.rectangle_animal = rectangle;
            this.pen_animal = pen;
        }


        public void setSeeHit_animal(bool bseeHit)
        {
            this.see_hit = bseeHit;

        }
        public bool getSeeHit_animal()
        {
            return see_hit;

        }


        public void setLook_animal(bool bLook)
        {
            this.look_animal = bLook;

        }
        public bool getLook_animal()
        {
            return look_animal;

        }
        public void SetRectangle(int x, int y, int width, int hight)
        {

            this.rectangle_animal.X = x;
            this.rectangle_animal.Y = y;
            this.rectangle_animal.Width = width;
            this.rectangle_animal.Height = hight;



        }
        public void Paint_animal(PaintEventArgs paintEvent)
        {
            pen_animal = new Pen(Color.Bisque);
            graphics_animal = paintEvent.Graphics;
            if (look_animal)
            {
                graphics_animal.FillRectangle(new SolidBrush(Color.Bisque), rectangle_animal);
                rectangle_animal.Width = how_see1;
                rectangle_animal.Height = how_see1;
            }
            else
            {
                graphics_animal.FillEllipse(new SolidBrush(Color.Green), rectangle_animal);
                rectangle_animal.Width = how_see2;
                rectangle_animal.Height = how_see2;


            }

        }

    }
}
