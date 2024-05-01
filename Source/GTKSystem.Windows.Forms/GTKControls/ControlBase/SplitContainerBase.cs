﻿using Gtk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class SplitContainerBase : Gtk.Paned, IControlGtk
    {
        public GtkControlOverride Override { get; set; }
        internal SplitContainerBase() : base(Gtk.Orientation.Vertical)
        {
            this.Override = new GtkControlOverride(this);
            this.Override.AddClass("SplitContainer");
            //this.Override.AddClass("BackgroundTransparent");
            this.BorderWidth = 1;
            this.WideHandle = true;
            this.Orientation = Gtk.Orientation.Horizontal;
        }

        public void AddClass(string cssClass)
        {
            this.Override.AddClass(cssClass);
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
