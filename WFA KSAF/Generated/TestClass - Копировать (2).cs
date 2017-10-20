//using System;
//using System.Collections.Generic;
//namespace GenProPopul
//{
//    public class Estimator
//    {
//        char AtniErrorApostrof = ';';
//        private Random rnd = new Random();
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
//        private double Log(double leaf, double arg)
//        {
//            return Math.Log(arg, leaf);
//        }
//        private double[,] Arg = new double[2, 51];
//        private double[,] Points = new double[100, 51];
//        private int ArgumentsCount;
//        private int TargetDeviation = 100 * 2;
//        public string[,] FitnessCollections = new string[3, 100];
//        public Estimator()
//        {
//            Reader();
//            CollectFitnessFunctions();
//        }
//        private void Reader()
//        {
//            ArgumentsCount = 51;
//            Arg[0, 0] = 5;
//            Arg[1, 0] = 231.388;
//            Arg[0, 1] = 4.9;
//            Arg[1, 1] = 211.801;
//            Arg[0, 2] = 4.8;
//            Arg[1, 2] = 193.424;
//            Arg[0, 3] = 4.7;
//            Arg[1, 3] = 176.209;
//            Arg[0, 4] = 4.6;
//            Arg[1, 4] = 160.11;
//            Arg[0, 5] = 4.5;
//            Arg[1, 5] = 145.082;
//            Arg[0, 6] = 4.4;
//            Arg[1, 6] = 131.079;
//            Arg[0, 7] = 4.3;
//            Arg[1, 7] = 118.057;
//            Arg[0, 8] = 4.2;
//            Arg[1, 8] = 105.973;
//            Arg[0, 9] = 4.1;
//            Arg[1, 9] = 94.784;
//            Arg[0, 10] = 4;
//            Arg[1, 10] = 84.449;
//            Arg[0, 11] = 3.9;
//            Arg[1, 11] = 74.925;
//            Arg[0, 12] = 3.8;
//            Arg[1, 12] = 66.174;
//            Arg[0, 13] = 3.7;
//            Arg[1, 13] = 58.156;
//            Arg[0, 14] = 3.6;
//            Arg[1, 14] = 50.832;
//            Arg[0, 15] = 3.5;
//            Arg[1, 15] = 44.165;
//            Arg[0, 16] = 3.4;
//            Arg[1, 16] = 38.117;
//            Arg[0, 17] = 3.3;
//            Arg[1, 17] = 32.654;
//            Arg[0, 18] = 3.2;
//            Arg[1, 18] = 27.739;
//            Arg[0, 19] = 3.1;
//            Arg[1, 19] = 23.338;
//            Arg[0, 20] = 3;
//            Arg[1, 20] = 19.419;
//            Arg[0, 21] = 2.9;
//            Arg[1, 21] = 15.948;
//            Arg[0, 22] = 2.8;
//            Arg[1, 22] = 12.895;
//            Arg[0, 23] = 2.7;
//            Arg[1, 23] = 10.228;
//            Arg[0, 24] = 2.6;
//            Arg[1, 24] = 7.917;
//            Arg[0, 25] = 2.5;
//            Arg[1, 25] = 5.935;
//            Arg[0, 26] = 2.4;
//            Arg[1, 26] = 4.252;
//            Arg[0, 27] = 2.3;
//            Arg[1, 27] = 2.843;
//            Arg[0, 28] = 2.2;
//            Arg[1, 28] = 1.681;
//            Arg[0, 29] = 2.1;
//            Arg[1, 29] = 0.741;
//            Arg[0, 30] = 2;
//            Arg[1, 30] = 0;
//            Arg[0, 31] = 1.9;
//            Arg[1, 31] = -0.566;
//            Arg[0, 32] = 1.8;
//            Arg[1, 32] = -0.978;
//            Arg[0, 33] = 1.7;
//            Arg[1, 33] = -1.257;
//            Arg[0, 34] = 1.6;
//            Arg[1, 34] = -1.423;
//            Arg[0, 35] = 1.5;
//            Arg[1, 35] = -1.494;
//            Arg[0, 36] = 1.4;
//            Arg[1, 36] = -1.488;
//            Arg[0, 37] = 1.3;
//            Arg[1, 37] = -1.421;
//            Arg[0, 38] = 1.2;
//            Arg[1, 38] = -1.309;
//            Arg[0, 39] = 1.1;
//            Arg[1, 39] = -1.164;
//            Arg[0, 40] = 1;
//            Arg[1, 40] = -1;
//            Arg[0, 41] = 0.9;
//            Arg[1, 41] = -0.828;
//            Arg[0, 42] = 0.8;
//            Arg[1, 42] = -0.657;
//            Arg[0, 43] = 0.7;
//            Arg[1, 43] = -0.496;
//            Arg[0, 44] = 0.6;
//            Arg[1, 44] = -0.352;
//            Arg[0, 45] = 0.5;
//            Arg[1, 45] = -0.231;
//            Arg[0, 46] = 0.4;
//            Arg[1, 46] = -0.135;
//            Arg[0, 47] = 0.3;
//            Arg[1, 47] = -0.066;
//            Arg[0, 48] = 0.2;
//            Arg[1, 48] = -0.023;
//            Arg[0, 49] = 0.1;
//            Arg[1, 49] = -0.004;
//            Arg[0, 50] = 0;
//            Arg[1, 50] = 0;

