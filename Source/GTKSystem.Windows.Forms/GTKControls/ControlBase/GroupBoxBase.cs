﻿using Gtk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class GroupBoxBase : Gtk.Frame, IControlGtk
    {
        public GtkControlOverride Override { get; set; }
        internal GroupBoxBase() : base()
        {
            this.Override = new GtkControlOverride(this);
            this.Override.AddClass("GroupBox");
            //self.Override.AddClass("BackgroundTransparent");
            this.LabelXalign = 0.03f;

        }
        protected override void OnShown()
        {
            Override.OnAddClass();
            base.OnShown();
        }
        protected override bool OnDrawn(Cairo.Context cr)
        {
            Gdk.Rectangle rec = this.Allocation;
            Override.OnDrawnBackground(cr, rec);
            Override.OnPaint(cr, rec);
            return base.OnDrawn(cr);
        }
    }
}
