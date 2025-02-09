//
// ControlStyleTest.cs (Auto-generated by GenerateControlStyleTest.cs).
//
// Author: 
//   Peter Dennis Bartok (pbartok@novell.com)
//
// (C) 2005 Novell, Inc. (http://www.novell.com)
//

using System.Windows.Forms;
using System.Reflection;

namespace GtkTests.System.Windows.Forms;

[TestFixture]
public class TestControlStyle  : TestHelper {

    static Array style_values = Enum.GetValues(typeof(ControlStyles));
    static string[] style_names = Enum.GetNames(typeof(ControlStyles));

    public void AssertAreEqual(string[] want, string[] got, string name) {
        if (want.Length == got.Length) {
            for (int i=0; i < want.Length; i++) {
                if (want[i] != got[i]) {
                    Console.WriteLine("{0}: Expected {1}, got {2}", name, want[i], got[i]);
                }
            }
        }
        Assert.AreEqual(want, got, name);
    }

    public static void CheckStyles (Control ctrl, string msg, params ControlStyles [] ExpectedStyles)
    {
        MethodInfo method = ctrl.GetType ().GetMethod ("GetStyle", BindingFlags.ExactBinding | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type [] {typeof(ControlStyles)}, null);
        Assert.IsNotNull (method, "Cannot complete test, didn't find GetStyle method on Control");
			
        string failed = "";
			
        if (ExpectedStyles == null)
            ExpectedStyles = new ControlStyles [0];
        foreach (ControlStyles style in Enum.GetValues (typeof(ControlStyles))) {
            bool result = (bool) method.Invoke (ctrl, new object [] {style});
            if (Array.IndexOf (ExpectedStyles, style) >= 0) {
                if (!result) 
                    failed += "\t" + "ControlStyles." + style.ToString () + " was expected, but is not set." + Environment.NewLine;
            } else {
                if (result)
                    failed += "\t" + "ControlStyles." + style.ToString () + " is set, but was not expected." + Environment.NewLine;
            }
        }
        if (failed != String.Empty) {
            Assert.Fail (msg + Environment.NewLine + failed);
        }
    }

