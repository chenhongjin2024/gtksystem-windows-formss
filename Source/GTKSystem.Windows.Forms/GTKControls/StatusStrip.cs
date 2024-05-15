/*
 * ����GTK�������������ԭ��C#�ؼ�winform����Ŀ�ƽ̨���������
 * ʹ�ñ����GTKSystem.Windows.Forms����Microsoft.WindowsDesktop.App.WindowsForms��һ�α��룬��ƽ̨windows��linux��macos����
 * ����֧��438865652@qq.com��https://gitee.com/easywebfactory, https://www.cnblogs.com/easywebfactory
 * author:chenhongjin
 * date: 2024/1/3
 */
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
    public class StatusStrip : ToolStrip
    {
        public StatusStrip():base()
        {
            this.self.StyleContext.RemoveClass("ToolStrip");
            this.self.StyleContext.AddClass("StatusStrip");
            Dock = DockStyle.Bottom;
        }
        public override Point Location { get => base.Location; set => base.Location = new Point(value.X, value.Y - 12); }
        public override Size Size { get => base.Size; set => base.Size = new Size(value.Width, value.Height + 12); }
        [DefaultValue(false)]
        public bool ShowItemToolTips { get; set; }

        [DefaultValue(true)]
		public bool SizingGrip { get; set; }

        [DefaultValue(true)]
		public bool Stretch { get; set; }
    }
}
