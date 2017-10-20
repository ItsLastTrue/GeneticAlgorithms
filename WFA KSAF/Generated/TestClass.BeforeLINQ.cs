//using System;
//using System.Collections.Generic;
//using System.Threading;

//namespace WFA.KSAF
//{
//    internal class SendEstimatorParams
//    {
//        public int s { get; set; }
//        public Estimator Estimator { get; set; }
//        public int CopyToRun { get; set; }
//    }

//    public class Estimator
//    {
//        public string GetFitnessFunctions(int i, int j)
//        {
//            return null;
//        }
//        public List<double> GetResult_Deviations()
//        {
//            return Out_Deviations;

//        }
//        public List<double[]> GetResult_Constants()
//        {
//            return Out_Constants;

//        }
//        public int[] GetResult_NM_Restarts()
//        {
//            return Out_NM_Restarts;

//        }
//        public int GetResult_BestGenotype()
//        {
//            return Result_BestGenotype;

//        }
//        public double GetGraphPoints(int i, int j)
//        {
//            return 0;

//        }
//        public List<double> GetResultGraphPoints()
//        {
//            return Points;

//        }
//        private double[,] Arg = new double[2, 29];
//        public int[] CnstInG = new int[200];
//        private List<double> Points = new List<double>();
//        public int Result_BestGenotype;
//        private int PointsCount;
//        public List<double> Out_Deviations = new List<double>();
//        public List<double[]> Out_Constants = new List<double[]>();
//        public int[] Out_NM_Restarts = new int[200];
//        public List<double[]> BestLeafs = new List<double[]>();
//        private double[] RecFiltr = new double[29];
//        private double Sin(double arg)
//        {
//            return Math.Sin(arg);
//        }
//        private double Cos(double arg)
//        {
//            return Math.Cos(arg);
//        }
//        private double Tan(double arg)
//        {
//            return Math.Tan(arg);
//        }
//        private double Exp(double arg)
//        {
//            return Math.Exp(arg);
//        }
//        private double Log(double leaf, double arg)
//        {
//            return Math.Log(arg, leaf);
//        }
//        private double Pow(double arg, double leaf)
//        {
//            if (arg > 0) return Math.Pow(arg, leaf);
//            double result = 0;
//            int floatlenght = 0;
//            double tmp = arg;
//            while ((int)tmp % 10 == 0 && tmp != 0)
//            {
//                tmp *= 10;
//                floatlenght++;

//            }
//            bool negatArg = false;
//            if ((leaf) % 2 != 0)
//            {
//                arg = arg * -1;
//                negatArg = true;

//            }
//            result = Math.Pow(arg, leaf);
//            if (negatArg == true) result = result * -1;
//            return result;

//        }
//        public Estimator()
//        {
//            Reader();
//            CollectFitnessFunctions();

