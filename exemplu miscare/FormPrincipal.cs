using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace exemplu_miscare
{




    public partial class FormPrincipal : Form
    {
        const int speedPLayer = 5;
        const int rejectionPlayer = 25;
        
        // ca sa aflu pozitia unde nu poate merge caracterul 
        int cursX = 0;
        int cursY = 0;
        Player player;

        Thread th;
        Random random=new Random();
        Content content = new Content();
        int misses = 0;
        int hits = 0;
        static int placeHit = 100;
        static int placeShow = 200;
        bool right;
        bool left;
        bool top;
        bool down;
        bool dDeer = false; //se verifica daca o ajuns in partea de jos,respectiv la dreapta 
        bool lDeer = false;//left Deer
     //   bool isDeer = false; //verific daca este un animal in apropiere
        MoveDeer moveDeer;
        //Rectangle rectangle_player;
        Animal_up animal_Up1;
        Animal_up animal_Up2;
        Animal_up animal_Up3;
        Animal_up animal_Up4;
        Animal_up animal_Up5;
        Animal_up animal_hit;
        List<Animal_up> list_animalup;
            
        public FormPrincipal(int x, int y, int hitsin, int missesin,bool isBoat_)
        {

            hits = hitsin;
            misses = missesin;
            player = new Player();
            player.IsBoat = isBoat_;
            WindowState = FormWindowState.Maximized;
            //  moveDeer = new MoveDeer();
          
            list_animalup = new List<Animal_up>();

            animal_Up1 = new Animal_up();
            animal_Up2 = new Animal_up();
            animal_Up3 = new Animal_up();
            animal_Up4 = new Animal_up();
            animal_Up5 = new Animal_up();
            animal_hit = new Animal_up();
            
            list_animalup.Add(animal_Up1);
            list_animalup.Add(animal_Up2);
            list_animalup.Add(animal_Up3);
            list_animalup.Add(animal_Up4);
            list_animalup.Add(animal_Up5);
            list_animalup[0].Type_animal = 0;
            list_animalup[1].Type_animal = 1;
            list_animalup[2].Type_animal = 1;
            list_animalup[3].Type_animal = 0;
            list_animalup[4].Type_animal = 1;

            InitializeComponent();


            // the_player = deer_hunter_Fd.Properties.Resources.square1;

            //rectangle_player = new Rectangle(40, 120, 10, 10);

            //animal_Up.SetRectangle(400, 120, 10, 10);
       
            this.BackgroundImage = exemplu_miscare.Properties.Resources.bk2;

            //rectangle_player.X = x;
            //rectangle_player.Y = y; //in jos
            player.setRectanglePlayer(x, y);
            
                                    //animal_Up.rectangle_animal.X = moveDeer.getX();
                                    //animal_Up.rectangle_animal.Y = moveDeer.getY();
         
       

            for (int i = 0; i < list_animalup.Count; i++)
            {
                moveDeer = new MoveDeer();
                moveDeer.setMaxX(Screen.PrimaryScreen.Bounds.Width);
                moveDeer.setMaxY(Screen.PrimaryScreen.Bounds.Height);
                list_animalup[i].SetRectangle(moveDeer.getX(), moveDeer.getX(), 10, 10);
                //am pus 70 pt ca nu voiam sa apara animalele apropiate
                while (random.Next(0, 500) > 70)
                {
                    list_animalup[i].rectangle_animal.X = moveDeer.getX() + random.Next(0, 1200);
                    list_animalup[i].rectangle_animal.Y = moveDeer.getY() + random.Next(0, 200);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

           
            if (right == true)
            {
                if (!content.isBlue(player.X, player.Y)&& ! player.IsBoat)
                {

                    player.X += speedPLayer;
                }else if(player.IsBoat&&content.isBlue(player.X, player.Y)){
                    player.X += speedPLayer ;

                }
                else {
                    player.X -= speedPLayer+rejectionPlayer;
                }
               



            }
            if (left == true)
            {
                if (!content.isBlue(player.X, player.Y)&&!player.IsBoat)
                {
                 
                    player.X -= speedPLayer;
                }
                else if (player.IsBoat && content.isBlue(player.X, player.Y))
                {
                    player.X -= speedPLayer ;

                }
                else
                {
                    player.X += speedPLayer+rejectionPlayer ;
                }
            }

            if (top == true)
            {
                if (!content.isBlue(player.X, player.Y) && !player.IsBoat)
                {
                  
                    player.Y -= speedPLayer;
                }
                else if (player.IsBoat && content.isBlue(player.X, player.Y))
                {
                    player.Y -= speedPLayer ;

                }
                else
                {
                   player.Y += speedPLayer+rejectionPlayer;
                }
            }
            if (down == true)
            {
                if (!content.isBlue(player.X, player.Y) && !player.IsBoat)
                {
                 
                    player.Y += speedPLayer;
                }
                else if (player.IsBoat && content.isBlue(player.X, player.Y))
                {
                    player.Y += speedPLayer ;

                }
                else
                {
                    player.Y -= speedPLayer+rejectionPlayer;
                }

            }

            Invalidate();
            //verific pt marginele stanga dreapta care se misca animalul
            for (int i = 0; i < list_animalup.Count; i++)
            {
                if ((list_animalup[i].rectangle_animal.Left < moveDeer.getmaxX()) && (lDeer == false))
                {
                    list_animalup[i].rectangle_animal.X += moveDeer.MoveDeerX(1);
                }
                else
                {
                    lDeer = true;
                }

                if (dDeer == true && (list_animalup[i].rectangle_animal.Left > 0))
                {
                    list_animalup[i].rectangle_animal.X -= moveDeer.MoveDeerX(1);
                }
                else
                {

                    lDeer = false;
                }

                //verific pt marginele jos sus 
                if ((list_animalup[i].rectangle_animal.Top < moveDeer.getmaxY()) && (dDeer == false))
                {
                    list_animalup[i].rectangle_animal.Y += moveDeer.MoveDeerY(1);
                }
                else
                {
                    dDeer = true;
                }




                if (dDeer == true && (list_animalup[i].rectangle_animal.Top > 0))
                {
                    list_animalup[i].rectangle_animal.Y -= moveDeer.MoveDeerY(1);
                }
                else
                {

                    dDeer = false;
                }

                ///

                //verific daca este in apropiere de vanat :)

                if (((player.Y - list_animalup[i].rectangle_animal.Y < placeShow) && (player.Y - list_animalup[i].rectangle_animal.Top > -placeShow)) && ((player.X - list_animalup[i].rectangle_animal.Left < placeShow)) && (player.X - list_animalup[i].rectangle_animal.Left > -placeShow))
                {
                   
                    list_animalup[i].setLook_animal(true);
                }
                else
                {
                    //  deer1l.Visible = false
                    // animal_Up.setLook_animal(false);
                    list_animalup[i].setLook_animal(false);
                }
            }
            for (int i = 0; i < list_animalup.Count; i++)
            {
                if (((player.Y - list_animalup[i].rectangle_animal.Top < placeHit) && (player.Y - list_animalup[i].rectangle_animal.Top > -placeHit)) && ((player.X - list_animalup[i].rectangle_animal.Left < placeHit)) && (player.X - list_animalup[i].rectangle_animal.Left > -placeHit))
                {
                    animal_hit.setSeeHit_animal(true);
                    animal_hit.Type_animal = list_animalup[i].Type_animal;
                    break;
                    
                }
                else
                {
               
                    animal_hit.setSeeHit_animal(false);

                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Right)
                {
                    right = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    left = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    top = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    down = true;
                }

            if (e.KeyCode == Keys.F)
            {

                this.Close();

                th = new Thread(openSecundarForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if(content.isInHarbor(player.X,player.Y))
                if (player.IsBoat == false)
                {
                    player.IsBoat = true;
                        player.X += 25;
                }
                else
                {
                    player.IsBoat = false;
                }
            }


        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;

            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                top = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                down = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            if (player.IsBoat)
            {
                th = new Thread(openFormFishing);
            }
            else
            {
                th = new Thread(openSecundarForm);
            }
            th.SetApartmentState(ApartmentState.STA);
            th.Start();




        }
        private void openFormFishing() {

            Application.Run(new Form_fishing(player.X, player.Y, hits, misses, player.IsBoat));
        }
        private void openSecundarForm()
        {
            bool[] hit_animals=new bool[list_animalup.Count];
            int[] type_animal = new int[list_animalup.Count];

            for (int i = 0; i < list_animalup.Count; i++) {
                hit_animals[i] = list_animalup[i].getSeeHit_animal();
                type_animal[i] = list_animalup[i].Type_animal;
            }
            Application.Run(new FormSecundar(player.X, player.Y, player.IsBoat,animal_hit.getSeeHit_animal(),animal_hit.Type_animal, hits, misses));
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            

            Graphics gr = e.Graphics;

            Font font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextFormatFlags flagsX_Y = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            TextRenderer.DrawText(gr, "x= " + cursX.ToString() + "|" + " Y= " + cursY.ToString(), font, new Rectangle(20, 140, 220, 120), Color.Red, flagsX_Y);
         //   TextRenderer.DrawText(gr, ""+sum + "|" , font, new Rectangle(20, 100, 220, 120), Color.Red, flagsX_Y);


            int total = hits + misses;
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font font2 = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(gr, "totalShots " + "" + total.ToString(), font2, new Rectangle(20, 40, 220, 20), Color.Red, flags);
            TextRenderer.DrawText(gr, "hits " + "" + hits.ToString(), font2, new Rectangle(20, 60, 220, 20), Color.Red, flags);
            TextRenderer.DrawText(gr, "misses " + "" + misses.ToString(), font2, new Rectangle(20, 80, 220, 20), Color.Red, flags);
            Graphics graf = e.Graphics;
            // graf.DrawImage(the_player, rectangle_player);

            //graf.FillRectangle(new SolidBrush(Color.BlueViolet), rectangle_player);
            player.paintPlayer(e);
            //  animal_Up.Paint_animal(e);
            for (int i = 0; i < list_animalup.Count; i++)
            {
                list_animalup[i].Paint_animal(e);
            }
        }

        private void FormPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            cursX = e.X;
            cursY = e.Y;
        }

     
    }

}
