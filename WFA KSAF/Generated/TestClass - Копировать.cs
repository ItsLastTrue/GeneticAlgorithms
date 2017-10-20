//using System;
//using System.Collections.Generic;
//using System.Threading;
//namespace WFA_KSAF
//{
//    class SendEstimatorParams
//    {
//        public int s { get; set; }
//        public Estimator Estimator { get; set; }
//        public int CopyToRun { get; set; }
//    }
//    public class Estimator
//    {
//        char AtniErrorApostrof = ';';

//        private double[] RecFiltr = new double[250];
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

//        private double[,] Arg = new double[2, 250];
//        public int[] LeafsCountInGen = new int[200];
//        private double[,] Points = new double[200, 250];
//        private int PointsCount;
//        public string[,] FitnessCollections = new string[3, 200];
//        public List<double[]> BestLeafs = new List<double[]>();
//        public Estimator()
//        {
//            Reader();
//            CollectFitnessFunctions();

//        }
//        private void Reader()
//        {
//            PointsCount = 250;
//            Arg[0, 0] = 25;
//            Arg[1, 0] = 1999.4117;
//            Arg[0, 1] = 24.9;
//            Arg[1, 1] = 1982.0543;
//            Arg[0, 2] = 24.8;
//            Arg[1, 2] = 1966.714;
//            Arg[0, 3] = 24.7;
//            Arg[1, 3] = 1953.3361;
//            Arg[0, 4] = 24.6;
//            Arg[1, 4] = 1941.8476;
//            Arg[0, 5] = 24.5;
//            Arg[1, 5] = 1932.1576;
//            Arg[0, 6] = 24.4;
//            Arg[1, 6] = 1924.1585;
//            Arg[0, 7] = 24.3;
//            Arg[1, 7] = 1917.7269;
//            Arg[0, 8] = 24.2;
//            Arg[1, 8] = 1912.7249;
//            Arg[0, 9] = 24.1;
//            Arg[1, 9] = 1909.0015;
//            Arg[0, 10] = 24;
//            Arg[1, 10] = 1906.394;
//            Arg[0, 11] = 23.9;
//            Arg[1, 11] = 1904.7299;
//            Arg[0, 12] = 23.8;
//            Arg[1, 12] = 1903.8281;
//            Arg[0, 13] = 23.7;
//            Arg[1, 13] = 1903.5014;
//            Arg[0, 14] = 23.6;
//            Arg[1, 14] = 1903.5576;
//            Arg[0, 15] = 23.5;
//            Arg[1, 15] = 1903.8022;
//            Arg[0, 16] = 23.4;
//            Arg[1, 16] = 1904.0396;
//            Arg[0, 17] = 23.3;
//            Arg[1, 17] = 1904.0756;
//            Arg[0, 18] = 23.2;
//            Arg[1, 18] = 1903.7193;
//            Arg[0, 19] = 23.1;
//            Arg[1, 19] = 1902.7845;
//            Arg[0, 20] = 23;
//            Arg[1, 20] = 1901.0921;
//            Arg[0, 21] = 22.9;
//            Arg[1, 21] = 1898.4718;
//            Arg[0, 22] = 22.8;
//            Arg[1, 22] = 1894.7634;
//            Arg[0, 23] = 22.7;
//            Arg[1, 23] = 1889.8191;
//            Arg[0, 24] = 22.6;
//            Arg[1, 24] = 1883.5042;
//            Arg[0, 25] = 22.5;
//            Arg[1, 25] = 1875.699;
//            Arg[0, 26] = 22.4;
//            Arg[1, 26] = 1866.2998;
//            Arg[0, 27] = 22.3;
//            Arg[1, 27] = 1855.2199;
//            Arg[0, 28] = 22.2;
//            Arg[1, 28] = 1842.3906;
//            Arg[0, 29] = 22.1;
//            Arg[1, 29] = 1827.7617;
//            Arg[0, 30] = 22;
//            Arg[1, 30] = 1811.302;
//            Arg[0, 31] = 21.9;
//            Arg[1, 31] = 1793;
//            Arg[0, 32] = 21.8;
//            Arg[1, 32] = 1772.8634;
//            Arg[0, 33] = 21.7;
//            Arg[1, 33] = 1750.9195;
//            Arg[0, 34] = 21.6;
//            Arg[1, 34] = 1727.2148;
//            Arg[0, 35] = 21.5;
//            Arg[1, 35] = 1701.8143;
//            Arg[0, 36] = 21.4;
//            Arg[1, 36] = 1674.8014;
//            Arg[0, 37] = 21.3;
//            Arg[1, 37] = 1646.2762;
//            Arg[0, 38] = 21.2;
//            Arg[1, 38] = 1616.3554;
//            Arg[0, 39] = 21.1;
//            Arg[1, 39] = 1585.1707;
//            Arg[0, 40] = 21;
//            Arg[1, 40] = 1552.8674;
//            Arg[0, 41] = 20.9;
//            Arg[1, 41] = 1519.6031;
//            Arg[0, 42] = 20.8;
//            Arg[1, 42] = 1485.546;
//            Arg[0, 43] = 20.7;
//            Arg[1, 43] = 1450.8736;
//            Arg[0, 44] = 20.6;
//            Arg[1, 44] = 1415.7703;
//            Arg[0, 45] = 20.5;
//            Arg[1, 45] = 1380.4261;
//            Arg[0, 46] = 20.4;
//            Arg[1, 46] = 1345.0343;
//            Arg[0, 47] = 20.3;
//            Arg[1, 47] = 1309.79;
//            Arg[0, 48] = 20.2;
//            Arg[1, 48] = 1274.8877;
//            Arg[0, 49] = 20.1;
//            Arg[1, 49] = 1240.5196;
//            Arg[0, 50] = 20;
//            Arg[1, 50] = 1206.8737;
//            Arg[0, 51] = 19.9;
//            Arg[1, 51] = 1174.1318;
//            Arg[0, 52] = 19.8;
//            Arg[1, 52] = 1142.4678;
//            Arg[0, 53] = 19.7;
//            Arg[1, 53] = 1112.0457;
//            Arg[0, 54] = 19.6;
//            Arg[1, 54] = 1083.0184;
//            Arg[0, 55] = 19.5;
//            Arg[1, 55] = 1055.5258;
//            Arg[0, 56] = 19.4;
//            Arg[1, 56] = 1029.6935;
//            Arg[0, 57] = 19.3;
//            Arg[1, 57] = 1005.6316;
//            Arg[0, 58] = 19.2;
//            Arg[1, 58] = 983.4337;
//            Arg[0, 59] = 19.1;
//            Arg[1, 59] = 963.1756;
//            Arg[0, 60] = 19;
//            Arg[1, 60] = 944.9149;
//            Arg[0, 61] = 18.9;
//            Arg[1, 61] = 928.6902;
//            Arg[0, 62] = 18.8;
//            Arg[1, 62] = 914.5209;
//            Arg[0, 63] = 18.7;
//            Arg[1, 63] = 902.407;
//            Arg[0, 64] = 18.6;
//            Arg[1, 64] = 892.3287;
//            Arg[0, 65] = 18.5;
//            Arg[1, 65] = 884.2471;
//            Arg[0, 66] = 18.4;
//            Arg[1, 66] = 878.1044;
//            Arg[0, 67] = 18.3;
//            Arg[1, 67] = 873.8245;
//            Arg[0, 68] = 18.2;
//            Arg[1, 68] = 871.3135;
//            Arg[0, 69] = 18.1;
//            Arg[1, 69] = 870.4611;
//            Arg[0, 70] = 18;
//            Arg[1, 70] = 871.1413;
//            Arg[0, 71] = 17.9;
//            Arg[1, 71] = 873.214;
//            Arg[0, 72] = 17.8;
//            Arg[1, 72] = 876.5259;
//            Arg[0, 73] = 17.7;
//            Arg[1, 73] = 880.9126;
//            Arg[0, 74] = 17.6;
//            Arg[1, 74] = 886.1999;
//            Arg[0, 75] = 17.5;
//            Arg[1, 75] = 892.2057;
//            Arg[0, 76] = 17.4;
//            Arg[1, 76] = 898.7415;
//            Arg[0, 77] = 17.3;
//            Arg[1, 77] = 905.6148;
//            Arg[0, 78] = 17.2;
//            Arg[1, 78] = 912.6306;
//            Arg[0, 79] = 17.1;
//            Arg[1, 79] = 919.5934;
//            Arg[0, 80] = 17;
//            Arg[1, 80] = 926.3095;
//            Arg[0, 81] = 16.9;
//            Arg[1, 81] = 932.5883;
//            Arg[0, 82] = 16.8;
//            Arg[1, 82] = 938.2449;
//            Arg[0, 83] = 16.7;
//            Arg[1, 83] = 943.1015;
//            Arg[0, 84] = 16.6;
//            Arg[1, 84] = 946.9892;
//            Arg[0, 85] = 16.5;
//            Arg[1, 85] = 949.7499;
//            Arg[0, 86] = 16.4;
//            Arg[1, 86] = 951.2377;
//            Arg[0, 87] = 16.3;
//            Arg[1, 87] = 951.3204;
//            Arg[0, 88] = 16.2;
//            Arg[1, 88] = 949.8808;
//            Arg[0, 89] = 16.1;
//            Arg[1, 89] = 946.818;
//            Arg[0, 90] = 16;
//            Arg[1, 90] = 942.0483;
//            Arg[0, 91] = 15.9;
//            Arg[1, 91] = 935.5058;
//            Arg[0, 92] = 15.8;
//            Arg[1, 92] = 927.1436;
//            Arg[0, 93] = 15.7;
//            Arg[1, 93] = 916.9337;
//            Arg[0, 94] = 15.6;
//            Arg[1, 94] = 904.8678;
//            Arg[0, 95] = 15.5;
//            Arg[1, 95] = 890.9569;
//            Arg[0, 96] = 15.4;
//            Arg[1, 96] = 875.2314;
//            Arg[0, 97] = 15.3;
//            Arg[1, 97] = 857.7409;
//            Arg[0, 98] = 15.2;
//            Arg[1, 98] = 838.5537;
//            Arg[0, 99] = 15.1;
//            Arg[1, 99] = 817.7557;
//            Arg[0, 100] = 15;
//            Arg[1, 100] = 795.4502;
//            Arg[0, 101] = 14.9;
//            Arg[1, 101] = 771.7562;
//            Arg[0, 102] = 14.8;
//            Arg[1, 102] = 746.8078;
//            Arg[0, 103] = 14.7;
//            Arg[1, 103] = 720.7524;
//            Arg[0, 104] = 14.6;
//            Arg[1, 104] = 693.7494;
//            Arg[0, 105] = 14.5;
//            Arg[1, 105] = 665.9688;
//            Arg[0, 106] = 14.4;
//            Arg[1, 106] = 637.5892;
//            Arg[0, 107] = 14.3;
//            Arg[1, 107] = 608.7961;
//            Arg[0, 108] = 14.2;
//            Arg[1, 108] = 579.7801;
//            Arg[0, 109] = 14.1;
//            Arg[1, 109] = 550.7349;
//            Arg[0, 110] = 14;
//            Arg[1, 110] = 521.8555;
//            Arg[0, 111] = 13.9;
//            Arg[1, 111] = 493.3362;
//            Arg[0, 112] = 13.8;
//            Arg[1, 112] = 465.3686;
//            Arg[0, 113] = 13.7;
//            Arg[1, 113] = 438.1396;
//            Arg[0, 114] = 13.6;
//            Arg[1, 114] = 411.8299;
//            Arg[0, 115] = 13.5;
//            Arg[1, 115] = 386.6116;
//            Arg[0, 116] = 13.4;
//            Arg[1, 116] = 362.6471;
//            Arg[0, 117] = 13.3;
//            Arg[1, 117] = 340.0871;
//            Arg[0, 118] = 13.2;
//            Arg[1, 118] = 319.0691;
//            Arg[0, 119] = 13.1;
//            Arg[1, 119] = 299.7161;
//            Arg[0, 120] = 13;
//            Arg[1, 120] = 282.1355;
//            Arg[0, 121] = 12.9;
//            Arg[1, 121] = 266.4179;
//            Arg[0, 122] = 12.8;
//            Arg[1, 122] = 252.6359;
//            Arg[0, 123] = 12.7;
//            Arg[1, 123] = 240.8441;
//            Arg[0, 124] = 12.6;
//            Arg[1, 124] = 231.0777;
//            Arg[0, 125] = 12.5;
//            Arg[1, 125] = 223.3528;
//            Arg[0, 126] = 12.4;
//            Arg[1, 126] = 217.666;
//            Arg[0, 127] = 12.3;
//            Arg[1, 127] = 213.9943;
//            Arg[0, 128] = 12.2;
//            Arg[1, 128] = 212.2954;
//            Arg[0, 129] = 12.1;
//            Arg[1, 129] = 212.5084;
//            Arg[0, 130] = 12;
//            Arg[1, 130] = 214.554;
//            Arg[0, 131] = 11.9;
//            Arg[1, 131] = 218.3355;
//            Arg[0, 132] = 11.8;
//            Arg[1, 132] = 223.7398;
//            Arg[0, 133] = 11.7;
//            Arg[1, 133] = 230.6383;
//            Arg[0, 134] = 11.6;
//            Arg[1, 134] = 238.8885;
//            Arg[0, 135] = 11.5;
//            Arg[1, 135] = 248.3353;
//            Arg[0, 136] = 11.4;
//            Arg[1, 136] = 258.8122;
//            Arg[0, 137] = 11.3;
//            Arg[1, 137] = 270.1435;
//            Arg[0, 138] = 11.2;
//            Arg[1, 138] = 282.1459;
//            Arg[0, 139] = 11.1;
//            Arg[1, 139] = 294.6301;
//            Arg[0, 140] = 11;
//            Arg[1, 140] = 307.4028;
//            Arg[0, 141] = 10.9;
//            Arg[1, 141] = 320.2688;
//            Arg[0, 142] = 10.8;
//            Arg[1, 142] = 333.0328;
//            Arg[0, 143] = 10.7;
//            Arg[1, 143] = 345.5011;
//            Arg[0, 144] = 10.6;
//            Arg[1, 144] = 357.4842;
//            Arg[0, 145] = 10.5;
//            Arg[1, 145] = 368.7981;
//            Arg[0, 146] = 10.4;
//            Arg[1, 146] = 379.2661;
//            Arg[0, 147] = 10.3;
//            Arg[1, 147] = 388.7211;
//            Arg[0, 148] = 10.2;
//            Arg[1, 148] = 397.0069;
//            Arg[0, 149] = 10.1;
//            Arg[1, 149] = 403.9796;
//            Arg[0, 150] = 10;
//            Arg[1, 150] = 409.5094;
//            Arg[0, 151] = 9.9;
//            Arg[1, 151] = 413.4817;
//            Arg[0, 152] = 9.8;
//            Arg[1, 152] = 415.7984;
//            Arg[0, 153] = 9.7;
//            Arg[1, 153] = 416.3785;
//            Arg[0, 154] = 9.6;
//            Arg[1, 154] = 415.1593;
//            Arg[0, 155] = 9.5;
//            Arg[1, 155] = 412.0969;
//            Arg[0, 156] = 9.4;
//            Arg[1, 156] = 407.1667;
//            Arg[0, 157] = 9.3;
//            Arg[1, 157] = 400.3632;
//            Arg[0, 158] = 9.2;
//            Arg[1, 158] = 391.7008;
//            Arg[0, 159] = 9.1;
//            Arg[1, 159] = 381.2132;
//            Arg[0, 160] = 9;
//            Arg[1, 160] = 368.9529;
//            Arg[0, 161] = 8.9;
//            Arg[1, 161] = 354.991;
//            Arg[0, 162] = 8.8;
//            Arg[1, 162] = 339.4166;
//            Arg[0, 163] = 8.7;
//            Arg[1, 163] = 322.3354;
//            Arg[0, 164] = 8.6;
//            Arg[1, 164] = 303.8691;
//            Arg[0, 165] = 8.5;
//            Arg[1, 165] = 284.1538;
//            Arg[0, 166] = 8.4;
//            Arg[1, 166] = 263.3392;
//            Arg[0, 167] = 8.3;
//            Arg[1, 167] = 241.5863;
//            Arg[0, 168] = 8.2;
//            Arg[1, 168] = 219.0667;
//            Arg[0, 169] = 8.1;
//            Arg[1, 169] = 195.96;
//            Arg[0, 170] = 8;
//            Arg[1, 170] = 172.4527;
//            Arg[0, 171] = 7.9;
//            Arg[1, 171] = 148.736;
//            Arg[0, 172] = 7.8;
//            Arg[1, 172] = 125.0038;
//            Arg[0, 173] = 7.7;
//            Arg[1, 173] = 101.451;
//            Arg[0, 174] = 7.6;
//            Arg[1, 174] = 78.2714;
//            Arg[0, 175] = 7.5;
//            Arg[1, 175] = 55.6559;
//            Arg[0, 176] = 7.4;
//            Arg[1, 176] = 33.7904;
//            Arg[0, 177] = 7.3;
//            Arg[1, 177] = 12.8541;
//            Arg[0, 178] = 7.2;
//            Arg[1, 178] = -6.9825;
//            Arg[0, 179] = 7.1;
//            Arg[1, 179] = -25.559;
//            Arg[0, 180] = 7;
//            Arg[1, 180] = -42.727;
//            Arg[0, 181] = 6.9;
//            Arg[1, 181] = -58.3514;
//            Arg[0, 182] = 6.8;
//            Arg[1, 182] = -72.3118;
//            Arg[0, 183] = 6.7;
//            Arg[1, 183] = -84.5038;
//            Arg[0, 184] = 6.6;
//            Arg[1, 184] = -94.8399;
//            Arg[0, 185] = 6.5;
//            Arg[1, 185] = -103.2505;
//            Arg[0, 186] = 6.4;
//            Arg[1, 186] = -109.6845;
//            Arg[0, 187] = 6.3;
//            Arg[1, 187] = -114.1099;
//            Arg[0, 188] = 6.2;
//            Arg[1, 188] = -116.5142;
//            Arg[0, 189] = 6.1;
//            Arg[1, 189] = -116.9041;
//            Arg[0, 190] = 6;
//            Arg[1, 190] = -115.3061;
//            Arg[0, 191] = 5.9;
//            Arg[1, 191] = -111.7658;
//            Arg[0, 192] = 5.8;
//            Arg[1, 192] = -106.3473;
//            Arg[0, 193] = 5.7;
//            Arg[1, 193] = -99.1331;
//            Arg[0, 194] = 5.6;
//            Arg[1, 194] = -90.223;
//            Arg[0, 195] = 5.5;
//            Arg[1, 195] = -79.7328;
//            Arg[0, 196] = 5.4;
//            Arg[1, 196] = -67.7938;
//            Arg[0, 197] = 5.3;
//            Arg[1, 197] = -54.5508;
//            Arg[0, 198] = 5.2;
//            Arg[1, 198] = -40.1613;
//            Arg[0, 199] = 5.1;
//            Arg[1, 199] = -24.7934;
//            Arg[0, 200] = 5;
//            Arg[1, 200] = -8.6244;
//            Arg[0, 201] = 4.9;
//            Arg[1, 201] = 8.1608;
//            Arg[0, 202] = 4.8;
//            Arg[1, 202] = 25.3722;
//            Arg[0, 203] = 4.7;
//            Arg[1, 203] = 42.8157;
//            Arg[0, 204] = 4.6;
//            Arg[1, 204] = 60.2958;
//            Arg[0, 205] = 4.5;
//            Arg[1, 205] = 77.617;
//            Arg[0, 206] = 4.4;
//            Arg[1, 206] = 94.5862;
//            Arg[0, 207] = 4.3;
//            Arg[1, 207] = 111.0142;
//            Arg[0, 208] = 4.2;
//            Arg[1, 208] = 126.7181;
//            Arg[0, 209] = 4.1;
//            Arg[1, 209] = 141.5224;
//            Arg[0, 210] = 4;
//            Arg[1, 210] = 155.2614;
//            Arg[0, 211] = 3.9;
//            Arg[1, 211] = 167.7807;
//            Arg[0, 212] = 3.8;
//            Arg[1, 212] = 178.9385;
//            Arg[0, 213] = 3.7;
//            Arg[1, 213] = 188.6071;
//            Arg[0, 214] = 3.6;
//            Arg[1, 214] = 196.6744;
//            Arg[0, 215] = 3.5;
//            Arg[1, 215] = 203.0447;
//            Arg[0, 216] = 3.4;
//            Arg[1, 216] = 207.64;
//            Arg[0, 217] = 3.3;
//            Arg[1, 217] = 210.4003;
//            Arg[0, 218] = 3.2;
//            Arg[1, 218] = 211.2845;
//            Arg[0, 219] = 3.1;
//            Arg[1, 219] = 210.2711;
//            Arg[0, 220] = 3;
//            Arg[1, 220] = 207.3575;
//            Arg[0, 221] = 2.9;
//            Arg[1, 221] = 202.5612;
//            Arg[0, 222] = 2.8;
//            Arg[1, 222] = 195.9185;
//            Arg[0, 223] = 2.7;
//            Arg[1, 223] = 187.485;
//            Arg[0, 224] = 2.6;
//            Arg[1, 224] = 177.3344;
//            Arg[0, 225] = 2.5;
//            Arg[1, 225] = 165.5582;
//            Arg[0, 226] = 2.4;
//            Arg[1, 226] = 152.2646;
//            Arg[0, 227] = 2.3;
//            Arg[1, 227] = 137.5773;
//            Arg[0, 228] = 2.2;
//            Arg[1, 228] = 121.6345;
//            Arg[0, 229] = 2.1;
//            Arg[1, 229] = 104.5873;
//            Arg[0, 230] = 2;
//            Arg[1, 230] = 86.5983;
//            Arg[0, 231] = 1.9;
//            Arg[1, 231] = 67.8399;
//            Arg[0, 232] = 1.8;
//            Arg[1, 232] = 48.4928;
//            Arg[0, 233] = 1.7;
//            Arg[1, 233] = 28.7436;
//            Arg[0, 234] = 1.6;
//            Arg[1, 234] = 8.7835;
//            Arg[0, 235] = 1.5;
//            Arg[1, 235] = -11.1937;
//            Arg[0, 236] = 1.4;
//            Arg[1, 236] = -30.9937;
//            Arg[0, 237] = 1.3;
//            Arg[1, 237] = -50.4239;
//            Arg[0, 238] = 1.2;
//            Arg[1, 238] = -69.2948;
//            Arg[0, 239] = 1.1;
//            Arg[1, 239] = -87.4222;
//            Arg[0, 240] = 1;
//            Arg[1, 240] = -104.6291;
//            Arg[0, 241] = 0.9;
//            Arg[1, 241] = -120.7474;
//            Arg[0, 242] = 0.8;
//            Arg[1, 242] = -135.6195;
//            Arg[0, 243] = 0.7;
//            Arg[1, 243] = -149.1003;
//            Arg[0, 244] = 0.6;
//            Arg[1, 244] = -161.0581;
//            Arg[0, 245] = 0.5;
//            Arg[1, 245] = -171.3766;
//            Arg[0, 246] = 0.4;
//            Arg[1, 246] = -179.9555;
//            Arg[0, 247] = 0.3;
//            Arg[1, 247] = -186.712;
//            Arg[0, 248] = 0.2;
//            Arg[1, 248] = -191.5817;
//            Arg[0, 249] = 0.1;
//            Arg[1, 249] = -194.5192;
//            LeafsCountInGen[0] = 2;
//            LeafsCountInGen[1] = 2;
//            LeafsCountInGen[2] = 2;
//            LeafsCountInGen[3] = 2;
//            LeafsCountInGen[4] = 1;
//            LeafsCountInGen[5] = 2;
//            LeafsCountInGen[6] = 1;
//            LeafsCountInGen[7] = 2;
//            LeafsCountInGen[8] = 1;
//            LeafsCountInGen[9] = 2;
//            LeafsCountInGen[10] = 1;
//            LeafsCountInGen[11] = 2;
//            LeafsCountInGen[12] = 1;
//            LeafsCountInGen[13] = 1;
//            LeafsCountInGen[14] = 2;
//            LeafsCountInGen[15] = 2;
//            LeafsCountInGen[16] = 1;
//            LeafsCountInGen[17] = 1;
//            LeafsCountInGen[18] = 1;
//            LeafsCountInGen[19] = 1;
//            LeafsCountInGen[20] = 1;
//            LeafsCountInGen[21] = 1;
//            LeafsCountInGen[22] = 2;
//            LeafsCountInGen[23] = 2;
//            LeafsCountInGen[24] = 2;
//            LeafsCountInGen[25] = 3;
//            LeafsCountInGen[26] = 2;
//            LeafsCountInGen[27] = 1;
//            LeafsCountInGen[28] = 2;
//            LeafsCountInGen[29] = 3;
//            LeafsCountInGen[30] = 2;
//            LeafsCountInGen[31] = 2;
//            LeafsCountInGen[32] = 1;
//            LeafsCountInGen[33] = 2;
//            LeafsCountInGen[34] = 2;
//            LeafsCountInGen[35] = 2;
//            LeafsCountInGen[36] = 1;
//            LeafsCountInGen[37] = 1;
//            LeafsCountInGen[38] = 1;
//            LeafsCountInGen[39] = 1;
//            LeafsCountInGen[40] = 1;
//            LeafsCountInGen[41] = 1;
//            LeafsCountInGen[42] = 1;
//            LeafsCountInGen[43] = 1;
//            LeafsCountInGen[44] = 2;
//            LeafsCountInGen[45] = 1;
//            LeafsCountInGen[46] = 1;
//            LeafsCountInGen[47] = 1;
//            LeafsCountInGen[48] = 1;
//            LeafsCountInGen[49] = 1;
//            LeafsCountInGen[50] = 1;
//            LeafsCountInGen[51] = 2;
//            LeafsCountInGen[52] = 2;
//            LeafsCountInGen[53] = 2;
//            LeafsCountInGen[54] = 1;
//            LeafsCountInGen[55] = 1;
//            LeafsCountInGen[56] = 2;
//            LeafsCountInGen[57] = 2;
//            LeafsCountInGen[58] = 2;
//            LeafsCountInGen[59] = 2;
//            LeafsCountInGen[60] = 2;
//            LeafsCountInGen[61] = 2;
//            LeafsCountInGen[62] = 1;
//            LeafsCountInGen[63] = 1;
//            LeafsCountInGen[64] = 2;
//            LeafsCountInGen[65] = 1;
//            LeafsCountInGen[66] = 2;
//            LeafsCountInGen[67] = 2;
//            LeafsCountInGen[68] = 2;
//            LeafsCountInGen[69] = 2;
//            LeafsCountInGen[70] = 2;
//            LeafsCountInGen[71] = 2;
//            LeafsCountInGen[72] = 2;
//            LeafsCountInGen[73] = 3;
//            LeafsCountInGen[74] = 1;
//            LeafsCountInGen[75] = 1;
//            LeafsCountInGen[76] = 1;
//            LeafsCountInGen[77] = 1;
//            LeafsCountInGen[78] = 2;
//            LeafsCountInGen[79] = 2;
//            LeafsCountInGen[80] = 1;
//            LeafsCountInGen[81] = 1;
//            LeafsCountInGen[82] = 2;
//            LeafsCountInGen[83] = 2;
//            LeafsCountInGen[84] = 1;
//            LeafsCountInGen[85] = 1;
//            LeafsCountInGen[86] = 3;
//            LeafsCountInGen[87] = 2;
//            LeafsCountInGen[88] = 1;
//            LeafsCountInGen[89] = 1;
//            LeafsCountInGen[90] = 1;
//            LeafsCountInGen[91] = 3;
//            LeafsCountInGen[92] = 1;
//            LeafsCountInGen[93] = 1;
//            LeafsCountInGen[94] = 1;
//            LeafsCountInGen[95] = 2;
//            LeafsCountInGen[96] = 2;
//            LeafsCountInGen[97] = 2;
//            LeafsCountInGen[98] = 1;
//            LeafsCountInGen[99] = 1;
//            LeafsCountInGen[100] = 1;
//            LeafsCountInGen[101] = 1;
//            LeafsCountInGen[102] = 1;
//            LeafsCountInGen[103] = 1;
//            LeafsCountInGen[104] = 3;
//            LeafsCountInGen[105] = 2;
//            LeafsCountInGen[106] = 2;
//            LeafsCountInGen[107] = 1;
//            LeafsCountInGen[108] = 1;
//            LeafsCountInGen[109] = 1;
//            LeafsCountInGen[110] = 2;
//            LeafsCountInGen[111] = 2;
//            LeafsCountInGen[112] = 1;
//            LeafsCountInGen[113] = 1;
//            LeafsCountInGen[114] = 4;
//            LeafsCountInGen[115] = 4;
//            LeafsCountInGen[116] = 2;
//            LeafsCountInGen[117] = 2;
//            LeafsCountInGen[118] = 1;
//            LeafsCountInGen[119] = 1;
//            LeafsCountInGen[120] = 3;
//            LeafsCountInGen[121] = 3;
//            LeafsCountInGen[122] = 1;
//            LeafsCountInGen[123] = 1;
//            LeafsCountInGen[124] = 1;
//            LeafsCountInGen[125] = 1;
//            LeafsCountInGen[126] = 1;
//            LeafsCountInGen[127] = 1;
//            LeafsCountInGen[128] = 1;
//            LeafsCountInGen[129] = 1;
//            LeafsCountInGen[130] = 1;
//            LeafsCountInGen[131] = 1;
//            LeafsCountInGen[132] = 2;
//            LeafsCountInGen[133] = 2;
//            LeafsCountInGen[134] = 2;
//            LeafsCountInGen[135] = 2;
//            LeafsCountInGen[136] = 1;
//            LeafsCountInGen[137] = 1;
//            LeafsCountInGen[138] = 1;
//            LeafsCountInGen[139] = 1;
//            LeafsCountInGen[140] = 1;
//            LeafsCountInGen[141] = 1;
//            LeafsCountInGen[142] = 2;
//            LeafsCountInGen[143] = 2;
//            LeafsCountInGen[144] = 1;
//            LeafsCountInGen[145] = 1;
//            LeafsCountInGen[146] = 1;
//            LeafsCountInGen[147] = 2;
//            LeafsCountInGen[148] = 1;
//            LeafsCountInGen[149] = 1;
//            LeafsCountInGen[150] = 1;
//            LeafsCountInGen[151] = 1;
//            LeafsCountInGen[152] = 1;
//            LeafsCountInGen[153] = 1;
//            LeafsCountInGen[154] = 1;
//            LeafsCountInGen[155] = 1;
//            LeafsCountInGen[156] = 1;
//            LeafsCountInGen[157] = 1;
//            LeafsCountInGen[158] = 1;
//            LeafsCountInGen[159] = 1;
//            LeafsCountInGen[160] = 1;
//            LeafsCountInGen[161] = 1;
//            LeafsCountInGen[162] = 2;
//            LeafsCountInGen[163] = 2;
//            LeafsCountInGen[164] = 1;
//            LeafsCountInGen[165] = 1;
//            LeafsCountInGen[166] = 3;
//            LeafsCountInGen[167] = 4;
//            LeafsCountInGen[168] = 1;
//            LeafsCountInGen[169] = 2;
//            LeafsCountInGen[170] = 2;
//            LeafsCountInGen[171] = 2;
//            LeafsCountInGen[172] = 1;
//            LeafsCountInGen[173] = 1;
//            LeafsCountInGen[174] = 2;
//            LeafsCountInGen[175] = 2;
//            LeafsCountInGen[176] = 1;
//            LeafsCountInGen[177] = 1;
//            LeafsCountInGen[178] = 4;
//            LeafsCountInGen[179] = 4;
//            LeafsCountInGen[180] = 1;
//            LeafsCountInGen[181] = 1;
//            LeafsCountInGen[182] = 2;
//            LeafsCountInGen[183] = 2;
//            LeafsCountInGen[184] = 1;
//            LeafsCountInGen[185] = 1;
//            LeafsCountInGen[186] = 1;
//            LeafsCountInGen[187] = 1;
//            LeafsCountInGen[188] = 1;
//            LeafsCountInGen[189] = 1;
//            LeafsCountInGen[190] = 1;
//            LeafsCountInGen[191] = 2;
//            LeafsCountInGen[192] = 2;
//            LeafsCountInGen[193] = 2;
//            LeafsCountInGen[194] = 1;
//            LeafsCountInGen[195] = 1;
//            LeafsCountInGen[196] = 2;
//            LeafsCountInGen[197] = 2;
//            LeafsCountInGen[198] = 1;
//            LeafsCountInGen[199] = 1;