//        }
//        private double Op(double Leaf, double Arg, int Operator)
//        {
//            switch (Operator)
//            {
//                case 1: return Arg * Leaf;
//                case 2: return Arg / Leaf;
//                case 3: return Leaf * Math.Sin(Arg);
//                case 4: return Leaf * Math.Cos(Arg);
//                case 5: return Leaf * Math.Tan(Arg);
//                case 6: return Math.Log(Arg, Leaf);

//            }
//            return 0;

//        }
//        private double GenotypeCollections(int GenotypeIndex, int n, double[] Leaf)
//        {
//            switch (GenotypeIndex)
//            {
//                case 0: return 0 + Arg[0, n] * Arg[0, n];
//                case 1: return 0 + Leaf[4] + Leaf[0] - Leaf[4] + Leaf[0] - Arg[0, n] / Leaf[0] + Tan(Arg[0, n]) / Leaf[0] * Arg[0, n];
//                case 2: return 0 + Arg[0, n] - Log(Arg[0, n], Leaf[4]) + Log(Arg[0, n], Leaf[4]);
//                case 3: return 0 + Arg[0, n] - Leaf[2] + Leaf[5] + Leaf[2] + Leaf[5];
//                case 4: return 0 + Arg[0, n] - Log(Arg[0, n], Leaf[4]) + Leaf[2] + Leaf[5];
//                case 5: return 0 + Arg[0, n] - Log(Arg[0, n], Leaf[4]) + Leaf[2] + Leaf[5];
//                case 6: return 0 + Sin(Arg[0, n]) + Cos(Arg[0, n]) + Arg[0, n] + Leaf[0];
//                case 7: return 0 + Sin(Leaf[0] + Leaf[0]) + Cos(Arg[0, n]) + Leaf[0] + Leaf[0] + Leaf[0];
//                case 8: return 0 + Sin(Arg[0, n]) + Cos(Arg[0, n]) + Leaf[0] + Leaf[0] + Arg[0, n];
//                case 9: return 0 + Sin(Leaf[0]) + Cos(Arg[0, n]) + Leaf[0] + Leaf[0] + Leaf[0];
//                case 10: return 0 + Pow(Arg[0, n], 2) * Leaf[0] + 2;
//                case 11: return 0 + Pow(Arg[0, n], Leaf[4] * Arg[0, n] + Leaf[2]) * Leaf[0] + Leaf[4] * Arg[0, n] + Leaf[2];
//                case 12: return 0 + Pow(Arg[0, n], Leaf[4]) * Leaf[0] + Leaf[4] * Arg[0, n] + Leaf[2];
//                case 13: return 0 + Pow(Arg[0, n], 2) * Leaf[0] + 2 * Arg[0, n] + Leaf[2];
//                case 14: return 0 + Sin(Arg[0, n]) + Cos(Arg[0, n]) + Leaf[0] + Leaf[0] + Leaf[0];
//                case 15: return 0 + Sin(Arg[0, n]) + Cos(Arg[0, n]) + Leaf[0] + Leaf[0] + Leaf[0];
//                case 16: return 0 + Leaf[0] * Pow(Arg[0, n], Leaf[1]) + Leaf[2] * Arg[0, n] * Leaf[5] - Arg[0, n] / Leaf[0] + Leaf[5] / Leaf[0] * Pow(Arg[0, n], Leaf[1]) + Leaf[5] * Exp(Arg[0, n]);
//                case 17: return 0 + Sin(Arg[0, n]) + Leaf[2] * Arg[0, n] * Leaf[5] - Arg[0, n] / Leaf[0] + Leaf[5] / Sin(Arg[0, n]) + Leaf[5] * Exp(Arg[0, n]);
//                case 18: return 0 + Arg[0, n] - Arg[0, n] - Log(Arg[0, n], Leaf[4]) + Leaf[2] + Leaf[5];
//                case 19: return 0 + Log(Arg[0, n], Leaf[4]) + Leaf[2] + Leaf[5];
//                case 20: return 0 + Sin(Arg[0, n]) + Cos(Arg[0, n]) + Leaf[0] + Leaf[0] + Leaf[0];
//                case 21: return 0 + Sin(Arg[0, n]) + Cos(Arg[0, n]) + Leaf[0] + Leaf[0] + Leaf[0];
//                case 22: return 0 + Leaf[2] * Leaf[0] + Leaf[4] * Arg[0, n] + Leaf[2];
//                case 23: return 0 + Pow(Arg[0, n], 2) * Leaf[0] + Leaf[4] * Arg[0, n] + Pow(Arg[0, n], 2);
//                case 24: return 0 + Pow(Arg[0, n], 2) * Leaf[0] + Leaf[4] * Arg[0, n] + Pow(Arg[0, n], 2);
//                case 25: return 0 + Leaf[2] * Leaf[0] + Leaf[4] * Arg[0, n] + Leaf[2];
//                case 26: return 0 + Leaf[0] * Pow(Arg[0, n], Leaf[1]) + Leaf[2] * Arg[0, n] * Leaf[5] - Arg[0, n] / Arg[0, n] + Leaf[5] * Exp(Arg[0, n]);
//                case 27: return 0 + Leaf[0] * Pow(Arg[0, n], Leaf[1]) + Leaf[2] * Arg[0, n] * Leaf[5] - Arg[0, n] / Leaf[0] + Leaf[5] / Sin(Arg[0, n]) + Leaf[5] * Exp(Leaf[0] + Leaf[5] / Sin(Arg[0, n]));
//                case 28: return 0 + Pow(Arg[0, n], Leaf[4] * Arg[0, n] + Leaf[2]) * Leaf[0] + Leaf[4] * Arg[0, n] + Leaf[2];
//                case 29: return 0 + Pow(Arg[0, n], 2) * Leaf[0] + 2;
//                case 30: return 0 + Sin(Arg[0, n]) + Cos(Arg[0, n]) + Leaf[0] + Leaf[0] + Leaf[0];
//                case 31: return 0 + Sin(Arg[0, n]) + Cos(Arg[0, n]) + Leaf[0] + Leaf[0] + Leaf[0];
//                case 32: return 0 + Leaf[0] * Pow(Arg[0, n], Leaf[1]) + Leaf[2] * Arg[0, n] * Leaf[5] - Arg[0, n] / Leaf[0] + Arg[0, n] + Leaf[5] * Exp(Arg[0, n]);
//                case 33: return 0 + Leaf[0] * Pow(Leaf[5] / Sin(Arg[0, n]), Leaf[1]) + Leaf[2] * Arg[0, n] * Leaf[5] - Arg[0, n] / Leaf[0] + Leaf[5] / Sin(Arg[0, n]) + Leaf[5] * Exp(Arg[0, n]);
//                case 34: return 0 + Pow(Arg[0, n], 2) * Leaf[0] + Leaf[4] * 2 + Leaf[2];
//                case 35: return 0 + Pow(Arg[0, n], Arg[0, n]) * Leaf[0] + Leaf[4] * Arg[0, n] + Leaf[2];
//                case 36: return 0 + Sin(Arg[0, n]) + Leaf[0] + Leaf[0] + Leaf[0] + Leaf[0];
//                case 37: return 0 + Sin(Arg[0, n]) + Cos(Arg[0, n]) + Leaf[0] + Cos(Arg[0, n]) + Leaf[0];
//                case 38: return 0 + Pow(Arg[0, n], 2) * Leaf[4] * Arg[0, n] + Pow(Arg[0, n], Leaf[5]) + Leaf[2];
//                case 39: return 0 + Pow(Arg[0, n], 2) * Leaf[0] + Leaf[0] + Leaf[4] * Arg[0, n] + Leaf[2];
//                case 40: return 0 + Leaf[0] * Pow(Arg[0, n], Leaf[1]) + Leaf[2] * Arg[0, n] * Leaf[5] - Leaf[5] - Arg[0, n] / Leaf[0] / Sin(Arg[0, n]) + Leaf[5] * Exp(Arg[0, n]);
//                case 41: return 0 + Leaf[0] * Pow(Arg[0, n], Leaf[1]) + Leaf[2] * Arg[0, n] * Arg[0, n] / Leaf[0] + Leaf[5] + Leaf[5] / Sin(Arg[0, n]) + Leaf[5] * Exp(Arg[0, n]);
//                case 42: return 0 + Pow(2, 2) * Leaf[0] + Leaf[4] * Arg[0, n] + Leaf[2];
//                case 43: return 0 + Pow(Arg[0, n], Arg[0, n]) * Leaf[0] + Leaf[4] * Arg[0, n] + Leaf[2];
//                case 44: return 0 + Arg[0, n] - Log(Arg[0, n], Leaf[4]) + Leaf[2] + Leaf[5];
//                case 45: return 0 + Arg[0, n] - Log(Arg[0, n], Leaf[4]) + Leaf[2] + Leaf[5];
//                case 46: return 0 + Leaf[0] * Pow(Arg[0, n], Leaf[1]) + Leaf[2] * Arg[0, n] * Leaf[5] - Arg[0, n] / Leaf[0] + Exp(Arg[0, n]) + Leaf[5] * Exp(Arg[0, n]);
//                case 47: return 0 + Leaf[0] * Pow(Arg[0, n], Leaf[1]) + Leaf[2] * Arg[0, n] * Leaf[5] - Arg[0, n] / Leaf[0] + Leaf[5] / Sin(Arg[0, n]) + Leaf[5] * Leaf[5] / Sin(Arg[0, n]);
//                case 48: return 0 + Sin(Arg[0, n]) + Cos(Arg[0, n]) + Leaf[0] + Leaf[0] + Leaf[0];
//                case 49: return 0 + Sin(Arg[0, n]) + Cos(Arg[0, n]) + Leaf[0] + Leaf[0] + Leaf[0];
//                case 50: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Leaf[4] + Tan(Arg[0, n]), Leaf[1]) + Leaf[4];
//                case 51: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Arg[0, n];
//                case 52: return 0 + Pow(Arg[0, n], 2) * Leaf[2] / Sin(Leaf[1]) + Leaf[1] * Arg[0, n] - Leaf[3];
//                case 53: return 0 + Pow(Arg[0, n], 2) * Leaf[2] / Sin(Arg[0, n]) + Arg[0, n] * Arg[0, n] - Leaf[3];
//                case 54: return 0 + Pow(Arg[0, n], 2) * Leaf[2] / Sin(Arg[0, n]) + Leaf[1] * Arg[0, n] - Leaf[3] - Leaf[3];
//                case 55: return 0 + Pow(Arg[0, n], 2) * Leaf[2] / Sin(Arg[0, n]) + Leaf[1] * Arg[0, n];
//                case 56: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Arg[0, n];
//                case 57: return 0 + Pow(Leaf[4], 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Leaf[4];
//                case 58: return 0 + Pow(Arg[0, n] + Cos(Arg[0, n]), 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Leaf[4];
//                case 59: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Leaf[4];
//                case 60: return 0 + Arg[0, n] * Leaf[0] + Arg[0, n] + Leaf[3] * Leaf[5] + Leaf[5];
//                case 61: return 0 + Arg[0, n] * Leaf[0] + Arg[0, n] + Leaf[3] * Arg[0, n] + Arg[0, n];
//                case 62: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Arg[0, n], Arg[0, n]) + Leaf[4];
//                case 63: return 0 + Pow(Leaf[1], 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Leaf[4];
//                case 64: return 0 + Arg[0, n] * Arg[0, n] * Leaf[2] - Arg[0, n] + Leaf[5] * Arg[0, n] + Leaf[5];
//                case 65: return 0 + Leaf[2] - Arg[0, n] + Leaf[5] * Arg[0, n] + Leaf[5];
//                case 66: return 0 + Leaf[4] + Leaf[0] * Arg[0, n] / Leaf[0] * Arg[0, n];
//                case 67: return 0 + Leaf[4] + Leaf[0] - Arg[0, n] / Leaf[0] - Arg[0, n];
//                case 68: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Arg[0, n];
//                case 69: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Leaf[4], Leaf[1]) + Leaf[4];
//                case 70: return 0 + Leaf[4] + Leaf[4] + Leaf[0] - Arg[0, n] / Leaf[0] * Arg[0, n];
//                case 71: return 0 + Leaf[0] - Arg[0, n] / Leaf[0] * Arg[0, n];
//                case 72: return 0 + Arg[0, n] * Leaf[0] + Arg[0, n] + Leaf[0] + Arg[0, n] + Leaf[3] * Arg[0, n] + Leaf[5];
//                case 73: return 0 + Arg[0, n] * Leaf[3] * Arg[0, n] + Leaf[5];
//                case 74: return 0 + Arg[0, n] * Leaf[2] - Arg[0, n] + Arg[0, n] + Leaf[5];
//                case 75: return 0 + Arg[0, n] * Leaf[2] - Leaf[5] * Arg[0, n] + Leaf[5] * Arg[0, n] + Leaf[5];
//                case 76: return 0 + Arg[0, n] * Leaf[2] - Arg[0, n] + Leaf[5] * Arg[0, n] + Arg[0, n];
//                case 77: return 0 + Arg[0, n] * Leaf[2] - Arg[0, n] + Leaf[5] * Leaf[5] + Leaf[5];
//                case 78: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Leaf[4];
//                case 79: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Leaf[4];
//                case 80: return 0 + Pow(Leaf[1], 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Leaf[4];
//                case 81: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Arg[0, n], Arg[0, n]) + Leaf[4];
//                case 82: return 0 + Arg[0, n] * Leaf[2] - Arg[0, n] + Leaf[5] * Arg[0, n] + Leaf[2] - Arg[0, n] + Leaf[5];
//                case 83: return 0 + Arg[0, n] * Leaf[5] * Arg[0, n] + Leaf[5];
//                case 84: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Leaf[4];
//                case 85: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Leaf[4];
//                case 86: return 0 + Leaf[4] + Arg[0, n] - Arg[0, n] / Leaf[0] * Arg[0, n];
//                case 87: return 0 + Leaf[4] + Leaf[0] - Arg[0, n] / Leaf[0] * Leaf[0];
//                case 88: return 0 + Pow(Arg[0, n], 2) * Leaf[2] / Sin(Arg[0, n]) + Leaf[1] * Arg[0, n] - Leaf[3];
//                case 89: return 0 + Pow(Arg[0, n], 2) * Leaf[2] / Sin(Arg[0, n]) + Leaf[1] * Arg[0, n] - Leaf[3];
//                case 90: return 0 + 2 * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Leaf[4];
//                case 91: return 0 + Pow(Arg[0, n], Pow(Arg[0, n], 2)) * Leaf[3] + Pow(Arg[0, n], Leaf[1]) + Leaf[4];
//                case 92: return 0 + Pow(Arg[0, n], 2) * 2 / Sin(Arg[0, n]) + Leaf[1] * Arg[0, n] - Leaf[3];
//                case 93: return 0 + Pow(Arg[0, n], Leaf[2]) * Leaf[2] / Sin(Arg[0, n]) + Leaf[1] * Arg[0, n] - Leaf[3];
//                case 94: return 0 + Arg[0, n] * Leaf[0] + Arg[0, n] + Leaf[0] + Arg[0, n] + Leaf[3] * Arg[0, n] + Leaf[5];
//                case 95: return 0 + Arg[0, n] * Leaf[3] * Arg[0, n] + Leaf[5];
//                case 96: return 0 + Pow(Leaf[3] + Leaf[3] * Arg[0, n], 2) * Leaf[2] / Sin(Arg[0, n]) + Leaf[1] * Arg[0, n] - Leaf[3];
//                case 97: return 0 + Pow(Arg[0, n], 2) * Leaf[2] / Sin(Arg[0, n]) + Leaf[1] * Arg[0, n] - Arg[0, n];
//                case 98: return 0 + Pow(Arg[0, n], 2) * Leaf[2] / Sin(Arg[0, n]) + Leaf[1] * Arg[0, n] - Leaf[2] / Sin(Arg[0, n]);
//                case 99: return 0 + Pow(Arg[0, n], 2) * Leaf[3] + Leaf[1] * Arg[0, n] - Leaf[3];