//        }
//        private void Reader()
//        {
//            PointsCount = 29;
//            Arg[0, 0] = 20;
//            Arg[1, 0] = 4400;
//            Arg[0, 1] = 19;
//            Arg[1, 1] = 3500;
//            Arg[0, 2] = 18;
//            Arg[1, 2] = 2716;
//            Arg[0, 3] = 17;
//            Arg[1, 3] = 2042;
//            Arg[0, 4] = 16;
//            Arg[1, 4] = 1472;
//            Arg[0, 5] = 15;
//            Arg[1, 5] = 1000;
//            Arg[0, 6] = 14;
//            Arg[1, 6] = 620;
//            Arg[0, 7] = 13;
//            Arg[1, 7] = 326;
//            Arg[0, 8] = 12;
//            Arg[1, 8] = 112;
//            Arg[0, 9] = 11;
//            Arg[1, 9] = -28;
//            Arg[0, 10] = 10;
//            Arg[1, 10] = -100;
//            Arg[0, 11] = 9;
//            Arg[1, 11] = -110;
//            Arg[0, 12] = 8;
//            Arg[1, 12] = -64;
//            Arg[0, 13] = 7;
//            Arg[1, 13] = 32;
//            Arg[0, 14] = 6;
//            Arg[1, 14] = 172;
//            Arg[0, 15] = 5;
//            Arg[1, 15] = 350;
//            Arg[0, 16] = 4;
//            Arg[1, 16] = 560;
//            Arg[0, 17] = 3;
//            Arg[1, 17] = 796;
//            Arg[0, 18] = 2;
//            Arg[1, 18] = 1052;
//            Arg[0, 19] = 1;
//            Arg[1, 19] = 1322;
//            Arg[0, 20] = 0;
//            Arg[1, 20] = 1600;
//            Arg[0, 21] = -1;
//            Arg[1, 21] = 1880;
//            Arg[0, 22] = -2;
//            Arg[1, 22] = 2156;
//            Arg[0, 23] = -3;
//            Arg[1, 23] = 2422;
//            Arg[0, 24] = -16;
//            Arg[1, 24] = 2240;
//            Arg[0, 25] = -17;
//            Arg[1, 25] = 1736;
//            Arg[0, 26] = -18;
//            Arg[1, 26] = 1132;
//            Arg[0, 27] = -19;
//            Arg[1, 27] = 422;
//            Arg[0, 28] = -20;
//            Arg[1, 28] = -400;
//            CnstInG[0] = 4;
//            CnstInG[1] = 4;
//            CnstInG[2] = 4;
//            CnstInG[3] = 4;
//            CnstInG[4] = 3;
//            CnstInG[5] = 3;
//            CnstInG[6] = 3;
//            CnstInG[7] = 3;
//            CnstInG[8] = 2;
//            CnstInG[9] = 2;
//            CnstInG[10] = 3;
//            CnstInG[11] = 3;
//            CnstInG[12] = 2;
//            CnstInG[13] = 3;
//            CnstInG[14] = 2;
//            CnstInG[15] = 3;
//            CnstInG[16] = 3;
//            CnstInG[17] = 2;
//            CnstInG[18] = 3;
//            CnstInG[19] = 2;
//            CnstInG[20] = 2;
//            CnstInG[21] = 2;
//            CnstInG[22] = 3;
//            CnstInG[23] = 3;
//            CnstInG[24] = 2;
//            CnstInG[25] = 3;
//            CnstInG[26] = 2;
//            CnstInG[27] = 2;
//            CnstInG[28] = 5;
//            CnstInG[29] = 3;
//            CnstInG[30] = 3;
//            CnstInG[31] = 3;
//            CnstInG[32] = 3;
//            CnstInG[33] = 3;
//            CnstInG[34] = 3;
//            CnstInG[35] = 3;
//            CnstInG[36] = 3;
//            CnstInG[37] = 3;
//            CnstInG[38] = 2;
//            CnstInG[39] = 3;
//            CnstInG[40] = 3;
//            CnstInG[41] = 3;
//            CnstInG[42] = 3;
//            CnstInG[43] = 2;
//            CnstInG[44] = 2;
//            CnstInG[45] = 3;
//            CnstInG[46] = 3;
//            CnstInG[47] = 3;
//            CnstInG[48] = 3;
//            CnstInG[49] = 3;
//            CnstInG[50] = 3;
//            CnstInG[51] = 2;
//            CnstInG[52] = 3;
//            CnstInG[53] = 3;
//            CnstInG[54] = 3;
//            CnstInG[55] = 2;
//            CnstInG[56] = 3;
//            CnstInG[57] = 2;
//            CnstInG[58] = 2;
//            CnstInG[59] = 2;
//            CnstInG[60] = 2;
//            CnstInG[61] = 1;
//            CnstInG[62] = 2;
//            CnstInG[63] = 3;
//            CnstInG[64] = 2;
//            CnstInG[65] = 3;
//            CnstInG[66] = 3;
//            CnstInG[67] = 1;
//            CnstInG[68] = 3;
//            CnstInG[69] = 3;
//            CnstInG[70] = 2;
//            CnstInG[71] = 2;
//            CnstInG[72] = 2;
//            CnstInG[73] = 3;
//            CnstInG[74] = 2;
//            CnstInG[75] = 2;
//            CnstInG[76] = 3;
//            CnstInG[77] = 2;
//            CnstInG[78] = 3;
//            CnstInG[79] = 3;
//            CnstInG[80] = 3;
//            CnstInG[81] = 3;
//            CnstInG[82] = 3;
//            CnstInG[83] = 4;
//            CnstInG[84] = 3;
//            CnstInG[85] = 3;
//            CnstInG[86] = 3;
//            CnstInG[87] = 2;
//            CnstInG[88] = 3;
//            CnstInG[89] = 3;
//            CnstInG[90] = 2;
//            CnstInG[91] = 2;
//            CnstInG[92] = 3;
//            CnstInG[93] = 3;
//            CnstInG[94] = 2;
//            CnstInG[95] = 1;
//            CnstInG[96] = 2;
//            CnstInG[97] = 2;
//            CnstInG[98] = 3;
//            CnstInG[99] = 3;
//            CnstInG[100] = 2;
//            CnstInG[101] = 2;
//            CnstInG[102] = 2;
//            CnstInG[103] = 3;
//            CnstInG[104] = 4;
//            CnstInG[105] = 4;
//            CnstInG[106] = 3;
//            CnstInG[107] = 3;
//            CnstInG[108] = 2;
//            CnstInG[109] = 2;
//            CnstInG[110] = 3;
//            CnstInG[111] = 3;
//            CnstInG[112] = 2;
//            CnstInG[113] = 4;
//            CnstInG[114] = 3;
//            CnstInG[115] = 2;
//            CnstInG[116] = 3;
//            CnstInG[117] = 3;
//            CnstInG[118] = 3;
//            CnstInG[119] = 3;
//            CnstInG[120] = 3;
//            CnstInG[121] = 3;
//            CnstInG[122] = 2;
//            CnstInG[123] = 2;
//            CnstInG[124] = 2;
//            CnstInG[125] = 2;
//            CnstInG[126] = 4;
//            CnstInG[127] = 3;
//            CnstInG[128] = 2;
//            CnstInG[129] = 1;
//            CnstInG[130] = 2;
//            CnstInG[131] = 2;
//            CnstInG[132] = 3;
//            CnstInG[133] = 4;
//            CnstInG[134] = 4;
//            CnstInG[135] = 4;
//            CnstInG[136] = 2;
//            CnstInG[137] = 3;
//            CnstInG[138] = 2;
//            CnstInG[139] = 1;
//            CnstInG[140] = 4;
//            CnstInG[141] = 4;
//            CnstInG[142] = 3;
//            CnstInG[143] = 3;
//            CnstInG[144] = 2;
//            CnstInG[145] = 2;
//            CnstInG[146] = 2;
//            CnstInG[147] = 3;
//            CnstInG[148] = 3;
//            CnstInG[149] = 3;
//            CnstInG[150] = 3;
//            CnstInG[151] = 2;
//            CnstInG[152] = 2;
//            CnstInG[153] = 2;
//            CnstInG[154] = 3;
//            CnstInG[155] = 2;
//            CnstInG[156] = 2;
//            CnstInG[157] = 3;
//            CnstInG[158] = 3;
//            CnstInG[159] = 4;
//            CnstInG[160] = 3;
//            CnstInG[161] = 4;
//            CnstInG[162] = 2;
//            CnstInG[163] = 2;
//            CnstInG[164] = 3;
//            CnstInG[165] = 2;
//            CnstInG[166] = 3;
//            CnstInG[167] = 2;
//            CnstInG[168] = 3;
//            CnstInG[169] = 4;
//            CnstInG[170] = 2;
//            CnstInG[171] = 3;
//            CnstInG[172] = 2;
//            CnstInG[173] = 2;
//            CnstInG[174] = 2;
//            CnstInG[175] = 1;
//            CnstInG[176] = 2;
//            CnstInG[177] = 4;
//            CnstInG[178] = 2;
//            CnstInG[179] = 3;
//            CnstInG[180] = 3;
//            CnstInG[181] = 3;
//            CnstInG[182] = 2;
//            CnstInG[183] = 2;
//            CnstInG[184] = 2;
//            CnstInG[185] = 2;
//            CnstInG[186] = 3;
//            CnstInG[187] = 3;
//            CnstInG[188] = 3;
//            CnstInG[189] = 3;
//            CnstInG[190] = 2;
//            CnstInG[191] = 2;
//            CnstInG[192] = 3;
//            CnstInG[193] = 2;
//            CnstInG[194] = 3;
//            CnstInG[195] = 2;
//            CnstInG[196] = 3;
//            CnstInG[197] = 3;
//            CnstInG[198] = 2;
//            CnstInG[199] = 2;

