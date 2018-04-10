using System;
using System.Collections.Generic;

namespace WFA.KSAF.Generated
{
    public class Estimator
    {
        private readonly double[,] Arg = new double[2, 41];
        private int PointsCount;
        public List<double[]> BestLeafs = new List<double[]>();

        public Estimator()
        {
            Reader();
        }

        private static bool CompareToZero(double d) => Math.Abs(d) < Double.Epsilon;
        private static double Sin(double arg) => Math.Sin(arg);
        private static double Cos(double arg) => Math.Cos(arg);
        private static double Tan(double arg) => Math.Tan(arg);
        private static double Exp(double arg) => Math.Exp(arg);
        private static double Log(double leaf, double arg) => Math.Log(arg, leaf);
        private static double Pow(double arg, double leaf)
        {
            if (arg > 0) return Math.Pow(arg, leaf);
            double tmp = arg;
            while ((int)tmp % 10 == 0 && CompareToZero(tmp) == false)
                tmp *= 10;
            var negativeArgument = false;

            if (CompareToZero(leaf % 2) == false)
            {
                arg = arg * -1;
                negativeArgument = true;
            }
            double result = Math.Pow(arg, leaf);
            if (negativeArgument) result = result * -1;
            return result;
        }

        private void Reader()
        {
            PointsCount = 41;
            Arg[0, 0] = 20;
            Arg[0, 1] = 4400;
            Arg[1, 0] = 19;
            Arg[1, 1] = 3500;
            Arg[2, 0] = 18;
            Arg[2, 1] = 2716;
            Arg[3, 0] = 17;
            Arg[3, 1] = 2042;
            Arg[4, 0] = 16;
            Arg[4, 1] = 1472;
            Arg[5, 0] = 15;
            Arg[5, 1] = 1000;
            Arg[6, 0] = 14;
            Arg[6, 1] = 620;
            Arg[7, 0] = 13;
            Arg[7, 1] = 326;
            Arg[8, 0] = 12;
            Arg[8, 1] = 112;
            Arg[9, 0] = 11;
            Arg[9, 1] = -28;
            Arg[10, 0] = 10;
            Arg[10, 1] = -100;
            Arg[11, 0] = 9;
            Arg[11, 1] = -110;
            Arg[12, 0] = 8;
            Arg[12, 1] = -64;
            Arg[13, 0] = 7;
            Arg[13, 1] = 32;
            Arg[14, 0] = 6;
            Arg[14, 1] = 172;
            Arg[15, 0] = 5;
            Arg[15, 1] = 350;
            Arg[16, 0] = 4;
            Arg[16, 1] = 560;
            Arg[17, 0] = 3;
            Arg[17, 1] = 796;
            Arg[18, 0] = 2;
            Arg[18, 1] = 1052;
            Arg[19, 0] = 1;
            Arg[19, 1] = 1322;
            Arg[20, 0] = 0;
            Arg[20, 1] = 1600;
            Arg[21, 0] = -1;
            Arg[21, 1] = 1880;
            Arg[22, 0] = -2;
            Arg[22, 1] = 2156;
            Arg[23, 0] = -3;
            Arg[23, 1] = 2422;
            Arg[24, 0] = -4;
            Arg[24, 1] = 2672;
            Arg[25, 0] = -5;
            Arg[25, 1] = 2900;
            Arg[26, 0] = -6;
            Arg[26, 1] = 3100;
            Arg[27, 0] = -7;
            Arg[27, 1] = 3266;
            Arg[28, 0] = -8;
            Arg[28, 1] = 3392;
            Arg[29, 0] = -9;
            Arg[29, 1] = 3472;
            Arg[30, 0] = -10;
            Arg[30, 1] = 3500;
            Arg[31, 0] = -11;
            Arg[31, 1] = 3470;
            Arg[32, 0] = -12;
            Arg[32, 1] = 3376;
            Arg[33, 0] = -13;
            Arg[33, 1] = 3212;
            Arg[34, 0] = -14;
            Arg[34, 1] = 2972;
            Arg[35, 0] = -15;
            Arg[35, 1] = 2650;
            Arg[36, 0] = -16;
            Arg[36, 1] = 2240;
            Arg[37, 0] = -17;
            Arg[37, 1] = 1736;
            Arg[38, 0] = -18;
            Arg[38, 1] = 1132;
            Arg[39, 0] = -19;
            Arg[39, 1] = 422;
            Arg[40, 0] = -20;
            Arg[40, 1] = -400;
        }

