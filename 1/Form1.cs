using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataPrep asdasd = new DataPrep();
            asdasd.Initialize();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////// K-NN & K-Means ///////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////

            StringBuilder result = new StringBuilder();
            Random rnd = new Random();

            List<int[]> RandomSample = new List<int[]>();

            List<Parkinson> ParkinsonTrainSet = new List<Parkinson>();
            
            List<Parkinson> ParkinsonTestSet = new List<Parkinson>();



            double ErrorEuclidean = 0, ErrorManhattan = 0, ErrorMinkowski = 0;
            int CorrectEuclidean = 0, CorrectManhattan = 0, CorrectMinkowski = 0;
            int FalseEuclidean = 0, FalseManhattan = 0, FalseMinkowski = 0;


            int sayac = Convert.ToInt32(numericUpDown1.Value);

            for (int i = 0; i < sayac; i++)
            {
                DataPrep dprp = new DataPrep();
                dprp.Initialize();

                ParkinsonTrainSet = dprp.ParkinsonTrainSet;
                ParkinsonTestSet = dprp.ParkinsonTestSet;
                KNN KNNRParkinson = new KNN(ParkinsonTrainSet);
                List<double[]> results = KNNRParkinson.GetIndividualScore(ParkinsonTestSet);
                result.AppendLine("Run " + (i + 1) + " - Normalised : ");
                result.AppendLine("");


                ErrorEuclidean = results.Sum(x => (double)Math.Abs(x[0] - x[3])) / (double)results.Count;
                ErrorManhattan = results.Sum(x => (double)Math.Abs(x[1] - x[3])) / (double)results.Count;
                ErrorMinkowski = results.Sum(x => (double)Math.Abs(x[2] - x[3])) / (double)results.Count;

                CorrectEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) <= 1).Count();
                CorrectManhattan = results.Where(x => Math.Abs(x[1] - x[3]) <= 1).Count();
                CorrectMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) <= 1).Count();

                FalseEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) > 1).Count();
                FalseManhattan = results.Where(x => Math.Abs(x[1] - x[3]) > 1).Count();
                FalseMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) > 1).Count();
                result.AppendLine("Parkinson Individual Average Error");
                result.AppendLine("for Euclidean : " + ErrorEuclidean.ToString());
                result.AppendLine("for Manhattan : " + ErrorManhattan.ToString());
                result.AppendLine("for Minkowski : " + ErrorMinkowski.ToString());
                result.AppendLine(
                    "Parkinsons Individual Average Euclidean Error : " + ErrorEuclidean +
                    ", Correct Count : " + CorrectEuclidean + "(" + CorrectEuclidean * 100 / ParkinsonTestSet.Count + "%)" +
                    ", False Count : " + FalseEuclidean + "(" + FalseEuclidean * 100 / ParkinsonTestSet.Count + "%)");
                result.AppendLine(
                    "Parkinsons Individual Average Manhattan Error : " + ErrorManhattan +
                    ", Correct Count : " + CorrectManhattan + "(" + CorrectManhattan * 100 / ParkinsonTestSet.Count + "%)" +
                    ", False Count : " + FalseManhattan + "(" + FalseManhattan * 100 / ParkinsonTestSet.Count + "%)");
                result.AppendLine(
                    "Parkinsons Individual Average Minkowski Error : " + ErrorMinkowski +
                    ", Correct Count : " + CorrectMinkowski + "(" + CorrectMinkowski * 100 / ParkinsonTestSet.Count + "%)" +
                    ", False Count : " + FalseMinkowski + "(" + FalseMinkowski * 100 / ParkinsonTestSet.Count + "%)");

                result.AppendLine("Parkinsons Individual scores");
                //RandomSample = results.OrderBy(user => rnd.Next()).Take(5).ToList();
                foreach (double[] item in results)
                {
                    result.AppendLine(String.Format("Euclidean : {0}, Manhattan : {1}, Minkowski : {2}, Original : {3}", item[0], item[1], item[2], item[3]));
                }
                result.AppendLine();
                //results = KNNRedWine.GetNearestClusterScore(RedWineTestSet);

                //ErrorEuclidean = results.Sum(x => (double)Math.Abs(x[0] - x[3])) / (double)results.Count;
                //ErrorManhattan = results.Sum(x => (double)Math.Abs(x[1] - x[3])) / (double)results.Count;
                //ErrorMinkowski = results.Sum(x => (double)Math.Abs(x[2] - x[3])) / (double)results.Count;

                //CorrectEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) <= 1).Count();
                //CorrectManhattan = results.Where(x => Math.Abs(x[1] - x[3]) <= 1).Count();
                //CorrectMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) <= 1).Count();

                //FalseEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) > 1).Count();
                //FalseManhattan = results.Where(x => Math.Abs(x[1] - x[3]) > 1).Count();
                //FalseMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) > 1).Count();
                //result.AppendLine("Parkinsons Cluster Average Error");
                //result.AppendLine("for Euclidean : " + ErrorEuclidean.ToString());
                //result.AppendLine("for Manhattan : " + ErrorManhattan.ToString());
                //result.AppendLine("for Minkowski : " + ErrorMinkowski.ToString());
                //result.AppendLine(
                //    "Parkinsons Nearest Cluster Average Euclidean Error : " + ErrorEuclidean +
                //    ", Correct Count : " + CorrectEuclidean + "(" + CorrectEuclidean * 100 / RedWineTestSet.Count + "%)" +
                //    ", False Count : " + FalseEuclidean + "(" + FalseEuclidean * 100 / RedWineTestSet.Count + "%)");
                //result.AppendLine(
                //    "Parkinsons Nearest Cluster Average Manhattan Error : " + ErrorManhattan +
                //    ", Correct Count : " + CorrectManhattan + "(" + CorrectManhattan * 100 / RedWineTestSet.Count + "%)" +
                //    ", False Count : " + FalseManhattan + "(" + FalseManhattan * 100 / RedWineTestSet.Count + "%)");
                //result.AppendLine(
                //    "Parkinsons Nearest Cluster Average Minkowski Error : " + ErrorMinkowski +
                //    ", Correct Count : " + CorrectMinkowski + "(" + CorrectMinkowski * 100 / RedWineTestSet.Count + "%)" +
                //    ", False Count : " + FalseMinkowski + "(" + FalseMinkowski * 100 / RedWineTestSet.Count + "%)");

                ////RandomSample = results.OrderBy(user => rnd.Next()).Take(5).ToList();
                //foreach (int[] item in results)
                //{
                //    result.AppendLine(String.Format("Euclidean : {0}, Manhattan : {1}, Minkowski : {2}, Original : {3}", item[0], item[1], item[2], item[3]));
                //}
                //result.AppendLine();



               
                dprp.Initialize(1);

                ParkinsonTrainSet = dprp.ParkinsonTrainSet;
                ParkinsonTestSet = dprp.ParkinsonTestSet;
                
                results = KNNRParkinson.GetIndividualScore(ParkinsonTestSet);
                result.AppendLine("Run " + (i + 1) + " - No Normalisation : ");
                result.AppendLine("");


                ErrorEuclidean = results.Sum(x => (double)Math.Abs(x[0] - x[3])) / (double)results.Count;
                ErrorManhattan = results.Sum(x => (double)Math.Abs(x[1] - x[3])) / (double)results.Count;
                ErrorMinkowski = results.Sum(x => (double)Math.Abs(x[2] - x[3])) / (double)results.Count;

                CorrectEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) <= 1).Count();
                CorrectManhattan = results.Where(x => Math.Abs(x[1] - x[3]) <= 1).Count();
                CorrectMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) <= 1).Count();

                FalseEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) > 1).Count();
                FalseManhattan = results.Where(x => Math.Abs(x[1] - x[3]) > 1).Count();
                FalseMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) > 1).Count();
                result.AppendLine("Parkinson Individual Average Error");
                result.AppendLine("for Euclidean : " + ErrorEuclidean.ToString());
                result.AppendLine("for Manhattan : " + ErrorManhattan.ToString());
                result.AppendLine("for Minkowski : " + ErrorMinkowski.ToString());
                result.AppendLine(
                    "Parkinsons Individual Average Euclidean Error : " + ErrorEuclidean +
                    ", Correct Count : " + CorrectEuclidean + "(" + CorrectEuclidean * 100 / ParkinsonTestSet.Count + "%)" +
                    ", False Count : " + FalseEuclidean + "(" + FalseEuclidean * 100 / ParkinsonTestSet.Count + "%)");
                result.AppendLine(
                    "Parkinsons Individual Average Manhattan Error : " + ErrorManhattan +
                    ", Correct Count : " + CorrectManhattan + "(" + CorrectManhattan * 100 / ParkinsonTestSet.Count + "%)" +
                    ", False Count : " + FalseManhattan + "(" + FalseManhattan * 100 / ParkinsonTestSet.Count + "%)");
                result.AppendLine(
                    "Parkinsons Individual Average Minkowski Error : " + ErrorMinkowski +
                    ", Correct Count : " + CorrectMinkowski + "(" + CorrectMinkowski * 100 / ParkinsonTestSet.Count + "%)" +
                    ", False Count : " + FalseMinkowski + "(" + FalseMinkowski * 100 / ParkinsonTestSet.Count + "%)");

                result.AppendLine("Parkinsons Individual scores");
                //RandomSample = results.OrderBy(user => rnd.Next()).Take(5).ToList();
                foreach (double[] item in results)
                {
                    result.AppendLine(String.Format("Euclidean : {0}, Manhattan : {1}, Minkowski : {2}, Original : {3}", item[0], item[1], item[2], item[3]));
                }
                result.AppendLine();
                //results = KNNRedWine.GetNearestClusterScore(RedWineTestSet);

                //ErrorEuclidean = results.Sum(x => (double)Math.Abs(x[0] - x[3])) / (double)results.Count;
                //ErrorManhattan = results.Sum(x => (double)Math.Abs(x[1] - x[3])) / (double)results.Count;
                //ErrorMinkowski = results.Sum(x => (double)Math.Abs(x[2] - x[3])) / (double)results.Count;

                //CorrectEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) <= 1).Count();
                //CorrectManhattan = results.Where(x => Math.Abs(x[1] - x[3]) <= 1).Count();
                //CorrectMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) <= 1).Count();

                //FalseEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) > 1).Count();
                //FalseManhattan = results.Where(x => Math.Abs(x[1] - x[3]) > 1).Count();
                //FalseMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) > 1).Count();
                //result.AppendLine("Parkinsons Cluster Average Error");
                //result.AppendLine("for Euclidean : " + ErrorEuclidean.ToString());
                //result.AppendLine("for Manhattan : " + ErrorManhattan.ToString());
                //result.AppendLine("for Minkowski : " + ErrorMinkowski.ToString());
                //result.AppendLine(
                //    "Parkinsons Nearest Cluster Average Euclidean Error : " + ErrorEuclidean +
                //    ", Correct Count : " + CorrectEuclidean + "(" + CorrectEuclidean * 100 / RedWineTestSet.Count + "%)" +
                //    ", False Count : " + FalseEuclidean + "(" + FalseEuclidean * 100 / RedWineTestSet.Count + "%)");
                //result.AppendLine(
                //    "Parkinsons Nearest Cluster Average Manhattan Error : " + ErrorManhattan +
                //    ", Correct Count : " + CorrectManhattan + "(" + CorrectManhattan * 100 / RedWineTestSet.Count + "%)" +
                //    ", False Count : " + FalseManhattan + "(" + FalseManhattan * 100 / RedWineTestSet.Count + "%)");
                //result.AppendLine(
                //    "Parkinsons Nearest Cluster Average Minkowski Error : " + ErrorMinkowski +
                //    ", Correct Count : " + CorrectMinkowski + "(" + CorrectMinkowski * 100 / RedWineTestSet.Count + "%)" +
                //    ", False Count : " + FalseMinkowski + "(" + FalseMinkowski * 100 / RedWineTestSet.Count + "%)");

                ////RandomSample = results.OrderBy(user => rnd.Next()).Take(5).ToList();
                //foreach (int[] item in results)
                //{
                //    result.AppendLine(String.Format("Euclidean : {0}, Manhattan : {1}, Minkowski : {2}, Original : {3}", item[0], item[1], item[2], item[3]));
                //}
                //result.AppendLine();

                



            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Output.txt", true))
            {
                file.WriteLine(result.ToString());
            }
            textBox1.Text = result.ToString();
            result.Clear();


            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////// K-NN & K-Means ///////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////


        }
    }
}