//        }
//        private double GenotypeCollections(int GenotypeIndex, int n, double[] Leaf)
//        {
//            switch (GenotypeIndex)
//            {
//                case 0: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[1]) - Arg[0, n] * Leaf[2] + Leaf[3];
//                case 1: return 0 + Pow(Arg[0, n], 3) + Pow(Arg[0, n], 2) - Arg[0, n] * 280 + 1600;
//                case 2: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[1]) - Arg[0, n] * Leaf[2] + Leaf[3];
//                case 3: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[1]) - Arg[0, n] * Leaf[2] + Leaf[3];
//                case 4: return 0 + Exp(Leaf[1]) / Tan(Arg[0, n]) * Leaf[0];
//                case 5: return 0 + Exp(Leaf[1]) / Tan(Arg[0, n]) * Tan(Tan(Leaf[0]));
//                case 6: return 0 + Sin(Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[1], Sin(Leaf[0]));
//                case 7: return 0 + Leaf[0] + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[1], Leaf[0]);
//                case 8: return 0 + Leaf[0] / Tan(Arg[0, n]) * Tan(Leaf[0]);
//                case 9: return 0 + Exp(Leaf[0]) / Tan(Arg[0, n]) * Tan(Exp(Leaf[0]));
//                case 10: return 0 + Exp(Arg[0, n]) + Exp(Leaf[1]) - Cos(Cos(Leaf[0]) + Cos(Arg[0, n]));
//                case 11: return 0 + Exp(Arg[0, n]) + Exp(Leaf[1]) - Leaf[0];
//                case 12: return 0 + Arg[0, n] / Log(Arg[0, n], Arg[0, n]) - Pow(Leaf[0], Arg[0, n]);
//                case 13: return 0 + Pow(Arg[0, n], Leaf[1]) / Log(Arg[0, n], 0.0001) - Pow(Leaf[0], Arg[0, n]);
//                case 14: return 0 + Tan(Arg[0, n]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 15: return 0 + Tan(Leaf[1]) - Sin(Leaf[1]) + Cos(Leaf[0]);
//                case 16: return 0 + Exp(Leaf[1]) / Tan(Arg[0, n]) * Tan(Tan(Leaf[0]));
//                case 17: return 0 + Exp(Leaf[0]) / Tan(Arg[0, n]) * 0.0001;
//                case 18: return 0 + Log(Leaf[1], Leaf[1]) * Leaf[0] + Log(Leaf[0], Arg[0, n]);
//                case 19: return 0 + Log(Leaf[0], Leaf[0]) * Pow(Arg[0, n], Leaf[0]) + Log(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 20: return 0 + Log(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) + Arg[0, n];
//                case 21: return 0 + Log(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) + Pow(Pow(Arg[0, n], Arg[0, n]), Arg[0, n]);
//                case 22: return 0 + Exp(Arg[0, n]) / Sin(Leaf[1]) * Log(Arg[0, n] / Tan(Arg[0, n]), Leaf[0]);
//                case 23: return 0 + Exp(0.0001) / Sin(Leaf[1]) * Log(Arg[0, n], Leaf[0]);
//                case 24: return 0 + Exp(Arg[0, n]) / Sin(Leaf[0]) * Log(Arg[0, n], Arg[0, n]);
//                case 25: return 0 + Exp(Arg[0, n]) / Sin(Leaf[1]) * Log(Leaf[0], Leaf[0]);
//                case 26: return 0 + Exp(Arg[0, n]) + Exp(Leaf[0]) - 0.0001 + Exp(Arg[0, n]);
//                case 27: return 0 + Exp(Arg[0, n]) + Exp(Cos(Leaf[0])) - Cos(Leaf[0]);
//                case 28: return 0 + Log(Leaf[2], Leaf[2]) * Pow(Arg[0, n], Leaf[2]) + Log(Leaf[1], Log(Leaf[2], Leaf[2]) * Pow(Leaf[3], Leaf[0]));
//                case 29: return 0 + Arg[0, n] * Pow(Arg[0, n], Leaf[1]) + Log(Leaf[0], Arg[0, n]);
//                case 30: return 0 + Leaf[1] / Sin(Leaf[1]) * Log(Arg[0, n], Leaf[0]);
//                case 31: return 0 + Exp(Arg[0, n]) / Sin(Exp(Arg[0, n]) / Log(Leaf[0], Leaf[1])) * Log(Arg[0, n], Leaf[0]);
//                case 32: return 0 + Tan(Leaf[1]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 33: return 0 + Tan(Leaf[1]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 34: return 0 + Tan(Leaf[1]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 35: return 0 + Tan(Leaf[1]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 36: return 0 + Exp(Arg[0, n]) / Sin(Leaf[1]) * Exp(Arg[0, n]) * Log(Arg[0, n], Leaf[0]);
//                case 37: return 0 + Exp(Arg[0, n]) / Sin(Leaf[1]) / Tan(Arg[0, n]) * Log(Arg[0, n], Leaf[0]);
//                case 38: return 0 + Log(Leaf[0], Leaf[0]) * Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[0]);
//                case 39: return 0 + Log(Leaf[1], Leaf[1]) * Log(Leaf[0], Arg[0, n]) + Log(Leaf[0], Arg[0, n]);
//                case 40: return 0 + Pow(Arg[0, n], Leaf[1]) / Log(Arg[0, n], Arg[0, n]) - Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);
//                case 41: return 0 + Pow(Arg[0, n], Leaf[1]) / Log(Arg[0, n], Arg[0, n]) - Leaf[0];
//                case 42: return 0 + Pow(Arg[0, n], Leaf[1]) / Log(Arg[0, n], Arg[0, n]) - Pow(Leaf[0], Leaf[0]);
//                case 43: return 0 + Pow(Arg[0, n], Leaf[0]) / Log(Arg[0, n], Arg[0, n]) - Pow(Arg[0, n], Arg[0, n]);
//                case 44: return 0 + Tan(Leaf[0]) - Sin(Arg[0, n]) + Cos(Sin(Arg[0, n]));
//                case 45: return 0 + Tan(Leaf[1]) - Leaf[0] * Log(Leaf[0], Leaf[1]) + Cos(Leaf[0]);
//                case 46: return 0 + Exp(Leaf[1]) / Tan(Arg[0, n]) * Tan(Leaf[0]);
//                case 47: return 0 + Exp(Leaf[1]) / Tan(Arg[0, n]) * Tan(Leaf[0]);
//                case 48: return 0 + Log(Leaf[1], Leaf[1]) * Pow(Arg[0, n], Leaf[1]) + Log(Leaf[0], Pow(Arg[0, n], Leaf[1]));
//                case 49: return 0 + Log(Leaf[1], Leaf[1]) * Arg[0, n] + Log(Leaf[0], Arg[0, n]);
//                case 50: return 0 + Tan(Leaf[1]) - Leaf[1] + Cos(Leaf[0]);
//                case 51: return 0 + Tan(Sin(Arg[0, n]) / Log(Arg[0, n], Leaf[0])) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 52: return 0 + Sin(Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[1], Leaf[0]);
//                case 53: return 0 + Sin(Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[1], Leaf[0]);
//                case 54: return 0 + Tan(Leaf[1]) - Sin(Leaf[1]) + Cos(Leaf[0]);
//                case 55: return 0 + Tan(0.0001) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 56: return 0 + Tan(Leaf[1]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 57: return 0 + 0.0001 / Exp(Arg[0, n]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 58: return 0 + Tan(Leaf[0]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 59: return 0 + Tan(Leaf[0]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 60: return 0 + Exp(Cos(Leaf[0])) + Cos(Arg[0, n]) - Cos(Leaf[0]);
//                case 61: return 0 + Exp(Arg[0, n]) + Cos(Arg[0, n]) - Arg[0, n];
//                case 62: return 0 + Sin(Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Arg[0, n], Leaf[0]);
//                case 63: return 0 + Sin(Leaf[0]) + Log(Arg[0, n], Leaf[1]) - Log(Leaf[1], Leaf[0]);
//                case 64: return 0 + Exp(Leaf[0]) / Tan(Arg[0, n]) * Tan(Tan(Arg[0, n]));
//                case 65: return 0 + Exp(Leaf[1]) / Leaf[0] * Tan(Leaf[0]);
//                case 66: return 0 + Sin(Arg[0, n]) * Pow(Leaf[0], Leaf[1]) / Pow(Leaf[0], Leaf[1]);
//                case 67: return 0 + Sin(Arg[0, n]) * Tan(Arg[0, n]) / Tan(Arg[0, n]);
//                case 68: return 0 + Sin(Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[1], Leaf[0]);
//                case 69: return 0 + Sin(Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[1], Leaf[0]);
//                case 70: return 0 + Log(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) + Pow(Arg[0, n], Arg[0, n]);
//                case 71: return 0 + Log(Leaf[0], 0.0001) - Tan(Arg[0, n]) + Pow(Arg[0, n], Arg[0, n]);
//                case 72: return 0 + Pow(Arg[0, n], Arg[0, n]) / Log(Arg[0, n], Arg[0, n]) - Pow(Leaf[0], Arg[0, n]);
//                case 73: return 0 + Pow(Arg[0, n], Leaf[1]) / Log(Leaf[1], Arg[0, n]) - Pow(Leaf[0], Arg[0, n]);
//                case 74: return 0 + Tan(Leaf[0]) - Sin(Arg[0, n]) + Cos(Leaf[0] * Exp(Arg[0, n]));
//                case 75: return 0 + Tan(Leaf[0]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 76: return 0 + Pow(Arg[0, n], Leaf[1]) / Log(Arg[0, n], Leaf[1]) - Pow(Leaf[0], Arg[0, n]);
//                case 77: return 0 + Pow(Arg[0, n], Arg[0, n]) / Log(Arg[0, n], Arg[0, n]) - Pow(Leaf[0], Arg[0, n]);
//                case 78: return 0 + Sin(Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[1], Arg[0, n]);
//                case 79: return 0 + Sin(Leaf[0]) + Log(Leaf[0] * Exp(Arg[0, n]), Arg[0, n]) - Log(Leaf[1], Leaf[0]);
//                case 80: return 0 + Arg[0, n] * Pow(Leaf[0], Leaf[1]) / Tan(Arg[0, n]);
//                case 81: return 0 + Sin(Sin(Arg[0, n])) * Pow(Leaf[0], Leaf[1]) / Tan(Arg[0, n]);
//                case 82: return 0 + Exp(Leaf[1]) / Tan(Arg[0, n]) * Tan(Tan(Leaf[0]));
//                case 83: return 0 + Exp(Leaf[2]) / Tan(Arg[0, n]) * Leaf[1] / Pow(Leaf[0], Arg[0, n]);
//                case 84: return 0 + Tan(Leaf[1]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 85: return 0 + Tan(Leaf[1]) - Sin(Arg[0, n]) + Cos(Leaf[0]);
//                case 86: return 0 + Sin(Log(Leaf[1], Leaf[0])) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[1], Leaf[0]);
//                case 87: return 0 + Sin(Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Leaf[0];
//                case 88: return 0 + Exp(Leaf[1]) / Arg[0, n] * Tan(Leaf[0]);
//                case 89: return 0 + Exp(Leaf[1]) / Tan(Tan(Arg[0, n]) * Tan(Arg[0, n])) * Tan(Leaf[0]);
//                case 90: return 0 + Exp(Arg[0, n]) / Log(Arg[0, n], Leaf[0]) * Log(Arg[0, n], Leaf[0]);
//                case 91: return 0 + Exp(Arg[0, n]) / Sin(Leaf[0]) * Sin(Leaf[0]) * Exp(Arg[0, n]);
//                case 92: return 0 + Exp(Arg[0, n]) / Sin(Leaf[1]) * Log(Arg[0, n], Log(Arg[0, n], Leaf[0]));
//                case 93: return 0 + Exp(Arg[0, n]) / Sin(Leaf[1]) * Leaf[0];
//                case 94: return 0 + Leaf[0] + Cos(Arg[0, n]) - Cos(Leaf[0]);
//                case 95: return 0 + Exp(Arg[0, n]) + Cos(Arg[0, n]) - Cos(Exp(Arg[0, n]));
//                case 96: return 0 + Log(Pow(Arg[0, n], Arg[0, n]), Leaf[0]) - Tan(Arg[0, n]) + Pow(Arg[0, n], Arg[0, n]);
//                case 97: return 0 + Log(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) + Leaf[0];
//                case 98: return 0 + Sin(Leaf[0]) + Log(Arg[0, n], Sin(Leaf[0])) - Log(Leaf[1], Leaf[0]);
//                case 99: return 0 + 0.0001 + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[1], Leaf[0]);
//                case 100: return 0 + Exp(Leaf[0]) * Exp(Leaf[0]) - Cos(Arg[0, n]);
//                case 101: return 0 + Exp(Leaf[0] / Cos(Leaf[0])) * Exp(Leaf[0]) - Cos(Arg[0, n]);
//                case 102: return 0 + Arg[0, n] - Sin(Arg[0, n]) - Exp(Leaf[0]);
//                case 103: return 0 + Sin(Leaf[0]) - Sin(Sin(Leaf[0])) - Exp(Leaf[1]);
//                case 104: return 0 + Tan(Leaf[0]) / Tan(Leaf[2]) + Sin(Leaf[1]);
//                case 105: return 0 + Tan(Leaf[0]) / Tan(Leaf[2]) + Sin(Leaf[1]);
//                case 106: return 0 + Tan(Leaf[0]) / Tan(Tan(Leaf[0])) + Sin(Leaf[1]);
//                case 107: return 0 + Leaf[1] / Tan(Leaf[1]) + Sin(Leaf[0]);
//                case 108: return 0 + Sin(Exp(Leaf[0])) - Sin(Arg[0, n]) - Exp(Leaf[0]);
//                case 109: return 0 + Sin(Leaf[0]) - Sin(Arg[0, n]) - Leaf[0];
//                case 110: return 0 + Cos(Cos(Arg[0, n])) * Log(Leaf[1], Leaf[0]) / Exp(Leaf[0]);
//                case 111: return 0 + Arg[0, n] * Log(Leaf[1], Leaf[0]) / Exp(Leaf[0]);
//                case 112: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - Sin(Arg[0, n]);
//                case 113: return 0 + Exp(Leaf[2]) + Sin(Arg[0, n]) - Sin(Arg[0, n]) + Log(Leaf[1], Leaf[0]);
//                case 114: return 0 + Sin(Leaf[0]) * Sin(Leaf[1]) / Pow(Sin(Leaf[0]), Arg[0, n]);
//                case 115: return 0 + Arg[0, n] * Sin(Leaf[0]) / Pow(Arg[0, n], Arg[0, n]);
//                case 116: return 0 + Cos(Arg[0, n]) * Log(Log(Leaf[1], Leaf[0]), Leaf[0]) / Exp(Leaf[0]);
//                case 117: return 0 + Cos(Arg[0, n]) * Leaf[1] / Exp(Leaf[0]);
//                case 118: return 0 + Exp(Leaf[1] * Sin(Arg[0, n])) * Exp(Leaf[0]) - Cos(Arg[0, n]);
//                case 119: return 0 + Exp(Leaf[1]) * Exp(Leaf[0]) - Cos(Arg[0, n]);
//                case 120: return 0 + Sin(Leaf[0]) * Sin(Leaf[1]) / Pow(Pow(Arg[0, n], Arg[0, n]), Arg[0, n]);
//                case 121: return 0 + Sin(Leaf[0]) * Sin(Leaf[1]) / Arg[0, n];
//                case 122: return 0 + Exp(Arg[0, n]) / Cos(Leaf[0]) / Tan(Leaf[0]);
//                case 123: return 0 + Exp(Arg[0, n]) / Cos(Leaf[0]) / Tan(0.0001);
//                case 124: return 0 + Exp(Arg[0, n]) / Cos(Leaf[0]) / Leaf[0];
//                case 125: return 0 + Exp(Arg[0, n]) / Cos(Leaf[0]) / Tan(Tan(Leaf[0]));
//                case 126: return 0 + Sin(Leaf[0]) * Pow(Leaf[2], Leaf[1]) * Log(Arg[0, n], Leaf[2]);
//                case 127: return 0 + Sin(Leaf[0]) * Pow(Arg[0, n], Leaf[1]) * Log(Arg[0, n], Arg[0, n]);
//                case 128: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - Sin(0.0001);
//                case 129: return 0 + Exp(Arg[0, n]) + Sin(Arg[0, n]) - Sin(Arg[0, n]);
//                case 130: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - Sin(Arg[0, n]);
//                case 131: return 0 + Exp(Leaf[0]) + Sin(0.0001) - Sin(Arg[0, n]);
//                case 132: return 0 + Sin(Leaf[0]) * Pow(Arg[0, n], Leaf[1]) * Log(Arg[0, n], Arg[0, n]);
//                case 133: return 0 + Sin(Leaf[0]) * Pow(Arg[0, n], Leaf[1]) * Log(Leaf[2], Leaf[2]);
//                case 134: return 0 + Sin(Leaf[0]) * Pow(Arg[0, n], Leaf[1]) * Log(Arg[0, n], Leaf[2]);
//                case 135: return 0 + Sin(Leaf[0]) * Pow(Arg[0, n], Leaf[1]) * Log(0.0001, Leaf[2]);
//                case 136: return 0 + Cos(Arg[0, n]) * Exp(Leaf[0]) - Cos(Arg[0, n]);
//                case 137: return 0 + Exp(Leaf[1]) * Exp(Leaf[0]) - Exp(Leaf[1]);
//                case 138: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - Sin(Leaf[0]);
//                case 139: return 0 + Exp(Arg[0, n]) + Sin(Arg[0, n]) - Sin(Arg[0, n]);
//                case 140: return 0 + Tan(Leaf[0]) / Tan(Leaf[2]) + Sin(Leaf[1]);
//                case 141: return 0 + Tan(Leaf[0]) / Tan(Leaf[2]) + Sin(Leaf[1]);
//                case 142: return 0 + Sin(Leaf[0]) * Sin(Sin(Leaf[1])) / Pow(Arg[0, n], Arg[0, n]);
//                case 143: return 0 + Sin(Leaf[0]) * Leaf[1] / Pow(Arg[0, n], Arg[0, n]);
//                case 144: return 0 + Exp(Leaf[0]) + Arg[0, n] - Sin(Arg[0, n]);
//                case 145: return 0 + Exp(Leaf[0]) + Sin(Sin(Arg[0, n])) - Sin(Arg[0, n]);
//                case 146: return 0 + Sin(Arg[0, n]) * Sin(Leaf[0]) / Pow(Arg[0, n], Arg[0, n]);
//                case 147: return 0 + Sin(Leaf[0]) * Sin(Leaf[1]) / Pow(Leaf[0], Arg[0, n]);
//                case 148: return 0 + Tan(Leaf[0]) / Tan(Leaf[1]) + Sin(Tan(Leaf[1]));
//                case 149: return 0 + Tan(Leaf[0]) / Leaf[1] + Sin(Leaf[1]);
//                case 150: return 0 + Sin(Leaf[0]) * Sin(Leaf[1]) / Sin(Leaf[0]);
//                case 151: return 0 + Pow(Arg[0, n], Arg[0, n]) * Sin(Leaf[0]) / Pow(Arg[0, n], Arg[0, n]);
//                case 152: return 0 + Exp(Leaf[0]) * Exp(Exp(Leaf[0])) - Cos(Arg[0, n]);
//                case 153: return 0 + Leaf[0] + Cos(Leaf[0]) * Exp(Leaf[0]) - Cos(Arg[0, n]);
//                case 154: return 0 + Sin(Leaf[0]) * Sin(Leaf[1]) / Sin(Leaf[1]);
//                case 155: return 0 + Sin(Leaf[0]) * Pow(Arg[0, n], Arg[0, n]) / Pow(Arg[0, n], Arg[0, n]);
//                case 156: return 0 + Cos(Arg[0, n]) * Cos(Arg[0, n]) / Exp(Leaf[0]);
//                case 157: return 0 + Log(Leaf[1], Leaf[0]) * Log(Leaf[1], Leaf[0]) / Exp(Leaf[0]);
//                case 158: return 0 + Sin(Leaf[0]) * Pow(Arg[0, n], Leaf[1]) * Arg[0, n];
//                case 159: return 0 + Sin(Leaf[0]) * Pow(Log(Arg[0, n], Leaf[2]), Leaf[1]) * Log(Arg[0, n], Leaf[2]);
//                case 160: return 0 + 0.0001 * Pow(Arg[0, n], Leaf[0]) * Log(Arg[0, n], Leaf[1]);
//                case 161: return 0 + Sin(Leaf[0]) * Pow(Arg[0, n], Leaf[1]) * Log(Arg[0, n], Leaf[2]);
//                case 162: return 0 + Exp(Arg[0, n]) / 0.0001 - Tan(Leaf[0]) / Tan(Leaf[0]);
//                case 163: return 0 + Exp(Arg[0, n]) / Cos(Leaf[0]) / Tan(Leaf[0]);
//                case 164: return 0 + Sin(Leaf[0]) * Sin(Leaf[1]) / Pow(Arg[0, n], Sin(Leaf[0]));
//                case 165: return 0 + Arg[0, n] * Sin(Leaf[0]) / Pow(Arg[0, n], Arg[0, n]);
//                case 166: return 0 + Pow(Pow(Arg[0, n], Leaf[1]), Leaf[1]) / Exp(Arg[0, n]) + Sin(Leaf[0]);
//                case 167: return 0 + Arg[0, n] / Exp(Arg[0, n]) + Sin(Leaf[0]);
//                case 168: return 0 + Tan(Leaf[0]) / Tan(0.0001) + Sin(Leaf[1]);
//                case 169: return 0 + Tan(Leaf[0]) / Tan(Leaf[2]) + Sin(Leaf[1]);
//                case 170: return 0 + Sin(Arg[0, n] + Exp(Arg[0, n])) - Sin(Arg[0, n]) - Exp(Leaf[0]);
//                case 171: return 0 + Sin(Leaf[0]) - Sin(Leaf[0]) - Exp(Leaf[1]);
//                case 172: return 0 + Exp(Exp(Leaf[0])) + Sin(Arg[0, n]) - Sin(Arg[0, n]);
//                case 173: return 0 + Leaf[0] + Sin(Arg[0, n]) - Sin(Arg[0, n]);
//                case 174: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - 0.0001;
//                case 175: return 0 + Sin(Arg[0, n]) + Sin(Arg[0, n]) - Sin(Arg[0, n]);
//                case 176: return 0 + Pow(Arg[0, n], Leaf[0]) / Exp(Arg[0, n]) + Sin(Exp(Arg[0, n]));
//                case 177: return 0 + Pow(Arg[0, n], Leaf[1]) / Leaf[0] - Sin(Leaf[2]) + Sin(Leaf[0]);
//                case 178: return 0 + Sin(Leaf[0]) - Sin(Arg[0, n]) - Sin(Arg[0, n]);
//                case 179: return 0 + Sin(Leaf[0]) - Exp(Leaf[1]) - Exp(Leaf[1]);
//                case 180: return 0 + Pow(Arg[0, n], Leaf[1]) / Exp(Arg[0, n]) + Leaf[0];
//                case 181: return 0 + Pow(Arg[0, n], Leaf[1]) / Exp(Arg[0, n]) + Sin(Sin(Leaf[0]));
//                case 182: return 0 + Tan(Leaf[0]) + Log(Arg[0, n], Arg[0, n]) + Cos(0.0001);
//                case 183: return 0 + Tan(Leaf[0]) + Log(Arg[0, n], Arg[0, n]) + Arg[0, n];
//                case 184: return 0 + Exp(Arg[0, n]) / Cos(Leaf[0]) / Tan(Leaf[0]);
//                case 185: return 0 + Exp(Arg[0, n]) / Cos(0.0001) / Tan(Leaf[0]);
//                case 186: return 0 + Exp(Exp(Leaf[1])) * Exp(Leaf[0]) - Cos(Arg[0, n]);
//                case 187: return 0 + Leaf[1] * Exp(Leaf[0]) - Cos(Arg[0, n]);
//                case 188: return 0 + Sin(Leaf[0]) - Sin(Arg[0, n]) - Exp(Leaf[1]);
//                case 189: return 0 + Sin(Leaf[0]) - Sin(Arg[0, n]) - Exp(Leaf[1]);
//                case 190: return 0 + Exp(Arg[0, n]) / Exp(Arg[0, n]) / Tan(Leaf[0]);
//                case 191: return 0 + Cos(Leaf[0]) / Cos(Leaf[0]) / Tan(Leaf[0]);
//                case 192: return 0 + Exp(Leaf[1]) * Exp(Leaf[0]) - Cos(Exp(Leaf[1]));
//                case 193: return 0 + Arg[0, n] * Exp(Leaf[0]) - Cos(Arg[0, n]);
//                case 194: return 0 + Cos(Arg[0, n]) * Log(Leaf[1], Leaf[0]) / Leaf[1];
//                case 195: return 0 + Cos(Arg[0, n]) * Log(Exp(Leaf[0]), Leaf[0]) / Exp(Leaf[0]);
//                case 196: return 0 + Tan(Leaf[0]) / Tan(0.0001) + Sin(Leaf[1]);
//                case 197: return 0 + Tan(Leaf[0]) / Tan(Leaf[1]) + 0.0001;
//                case 198: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - Sin(Arg[0, n]);
//                case 199: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - Sin(Arg[0, n]);

