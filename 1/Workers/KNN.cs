using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class KNN
    {

        double[,] scores = new double[10, 10];
        private List<Parkinson> _Parkinsons = new List<Parkinson>();
        public KNN(List<Parkinson> Parkinsons)
        {
            _Parkinsons = Parkinsons;

            //for (int i = 0; i < 10; i++)
            //{
            //    scores[i, 0] = _Parkinsons.Where(y => y.total_UPDRS == i).Select(x => x.FixedAcidity).ToList().Sum() / _Parkinsons.Count;
            //    scores[i, 1] = _Parkinsons.Where(y => y.QualityOriginal == i).Select(x => x.VolatileAcidity).ToList().Sum() / _Parkinsons.Count;
            //    scores[i, 2] = _Parkinsons.Where(y => y.QualityOriginal == i).Select(x => x.ResidualSugar).ToList().Sum() / _Parkinsons.Count;
            //    scores[i, 3] = _Parkinsons.Where(y => y.QualityOriginal == i).Select(x => x.Chlorides).ToList().Sum() / _Parkinsons.Count;
            //    scores[i, 4] = _Parkinsons.Where(y => y.QualityOriginal == i).Select(x => x.FreeSulfurDioxide).ToList().Sum() / _Parkinsons.Count;
            //    scores[i, 5] = _Parkinsons.Where(y => y.QualityOriginal == i).Select(x => x.TotalSulfurDioxide).ToList().Sum() / _Parkinsons.Count;
            //    scores[i, 6] = _Parkinsons.Where(y => y.QualityOriginal == i).Select(x => x.Density).ToList().Sum() / _Parkinsons.Count;
            //    scores[i, 7] = _Parkinsons.Where(y => y.QualityOriginal == i).Select(x => x.PH).ToList().Sum() / _Parkinsons.Count;
            //    scores[i, 8] = _Parkinsons.Where(y => y.QualityOriginal == i).Select(x => x.Sulphates).ToList().Sum() / _Parkinsons.Count;
            //    scores[i, 9] = _Parkinsons.Where(y => y.QualityOriginal == i).Select(x => x.Alcohol).ToList().Sum() / _Parkinsons.Count;
            //}
        }


        public double[] GetIndividualScore(Parkinson _Parkinson)
        {


            double CumulativeEuclideanDistance, CumulativeManhattanDistance, CumulativeMinkowskiDistance;

            foreach (Parkinson x in _Parkinsons)
            {

                CumulativeEuclideanDistance = Math.Sqrt(
                                                 Euclidean(x.age, _Parkinson.age) +
                                                 Euclidean(x.test_time, _Parkinson.test_time) +
                                                 //Euclidean(x.motor_UPDRS, _Parkinson.motor_UPDRS) +
                                                 //Euclidean(x.total_UPDRS, _Parkinson.total_UPDRS) +
                                                 Euclidean(x.Jitter_Pct, _Parkinson.Jitter_Pct) +
                                                 Euclidean(x.Jitter_Abs, _Parkinson.Jitter_Abs) +
                                                 Euclidean(x.Jitter_RAP, _Parkinson.Jitter_RAP) +
                                                 Euclidean(x.Jitter_PPQ5, _Parkinson.Jitter_PPQ5) +
                                                 Euclidean(x.Jitter_DDP, _Parkinson.Jitter_DDP) +
                                                 Euclidean(x.Shimmer, _Parkinson.Shimmer) +
                                                 Euclidean(x.Shimmer_dB, _Parkinson.Shimmer_dB) +
                                                 Euclidean(x.Shimmer_APQ3, _Parkinson.Shimmer_APQ3) +
                                                 Euclidean(x.Shimmer_APQ5, _Parkinson.Shimmer_APQ5) +
                                                 Euclidean(x.Shimmer_APQ11, _Parkinson.Shimmer_APQ11) +
                                                 Euclidean(x.Shimmer_DDA, _Parkinson.Shimmer_DDA) +
                                                 Euclidean(x.NHR, _Parkinson.NHR) +
                                                 Euclidean(x.HNR, _Parkinson.HNR) +
                                                 Euclidean(x.RPDE, _Parkinson.RPDE) +
                                                 Euclidean(x.DFA, _Parkinson.DFA) +
                                                 Euclidean(x.PPE, _Parkinson.PPE)

                                                 );

                x.temp1 = CumulativeEuclideanDistance;


                CumulativeManhattanDistance = Manhattan(x.age, _Parkinson.age) +
                                             Manhattan(x.test_time, _Parkinson.test_time) +
                                             //Manhattan(x.motor_UPDRS, _Parkinson.motor_UPDRS) +
                                             //Manhattan(x.total_UPDRS, _Parkinson.total_UPDRS) +
                                             Manhattan(x.Jitter_Pct, _Parkinson.Jitter_Pct) +
                                             Manhattan(x.Jitter_Abs, _Parkinson.Jitter_Abs) +
                                             Manhattan(x.Jitter_RAP, _Parkinson.Jitter_RAP) +
                                             Manhattan(x.Jitter_PPQ5, _Parkinson.Jitter_PPQ5) +
                                             Manhattan(x.Jitter_DDP, _Parkinson.Jitter_DDP) +
                                             Manhattan(x.Shimmer, _Parkinson.Shimmer) +
                                             Manhattan(x.Shimmer_dB, _Parkinson.Shimmer_dB) +
                                             Manhattan(x.Shimmer_APQ3, _Parkinson.Shimmer_APQ3) +
                                             Manhattan(x.Shimmer_APQ5, _Parkinson.Shimmer_APQ5) +
                                             Manhattan(x.Shimmer_APQ11, _Parkinson.Shimmer_APQ11) +
                                             Manhattan(x.Shimmer_DDA, _Parkinson.Shimmer_DDA) +
                                             Manhattan(x.NHR, _Parkinson.NHR) +
                                             Manhattan(x.HNR, _Parkinson.HNR) +
                                             Manhattan(x.RPDE, _Parkinson.RPDE) +
                                             Manhattan(x.DFA, _Parkinson.DFA) +
                                             Manhattan(x.PPE, _Parkinson.PPE);

                x.temp2 = CumulativeManhattanDistance;

                int orderForMinkowski = 2;

                CumulativeMinkowskiDistance = Math.Pow(
                                            Minkowski(x.age, _Parkinson.age, orderForMinkowski) +
                                             Minkowski(x.test_time, _Parkinson.test_time, orderForMinkowski) +
                                             //Minkowski(x.motor_UPDRS, _Parkinson.motor_UPDRS, orderForMinkowski) +
                                             //Minkowski(x.total_UPDRS, _Parkinson.total_UPDRS, orderForMinkowski) +
                                             Minkowski(x.Jitter_Pct, _Parkinson.Jitter_Pct, orderForMinkowski) +
                                             Minkowski(x.Jitter_Abs, _Parkinson.Jitter_Abs, orderForMinkowski) +
                                             Minkowski(x.Jitter_RAP, _Parkinson.Jitter_RAP, orderForMinkowski) +
                                             Minkowski(x.Jitter_PPQ5, _Parkinson.Jitter_PPQ5, orderForMinkowski) +
                                             Minkowski(x.Jitter_DDP, _Parkinson.Jitter_DDP, orderForMinkowski) +
                                             Minkowski(x.Shimmer, _Parkinson.Shimmer, orderForMinkowski) +
                                             Minkowski(x.Shimmer_dB, _Parkinson.Shimmer_dB, orderForMinkowski) +
                                             Minkowski(x.Shimmer_APQ3, _Parkinson.Shimmer_APQ3, orderForMinkowski) +
                                             Minkowski(x.Shimmer_APQ5, _Parkinson.Shimmer_APQ5, orderForMinkowski) +
                                             Minkowski(x.Shimmer_APQ11, _Parkinson.Shimmer_APQ11, orderForMinkowski) +
                                             Minkowski(x.Shimmer_DDA, _Parkinson.Shimmer_DDA, orderForMinkowski) +
                                             Minkowski(x.NHR, _Parkinson.NHR, orderForMinkowski) +
                                             Minkowski(x.HNR, _Parkinson.HNR, orderForMinkowski) +
                                             Minkowski(x.RPDE, _Parkinson.RPDE, orderForMinkowski) +
                                             Minkowski(x.DFA, _Parkinson.DFA, orderForMinkowski) +
                                             Minkowski(x.PPE, _Parkinson.PPE, orderForMinkowski)
                                             , (1 / orderForMinkowski));


                x.temp3 = CumulativeMinkowskiDistance;



            }

            double[] finalScores = new double[4];
            finalScores[0] = _Parkinsons.OrderBy(x => x.temp1).Take(5).ToList().Average(zy => zy.total_UPDRS);
            finalScores[1] = _Parkinsons.OrderBy(x => x.temp2).Take(5).ToList().Average(zy => zy.total_UPDRS);
            finalScores[2] = _Parkinsons.OrderBy(x => x.temp3).Take(5).ToList().Average(zy => zy.total_UPDRS);
            finalScores[3] = (int)_Parkinson.total_UPDRS;


            return finalScores;
        }

        public List<double[]> GetIndividualScore(List<Parkinson> _Parkinson)
        {

            List<double[]> testResults = new List<double[]>();

            double CumulativeEuclideanDistance, CumulativeManhattanDistance, CumulativeMinkowskiDistance;

            foreach (Parkinson y in _Parkinson)
            {
                foreach (Parkinson x in _Parkinson)
                {

                    

                    CumulativeEuclideanDistance = Math.Sqrt(
                                                 Euclidean(x.age, y.age) +
                                                 Euclidean(x.test_time, y.test_time) +
                                                 //Euclidean(x.motor_UPDRS, y.motor_UPDRS) +
                                                 //Euclidean(x.total_UPDRS, y.total_UPDRS) +
                                                 Euclidean(x.Jitter_Pct, y.Jitter_Pct) +
                                                 Euclidean(x.Jitter_Abs, y.Jitter_Abs) +
                                                 Euclidean(x.Jitter_RAP, y.Jitter_RAP) +
                                                 Euclidean(x.Jitter_PPQ5, y.Jitter_PPQ5) +
                                                 Euclidean(x.Jitter_DDP, y.Jitter_DDP) +
                                                 Euclidean(x.Shimmer, y.Shimmer)+
                                                 Euclidean(x.Shimmer_dB, y.Shimmer_dB) +
                                                 Euclidean(x.Shimmer_APQ3, y.Shimmer_APQ3) +
                                                 Euclidean(x.Shimmer_APQ5, y.Shimmer_APQ5) +
                                                 Euclidean(x.Shimmer_APQ11, y.Shimmer_APQ11) +
                                                 Euclidean(x.Shimmer_DDA, y.Shimmer_DDA) +
                                                 Euclidean(x.NHR, y.NHR)+
                                                 Euclidean(x.HNR, y.HNR) +
                                                 Euclidean(x.RPDE, y.RPDE) +
                                                 Euclidean(x.DFA, y.DFA) +
                                                 Euclidean(x.PPE, y.PPE) 
                                                 
                                                 );

                    x.temp1 = CumulativeEuclideanDistance;


                    CumulativeManhattanDistance = Manhattan(x.age, y.age) +
                                                 Manhattan(x.test_time, y.test_time) +
                                                 //Manhattan(x.motor_UPDRS, y.motor_UPDRS) +
                                                 //Manhattan(x.total_UPDRS, y.total_UPDRS) +
                                                 Manhattan(x.Jitter_Pct, y.Jitter_Pct) +
                                                 Manhattan(x.Jitter_Abs, y.Jitter_Abs) +
                                                 Manhattan(x.Jitter_RAP, y.Jitter_RAP) +
                                                 Manhattan(x.Jitter_PPQ5, y.Jitter_PPQ5) +
                                                 Manhattan(x.Jitter_DDP, y.Jitter_DDP) +
                                                 Manhattan(x.Shimmer, y.Shimmer) +
                                                 Manhattan(x.Shimmer_dB, y.Shimmer_dB) +
                                                 Manhattan(x.Shimmer_APQ3, y.Shimmer_APQ3) +
                                                 Manhattan(x.Shimmer_APQ5, y.Shimmer_APQ5) +
                                                 Manhattan(x.Shimmer_APQ11, y.Shimmer_APQ11) +
                                                 Manhattan(x.Shimmer_DDA, y.Shimmer_DDA) +
                                                 Manhattan(x.NHR, y.NHR) +
                                                 Manhattan(x.HNR, y.HNR) +
                                                 Manhattan(x.RPDE, y.RPDE) +
                                                 Manhattan(x.DFA, y.DFA) +
                                                 Manhattan(x.PPE, y.PPE);

                    x.temp2 = CumulativeManhattanDistance;

                    int orderForMinkowski = 2;

                    CumulativeMinkowskiDistance = Math.Pow(
                                                Minkowski(x.age, y.age, orderForMinkowski) +
                                                 Minkowski(x.test_time, y.test_time, orderForMinkowski) +
                                                 //Minkowski(x.motor_UPDRS, y.motor_UPDRS, orderForMinkowski) +
                                                 //Minkowski(x.total_UPDRS, y.total_UPDRS, orderForMinkowski) +
                                                 Minkowski(x.Jitter_Pct, y.Jitter_Pct, orderForMinkowski) +
                                                 Minkowski(x.Jitter_Abs, y.Jitter_Abs, orderForMinkowski) +
                                                 Minkowski(x.Jitter_RAP, y.Jitter_RAP, orderForMinkowski) +
                                                 Minkowski(x.Jitter_PPQ5, y.Jitter_PPQ5, orderForMinkowski) +
                                                 Minkowski(x.Jitter_DDP, y.Jitter_DDP, orderForMinkowski) +
                                                 Minkowski(x.Shimmer, y.Shimmer, orderForMinkowski) +
                                                 Minkowski(x.Shimmer_dB, y.Shimmer_dB, orderForMinkowski) +
                                                 Minkowski(x.Shimmer_APQ3, y.Shimmer_APQ3, orderForMinkowski) +
                                                 Minkowski(x.Shimmer_APQ5, y.Shimmer_APQ5, orderForMinkowski) +
                                                 Minkowski(x.Shimmer_APQ11, y.Shimmer_APQ11, orderForMinkowski) +
                                                 Minkowski(x.Shimmer_DDA, y.Shimmer_DDA, orderForMinkowski) +
                                                 Minkowski(x.NHR, y.NHR, orderForMinkowski) +
                                                 Minkowski(x.HNR, y.HNR, orderForMinkowski) +
                                                 Minkowski(x.RPDE, y.RPDE, orderForMinkowski) +
                                                 Minkowski(x.DFA, y.DFA, orderForMinkowski) +
                                                 Minkowski(x.PPE, y.PPE, orderForMinkowski)
                                                 , (1 / orderForMinkowski));


                    x.temp3 = CumulativeMinkowskiDistance;



                }


                double[] finalScores = new double[4];
                finalScores[0] = _Parkinson.OrderBy(x => x.temp1).Take(5).ToList().Average(zy => zy.total_UPDRS);
                finalScores[1] = _Parkinson.OrderBy(x => x.temp2).Take(5).ToList().Average(zy => zy.total_UPDRS);
                finalScores[2] = _Parkinson.OrderBy(x => x.temp3).Take(5).ToList().Average(zy => zy.total_UPDRS);
                finalScores[3] = y.total_UPDRS;
                testResults.Add(finalScores);
            }
            return testResults;
        }

        //public int[] GetNearestClusterScore(Wine _wine)
        //{


        //    double CurrentDistanceForEuclidean = 999999, CurrentDistanceForManhattan = 999999, CurrentDistanceForMinkowski = 999999;
        //    int CurrentScoreForEuclidean = 999999, CurrentScoreForManhattan = 999999, CurrentScoreForMinkowski = 999999;
        //    double CumulativeEuclideanDistance, CumulativeManhattanDistance, CumulativeMinkowskiDistance;




        //    for (int i = 0; i < 10; i++)
        //    {


        //        CumulativeEuclideanDistance = Math.Sqrt(Euclidean(scores[i, 0], _wine.FixedAcidity) +
        //                                     Euclidean(scores[i, 1], _wine.VolatileAcidity) +
        //                                     Euclidean(scores[i, 2], _wine.ResidualSugar) +
        //                                     Euclidean(scores[i, 3], _wine.Chlorides) +
        //                                     Euclidean(scores[i, 4], _wine.FreeSulfurDioxide) +
        //                                     Euclidean(scores[i, 5], _wine.TotalSulfurDioxide) +
        //                                     Euclidean(scores[i, 6], _wine.Density) +
        //                                     Euclidean(scores[i, 7], _wine.PH) +
        //                                     Euclidean(scores[i, 8], _wine.Sulphates) +
        //                                     Euclidean(scores[i, 9], _wine.Alcohol));

        //        if (CumulativeEuclideanDistance < CurrentDistanceForEuclidean)
        //        {
        //            CurrentScoreForEuclidean = i;
        //            CurrentDistanceForEuclidean = CumulativeEuclideanDistance;
        //        }


        //        CumulativeManhattanDistance =   Manhattan(scores[i, 0], _wine.FixedAcidity) +
        //                                     Manhattan(scores[i, 1], _wine.VolatileAcidity) +
        //                                     Manhattan(scores[i, 2], _wine.ResidualSugar) +
        //                                     Manhattan(scores[i, 3], _wine.Chlorides) +
        //                                     Manhattan(scores[i, 4], _wine.FreeSulfurDioxide) +
        //                                     Manhattan(scores[i, 5], _wine.TotalSulfurDioxide) +
        //                                     Manhattan(scores[i, 6], _wine.Density) +
        //                                     Manhattan(scores[i, 7], _wine.PH) +
        //                                     Manhattan(scores[i, 8], _wine.Sulphates) +
        //                                     Manhattan(scores[i, 9], _wine.Alcohol);

        //        if (CumulativeManhattanDistance < CurrentDistanceForManhattan)
        //        {
        //            CurrentScoreForManhattan = i;
        //            CurrentDistanceForManhattan = CumulativeManhattanDistance;
        //        }

        //        int orderForMinkowski = 2;

        //        CumulativeMinkowskiDistance = Math.Pow(  Minkowski(scores[i, 0], _wine.FixedAcidity, orderForMinkowski) +
        //                                     Minkowski(scores[i, 1], _wine.VolatileAcidity, orderForMinkowski) +
        //                                     Minkowski(scores[i, 2], _wine.ResidualSugar, orderForMinkowski) +
        //                                     Minkowski(scores[i, 3], _wine.Chlorides, orderForMinkowski) +
        //                                     Minkowski(scores[i, 4], _wine.FreeSulfurDioxide, orderForMinkowski) +
        //                                     Minkowski(scores[i, 5], _wine.TotalSulfurDioxide, orderForMinkowski) +
        //                                     Minkowski(scores[i, 6], _wine.Density, orderForMinkowski) +
        //                                     Minkowski(scores[i, 7], _wine.PH, orderForMinkowski) +
        //                                     Minkowski(scores[i, 8], _wine.Sulphates, orderForMinkowski) +
        //                                     Minkowski(scores[i, 9], _wine.Alcohol, orderForMinkowski),(1/ orderForMinkowski));

        //        if (CumulativeMinkowskiDistance < CurrentDistanceForMinkowski)
        //        {
        //            CurrentScoreForMinkowski = i;
        //            CurrentDistanceForMinkowski = CumulativeMinkowskiDistance;
        //        }


        //    }

        //    int[] finalScores = new int[4];
        //    finalScores[0] = CurrentScoreForEuclidean;
        //    finalScores[1] = CurrentScoreForManhattan;
        //    finalScores[2] = CurrentScoreForMinkowski;
        //    finalScores[3] = (int)_wine.QualityOriginal;

        //    return finalScores;
        //}

        //public List<int[]> GetNearestClusterScore(List<Wine> _wine)
        //{

        //    List<int[]> testResults = new List<int[]>();
        //    double CurrentDistanceForEuclidean = 999999, CurrentDistanceForManhattan = 999999, CurrentDistanceForMinkowski = 999999;
        //    int CurrentScoreForEuclidean = 999999, CurrentScoreForManhattan = 999999, CurrentScoreForMinkowski = 999999;
        //    double CumulativeEuclideanDistance, CumulativeManhattanDistance, CumulativeMinkowskiDistance;


        //    foreach (Wine y in _wine)
        //    {

        //        for (int i = 0; i < 10; i++)
        //        {


        //            CumulativeEuclideanDistance = Math.Sqrt( Euclidean(scores[i, 0], y.FixedAcidity) +
        //                                                     Euclidean(scores[i, 1], y.VolatileAcidity) +
        //                                                     Euclidean(scores[i, 2], y.ResidualSugar) +
        //                                                     Euclidean(scores[i, 3], y.Chlorides) +
        //                                                     Euclidean(scores[i, 4], y.FreeSulfurDioxide) +
        //                                                     Euclidean(scores[i, 5], y.TotalSulfurDioxide) +
        //                                                     Euclidean(scores[i, 6], y.Density) +
        //                                                     Euclidean(scores[i, 7], y.PH) +
        //                                                     Euclidean(scores[i, 8], y.Sulphates) +
        //                                                     Euclidean(scores[i, 9], y.Alcohol));

        //            if (CumulativeEuclideanDistance < CurrentDistanceForEuclidean)
        //            {
        //                CurrentScoreForEuclidean = i;
        //                CurrentDistanceForEuclidean = CumulativeEuclideanDistance;
        //            }


        //            CumulativeManhattanDistance = Manhattan(scores[i, 0], y.FixedAcidity) +
        //                                          Manhattan(scores[i, 1], y.VolatileAcidity) +
        //                                          Manhattan(scores[i, 2], y.ResidualSugar) +
        //                                          Manhattan(scores[i, 3], y.Chlorides) +
        //                                          Manhattan(scores[i, 4], y.FreeSulfurDioxide) +
        //                                          Manhattan(scores[i, 5], y.TotalSulfurDioxide) +
        //                                          Manhattan(scores[i, 6], y.Density) +
        //                                          Manhattan(scores[i, 7], y.PH) +
        //                                          Manhattan(scores[i, 8], y.Sulphates) +
        //                                          Manhattan(scores[i, 9], y.Alcohol);

        //            if (CumulativeManhattanDistance < CurrentDistanceForManhattan)
        //            {
        //                CurrentScoreForManhattan = i;
        //                CurrentDistanceForManhattan = CumulativeManhattanDistance;
        //            }

        //            double orderForMinkowski = 2;

        //            CumulativeMinkowskiDistance = Math.Pow(  Minkowski(scores[i, 0], y.FixedAcidity, orderForMinkowski) +
        //                                                     Minkowski(scores[i, 1], y.VolatileAcidity, orderForMinkowski) +
        //                                                     Minkowski(scores[i, 2], y.ResidualSugar, orderForMinkowski) +
        //                                                     Minkowski(scores[i, 3], y.Chlorides, orderForMinkowski) +
        //                                                     Minkowski(scores[i, 4], y.FreeSulfurDioxide, orderForMinkowski) +
        //                                                     Minkowski(scores[i, 5], y.TotalSulfurDioxide, orderForMinkowski) +
        //                                                     Minkowski(scores[i, 6], y.Density, orderForMinkowski) +
        //                                                     Minkowski(scores[i, 7], y.PH, orderForMinkowski) +
        //                                                     Minkowski(scores[i, 8], y.Sulphates, orderForMinkowski) +
        //                                                     Minkowski(scores[i, 9], y.Alcohol, orderForMinkowski), (1 / orderForMinkowski));

        //            if (CumulativeMinkowskiDistance < CurrentDistanceForMinkowski)
        //            {
        //                CurrentScoreForMinkowski = i;
        //                CurrentDistanceForMinkowski = CumulativeMinkowskiDistance;
        //            }


        //        }

        //        int[] finalScores = new int[4];
        //        finalScores[0] = CurrentScoreForEuclidean;
        //        finalScores[1] = CurrentScoreForManhattan;
        //        finalScores[2] = CurrentScoreForMinkowski;
        //        finalScores[3] = (int)y.QualityOriginal;
        //        testResults.Add(finalScores);

        //    }
        //    return testResults;
        //}

        private double Euclidean(double x, double y)
        {
            return Math.Pow(x - y, 2);
        }

        private double Manhattan(double x, double y)
        {
            return Math.Abs(x - y);
        }

        private double Minkowski(double x, double y, double order)
        {
            return Math.Pow(Math.Abs(x - y), order);
        }



    }
}
