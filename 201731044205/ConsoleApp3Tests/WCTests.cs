using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Tests
{
    [TestClass()]
    public class WCTests
    {
        [TestMethod()]
        public void BaseCountTest()
        {
            WC w = new WC();
            w.BaseCount("dgsjssk\n");


            Assert.AreEqual(w.Wordcount, 2);
        }

        [TestMethod()]
        public void BaseCountTest1()
        {
            WC w = new WC();
            w.BaseCount("dgsjssk\n");
            Assert.AreEqual(w.Charcount, 8);
        }

        [TestMethod()]
        public void CountWordsTest()
        {
            WC w = new WC();
            w.CountWords("nerer live upppp nerer live live hhkp", 3);
            Assert.AreEqual(w.putout2.Count, 3);
        }

        
    }
}