//            }
//            return 0;

//        }
//        private double DeviationCollections(double[] Leaf, int index)
//        {
//            double temp = 0;
//            for (int i = 0; i < ArgumentsCount; i++)
//            {
//                double func = GenotypeCollections(index, i, Leaf);
//                Points[index, i] = func;
//                temp += Math.Abs((Arg[1, i] - func));

//            }
//            if (double.IsNaN(temp)) temp = Math.Pow(10, 300);
//            return temp;

//        }
//        public void CollectFitnessFunctions()
//        {
//            for (int s = 0; s < 100; s++)
//            {
//                double[] BestLeafs = NeldorMid(6, s);
//                FitnessCollections[0, s] = BestLeafs[3].ToString();
//                for (int i = 0; i < 6; i++) FitnessCollections[1, s] += BestLeafs[i].ToString() + AtniErrorApostrof;

//            }

//        }
//        public string GetFitnessFunctions(int i, int j)
//        {
//            return FitnessCollections[i, j];

//        }
//        public double GetGraphPoints(int i, int j)
//        {
//            return Points[i, j];

//        }
//        int Nmer;
//        public double[] NeldorMid(int razmernost, int genotypenumber)
//        {
//            Nmer = razmernost;
//            int iteration = 0;
//            int maxIterations = 300;
//            double A_Mirror = 1;
//            double B_Сompression = 0.5;
//            double G_Tensile = 2;
//            double TargetСonvergence = 0.5;
//            double[] GravityCentr = new double[Nmer];
//            double[] MirrorVertice = new double[Nmer + 1];
//            double[] TensileVertice = new double[Nmer + 1];
//            double[] СompressionVertice = new double[Nmer + 1];
//            double[] MinVertice = new double[Nmer + 1];
//            double[] MaxVertice = new double[Nmer + 1];
//            double[] PenultMaxVertice = new double[Nmer + 1];
//        ReStart: List<double[]> SimplexVertices = new List<double[]>();
//            double[] firstVertice = new double[Nmer + 1];
//            for (int j = 0; j < Nmer; j++) firstVertice[j] = (rnd.Next(0, 9000) - 4000) * 0.01;
//            firstVertice[Nmer] = DeviationCollections(firstVertice, genotypenumber);
//            SimplexVertices.Add(firstVertice);
//            double simplexStep = 1;
//            for (int i = 1; i <= Nmer; i++)
//            {
//                double[] tempVert = new double[Nmer + 1];
//                Array.Copy(firstVertice, tempVert, Nmer + 1);
//                tempVert[i - 1] += simplexStep;
//                tempVert[Nmer] = DeviationCollections(tempVert, genotypenumber);
//                SimplexVertices.Add(tempVert);

