using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    class RoundedPanel:Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var rad = 30;
            var corr = 4;
            var near = 1;
            var graph = CreateGraphics();
            Pen p = new Pen(Brushes.Black, 1);

            //top
            graph.DrawLine(p, rad, near, Width - rad, near);
            //bottom
            graph.DrawLine(p, rad, Height - corr, Width - rad, Height - corr);
            //right
            graph.DrawLine(p, Width - corr, rad, Width - corr, Height - rad);
            //left
            graph.DrawLine(p, near, rad, near, Height - rad);
            //right-top
            graph.DrawBezier(p, Width - rad, near, Width - corr, near, Width - corr, near, Width - corr, rad);
            //right-bottom
            graph.DrawBezier(p, Width - corr, Height - rad, Width - corr, Height - corr, Width - corr, Height - corr, Width - rad, Height - corr);
            //left-bottom
            graph.DrawBezier(p, rad, Height - corr, near, Height - corr, near, Height - corr, near, Height - rad);
            //left-top
            graph.DrawBezier(p, near, rad, near, near, near, near, rad, near);
        }
    }
}
