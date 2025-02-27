/*
 * ����GTK�������������ԭ��C#�ؼ�winform����Ŀ�ƽ̨���������
 * ʹ�ñ����GTKSystem.Windows.Forms����Microsoft.WindowsDesktop.App.WindowsForms��һ�α��룬��ƽ̨windows��linux��macos����
 * ����֧��438865652@qq.com��https://www.gtkapp.com, https://gitee.com/easywebfactory, https://github.com/easywebfactory
 * author:chenhongjin
 */

using System.ComponentModel;
using Gtk;

namespace System.Windows.Forms;

[DesignerCategory("Component")]
public class TrackBar : Control
{
    public readonly TrackBarBase self = new();
    public override object GtkControl => self;
    readonly Adjustment adjustment = new(10, 0, 100, 1, 1, 0);
    Scale? scale;
    public TrackBar()
    {
        self.Realized += Control_Realized;
    }

    private void Control_Realized(object? sender, EventArgs e)
    {
        scale = new Scale(Orientation== Orientation.Horizontal ? Gtk.Orientation.Horizontal : Gtk.Orientation.Vertical, adjustment);
        scale.ShowFillLevel = true;
        scale.DrawValue = false;
        scale.RoundDigits = 1;
        scale.Visible = true;
        scale.Inverted = Orientation == Orientation.Vertical;
        adjustment.Lower = Minimum;
        adjustment.Upper = Maximum;
        adjustment.Value = Value;
        adjustment.ValueChanged += Control_ValueChanged;
        self.Child = scale;
    }

    private void Control_ValueChanged(object? sender, EventArgs e)
    {
        Value = (int)adjustment.Value;
        Scroll?.Invoke(this, e);
    }

    public int LargeChange { get; set; } = 5;
    public int Maximum { get; set; }
    public int Minimum { get; set; }
    public int Value { get=> (int)adjustment.Value; set => adjustment.Value = value;
    }
    public Orientation Orientation { get; set; }
    public int TickFrequency { get; set; }
    public TickStyle TickStyle { get; set; }
    public event EventHandler? Scroll;
}