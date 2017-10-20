using System;
using System.Collections.Generic;

namespace WFA.KSAF.Generated
{
    public class Estimator
    {
        private double[,] Arg = new double[2, 41];
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
            Arg[1, 0] = 4400;
            Arg[0, 1] = 19;
            Arg[1, 1] = 3500;
            Arg[0, 2] = 18;
            Arg[1, 2] = 2716;
            Arg[0, 3] = 17;
            Arg[1, 3] = 2042;
            Arg[0, 4] = 16;
            Arg[1, 4] = 1472;
            Arg[0, 5] = 15;
            Arg[1, 5] = 1000;
            Arg[0, 6] = 14;
            Arg[1, 6] = 620;
            Arg[0, 7] = 13;
            Arg[1, 7] = 326;
            Arg[0, 8] = 12;
            Arg[1, 8] = 112;
            Arg[0, 9] = 11;
            Arg[1, 9] = -28;
            Arg[0, 10] = 10;
            Arg[1, 10] = -100;
            Arg[0, 11] = 9;
            Arg[1, 11] = -110;
            Arg[0, 12] = 8;
            Arg[1, 12] = -64;
            Arg[0, 13] = 7;
            Arg[1, 13] = 32;
            Arg[0, 14] = 6;
            Arg[1, 14] = 172;
            Arg[0, 15] = 5;
            Arg[1, 15] = 350;
            Arg[0, 16] = 4;
            Arg[1, 16] = 560;
            Arg[0, 17] = 3;
            Arg[1, 17] = 796;
            Arg[0, 18] = 2;
            Arg[1, 18] = 1052;
            Arg[0, 19] = 1;
            Arg[1, 19] = 1322;
            Arg[0, 20] = 0;
            Arg[1, 20] = 1600;
            Arg[0, 21] = -1;
            Arg[1, 21] = 1880;
            Arg[0, 22] = -2;
            Arg[1, 22] = 2156;
            Arg[0, 23] = -3;
            Arg[1, 23] = 2422;
            Arg[0, 24] = -4;
            Arg[1, 24] = 2672;
            Arg[0, 25] = -5;
            Arg[1, 25] = 2900;
            Arg[0, 26] = -6;
            Arg[1, 26] = 3100;
            Arg[0, 27] = -7;
            Arg[1, 27] = 3266;
            Arg[0, 28] = -8;
            Arg[1, 28] = 3392;
            Arg[0, 29] = -9;
            Arg[1, 29] = 3472;
            Arg[0, 30] = -10;
            Arg[1, 30] = 3500;
            Arg[0, 31] = -11;
            Arg[1, 31] = 3470;
            Arg[0, 32] = -12;
            Arg[1, 32] = 3376;
            Arg[0, 33] = -13;
            Arg[1, 33] = 3212;
            Arg[0, 34] = -14;
            Arg[1, 34] = 2972;
            Arg[0, 35] = -15;
            Arg[1, 35] = 2650;
            Arg[0, 36] = -16;
            Arg[1, 36] = 2240;
            Arg[0, 37] = -17;
            Arg[1, 37] = 1736;
            Arg[0, 38] = -18;
            Arg[1, 38] = 1132;
            Arg[0, 39] = -19;
            Arg[1, 39] = 422;
            Arg[0, 40] = -20;
            Arg[1, 40] = -400;
        }