//            }
//            return 0;

//        }
//        public double DeviationCollections(double[] Leaf, int index)
//        {
//            double temp = 0;
//            for (int i = 0 + 0; i < PointsCount; i++)
//            {
//                RecFiltr[i] = GenotypeCollections(index, i, Leaf);
//                temp += Math.Abs((Arg[1, i] - RecFiltr[i]));

//            }
//            if (double.IsNaN(temp)) temp = Math.Pow(10, 300);
//            return temp;

//        }
//        private void CollectBestGraphPoints(double[] Leaf, int index)
//        {
//            for (int i = 0 + 0; i < PointsCount; i++)
//            {
//                Points.Add(GenotypeCollections(index, i, Leaf));

//            }

//        }
//        public void CollectFitnessFunctions()
//        {
//            var thList = new List<Thread>();
//            int copyToRun = 2;
//            for (int s = 0; s < 200; s++)
//            {
//                BestLeafs.Add(new double[CnstInG[s]]);

//            }
//            for (int s = 0; s < 200; s = s + copyToRun)
//            {
//                TransitToNM transit = new TransitToNM();
//                SendEstimatorParams SEP = new SendEstimatorParams()
//                {
//                    s = s,
//                    Estimator = this,
//                    CopyToRun = copyToRun
//                };
//                var thread = new Thread(transit.RunSeveralCopyNelderMid);
//                thread.Start(SEP);
//                thList.Add(thread);

