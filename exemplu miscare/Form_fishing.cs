using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exemplu_miscare
{
    public partial class Form_fishing : Form
    {

     

     
        Thread th;
        //coordonatele pentru player
        int x1, y1;
        int hits = 0;
        int misses = 0;
        bool isBoat;
        Cloud cloud;

        public Form_fishing(int x, int y, int hits_, int misses_,bool isBoat_)
        {
            InitializeComponent();
            x1 = x;
            y1 = y;
            hits = hits_;
            misses=misses_;
            isBoat = isBoat_;
            WindowState = FormWindowState.Maximized;
            cloud = new Cloud();
            this.BackgroundImage = Image.FromFile(@"ResourcesImage\fishing1.jpg");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openPrincipalForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            cloud.DrawCloud(graphics, 40, 100);

        }
            private void openPrincipalForm()
        {
            Application.Run(new FormPrincipal(x1, y1, hits, misses,isBoat));
        }
    }
}