        private double GenotypeCollections(int GenotypeIndex, int n, double[] Leaf)
        {
            switch (GenotypeIndex)
            {
                case 0: return 0 + Leaf[2] * Cos(Leaf[1] - Arg[0, n] / Leaf[0]) + Leaf[2] - Cos(Exp(Arg[0, n]) * Leaf[0] - Exp(Cos(Arg[0, n] - Pow(Arg[0, n] / Leaf[0] * Arg[0, n] / Cos(0.0001), Cos(Leaf[2] * Arg[0, n] - Cos(Cos(Cos(Cos(Arg[0, n] - Cos(Arg[0, n] / Cos(Leaf[2] + Arg[0, n] + Cos(Arg[0, n]))) - Leaf[0])) - Cos(Arg[0, n] / Cos(Leaf[2] + Arg[0, n] + Cos(Arg[0, n])))) / Leaf[4] * Arg[0, n] - Cos(Cos(Arg[0, n] - Sin(Arg[0, n] / Leaf[1])) - Cos(Leaf[2] - Cos(Cos(Cos(Cos(Arg[0, n] - Sin(Arg[0, n] / Leaf[1])) - Cos(Arg[0, n]))) * 0.0001 * Sin(Arg[0, n]) - Exp(Cos(Leaf[0] - Leaf[0]))))) * Cos(Leaf[1] * Exp(Cos(Leaf[3] - Leaf[1] * Cos(Pow(Leaf[2], Arg[0, n]) - Arg[0, n] / Cos(Cos(Leaf[2] * Arg[0, n] + Leaf[0])) - Tan(Arg[0, n])) / Leaf[1] * Leaf[5] - Arg[0, n] / Leaf[2]))) + Arg[0, n] / Cos(Arg[0, n]) + Arg[0, n] + Leaf[0]))) - Leaf[0])));

                case 1: return 0 + Sin(Arg[0, n]) * Sin(Leaf[0]) - Pow(Leaf[0], Arg[0, n]);
                case 2: return 0 + Pow(Arg[0, n], Leaf[0]) / Log(Sin(Leaf[0]), Arg[0, n]) - Log(Arg[0, n], Arg[0, n]);
                case 3: return 0 + Leaf[0] * Pow(Leaf[0], Leaf[0]) / Sin(Arg[0, n]);
                case 4: return 0 + Tan(Leaf[0]) / Log(Leaf[0], Arg[0, n]) - Pow(Leaf[0], Leaf[0]);
                case 5: return 0 + Sin(Leaf[0]) + Tan(Arg[0, n]) + Sin(Leaf[0]);
                case 6: return 0 + 0.0001 + Tan(Arg[0, n]) + Sin(Leaf[0]);
                case 7: return 0 + Cos(Sin(Arg[0, n])) / Sin(Arg[0, n]) / Exp(Arg[0, n]);
                case 8: return 0 + 0.0001 + Tan(Leaf[0]) / Cos(Leaf[0]);
                case 9: return 0 + Pow(Leaf[0], Arg[0, n]) * Sin(Leaf[0]) * Pow(Arg[0, n], Arg[0, n]);
                case 10: return 0 + Cos(Tan(Leaf[0])) + Pow(Arg[0, n], Arg[0, n]) / Log(Arg[0, n], Leaf[0]);
                case 11: return 0 + Log(Arg[0, n], Leaf[0]) + Leaf[0] / Log(Arg[0, n], Arg[0, n]);
                case 12: return 0 + Cos(Arg[0, n]) / Sin(Arg[0, n]) / Exp(Arg[0, n]);
                case 13: return 0 + Pow(0.0001, Leaf[0]) / Sin(Leaf[0]) / Tan(Arg[0, n]);
                case 14: return 0 + Sin(0.0001) * Sin(Arg[0, n]) + Sin(Arg[0, n]);
                case 15: return 0 + Tan(Leaf[0]) / 0.0001 - Pow(Leaf[0], Leaf[0]);
                case 16: return 0 + Sin(Leaf[0]) * Sin(Arg[0, n]) / Sin(Arg[0, n]);
                case 17: return 0 + Pow(Leaf[0], Leaf[0]) + Tan(Arg[0, n]) + Sin(Leaf[0]);
                case 18: return 0 + Pow(Arg[0, n], Leaf[0]) / Sin(Tan(Leaf[0])) / Tan(Arg[0, n]);
                case 19: return 0 + Pow(Leaf[0], Arg[0, n]) + Leaf[0] / Cos(Leaf[0]);
                case 20: return 0 + Sin(Arg[0, n]) + Tan(Arg[0, n]) + Sin(Leaf[0]);
                case 21: return 0 + Log(Leaf[0], Arg[0, n]) - Tan(Leaf[0]) + Sin(Leaf[0]);
                case 22: return 0 + Cos(Leaf[0]) + Pow(Arg[0, n], Arg[0, n]) / Log(Leaf[0], Leaf[0]);
                case 23: return 0 + Pow(Arg[0, n], Arg[0, n]) / Sin(Leaf[0]) / Tan(Arg[0, n]);
                case 24: return 0 + Sin(Leaf[0]) + Tan(Arg[0, n]) + Sin(Leaf[0]);
                case 25: return 0 + Pow(Leaf[0], Arg[0, n]) + Tan(Leaf[0]) / Cos(Arg[0, n]);
                case 26: return 0 + Pow(Leaf[0], Arg[0, n]) + Tan(Leaf[0]) / Arg[0, n];
                case 27: return 0 + Cos(Arg[0, n]) / Sin(Cos(Leaf[0]) / Cos(Leaf[0])) / Exp(Arg[0, n]);
                case 28: return 0 + Sin(Leaf[0]) * Pow(Leaf[0], Arg[0, n]) / Sin(Arg[0, n]);
                case 29: return 0 + Sin(Leaf[0]) * Sin(Leaf[0]) * Pow(Arg[0, n], Arg[0, n]);
                case 30: return 0 + Pow(Leaf[0], Arg[0, n]) + 0.0001 / Cos(Leaf[0]);
                case 31: return 0 + Sin(Leaf[0]) * Pow(Leaf[0], Leaf[0]) / Sin(Tan(Leaf[0]));
                case 32: return 0 + Sin(Arg[0, n]) / Log(Leaf[0], Leaf[0]) - Pow(Leaf[0], Leaf[0]);
                case 33: return 0 + Sin(Arg[0, n]) * Sin(Arg[0, n]) + Tan(Leaf[0]);
                case 34: return 0 + Pow(Arg[0, n], Leaf[0]) / Leaf[0] / Tan(Arg[0, n]);
                case 35: return 0 + Sin(Sin(Leaf[0])) * Pow(Leaf[0], Leaf[0]) / Sin(Arg[0, n]);
                case 36: return 0 + Tan(Leaf[0]) / Log(Arg[0, n], Leaf[0]) - Pow(Leaf[0], Leaf[0]);
                case 37: return 0 + Sin(Arg[0, n]) * Sin(Leaf[0]) * Pow(Arg[0, n], Leaf[0] + Cos(Leaf[0]));
                case 38: return 0 + Pow(Leaf[0], Arg[0, n]) + Tan(Leaf[0]) / 0.0001;
                case 39: return 0 + Sin(Arg[0, n]) + 0.0001 + Sin(Leaf[0]);
                case 40: return 0 + Sin(Leaf[0]) + Tan(Arg[0, n]) + Sin(Leaf[0]);
                case 41: return 0 + Sin(Arg[0, n]) * Pow(Leaf[0], Leaf[0]) / Sin(Arg[0, n]);
                case 42: return 0 + Sin(Arg[0, n]) * Sin(Leaf[0]) * Pow(Tan(Leaf[0]) + Sin(Leaf[0]), Arg[0, n]);
                case 43: return 0 + Pow(Leaf[0], Arg[0, n]) + Arg[0, n] / Cos(Leaf[0]);
                case 44: return 0 + Sin(Leaf[0]) * Pow(Leaf[0], Leaf[0]) / 0.0001;
                case 45: return 0 + Cos(Arg[0, n]) / Sin(Arg[0, n]) / Exp(Arg[0, n]);
                case 46: return 0 + Pow(Leaf[0], Arg[0, n]) + Tan(Leaf[0]) / Cos(Leaf[0]);
                case 47: return 0 + 0.0001 / Exp(Leaf[0]) + Pow(Arg[0, n], Arg[0, n]) / Log(Arg[0, n], Leaf[0]);
                case 48: return 0 + Pow(Arg[0, n], Leaf[0]) / Arg[0, n] / Tan(Arg[0, n]);
                case 49: return 0 + Sin(Sin(Leaf[0])) + Tan(Arg[0, n]) + Sin(Leaf[0]);
                case 50: return 0 + Pow(Arg[0, n], Leaf[0]) / Log(Cos(Leaf[0]), Arg[0, n]) - Log(Arg[0, n], Arg[0, n]);
                case 51: return 0 + Leaf[0] + Pow(Arg[0, n], Arg[0, n]) / Log(Arg[0, n], Leaf[0]);
                case 52: return 0 + Tan(Pow(Leaf[0], Arg[0, n]) / Exp(Leaf[0])) / Log(Leaf[0], Leaf[0]) - Pow(Leaf[0], Leaf[0]);
                case 53: return 0 + Leaf[0] + Tan(Leaf[0]) / Cos(Leaf[0]);
                case 54: return 0 + Cos(Arg[0, n]) / Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 55: return 0 + Sin(Arg[0, n]) * Sin(Arg[0, n]) * Pow(Arg[0, n], Arg[0, n]);
                case 56: return 0 + Sin(Leaf[0]) * Pow(Leaf[0], Leaf[0]) / Sin(Arg[0, n]);
                case 57: return 0 + Cos(Arg[0, n]) / Sin(Arg[0, n]) / Exp(Arg[0, n]);
                case 58: return 0 + Cos(Leaf[0]) + Leaf[0] / Log(Arg[0, n], Leaf[0]);
                case 59: return 0 + Pow(Leaf[0], Arg[0, n]) + Tan(Leaf[0]) / Cos(Pow(Arg[0, n], Arg[0, n]));
                case 60: return 0 + Cos(Tan(Leaf[0])) / Sin(Arg[0, n]) / Exp(Arg[0, n]);
                case 61: return 0 + Pow(Leaf[0], Arg[0, n]) + Arg[0, n] / Cos(Leaf[0]);
                case 62: return 0 + Pow(Leaf[0], Arg[0, n]) + Tan(Leaf[0]) / Cos(Tan(Arg[0, n]));
                case 63: return 0 + Tan(Arg[0, n]) - Leaf[0] - Tan(Arg[0, n]);
                case 64: return 0 + Pow(Sin(Arg[0, n]), Leaf[0]) / Log(Leaf[0], Arg[0, n]) - Log(Arg[0, n], Arg[0, n]);
                case 65: return 0 + Sin(Arg[0, n]) * Arg[0, n] + Sin(Arg[0, n]);
                case 66: return 0 + Sin(Arg[0, n]) * Sin(Leaf[0]) * Pow(Arg[0, n], Arg[0, n]);
                case 67: return 0 + Pow(Leaf[0], Arg[0, n]) + Tan(Leaf[0]) / Cos(Leaf[0]);
                case 68: return 0 + Tan(Sin(Arg[0, n])) / Log(Leaf[0], Leaf[0]) - Pow(Leaf[0], Leaf[0]);
                case 69: return 0 + Leaf[0] * Sin(Arg[0, n]) + Sin(Arg[0, n]);
                case 70: return 0 + Sin(0.0001 + Cos(Leaf[0])) * Sin(Arg[0, n]) + Sin(Arg[0, n]);
                case 71: return 0 + Pow(Leaf[0], Arg[0, n]) + Tan(Leaf[0]) / Arg[0, n];
                case 72: return 0 + Sin(Arg[0, n]) + Tan(Arg[0, n]) + Pow(Leaf[0], Leaf[0]);
                case 73: return 0 + Tan(Leaf[0]) / Log(Leaf[0], Leaf[0]) - Sin(Leaf[0]);
                case 74: return 0 + Pow(Leaf[0], Arg[0, n]) + Tan(Leaf[0]) / Cos(0.0001);
                case 75: return 0 + Leaf[0] / Sin(Arg[0, n]) / Exp(Arg[0, n]);
                case 76: return 0 + Sin(Arg[0, n]) * Sin(Arg[0, n]) + Sin(Leaf[0]);
                case 77: return 0 + Pow(Arg[0, n], Leaf[0]) / Sin(Arg[0, n]) / Tan(Arg[0, n]);
                case 78: return 0 + Pow(Sin(Leaf[0]) + Tan(Arg[0, n]), Leaf[0]) / Log(Leaf[0], Arg[0, n]) - Log(Arg[0, n], Arg[0, n]);
                case 79: return 0 + Sin(Arg[0, n]) * Arg[0, n] + Pow(Arg[0, n], Leaf[0]) * Pow(Arg[0, n], Arg[0, n]);
                case 80: return 0 + Pow(Arg[0, n], Leaf[0]) / Sin(0.0001) / Tan(Arg[0, n]);
                case 81: return 0 + Sin(Arg[0, n]) * Sin(Arg[0, n]) + Leaf[0];
                case 82: return 0 + Cos(Leaf[0]) + Leaf[0] / Log(Arg[0, n], Leaf[0]);
                case 83: return 0 + Pow(Arg[0, n], 0.0001 / Exp(Leaf[0])) / Log(Leaf[0], Arg[0, n]) - Log(Arg[0, n], Arg[0, n]);
                case 84: return 0 + Sin(0.0001) * Sin(Arg[0, n]) + Sin(Arg[0, n]);
                case 85: return 0 + Arg[0, n] / Log(Leaf[0], Arg[0, n]) - Log(Arg[0, n], Arg[0, n]);
                case 86: return 0 + Pow(Leaf[0], Arg[0, n]) + Tan(Leaf[0]) / Cos(Leaf[0]);
                case 87: return 0 + Sin(Arg[0, n]) * Sin(Leaf[0]) * Pow(Arg[0, n], Arg[0, n]);
                case 88: return 0 + Cos(Leaf[0]) + Pow(Arg[0, n], Arg[0, n]) / Log(Arg[0, n], Leaf[0]);
                case 89: return 0 + Sin(Arg[0, n]) + Tan(Arg[0, n]) + Sin(Leaf[0]);
                case 90: return 0 + Cos(Leaf[0]) + Pow(Leaf[0], Arg[0, n]) / Log(Arg[0, n], Leaf[0]);
                case 91: return 0 + Pow(Arg[0, n], Arg[0, n] - Cos(Arg[0, n])) / Sin(Leaf[0]) / Tan(Arg[0, n]);
                case 92: return 0 + Cos(0.0001) / Sin(Arg[0, n]) / Exp(Arg[0, n]);
                case 93: return 0 + Cos(Arg[0, n]) + Pow(Arg[0, n], Arg[0, n]) / Log(Arg[0, n], Leaf[0]);
                case 94: return 0 + Cos(Arg[0, n]) * Pow(Leaf[0], Leaf[0]) / Sin(Arg[0, n]);
                case 95: return 0 + Sin(Leaf[0]) / Sin(Arg[0, n]) / Exp(Arg[0, n]);
                case 96: return 0 + Tan(Leaf[0]) / Log(Sin(Arg[0, n]), Leaf[0]) - Pow(Leaf[0], Leaf[0]);
                case 97: return 0 + Cos(Arg[0, n]) / Leaf[0] / Exp(Arg[0, n]);
                case 98: return 0 + Cos(Leaf[0]) + Arg[0, n] / Log(Arg[0, n], Leaf[0]);
                case 99: return 0 + Cos(Arg[0, n]) / Sin(Pow(Arg[0, n], Arg[0, n])) / Exp(Arg[0, n]);
                case 100: return 0 + Cos(Arg[0, n]) / Pow(Leaf[0], Arg[0, n]) / Exp(Leaf[0]);
                case 101: return 0 + Log(Leaf[0], Arg[0, n]) - Tan(Leaf[0]) + Sin(Arg[0, n]);
                case 102: return 0 + Cos(Cos(Arg[0, n])) / Pow(Leaf[0], Arg[0, n]) / Exp(Arg[0, n]);
                case 103: return 0 + Arg[0, n] / Sin(Arg[0, n]) / Exp(Arg[0, n]);
                case 104: return 0 + Exp(Arg[0, n]) + Arg[0, n] + Cos(Leaf[0]);
                case 105: return 0 + Log(Leaf[0], Leaf[0]) / Sin(Leaf[0]) / Tan(Cos(Leaf[0]));
                case 106: return 0 + Log(Leaf[0], Arg[0, n]) - Tan(Leaf[0]) + Sin(Leaf[0]);
                case 107: return 0 + Log(Arg[0, n], Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 108: return 0 + Tan(Arg[0, n]) - Tan(Arg[0, n]) - 0.0001;
                case 109: return 0 + Exp(Leaf[0]) / Tan(Arg[0, n]) + Tan(Leaf[0]);
                case 110: return 0 + Cos(Log(Leaf[0], Arg[0, n]) + Tan(Arg[0, n])) / Pow(Leaf[0], Arg[0, n]) / Exp(Arg[0, n]);
                case 111: return 0 + Arg[0, n] * Pow(Arg[0, n], Arg[0, n]) - Tan(Leaf[0]) + Sin(Leaf[0]);
                case 112: return 0 + Log(Arg[0, n], Leaf[0]) + Tan(Leaf[0]) / Sin(Leaf[0]);
                case 113: return 0 + Log(Leaf[0], Arg[0, n]) - Tan(Leaf[0]) + Log(Arg[0, n], Arg[0, n]);
                case 114: return 0 + 0.0001 + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 115: return 0 + Cos(Arg[0, n]) / Pow(Leaf[0], Arg[0, n]) / Exp(Log(Arg[0, n], Leaf[0]));
                case 116: return 0 + Log(Arg[0, n], Leaf[0]) + Tan(Tan(Arg[0, n])) / Log(Arg[0, n], Arg[0, n]);
                case 117: return 0 + Log(Leaf[0], Leaf[0]) / Sin(Leaf[0]) / Leaf[0];
                case 118: return 0 + Log(Arg[0, n], Arg[0, n]) + Tan(Leaf[0]) / Log(Arg[0, n], Arg[0, n]);
                case 119: return 0 + Log(Arg[0, n], Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Leaf[0]);
                case 120: return 0 + Log(Leaf[0], Arg[0, n]) - Tan(Leaf[0]) + Sin(Leaf[0]);
                case 121: return 0 + Sin(Arg[0, n]) * Sin(Leaf[0] * Sin(Leaf[0])) * Pow(Arg[0, n], Arg[0, n]);
                case 122: return 0 + Exp(Arg[0, n]) + Cos(Leaf[0]) + Cos(Leaf[0]);
                case 123: return 0 + Log(Arg[0, n], Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 124: return 0 + Log(Arg[0, n], Leaf[0]) + Tan(Leaf[0]) / Log(Tan(Leaf[0]), Arg[0, n]);
                case 125: return 0 + Exp(Leaf[0]) / Tan(Leaf[0]) + Arg[0, n];
                case 126: return 0 + Tan(Arg[0, n]) - Tan(Sin(Leaf[0])) - Tan(Arg[0, n]);
                case 127: return 0 + Sin(Leaf[0]) * Arg[0, n] - Pow(Leaf[0], Arg[0, n]);
                case 128: return 0 + Leaf[0] / Pow(Leaf[0], Arg[0, n]) / Exp(Arg[0, n]);
                case 129: return 0 + Exp(Arg[0, n]) + Cos(Leaf[0]) + Cos(Cos(Arg[0, n]));
                case 130: return 0 + Exp(Arg[0, n]) + Arg[0, n] + Cos(Leaf[0]);
                case 131: return 0 + Log(Arg[0, n], Leaf[0]) + Tan(Leaf[0]) / Log(Arg[0, n], Cos(Leaf[0]));
                case 132: return 0 + Log(Leaf[0], Leaf[0]) * Arg[0, n] * Log(Leaf[0], Leaf[0]);
                case 133: return 0 + Log(Log(Arg[0, n], Arg[0, n]), Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 134: return 0 + Log(Arg[0, n], Arg[0, n]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 135: return 0 + Log(Leaf[0], Leaf[0]) + Tan(Leaf[0]) / Log(Arg[0, n], Arg[0, n]);
                case 136: return 0 + Log(Leaf[0], 0.0001) / Sin(Leaf[0]) / Tan(Arg[0, n]);
                case 137: return 0 + Log(Leaf[0], Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 138: return 0 + Log(Leaf[0], Arg[0, n]) - Arg[0, n] + Sin(Leaf[0]);
                case 139: return 0 + Log(Arg[0, n], Leaf[0]) + Log(Tan(Leaf[0]), Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 140: return 0 + Sin(Leaf[0]) * Sin(Leaf[0]) - Pow(Leaf[0], Leaf[0]);
                case 141: return 0 + Log(Leaf[0], Leaf[0]) / Sin(Arg[0, n] * Tan(Leaf[0])) / Tan(Arg[0, n]);
                case 142: return 0 + Log(Arg[0, n], Leaf[0]) / Sin(Leaf[0]) / Tan(Arg[0, n]);
                case 143: return 0 + Tan(Leaf[0]) - Tan(Arg[0, n]) - Tan(Arg[0, n]);
                case 144: return 0 + Log(Leaf[0], Leaf[0]) / Sin(Leaf[0]) / 0.0001;
                case 145: return 0 + Log(Tan(Arg[0, n]), Arg[0, n]) - Tan(Leaf[0]) + Sin(Leaf[0]);
                case 146: return 0 + Log(Arg[0, n], Leaf[0]) + Leaf[0] - Log(Leaf[0], Arg[0, n]);
                case 147: return 0 + Cos(Arg[0, n]) / Pow(Log(Arg[0, n], Arg[0, n]), Arg[0, n]) / Exp(Arg[0, n]);
                case 148: return 0 + Log(Arg[0, n], Leaf[0]) + Log(Arg[0, n], Leaf[0]) - Log(Leaf[0], Arg[0, n]);
                case 149: return 0 + Exp(Leaf[0]) / Tan(Leaf[0]) + Tan(Arg[0, n]);
                case 150: return 0 + Exp(Leaf[0]) / Cos(Leaf[0]) + Tan(Leaf[0]);
                case 151: return 0 + Exp(Arg[0, n]) + Cos(Leaf[0]) + Tan(Leaf[0]);
                case 152: return 0 + Log(Leaf[0], Leaf[0]) * Log(Arg[0, n], Arg[0, n]) * Log(Leaf[0], Log(Arg[0, n], Leaf[0]));
                case 153: return 0 + Leaf[0] + Tan(Leaf[0]) / Log(Arg[0, n], Arg[0, n]);
                case 154: return 0 + Log(Arg[0, n], Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 155: return 0 + Log(Leaf[0], Leaf[0]) * Log(Arg[0, n], Arg[0, n]) * Log(Leaf[0], Leaf[0]);
                case 156: return 0 + Log(Arg[0, n], Leaf[0]) + Tan(Leaf[0]) / Log(Arg[0, n], Arg[0, n]);
                case 157: return 0 + Exp(Leaf[0]) / Tan(Leaf[0]) + Tan(Leaf[0]);
                case 158: return 0 + Sin(Leaf[0]) * Arg[0, n] - Pow(Leaf[0], Arg[0, n]);
                case 159: return 0 + Cos(Sin(Leaf[0]) + Exp(Arg[0, n])) / Pow(Leaf[0], Arg[0, n]) / Exp(Arg[0, n]);
                case 160: return 0 + Log(Leaf[0], Leaf[0]) / Leaf[0] / Tan(Arg[0, n]);
                case 161: return 0 + Exp(Sin(Leaf[0]) * Sin(Leaf[0])) / Tan(Leaf[0]) + Tan(Leaf[0]);
                case 162: return 0 + Tan(Arg[0, n]) - Tan(Arg[0, n]) - Tan(Arg[0, n]);
                case 163: return 0 + Log(Arg[0, n], Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 164: return 0 + Cos(Arg[0, n]) / Arg[0, n] / Exp(Arg[0, n]);
                case 165: return 0 + Cos(Arg[0, n]) / Sin(Pow(Leaf[0], Arg[0, n])) / Exp(Arg[0, n]);
                case 166: return 0 + Log(Leaf[0], Leaf[0]) * Log(Arg[0, n], Arg[0, n]) * Log(Leaf[0], Leaf[0]);
                case 167: return 0 + Exp(Arg[0, n]) + Cos(Leaf[0]) + Cos(Leaf[0]);
                case 168: return 0 + Log(Leaf[0], Leaf[0]) / Sin(Leaf[0]) / Tan(Arg[0, n]);
                case 169: return 0 + Exp(Arg[0, n]) + Cos(Leaf[0]) + Cos(Leaf[0]);
                case 170: return 0 + Log(Leaf[0], Arg[0, n]) - Tan(Leaf[0]) + Sin(Leaf[0]);
                case 171: return 0 + Exp(Leaf[0]) / Tan(Leaf[0]) + Tan(Leaf[0]);
                case 172: return 0 + Log(Arg[0, n], Leaf[0]) + Tan(Leaf[0]) / Leaf[0];
                case 173: return 0 + Log(Leaf[0], Leaf[0]) * Log(Arg[0, n], Arg[0, n]) * Log(Leaf[0], Log(Arg[0, n], Arg[0, n]));
                case 174: return 0 + Log(Leaf[0], Leaf[0]) / Sin(Leaf[0]) / Tan(Arg[0, n]);
                case 175: return 0 + Sin(Leaf[0]) * Sin(Leaf[0]) - Pow(Leaf[0], Arg[0, n]);
                case 176: return 0 + Tan(Arg[0, n]) - Tan(Arg[0, n]) - Leaf[0];
                case 177: return 0 + Log(Arg[0, n], Tan(Arg[0, n])) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 178: return 0 + Exp(Arg[0, n]) + Cos(Leaf[0]) + Log(Leaf[0], Arg[0, n]);
                case 179: return 0 + Log(Arg[0, n], Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Cos(Leaf[0]);
                case 180: return 0 + Cos(Arg[0, n]) / Pow(Leaf[0], Arg[0, n]) / Exp(Arg[0, n]);
                case 181: return 0 + Exp(Leaf[0]) / Tan(Leaf[0]) + Tan(Leaf[0]);
                case 182: return 0 + Exp(Leaf[0]) / Tan(Leaf[0]) + Tan(Leaf[0]);
                case 183: return 0 + Log(Arg[0, n], Leaf[0]) + Tan(Leaf[0]) + Pow(Leaf[0], Leaf[0]) / Log(Arg[0, n], Arg[0, n]);
                case 184: return 0 + Log(Leaf[0], Leaf[0]) / Arg[0, n] / Tan(Arg[0, n]);
                case 185: return 0 + Log(Arg[0, n], Leaf[0]) + Tan(Leaf[0]) / Log(Sin(Leaf[0]), Arg[0, n]);
                case 186: return 0 + Log(Leaf[0], Leaf[0]) / 0.0001 / Tan(Arg[0, n]);
                case 187: return 0 + Log(Arg[0, n], Leaf[0]) + Tan(Leaf[0]) / Log(Arg[0, n], Sin(Leaf[0]));
                case 188: return 0 + Cos(Arg[0, n]) / Sin(Leaf[0]) / Exp(Arg[0, n]);
                case 189: return 0 + Sin(Leaf[0]) * Pow(Leaf[0], Arg[0, n]) - Pow(Leaf[0], Arg[0, n]);
                case 190: return 0 + Pow(Leaf[0], Arg[0, n]) / Pow(Leaf[0], Arg[0, n]) / Exp(Arg[0, n]);
                case 191: return 0 + Sin(Leaf[0]) * Sin(Leaf[0]) - Cos(Arg[0, n]);
                case 192: return 0 + Log(Leaf[0], Leaf[0]) * Log(Arg[0, n], Arg[0, n]) * Log(0.0001, Leaf[0]);
                case 193: return 0 + 0.0001 + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 194: return 0 + Log(Arg[0, n], Leaf[0]) + Tan(Leaf[0]) / Log(Arg[0, n], Leaf[0]);
                case 195: return 0 + Log(Leaf[0], Arg[0, n]) - Tan(Arg[0, n]) + Sin(Leaf[0]);
                case 196: return 0 + Sin(Leaf[0]) * Sin(Leaf[0]) - Pow(Leaf[0], Arg[0, n]);
                case 197: return 0 + Log(Arg[0, n], Leaf[0]) + Log(Arg[0, n], Arg[0, n]) - Log(Leaf[0], Arg[0, n]);
                case 198: return 0 + Tan(Leaf[0]) + Cos(Leaf[0]) + Cos(Leaf[0]);
                case 199: return 0 + Exp(Leaf[0]) / Exp(Arg[0, n]) + Tan(Leaf[0]);

                default:
                    throw new Exception("Error 10241610. Размер популяции был изменен.");
            }
        }

        public double DeviationCollections(double[] Leaf, int index)
        {
            double temp = 0;
            for (int i = 0 + 0; i < PointsCount; i++)
                temp += Math.Abs((Arg[1, i] - GenotypeCollections(index, i, Leaf)));

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