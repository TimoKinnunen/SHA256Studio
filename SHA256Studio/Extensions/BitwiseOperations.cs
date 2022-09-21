using System;

namespace SHA256Studio.Extensions
{
    public static class BitwiseOperations
    {
        //shift right
        public static uint ShiftRight(uint x, int nbitsShift)
        {
            return x >> nbitsShift;
        }

        //rotate right
        public static uint RotateRight(uint x, int nbitsShift)
        {
            return (x >> nbitsShift) | (x << (32 - nbitsShift));
        }

        //rotate left
        public static uint RotateLeft(uint x, int nbitsShift)
        {
            return (x << nbitsShift) | (x >> (32 - nbitsShift));
        }

        //XOR
        public static uint XOR(uint x, uint y)
        {
            return x ^ y;
        }

        //'lower case sigma 0' σ0
        public static uint LowerCaseSigma0(uint x)
        {
            return RotateRight(x, 7) ^ RotateRight(x, 18) ^ ShiftRight(x, 3);

            #region save this
            ////1. rotate x right 7
            //uint ROTR7 = RotateRight(x, 7);
            ////2. rotate x right 18
            //uint ROTR18 = RotateRight(x, 18);
            ////3. shift x right 3
            //uint SHR3 = ShiftRight(x, 3);
            ////4. XOR ROTR7 and ROTR18
            //uint XOR_ROTR7_ROTR18 = XOR(ROTR7, ROTR18);
            ////5. XOR XOR_ROTR7_ROTR18 and SHR3
            //return XOR(XOR_ROTR7_ROTR18, SHR3);
            #endregion save this
        }

        //'lower case sigma 1' σ1
        public static uint LowerCaseSigma1(uint x)
        {
            return RotateRight(x, 17) ^ RotateRight(x, 19) ^ ShiftRight(x, 10);

            #region save this
            ////1. rotate x right 17
            //uint ROTR17 = RotateRight(x, 17);
            ////2. rotate x right 19
            //uint ROTR19 = RotateRight(x, 19);
            ////3. shift x right 10
            //uint SHR10 = ShiftRight(x, 10);
            ////4. XOR ROTR17 and ROTR19
            //uint XOR_ROTR17_ROTR19 = XOR(ROTR17, ROTR19);
            ////5. XOR XOR_ROTR17_ROTR19 and SHR10
            //return XOR(XOR_ROTR17_ROTR19, SHR10);
            #endregion save this
        }

        //'upper case sigma 0' Σ0
        public static uint UpperCaseSigma0(uint x)
        {
            return RotateRight(x, 2) ^ RotateRight(x, 13) ^ RotateRight(x, 22);

            #region save this
            ////1. rotate x right 2
            //uint ROTR2 = RotateRight(x, 2);
            ////2. rotate x right 13
            //uint ROTR13 = RotateRight(x, 13);
            ////3. rotate x right 22
            //uint ROTR22 = RotateRight(x, 22);
            ////4. XOR ROTR2 and ROTR13
            //uint XOR_ROTR2_ROTR13 = XOR(ROTR2, ROTR13);
            ////5. XOR XOR_ROTR2_ROTR13 and ROTR22
            //return XOR(XOR_ROTR2_ROTR13, ROTR22);
            #endregion save this
        }

        //'upper case sigma 1' Σ1
        public static uint UpperCaseSigma1(uint x)
        {
            return RotateRight(x, 6) ^ RotateRight(x, 11) ^ RotateRight(x, 25);

            #region save this
            ////1. rotate x right 6
            //uint ROTR6 = RotateRight(x, 6);
            ////2. rotate x right 11
            //uint ROTR11 = RotateRight(x, 11);
            ////3. rotate x right 25
            //uint ROTR25 = RotateRight(x, 25);
            ////4. XOR ROTR6 and ROTR11
            //uint XOR_ROTR6_ROTR11 = XOR(ROTR6, ROTR11);
            ////5. XOR XOR_ROTR6_ROTR11 and ROTR25
            //return XOR(XOR_ROTR6_ROTR11, ROTR25);
            #endregion save this
        }

