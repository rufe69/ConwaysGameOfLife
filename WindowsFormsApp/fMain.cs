using ConwaysGameOfLife;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            pStartMenu.Top = 120;
        }

        private void btCustomGame_Click(object sender, EventArgs e)
        {
            if (tbFieldLength.Text == "")
            {
                tbFieldLength.BackColor = Color.FromArgb(250,200,200);
                return;
            }
            HideStartMenu();
            var fieldLength = int.Parse(tbFieldLength.Text);
            var field = new Field(fieldLength);
            var drawer = new FieldDrawer(field, pGameField.CreateGraphics(), pGameField.Width, pGameField.Height);
            drawer.DrawField();
        }

        private void ShowStartMenu()
        {
            pStartMenu.Visible = true;
        }

        private void HideStartMenu()
        {
            pStartMenu.Visible = false;
        }

        private void SetPanelDesign()
        {
            var rad =30;
            var corr = 4;
            var near = 1;
            var Height = pStartMenu.Height;
            var Width = pStartMenu.Width;
            var graph = pStartMenu.CreateGraphics();
            Pen p = new Pen(Brushes.Black, 1);
            
            //top
            graph.DrawLine(p, rad, near, Width - rad , near);
            //bottom
            graph.DrawLine(p, rad, Height - corr, Width - rad , Height - corr);
            //right
            graph.DrawLine(p, Width - corr , rad, Width - corr , Height - rad);
            //left
            graph.DrawLine(p, near, rad, near, Height - rad );
            //right-top
            graph.DrawBezier(p, Width - rad, near, Width - corr, near, Width - corr, near, Width - corr, rad);
            //right-bottom
            graph.DrawBezier(p, Width - corr, Height - rad , Width - corr, Height - corr, Width - corr, Height - corr, Width - rad, Height - corr);
            //left-bottom
            graph.DrawBezier(p, rad, Height - corr, near, Height - corr, near, Height - corr, near, Height - rad );
            //left-top
            graph.DrawBezier(p, near, rad, near, near, near, near, rad, near);
        }

        private void tbFieldLength_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                MessageBox.Show("");
        }

        private void tbFieldLength_Enter(object sender, EventArgs e) => tbFieldLength.BackColor = Color.White;
    }
}
