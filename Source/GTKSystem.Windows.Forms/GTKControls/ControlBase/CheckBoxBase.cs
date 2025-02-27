﻿using Cairo;
using GTKSystem.Windows.Forms.GTKControls;

namespace System.Windows.Forms;

public sealed class CheckBoxBase : Gtk.CheckButton, IGtkControl
{
    public IGtkControlOverride Override { get; set; }
    public CheckBoxBase()
    {
        public GtkControlOverride Override { get; set; }
        public CheckBoxBase() : base()
        {
            this.Override = new GtkControlOverride(this);
            this.Override.AddClass("CheckBox");
            base.Valign = Gtk.Align.Start;
            base.Halign = Gtk.Align.Start;
        }
        protected override void OnShown()
        {
            Override.OnAddClass();
            base.OnShown();
        }
    }
}
