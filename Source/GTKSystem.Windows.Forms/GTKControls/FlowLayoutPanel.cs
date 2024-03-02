/*
 * ����GTK�������������ԭ��C#�ؼ�winform����Ŀ�ƽ̨���������
 * ʹ�ñ����GTKSystem.Windows.Forms����Microsoft.WindowsDesktop.App.WindowsForms��һ�α��룬��ƽ̨windows��linux��macos����
 * ����֧��438865652@qq.com��https://gitee.com/easywebfactory, https://www.cnblogs.com/easywebfactory
 * author:chenhongjin
 * date: 2024/1/3
 */
using Gtk;
using System.ComponentModel;


namespace System.Windows.Forms
{
	[ProvideProperty("FlowBreak", typeof(Control))]
	[DefaultProperty("FlowDirection")]
    [DesignerCategory("Component")]
    public partial class FlowLayoutPanel : WidgetContainerControl<Gtk.FlowBox>, IExtenderProvider
    {
        private ObjectCollection _controls;
        public FlowLayoutPanel() : base()
        {
            Widget.StyleContext.AddClass("FlowLayoutPanel");
            base.Control.Orientation = Gtk.Orientation.Horizontal;
            base.Control.Halign = Align.Start;
            base.Control.Valign = Align.Start;
            base.Control.MinChildrenPerLine = 1;
            base.Control.MaxChildrenPerLine = 999;
            base.Control.ColumnSpacing = 0;
            base.Control.BorderWidth = 0;

            base.Control.ChildActivated += Control_ChildActivated;
            _controls = new ObjectCollection(this);

        }

        private void Control_ChildActivated(object o, ChildActivatedArgs args)
        {
            var c = args.Child;
        }

        private FlowDirection _FlowDirection;
		public FlowDirection FlowDirection
		{
            get { return _FlowDirection; }
            set
            {
                if (value == FlowDirection.LeftToRight || value == FlowDirection.RightToLeft) { base.Control.Orientation = Gtk.Orientation.Horizontal; }
                else if (value == FlowDirection.TopDown || value == FlowDirection.BottomUp) { base.Control.Orientation = Gtk.Orientation.Vertical; }
            }
        }

        public bool WrapContents { get; set; }

        public bool GetFlowBreak(Control control)
        {
            return false;
        }

        public void SetFlowBreak(Control control, bool value)
        {

        }
        public override ControlCollection Controls => _controls;
        public bool CanExtend(object extendee)
        {
            return true;
        }
        public class ObjectCollection : ControlCollection
        {
            public ObjectCollection(FlowLayoutPanel owner) : base(owner)
            {

            }
            public override int Add(object item)
            {
                Gtk.FlowBoxChild box = new FlowBoxChild();
                box.Valign = Align.Start;
                box.Halign = Align.Start;
                Control control = (Control)item;
                Gtk.Widget widg = control.Widget;
                widg.Valign = Align.Start;
                widg.Halign = Align.Start;
                box.Add(widg);
                return base.AddWidget(box, control);
            }
        }
    }
}
