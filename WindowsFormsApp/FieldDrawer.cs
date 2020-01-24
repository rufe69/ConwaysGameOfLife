using ConwaysGameOfLife;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    class FieldDrawer
    {
        private Graphics gr;
        private Field field;
        private float width;
        private float height;

        public FieldDrawer(Field field, Graphics graphics, float width, float height)
        {
            gr = graphics;
            this.field = field;
            this.width = width;
            this.height = height;
        }

        public void DrawField()
        {
            DrawLines();
        }

        private void DrawLines()
        {
            var cellWidth = width / field.Length;
            var cellHeight = height / field.Length;

            for (int i = 0; i < field.Length; i++)
            {
                gr.DrawLine(Pens.LightGray, cellWidth * i, 0, cellWidth*i, height);
                gr.DrawLine(Pens.LightGray, 0, cellHeight * i, width, cellHeight * i);
                gr.DrawString((i+1).ToString(), SystemFonts.DefaultFont, Brushes.Black, cellWidth * i, 0);
                gr.DrawString((i + 1).ToString(), SystemFonts.DefaultFont, Brushes.Black, 0, cellHeight * i);
            }
        }
    }
}
