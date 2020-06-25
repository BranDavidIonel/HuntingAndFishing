using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplu_miscare
{
    class Forest
    {
        int []x;
        int []y;
        //retin numarul de ramuri pentru fiecare copac
        int[] branches;
        Tree tree;
        Random randomX_Y;
        Random random_NrTrees;
 
        int numberOfTrees;
        const int mTop = 500;
        const int mDown = 730;
        const int mLeft = 0;
        const int mRight = 1800;

        public Forest()
        {
            randomX_Y = new Random();
            random_NrTrees = new Random();
            tree = new Tree();
            numberOfTrees = random_NrTrees.Next(1, 10);
            x = new int[numberOfTrees];
            y = new int[numberOfTrees];
            branches = new int[numberOfTrees];
            for (int i = 0; i < numberOfTrees; i++) {
                x[i] = randomX_Y.Next(mLeft, mRight);
                y[i] = randomX_Y.Next(mTop, mDown);
                branches[i] = tree.RandomBranches();

            }
           

        }
        public void GeneratingForest(Graphics graphics) {

            for (int i=0;i<numberOfTrees;i++) {
              
                tree.X = x[i];
                tree.Y = y[i];
                tree.NumberOfBranches = branches[i];
                tree.DrawTree(graphics);

            }

        }


    }
}
