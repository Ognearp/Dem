using DemExamReadyy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemExamReadyy.OtherClass
{
    public class TestClass
    {

        public static string Generate(int captchaleng)
        {
            string capthatext = string.Empty;
            Random random = new Random();
            for(int i=0; i < captchaleng; i++)
            {
                switch (random.Next(1, 4))
                {
                    case 1:
                        capthatext += (char)random.Next('A', 'Z');
                        break;
                    case 2:
                        capthatext += (char)random.Next('1', '9');
                        break;
                    case 3:
                        capthatext += (char)random.Next('a', 'z');
                        break;

                }
            }
            return capthatext;
        }
    }
}
