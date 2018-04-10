using Microsoft.VisualStudio.TestTools.UnitTesting;
using CL.KSAF.ExpressionParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.KSAF.ExpressionParser.Tests
{
    [TestClass]
    public class TreeParserTests
    {

        [TestMethod]
        public void ParseTest()
        {
            {
                var math = new TreeParser("0-5*2/2*8");
                math.Parse();
                var result = math.JoinTreeAsString();
                Assert.AreEqual("END-*8/2*250", result);
            }
            {
                var math = new TreeParser("0-5*2/2*12");
                math.Parse();
                var result = math.JoinTreeAsString();
                Assert.AreEqual("END-*12/2*250", result);
            }
            {
                var math = new TreeParser("0-Cos(2.43-18.3+8*2/3-24.1)-Cos(12*3)");
                math.Parse();
                var result = math.JoinTreeAsString();
                Assert.AreEqual("END-Cos*312-Cos-24.1+/3*28-18.32.430", result);
            }
            {
                var math = new TreeParser("0-Pow(12*3,1+1)");
                math.Parse();
                var result = math.JoinTreeAsString();
                Assert.AreEqual("END-Pow,+11*3120", result);
            }
        }

        [TestMethod]
        public void Simplification_Common_Test()
        {
            {
                var math = new TreeParser("0-5*2");
                math.Parse();
                math.Simplification();
                var res2 = math.ReparseTree();
                Assert.AreEqual("0-10", res2);
            }
            {
                var math = new TreeParser("0-Cos(0)");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-1", res);
            }
            {
                var math = new TreeParser("0-Pow(2,2)");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-4", res);
            }
            {
                var math = new TreeParser("0-Pow(2,2)+12-10");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-2", res);
            }

            {
                var math = new TreeParser("0-Pow(Arg[0,n],2)+12-10");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-Pow(Arg[0,n],2)+2", res);
            }
        }

        [TestMethod]
        public void Simplification_HighPriopityOperations_Test()
        {
            {
                var math = new TreeParser("0-8/2/4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-1", res);
            }

            {
                var math = new TreeParser("0-8/2*4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-16", res);
            }

            {
                var math = new TreeParser("0-8*2*4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-64", res);
            }

            {
                var math = new TreeParser("0-8*2/4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-4", res);
            }
        }

        [TestMethod]
        public void Simplification_LowPriorityOperations_Test()
        {
            {
                var math = new TreeParser("0-8-2-4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-14", res);
            }

            {
                var math = new TreeParser("0-8-2+4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-6", res);
            }

            {
                var math = new TreeParser("0+8+2+4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0+14", res);
            }

            {
                var math = new TreeParser("0+8+2-4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0+6", res);
            }
        }

        [TestMethod]
        public void Simplification_WithArg_Test()
        {
            {
                var math = new TreeParser("0-8/Arg[0,n]/4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-2/Arg[0,n]", res);
            }

            {
                var math = new TreeParser("0-8*Arg[0,n]/4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-2*Arg[0,n]", res);
            }

            {
                var math = new TreeParser("0-8*Arg[0,n]*4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-32*Arg[0,n]", res);
            }

            {
                var math = new TreeParser("0-8/Arg[0,n]*4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-32/Arg[0,n]", res);
            }
        }

        [TestMethod]
        public void Simplification_WithCos_Test()
        {
            {
                var math = new TreeParser("0-8/Cos(1)/4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-3.70163143536185", res);
            }

            {
                var math = new TreeParser("0-8/Cos(1)*4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-59.2261029657896", res);
            }

            {
                var math = new TreeParser("0-8*Cos(1)/4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-1.08060461173628", res);
            }

            {
                var math = new TreeParser("0-8*Cos(1)*4");
                math.Parse();
                math.Simplification();
                var res = math.ReparseTree();
                Assert.AreEqual("0-17.2896737877805", res);
            }

        }

    }
}