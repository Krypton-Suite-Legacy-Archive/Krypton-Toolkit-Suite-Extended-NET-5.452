﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.452/blob/master/LICENSE
 *
 */
#endregion

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedControls.ExtendedToolkit.Controls.StandardControls.GridView
{
    public class DataGridViewUpDownImageColumn : DataGridViewTextBoxColumn
    {
        // Methods
        public DataGridViewUpDownImageColumn()
        {
            this.CellTemplate = new DataGridViewUpDownImage();
        }
    }

    public class DataGridViewUpDownImage : DataGridViewTextBoxCell
    {
        protected override void PaintBorder(Graphics graphics, Rectangle clipBounds, Rectangle bounds, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle)
        {
            base.PaintBorder(graphics, clipBounds, bounds, cellStyle, advancedBorderStyle);
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                object o;
                o = value;

                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, "", "", errorText, cellStyle, advancedBorderStyle,
                paintParts);

                //load Icons from resources
                //arrows
                ImageList GridIcons = new ImageList();
                //System.IO.Stream strm;
                string iconName;
                Icon icon;

                //UP
                iconName = "AC.ExtendedRenderer.Toolkit.StdControls.Images.Up.ico";
                icon = new Icon(this.GetType().Assembly.GetManifestResourceStream(iconName));
                GridIcons.Images.Add(icon.ToBitmap());
                //Down
                iconName = "AC.ExtendedRenderer.Toolkit.StdControls.Images.Down.ico";
                icon = new Icon(this.GetType().Assembly.GetManifestResourceStream(iconName));
                GridIcons.Images.Add(icon.ToBitmap());
                //Equal
                iconName = "AC.ExtendedRenderer.Toolkit.StdControls.Images.Eq.ico";
                icon = new Icon(this.GetType().Assembly.GetManifestResourceStream(iconName));
                GridIcons.Images.Add(icon.ToBitmap());
                //Na
                //iconName = "AC.Utils.Na.ico"
                iconName = "AC.ExtendedRenderer.Toolkit.StdControls.Images.Na2.ico";
                icon = new Icon(this.GetType().Assembly.GetManifestResourceStream(iconName));
                GridIcons.Images.Add(icon.ToBitmap());

                int ngXlocation = (cellBounds.Width - 16);
                int ngYlocation = (cellBounds.Height - 16);
                if (ngXlocation < 0)
                {
                    ngXlocation = 0;
                }
                if (ngYlocation < 0)
                {
                    ngYlocation = 0;
                }
                ngXlocation = ngXlocation / 2;
                ngYlocation = ngYlocation / 2;

                Rectangle ng = new Rectangle(cellBounds.X + ngXlocation, cellBounds.Y + ngYlocation, 16, 16);

                if ((((o) != null)))
                {
                    Single c;
                    c = Conversions.ToSingle(o);
                    //Debug
                    //MessageBox.Show(c)

                    Brush backBrush = new SolidBrush(cellStyle.BackColor);

                    if (elementState == DataGridViewElementStates.Selected)
                    {
                        backBrush = new SolidBrush(Color.Gold);
                    }

                    //erase background
                    if (c == 1)
                    {
                        //graphics.FillRectangle(backBrush, cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height)
                        graphics.DrawImage(GridIcons.Images[0], ng);
                    }
                    else if (c == -1)
                    {
                        //graphics.FillRectangle(backBrush, cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height)
                        graphics.DrawImage(GridIcons.Images[1], ng);
                    }
                    else if (c == 0)
                    {
                        //graphics.FillRectangle(backBrush, cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height)
                        graphics.DrawImage(GridIcons.Images[2], ng);
                    }
                    else if (c == 2)
                    {
                        //graphics.FillRectangle(backBrush, cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height)
                        graphics.DrawImage(GridIcons.Images[3], ng);
                    }
                    else
                    {
                        //graphics.FillRectangle(backBrush, cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height)
                    }
                }

                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);

            }
            catch
            {
                // empty catch 
                //MessageBox.Show(ex.Message)
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle,
                paintParts);
                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            }
        }

        //public property
        public override object DefaultNewRowValue
        {
            get { return "3"; }
        }



    }
}