﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.452/blob/master/LICENSE
 *
 */
#endregion

using System;

namespace ExtendedControls.ExtendedToolkit.CrashReportTool.Classes.DrDump
{
    internal class AnonymousData
    {
        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public Exception Exception { get; set; }

        /// <summary>
        /// Converts to email.
        /// </summary>
        /// <value>
        /// To e mail.
        /// </value>
        public string ToEMail { get; set; }

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public Guid? ApplicationIdentifier { get; set; }
    }
}