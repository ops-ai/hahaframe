﻿#region License
/* Copyright (C) 2012 by Scott W. Anderson
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion

using System;

namespace ActionMailer.Net {
    /// <summary>
    /// Thrown when ActionMailer cannot locate any views for a given EmailResult
    /// </summary>
    public class NoViewsFoundException : Exception {
        /// <summary>
        /// Thrown when ActionMailer cannot locate any views for a given EmailResult
        /// </summary>
        public NoViewsFoundException() { }

        /// <summary>
        /// Thrown when ActionMailer cannot locate any views for a given EmailResult
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        public NoViewsFoundException(string message) : base(message) { }

        /// <summary>
        /// Thrown when ActionMailer cannot locate any views for a given EmailResult
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">An inner exception which contributed to (or caused) this exception.</param>
        public NoViewsFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
