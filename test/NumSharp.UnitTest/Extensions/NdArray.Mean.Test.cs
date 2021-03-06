﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NumSharp.Core.Extensions;
using System.Linq;
using NumSharp.Core;

namespace NumSharp.UnitTest.Extensions
{
    [TestClass]
    public class NdArrayMeanTest
    {
        [TestMethod]
        public void MeanAxis0()
        {
            var np = Core.np.array(new double[]{1,2,3,4}).reshape(2,2);

            Assert.IsTrue(Enumerable.SequenceEqual(np.mean(0).Storage.GetData<double>(), new double[] { 2, 3 }));
        }
        [TestMethod]
        public void MeanAxis1()
        {
            var np = Core.np.array(new double[]{1,2,3,4}).reshape(2,2);
            
            Assert.IsTrue(Enumerable.SequenceEqual(np.mean(1).Storage.GetData<double>(), new double[] { 1.5, 3.5 }));
        }
        [TestMethod]
        public void MeanAxisMinus1()
        {
            var np = Core.np.array(new double[]{1,2,3,4}).reshape(2,2);

            Assert.IsTrue(Enumerable.SequenceEqual(np.mean().Storage.GetData<double>(), new double[] { 2.5 }));
            
        }
    }
}
