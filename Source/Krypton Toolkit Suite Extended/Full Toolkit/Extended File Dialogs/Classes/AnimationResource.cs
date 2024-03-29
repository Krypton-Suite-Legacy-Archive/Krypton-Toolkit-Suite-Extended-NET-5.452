﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.452/blob/master/LICENSE
 *
 */
#endregion

using ExtendedFileDialogs.Enumerations;
using ExtendedFileDialogs.Properties;
using System;
using System.Globalization;
using System.IO;

namespace ExtendedFileDialogs.Classes
{
    /// <summary>
    /// Represents an animation for the <see cref="ProgressDialog"/> loaded from a Win32 resource.
    /// </summary>
    /// <threadsafety instance="false" static="true" />
    public sealed class AnimationResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationResource"/> class.
        /// </summary>
        /// <param name="resourceFile">The file containing the animation resource.</param>
        /// <param name="resourceId">The resource ID of the animation resource.</param>
        /// <exception cref="ArgumentNullException"><paramref name="resourceFile"/> is <see langword="null"/>.</exception>
        public AnimationResource(string resourceFile, int resourceId)
        {
            if (resourceFile == null)
                throw new ArgumentNullException("resourceFile");

            ResourceFile = resourceFile;
            ResourceId = resourceId;
        }

        /// <summary>
        /// Gets the name of the file containing the animation resource.
        /// </summary>
        /// <value>
        /// The name of the file containing the animation resource. This is typically a DLL or EXE file.
        /// </value>
        public string ResourceFile { get; private set; }

        /// <summary>
        /// Gets the ID of the animation resource.
        /// </summary>
        /// <value>
        /// The ID of the animation resource.
        /// </value>
        public int ResourceId { get; private set; }

        /// <summary>
        /// Gets a default animation from shell32.dll.
        /// </summary>
        /// <param name="animation">The animation to get.</param>
        /// <returns>An instance of the <see cref="AnimationResource"/> class representing the specified animation.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="animation"/> parameter was not a value defined in the
        /// <see cref="ShellAnimation"/> enumeration.</exception>
        public static AnimationResource GetShellAnimation(ShellAnimation animation)
        {
            if (!Enum.IsDefined(typeof(ShellAnimation), animation))
                throw new ArgumentOutOfRangeException("animation");

            return new AnimationResource("shell32.dll", (int)animation);
        }

        internal SafeModuleHandle LoadLibrary()
        {
            SafeModuleHandle handle = NativeMethods.LoadLibraryEx(ResourceFile, IntPtr.Zero, NativeMethods.LoadLibraryExFlags.LoadLibraryAsDatafile);
            if (handle.IsInvalid)
            {
                int error = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                if (error == NativeMethods.ErrorFileNotFound)
                    throw new FileNotFoundException(string.Format(CultureInfo.CurrentCulture, Resources.FileNotFoundFormat, ResourceFile));
                else
                    throw new System.ComponentModel.Win32Exception(error);
            }

            return handle;
        }
    }
}