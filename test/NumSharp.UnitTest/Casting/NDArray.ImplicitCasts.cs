using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NumSharp.Core.Extensions;
using NumSharp.Core;

namespace NumSharp.UnitTest
{
    [TestClass]
    public class ImplicitCastTester
    {
        [TestMethod]
        public void ConvertFromJagged()
        {
            double[][] a = new double[3][];
            for(int idx = 0; idx < a.Length;idx++)
                a[idx] = new double[2];

            
            for (int idx = 0; idx < 3;idx++)
                for (int jdx = 0; jdx < 2;jdx++)
                    a[idx][jdx] = 10 * idx + jdx;

            NDArray b = a;

            var c = b.MakeGeneric<double>();
            
            for (int idx = 0; idx < 3;idx++)
                for (int jdx = 0; jdx < 2;jdx++)
                    Assert.IsTrue(c[idx,jdx] == a[idx][jdx]);
        }
        [TestMethod]
        public void FromDotNetVector()
        {
            NDArray nd = new double[]{1,2,3,4};

            Assert.IsTrue(((double)nd[0]) == 1);
            Assert.IsTrue(((double)nd[1]) == 2);
            Assert.IsTrue(((double)nd[2]) == 3);
            Assert.IsTrue(((double)nd[3]) == 4);
        }
        [TestMethod]
        public void FromDotNetMatrix()
        {
            NDArray nd = new double[,]{{1,2,3},{4,5,6}};

            var doubleMatr = new double[,]{{1,2,3},{4,5,6}};

            for(int idx = 0; idx < doubleMatr.GetLength(0);idx++)
                for(int jdx = 0; jdx < doubleMatr.GetLength(1);jdx++)
                    Assert.IsTrue((double)nd[idx,jdx] == doubleMatr[idx,jdx]); 
        }

        [TestMethod]
        public void FromAndToDotNetMatrix()
        {
            NDArray nd = new double[,]{{1,2,3},{4,5,6}};

            double[,] nd_ = new double[,]{{1,2,3},{4,5,6}};

            Array arr =  nd;

            double[,] doubleMatr = (double[,]) arr;

            for(int idx = 0; idx < doubleMatr.GetLength(0);idx++)
                for(int jdx = 0; jdx < doubleMatr.GetLength(1);jdx++)
                {
                    Assert.IsTrue((double)nd[idx,jdx] == doubleMatr[idx,jdx]); 
                    Assert.IsTrue(nd_[idx,jdx] == doubleMatr[idx,jdx]); 
                }
                    
        }

        [TestMethod]
        public void StringCast1()
        {
            NDArray nd = "hello";

            var a = (string) nd.Storage.GetData().GetValue(0);

            Assert.IsTrue(a == "hello");
        }

        [TestMethod]
        public void StringCast2()
        {
            NDArray nd = "[1,2,3;4,5,6]";

            var doubleMatr = new double[,] { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int idx = 0; idx < doubleMatr.GetLength(0); idx++)
                for (int jdx = 0; jdx < doubleMatr.GetLength(1); jdx++)
                    Assert.IsTrue((double)nd[idx, jdx] == doubleMatr[idx, jdx]);
        }
    }

}