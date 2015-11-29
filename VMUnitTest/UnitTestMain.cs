using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VM;
using System.Collections.Generic;

namespace VMUnitTest
{
    struct A
    {
        public int a { get; set; }
        public int b { get; set; }
    }
    [TestClass]
    public class UnitTestMain
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dictionary<A, int> d = new Dictionary<A, int>();
            A testA = new A() { a = 0, b = 0 };
            d.Add(testA, 0);
            Console.WriteLine(d[testA].ToString());
        }
    }
}
