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
    public partial class Assembler : Form
    {
        cpu580 cpu;
        byte[] mem;
        private Form1 form1;

        public Assembler(byte[] memory, cpu580 c, Form1 form1)
        {
            this.form1 = form1;
            cpu = c;
            mem = memory;
            InitializeComponent();
        }

        private void Assembler_Load(object sender, EventArgs e)
        {

        }


        struct prog_block
        {
            public int beg;
            public int end;
        }

        struct prog_LABEL
        {
            public UInt16 addr;
            public int number;
        }

        struct string_addr
        {
            public string STR;
            public UInt16 addr;
        }

        private void дизасемблироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<prog_block> blocks = new List<prog_block>();

            int i = 0;
            while (i<65536)
            {
                while (true)
                {
                    if (i > 65535) break;
                    if (mem[i] != 0) break;
                    else i++;
                }

                int beg = i;

                while (true)
                {
                    if (i > 65535) break;
                    if (mem[i] == 0) break;
                    else i++;
                }

                int end = i;

                if (beg<65536)
                {
                    prog_block element;
                    element.beg = beg;
                    element.end = end;

                    blocks.Add(element);
                }
            }


            

            for (i=1;i<blocks.Count;i++)
            {
                int diff = blocks.ElementAt(i).beg - blocks.ElementAt(i - 1).end;

                if (diff<16)
                {
                    int tmpbeg = blocks.ElementAt(i - 1).beg;
                    prog_block tmp_block = blocks.ElementAt(i);
                    tmp_block.beg = tmpbeg;


                    blocks.RemoveAt(i);
                    blocks.RemoveAt(i - 1);

                    blocks.Insert(i - 1, tmp_block);

                    i--;

                }


                
            }

            List<prog_LABEL> labels = new List<prog_LABEL>();
            int numoflbls = 0;


            List<string_addr> lines = new List<string_addr>();

            for (i = 0; i < blocks.Count; i++)
            {
                //textBox1.Text += "$ORG " + blocks.ElementAt(i).beg.ToString("X"+4) + Environment.NewLine;

                int j = blocks.ElementAt(i).beg;
                while (j < blocks.ElementAt(i).end)
                {
                    string tmp_asm = cpu.instruction_str((UInt16)j);

                    if (cpu.ist_length(mem[j])==3)
                    {
                        string[] splited = tmp_asm.Split(' ');

                        UInt16 lbladdr = 0;
                        if (splited[0] == "LXI")
                        {
                            splited[0] = splited[0] + " " + splited[1];
                            lbladdr = (UInt16)(int.Parse(splited[2], System.Globalization.NumberStyles.HexNumber));
                        }
                        else lbladdr = (UInt16)(int.Parse(splited[1], System.Globalization.NumberStyles.HexNumber));


                        int element = -1;
                        for (int k=0;k<labels.Count;k++)
                        {
                            if (labels.ElementAt(k).addr==lbladdr)
                            {
                                element = k;
                                break;
                            }
                        }

                        if (element == -1)
                        {
                            int lblnum = ++numoflbls;
                            prog_LABEL _LABEL;
                            _LABEL.addr = lbladdr;
                            _LABEL.number = lblnum;

                            labels.Add(_LABEL);

                            tmp_asm = splited[0] + " _LABEL" + lblnum;

                        }
                        else
                        {
                            tmp_asm = splited[0] + " _LABEL" + labels.ElementAt(element);
                        }

                    }

                    string tmp_lbl = "";
                    /*
                    for (int k = 0; k < labels.Count; k++)
                    {
                        if (labels.ElementAt(k).addr == j)
                        {
                            tmp_lbl = "_LABEL" + labels.ElementAt(k).number + ": ";//j.ToString("X" + 4) + ": ";
                            break;
                        }
                    }
                    */

                    string_addr string_Addr;
                    string_Addr.STR = tmp_lbl + tmp_asm + Environment.NewLine;
                    string_Addr.addr = (UInt16)j;

                    lines.Add(string_Addr);

                    j += cpu.ist_length(mem[j]);
                }


            }

            textBox1.Text = "";


            for (int iter=0; iter < lines.Count; iter++)
            {
                string tmp = "";

                for (int k = 0; k < labels.Count; k++)
                {
                    if (labels.ElementAt(k).addr == lines.ElementAt(iter).addr)
                    {
                        tmp = "_LABEL" + labels.ElementAt(k).number + ": ";//j.ToString("X" + 4) + ": ";
                        labels.RemoveAt(k);
                        break;
                    }
                }

                textBox1.Text += tmp + lines.ElementAt(iter).STR;
            }


            for (int k = 0; k < labels.Count; k++)
            {
                textBox1.Text += ";Ошибочная метка __LABEL" + labels.ElementAt(k).number + " ссылается по адресу 0x" + labels.ElementAt(k).addr.ToString("X4") + " со значением 0x"+mem[labels.ElementAt(k).addr].ToString("X2") + Environment.NewLine;
            }



        }

        private void ассемблироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 65536; i++) mem[i] = 0;

            UInt16 memptr = 0;

            string[] strings = textBox1.Text.ToUpper().Replace(",","").Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            string[][] table_text = new string[strings.Length][];
            

            for (int i=0;i<strings.Length;i++)
            {
                table_text[i] = strings[i].Split(' ');

                if (table_text[i][0]=="ORG")
                {
                    memptr = (UInt16)int.Parse(table_text[i][1], System.Globalization.NumberStyles.HexNumber);
                    continue;
                }

                bool cmdok = false;
                int j=0;
                for (j=0;j<256;j++)
                {
                    string[] tmp = cpu.instruction_str((byte)(j)).Replace(",","").Split(' ');
                    if (tmp[0]==table_text[i][0])
                    {
                        int size = cpu.ist_length((byte)(j));

                        switch (size)
                        {
                            case 1:
                                {
                                    bool regok = true;
                                    for (int k=1;k<tmp.Length;k++)
                                    {
                                        if (tmp[k]!=table_text[i][k])
                                        {
                                            regok = false;
                                            break;
                                        }
                                    }
                                    if (regok == false) continue;
                                    else cmdok = true;
                                }
                                break;
                            case 2:
                                {
                                    if (tmp[0] == "MVI")
                                    {
                                        if (tmp[1] == table_text[i][1]) cmdok = true;
                                    }
                                    else cmdok = true;

                                }
                                break;
                            case 3:
                                {
                                    if (tmp[0] == "LXI")
                                    {
                                        if (tmp[1] == table_text[i][1]) cmdok = true;
                                    }
                                    else cmdok = true;
                                }
                                break;
                            default:
                                break;
                        }

                        if (cmdok == true) break;

                    }
                }

                int sizecmd = cpu.ist_length((byte)(j));

                if (cmdok)
                {
                    mem[memptr] = (byte)j;


                    if (sizecmd == 2)
                    {
                        int argoffset = 1;
                        if (table_text[i][0] == "MVI") argoffset = 2;
                        mem[memptr + 1] = (byte)int.Parse(table_text[i][argoffset], System.Globalization.NumberStyles.HexNumber);
                    }
                    if (sizecmd == 3)
                    {
                        int argoffset = 1;
                        if (table_text[i][0] == "LXI") argoffset = 2;
                        UInt16 data = 0;
                        if (table_text[i][argoffset].ElementAt(0)=='$')
                        {
                            if (table_text[i][argoffset].ElementAt(1) == '+')
                                data = (UInt16)(memptr + int.Parse(table_text[i][argoffset].Remove(0, 2), System.Globalization.NumberStyles.HexNumber));
                            if (table_text[i][argoffset].ElementAt(1) == '-')
                                data = (UInt16)(memptr - int.Parse(table_text[i][argoffset].Remove(0, 2), System.Globalization.NumberStyles.HexNumber));
                        }
                        else data= (UInt16)(int.Parse(table_text[i][argoffset], System.Globalization.NumberStyles.HexNumber) );
                        mem[memptr + 1] = (byte)(data & 0xff);
                        mem[memptr + 2] = (byte)(data >> 8);
                    }

                    memptr += (UInt16)sizecmd;
                }
                else
                {
                    if (table_text[i][0] == "DB")
                    {
                        mem[memptr] = (byte)int.Parse(table_text[i][1], System.Globalization.NumberStyles.HexNumber);
                        memptr++;
                    }
                }

            }
            form1.redrawmemtable();
        }

        private void Assembler_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }
    }
}