        // xyz choice
        public static uint ChoiceXYZ(uint x, uint y, uint z)
        {
            return ((x) & (y)) | (~x & (z));

            #region save this
            //string xString = ShowUintAsOnesAndZeroesPadLeft32(x);
            //string yString = ShowUintAsOnesAndZeroesPadLeft32(y);
            //string zString = ShowUintAsOnesAndZeroesPadLeft32(z);

            //StringBuilder stringBuilder = new StringBuilder();
            //for (int i = 31; i >= 0; i--)
            //{
            //    switch (xString[i]) //depending on x if it is '1' it takes y else if it is '0' it takes z 
            //    {
            //        case '0':
            //            stringBuilder.Insert(0, zString[i]);
            //            break;
            //        case '1':
            //            stringBuilder.Insert(0, yString[i]);
            //            break;
            //        default:
            //            break;
            //    }
            //}

            //return Convert32OnesAndZeroesToUInt(stringBuilder.ToString());
            #endregion save this
        }

        // xyz majority
        public static uint MajorityXYZ(uint x, uint y, uint z)
        {
            return ((x) & (y)) | ((x) & (z)) | ((y) & (z));

            #region save this
            //string xString = ShowUintAsOnesAndZeroesPadLeft32(x);
            //string yString = ShowUintAsOnesAndZeroesPadLeft32(y);
            //string zString = ShowUintAsOnesAndZeroesPadLeft32(z);

            //StringBuilder stringBuilder = new StringBuilder();
            //for (int i = 31; i >= 0; i--)
            //{
            //    switch (xString[i])
            //    {
            //        case '0':
            //            switch (yString[i])
            //            {
            //                case '0':
            //                    stringBuilder.Insert(0, '0'); //majority
            //                    break;
            //                case '1':
            //                    switch (zString[i])
            //                    {
            //                        case '1':
            //                            stringBuilder.Insert(0, '1'); //majority
            //                            break;
            //                        case '0':
            //                            stringBuilder.Insert(0, '0'); //majority
            //                            break;
            //                        default:
            //                            break;
            //                    }
            //                    break;
            //                default:
            //                    break;
            //            }
            //            break;
            //        case '1':
            //            switch (yString[i])
            //            {
            //                case '1':
            //                    stringBuilder.Insert(0, '1'); //majority
            //                    break;
            //                case '0':
            //                    switch (zString[i])
            //                    {
            //                        case '1':
            //                            stringBuilder.Insert(0, '1'); //majority
            //                            break;
            //                        case '0':
            //                            stringBuilder.Insert(0, '0'); //majority
            //                            break;
            //                        default:
            //                            break;
            //                    }
            //                    break;
            //                default:
            //                    break;
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //}

            //return Convert32OnesAndZeroesToUInt(stringBuilder.ToString());
            #endregion save this
        }

        //round constant cube root
        public static uint GetCalculatedRoundConstantCubeRoot(uint primenumber)
        {
            double cubeRoot = CubeRoot(primenumber);
            return (uint)((cubeRoot - (int)cubeRoot) * Math.Pow(2, 32));
        }

        //working variable square root
        public static uint GetCalculatedWorkingVariableSquareRoot(uint primenumber)
        {
            double squareRoot = SquareRoot(primenumber);
            return (uint)((squareRoot - (int)squareRoot) * Math.Pow(2, 32));
        }

        public static double CubeRoot(double x)
        {
            return Math.Pow(x, 1.0 / 3.0);
        }

        public static double SquareRoot(double x)
        {
            return Math.Pow(x, 1.0 / 2.0);
        }

        #region helpers
        //public static string ShowUintAsOnesAndZeroesPadLeft32(uint x)
        //{
        //    return Convert.ToString(x, 2).PadLeft(32, '0');
        //}

        //public static uint Convert32OnesAndZeroesToUInt(string onesAndZeroes)
        //{
        //    if (onesAndZeroes.Length != 32)
        //    {
        //        onesAndZeroes = CheckLengthPadLeft32(onesAndZeroes);
        //    }

        //    return Convert.ToUInt32(onesAndZeroes.PadLeft(32, '0'), 2);
        //}

        //public static string CheckLengthPadLeft32(string stringToCheck)
        //{
        //    if (stringToCheck.Length > 32)
        //    {
        //        stringToCheck = stringToCheck.Substring(0, 32);
        //    }

        //    if (stringToCheck.Length < 32)
        //    {
        //        stringToCheck = stringToCheck.PadLeft(32, '0');
        //    }

        //    return stringToCheck;
        //}
        #endregion helpers
    }
}
