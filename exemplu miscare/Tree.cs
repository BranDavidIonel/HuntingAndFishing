using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exemplu_miscare
{
    class Tree
    {
      
        int x;
        int y;
        int numberOfBranches;
        Random randomBranches = new Random();
    
       
       
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public int NumberOfBranches
        {
            get
            {
                return numberOfBranches;
            }

            set
            {
                numberOfBranches = value;
            }
        }

        public int  RandomBranches() {
            NumberOfBranches = randomBranches.Next(4, 9);
            return NumberOfBranches;
        }
        public void DrawTree(Graphics graphics)
        {
            

            
            int measureB = 20;
            int deepBranches=22;
         
            int h = Convert.ToInt16(measureB * Math.Sqrt(3) / 2);
            Point[] headTree = { new Point(X + 1, Y), new Point(X - 1, Y), new Point(X - 1, Y - 20), new Point(X + 1, Y - 20) };

            graphics.FillPolygon(new SolidBrush(Color.Green), headTree);
            for (int i = 0; i < NumberOfBranches; i++)
            {

                Point[] points2 = { new Point(X, Y), new Point(X - measureB/ 2, Y + h), new Point(X + measureB/ 2, Y + h) };


                Y += h - deepBranches;
                measureB = measureB + measureB/2;
                h = Convert.ToInt16(measureB * Math.Sqrt(3) / 2);
                h = h - h * 1/2;



                graphics.FillPolygon(new SolidBrush(Color.Green), points2);


            }
            Point[] tailTree = { new Point(X + 10, Y+deepBranches), new Point(X + 10, Y + 30), new Point(X - 10, Y + 30), new Point(X - 10, Y+deepBranches) };
            graphics.FillPolygon(new SolidBrush(Color.Brown), tailTree);


        }
    }
}

