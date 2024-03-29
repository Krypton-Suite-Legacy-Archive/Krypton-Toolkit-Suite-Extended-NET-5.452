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
using System.Windows.Forms.Design;

namespace ExtendedMenuToolbarItems
{
    [ToolboxBitmap(typeof(KryptonTextBox)), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class KryptonToolStripTextBox : ToolStripControlHost
    {
        #region Properties
        public KryptonTextBox KryptonTextBox
        {
            get
            {
                return Control as KryptonTextBox;
            }
        }
        #endregion

        #region Constructor
        public KryptonToolStripTextBox() : base(CreateControlInstance())
        {

        }
        #endregion

        #region Overrides
        protected override void OnSubscribeControlEvents(Control control)
        {
            KryptonTextBox kryptonTextBox = control as KryptonTextBox;

            kryptonTextBox.TextAlignChanged += new EventHandler(TextAlignChanged);

            kryptonTextBox.TextChanged += new EventHandler(Text_Changed);

            kryptonTextBox.FontChanged += new EventHandler(FontChanged);

            base.OnSubscribeControlEvents(control);
        }

        protected override void OnUnsubscribeControlEvents(Control control)
        {
            KryptonTextBox kryptonTextBox = control as KryptonTextBox;

            kryptonTextBox.TextAlignChanged -= new EventHandler(TextAlignChanged);

            kryptonTextBox.TextChanged -= new EventHandler(Text_Changed);

            kryptonTextBox.FontChanged -= new EventHandler(FontChanged);

            base.OnUnsubscribeControlEvents(control);
        }
        #endregion

        #region Methods
        private static Control CreateControlInstance()
        {
            KryptonTextBox kryptonTextBox = new KryptonTextBox();

            //TODO: Add other initialization code here.


            return kryptonTextBox;
        }
        #endregion

        #region Event Handlers
        private void Text_Changed(object sender, EventArgs e)
        {
            //if (KryptonTextBox.TextChanged)
            //{

            //}
        }

        private void TextAlignChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FontChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}