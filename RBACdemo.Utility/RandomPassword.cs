using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RBACdemo.Utility
{
  public  class RandomPassword
    {
        // Define default min and max password lengths.
        private static int DEFAULT_MIN_PASSWORD_LENGTH = 8;

        private static int DEFAULT_MAX_PASSWORD_LENGTH = 20;
        private static string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
        private static string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
        private static string PASSWORD_CHARS_NUMERIC = "23456789";
        //"*$-+?_&=!%{}/"
        private static string PASSWORD_CHARS_SPECIAL = "*$+?_&=!%/@";

        public static string Generate()
        {
            return Generate(DEFAULT_MIN_PASSWORD_LENGTH, DEFAULT_MAX_PASSWORD_LENGTH);
        }

        public static string Generate(int length)
        {
            return Generate(length, length);
        }
        public static string Generate(int minLength, int maxLength)
        {
            string functionReturnValue = null;

            if ((minLength <= 0 | maxLength <= 0 | minLength > maxLength))
            {
                functionReturnValue = null;
            }
            char[][] charGroups = new char[][] {
            PASSWORD_CHARS_UCASE.ToCharArray(),
            PASSWORD_CHARS_NUMERIC.ToCharArray(),
            PASSWORD_CHARS_SPECIAL.ToCharArray()
        };
            int[] charsLeftInGroup = new int[charGroups.Length];

            int I = 0;
            for (I = 0; I <= charsLeftInGroup.Length - 1; I++)
            {
                charsLeftInGroup[I] = charGroups[I].Length;
            }

            int[] leftGroupsOrder = new int[charGroups.Length];

            for (I = 0; I <= leftGroupsOrder.Length - 1; I++)
            {
                leftGroupsOrder[I] = I;
            }
            byte[] randomBytes = new byte[4];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            rng.GetBytes(randomBytes);

            int seed = ((randomBytes[0] & 0x7f) << 24 | randomBytes[1] << 16 | randomBytes[2] << 8 | randomBytes[3]);

            Random random = new Random(seed);

            char[] password = null;

            if ((minLength < maxLength))
            {
                password = new char[random.Next(minLength - 1, maxLength) + 1];
            }
            else
            {
                password = new char[minLength];
            }

            int nextCharIdx = 0;

            int nextGroupIdx = 0;

            int nextLeftGroupsOrderIdx = 0;

            int lastCharIdx = 0;

            int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;


            for (I = 0; I <= password.Length - 1; I++)
            {
                if ((lastLeftGroupsOrderIdx == 0))
                {
                    nextLeftGroupsOrderIdx = 0;
                }
                else
                {
                    nextLeftGroupsOrderIdx = random.Next(0, lastLeftGroupsOrderIdx);
                }

                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];

                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;

                if ((lastCharIdx == 0))
                {
                    nextCharIdx = 0;
                }
                else
                {
                    nextCharIdx = random.Next(0, lastCharIdx + 1);
                }

                password[I] = charGroups[nextGroupIdx][nextCharIdx];

                if ((lastCharIdx == 0))
                {
                    charsLeftInGroup[nextGroupIdx] = charGroups[nextGroupIdx].Length;
                }
                else
                {
                    if ((lastCharIdx != nextCharIdx))
                    {
                        char temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][lastCharIdx] = charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }

                    charsLeftInGroup[nextGroupIdx] = charsLeftInGroup[nextGroupIdx] - 1;
                }

                if ((lastLeftGroupsOrderIdx == 0))
                {
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                }
                else
                {
                    if ((lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx))
                    {
                        int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] = leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }

                    lastLeftGroupsOrderIdx = lastLeftGroupsOrderIdx - 1;
                }
            }

            functionReturnValue = new string(password);
            return functionReturnValue;
        }
    }
}