//            }
//            foreach (var t in thList)
//            {
//                while (t.IsAlive) ;

//            }
//            var best_Deviate = Math.Pow(10, 300);
//            for (int s = 0; s < 200; s++)
//            {
//                var _dev = BestLeafs[s][CnstInG[s]];
//                Out_Deviations.Add(_dev);
//                if (_dev < best_Deviate)
//                {
//                    best_Deviate = _dev;
//                    Result_BestGenotype = s;

//                }
//                Out_Constants.Add(BestLeafs[s]);

//            }
//            CollectBestGraphPoints(Out_Constants[Result_BestGenotype], Result_BestGenotype);

//        }
//        private void RecurseFilter()
//        {
//            NeldorMidThreads nl = new NeldorMidThreads();
//            var best_Deviate = Math.Pow(10, 300);
//            for (int s = 0; s < 200; s++)
//            {
//                for (int i = 0; i < 10; i++) RecFiltr[i] = 0;
//                nl.NeldorMid(this, s);
//                var _dev = BestLeafs[s][CnstInG[s]];
//                Out_Deviations.Add(_dev);
//                if (_dev < best_Deviate)
//                {
//                    best_Deviate = _dev;
//                    Result_BestGenotype = s;

//                }
//                Out_Constants.Add(BestLeafs[s]);

