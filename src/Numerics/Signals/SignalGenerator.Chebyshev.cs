// <copyright file="SignalGenerator.Chebyshev.cs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://numerics.mathdotnet.com
// http://github.com/mathnet/mathnet-numerics
// http://mathnetnumerics.codeplex.com
//
// Copyright (c) 2009-2010 Math.NET
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

namespace MathNet.Numerics.Signals
{
    using System;

    /// <summary>
    /// Generic Function Sampling and Quantization Provider
    /// </summary>
    public static partial class SignalGenerator
    {
        /// <summary>
        /// Samples a function at the roots of the Chebyshev polynomial of the first kind.
        /// </summary>
        /// <param name="function">The real-domain function to sample.</param>
        /// <param name="intervalBegin">The real domain interval begin where to start sampling.</param>
        /// <param name="intervalEnd">The real domain interval end where to stop sampling.</param>
        /// <param name="sampleCount">The number of samples to generate.</param>
        /// <typeparam name="T">The value type of the function to sample.</typeparam>
        /// <returns>Vector of the function sampled in [a,b] at (b+a)/2+(b-1)/2*cos(pi*(2i-1)/(2n))</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [Obsolete]
        public static T[] ChebyshevNodesFirstKind<T>(
            Func<double, T> function,
            double intervalBegin,
            double intervalEnd,
            int sampleCount)
        {
            var roots = FindRoots.ChebychevPolynomialFirstKind(sampleCount, intervalBegin, intervalEnd);
            var samples = new T[roots.Length];
            for (int i = 0; i < samples.Length; i++)
            {
                samples[i] = function(roots[i]);
            }
            return samples;
        }

        /// <summary>
        /// Samples a function at the roots of the Chebyshev polynomial of the second kind.
        /// </summary>
        /// <param name="function">The real-domain function to sample.</param>
        /// <param name="intervalBegin">The real domain interval begin where to start sampling.</param>
        /// <param name="intervalEnd">The real domain interval end where to stop sampling.</param>
        /// <param name="sampleCount">The number of samples to generate.</param>
        /// <typeparam name="T">The value type of the function to sample.</typeparam>
        /// <returns>Vector of the function sampled in [a,b] at (b+a)/2+(b-1)/2*cos(pi*i/(n-1))</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [Obsolete]
        public static T[] ChebyshevNodesSecondKind<T>(
            Func<double, T> function,
            double intervalBegin,
            double intervalEnd,
            int sampleCount)
        {
            var roots = FindRoots.ChebychevPolynomialSecondKind(sampleCount, intervalBegin, intervalEnd);
            var samples = new T[roots.Length];
            for (int i = 0; i < samples.Length; i++)
            {
                samples[i] = function(roots[i]);
            }
            return samples;
        }
    }
}