        private double GenotypeCollections(int GenotypeIndex, int n, double[] Leaf)
        {
            switch (GenotypeIndex)
            {
                case 0: return 0 + Exp(Sin(Leaf[0])) + Sin(Arg[0, n]) - Pow(Leaf[0], Leaf[1]);
                case 1: return 0 + Sin(Arg[0, n]) / Leaf[0] - Sin(Leaf[1]);
                case 2: return 0 + Tan(Arg[0, n]) - Cos(Arg[0, n]) - Cos(Leaf[0]);
                case 3: return 0 + Sin(0.0001) / Cos(Arg[0, n]) + Cos(Leaf[0]);
                case 4: return 0 + Pow(Leaf[1], Arg[0, n]) / Cos(Arg[0, n]) + Cos(Leaf[0]);
                case 5: return 0 + Sin(Leaf[1]) + Log(Leaf[0], Arg[0, n]) / Cos(Leaf[1]);
                case 6: return 0 + Arg[0, n] + Exp(Arg[0, n]) + Log(Leaf[0], Arg[0, n]);
                case 7: return 0 + Tan(Arg[0, n]) * Cos(Cos(Leaf[0])) - Tan(Arg[0, n]);
                case 8: return 0 + Log(Leaf[0], Leaf[0]) + Pow(Arg[0, n], Leaf[0]) - Sin(Leaf[0]);
                case 9: return 0 + Exp(Arg[0, n]) - Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 10: return 0 + Sin(Leaf[2]) / 0.0001 - Sin(Leaf[1]) + Cos(Leaf[0]);
                case 11: return 0 + Log(Leaf[1], Leaf[0]) + Cos(Arg[0, n]) - Sin(Leaf[0]);
                case 12: return 0 + Arg[0, n] * Cos(Arg[0, n]) - Tan(Arg[0, n]);
                case 13: return 0 + Pow(Leaf[1], Tan(Arg[0, n])) + Log(Leaf[0], Arg[0, n]) / Cos(Leaf[1]);
                case 14: return 0 + Log(Leaf[1], Leaf[0]) + Cos(Arg[0, n]) + Arg[0, n];
                case 15: return 0 + Tan(Arg[0, n]) - Cos(Cos(Leaf[0])) - Cos(Leaf[1]);
                case 16: return 0 + Tan(Arg[0, n]) + Log(Leaf[0], Arg[0, n]) / Cos(Leaf[1]);
                case 17: return 0 + Pow(Leaf[0], Arg[0, n]) - Cos(Arg[0, n]) - Cos(Leaf[1]);
                case 18: return 0 + Sin(Arg[0, n]) - Cos(Leaf[0]) - Sin(Arg[0, n]);
                case 19: return 0 + Sin(Leaf[0]) / Cos(Arg[0, n]) + Exp(Arg[0, n]);
                case 20: return 0 + Sin(Leaf[1]) / Cos(Arg[0, n]) + Cos(Leaf[0]);
                case 21: return 0 + Pow(Leaf[1], Arg[0, n]) + Log(Leaf[0], Arg[0, n]) / Cos(Leaf[1]);
                case 22: return 0 + Log(0.0001, Leaf[0]) + Pow(Arg[0, n], Leaf[0]) - Sin(Leaf[0]);
                case 23: return 0 + Leaf[2] + Log(Leaf[0], Arg[0, n]) / Cos(Leaf[1]);
                case 24: return 0 + Cos(Leaf[0]) + Exp(Arg[0, n]) + Log(Arg[0, n], Arg[0, n]);
                case 25: return 0 + Exp(Leaf[0] * Pow(Arg[0, n], Arg[0, n])) - Sin(Leaf[1]) / Exp(Arg[0, n]);
                case 26: return 0 + Sin(Arg[0, n]) / Cos(Arg[0, n]) + Cos(Leaf[0]);
                case 27: return 0 + Sin(Leaf[0]) - Exp(Arg[0, n]) - Sin(Arg[0, n]);
                case 28: return 0 + Arg[0, n] + Exp(Arg[0, n]) + Log(Leaf[0], Arg[0, n]);
                case 29: return 0 + Tan(Arg[0, n]) - Cos(0.0001) - Cos(Leaf[0]);
                case 30: return 0 + Log(Arg[0, n], Arg[0, n]) + Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 31: return 0 + Log(Leaf[1], Leaf[0]) + Exp(Arg[0, n]) * Cos(Arg[0, n]);
                case 32: return 0 + Log(Leaf[2], Leaf[1]) - Cos(Arg[0, n]) + Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 33: return 0 + Log(Arg[0, n], Arg[0, n]) + Pow(Arg[0, n], Leaf[0]) - Sin(Leaf[0]);
                case 34: return 0 + Log(Leaf[1], Leaf[0]) + Pow(Arg[0, n], Leaf[0]) - Sin(Leaf[0]);
                case 35: return 0 + Tan(Arg[0, n]) - Cos(Arg[0, n] + Tan(Leaf[0])) - Cos(Leaf[1]);
                case 36: return 0 + Sin(Arg[0, n]) - Exp(Arg[0, n]) - Sin(Leaf[0]);
                case 37: return 0 + Log(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[0]) - Sin(Leaf[0]);
                case 38: return 0 + Leaf[0] - Exp(Arg[0, n]) - Sin(Arg[0, n]);
                case 39: return 0 + Log(Leaf[1], Leaf[0]) + Pow(Arg[0, n], Leaf[0]) - Sin(Sin(Arg[0, n]));
                case 40: return 0 + Sin(Leaf[1]) / Cos(Arg[0, n]) + Cos(Log(Leaf[2], Leaf[0]) - Cos(Leaf[2]));
                case 41: return 0 + Leaf[0] + Pow(Arg[0, n], Leaf[1]) - Sin(Leaf[1]);
                case 42: return 0 + Sin(Leaf[2]) / Cos(Log(Leaf[3], Leaf[1])) + Cos(Leaf[0]);
                case 43: return 0 + 0.0001 + Cos(Arg[0, n]) + Cos(Leaf[0]);
                case 44: return 0 + Arg[0, n] - Exp(Arg[0, n]) - Sin(Arg[0, n]);
                case 45: return 0 + Log(Leaf[2], Leaf[1]) + Cos(Sin(Arg[0, n])) + Cos(Leaf[0]);
                case 46: return 0 + Pow(Leaf[1], Arg[0, n]) + Log(Leaf[0], Arg[0, n]) / Log(Arg[0, n], Arg[0, n]);
                case 47: return 0 + Cos(Leaf[1]) + Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 48: return 0 + Tan(Log(Leaf[0], Arg[0, n])) * Cos(Arg[0, n]) - Tan(Arg[0, n]);
                case 49: return 0 + Pow(Leaf[0], Arg[0, n]) + Arg[0, n] / Cos(Leaf[0]);
                case 50: return 0 + Cos(Leaf[0]) + Exp(Arg[0, n]) + Arg[0, n] - Cos(Arg[0, n]);
                case 51: return 0 + Tan(Arg[0, n]) - Cos(Log(Leaf[0], Arg[0, n])) - Cos(Leaf[1]);
                case 52: return 0 + 0.0001 + Sin(Leaf[1]) - Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 53: return 0 + Exp(Arg[0, n]) + Exp(Arg[0, n]) + Log(Leaf[0], Arg[0, n]);
                case 54: return 0 + Log(Leaf[1], Cos(Arg[0, n])) + Cos(Arg[0, n]) + Cos(Leaf[0]);
                case 55: return 0 + Tan(Arg[0, n]) - Leaf[0] - Cos(Leaf[1]);
                case 56: return 0 + Log(Leaf[3], Leaf[1]) + Log(Leaf[3], Leaf[2]) * Cos(Arg[0, n]) + Cos(Leaf[0]);
                case 57: return 0 + Cos(Arg[0, n]) / Sin(Leaf[0]) - Exp(Arg[0, n]);
                case 58: return 0 + Arg[0, n] - Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 59: return 0 + Log(Exp(Arg[0, n]), Arg[0, n]) + Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 60: return 0 + Sin(Exp(Arg[0, n])) - Exp(Arg[0, n]) - Sin(Arg[0, n]);
                case 61: return 0 + Cos(Leaf[1]) + Arg[0, n] + Log(Leaf[0], Arg[0, n]);
                case 62: return 0 + Cos(Leaf[0]) + Exp(Arg[0, n]) + Log(Leaf[1], Leaf[0]);
                case 63: return 0 + Log(Leaf[0], Arg[0, n]) + Pow(Arg[0, n], Leaf[1]) - Sin(Leaf[1]);
                case 64: return 0 + Tan(Arg[0, n]) - Arg[0, n] - Cos(Leaf[0]);
                case 65: return 0 + Log(Arg[0, n], Cos(Arg[0, n])) + Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 66: return 0 + Cos(Leaf[1]) + Sin(Leaf[2]) + Log(Leaf[0], Arg[0, n]);
                case 67: return 0 + Exp(Arg[0, n]) / Cos(Arg[0, n]) + Cos(Leaf[0]);
                case 68: return 0 + 0.0001 + Cos(Arg[0, n]) + Cos(Leaf[0]);
                case 69: return 0 + Cos(Log(Leaf[3], Leaf[1])) + Cos(Leaf[2]) * Pow(Arg[0, n], Leaf[0]);
                case 70: return 0 + Tan(Arg[0, n]) - Cos(Arg[0, n]) - Cos(Leaf[0]);
                case 71: return 0 + Exp(Arg[0, n]) - Sin(Leaf[0]) / Exp(Arg[0, n] - Pow(Arg[0, n], Arg[0, n]));
                case 72: return 0 + Arg[0, n] + Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 73: return 0 + Pow(Leaf[1], Arg[0, n]) + Log(Leaf[0], Log(Arg[0, n], Arg[0, n])) / Cos(Leaf[1]);
                case 74: return 0 + Sin(Leaf[0]) - Cos(Arg[0, n]) - Cos(Leaf[1]);
                case 75: return 0 + Exp(Arg[0, n]) - Tan(Arg[0, n]) / Exp(Arg[0, n]);
                case 76: return 0 + Pow(Cos(Leaf[0]), Arg[0, n]) + Log(Leaf[1], Arg[0, n]) / Cos(Leaf[2]);
                case 77: return 0 + Log(Leaf[2], Leaf[0]) + Cos(Arg[0, n]) + Leaf[1];
                case 78: return 0 + Log(Leaf[1], Arg[0, n]) + Pow(Arg[0, n], Leaf[0]) - Sin(Leaf[0]);
                case 79: return 0 + Tan(0.0001) * Cos(Arg[0, n]) - Tan(Arg[0, n]);
                case 80: return 0 + Pow(Leaf[1], Arg[0, n]) + Log(Leaf[0], Arg[0, n]) / Cos(Leaf[2]);
                case 81: return 0 + Tan(Arg[0, n]) - Cos(Arg[0, n]) - Cos(Leaf[0]);
                case 82: return 0 + Leaf[0] - Log(Arg[0, n], Arg[0, n]) - Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 83: return 0 + Log(Leaf[1], 0.0001) + Pow(Arg[0, n], Leaf[0]) - Sin(Leaf[0]);
                case 84: return 0 + Tan(Arg[0, n]) * Exp(Arg[0, n]) - Tan(Arg[0, n]);
                case 85: return 0 + Cos(Leaf[1]) + Cos(Arg[0, n]) + Log(Leaf[0], Arg[0, n]);
                case 86: return 0 + Pow(Leaf[1], Arg[0, n]) + Log(Leaf[0] + Sin(Arg[0, n]), Arg[0, n]) / Cos(Leaf[1]);
                case 87: return 0 + Log(Leaf[2], Leaf[1]) + Pow(Arg[0, n], Leaf[1]) - Sin(Leaf[0]);
                case 88: return 0 + Log(Leaf[2], Leaf[0]) + Pow(Arg[0, n], Leaf[0]) - Sin(Leaf[1]);
                case 89: return 0 + Sin(Leaf[1]) / Cos(Arg[0, n]) + Cos(Leaf[0]);
                case 90: return 0 + Log(Leaf[1], 0.0001) + Pow(Arg[0, n], Leaf[0]) - Sin(Leaf[0]);
                case 91: return 0 + Tan(Arg[0, n]) * Cos(Arg[0, n]) - Tan(Leaf[0]);
                case 92: return 0 + Log(Leaf[1], Leaf[0]) + Cos(Arg[0, n]) + Arg[0, n];
                case 93: return 0 + Exp(Cos(Leaf[0])) - Sin(Leaf[1]) / Exp(Arg[0, n]);
                case 94: return 0 + Cos(Leaf[0]) + Exp(Arg[0, n]) + Sin(Leaf[0]);
                case 95: return 0 + Log(Leaf[2], Leaf[1]) + Pow(Arg[0, n], Leaf[1]) - Log(Leaf[0], Arg[0, n]);
                case 96: return 0 + Exp(Arg[0, n]) - Sin(Leaf[0]) / Arg[0, n];
                case 97: return 0 + Sin(Arg[0, n]) - Exp(Arg[0, n]) - Sin(0.0001);
                case 98: return 0 + Sin(Leaf[1]) / Cos(Arg[0, n]) + Leaf[0];
                case 99: return 0 + Log(Leaf[1], Cos(Leaf[0])) + Cos(Arg[0, n]) + Cos(Leaf[0]);
                case 100: return 0 + Log(Leaf[1], Leaf[0]) * Exp(Arg[0, n]) - Tan(Leaf[2]);
                case 101: return 0 + Cos(Leaf[0]) * Sin(0.0001) + Sin(Arg[0, n]);
                case 102: return 0 + Exp(0.0001) + Sin(Arg[0, n]) - Pow(Leaf[0], Leaf[1]);
                case 103: return 0 + Log(Leaf[1], Leaf[0]) * Exp(Leaf[1]) - Tan(Leaf[2]);
                case 104: return 0 + Exp(Leaf[1]) - Leaf[0] / Sin(Arg[0, n]);
                case 105: return 0 + Log(Leaf[0], Pow(Arg[0, n], Arg[0, n])) * Exp(Arg[0, n]) - Tan(Leaf[1]);
                case 106: return 0 + Exp(Leaf[0]) - Pow(Pow(Leaf[0], Leaf[1]), Arg[0, n]) / Sin(Arg[0, n]);
                case 107: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - Arg[0, n];
                case 108: return 0 + Log(Leaf[2], Exp(Leaf[0]) * Sin(Leaf[1])) + Exp(Arg[0, n]) * Cos(Arg[0, n]);
                case 109: return 0 + Leaf[1] + Sin(Arg[0, n]) - Pow(Leaf[0], Leaf[1]);
                case 110: return 0 + Log(Leaf[0], Arg[0, n]) * Exp(Arg[0, n]) - Tan(Leaf[1]);
                case 111: return 0 + Exp(Leaf[1]) - Pow(Arg[0, n], Leaf[0]) / Sin(Arg[0, n]);
                case 112: return 0 + Log(Leaf[2], Leaf[1]) + Exp(Arg[0, n]) * Cos(Pow(Leaf[0], Arg[0, n]));
                case 113: return 0 + Arg[0, n] / Tan(Arg[0, n]) - Tan(Arg[0, n]);
                case 114: return 0 + Pow(Leaf[0], Leaf[2]) / Sin(Leaf[1]) - Sin(Leaf[3]);
                case 115: return 0 + Sin(Arg[0, n]) + Cos(Leaf[0]) * Sin(Leaf[1]);
                case 116: return 0 + Pow(Leaf[0], Arg[0, n]) / Cos(Leaf[1]) - Tan(Arg[0, n]);
                case 117: return 0 + Cos(Leaf[1]) + Tan(Arg[0, n]) * Pow(Arg[0, n], Leaf[0]);
                case 118: return 0 + Cos(Leaf[1]) * Pow(Leaf[0], Arg[0, n]) + Exp(Arg[0, n]) + Sin(Arg[0, n]);
                case 119: return 0 + Sin(Leaf[0]) / Tan(Arg[0, n]) - Tan(Arg[0, n]);
                case 120: return 0 + Sin(Arg[0, n]) / Sin(Log(Leaf[1], Leaf[0])) - Sin(Leaf[1]);
                case 121: return 0 + Leaf[0] / Sin(Leaf[1]) - Exp(Arg[0, n]);
                case 122: return 0 + Pow(Leaf[0], Leaf[1]) + Cos(Leaf[1]) * Leaf[1];
                case 123: return 0 + Log(Leaf[0], Sin(Leaf[0])) + Exp(Arg[0, n]) * Cos(Arg[0, n]);
                case 124: return 0 + Sin(Arg[0, n]) / Sin(Leaf[0]) - Arg[0, n];
                case 125: return 0 + Exp(Leaf[0]) - Pow(Arg[0, n], Arg[0, n]) / Sin(Sin(Leaf[1]));
                case 126: return 0 + Cos(Leaf[1]) + Leaf[2] * Pow(Arg[0, n], Leaf[0]);
                case 127: return 0 + Log(0.0001, Leaf[0]) + Exp(Arg[0, n]) * Cos(Arg[0, n]);
                case 128: return 0 + Cos(Leaf[1]) + Cos(Tan(Arg[0, n])) * Pow(Arg[0, n], Leaf[0]);
                case 129: return 0 + Pow(Leaf[0], Arg[0, n]) / Tan(Arg[0, n]) - Leaf[1];
                case 130: return 0 + Exp(Leaf[0]) - Pow(Arg[0, n], Arg[0, n]) / Cos(Leaf[1]);
                case 131: return 0 + Sin(Arg[0, n]) * Sin(Leaf[0]) + Sin(Arg[0, n]);
                case 132: return 0 + Cos(Leaf[1]) * Sin(Leaf[0]) + Sin(Arg[0, n]);
                case 133: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - Pow(Leaf[1], Leaf[1]);
                case 134: return 0 + Sin(Arg[0, n]) / Sin(Leaf[0]) - Sin(Leaf[1]);
                case 135: return 0 + Log(Leaf[1], Leaf[0]) * Exp(Arg[0, n]) - Tan(Leaf[2]);
                case 136: return 0 + Leaf[1] + Cos(Leaf[2]) * Pow(Arg[0, n], Leaf[0]);
                case 137: return 0 + Cos(Cos(Leaf[0])) * Sin(Leaf[0]) + Sin(Arg[0, n]);
                case 138: return 0 + Cos(Leaf[1]) * Sin(Leaf[0]) + Sin(Tan(Arg[0, n]));
                case 139: return 0 + Pow(Leaf[0], Arg[0, n]) / Arg[0, n] - Tan(Arg[0, n]);
                case 140: return 0 + Pow(Arg[0, n], Leaf[0]) * Exp(Arg[0, n]) - Tan(Leaf[1]);
                case 141: return 0 + Cos(Leaf[0]) + Cos(Leaf[1]) * 0.0001;
                case 142: return 0 + Log(Leaf[3], Leaf[2]) / Sin(Leaf[1]) - Exp(Leaf[0]);
                case 143: return 0 + Log(Leaf[0], Arg[0, n]) * Exp(Arg[0, n]) - Tan(Leaf[1]);
                case 144: return 0 + Log(Leaf[2], Leaf[1]) / Sin(Leaf[0]) - Sin(Arg[0, n]);
                case 145: return 0 + Cos(Leaf[1]) * Sin(Leaf[0]) + 0.0001;
                case 146: return 0 + Sin(Arg[0, n]) / Arg[0, n] - Sin(Leaf[0]);
                case 147: return 0 + Log(Leaf[2], Leaf[1]) + Exp(Arg[0, n]) * Cos(Sin(Leaf[0]));
                case 148: return 0 + Cos(Leaf[0]) * 0.0001 + Sin(Arg[0, n]);
                case 149: return 0 + Sin(Leaf[0]) + Sin(Arg[0, n]) - Pow(Leaf[1], Leaf[2]);
                case 150: return 0 + Sin(Arg[0, n]) / Leaf[0] - Sin(Leaf[1]);
                case 151: return 0 + Log(Leaf[1], Sin(Leaf[0])) + Exp(Arg[0, n]) * Cos(Arg[0, n]);
                case 152: return 0 + 0.0001 - Pow(Arg[0, n], Arg[0, n]) / Sin(Arg[0, n]);
                case 153: return 0 + Cos(Leaf[1]) + Cos(Leaf[3]) * Pow(Exp(Leaf[2]), Leaf[0]);
                case 154: return 0 + Sin(Leaf[0]) * Exp(Arg[0, n]) - Tan(Leaf[0]);
                case 155: return 0 + Log(Leaf[3], Leaf[2]) / Log(Leaf[1], Leaf[0]) - Exp(Arg[0, n]);
                case 156: return 0 + Sin(Arg[0, n]) / Sin(Leaf[0]) - Sin(Leaf[1]);
                case 157: return 0 + Log(Leaf[1], Leaf[0]) + Pow(Arg[0, n], Leaf[0]) - Sin(Leaf[0]);
                case 158: return 0 + Log(Leaf[1], Leaf[0]) + Exp(Arg[0, n]) * Leaf[0];
                case 159: return 0 + Pow(Leaf[0], Cos(Arg[0, n])) + Cos(Leaf[1]) * Sin(Leaf[2]);
                case 160: return 0 + Exp(Arg[0, n]) - Tan(Arg[0, n]) / Sin(Leaf[0]) - Exp(Arg[0, n]);
                case 161: return 0 + Log(Leaf[1], Leaf[0]) * Log(Leaf[4], Leaf[3]) - Tan(Leaf[2]);
                case 162: return 0 + Pow(Leaf[0], Arg[0, n]) / Tan(Arg[0, n]) - Tan(Leaf[1]);
                case 163: return 0 + Log(0.0001, Leaf[0]) + Exp(Arg[0, n]) * Cos(Arg[0, n]);
                case 164: return 0 + Log(Leaf[1], Leaf[0]) + Exp(Arg[0, n]) * Leaf[0] + Log(Arg[0, n], Arg[0, n]);
                case 165: return 0 + Pow(Leaf[0], Leaf[1]) + Cos(Cos(Arg[0, n])) * Sin(Leaf[2]);
                case 166: return 0 + Cos(Leaf[1]) * Sin(Leaf[0]) + Sin(Leaf[0]);
                case 167: return 0 + Cos(Arg[0, n] * Log(Leaf[1], Arg[0, n])) + Cos(Leaf[2]) * Pow(Arg[0, n], Leaf[0]);
                case 168: return 0 + Cos(Leaf[1]) * Sin(Leaf[0]) + Sin(Arg[0, n]);
                case 169: return 0 + Sin(Arg[0, n]) / Sin(Leaf[0]) - Sin(Leaf[1]);
                case 170: return 0 + Cos(Leaf[1]) * Pow(Leaf[0], Arg[0, n]) + Sin(Arg[0, n]);
                case 171: return 0 + Sin(Leaf[0]) / Tan(Arg[0, n]) - Tan(Arg[0, n]);
                case 172: return 0 + Pow(Leaf[0], Leaf[1]) + Cos(Tan(Leaf[1])) * Sin(Leaf[2]);
                case 173: return 0 + Log(Leaf[1], Leaf[0]) * Exp(Arg[0, n]) - Leaf[2];
                case 174: return 0 + Log(Leaf[1] + Log(Leaf[1], Arg[0, n]), Leaf[0]) * Exp(Arg[0, n]) - Tan(Leaf[1]);
                case 175: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - Pow(Leaf[0], Leaf[0]);
                case 176: return 0 + Cos(Leaf[1]) * Sin(Leaf[0]) + Sin(Arg[0, n]);
                case 177: return 0 + Exp(Leaf[0]) - Pow(Arg[0, n], Arg[0, n]) / Sin(Arg[0, n]);
                case 178: return 0 + Log(Leaf[0], 0.0001) + Exp(Arg[0, n]) * Cos(Arg[0, n]);
                case 179: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - Pow(Leaf[1], Leaf[1]);
                case 180: return 0 + Exp(Leaf[0]) - Pow(Arg[0, n], Arg[0, n]) / Sin(Arg[0, n]);
                case 181: return 0 + Exp(Leaf[0]) + Sin(Arg[0, n]) - Pow(Leaf[0], Leaf[1]);
                case 182: return 0 + Pow(Leaf[0], Leaf[1]) + Cos(Arg[0, n]) * Sin(Leaf[2]);
                case 183: return 0 + Log(Leaf[1], Leaf[0]) + Exp(Arg[0, n]) * Cos(Leaf[0]);
                case 184: return 0 + Exp(Leaf[0]) - Pow(Arg[0, n], Arg[0, n]) / Sin(Arg[0, n]);
                case 185: return 0 + Cos(Leaf[1]) + Cos(Leaf[2]) * Pow(Arg[0, n], Leaf[0]);
                case 186: return 0 + Log(Leaf[0], Tan(Arg[0, n])) + Exp(Arg[0, n]) * Cos(Arg[0, n]);
                case 187: return 0 + Pow(Leaf[0], Arg[0, n]) / Leaf[1] - Tan(Arg[0, n]);
                case 188: return 0 + Log(Leaf[2], Pow(Leaf[0], Arg[0, n])) / Sin(Leaf[1]) - Exp(Arg[0, n]);
                case 189: return 0 + Leaf[0] + Exp(Arg[0, n]) / Tan(Arg[0, n]) - Tan(Arg[0, n]);
                case 190: return 0 + Log(Leaf[1], Leaf[0]) + Cos(Leaf[0]) * Sin(Leaf[1]);
                case 191: return 0 + Pow(Leaf[0], Leaf[1]) + Exp(Arg[0, n]) * Cos(Arg[0, n]);
                case 192: return 0 + Pow(Tan(Arg[0, n]), Leaf[0]) + Cos(Leaf[0]) * Sin(Leaf[1]);
                case 193: return 0 + Tan(Arg[0, n]) * Cos(Arg[0, n]) - Leaf[0];
                case 194: return 0 + Exp(Leaf[0]) - Pow(Arg[0, n], Arg[0, n]) / Sin(Leaf[1]);
                case 195: return 0 + Pow(Leaf[0], Leaf[1]) + Cos(Leaf[1]) * Sin(Arg[0, n]);
                case 196: return 0 + Cos(Leaf[0]) + Cos(Leaf[2]) * Pow(Arg[0, n], Leaf[1]);
                case 197: return 0 + Sin(Arg[0, n]) / Sin(Leaf[0]) - Sin(Leaf[1]);
                case 198: return 0 + Sin(Arg[0, n]) / Sin(Leaf[0]) - Leaf[1];
                case 199: return 0 + Pow(Leaf[0], Leaf[1]) + Cos(Sin(Leaf[2])) * Sin(Leaf[2]);

                default:
                    throw new Exception("Error 10241610. Размер популяции был изменен.");
            }
        }

        public double DeviationCollections(double[] Leaf, int index)
        {
            double temp = 0;
            for (int i = 0 + 0; i < PointsCount; i++)
                temp += Math.Abs((Arg[i, 1] - GenotypeCollections(index, i, Leaf)));

            if (double.IsNaN(temp)) temp = Math.Pow(10, 300);
            return temp;
        }

        //Возвращает график математической функции.
        public List<double> GetFunctionPoints(double[] leafs, int index)
        {
            var points = new List<double>();
            for (int i = 0 + 0; i < PointsCount; i++)
                points.Add(GenotypeCollections(index, i, leafs));

            return points;
        }
    }
}