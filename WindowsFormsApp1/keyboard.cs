using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class keyboard : Form
    {


        public static Button[][] buttons;
        public static Button[] led;
        public static CheckBox[] checker;

        public static void initbtns()
        {
            buttons = new Button[4][];

            for (int i = 0; i < 4; i++)
            {
                buttons[i] = new Button[6];
                for (int j = 0; j < 6; j++)
                {
                    buttons[i][j] = new Button();
                }
            }
        }

        public static readonly string[] Titles = 
            { "3", "7", "B", "F",
                "2", "6", "A", "E",
                "1", "5", "9", "D",
                "0", "4", "8", "C",
                "РГ", "КС", "ПМ", "ВП",
                "П", "СТ", "ЗК", "└┘" };

        public keyboard()
        {
            InitializeComponent();

            led = new Button[8];
            checker = new CheckBox[8];

            for (int i=0;i<8;i++)
            {
                led[i] = new Button();
                led[i].Enabled = false;
                checker[i] = new CheckBox();
                leds.Controls.Add(led[i], i, 0);
                checkers.Controls.Add(checker[i], i, 0);
                led[i].Dock = System.Windows.Forms.DockStyle.Fill;
                checker[i].Dock = System.Windows.Forms.DockStyle.Fill;
            }


            for (int i=0;i<4;i++)
            {
                for (int j=0;j<6;j++)
                {
                    buttons[i][j].Text = Titles[j*4+i];
                    buttons[i][j].BackColor = Color.White;
                    buttons[i][j].Click += new System.EventHandler(this.ButtonClick);
                    tableLayoutPanel1.Controls.Add(buttons[i][j], i, j);
                 //   buttons[i][j].
                }
            }


        }

        void ButtonClick(object sender, EventArgs e)
        {
            Button btn = null;
            for (int i=0;i<4;i++)
                for (int j=0;j<6;j++)
                {
                    if ((Button)(sender) == buttons[i][j])
                        btn=buttons[i][j];
                }

            if (btn.BackColor==Color.White)
            {
                btn.BackColor = Color.Yellow;
            }
            else
            {
                btn.BackColor = Color.White;
            }

        }

        private void keyboard_Load(object sender, EventArgs e)
        {

        }

        private void keyboard_FormClosing(object sender, FormClosingEventArgs e)
        {
                this.Hide();
                e.Cancel = true; // this cancels the close event.
            
        }
    }
}
