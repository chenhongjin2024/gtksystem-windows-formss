﻿/*
 * 基于GTK组件开发，兼容原生C#控件winform界面的跨平台界面组件。
 * 使用本组件GTKSystem.Windows.Forms代替Microsoft.WindowsDesktop.App.WindowsForms，一次编译，跨平台windows、linux、macos运行
 * 技术支持438865652@qq.com，https://www.gtkapp.com, https://gitee.com/easywebfactory, https://github.com/easywebfactory
 * author:chenhongjin
 */

using Gtk;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace System.Windows.Forms;

[DesignerCategory("Component")]
public class DateTimePicker : MaskedTextBox
{
    readonly Popover popver;
    readonly Gtk.Calendar calendar = new();
    public DateTimePicker() : base("DateTimePicker")
    {
        Mask = "____年__月__日";

        self.SecondaryIconActivatable = true;
        self.SecondaryIconStock= "open-menu";
        self.SecondaryIconPixbuf = new Gdk.Pixbuf(GetType().Assembly, "System.Windows.Forms.Resources.System.MonthCalendar.ico");
        self.IconRelease += DateTimePicker_IconRelease;
        self.Shown += Self_Shown;

        popver = new Popover(self);
        popver.BorderWidth = 5;
        popver.Modal = true;
        popver.Position = PositionType.Bottom;

        calendar.Halign = Align.Fill;
        calendar.Valign = Align.Fill;
        calendar.DaySelected += Calendar_DaySelected;
        calendar.PrevYear += Calendar_PrevYear;
        calendar.NextYear += Calendar_NextYear;
        calendar.PrevMonth += Calendar_PrevMonth;
        calendar.NextMonth += Calendar_NextMonth;

        var popbody=new Box(Gtk.Orientation.Vertical, 6);
        popbody.Add(calendar);
        var todaybtn = new Gtk.Button { Label = "选择今天"+DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") };
        todaybtn.Clicked += Todaybtn_Clicked;
        popbody.Add(todaybtn);
        popver.Add(popbody);
        self.Changed += Self_Changed;
    }
    private void Self_Changed(object? sender, EventArgs e)
    {
        if (ValueChanged != null && self.IsMapped)
            ValueChanged?.Invoke(this, e);
    }

    private void Calendar_NextMonth(object? sender, EventArgs e)
    {
        if (calendar.GetDate() > MaxDate)
        {
            calendar.Date = MaxDate.Date.AddDays(-1);
        }
    }

    private void Calendar_PrevMonth(object? sender, EventArgs e)
    {
        if (calendar.GetDate() < MinDate)
        {
            calendar.Date = MinDate.Date.AddDays(1);
        }
    }

    private void Calendar_NextYear(object? sender, EventArgs e)
    {
        if (calendar.GetDate() > MaxDate)
        {
            calendar.Date = MaxDate.Date.AddDays(-1);
        }
    }

    private void Calendar_PrevYear(object? sender, EventArgs e)
    {
        if (calendar.GetDate() < MinDate)
        {
            calendar.Date = MinDate.Date.AddDays(1);
        }
    }

    private void Todaybtn_Clicked(object? sender, EventArgs e)
    {
        Value = DateTime.Now;
        popver.Hide();
    }

    private void Self_Shown(object? sender, EventArgs e)
    {
        Value = DateTime.Now;
    }

    private void DateTimePicker_IconRelease(object? o, IconReleaseArgs args)
    {
        var current = Value;
        if (current >= MaxDate)
        {
            calendar.Date = MaxDate.Date.AddDays(-1);
        }
        else if(current <= MinDate)
        {
            calendar.Date = MinDate.AddDays(1);
        }
        else
        {
            calendar.Date = Value;
        }
        popver.ShowAll();
    }

    private void Calendar_DaySelected(object? sender, EventArgs e)
    {
        var calendarValue = sender as Gtk.Calendar;
        var dt = calendarValue?.GetDate()??default;
        if (dt > MaxDate || dt < MinDate)
        {
            if (calendarValue != null)
            {
                calendarValue.Date = Value;
            }

            MessageBox.Show($"选择的日期超出限制范围 \n最大时间：{MaxDate.ToString("yyyy/MM/dd HH:mm:ss")}\n最小时间：{MinDate.ToString("yyyy/MM/dd HH:mm:ss")}","日期限制");
        }
        else
        {
            var current = Value;
            Value = dt.AddHours(current.Hour).AddMinutes(current.Minute).AddSeconds(current.Second);
        }
    }

    public DateTime MaxDate { get; set; } = DateTime.MaxValue;
    public DateTime MinDate { get; set; } = DateTime.MinValue;
    public DateTime Value
    {
        get
        {
            var result = DateTime.Now;
            var provider = CultureInfo.InvariantCulture;
            if (string.IsNullOrWhiteSpace(Text))
            { }
            else if (Format == DateTimePickerFormat.Custom && DateTime.TryParseExact(Text, CustomFormat, provider, DateTimeStyles.AllowWhiteSpaces, out result))
            { }
            else if (DateTime.TryParse(Text, provider, DateTimeStyles.AllowWhiteSpaces, out result))
            { }
            else
            { 
                result = DateTime.Now;
            }
            if (result > MaxDate)
            {
                return MaxDate;
            }
            if (result < MinDate)
            {
                return MinDate;
            }
            return result;
        }
        set { 
            if(value > MaxDate)
            {
                value = MaxDate.AddDays(-1);
            }
            if (value < MinDate)
            {
                value = MinDate.AddDays(1);
            }
            if (Format==DateTimePickerFormat.Long)
                base.Text = value.ToString("yyyy年MM月dd日");
            else if (Format == DateTimePickerFormat.Short)
                base.Text = value.ToString("yyyy/MM/dd");
            else if (Format == DateTimePickerFormat.Time)
                base.Text = value.ToString("HH:mm:ss");
            else if (Format == DateTimePickerFormat.Custom)
                base.Text = value.ToString(CustomFormat);
            else
                base.Text = value.ToString("yyyy年MM月dd日"); 
        }
    }
    private string customFormat= "yyyy年MM月dd日";
    public string CustomFormat { get => customFormat; 
        set { customFormat = value; 
            Mask = Regex.Replace(value,"[ymdhs]","_",RegexOptions.IgnoreCase); 
        }
    }
    public DateTimePickerFormat format;
    public DateTimePickerFormat Format { get => format;
        set {
            format = value;
            if (Format == DateTimePickerFormat.Long)
                Mask = "____年__月__日";
            else if (Format == DateTimePickerFormat.Short)
                Mask = "____/__/__";
            else if (Format == DateTimePickerFormat.Time)
                Mask = "__:__:__";
            else if (Format == DateTimePickerFormat.Custom)
                Mask = Regex.Replace(CustomFormat, "[ymdhs]", "_", RegexOptions.IgnoreCase);
            else
                Mask = "____年__月__日";
        } 
    }
    public Font? CalendarFont { get; set; }
    public Color CalendarForeColor { get; set; }
    public Color CalendarMonthBackground { get; set; }
    public Color CalendarTitleBackColor { get; set; }
    public Color CalendarTitleForeColor { get; set; }
    public Color CalendarTrailingForeColor { get; set; }

    public event EventHandler? ValueChanged;
}