//        }
//        private double GenotypeCollections(int GenotypeIndex, int n, double[] Leaf)
//        {
//            switch (GenotypeIndex)
//            {
//                case 0: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 1: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], Arg[0, n] / Log(Leaf[0], Arg[0, n])), Arg[0, n]);
//                case 2: return 0 + Pow(Arg[0, n], Arg[0, n]) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 3: return 0 + Pow(Arg[0, n], Pow(Leaf[1], Leaf[0])) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], Leaf[0]), Pow(Leaf[1], Leaf[0]));
//                case 4: return 0 + Cos(Pow(Arg[0, n], Leaf[0])) + Pow(0.0001, Pow(Arg[0, n], Leaf[0])) + Sin(Leaf[0]);
//                case 5: return 0 + Cos(Pow(Arg[0, n], Leaf[0])) + Pow(0.0001, Pow(Arg[0, n], Leaf[1])) + Sin(Leaf[0]);
//                case 6: return 0 + Arg[0, n] / 0.0001 + Pow(Arg[0, n], Leaf[0]) / Arg[0, n];
//                case 7: return 0 + Arg[0, n] / Tan(Tan(Leaf[0] * Sin(Leaf[1]))) + Pow(Arg[0, n], Leaf[0]) / Arg[0, n];
//                case 8: return 0 + Leaf[0] + Sin(Leaf[0]) + Sin(Leaf[0]);
//                case 9: return 0 + Leaf[0] + Pow(Arg[0, n], Leaf[1]) + Pow(Arg[0, n], Leaf[1]);
//                case 10: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 11: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[1], Leaf[1]) / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 12: return 0 + Arg[0, n] + Cos(Pow(Arg[0, n], Leaf[0]));
//                case 13: return 0 + Leaf[0] - Leaf[0] + Pow(Arg[0, n], Leaf[0]) + Cos(Pow(Leaf[0] - Leaf[0] + Pow(Arg[0, n], Leaf[0]), Leaf[0]));
//                case 14: return 0 + Cos(Sin(Leaf[0]) - Leaf[1]) + Pow(Arg[0, n], Leaf[1]) + Pow(Leaf[0], Leaf[0]);
//                case 15: return 0 + Cos(Sin(Leaf[0]) - Leaf[1]) + Pow(Arg[0, n], Leaf[1]) + Pow(Leaf[0], Leaf[0]);
//                case 16: return 0 + Arg[0, n] + Pow(Arg[0, n], Leaf[0]) + Cos(Pow(Arg[0, n], Leaf[0]));
//                case 17: return 0 + Arg[0, n] + Pow(Arg[0, n], Leaf[0]) + Cos(Pow(Arg[0, n], Leaf[0]));
//                case 18: return 0 + Leaf[0] - Tan(0.0001) + 0.0001 + Cos(Pow(Leaf[0] - Tan(0.0001), Leaf[0]));
//                case 19: return 0 + Leaf[0] - Tan(0.0001) + Pow(Arg[0, n], Leaf[0]) + Cos(Pow(Leaf[0] - Tan(Pow(Arg[0, n], Leaf[0])), Leaf[0]));
//                case 20: return 0 + Arg[0, n] + Pow(Arg[0, n], Leaf[0]) + Leaf[0];
//                case 21: return 0 + Arg[0, n] + Pow(Arg[0, n], Leaf[0]) + Leaf[0];
//                case 22: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 23: return 0 + Leaf[0] + Pow(Leaf[1], Leaf[0]) / Pow(Leaf[0], Arg[0, n]);
//                case 24: return 0 + Cos(Pow(Arg[0, n], Leaf[1])) + 0.0001 + Sin(Leaf[0]);
//                case 25: return 0 + Cos(Pow(Arg[0, n], 0.0001 * Tan(Leaf[2]))) + Pow(Leaf[1], Pow(Arg[0, n], Leaf[1])) + Sin(Leaf[0]);
//                case 26: return 0 + Cos(Leaf[0] * Tan(Leaf[0])) + Pow(Cos(Leaf[0] * Tan(Leaf[0])), Leaf[1]) + 0.0001;
//                case 27: return 0 + 0.0001 + Pow(Arg[0, n], Leaf[0]) + 0.0001;
//                case 28: return 0 + Cos(Sin(Leaf[0])) + Pow(Arg[0, n], Leaf[1]) + Sin(Leaf[0]);
//                case 29: return 0 + Cos(Sin(Pow(Arg[0, n], Sin(Leaf[0])) / Tan(Arg[0, n])) / Exp(Leaf[2])) + Pow(Arg[0, n], Leaf[1]) + Sin(Pow(Arg[0, n], Sin(Leaf[0])) / Tan(Arg[0, n]));
//                case 30: return 0 + Cos(Sin(Leaf[0])) + Pow(Arg[0, n], Leaf[1]) + Sin(Sin(Pow(Arg[0, n], Sin(Leaf[0])) / Tan(Arg[0, n])) / Tan(Arg[0, n]));
//                case 31: return 0 + Cos(Sin(Leaf[0])) + Pow(Arg[0, n], Leaf[1]) + Pow(Arg[0, n], Sin(Leaf[0]));
//                case 32: return 0 + Leaf[0] + Pow(Arg[0, n], Leaf[0]) + Sin(Arg[0, n]);
//                case 33: return 0 + Leaf[1] + Pow(Leaf[0], Leaf[1]) + Sin(Leaf[0]);
//                case 34: return 0 + Cos(Sin(Leaf[0]) - Leaf[1]) + Pow(Arg[0, n], Leaf[1]) + Cos(Sin(Leaf[0]) - Leaf[1]) / Cos(Arg[0, n]);
//                case 35: return 0 + Sin(Sin(Cos(Sin(Leaf[0]) - Pow(Arg[0, n], Leaf[1])))) + Pow(Arg[0, n], Leaf[1]) + Sin(Sin(Cos(Sin(Leaf[0]) - Pow(Arg[0, n], Leaf[1]))));
//                case 36: return 0 + Pow(Arg[0, n], Leaf[0]) + Arg[0, n] / Pow(Pow(Arg[0, n], Leaf[0]), Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]));
//                case 37: return 0 + Pow(Arg[0, n], Leaf[0]) + Arg[0, n] / Arg[0, n] + Pow(Arg[0, n], Arg[0, n]);
//                case 38: return 0 + Pow(Arg[0, n], Leaf[0]) + Leaf[0] / Leaf[0];
//                case 39: return 0 + Pow(Arg[0, n], Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n])) + Leaf[0] / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 40: return 0 + Arg[0, n] + Pow(Arg[0, n], Arg[0, n] + Pow(Arg[0, n], Leaf[0])) + Sin(Pow(Arg[0, n], Leaf[0]));
//                case 41: return 0 + Leaf[0] + Sin(Pow(Arg[0, n], Leaf[0]));
//                case 42: return 0 + Cos(Pow(Cos(0.0001 / Exp(Arg[0, n])), Leaf[0])) + Pow(Cos(0.0001 / Exp(Arg[0, n])), Leaf[0]) + Pow(Arg[0, n], Leaf[0]);
//                case 43: return 0 + Cos(Pow(Arg[0, n], Leaf[0])) + Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[0]);
//                case 44: return 0 + Leaf[0] / Tan(Leaf[1]) + Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[0]);
//                case 45: return 0 + Arg[0, n] + Pow(Arg[0, n], Arg[0, n]) + Pow(Arg[0, n], Leaf[0]);
//                case 46: return 0 + Arg[0, n] / Tan(Arg[0, n]) + Pow(Arg[0, n], Leaf[0]) / Arg[0, n];
//                case 47: return 0 + Arg[0, n] / Tan(Arg[0, n]) + Pow(Arg[0, n], Leaf[0]) / Arg[0, n];
//                case 48: return 0 + Leaf[0] - Leaf[0] + Pow(Arg[0, n], Leaf[0]) + Cos(Pow(Leaf[0] - Tan(0.0001), Leaf[0]));
//                case 49: return 0 + Leaf[0] - Tan(0.0001) + Pow(Arg[0, n], Leaf[0]) + Cos(Pow(Leaf[0] - Tan(0.0001), 0.0001));
//                case 50: return 0 + Cos(Leaf[0]) + Pow(Arg[0, n], Leaf[0]) + Leaf[0];
//                case 51: return 0 + Cos(Sin(Leaf[0])) + Pow(Arg[0, n], Sin(Leaf[0])) + Leaf[1];
//                case 52: return 0 + Cos(Leaf[0] * Tan(Leaf[0])) + Pow(Arg[0, n], Leaf[1]) + Sin(Pow(Arg[0, n], Leaf[1]));
//                case 53: return 0 + Cos(Leaf[0] * Tan(Leaf[0])) + Sin(Pow(Arg[0, n], Leaf[1])) + Sin(Sin(Pow(Arg[0, n], Leaf[1])));
//                case 54: return 0 + Sin(0.0001) + Pow(Arg[0, n], Leaf[0]) + Sin(Pow(Arg[0, n], Pow(Arg[0, n], Leaf[0])));
//                case 55: return 0 + Sin(0.0001) + Leaf[0] + Sin(Pow(Arg[0, n], Leaf[0]));
//                case 56: return 0 + Pow(Arg[0, n], Pow(Leaf[1], Leaf[0])) + Pow(Leaf[1], Leaf[0]) / Arg[0, n];
//                case 57: return 0 + Pow(Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]), Pow(Leaf[1], Leaf[0])) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 58: return 0 + Pow(Leaf[0], Pow(Leaf[1], Leaf[0])) + Pow(Leaf[1], Leaf[0]) / Pow(Leaf[0], Arg[0, n]);
//                case 59: return 0 + Pow(Arg[0, n], Pow(Leaf[1], Arg[0, n] / Pow(Leaf[1], Leaf[1]))) + Pow(Leaf[1], Leaf[0]) / Pow(Leaf[0], Arg[0, n]);
//                case 60: return 0 + Pow(Arg[0, n], Pow(Leaf[1], Leaf[0])) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 61: return 0 + Pow(Arg[0, n], Pow(Leaf[1], Leaf[0])) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 62: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[0]);
//                case 63: return 0 + Pow(Arg[0, n], Leaf[0]) + Leaf[0] / Pow(Leaf[0] / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]), Arg[0, n]);
//                case 64: return 0 + Arg[0, n] + Pow(Arg[0, n] + Pow(Arg[0, n], Leaf[0]) * Tan(Leaf[1]), Leaf[0]) + Pow(Arg[0, n], Leaf[0]);
//                case 65: return 0 + Arg[0, n] + Pow(Arg[0, n], Leaf[0]);
//                case 66: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[1], Pow(Arg[0, n], Leaf[0])) / Arg[0, n];
//                case 67: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[1], Pow(Arg[0, n], Leaf[0])) / Pow(Pow(Arg[0, n], Leaf[0]), Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]));
//                case 68: return 0 + Cos(Sin(Sin(Pow(Arg[0, n], Sin(Leaf[0])) / Tan(Arg[0, n])))) + Pow(Arg[0, n], Leaf[1]) + Sin(Pow(Arg[0, n], Sin(Leaf[0])) / Tan(Arg[0, n]));
//                case 69: return 0 + Cos(Sin(Leaf[0])) + Pow(Arg[0, n], Leaf[1]) + Leaf[0];
//                case 70: return 0 + Pow(Pow(Pow(Arg[0, n], 0.0001), Arg[0, n]), Pow(Leaf[1], Leaf[0])) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], 0.0001), Arg[0, n]);
//                case 71: return 0 + Pow(Arg[0, n], Pow(Leaf[1], Leaf[0])) + Pow(Leaf[1], Leaf[0]) / Arg[0, n];
//                case 72: return 0 + Cos(Leaf[0] * Leaf[0] * Tan(Leaf[0])) + Pow(Arg[0, n], Leaf[1]) + Leaf[1];
//                case 73: return 0 + Cos(Tan(Leaf[0]) / Sin(Leaf[2])) + Pow(Arg[0, n], Leaf[1]) + Leaf[1];
//                case 74: return 0 + Cos(Exp(Arg[0, n])) + Pow(Cos(0.0001 / Exp(Arg[0, n])), Leaf[0]) + Pow(Arg[0, n], Leaf[0]);
//                case 75: return 0 + Cos(Pow(Arg[0, n], Leaf[0])) + Pow(Cos(0.0001 / Pow(Arg[0, n], Leaf[0])), Leaf[0]) + Pow(Arg[0, n], Leaf[0]);
//                case 76: return 0 + Arg[0, n] + Pow(Arg[0, n], Leaf[0]) + Cos(Pow(Leaf[0], Leaf[0]));
//                case 77: return 0 + Arg[0, n] + Pow(Arg[0, n], Leaf[0]) + Cos(Pow(Arg[0, n], 0.0001));
//                case 78: return 0 + Cos(Sin(Leaf[0]) - Leaf[1]) + Pow(Arg[0, n], Pow(Arg[0, n], Leaf[1])) + Sin(Sin(Cos(Sin(Leaf[0]) - Pow(Arg[0, n], Leaf[1]))));
//                case 79: return 0 + Cos(Sin(Leaf[0]) - Leaf[1]) + Leaf[1] + Sin(Sin(Cos(Sin(Leaf[0]) - Pow(Arg[0, n], Leaf[1]))));
//                case 80: return 0 + Cos(Leaf[0] * Tan(Leaf[0])) + Leaf[0] * Tan(Leaf[0]) + 0.0001;
//                case 81: return 0 + Cos(Pow(Arg[0, n], Leaf[0])) + Pow(Arg[0, n], Leaf[0]) + 0.0001;
//                case 82: return 0 + Pow(Leaf[1], Leaf[0]) + Pow(Leaf[1], Leaf[0]) / Pow(Arg[0, n], Arg[0, n]);
//                case 83: return 0 + Pow(Arg[0, n], Pow(Leaf[1], Leaf[0])) + Pow(Arg[0, n], Pow(Leaf[1], Leaf[0])) / Pow(Arg[0, n], Arg[0, n]);
//                case 84: return 0 + Pow(Arg[0, n], Leaf[0]) + 0.0001 / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 85: return 0 + Pow(Leaf[0], Leaf[0]) + Leaf[0] / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 86: return 0 + Pow(Pow(Leaf[1], Leaf[0]), Leaf[0]) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], Leaf[0]), Leaf[0] + Cos(Leaf[2]));
//                case 87: return 0 + Pow(Pow(Leaf[1], Arg[0, n] - Tan(Arg[0, n])), Leaf[0]) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 88: return 0 + Arg[0, n] + Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[0]);
//                case 89: return 0 + Arg[0, n] + Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[0]);
//                case 90: return 0 + Arg[0, n] + Leaf[0] + Leaf[0];
//                case 91: return 0 + Arg[0, n] + Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[0]) / Pow(Leaf[2], Leaf[1]);
//                case 92: return 0 + Arg[0, n] + Leaf[0] + Leaf[0];
//                case 93: return 0 + Arg[0, n] + Pow(Arg[0, n], Pow(Arg[0, n], Leaf[0])) + Leaf[0];
//                case 94: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Leaf[0]) * Cos(Arg[0, n]) / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 95: return 0 + Pow(Leaf[1], Leaf[0]) + Pow(Leaf[1], Leaf[0]) / Pow(Pow(Arg[0, n], Leaf[0]), Arg[0, n]);
//                case 96: return 0 + Cos(Sin(Cos(Pow(Leaf[0], Leaf[0]))) - Cos(Sin(Leaf[0]) - Cos(Pow(Leaf[0], Leaf[0])))) + Pow(Arg[0, n], Leaf[1]) + Cos(Pow(Leaf[0], Leaf[0]));
//                case 97: return 0 + Cos(Sin(Cos(Pow(Leaf[0], Leaf[0]))) - Cos(Sin(Leaf[0]) - Cos(Pow(Leaf[0], Leaf[0])))) + Pow(Arg[0, n], Leaf[1]) + Cos(Pow(Leaf[0], Leaf[0]));
//                case 98: return 0 + Arg[0, n] + Pow(Leaf[0], Leaf[0]) + Leaf[0];
//                case 99: return 0 + Arg[0, n] + Pow(Arg[0, n], Arg[0, n]) + Leaf[0];
//                case 100: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) / Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);
//                case 101: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) / Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);
//                case 102: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Pow(Leaf[0], Leaf[0]) / Leaf[0];
//                case 103: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Pow(Leaf[0], Leaf[0] * Pow(Arg[0, n], Arg[0, n])) / Leaf[0];
//                case 104: return 0 + 0.0001 / Tan(0.0001 / Tan(Leaf[2])) + Pow(Leaf[0], Arg[0, n] / 0.0001) / Leaf[1];
//                case 105: return 0 + 0.0001 + Pow(Leaf[0], Arg[0, n] / 0.0001) / Leaf[1];
//                case 106: return 0 + 0.0001 - Tan(0.0001) - Exp(Tan(0.0001)) + 0.0001 - Tan(0.0001) / Pow(Arg[0, n], Arg[0, n]);
//                case 107: return 0 + 0.0001 - Leaf[0] - Exp(Leaf[0]) + 0.0001 - Tan(0.0001) / Pow(Arg[0, n], Arg[0, n]);
//                case 108: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) / Pow(Pow(Leaf[0], Arg[0, n]), Leaf[0]);
//                case 109: return 0 + Pow(Arg[0, n], Arg[0, n]) + Pow(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) / Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);
//                case 110: return 0 + Pow(Arg[0, n], Pow(Leaf[0], Leaf[0])) + Pow(Leaf[0], Leaf[0]) - Leaf[1] / Pow(Leaf[0], Leaf[0]);
//                case 111: return 0 + Pow(Arg[0, n], Leaf[1]) + 0.0001 - Leaf[1] / Pow(Leaf[0], Leaf[0]);
//                case 112: return 0 + Leaf[0] + Pow(Arg[0, n], Leaf[0]) - Tan(Arg[0, n]) / Pow(Pow(Arg[0, n], Arg[0, n]), Arg[0, n]);
//                case 113: return 0 + Leaf[0] + Pow(Arg[0, n], Leaf[0]) - Tan(Arg[0, n]) / Pow(Pow(Arg[0, n], Arg[0, n]), Arg[0, n]);
//                case 114: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[1], Arg[0, n] * Log(Leaf[3], Arg[0, n])) - Cos(Pow(Leaf[0] + Pow(Leaf[0] + Cos(Leaf[2]), Leaf[0]), Leaf[0])) / Pow(Arg[0, n], Leaf[0]);
//                case 115: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[1], Arg[0, n] * Log(Leaf[3], Arg[0, n])) - Cos(Cos(Leaf[2])) / Pow(Arg[0, n], Leaf[0]);
//                case 116: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Arg[0, n], Pow(Leaf[1], Leaf[1])) + Tan(Leaf[0]) - Leaf[1] / Pow(Arg[0, n], Pow(Arg[0, n], Leaf[1]));
//                case 117: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Arg[0, n], Pow(Arg[0, n], Leaf[1])) + Tan(Leaf[0]) - Leaf[1] / Pow(Arg[0, n], Pow(Arg[0, n], Arg[0, n]));
//                case 118: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - 0.0001 / Leaf[0];
//                case 119: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Pow(Leaf[0], Leaf[0]) + Exp(Leaf[0])) - Pow(Leaf[0], Leaf[0]) / Leaf[0];
//                case 120: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Pow(Arg[0, n], Arg[0, n]), Leaf[2] + Log(Leaf[0], Pow(Arg[0, n], Leaf[1]))) - Tan(Arg[0, n]) / Pow(Arg[0, n], Arg[0, n]);
//                case 121: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Leaf[2], Leaf[2] + Log(Leaf[0], Pow(Arg[0, n], Leaf[1]))) - Tan(Arg[0, n]) / Leaf[2];
//                case 122: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Pow(Arg[0, n], Leaf[0]) / Leaf[0];
//                case 123: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Pow(Arg[0, n], Leaf[0]) / Leaf[0];
//                case 124: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) / Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);
//                case 125: return 0 + Pow(Arg[0, n], 0.0001) + Pow(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) / Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);
//                case 126: return 0 + Pow(Arg[0, n] + Pow(Arg[0, n], Leaf[0]), Leaf[0]) + 0.0001 - Tan(Tan(Tan(Arg[0, n]))) / Pow(Arg[0, n], Arg[0, n]);
//                case 127: return 0 + Pow(Arg[0, n], Leaf[0]) + 0.0001 - Tan(Tan(Tan(Arg[0, n]))) / Pow(Arg[0, n], Arg[0, n]);
//                case 128: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(0.0001, Arg[0, n]) - Tan(0.0001) / Pow(Pow(Arg[0, n], Arg[0, n]), Arg[0, n]);
//                case 129: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Arg[0, n], Arg[0, n]) - Tan(Arg[0, n]) / Pow(Pow(Arg[0, n], Arg[0, n]), Arg[0, n]);
//                case 130: return 0 + Pow(Arg[0, n], Pow(Arg[0, n], Leaf[0])) + Pow(0.0001, Leaf[0]) - Tan(Leaf[0]) / Leaf[0];
//                case 131: return 0 + Leaf[0] + Pow(0.0001, Leaf[0]) - Tan(Leaf[0]) / Leaf[0];
//                case 132: return 0 + 0.0001 / Pow(Leaf[0], Arg[0, n] / 0.0001) + Pow(Leaf[0], Arg[0, n] / 0.0001) / Leaf[1];
//                case 133: return 0 + 0.0001 / Tan(Leaf[0]) + Tan(Leaf[0]) / Leaf[1];
//                case 134: return 0 + Pow(Arg[0, n], Leaf[1]) + Tan(Leaf[0]) - Tan(Leaf[0]) / 0.0001;
//                case 135: return 0 + Leaf[1] + Tan(Leaf[0]) - Tan(Leaf[0]) / Leaf[1];
//                case 136: return 0 + Leaf[0] + Pow(0.0001, Leaf[0]) - Tan(Arg[0, n]) / Pow(Arg[0, n], Pow(Arg[0, n], Arg[0, n]));
//                case 137: return 0 + Pow(Arg[0, n], Pow(Arg[0, n], Leaf[0])) + Pow(0.0001, Leaf[0]) - Tan(Arg[0, n]) / Pow(Arg[0, n], Pow(Arg[0, n], Arg[0, n]));
//                case 138: return 0 + Pow(Leaf[0], Leaf[0]) + Leaf[0];
//                case 139: return 0 + Pow(Leaf[0], Leaf[0]) + Leaf[0];
//                case 140: return 0 + Pow(Tan(Tan(Leaf[0])), Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Tan(Leaf[0]) / Arg[0, n];
//                case 141: return 0 + Pow(Tan(Leaf[0]), Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Leaf[0] / Arg[0, n];
//                case 142: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Leaf[0], Leaf[0]) - Leaf[0];
//                case 143: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Leaf[0], Leaf[0]) - Leaf[1] / Pow(Leaf[0], Leaf[1] / Pow(Leaf[0], Leaf[0]));
//                case 144: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(0.0001, 0.0001) - Tan(Pow(0.0001, 0.0001)) / Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);
//                case 145: return 0 + Pow(Arg[0, n], Leaf[0]) + Arg[0, n] - Tan(Arg[0, n]) / Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);
//                case 146: return 0 + Leaf[0] + Pow(Leaf[0], Leaf[0]) - Tan(Pow(Leaf[0], Leaf[0])) / Arg[0, n];
//                case 147: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Pow(Arg[0, n], Leaf[1]), Leaf[0]) - Tan(Pow(Leaf[0], Leaf[0])) / Arg[0, n];
//                case 148: return 0 + Pow(Arg[0, n], Leaf[0]) + Arg[0, n];
//                case 149: return 0 + Pow(Arg[0, n], Leaf[0]) + Arg[0, n] / Cos(Pow(Arg[0, n] / Cos(Pow(Arg[0, n], Leaf[0])), Leaf[0]));
//                case 150: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Pow(Leaf[0], Leaf[0]) / Leaf[0];
//                case 151: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Pow(Leaf[0], Leaf[0]) / Leaf[0];
//                case 152: return 0 + Pow(Arg[0, n], Arg[0, n]) + Pow(0.0001, Arg[0, n]) - Tan(Arg[0, n]) / Pow(Pow(Arg[0, n], Arg[0, n]), Arg[0, n]);
//                case 153: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(0.0001, Arg[0, n]) - Tan(Arg[0, n]) / Pow(0.0001, Arg[0, n]);
//                case 154: return 0 + Pow(Leaf[0], Leaf[0]) + Leaf[0];
//                case 155: return 0 + Pow(Leaf[0], Leaf[0]) + Leaf[0];
//                case 156: return 0 + Leaf[0] + Leaf[0] - Leaf[0] + Leaf[0] - Leaf[0] + Sin(Arg[0, n]);
//                case 157: return 0 + Leaf[0] * Pow(Arg[0, n], Leaf[0]);
//                case 158: return 0 + 0.0001 - Tan(0.0001) - Exp(Leaf[0]) + 0.0001 - Tan(0.0001) / Pow(Arg[0, n], Arg[0, n]);
//                case 159: return 0 + 0.0001 - Tan(0.0001) - Exp(Leaf[0]) + 0.0001 - Tan(0.0001) / Pow(Arg[0, n], Arg[0, n]);
//                case 160: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(0.0001, Leaf[0]) - Tan(Arg[0, n]) / Pow(Arg[0, n], Leaf[0]);
//                case 161: return 0 + Arg[0, n] + Pow(0.0001, Leaf[0]) - Tan(Arg[0, n]) / Arg[0, n];
//                case 162: return 0 + Arg[0, n] + Pow(Leaf[1], Pow(Leaf[1], Pow(Leaf[1], Pow(Leaf[1], Leaf[1])))) - Tan(Leaf[0]) / Pow(Arg[0, n], Pow(Leaf[1], Pow(Leaf[1], Arg[0, n])));
//                case 163: return 0 + Arg[0, n] + Leaf[1] - Tan(Leaf[0]) / Pow(Arg[0, n], Pow(Leaf[1], Pow(Leaf[1], Arg[0, n])));
//                case 164: return 0 + Pow(Arg[0, n], Leaf[0]) + Leaf[0] - Tan(Leaf[0]) / Leaf[0];
//                case 165: return 0 + Pow(Arg[0, n], Tan(Leaf[0])) + 0.0001 - Tan(Leaf[0]) / Leaf[0];
//                case 166: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Leaf[2], Leaf[2] + Log(Arg[0, n], Pow(Leaf[0], Leaf[1]))) - Tan(Leaf[0]) / Pow(Arg[0, n], Arg[0, n]);
//                case 167: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Leaf[2], Leaf[2] + Log(Leaf[3], Pow(Leaf[0], Leaf[1]))) - Tan(Leaf[0]) / Pow(Arg[0, n], Leaf[3]);
//                case 168: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) / Arg[0, n];
//                case 169: return 0 + Pow(Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]) / Log(Arg[0, n], Leaf[1]), Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) / Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);
//                case 170: return 0 + Pow(Arg[0, n], Leaf[1]) + Tan(Leaf[0]) - Tan(Leaf[0]) / Leaf[0] - Exp(Arg[0, n]);
//                case 171: return 0 + Pow(Arg[0, n], Leaf[1]) + Tan(Leaf[0]) - Tan(Leaf[1]) / Leaf[1];
//                case 172: return 0 + Leaf[0] + Leaf[0] - Leaf[0];
//                case 173: return 0 + Leaf[0] + Leaf[0] - Leaf[0];
//                case 174: return 0 + Arg[0, n] + Pow(Leaf[1], Pow(Leaf[1], Leaf[1])) - Tan(Leaf[0]) / Pow(Arg[0, n], Pow(Leaf[1], Pow(Leaf[1], Arg[0, n])));
//                case 175: return 0 + Arg[0, n] + Pow(Leaf[1], Pow(Leaf[1], Leaf[1])) - Tan(Leaf[0]) / Pow(Arg[0, n], Pow(Leaf[1], Pow(Leaf[1], Arg[0, n])));
//                case 176: return 0 + 0.0001 + Arg[0, n] / Cos(Leaf[0]);
//                case 177: return 0 + 0.0001 + Arg[0, n] / Cos(Leaf[0]);
//                case 178: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[1], Arg[0, n] * Log(Leaf[3], Arg[0, n])) - Cos(Pow(Leaf[0] + Cos(Cos(Leaf[2])), Leaf[0])) / Pow(Arg[0, n], Leaf[0]);
//                case 179: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[1], Arg[0, n] * Log(Leaf[3], Arg[0, n])) - Cos(Pow(Leaf[0] + Leaf[2], Leaf[0])) / Pow(Arg[0, n], Leaf[0]);
//                case 180: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Pow(Leaf[0], Leaf[0]) / Leaf[0];
//                case 181: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Pow(Leaf[0], Leaf[0]) / Leaf[0];
//                case 182: return 0 + Pow(Arg[0, n], Leaf[1]) + Tan(Leaf[0]) - Tan(Leaf[0]) / 0.0001;
//                case 183: return 0 + Pow(Arg[0, n], Leaf[1]) + Tan(Leaf[1]) - Tan(Leaf[0]) / Leaf[1];
//                case 184: return 0 + Pow(Arg[0, n], Leaf[0]) + Arg[0, n] - Arg[0, n] / Pow(Arg[0, n] - Arg[0, n] / Leaf[0] * Exp(Leaf[0]), Arg[0, n]);
//                case 185: return 0 + Pow(Arg[0, n], Leaf[0]) + Arg[0, n] - Arg[0, n] / Pow(Arg[0, n] - Arg[0, n] / Leaf[0] * Exp(Leaf[0]), Arg[0, n]);
//                case 186: return 0 + Pow(Arg[0, n], Leaf[0]) + Arg[0, n] / Pow(Arg[0, n], Arg[0, n]);
//                case 187: return 0 + Pow(Arg[0, n], Leaf[0]) + 0.0001 - Tan(Tan(Tan(Arg[0, n]))) / Pow(Arg[0, n], 0.0001);
//                case 188: return 0 + Pow(Arg[0, n], Leaf[0]) + Arg[0, n] - Arg[0, n] / Pow(Arg[0, n] - Arg[0, n] / Leaf[0] * Exp(Leaf[0]), Arg[0, n]) / Pow(Arg[0, n] - Arg[0, n] / Leaf[0] * Exp(Leaf[0]), Arg[0, n]);
//                case 189: return 0 + Pow(Arg[0, n], Leaf[0]) + Arg[0, n] - 0.0001;
//                case 190: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Pow(Arg[0, n], Leaf[0]) - Arg[0, n] / Pow(Arg[0, n], Pow(Arg[0, n], Leaf[0]));
//                case 191: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Leaf[1], Leaf[1]) - Pow(Leaf[0], Leaf[1]) - Arg[0, n] / Pow(Arg[0, n], Pow(Leaf[0], Leaf[1]));
//                case 192: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Leaf[0], Pow(Arg[0, n], Leaf[1]) + Sin(Arg[0, n])) - Leaf[1] / Pow(Leaf[0], Leaf[0]);
//                case 193: return 0 + Leaf[0] + Pow(Leaf[0], Leaf[0]) - Leaf[1] / Pow(Leaf[0], Leaf[0]);
//                case 194: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(0.0001, 0.0001) - Arg[0, n] / Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);
//                case 195: return 0 + Pow(Arg[0, n], Leaf[0]) + Pow(0.0001, 0.0001) - Tan(Arg[0, n]) / Pow(Pow(Leaf[0], Arg[0, n]), Tan(Arg[0, n]));
//                case 196: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Leaf[0], Leaf[0]) - Leaf[0];
//                case 197: return 0 + Pow(Arg[0, n], Leaf[1]) + Pow(Leaf[0], Leaf[0]) - Leaf[1] / Pow(Leaf[0], Leaf[1] / Pow(Leaf[0], Leaf[0]));
//                case 198: return 0 + Pow(Pow(Arg[0, n], Leaf[0]), Leaf[0]) + Pow(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) / Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);
//                case 199: return 0 + Arg[0, n] + Pow(Leaf[0], Leaf[0]) - Tan(Arg[0, n]) / Pow(Pow(Leaf[0], Arg[0, n]), Arg[0, n]);

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
//                Points[index, i] = GenotypeCollections(index, i, Leaf);
//            }
//        }
//        public void CollectFitnessFunctions()
//        {
//            var thList = new List<Thread>();
//            int copyToRun = 2;
//            for (int s = 0; s < 200; s++)
//            {
//                BestLeafs.Add(new double[LeafsCountInGen[s]]);
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
//                //transit.RunSeveralCopyNelderMid(SEP);
//            }
//            foreach (var t in thList)
//            {
//                while (t.IsAlive) ;
//            }
//            for (int s = 0; s < 200; s++)
//            {
//                CollectBestGraphPoints(BestLeafs[s], s);
//                FitnessCollections[0, s] = BestLeafs[s][LeafsCountInGen[s]].ToString();
//                for (int i = 0; i < LeafsCountInGen[s]; i++) FitnessCollections[1, s] += BestLeafs[s][i].ToString() + AtniErrorApostrof;
//            }
//        }

