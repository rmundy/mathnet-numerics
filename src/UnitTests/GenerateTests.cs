﻿// <copyright file="GenerateTests.cs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://numerics.mathdotnet.com
// http://github.com/mathnet/mathnet-numerics
// http://mathnetnumerics.codeplex.com
// 
// Copyright (c) 2009-2013 Math.NET
// 
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

using System;
using System.Linq;
using NUnit.Framework;

namespace MathNet.Numerics.UnitTests
{
    [TestFixture]
    public class GenerateTests
    {
        [Test]
        public void LinearSpaced()
        {
            Assert.That(Generate.LinearSpaced(0, 0d, 2d), Is.EqualTo(new double[0]).AsCollection);
            Assert.That(Generate.LinearSpaced(1, 0d, 2d), Is.EqualTo(new[] { 2d }).AsCollection);
            Assert.That(Generate.LinearSpaced(2, 0d, 2d), Is.EqualTo(new[] { 0d, 2d }).AsCollection);
            Assert.That(Generate.LinearSpaced(3, 0d, 2d), Is.EqualTo(new[] { 0d, 1d, 2d }).AsCollection);
            Assert.That(Generate.LinearSpaced(4, 0d, 2d), Is.EqualTo(new[] { 0d, 2d/3d, 4d/3d, 2d }).Within(1e-12).AsCollection);

            Assert.That(Generate.LinearSpaced(0, 2d, 0d), Is.EqualTo(new double[0]).AsCollection);
            Assert.That(Generate.LinearSpaced(1, 2d, 0d), Is.EqualTo(new[] { 0d }).AsCollection);
            Assert.That(Generate.LinearSpaced(2, 2d, 0d), Is.EqualTo(new[] { 2d, 0d }).AsCollection);
            Assert.That(Generate.LinearSpaced(3, 2d, 0d), Is.EqualTo(new[] { 2d, 1d, 0d }).AsCollection);
            Assert.That(Generate.LinearSpaced(4, 2d, 0d), Is.EqualTo(new[] { 2d, 4d/3d, 2d/3d, 0d }).Within(1e-12).AsCollection);
        }

        [Test]
        public void LogSpaced()
        {
            Assert.That(Generate.LogSpaced(0, 0d, 2d), Is.EqualTo(new double[0]).AsCollection);
            Assert.That(Generate.LogSpaced(1, 0d, 2d), Is.EqualTo(new[] { 100.0 }).AsCollection);
            Assert.That(Generate.LogSpaced(2, 0d, 2d), Is.EqualTo(new[] { 1.0, 100.0 }).AsCollection);
            Assert.That(Generate.LogSpaced(3, 0d, 2d), Is.EqualTo(new[] { 1.0, 10.0, 100.0 }).AsCollection);
            Assert.That(Generate.LogSpaced(4, 0d, 2d), Is.EqualTo(new[] { 1.0, Math.Pow(10.0, 2.0/3.0), Math.Pow(10.0, 4.0/3.0), 100.0 }).Within(1e-12).AsCollection);

            Assert.That(Generate.LogSpaced(0, 2d, 0d), Is.EqualTo(new double[0]).AsCollection);
            Assert.That(Generate.LogSpaced(1, 2d, 0d), Is.EqualTo(new[] { 1.0 }).AsCollection);
            Assert.That(Generate.LogSpaced(2, 2d, 0d), Is.EqualTo(new[] { 100.0, 1.0 }).AsCollection);
            Assert.That(Generate.LogSpaced(3, 2d, 0d), Is.EqualTo(new[] { 100.0, 10.0, 1.0 }).AsCollection);
            Assert.That(Generate.LogSpaced(4, 2d, 0d), Is.EqualTo(new[] { 100.0, Math.Pow(10.0, 4.0/3.0), Math.Pow(10, 2.0/3.0), 1.0 }).Within(1e-12).AsCollection);

            Assert.That(Generate.LogSpaced(5, -2d, 2d), Is.EqualTo(new[] { 0.01, 0.1, 1.0, 10.0, 100.0 }).AsCollection);
            Assert.That(Generate.LogSpaced(5, 2d, -2d), Is.EqualTo(new[] { 100.0, 10.0, 1.0, 0.1, 0.01 }).AsCollection);
        }

        [Test]
        public void LinearRange()
        {
            Assert.That(Generate.LinearRange(1, 1), Is.EqualTo(new[] { 1d }).AsCollection);

            Assert.That(Generate.LinearRange(1, 3), Is.EqualTo(new[] { 1d, 2d, 3d }).AsCollection);
            Assert.That(Generate.LinearRange(-1, -3), Is.EqualTo(new[] { -1d, -2d, -3d }).AsCollection);
            Assert.That(Generate.LinearRange(-3, -1), Is.EqualTo(new[] { -3d, -2d, -1d }).AsCollection);
            Assert.That(Generate.LinearRange(1, -2), Is.EqualTo(new[] { 1d, 0d, -1d, -2d }).AsCollection);
        }