    public static string[] GetStyles(Control control) {
        string[] result;

        result = new string[style_names.Length];

        for (int i = 0; i < style_values.Length; i++) {
            result[i] = style_names[i] + "=" + control.GetType().GetMethod("GetStyle", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(control, new object[1] {(ControlStyles)style_values.GetValue(i)});
        }

        return result;
    }

    [Test]
    public void ControlStyleTest ()
    {
        string[] Control_want = {
            "ContainerControl=False",
            "UserPaint=True",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(Control_want, GetStyles(new Control()), "ControlStyles");
    }


    [Test]
    public void ButtonStyleTest ()
    {
        string[] Button_want = {
            "ContainerControl=False",
            "UserPaint=True",
            "Opaque=True",
            "ResizeRedraw=True",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=True",
            "SupportsTransparentBackColor=True",
            "StandardDoubleClick=False",
            "AllPaintingInWmPaint=True",
            "CacheText=True",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=True",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(Button_want, GetStyles(new Button()), "ButtonStyles");
    }

    [Test]
    public void CheckBoxStyleTest ()
    {
        string[] CheckBox_want = {
            "ContainerControl=False",
            "UserPaint=True",
            "Opaque=True",
            "ResizeRedraw=True",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=True",
            "SupportsTransparentBackColor=True",
            "StandardDoubleClick=False",
            "AllPaintingInWmPaint=True",
            "CacheText=True",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=True",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(CheckBox_want, GetStyles(new CheckBox()), "CheckBoxStyles");
    }

    [Test]
    public void RadioButtonStyleTest ()
    {
        string[] RadioButton_want = {
            "ContainerControl=False",
            "UserPaint=True",
            "Opaque=True",
            "ResizeRedraw=True",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=True",
            "SupportsTransparentBackColor=True",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=True",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=True",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(RadioButton_want, GetStyles(new RadioButton()), "RadioButtonStyles");
    }

    [Test]
    public void DateTimePickerStyleTest ()
    {
        string[] DateTimePicker_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=True",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(DateTimePicker_want, GetStyles(new DateTimePicker()), "DateTimePickerStyles");
    }

    [Test]
    public void GroupBoxStyleTest ()
    {
        string[] GroupBox_want = {
            "ContainerControl=True",
            "UserPaint=True",
            "Opaque=False",
            "ResizeRedraw=True",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=False",
            "UserMouse=False",
            "SupportsTransparentBackColor=True",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(GroupBox_want, GetStyles(new GroupBox()), "GroupBoxStyles");
    }

    [Test]
    public void LabelStyleTest ()
    {
        string[] Label_want = {
            "ContainerControl=False",
            "UserPaint=True",
            "Opaque=False",
            "ResizeRedraw=True",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=False",
            "UserMouse=False",
            "SupportsTransparentBackColor=True",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=True",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(Label_want, GetStyles(new Label()), "LabelStyles");
    }

    [Test]
    public void LinkLabelStyleTest ()
    {
        string[] LinkLabel_want = {
            "ContainerControl=False",
            "UserPaint=True",
            "Opaque=True",
            "ResizeRedraw=True",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=False",
            "UserMouse=False",
            "SupportsTransparentBackColor=True",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=True",
            "UseTextForAccessibility=True"
        };

        string[] LinkLabel_link_want = {
            "ContainerControl=False",
            "UserPaint=True",
            "Opaque=True",
            "ResizeRedraw=True",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=True",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=True",
            "UseTextForAccessibility=True"
        };

        LinkLabel link = new LinkLabel ();

        // Test LinkLabel without text and without links
        Assert.AreEqual(LinkLabel_want, GetStyles(link), "#1");

        // Test LinkLabel with only text
        link.Text = "Users need not fear making the switch to Linux";
        link.Links.Clear ();
        Assert.AreEqual (LinkLabel_want, GetStyles (link), "#2");
    }

    [Test]
    public void ComboBoxStyleTest ()
    {
        string[] ComboBox_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(ComboBox_want, GetStyles(new ComboBox()), "ComboBoxStyles");
    }

    [Test]
    public void ListBoxStyleTest ()
    {
        string[] ListBox_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(ListBox_want, GetStyles(new ListBox()), "ListBoxStyles");
    }

    [Test]
    public void CheckedListBoxStyleTest ()
    {
        string[] CheckedListBox_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=True",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(CheckedListBox_want, GetStyles(new CheckedListBox()), "CheckedListBoxStyles");
    }

    [Test]
    public void ListViewStyleTest ()
    {
        string[] ListView_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(ListView_want, GetStyles(new ListView()), "ListViewStyles");
    }

    [Test]
    public void MonthCalendarStyleTest ()
    {
        string[] MonthCalendar_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(MonthCalendar_want, GetStyles(new MonthCalendar()), "MonthCalendarStyles");
    }

    [Test]
    public void PictureBoxStyleTest ()
    {
        string[] PictureBox_want = {
            "ContainerControl=False",
            "UserPaint=True",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=False",
            "UserMouse=False",
            "SupportsTransparentBackColor=True",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=True",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(PictureBox_want, GetStyles(new PictureBox()), "PictureBoxStyles");
    }

    [Test]
    public void ProgressBarStyleTest ()
    {
        string[] ProgressBar_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=False",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(ProgressBar_want, GetStyles(new ProgressBar()), "ProgressBarStyles");
    }

    [Test]
    public void ScrollableControlStyleTest ()
    {
        string[] ScrollableControl_want = {
            "ContainerControl=True",
            "UserPaint=True",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=False",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(ScrollableControl_want, GetStyles(new ScrollableControl()), "ScrollableControlStyles");
    }

    [Test]
    public void ContainerControlStyleTest ()
    {
        string[] ContainerControl_want = {
            "ContainerControl=True",
            "UserPaint=True",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=False",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(ContainerControl_want, GetStyles(new ContainerControl()), "ContainerControlStyles");
    }

    [Test]
    public void FormStyleTest ()
    {
        string[] Form_want = {
            "ContainerControl=True",
            "UserPaint=True",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=False",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Form f = new Form ();
        f.ShowInTaskbar = false;
        Assert.AreEqual(Form_want, GetStyles(f), "FormStyles");
        f.Dispose ();
    }

    [Test]
    public void PropertyGridStyleTest ()
    {
        string[] PropertyGrid_want = {
            "ContainerControl=True",
            "UserPaint=True",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=False",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(PropertyGrid_want, GetStyles(new PropertyGrid()), "PropertyGridStyles");
    }

    [Test]
    public void NumericUpDownStyleTest ()
    {
        string[] NumericUpDown_want = {
            "ContainerControl=True",
            "UserPaint=True",
            "Opaque=True",
            "ResizeRedraw=True",
            "FixedWidth=False",
            "FixedHeight=True",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=False",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(NumericUpDown_want, GetStyles(new NumericUpDown()), "NumericUpDownStyles");
    }

    [Test]
    public void UserControlStyleTest ()
    {
        string[] UserControl_want = {
            "ContainerControl=True",
            "UserPaint=True",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=True",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=False",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(UserControl_want, GetStyles(new UserControl()), "UserControlStyles");
    }

    [Test]
    public void PanelStyleTest ()
    {
        string[] Panel_want = {
            "ContainerControl=True",
            "UserPaint=True",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=False",
            "UserMouse=False",
            "SupportsTransparentBackColor=True",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=False",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(Panel_want, GetStyles(new Panel()), "PanelStyles");
    }

    [Test]
    public void TabPageStyleTest ()
    {
        string[] TabPage_want = {
            "ContainerControl=True",
            "UserPaint=True",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=False",
            "UserMouse=False",
            "SupportsTransparentBackColor=True",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=False",
            "CacheText=True",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(TabPage_want, GetStyles(new TabPage()), "TabPageStyles");
    }

    [Test]
    public void HScrollBarStyleTest ()
    {
        string[] HScrollBar_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(HScrollBar_want, GetStyles(new HScrollBar()), "HScrollBarStyles");
    }

    [Test]
    public void VScrollBarStyleTest ()
    {
        string[] VScrollBar_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(VScrollBar_want, GetStyles(new VScrollBar()), "VScrollBarStyles");
    }

    [Test]
    public void TabControlStyleTest ()
    {
        string[] TabControl_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=True"
        };

        Assert.AreEqual(TabControl_want, GetStyles(new TabControl()), "TabControlStyles");
    }

    [Test]
    public void RichTextBoxStyleTest ()
    {
        string[] RichTextBox_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=False",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(RichTextBox_want, GetStyles(new RichTextBox()), "RichTextBoxStyles");
    }

    [Test]
    public void TextBoxStyleTest ()
    {
        string[] TextBox_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=True",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=False",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(TextBox_want, GetStyles(new TextBox()), "TextBoxStyles");
    }

    [Test]
    public void TrackBarStyleTest ()
    {
        string[] TrackBar_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=True",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(TrackBar_want, GetStyles(new TrackBar()), "TrackBarStyles");
    }

    [Test]
    public void TreeViewStyleTest ()
    {
        string[] TreeView_want = {
            "ContainerControl=False",
            "UserPaint=False",
            "Opaque=False",
            "ResizeRedraw=False",
            "FixedWidth=False",
            "FixedHeight=False",
            "StandardClick=False",
            "Selectable=True",
            "UserMouse=False",
            "SupportsTransparentBackColor=False",
            "StandardDoubleClick=True",
            "AllPaintingInWmPaint=True",
            "CacheText=False",
            "EnableNotifyMessage=False",
            "DoubleBuffer=False",
            "OptimizedDoubleBuffer=False",
            "UseTextForAccessibility=False"
        };

        Assert.AreEqual(TreeView_want, GetStyles(new TreeView()), "TreeViewStyles");
    }
}