//            }
//            CollectBestGraphPoints(Out_Constants[Result_BestGenotype], Result_BestGenotype);

//        }

//    }
//    class TransitToNM
//    {
//        public void RunSeveralCopyNelderMid(object param)
//        {
//            SendEstimatorParams get = param as SendEstimatorParams;
//            for (int i = 0; i < get.CopyToRun; i++)
//            {
//                int num = get.s + i;
//                NeldorMidThreads nlt = new NeldorMidThreads();
//                nlt.NeldorMid(get.Estimator, num);

//            }

//        }

//    }
//    class NeldorMidThreads
//    {
//        int genotypenumber;
//        Estimator Est;
//        int Nmer;
//        private double TargetDeviation;
//        private Random rnd = new Random();
//        private double DeviationCollections(double[] Leaf, int index)
//        {
//            return Est.DeviationCollections(Leaf, index);

//        }
//        public void NeldorMid(Estimator _Est, int _genotypenumber)
//        {
//            Est = _Est;
//            genotypenumber = _genotypenumber;
//            Nmer = Est.CnstInG[genotypenumber];
//            if (Nmer == 0)
//            {
//                Est.BestLeafs[genotypenumber] = new double[1]
// {
// DeviationCollections(new double[1]
//{
// 0
//}
//, genotypenumber)
// };
//                return;

