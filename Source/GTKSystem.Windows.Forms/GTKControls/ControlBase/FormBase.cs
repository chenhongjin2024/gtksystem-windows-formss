﻿using Cairo;
using Gtk;
using System;
using System.Drawing.Drawing2D;


namespace GTKSystem.Windows.Forms.GTKControls.ControlBase
{
    public sealed class FormBase : Gtk.Dialog, IControlGtk
    {
        public readonly Gtk.ScrolledWindow ScrollArea = new Gtk.ScrolledWindow();
        public readonly Gtk.Layout StatusBar = new Gtk.Layout(new Gtk.Adjustment(1, 1, 100, 1, 0, 1), new Gtk.Adjustment(1, 1, 100, 1, 0, 1));
        private readonly Gtk.Viewport StatusBarView = new Gtk.Viewport();

        public GtkControlOverride Override { get; set; }
        public FormBase() : base()
        {
            this.Override = new GtkControlOverride(this);
            this.Override.AddClass("Form");
            this.WindowPosition = Gtk.WindowPosition.Center;
            this.BorderWidth = 0;
            this.SetDefaultSize(100, 100);
            this.TypeHint = Gdk.WindowTypeHint.Normal;
            this.Response += FormBase_Response;
            ScrollArea.BorderWidth = 0;
            ScrollArea.Valign = Gtk.Align.Fill;
            ScrollArea.Halign = Gtk.Align.Fill;
            ScrollArea.HscrollbarPolicy = PolicyType.Always;
            ScrollArea.VscrollbarPolicy = PolicyType.Always;
            this.ContentArea.PackStart(ScrollArea, true, true, 0);
            StatusBar.Hexpand = true;
            StatusBar.Vexpand = false;
            StatusBar.Halign = Gtk.Align.Fill;
            StatusBar.Valign = Gtk.Align.Fill;
            StatusBar.NoShowAll = true;
            StatusBar.Visible = false;
            StatusBarView.StyleContext.AddClass("StatusStrip");
            StatusBarView.Child = StatusBar;
            this.ContentArea.PackEnd(StatusBarView, false, true, 0);
            // this.Decorated = false; //删除工具栏
        }

        public FormBase(string title, Gtk.Window parent, DialogFlags flags, params object[] button_data) : base(title, parent, flags, button_data)
        {
            this.Override = new GtkControlOverride(this);
            this.Override.AddClass("Form");
            this.WindowPosition = Gtk.WindowPosition.Center;
            this.BorderWidth = 0;
            this.SetDefaultSize(100, 100);
            this.TypeHint = Gdk.WindowTypeHint.Normal;
            this.Response += FormBase_Response;
        }
        private void FormBase_Response(object o, ResponseArgs args)
        {
            //Console.WriteLine(args.ResponseId);
            if (args.ResponseId == ResponseType.DeleteEvent)
                if (this.IsActive)
                    this.Destroy();
        }

        public void CloseWindow()
        {
            this.OnClose();
        }
    }
}
