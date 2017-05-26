using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace LocationNumerals
{
    static class Constants
    {
        public const string StringRegex = "^[a-zA-Z]*$";
    }

    public class LocationNumeralConverter
    {
        //ConvertToDecimal takes in a string location numeral and produces the decimal equivilant
        public int ConvertToDecimal (string numeral)
        {
            List<string> list = new List<string>(); //list of the numerals chars
            Double result = 0;
            //apply regex to assure the string is letters only
            if (Regex.IsMatch(numeral,Constants.StringRegex))
            {
                list = StringToArray(numeral);  //produce a list of single char strings
                foreach (string item in list)
                {
                    result += Math.Pow(2,GetNumeralValue(item)); // add the value to the result
                }
            }
            else
            {
                throw new System.ArgumentException("Invalid string input " + numeral, " is not a location numeral.");
            }
            return (int)result;
        }
        //ConvertToNumeral takes in a non negative integer value and 
        //returns the abbreviated location numeral
        public string ConvertToNumeral(int decimalToConvert)
        {
            //decimal is non negative
            if (decimalToConvert > 0)
            {
                List<string> numeralList = new List<string>(); // List to store the chars
                string result;
                Double charDecimal; // numeral value of a char
                //loop through the possible values from z (25) to a (0)
                for (int i = 25; i >= 0; i--)
                {
                    charDecimal = Math.Pow(2,i); //get the numerical value of the char

                    //while it is possible to reduce the remaining value in the decimal by the current char
                    while (charDecimal <= decimalToConvert)
                    {
                        decimalToConvert -= (int)charDecimal; //remove the value from the remainder
                        numeralList.Add(GetStringValue(i)); //add the char to the list
                    }
                }
                numeralList.Reverse(); //location numerals don't have to be ordered but for simplicity of test cases
                result = string.Join("", numeralList.ToArray()); //join the string list together
                return result;
            }
            else
            {
                throw new System.ArgumentException("Invalid string input " + decimalToConvert, " cannot be negative.");
            }
        }
        //since ConvertToNumeral produces abbreviated Location Numerals 
        //we can just do a convert to decimal and back with the previously
        //created methods.
        public string AbbreviateNumeral (string numeral)
        {
            string result;
            int asDecimal;
            asDecimal = ConvertToDecimal(numeral);
            result = ConvertToNumeral(asDecimal);
            return result;
        }
        //split up a string into a string list of single chars
        private List<string> StringToArray(string input)
        {
            List<string> result = new List<string>();
            string working = input;
            for (int i = 0; i < working.Length; i++)
            {
                result.Add("" + working[i]);
            }
            return result;
        }
        //retrieve the exponential value associated with a character
        private double GetNumeralValue(string value)
        {
            switch (value.ToUpper())
            {
                case "A":
                    return (Double)LetterPowerValue.A;
                case "B":
                    return (Double)LetterPowerValue.B;
                case "C":
                    return (Double)LetterPowerValue.C;
                case "D":
                    return (Double)LetterPowerValue.D;
                case "E":
                    return (Double)LetterPowerValue.E;
                case "F":
                    return (Double)LetterPowerValue.F;
                case "G":
                    return (Double)LetterPowerValue.G;
                case "H":
                    return (Double)LetterPowerValue.H;
                case "I":
                    return (Double)LetterPowerValue.I;
                case "J":
                    return (Double)LetterPowerValue.J;
                case "K":
                    return (Double)LetterPowerValue.K;
                case "L":
                    return (Double)LetterPowerValue.L;
                case "M":
                    return (Double)LetterPowerValue.M;
                case "N":
                    return (Double)LetterPowerValue.N;
                case "O":
                    return (Double)LetterPowerValue.O;
                case "P":
                    return (Double)LetterPowerValue.P;
                case "Q":
                    return (Double)LetterPowerValue.Q;
                case "R":
                    return (Double)LetterPowerValue.R;
                case "S":
                    return (Double)LetterPowerValue.S;
                case "T":
                    return (Double)LetterPowerValue.T;
                case "U":
                    return (Double)LetterPowerValue.U;
                case "V":
                    return (Double)LetterPowerValue.V;
                case "W":
                    return (Double)LetterPowerValue.W;
                case "X":
                    return (Double)LetterPowerValue.X;
                case "Y":
                    return (Double)LetterPowerValue.Y;
                case "Z":
                    return (Double)LetterPowerValue.Z;
                default:
                    throw new System.ArgumentException("Invalid string " + value, " cannot be found.");
            }
        }
        //retrieve the letter associated with an exponential value
        private string GetStringValue(int value)
        {
            switch (value)
            {
                case 0:
                    return "a";
                case 1:
                    return "b";
                case 2:
                    return "c";
                case 3:
                    return "d";
                case 4:
                    return "e";
                case 5:
                    return "f";
                case 6:
                    return "g";
                case 7:
                    return "h";
                case 8:
                    return "i";
                case 9:
                    return "j";
                case 10:
                    return "k";
                case 11:
                    return "l";
                case 12:
                    return "m";
                case 13:
                    return "n";
                case 14:
                    return "o";
                case 15:
                    return "p";
                case 16:
                    return "q";
                case 17:
                    return "r";
                case 18:
                    return "s";
                case 19:
                    return "t";
                case 20:
                    return "u";
                case 21:
                    return "v";
                case 22:
                    return "w";
                case 23:
                    return "x";
                case 24:
                    return "y";
                case 25:
                    return "z";
                default:
                    throw new System.ArgumentException("Invalid integer " + value, " cannot be found.");
            }
        }
        //Letters line up well as an enum
        private enum LetterPowerValue
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V,
            W,
            X,
            Y,
            Z
        }

    }
}
