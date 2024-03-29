﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.452/blob/master/LICENSE
 *
 */
#endregion

using ComponentFactory.Krypton.Toolkit;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedControls.ExtendedToolkit.Controls.Charting
{
    [System.Drawing.ToolboxBitmapAttribute(typeof(System.Windows.Forms.Control))]
    public class KryptonLxLedControl : LxLedControl
    {
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;

        public KryptonLxLedControl()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();

            // add Palette Handler
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            InitColors();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.ClipRectangle);

        }


        #region ... Krypton ...
        private void InitColors()
        {
            this.HighlightOpaque = 75;
            this.BackColor = Color.Transparent;

            this.BackColour_1 = _palette.ColorTable.ToolStripGradientEnd;
            this.BackColour_2 = _palette.ColorTable.ToolStripGradientEnd;

            this.FadedColour = _palette.ColorTable.ToolStripGradientMiddle;

            //for sparkle
            if (FadedColour == BackColour_2) this.FadedColour = _palette.ColorTable.ToolStripGradientBegin;

            this.BorderColour = _palette.ColorTable.ToolStripBorder;

            this.FocusedBorderColour = _palette.ColorTable.ToolStripBorder;
            this.ForeColor = _palette.ColorTable.ToolStripText;
            Invalidate();

        }


        //Kripton Palette Events
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;

            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                //repaint with new values

                InitColors();

            }

            Invalidate();
        }

        //Kripton Palette Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_palette != null)
                {
                    _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                    _palette = null;
                }

                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnGlobalPaletteChanged);
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}