//        private void RecurseFilter()
//        {
//            NeldorMidThreads nl = new NeldorMidThreads();

//            for (int s = 0; s < 200; s++)
//            {
//                for (int i = 0; i < 10; i++) RecFiltr[i] = 0;
//                nl.NeldorMid(this, s);
//                CollectBestGraphPoints(BestLeafs[s], s);
//                FitnessCollections[0, s] = BestLeafs[s][LeafsCountInGen[s]].ToString();
//                for (int i = 0; i < LeafsCountInGen[s]; i++) FitnessCollections[1, s] += BestLeafs[s][i].ToString() + AtniErrorApostrof;
//            }
//        }
//        public string GetFitnessFunctions(int i, int j)
//        {
//            return FitnessCollections[i, j];
//        }
//        public string[,] GetResultFitnessFunctions()
//        {
//            return (string[,])FitnessCollections.Clone();
//        }
//        public double GetGraphPoints(int i, int j)
//        {
//            return Points[i, j];
//        }
//        public double[,] GetResultGraphPoints()
//        {
//            return (double[,])Points.Clone();
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
//            Nmer = Est.LeafsCountInGen[genotypenumber];
//            if (Nmer == 0)
//                Est.BestLeafs[genotypenumber] = new double[1]
//            {
//                DeviationCollections(new double[1]{0} ,   genotypenumber)
//            };
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
//            Est.FitnessCollections[2, genotypenumber] = _RestartCount.ToString();
//            Est.BestLeafs[genotypenumber] = _BestLeafs;
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
