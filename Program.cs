using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace password
{
    class Program
    {
        static void Main(string[] args)
        {
            //making of a program to get all possible 8assword for a wifi.

            //specification of all the 8 random objects for getting the values
            Random ndom = new Random();
            Random ndom1 = new Random();
            Random ndom2 = new Random();
            Random ndom3 = new Random();
            Random ndom4 = new Random();
            Random ndom5 = new Random();
            Random ndom6 = new Random();
            Random ndom7 = new Random();

            StreamWriter sw = new StreamWriter("names.txt"); //creating streamwriter class object for getting the results on a specific file
            //if file is not present it will create and if present then it will be overwritten

            int jh = 0;

            long o = 100000000; //poviding the total number of results. (There is a problem here: The total possible results should be 95^8 which is more than the specified value, hence not all possibilities will be included.)

            string[] password = new string[o];//creating the array for the storage of the values we get, so that we can check that those values dont coincide,or be the same...Hence ensuring unique combination of the characters each time

            string[] arr = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", " ", "!", "\"", "#", "$", "%", "&", "\'", "(", ")", "*", "+", ",", "-", ".", "/", ":", ";", "<", ">", "=", "?", "@", "[", "]", "\\", "^", "_", "`", "~", "{", "}", "|", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            //the above array is the range of chracters used here for the passowrd creation.
            for (int y = 0; y<o; y++)
            {
                //here we get random integers values 0-94 and get the corresponding character to it in the above range.
                int d = ndom.Next(95);
                int r = ndom.Next(95);
                int e = ndom.Next(95);
                int f = ndom.Next(95);
                int g = ndom.Next(95);
                int h = ndom.Next(95);
                int t = ndom.Next(95);
                int i = ndom.Next(95);

                string pass = arr[d] + arr[r] + arr[e] + arr[f] + arr[g] + arr[h] + arr[t] + arr[i];//joining the values to make a string

                for(int ui =y; ui >0&&jh==0; ui--)//checking the equality of the strings with any previous strings created.
                {
                    if(password[y - 1].Equals(pass))
                    {
                        jh += 1;//if equality holds true, then the value of this integer get +1 each time the euality holds true. But this will be inefficient so when the first time the equality holds true this piece of code will not repeat itself anymore.
                    }else if (!password[y - 1].Equals(pass))
                    {
                        jh += 0;
                    }
                }
                if (jh == 0)
                {
                    //printing the values on the screen if the value is non repreated and simultaneously storing it away in the asrray mentioned before.
                   password[y] = pass;
                   Console.WriteLine(pass);
                }
                else if(jh!=0)
                {
                    //incase it is a repeated value then we cant store the value in the array and cant print it on the screen, hence here y get -1 to reevaluate the value.
                    Console.WriteLine("we got a equal value");
                    --y;
                    //we get a message here and hence asks for confirmation to continue.
                    Console.ReadKey();
                }
                jh = 0;
             
                for (int rt = y; rt <= y; rt++)//using the streamwriter class object  to write to the file.
                {
                   sw.WriteLine(password[y]);
                   sw.Flush();
                }                   
            }
            Console.ReadKey();
        }
    }    
}
