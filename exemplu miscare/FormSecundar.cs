//#define My_debug
using exemplu_miscare.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace exemplu_miscare
{

    public partial class FormSecundar : Form
    {
        const int timeDeer = 20;
        
        const int dimImage=157;//latimea si lungimea imaginei care trebuie inpuscata
        const string folderDeer = "deer";
        const string folderRabbit = "rabbit_157";
        int totalShots=0;
        int hits=0;
        int misses = 0;
        bool splat = false;
        int splatTime = 0;
        int gameFrame = 0;//imagini deer 
        bool showDeer = false;
        int timeX = 1;
        int timeY = 1;
        Tree tree ;
        Forest forest;
        Canimal canimal;
        CSplat csplat;
        Trees trees;
        Thread th;
        bool hit_animals;
        int typeAnimal;
        int x1, y1;
        bool isBoat;
#if My_debug
        int cursX=0;
        int cursY=0;
        Random random = new Random();
#endif
        public FormSecundar(int x, int y, bool isBoot_ ,bool hit_animalsget, int typeAnimalget,int hitsin, int missesin)
        {
            InitializeComponent();
            tree = new Tree();
            forest = new Forest();
            tree.RandomBranches();
            hits = hitsin;
            misses = missesin;
            isBoat = isBoot_;
            hit_animals = hit_animalsget;
            typeAnimal = typeAnimalget;
            Bitmap b = new Bitmap(Properties.Resources.target2);
            this.Cursor = CustomCursor.CreateCursor(b, b.Height / 2, b.Width / 2);


            WindowState = FormWindowState.Maximized;
            Random rd = new Random();

            int nrImage = rd.Next(1, 3);
            x1 = x;
            y1 = y;
            this.BackgroundImage = Image.FromFile(@"ResourcesImage\campie" + nrImage + ".jpg");

          
            

            // cscore = new CScore() { Left = 30, Top = 160 };
            csplat = new CSplat();
            canimal = new Canimal(1, folderDeer) { Left = 40, Top = 400 };
            trees = new Trees();
            trees.Left = 120;
            trees.Top = 120;

                 
                if (hit_animals == true)
                {
                    
                    showDeer = true;
                }
            
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
            th = new Thread(openPrincipalForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();


        }

        private void timerDeer_Tick(object sender, EventArgs e)
        {

            if (showDeer == true && typeAnimal == 0)
            {
                timeX += timeDeer;
                timeY += 1;
                //  canimal = new Canimal() { Left = timeX, Top = timeY };


                canimal = new Canimal(gameFrame, folderDeer) { Left = timeX, Top = 400 };


                UpdateAnimal(timeX, 420 + timeY);
                if (gameFrame >= 3)
                {


                    gameFrame = 0;
                }

                if (splat)
                {
                    if (splatTime >= 3)
                    {

                        splat = false;
                        splatTime = 0;
                        // UpdateAnimal(timeX,400);

                    }
                    timerDeer.Stop();
                    splatTime++;
                }

            }
            else if(showDeer == true && typeAnimal == 1){
                timeX += timeDeer;
                timeY += 1;
                //  canimal = new Canimal() { Left = timeX, Top = timeY };


                canimal = new Canimal(gameFrame, folderRabbit) { Left = timeX, Top = 400 };


                UpdateAnimal(timeX, 420 + timeY);
                if (gameFrame >= 5)
                {


                    gameFrame = 0;
                }

                if (splat)
                {
                    if (splatTime >= 3)
                    {

                        splat = false;
                        splatTime = 0;
                        // UpdateAnimal(timeX,400);

                    }
                    timerDeer.Stop();
                    splatTime++;
                }

            }
            gameFrame++;
            Refresh();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
          
                if (splat == true)
                {
                    csplat.DrawImage(gr);
                }
                else if (showDeer== true)
                {
                    gr = e.Graphics;
                    canimal.DrawImage(gr);
                }
            
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            #if My_debug

            Font font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(gr, "x= " +cursX.ToString()+"|" + " Y= "+cursY.ToString(), font, new Rectangle(20, 20, 220, 120),Color.Red,flags);
            #endif
            Font font2 = new System.Drawing.Font("Stencil", 16, FontStyle.Regular);
            TextRenderer.DrawText(gr, "totalShots " +""+ totalShots.ToString() , font2, new Rectangle(20, 40, 220, 20), Color.Red, flags);
            TextRenderer.DrawText(gr, "hits " +""+hits.ToString()  , font2, new Rectangle(20, 60, 220, 20), Color.Red, flags);
            TextRenderer.DrawText(gr, "misses " +""+ misses.ToString(), font2, new Rectangle(20, 80, 220, 20), Color.Red, flags);



            //  cscore.DrawImage(gr);
         
            base.OnPaint(e);
            //imagine importata 
            // trees.DrawImage(gr);
            //tree.X = 400;
            //tree.Y = 400;
            //tree.DrawTree(e);
            forest.GeneratingForest(gr);
        }

        private void FormSecundar_MouseMove(object sender, MouseEventArgs e)
        {
           #if My_debug
            cursX = e.X;
            cursY = e.Y;
            #endif
         
        }

        private void FormSecundar_MouseClick(object sender, MouseEventArgs e)
        {
            if (showDeer == true)
            {
                if (e.X > 1256 && e.X < 1295 && e.Y > 634 && e.Y < 644)
                {
                    timerDeer.Start();
                }
                else if (e.X > 1256 && e.X < 1295 && e.Y > 654 && e.Y < 667)
                {
                    timerDeer.Stop();
                }
                else
                {
                    if (canimal.Hit(e.X, e.Y))
                    {
                        splat = true;
                        csplat.Left = canimal.Left - Resources.splat.Width / 3;
                        csplat.Top = canimal.Top - Resources.splat.Width / 3;
                        hits++;
                    }
                    else
                    {
                        misses++;
                    }


                    totalShots = misses + hits;
                }

            }
            else {
                // daca nu este nici un animal dar totusi dragi in gol
                this.Refresh();
                misses++;
                totalShots = misses + hits;

            }
           
            Firesound();

        }
        private void UpdateAnimal(int x,int y) {

            canimal.Uptate( x, y );

            
        }
        private void Firesound() {
            //fire off the shot 
          //  SoundPlayer soundShot = new SoundPlayer("ResourcesImage/shotgun.wav");
           // soundShot.Play();
        }

        private void FormSecundar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) {
                this.Close();
                th = new Thread(openPrincipalForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();


            }
        }

        private void openPrincipalForm()
        {
            Application.Run(new FormPrincipal(x1,y1,hits,misses,isBoat));
        }
    }
}
