using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GEdit
{
    public partial class EllipseButton : UserControl
    {
        public bool HasMouseHover = true;
        private Color _hoverBackColor = Color.White;
        private readonly Color _buttonBackColor = Color.Green;

        private readonly Color _hoverBorderColor = Color.Red;
        private readonly Color _buttonBorderColor = Color.Black;

        private string Caption = "aa";

        public EllipseButton()
        {
            InitializeComponent();
        }


        protected override void OnClick(EventArgs e)
        {
            var p = PointToClient(Control.MousePosition);
            if (IsMouseHover(p.X, p.Y))
            {
                base.OnClick(e);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.IsMouseHover(e.X, e.Y);
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.IsMouseHover(-1, -1);
            base.OnMouseLeave(e);
        }

        public bool IsMouseHover(int x, int y)
        {
            bool visible;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
                visible = path.IsVisible(x, y);
            }

            if (visible != HasMouseHover)
            {
                HasMouseHover = visible;
                Invalidate();
            }

            return visible;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, ClientSize.Width - 1, ClientSize.Height - 1);

                using (SolidBrush brush = new SolidBrush(HasMouseHover ? _hoverBackColor : _buttonBackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                using (Pen pen = new Pen(HasMouseHover ? _hoverBorderColor : _buttonBorderColor, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }

            if (Caption != null)
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.FormatFlags = StringFormatFlags.NoWrap;

                    using (SolidBrush b = new SolidBrush(ForeColor))
                    {
                        var rectangle = new RectangleF(0, 0, ClientSize.Width, ClientSize.Height);

                        e.Graphics.DrawString(Caption, Font, b, rectangle, sf);
                    }
                }
            }
        }
    }
}