//            }
//            SortDouble(SimplexVertices, 0, Nmer);
//        Start: iteration++;
//            if (iteration == maxIterations) goto End;
//            MinVertice = SimplexVertices[0];
//            MaxVertice = SimplexVertices[Nmer];
//            PenultMaxVertice = SimplexVertices[Nmer - 1];
//            GravityCentr = GetGravityCentr(SimplexVertices, Nmer - 1, genotypenumber);
//            MirrorVertice = GetNewVertice(GravityCentr, GravityCentr, MaxVertice, A_Mirror, genotypenumber);
//            if (MirrorVertice[Nmer] < MinVertice[Nmer])
//            {
//                TensileVertice = GetNewVertice(GravityCentr, MirrorVertice, GravityCentr, G_Tensile, genotypenumber);
//                if (TensileVertice[Nmer] < MinVertice[Nmer])
//                {
//                    Array.Copy(TensileVertice, SimplexVertices[Nmer], Nmer + 1);
//                    SortDouble(SimplexVertices, 0, Nmer);
//                    if (CheckСonvergence(SimplexVertices) > TargetСonvergence) goto Start;
//                    else goto End;

//                }
//                else if (TensileVertice[Nmer] > MinVertice[Nmer])
//                {
//                    Array.Copy(MirrorVertice, SimplexVertices[Nmer], Nmer + 1);
//                    SortDouble(SimplexVertices, 0, Nmer);
//                    if (CheckСonvergence(SimplexVertices) > TargetСonvergence) goto Start;
//                    else goto End;

