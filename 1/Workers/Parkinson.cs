using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class Parkinson
    {
        public int RowID { get; set; }
        public int subject { get; set; }
        public double age { get; set; }
        public int sex { get; set; }
        public double test_time { get; set; }
        public double motor_UPDRS { get; set; }
        public double total_UPDRS { get; set; }
        public double Jitter_Pct { get; set; }
        public double Jitter_Abs { get; set; }
        public double Jitter_RAP { get; set; }
        public double Jitter_PPQ5 { get; set; }
        public double Jitter_DDP { get; set; }
        public double Shimmer { get; set; }
        public double Shimmer_dB { get; set; }
        public double Shimmer_APQ3 { get; set; }
        public double Shimmer_APQ5 { get; set; }
        public double Shimmer_APQ11 { get; set; }
        public double Shimmer_DDA { get; set; }
        public double NHR { get; set; }
        public double HNR { get; set; }
        public double RPDE { get; set; }
        public double DFA { get; set; }
        public double PPE { get; set; }


        public double temp1 { get; set; }
        public double temp2 { get; set; }
        public double temp3 { get; set; }


        //public double GetArray(int i)
        //{
        //    switch (i)
        //    {
        //        case 0: return FixedAcidity;
        //        case 1: return VolatileAcidity;
        //        case 2: return ResidualSugar;
        //        case 3: return Chlorides;
        //        case 4: return FreeSulfurDioxide;
        //        case 5: return TotalSulfurDioxide;
        //        case 6: return Density;
        //        case 7: return PH;
        //        case 8: return Sulphates;
        //        case 9: return Alcohol;
        //        case 10: return QualityOriginal;
        //        default: return 0;
        //    } 
        //}

    }
}
