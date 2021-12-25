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
    }
}
