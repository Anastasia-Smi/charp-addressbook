using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookUI.TestsUI;
using NUnit.Framework;



namespace AddressBookUI
{
    public class BaseTest
    {
        protected ApplicationManager app;


        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        } 
        
        //generator of  random integers
       public static  Random rnd = new Random();


        public static string GenerateRandomString(int max)
        {//create random int from 0 to max
            int l = Convert.ToInt32(rnd.NextDouble() * max);

            //create string from random symbols

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 1; i++) 
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }

    }
}