//                }

//            }
//            else if (MirrorVertice[Nmer] > MinVertice[Nmer] && MirrorVertice[Nmer] < PenultMaxVertice[Nmer])
//            {
//                Array.Copy(MirrorVertice, SimplexVertices[Nmer], Nmer + 1);
//                SortDouble(SimplexVertices, 0, Nmer);
//                if (CheckСonvergence(SimplexVertices) > TargetСonvergence) goto Start;
//                else goto End;

//            }
//            if (MirrorVertice[Nmer] < MaxVertice[Nmer])
//            {
//                Array.Copy(MirrorVertice, SimplexVertices[Nmer], Nmer + 1);
//                SortDouble(SimplexVertices, 0, Nmer);
//                СompressionVertice = GetNewVertice(GravityCentr, MirrorVertice, GravityCentr, B_Сompression, genotypenumber);

//            }
//            else
//            {
//                СompressionVertice = GetNewVertice(GravityCentr, MaxVertice, GravityCentr, B_Сompression, genotypenumber);

//            }
//            if (СompressionVertice[Nmer] < MaxVertice[Nmer])
//            {
//                Array.Copy(СompressionVertice, SimplexVertices[Nmer], Nmer + 1);
//                SortDouble(SimplexVertices, 0, Nmer);
//                if (CheckСonvergence(SimplexVertices) > TargetСonvergence) goto Start;
//                else goto End;

//            }
//            else
//            {
//                DivideSimplex(SimplexVertices);
//                SortDouble(SimplexVertices, 0, Nmer);
//                if (CheckСonvergence(SimplexVertices) > TargetСonvergence) goto Start;
//                else goto End;

//            }
//        End: double[] checkDeviation = GetGravityCentr(SimplexVertices, Nmer - 1, genotypenumber);
//            if (checkDeviation[Nmer] > TargetDeviation && iteration != maxIterations) goto ReStart;
//            FitnessCollections[2, genotypenumber] = iteration.ToString();
//            return checkDeviation;

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
//            double delete = Math.Pow(tempMinVert[Nmer] - AverageСonvergence, 2) / (Nmer + 1);
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


