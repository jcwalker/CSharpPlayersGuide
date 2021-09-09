using System;

namespace VariableShop
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] arrayOfTypes = new object[14];
            arrayOfTypes[0]  = -2147483648;          // int
            arrayOfTypes[1]  = 2_147_483_648;        //uint
            arrayOfTypes[2]  = -32768;               //short 
            arrayOfTypes[3]  = 65535;                // ushort
            arrayOfTypes[4]  = 18446744073709551615; // ulong
            arrayOfTypes[5]  = -9223372036854775808; //long
            arrayOfTypes[6]  =  5e-324;              // double
            arrayOfTypes[7]  =  1.1F;                // float
            arrayOfTypes[8]  =  5.5M;                // decimal
            arrayOfTypes[9]  =  1;                   // byte
            arrayOfTypes[10] = -1;                  // singed byte
            arrayOfTypes[11] = true;                // bool
            arrayOfTypes[12] = 'a';                 // char
            arrayOfTypes[13] = "Hello";             // string

            foreach (var variableType in arrayOfTypes)
            {
                Console.WriteLine(variableType);
            }
            
        }
    }
}