        [Test]
        public void LinearRangeStep()
        {
            Assert.That(Generate.LinearRange(1, 1, 1), Is.EqualTo(new[] { 1d }).AsCollection);

            Assert.That(Generate.LinearRange(1, -1, 2), Is.EqualTo(new double[0]).AsCollection);
            Assert.That(Generate.LinearRange(2, 1, 1), Is.EqualTo(new double[0]).AsCollection);
            Assert.That(Generate.LinearRange(1, 0, 2), Is.EqualTo(new double[0]).AsCollection);
            Assert.That(Generate.LinearRange(2, 0, 1), Is.EqualTo(new double[0]).AsCollection);

            Assert.That(Generate.LinearRange(1, 1, 5), Is.EqualTo(new[] { 1d, 2d, 3d, 4d, 5d }).AsCollection);
            Assert.That(Generate.LinearRange(1, 2, 5), Is.EqualTo(new[] { 1d, 3d, 5d }).AsCollection);
            Assert.That(Generate.LinearRange(1, 2, 6), Is.EqualTo(new[] { 1d, 3d, 5d }).AsCollection);
            Assert.That(Generate.LinearRange(1, 2, 4), Is.EqualTo(new[] { 1d, 3d }).AsCollection);

            Assert.That(Generate.LinearRange(1, -1, -3), Is.EqualTo(new[] { 1d, 0d, -1d, -2d, -3d }).AsCollection);
            Assert.That(Generate.LinearRange(1, -2, -3), Is.EqualTo(new[] { 1d, -1d, -3d }).AsCollection);
            Assert.That(Generate.LinearRange(1, -2, -4), Is.EqualTo(new[] { 1d, -1d, -3d }).AsCollection);
            Assert.That(Generate.LinearRange(1, -2, -2), Is.EqualTo(new[] { 1d, -1d }).AsCollection);
        }

        [Test]
        public void LinearRangeFloatingPoint()
        {
            Assert.That(Generate.LinearRange(1d, 1d, 1d), Is.EqualTo(new[] { 1d }).AsCollection);

            Assert.That(Generate.LinearRange(1d, -1d, 2d), Is.EqualTo(new double[0]).AsCollection);
            Assert.That(Generate.LinearRange(2d, 1d, 1d), Is.EqualTo(new double[0]).AsCollection);
            Assert.That(Generate.LinearRange(1d, 0d, 2d), Is.EqualTo(new double[0]).AsCollection);
            Assert.That(Generate.LinearRange(2d, 0d, 1d), Is.EqualTo(new double[0]).AsCollection);

            Assert.That(Generate.LinearRange(1d, 1d, 5d), Is.EqualTo(new[] { 1d, 2d, 3d, 4d, 5d }).AsCollection);
            Assert.That(Generate.LinearRange(1d, 2d, 5d), Is.EqualTo(new[] { 1d, 3d, 5d }).AsCollection);
            Assert.That(Generate.LinearRange(1d, 2d, 6d), Is.EqualTo(new[] { 1d, 3d, 5d }).AsCollection);
            Assert.That(Generate.LinearRange(1d, 2d, 4d), Is.EqualTo(new[] { 1d, 3d }).AsCollection);
            Assert.That(Generate.LinearRange(1d, 1.5d, 5d), Is.EqualTo(new[] { 1d, 2.5d, 4d }).AsCollection);
            Assert.That(Generate.LinearRange(1d, 1.5d, 6.5d), Is.EqualTo(new[] { 1d, 2.5d, 4d, 5.5d }).AsCollection);

            Assert.That(Generate.LinearRange(1d, -1d, -3d), Is.EqualTo(new[] { 1d, 0d, -1d, -2d, -3d }).AsCollection);
            Assert.That(Generate.LinearRange(1d, -2d, -3d), Is.EqualTo(new[] { 1d, -1d, -3d }).AsCollection);
            Assert.That(Generate.LinearRange(1d, -2d, -4d), Is.EqualTo(new[] { 1d, -1d, -3d }).AsCollection);
            Assert.That(Generate.LinearRange(1d, -2d, -2d), Is.EqualTo(new[] { 1d, -1d }).AsCollection);
            Assert.That(Generate.LinearRange(1d, -1.5d, -3d), Is.EqualTo(new[] { 1d, -0.5d, -2d }).AsCollection);
            Assert.That(Generate.LinearRange(1d, -1.5d, -3.5d), Is.EqualTo(new[] { 1d, -0.5d, -2d, -3.5 }).AsCollection);
            Assert.That(Generate.LinearRange(1d, -1.5d, -4d), Is.EqualTo(new[] { 1d, -0.5d, -2d, -3.5 }).AsCollection);
        }

        [Test]
        public void SinusoidalConsistentWithSequence()
        {
            Assert.That(
                Generate.SinusoidalSequence(32, 2, 5, 1, 0.5, -6).Take(1000).ToArray(),
                Is.EqualTo(Generate.Sinusoidal(1000, 32, 2, 5, 1, 0.5, -6)).AsCollection);
        }

        [Test]
        public void StepConsistentWithSequence()
        {
            Assert.That(
                Generate.StepSequence(5, 40).Take(1000).ToArray(),
                Is.EqualTo(Generate.Step(1000, 5, 40)).AsCollection);
        }

        [Test]
        public void ImpulseConsistentWithSequence()
        {
            Assert.That(
                Generate.ImpulseSequence(0, 5, 40).Take(1000).ToArray(),
                Is.EqualTo(Generate.Impulse(1000, 0, 5, 40)).AsCollection);

            Assert.That(
                Generate.ImpulseSequence(100, 5, 40).Take(1000).ToArray(),
                Is.EqualTo(Generate.Impulse(1000, 100, 5, 40)).AsCollection);
        }
    }
}
