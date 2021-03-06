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
using System.Net.Mail;

namespace ActionMailer.Net {
    /// <summary>
    /// Some helpers used to dilver mail.  Reduces the need to repeat code.
    /// </summary>
    public class DeliveryHelper {
        private IMailSender _sender;
        private IMailInterceptor _interceptor;

        /// <summary>
        /// Creates a new dilvery helper to be used for sending messages.
        /// </summary>
        /// <param name="sender">The sender to use when delivering mail.</param>
        /// <param name="interceptor">The interceptor to report with while delivering mail.</param>
        public DeliveryHelper(IMailSender sender, IMailInterceptor interceptor) {
            if (interceptor == null)
                throw new ArgumentNullException("interceptor");

            if (sender == null)
                throw new ArgumentNullException("sender");

            _sender = sender;
            _interceptor = interceptor;
        }

        /// <summary>
        /// Sends the given email using the given
        /// </summary>
        /// <param name="async">Whether or not to use asynchronous delivery.</param>
        /// <param name="mail">The mail message to send.</param>
        public void Deliver(bool async, MailMessage mail) {
            if (mail == null)
                throw new ArgumentNullException("mail");

            var mailContext = new MailSendingContext(mail);
            _interceptor.OnMailSending(mailContext);

            if (mailContext.Cancel)
                return;

            if (async) {
                _sender.SendAsync(mail, AsyncSendCompleted);
                return;
            }

            _sender.Send(mail);
            _interceptor.OnMailSent(mail);
        }

        private void AsyncSendCompleted(MailMessage mail) {
            _interceptor.OnMailSent(mail);
        }
    }
}
