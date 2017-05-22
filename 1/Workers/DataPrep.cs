using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class DataPrep
    {
        public List<Parkinson> ParkinsonTrainSet = new List<Parkinson>();
        public List<Parkinson> ParkinsonTestSet = new List<Parkinson>();
        private List<Parkinson> ParkinsonAllSet = new List<Parkinson>();
        private List<Parkinson> ParkinsonOriginalSet = new List<Parkinson>();
        public List<Parkinson> ParkinsonOriginalSetTransformed = new List<Parkinson>();


        


        public DataPrep()
        {
            

        }

        public void Initialize(int normalize = 1)
        {
            ExtractData();
            TransformData();
            if(normalize == 1)
                ParkinsonOriginalSetTransformed = NormalizeData(ParkinsonOriginalSetTransformed);
            SeperateTestData(ParkinsonOriginalSetTransformed);

        }

        

        private void ExtractData()
        {
            

            var reader = new StreamReader(File.OpenRead(@"D:\parkinsons_updrs.data"));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                //line = line.Replace(".", ",");
                var values = line.Split(',');

                Parkinson newParkinson = new Parkinson();

                newParkinson.subject = Convert.ToInt32(values[0]);
                newParkinson.age = Convert.ToInt32(values[1]);
                newParkinson.sex = Convert.ToInt32(values[2]);
                //newParkinson.test_time = Convert.ToDouble(values[3]);
                //newParkinson.motor_UPDRS = Convert.ToDouble(values[4]);
                //newParkinson.total_UPDRS = Convert.ToDouble(values[5]);
                //newParkinson.Jitter_Pct = Convert.ToDouble(values[6]);
                //newParkinson.Jitter_Abs = Convert.ToDouble(values[7]);
                //newParkinson.Jitter_RAP = Convert.ToDouble(values[8]);
                //newParkinson.Jitter_PPQ5 = Convert.ToDouble(values[9]);
                //newParkinson.Jitter_DDP = Convert.ToDouble(values[10]);
                //newParkinson.Shimmer = Convert.ToDouble(values[11]);
                //newParkinson.Shimmer_dB = Convert.ToDouble(values[12]);
                //newParkinson.Shimmer_APQ3 = Convert.ToDouble(values[13]);
                //newParkinson.Shimmer_APQ5 = Convert.ToDouble(values[14]);
                //newParkinson.Shimmer_APQ11 = Convert.ToDouble(values[15]);
                //newParkinson.Shimmer_DDA = Convert.ToDouble(values[16]);
                //newParkinson.NHR = Convert.ToDouble(values[17]);
                //newParkinson.HNR = Convert.ToDouble(values[18]);
                //newParkinson.RPDE = Convert.ToDouble(values[19]);
                //newParkinson.DFA = Convert.ToDouble(values[20]);
                //newParkinson.PPE = Convert.ToDouble(values[21]);

                newParkinson.test_time = double.Parse(values[3], CultureInfo.InvariantCulture);
                newParkinson.motor_UPDRS = double.Parse(values[4], CultureInfo.InvariantCulture);
                newParkinson.total_UPDRS = double.Parse(values[5], CultureInfo.InvariantCulture);
                newParkinson.Jitter_Pct = double.Parse(values[6], CultureInfo.InvariantCulture);
                newParkinson.Jitter_Abs = double.Parse(values[7], CultureInfo.InvariantCulture);
                newParkinson.Jitter_RAP = double.Parse(values[8], CultureInfo.InvariantCulture);
                newParkinson.Jitter_PPQ5 = double.Parse(values[9], CultureInfo.InvariantCulture);
                newParkinson.Jitter_DDP = double.Parse(values[10], CultureInfo.InvariantCulture);
                newParkinson.Shimmer = double.Parse(values[11], CultureInfo.InvariantCulture);
                newParkinson.Shimmer_dB = double.Parse(values[12], CultureInfo.InvariantCulture);
                newParkinson.Shimmer_APQ3 = double.Parse(values[13], CultureInfo.InvariantCulture);
                newParkinson.Shimmer_APQ5 = double.Parse(values[14], CultureInfo.InvariantCulture);
                newParkinson.Shimmer_APQ11 = double.Parse(values[15], CultureInfo.InvariantCulture);
                newParkinson.Shimmer_DDA = double.Parse(values[16], CultureInfo.InvariantCulture);
                newParkinson.NHR = double.Parse(values[17], CultureInfo.InvariantCulture);
                newParkinson.HNR = double.Parse(values[18], CultureInfo.InvariantCulture);
                newParkinson.RPDE = double.Parse(values[19], CultureInfo.InvariantCulture);
                newParkinson.DFA = double.Parse(values[20], CultureInfo.InvariantCulture);
                newParkinson.PPE = double.Parse(values[21], CultureInfo.InvariantCulture);
                //double.Parse("0.5e10", CultureInfo.InvariantCulture)
                ParkinsonOriginalSet.Add(newParkinson);


            }


        }


        private void TransformData()
        {


            int AutoID = 0;

            foreach (Parkinson newParkinson in ParkinsonOriginalSet)
            {
                ParkinsonOriginalSetTransformed.Add(
                        new Parkinson()
                        {
                           
                            RowID = AutoID,
                            subject = newParkinson.subject,
                            age = newParkinson.age,
                            sex = newParkinson.sex,
                            test_time = newParkinson.test_time,
                            motor_UPDRS = newParkinson.motor_UPDRS,
                            total_UPDRS = newParkinson.total_UPDRS,
                            Jitter_Pct = newParkinson.Jitter_Pct,
                            Jitter_Abs = newParkinson.Jitter_Abs,
                            Jitter_RAP = newParkinson.Jitter_RAP,
                            Jitter_PPQ5 = newParkinson.Jitter_PPQ5,
                            Jitter_DDP = newParkinson.Jitter_DDP,
                            Shimmer = newParkinson.Shimmer,
                            Shimmer_dB = newParkinson.Shimmer_dB,
                            Shimmer_APQ3 = newParkinson.Shimmer_APQ3,
                            Shimmer_APQ5 = newParkinson.Shimmer_APQ5,
                            Shimmer_APQ11 = newParkinson.Shimmer_APQ11,
                            Shimmer_DDA = newParkinson.Shimmer_DDA,
                            NHR = newParkinson.NHR,
                            HNR = newParkinson.HNR,
                            RPDE = newParkinson.RPDE,
                            DFA = newParkinson.DFA,
                            PPE = newParkinson.PPE
                        }
                    );
                AutoID++;

            }

        }



        private void SeperateTestData(List<Parkinson> Parkinsons)
        {
            Random rnd = new Random();

            int testCountParkinson = ParkinsonOriginalSet.Count() / 5;

            ParkinsonTestSet = Parkinsons.OrderBy(user => rnd.Next()).Take(testCountParkinson).ToList();
            ParkinsonTrainSet = Parkinsons.Where(x => !ParkinsonTestSet.Any(y => y.RowID == x.RowID)).ToList();
            
        }


        private List<Parkinson> NormalizeData(List<Parkinson> Parkinsons)
        {
            double age_Mean, test_time_Mean, motor_UPDRS_Mean, total_UPDRS_Mean, Jitter_Pct_Mean, Jitter_Abs_Mean, Jitter_RAP_Mean, Jitter_PPQ5_Mean, Jitter_DDP_Mean, Shimmer_Mean,
                   Shimmer_dB_Mean, Shimmer_APQ3_Mean, Shimmer_APQ5_Mean, Shimmer_APQ11_Mean, Shimmer_DDA_Mean, NHR_Mean, HNR_Mean, RPDE_Mean, DFA_Mean, PPE_Mean;

            double age_StdDev, test_time_StdDev, motor_UPDRS_StdDev, total_UPDRS_StdDev, Jitter_Pct_StdDev, Jitter_Abs_StdDev, Jitter_RAP_StdDev, Jitter_PPQ5_StdDev, Jitter_DDP_StdDev, Shimmer_StdDev,
                   Shimmer_dB_StdDev, Shimmer_APQ3_StdDev, Shimmer_APQ5_StdDev, Shimmer_APQ11_StdDev, Shimmer_DDA_StdDev, NHR_StdDev, HNR_StdDev, RPDE_StdDev, DFA_StdDev, PPE_StdDev;

      

            age_Mean = Parkinsons.Select(x => x.age).ToList().Sum() / Parkinsons.Count;
            test_time_Mean = Parkinsons.Select(x => x.test_time).ToList().Sum() / Parkinsons.Count;
            motor_UPDRS_Mean = Parkinsons.Select(x => x.motor_UPDRS).ToList().Sum() / Parkinsons.Count;
            total_UPDRS_Mean = Parkinsons.Select(x => x.total_UPDRS).ToList().Sum() / Parkinsons.Count;
            Jitter_Pct_Mean = Parkinsons.Select(x => x.Jitter_Pct).ToList().Sum() / Parkinsons.Count;
            Jitter_Abs_Mean = Parkinsons.Select(x => x.Jitter_Abs).ToList().Sum() / Parkinsons.Count;
            Jitter_RAP_Mean = Parkinsons.Select(x => x.Jitter_RAP).ToList().Sum() / Parkinsons.Count;
            Jitter_PPQ5_Mean = Parkinsons.Select(x => x.Jitter_PPQ5).ToList().Sum() / Parkinsons.Count;
            Jitter_DDP_Mean = Parkinsons.Select(x => x.Jitter_DDP).ToList().Sum() / Parkinsons.Count;
            Shimmer_Mean = Parkinsons.Select(x => x.Shimmer).ToList().Sum() / Parkinsons.Count;
            Shimmer_dB_Mean = Parkinsons.Select(x => x.Shimmer_dB).ToList().Sum() / Parkinsons.Count;
            Shimmer_APQ3_Mean = Parkinsons.Select(x => x.Shimmer_APQ3).ToList().Sum() / Parkinsons.Count;
            Shimmer_APQ5_Mean = Parkinsons.Select(x => x.Shimmer_APQ5).ToList().Sum() / Parkinsons.Count;
            Shimmer_APQ11_Mean = Parkinsons.Select(x => x.Shimmer_APQ11).ToList().Sum() / Parkinsons.Count;
            Shimmer_DDA_Mean = Parkinsons.Select(x => x.Shimmer_DDA).ToList().Sum() / Parkinsons.Count;
            NHR_Mean = Parkinsons.Select(x => x.NHR).ToList().Sum() / Parkinsons.Count;
            HNR_Mean = Parkinsons.Select(x => x.HNR).ToList().Sum() / Parkinsons.Count;
            RPDE_Mean = Parkinsons.Select(x => x.RPDE).ToList().Sum() / Parkinsons.Count;
            DFA_Mean = Parkinsons.Select(x => x.DFA).ToList().Sum() / Parkinsons.Count;
            PPE_Mean = Parkinsons.Select(x => x.PPE).ToList().Sum() / Parkinsons.Count;


            age_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.age - age_Mean, 2)) / Parkinsons.Count);
            test_time_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.test_time - test_time_Mean, 2)) / Parkinsons.Count);
            motor_UPDRS_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.motor_UPDRS - motor_UPDRS_Mean, 2)) / Parkinsons.Count);
            total_UPDRS_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.total_UPDRS - total_UPDRS_Mean, 2)) / Parkinsons.Count);
            Jitter_Pct_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.Jitter_Pct - Jitter_Pct_Mean, 2)) / Parkinsons.Count);
            Jitter_Abs_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.Jitter_Abs - Jitter_Abs_Mean, 2)) / Parkinsons.Count);
            Jitter_RAP_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.Jitter_RAP - Jitter_RAP_Mean, 2)) / Parkinsons.Count);
            Jitter_PPQ5_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.Jitter_PPQ5 - Jitter_PPQ5_Mean, 2)) / Parkinsons.Count);
            Jitter_DDP_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.Jitter_DDP - Jitter_DDP_Mean, 2)) / Parkinsons.Count);
            Shimmer_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.Shimmer - Shimmer_Mean, 2)) / Parkinsons.Count);
            Shimmer_dB_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.Shimmer_dB - Shimmer_dB_Mean, 2)) / Parkinsons.Count);
            Shimmer_APQ3_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.Shimmer_APQ3 - Shimmer_APQ3_Mean, 2)) / Parkinsons.Count);
            Shimmer_APQ5_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.Shimmer_APQ5 - Shimmer_APQ5_Mean, 2)) / Parkinsons.Count);
            Shimmer_APQ11_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.Shimmer_APQ11 - Shimmer_APQ11_Mean, 2)) / Parkinsons.Count);
            Shimmer_DDA_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.Shimmer_DDA - Shimmer_DDA_Mean, 2)) / Parkinsons.Count);
            NHR_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.NHR - NHR_Mean, 2)) / Parkinsons.Count);
            HNR_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.HNR - HNR_Mean, 2)) / Parkinsons.Count);
            RPDE_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.RPDE - RPDE_Mean, 2)) / Parkinsons.Count);
            DFA_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.DFA - DFA_Mean, 2)) / Parkinsons.Count);
            PPE_StdDev = Math.Sqrt(Parkinsons.Sum(x => Math.Pow(x.PPE - PPE_Mean, 2)) / Parkinsons.Count);





            Parkinsons.ToList().ForEach(x => x.age = Convert.ToSingle(((x.age) - age_Mean) / age_StdDev));
            Parkinsons.ToList().ForEach(x => x.test_time = Convert.ToSingle(((x.test_time) - test_time_Mean) / test_time_StdDev));
            Parkinsons.ToList().ForEach(x => x.motor_UPDRS = Convert.ToSingle(((x.motor_UPDRS) - motor_UPDRS_Mean) / motor_UPDRS_StdDev));
            Parkinsons.ToList().ForEach(x => x.total_UPDRS = Convert.ToSingle(((x.total_UPDRS) - total_UPDRS_Mean) / total_UPDRS_StdDev));
            Parkinsons.ToList().ForEach(x => x.Jitter_Pct = Convert.ToSingle(((x.Jitter_Pct) - Jitter_Pct_Mean) / Jitter_Pct_StdDev));
            Parkinsons.ToList().ForEach(x => x.Jitter_Abs = Convert.ToSingle(((x.Jitter_Abs) - Jitter_Abs_Mean) / Jitter_Abs_StdDev));
            Parkinsons.ToList().ForEach(x => x.Jitter_RAP = Convert.ToSingle(((x.Jitter_RAP) - Jitter_RAP_Mean) / Jitter_RAP_StdDev));
            Parkinsons.ToList().ForEach(x => x.Jitter_PPQ5 = Convert.ToSingle(((x.Jitter_PPQ5) - Jitter_PPQ5_Mean) / Jitter_PPQ5_StdDev));
            Parkinsons.ToList().ForEach(x => x.Jitter_DDP = Convert.ToSingle(((x.Jitter_DDP) - Jitter_DDP_Mean) / Jitter_DDP_StdDev));
            Parkinsons.ToList().ForEach(x => x.Shimmer = Convert.ToSingle(((x.Shimmer) - Shimmer_Mean) / Shimmer_StdDev));
            Parkinsons.ToList().ForEach(x => x.Shimmer_dB = Convert.ToSingle(((x.Shimmer_dB) - Shimmer_dB_Mean) / Shimmer_dB_StdDev));
            Parkinsons.ToList().ForEach(x => x.Shimmer_APQ3 = Convert.ToSingle(((x.Shimmer_APQ3) - Shimmer_APQ3_Mean) / Shimmer_APQ3_StdDev));
            Parkinsons.ToList().ForEach(x => x.Shimmer_APQ5 = Convert.ToSingle(((x.Shimmer_APQ5) - Shimmer_APQ5_Mean) / Shimmer_APQ5_StdDev));
            Parkinsons.ToList().ForEach(x => x.Shimmer_APQ11 = Convert.ToSingle(((x.Shimmer_APQ11) - Shimmer_APQ11_Mean) / Shimmer_APQ11_StdDev));
            Parkinsons.ToList().ForEach(x => x.Shimmer_DDA = Convert.ToSingle(((x.Shimmer_DDA) - Shimmer_DDA_Mean) / Shimmer_DDA_StdDev));
            Parkinsons.ToList().ForEach(x => x.NHR = Convert.ToSingle(((x.NHR) - NHR_Mean) / NHR_StdDev));
            Parkinsons.ToList().ForEach(x => x.HNR = Convert.ToSingle(((x.HNR) - HNR_Mean) / HNR_StdDev));
            Parkinsons.ToList().ForEach(x => x.RPDE = Convert.ToSingle(((x.RPDE) - RPDE_Mean) / RPDE_StdDev));
            Parkinsons.ToList().ForEach(x => x.DFA = Convert.ToSingle(((x.DFA) - DFA_Mean) / DFA_StdDev));
            Parkinsons.ToList().ForEach(x => x.PPE = Convert.ToSingle(((x.PPE) - PPE_Mean) / PPE_StdDev));



            





            return Parkinsons;
        }

    }
}
