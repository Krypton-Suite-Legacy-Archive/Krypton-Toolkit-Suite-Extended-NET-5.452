﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.452/blob/master/LICENSE
 *
 */
#endregion

using Core.Classes.Colours;
using System.IO;

namespace Core.Interfaces
{
    public interface IPaletteSerialiser
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether this serializer can be used to read palettes.
        /// </summary>
        /// <value><c>true</c> if palettes can be read using this serializer; otherwise, <c>false</c>.</value>
        bool CanRead { get; }

        /// <summary>
        /// Gets a value indicating whether this serializer can be used to write palettes.
        /// </summary>
        /// <value><c>true</c> if palettes can be written using this serializer; otherwise, <c>false</c>.</value>
        bool CanWrite { get; }

        /// <summary>
        /// Gets the default extension for files generated with this palette format.
        /// </summary>
        /// <value>The default extension for files generated with this palette format.</value>
        string DefaultExtension { get; }

        /// <summary>
        /// Gets the maximum number of colors supported by this format.
        /// </summary>
        /// <value>
        /// The maximum value number of colors supported by this format.
        /// </value>
        int Maximum { get; }

        /// <summary>
        /// Gets the minimum numbers of colors supported by this format.
        /// </summary>
        /// <value>
        /// The minimum number of colors supported by this format.
        /// </value>
        int Minimum { get; }

        /// <summary>
        /// Gets a descriptive name of the palette format
        /// </summary>
        /// <value>The descriptive name of the palette format.</value>
        string Name { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether this instance can read palette data from the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns><c>true</c> if this instance can read palette data from the specified stream; otherwise, <c>false</c>.</returns>
        bool CanReadFrom(Stream stream);

        /// <summary>
        /// Deserializes the <see cref="ColourCollection"/> contained by the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> that contains the palette to deserialize.</param>
        /// <returns>The <see cref="ColourCollection"/> being deserialized.</returns>
        ColourCollection Deserialise(Stream stream);

        /// <summary>
        /// Serializes the specified <see cref="ColourCollection"/> and writes the palette to a file using the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> used to write the palette.</param>
        /// <param name="palette">The <see cref="ColourCollection"/> to serialize.</param>
        void Serialise(Stream stream, ColourCollection palette);

        #endregion
    }
}