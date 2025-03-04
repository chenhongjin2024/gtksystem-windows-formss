﻿/*
 * 基于GTK组件开发，兼容原生C#控件winform界面的跨平台界面组件。
 * 使用本组件GTKSystem.Windows.Forms代替Microsoft.WindowsDesktop.App.WindowsForms，一次编译，跨平台windows、linux、macos运行
 * 技术支持438865652@qq.com，https://www.gtkapp.com, https://gitee.com/easywebfactory, https://github.com/easywebfactory
 * author:chenhongjin
 */
using Gtk;
using System.ComponentModel;

namespace System.Windows.Forms;

[DesignerCategory("Component")]
public class Panel : ScrollableControl
{
    public readonly PanelBase self = new();
    public override object GtkControl => self;
    public Overlay contaner = new();
    private readonly ControlCollection? _controls;
    public Panel()
    {
        _controls = new ControlCollection(this, contaner);
        contaner.Margin = 0;
        contaner.Halign = Align.Fill;
        contaner.Valign = Align.Fill;
        contaner.Hexpand = false;
        contaner.Vexpand = false;
        contaner.BorderWidth = 0;
        contaner.Add(new Fixed { Halign = Align.Fill, Valign = Align.Fill });
        self.Add(contaner);
    }
    public override ControlCollection? Controls => _controls;
    public override Padding Padding
    {
        get => base.Padding;
        set
        {
            base.Padding = value;
            contaner.MarginStart = value.Left;
            contaner.MarginTop = value.Top;
            contaner.MarginEnd = value.Right;
            contaner.MarginBottom = value.Bottom;
        }
    }
}