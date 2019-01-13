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
    public partial class Form1 : Form
    {

        public byte[] memory;
        cpu580 cpu;

        public Ports ports;
        keyboard kb;

        Assembler asmForm;

        public Form1()
        {

            memory = new byte[65536];
            InitializeComponent();
            keyboard.initbtns();


            ports = new Ports();


            cpu = new cpu580(memory, ports);

            kb = new keyboard();

            asmForm = new Assembler(memory, cpu, this);


            dataGridView1.RowCount = 256;
            dataGridView1.ColumnCount = 3;

            redrawmemtable();
            update_regs();
        }

        public void redrawmemtable()
        {
            int beg = (int)MemAddrBeg.Value;
            int i;
            int inst = 0;
            for (i = 0; i < 256; ++i)
            {
                // Store integer 182
                int intValue = memory[i + beg];
                // Convert integer 182 as a hex in a string variable
                string hexValue = intValue.ToString("X");

                string addrhex = (beg + i).ToString("X");

                while (addrhex.Length < 4 ) addrhex = '0' + addrhex;

                //addrhex = '0x' + addrhex;

                dataGridView1.Rows[i].Cells[0].Value = addrhex;
                dataGridView1.Rows[i].Cells[1].Value = hexValue;
                if (i >= inst)
                {
                    dataGridView1.Rows[i].Cells[2].Value = cpu.instruction_str((UInt16)(beg + i));
                    inst += cpu.ist_length((byte)intValue);
                }
                else dataGridView1.Rows[i].Cells[2].Value = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MemAddrBeg_ValueChanged(object sender, EventArgs e)
        {
            redrawmemtable();
        }

        private void update_regs()
        {
            GuiRegA.Value = cpu.registers.a;
            GuiRegB.Value = cpu.registers.b;
            GuiRegC.Value = cpu.registers.c;
            GuiRegD.Value = cpu.registers.d;
            GuiRegE.Value = cpu.registers.e;
            GuiRegH.Value = cpu.registers.h;
            GuiRegL.Value = cpu.registers.l;
            GuiRegPC.Value = cpu.registers.PC;
            GuiRegSP.Value = cpu.registers.SP;

            FlagS.Checked = cpu.registers.flags.S;
            FlagZ.Checked = cpu.registers.flags.Z;
            FlagP.Checked = cpu.registers.flags.P;
            FlagAC.Checked = cpu.registers.flags.AC;
            FlagC.Checked = cpu.registers.flags.C;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {

                int beg = (int)MemAddrBeg.Value;

                int i = e.RowIndex;
                string hexValue = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                int intAgain;
                try
                {
                    intAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    intAgain = 0;
                }
                memory[i+beg] = (byte)(intAgain & 0xff);


                // Convert integer 182 as a hex in a string variable
                hexValue = (intAgain & 0xff).ToString("X");
                dataGridView1.Rows[i].Cells[1].Value = hexValue;

                redrawmemtable();

            }
        }

        private void GuiRegA_ValueChanged(object sender, EventArgs e)
        {
            cpu.registers.a = (byte)GuiRegA.Value;
        }

        private void GuiRegB_ValueChanged(object sender, EventArgs e)
        {
            cpu.registers.b = (byte)GuiRegB.Value;
        }

        private void GuiRegC_ValueChanged(object sender, EventArgs e)
        {
            cpu.registers.c = (byte)GuiRegC.Value;
        }

        private void GuiRegD_ValueChanged(object sender, EventArgs e)
        {
            cpu.registers.d = (byte)GuiRegD.Value;
        }

        private void GuiRegE_ValueChanged(object sender, EventArgs e)
        {
            cpu.registers.e = (byte)GuiRegE.Value;
        }

        private void GuiRegH_ValueChanged(object sender, EventArgs e)
        {
            cpu.registers.h = (byte)GuiRegH.Value;
        }

        private void GuiRegL_ValueChanged(object sender, EventArgs e)
        {
            cpu.registers.l = (byte)GuiRegL.Value;
        }

        private void GuiRegSP_ValueChanged(object sender, EventArgs e)
        {
            cpu.registers.SP = (UInt16)GuiRegSP.Value;
        }

        private void GuiRegPC_ValueChanged(object sender, EventArgs e)
        {
            cpu.registers.PC = (UInt16)GuiRegPC.Value;

            int index = cpu.registers.PC - (int)MemAddrBeg.Value;

            for (int i = 0; i < 256; i++)
                dataGridView1.Rows[i].Selected = false;

            if ((index >= 0) && (index <= 255))
                dataGridView1.Rows[index].Selected = true;

        }

        void instruction_step()
        {
            cpu.inst_step();

            redrawmemtable();
            update_regs();
        }


        private void instructionBTN_Click(object sender, EventArgs e)
        {
            if (AutomaticModebtn.Checked)
            {
                instructionBTN.Visible = false;
                button1.Visible = true;
                timer1.Start();
            }
            else
            {
                instruction_step();
            }
                
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FlagS_CheckedChanged(object sender, EventArgs e)
        {
            cpu.registers.flags.S = FlagS.Checked;
        }

        private void FlagZ_CheckedChanged(object sender, EventArgs e)
        {
            cpu.registers.flags.Z = FlagZ.Checked;
        }

        private void FlagAC_CheckedChanged(object sender, EventArgs e)
        {
            cpu.registers.flags.AC = FlagAC.Checked;
        }

        private void FlagP_CheckedChanged(object sender, EventArgs e)
        {
            cpu.registers.flags.P = FlagP.Checked;
        }

        private void FlagC_CheckedChanged(object sender, EventArgs e)
        {
            cpu.registers.flags.C = FlagC.Checked;
        }

        private void AutomaticModebtn_CheckedChanged(object sender, EventArgs e)
        {
            if (AutomaticModebtn.Checked)
            {
                intervalLabel.Visible = true;
                msLabel.Visible = true;
                TimerPeriod.Visible = true;
                skipcmd.Visible = true;
                label12.Visible = true;
            } 
            else
            {
                intervalLabel.Visible = false;
                msLabel.Visible = false;
                TimerPeriod.Visible = false;
                skipcmd.Visible = false;
                label12.Visible = false;
            }
        }

        private void CmdMOdebtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TimerPeriod_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = (int)TimerPeriod.Value;

            }
            catch
            {
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i=0;i<=skipcmd.Value;i++)
                cpu.inst_step();

            redrawmemtable();
            update_regs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            instructionBTN.Visible = true;
            button1.Visible = false;
            timer1.Stop();
        }

        private void ассемблерToolStripMenuItem_Click(object sender, EventArgs e)
        {
                asmForm.Visible = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void клавиатураToolStripMenuItem_Click(object sender, EventArgs e)
        {
                    kb.Visible = true;
        }

        private void тестоваяформаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            byte[] buffer = System.IO.File.ReadAllBytes(dialog.FileName);

            for (int i=0;i<buffer.Length;i++)
            {
                memory[i + 0x800] = buffer[i];
            }

            redrawmemtable();

        }
    }

    public class Ports
    {
        byte[] ports;
        public Ports()
        {
            ports = new byte[255];
        }

        public void port_set(int index, byte data)
        {
            switch (index)
            {
                case 0x05:
                    for (int i=0;i<8;i++)
                    {
                        bool st = false;

                        if (((data >> (7 - i)) & 0x01) == 0x01) st = true;

                        if (st)
                            keyboard.led[i].BackColor = Color.Green;
                        else
                            keyboard.led[i].BackColor = Color.White;
                    }
                    break;
                default:
                    break;
            }
            ports[index] = data;
        }

        public byte port_get(int index)
        {
            switch (index)
            {
                case 0x05:
                    {
                        byte data = 0;
                        for (int i=0;i<8;i++)
                        {
                            bool cur = keyboard.checker[i].Checked;
                            if (cur)
                            {
                                data |= (byte)(1 << (7-i));
                            }
                        }
                        return data;
                    }
                case 0x06:
                    {
                        byte keymsk = (1<<4)|(1<<6)|(1<<5)|(1<<2);
                        //try
                        {
                            byte keys_en = (byte)(~ports[0x07]);
                            for (int i = 0; i < 6; i++)
                            {
                                if (((keys_en >> i) & 1) != 0)
                                {
                                    for (int j = 0; j < 4; j++)
                                    {
                                        int bit = 0;
                                        switch (j)
                                        {
                                            case 0:
                                                bit = 4;
                                                break;
                                            case 1:
                                                bit = 6;
                                                break;
                                            case 2:
                                                bit = 5;
                                                break;
                                            case 3:
                                                bit = 2;
                                                break;
                                            default:
                                                break;
                                        }
                                        if (keyboard.buttons[j][i].BackColor != Color.White)
                                        {
                                            keymsk &= (byte)(~(1 << bit));
                                        }
                                    }
                                }
                            }
                        }
                        //catch (Exception e)
                        {

                        }
                        return keymsk;
                    }
                default:
                    break;
            }
            return ports[index];
        }

    }

    public class HexNumericUpDown : System.Windows.Forms.NumericUpDown
    {
        public HexNumericUpDown()
        {
            Hexadecimal = true;
        }

        protected override void ValidateEditText()
        {
            if (base.UserEdit)
            {
                base.ValidateEditText();
            }
        }

        protected override void UpdateEditText()
        {
            Text = System.Convert.ToInt64(base.Value).ToString("X" + HexLength);
        }

        [System.ComponentModel.DefaultValue(4)]
        public int HexLength
        {
            get { return m_nHexLength; }
            set { m_nHexLength = value; }
        }

        public new System.Int64 Value
        {
            get { return System.Convert.ToInt64(base.Value); }
            set { base.Value = System.Convert.ToDecimal(value); }
        }

        private int m_nHexLength = 4;
    }

}