//            }
//            int iteration = 0;
//            int maxIterations = 300;
//            double[] _BestLeafs = new double[Nmer + 1];
//            int _RestartCount = 0;
//            double A_Mirror = 1;
//            double B_Сompression = 0.5;
//            double G_Tensile = 2;
//            double[] GravityCentr = new double[Nmer];
//            double[] MirrorVertice = new double[Nmer + 1];
//            double[] TensileVertice = new double[Nmer + 1];
//            double[] СompressionVertice = new double[Nmer + 1];
//            double[] MinVertice = new double[Nmer + 1];
//            double[] MaxVertice = new double[Nmer + 1];
//            double[] PenultMaxVertice = new double[Nmer + 1];
//            ReStart: double TargetConvergence = rnd.Next(1, 11) * 0.1;
//            TargetDeviation = 1;
//            double simplexStep = 1;
//            List<double[]> SimplexVertices = new List<double[]>();
//            double[] firstVertice = new double[Nmer + 1];
//            for (int j = 0; j < Nmer; j++) firstVertice[j] = (rnd.Next(0, 9000) - 4000) * 0.01;
//            firstVertice[Nmer] = DeviationCollections(firstVertice, genotypenumber);
//            SimplexVertices.Add(firstVertice);
//            for (int i = 1; i <= Nmer; i++)
//            {
//                double[] tempVert = new double[Nmer + 1];
//                Array.Copy(firstVertice, tempVert, Nmer + 1);
//                tempVert[i - 1] += simplexStep;
//                tempVert[Nmer] = DeviationCollections(tempVert, genotypenumber);
//                SimplexVertices.Add(tempVert);

//            }
//            SortDouble(SimplexVertices, 0, Nmer);
//            Start: iteration++;
//            if (iteration == maxIterations) goto End;
//            MinVertice = SimplexVertices[0];
//            MaxVertice = SimplexVertices[Nmer];
//            PenultMaxVertice = SimplexVertices[Nmer - 1];
//            GravityCentr = GetGravityCentr(SimplexVertices, Nmer - 1);
//            MirrorVertice = GetNewVertice(GravityCentr, GravityCentr, MaxVertice, A_Mirror, genotypenumber);
//            if (MirrorVertice[Nmer] < MinVertice[Nmer])
//            {
//                TensileVertice = GetNewVertice(GravityCentr, MirrorVertice, GravityCentr, G_Tensile, genotypenumber);
//                if (TensileVertice[Nmer] < MirrorVertice[Nmer])
//                {
//                    Array.Copy(TensileVertice, SimplexVertices[Nmer], Nmer + 1);
//                    SortDouble(SimplexVertices, 0, Nmer);
//                    if (CheckСonvergence(SimplexVertices) > TargetConvergence) goto Start;
//                    else goto End;

//                }
//                else
//                {
//                    Array.Copy(MirrorVertice, SimplexVertices[Nmer], Nmer + 1);
//                    SortDouble(SimplexVertices, 0, Nmer);
//                    if (CheckСonvergence(SimplexVertices) > TargetConvergence) goto Start;
//                    else goto End;

//                }

//            }
//            else if (MirrorVertice[Nmer] > MinVertice[Nmer] && MirrorVertice[Nmer] < PenultMaxVertice[Nmer])
//            {
//                Array.Copy(MirrorVertice, SimplexVertices[Nmer], Nmer + 1);
//                SortDouble(SimplexVertices, 0, Nmer);
//                if (CheckСonvergence(SimplexVertices) > TargetConvergence) goto Start;
//                else goto End;

//            }
//            else if (MirrorVertice[Nmer] < MaxVertice[Nmer])
//            {
//                Array.Copy(MirrorVertice, SimplexVertices[Nmer], Nmer + 1);
//                Array.Copy(MirrorVertice, MaxVertice, Nmer + 1);
//                GravityCentr = GetGravityCentr(SimplexVertices, Nmer - 1);

//            }
//            СompressionVertice = GetNewVertice(GravityCentr, MaxVertice, GravityCentr, B_Сompression, genotypenumber);
//            if (СompressionVertice[Nmer] < MaxVertice[Nmer])
//            {
//                Array.Copy(СompressionVertice, SimplexVertices[Nmer], Nmer + 1);
//                SortDouble(SimplexVertices, 0, Nmer);
//                if (CheckСonvergence(SimplexVertices) > TargetConvergence) goto Start;
//                else goto End;

//            }
//            else
//            {
//                DivideSimplex(SimplexVertices);
//                SortDouble(SimplexVertices, 0, Nmer);
//                if (CheckСonvergence(SimplexVertices) > TargetConvergence) goto Start;
//                else goto End;

//            }
//            End: double[] checkDeviation = GetGravityCentr(SimplexVertices, Nmer - 1, genotypenumber);
//            if (_BestLeafs[Nmer] == 0) Array.Copy(checkDeviation, _BestLeafs, Nmer + 1);
//            if (checkDeviation[Nmer] > TargetDeviation && iteration != maxIterations)
//            {
//                if (_BestLeafs[Nmer] > checkDeviation[Nmer]) Array.Copy(checkDeviation, _BestLeafs, Nmer + 1);
//                _RestartCount++;
//                goto ReStart;

//            }
//            Est.Out_NM_Restarts[genotypenumber] = _RestartCount;
//            Est.BestLeafs[genotypenumber] = _BestLeafs;

//        }
//        private double[] GetGravityCentr(List<double[]> array, int vercticesCount)
//        {
//            double[] tempCent = new double[Nmer + 1];
//            double[] tempSimplexVertice = new double[Nmer + 1];
//            for (int i = 0; i <= vercticesCount; i++)
//            {
//                tempSimplexVertice = array[i];
//                for (int j = 0; j < Nmer; j++)
//                {
//                    tempCent[j] += tempSimplexVertice[j] / Nmer;

//                }

//            }
//            return tempCent;

//        }
//        private double[] GetGravityCentr(List<double[]> array, int vercticesCount, int genotypenumber)
//        {
//            double[] tempCent = new double[Nmer + 1];
//            double[] tempSimplexVertice = new double[Nmer + 1];
//            for (int i = 0; i <= vercticesCount; i++)
//            {
//                tempSimplexVertice = array[i];
//                for (int j = 0; j < Nmer; j++)
//                {
//                    tempCent[j] += tempSimplexVertice[j] / Nmer;

//                }

//            }
//            tempCent[Nmer] = DeviationCollections(tempCent, genotypenumber);
//            return tempCent;

//        }
//        private double[] GetNewVertice(double[] gravityCentr, double[] startingPoint, double[] reflectionPoint, double multiplicator, int genotypenumber)
//        {
//            double[] tempVert = new double[Nmer + 1];
//            for (int j = 0; j < Nmer; j++)
//            {
//                tempVert[j] += gravityCentr[j] + multiplicator * (startingPoint[j] - reflectionPoint[j]);

//            }
//            tempVert[Nmer] = DeviationCollections(tempVert, genotypenumber);
//            return tempVert;

//        }
//        private double CheckСonvergence(List<double[]> simplexVertices)
//        {
//            double AverageСonvergence = 0;
//            double[] tempMinVert = simplexVertices[0];
//            for (int i = 1; i <= Nmer; i++)
//            {
//                double[] tempVert = simplexVertices[i];
//                for (int n = 0; n < Nmer; n++)
//                {
//                    AverageСonvergence += Math.Abs(tempMinVert[n] - tempVert[n]);

//                }

//            }
//            AverageСonvergence = AverageСonvergence / Convert.ToDouble(Nmer);
//            return AverageСonvergence;

//        }
//        private List<double[]> DivideSimplex(List<double[]> simplexVertices)
//        {
//            double[] tempMinVert = simplexVertices[0];
//            for (int i = 1; i <= Nmer; i++)
//            {
//                double[] tempVert = simplexVertices[i];
//                for (int j = 0; j < Nmer; j++)
//                {
//                    tempVert[j] = (tempVert[j] + tempMinVert[j]) / 2;

//                }

//            }
//            return simplexVertices;

//        }
//        void SortDouble(List<double[]> array, int start, int end)
//        {
//            if (start >= end)
//            {
//                return;

//            }
//            int pivot = partition(array, start, end);
//            SortDouble(array, start, pivot - 1);
//            SortDouble(array, pivot + 1, end);

//        }
//        int partition(List<double[]> array, int start, int end)
//        {
//            int marker = start;
//            for (int i = start; i <= end; i++)
//            {
//                double[] TeampReaderStart = array[i];
//                double[] TeampReaderEnd = array[end];
//                if (TeampReaderStart[Nmer] <= TeampReaderEnd[Nmer])
//                {
//                    double[] temp = array[marker];
//                    array[marker] = array[i];
//                    array[i] = temp;
//                    marker += 1;

//                }

//            }
//            return marker - 1;

//        }

//    }
//}


