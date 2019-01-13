using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{


    public class Flags
    {
        public bool S;
        public bool Z;
        public bool AC;
        public bool P;
        public bool C;

        public Flags()
        {
            S = false;
            Z = false;
            AC = false;
            P = false;
            C = false;
        }

        public byte flags
        {
            get
            {
                byte f = 0;
                if (S) f |= 0x80;
                if (Z) f |= 0x40;
                if (AC) f |= 0x10;
                if (P) f |= 0x04;
                if (C) f |= 0x01;
                return f;
            }
            set
            {
                if ((value & 0x80) == 0x80) S = true;
                else S = false;

                if ((value & 0x40) == 0x40) Z = true;
                else Z = false;

                if ((value & 0x10) == 0x10) AC = true;
                else AC = false;

                if ((value & 0x04) == 0x04) P = true;
                else P = false;

                if ((value & 0x01) == 0x01) C = true;
                else C = false;
            }
        }

    };

    public class Cpu580Regs
    {
        public byte a;
        public byte b;
        public byte c;
        public byte d;
        public byte e;
        public byte h;
        public byte l;
        public Flags flags;
        public UInt16 PC;
        public UInt16 SP;

        byte[] mem;

        public Cpu580Regs(byte[] mem)
        {
            a = 0;
            b = 0;
            c = 0;
            d = 0;
            e = 0;
            h = 0;
            l = 0;
            flags = new Flags();
            PC = 0;
            SP = 0xffff;
            this.mem = mem;
        }


        public void set(int num,byte value)
        {
            switch (num)
            {
                case 0:
                    b = value;
                    break;
                case 1:
                    c = value;
                    break;
                case 2:
                    d = value;
                    break;
                case 3:
                    e = value;
                    break;
                case 4:
                    h = value;
                    break;
                case 5:
                    l = value;
                    break;
                case 6:
                    m = value;
                    break;
                case 7:
                    a = value;
                    break;
                default:
                    break;
            }
        }

        public byte get(int num)
        {
            switch(num)
            {
                case 0: return b;
                case 1: return c;
                case 2: return d;
                case 3: return e;
                case 4: return h;
                case 5: return l;
                case 6: return m;
                case 7: return a;
                default: return 0;
            }
        }

        public byte m
        {
            get
            {
                return mem[hl];
            }
            set
            {
                mem[hl] = value;
            }
        }

        public UInt16 bc
        {
            get
            {
                return (UInt16)((b << 8) | c);
            }
            set
            {
                b = (byte)(value >> 8);
                c = (byte)(value & 0xff);
            }
        }

        public UInt16 de
        {
            get
            {
                return (UInt16)((d << 8) | e);
            }
            set
            {
                d = (byte)(value >> 8);
                e = (byte)(value & 0xff);
            }
        }

        public UInt16 hl
        {
            get
            {
                return (UInt16)((h << 8) | l);
            }
            set
            {
                h = (byte)(value >> 8);
                l = (byte)(value & 0xff);
            }
        }

        public UInt16 PSW
        {
            get
            {
                return (UInt16)((flags.flags << 8) | (a));
            }
            set
            {
                a = (byte)(value & 0xff);
                flags.flags = (byte)(value >> 8);
            }
        }


        public void set16(int num,UInt16 value)
        {
            switch (num)
            {
                case 0:
                    bc = value;
                    break;
                case 1:
                    de = value;
                    break;
                case 2:
                    hl = value;
                    break;
                case 3:
                    SP = value;
                    break;
                default:
                    break;
            }
        }

        public UInt16 get16(int num)
        {
            switch (num)
            {
                case 0:
                    return bc;
                case 1:
                    return de;
                case 2:
                    return hl;
                case 3:
                    return SP;
                default:
                    return 0;
            }
        }

    };


    public class cpu580
    {
        public Cpu580Regs registers;
        byte[] memory;
        Ports _ports;
        
       
        void port_set(int index , byte data)
        {
            _ports.port_set( index,  data);
        }

        byte port_get(int index)
        {
            return _ports.port_get(index);
        }


        public cpu580(byte[] mem,Ports ports)
        {
            registers = new Cpu580Regs(mem);
            memory = mem;
            _ports = ports;
        }

        public int ist_length(byte instruction)
        {

            switch (instruction)
            {
                case 0x00: return 1;
                case 0x01: return 3;
                case 0x02: return 1;
                case 0x03: return 1;
                case 0x04: return 1;
                case 0x05: return 1;
                case 0x06: return 2;
                case 0x07: return 1;
                case 0x08: return 1;
                case 0x09: return 1;
                case 0x0a: return 1;
                case 0x0b: return 1;
                case 0x0c: return 1;
                case 0x0d: return 1;
                case 0x0e: return 2;
                case 0x0f: return 1;
                case 0x10: return 1;
                case 0x11: return 3;
                case 0x12: 
                case 0x13:
                case 0x14:
                case 0x15: return 1;
                case 0x16: return 2;
                case 0x17:
                case 0x18:
                case 0x19:
                case 0x1a:
                case 0x1b:
                case 0x1c:
                case 0x1d: return 1;
                case 0x1e: return 2;
                case 0x1f:
                case 0x20: return 1;
                case 0x21: return 3;
                case 0x22: return 3;
                case 0x23:
                case 0x24:
                case 0x25: return 1;
                case 0x26: return 2;
                case 0x27:
                case 0x28:
                case 0x29: return 1;
                case 0x2a: return 3;
                case 0x2b:
                case 0x2c:
                case 0x2d: return 1;
                case 0x2e: return 2;
                case 0x2f: 
                case 0x30: return 1;
                case 0x31:
                case 0x32: return 3;
                case 0x33:
                case 0x34:
                case 0x35: return 1;
                case 0x36: return 2;
                case 0x37: return 1;
                case 0x38: return 1;
                case 0x39: return 1;
                case 0x3a: return 3;
                case 0x3b: return 1;
                case 0x3c: return 1;
                case 0x3d: return 1;
                case 0x3e: return 2;
                case 0x3f: return 1;
                case 0x40:
                case 0x41:
                case 0x42:
                case 0x43:
                case 0x44:
                case 0x45:
                case 0x46:
                case 0x47:
                case 0x48:
                case 0x49:
                case 0x4a:
                case 0x4b:
                case 0x4c:
                case 0x4d:
                case 0x4e:
                case 0x4f:
                case 0x50:
                case 0x51:
                case 0x52:
                case 0x53:
                case 0x54:
                case 0x55:
                case 0x56:
                case 0x57:
                case 0x58:
                case 0x59:
                case 0x5a:
                case 0x5b:
                case 0x5c:
                case 0x5d:
                case 0x5e:
                case 0x5f:
                case 0x60:
                case 0x61:
                case 0x62:
                case 0x63:
                case 0x64:
                case 0x65:
                case 0x66:
                case 0x67:
                case 0x68:
                case 0x69:
                case 0x6a:
                case 0x6b:
                case 0x6c:
                case 0x6d:
                case 0x6e:
                case 0x6f:
                case 0x70:
                case 0x71:
                case 0x72:
                case 0x73:
                case 0x74:
                case 0x75:
                case 0x76:
                case 0x77:
                case 0x78:
                case 0x79:
                case 0x7a:
                case 0x7b:
                case 0x7c:
                case 0x7d:
                case 0x7e:
                case 0x7f:
                case 0x80:
                case 0x81:
                case 0x82:
                case 0x83:
                case 0x84:
                case 0x85:
                case 0x86:
                case 0x87:
                case 0x88:
                case 0x89:
                case 0x8a:
                case 0x8b:
                case 0x8c:
                case 0x8d:
                case 0x8e:
                case 0x8f:
                case 0x90:
                case 0x91:
                case 0x92:
                case 0x93:
                case 0x94:
                case 0x95:
                case 0x96:
                case 0x97:
                case 0x98:
                case 0x99:
                case 0x9a:
                case 0x9b:
                case 0x9c:
                case 0x9d:
                case 0x9e:
                case 0x9f:
                case 0xa0:
                case 0xa1:
                case 0xa2:
                case 0xa3:
                case 0xa4:
                case 0xa5:
                case 0xa6:
                case 0xa7:
                case 0xa8:
                case 0xa9:
                case 0xaa:
                case 0xab:
                case 0xac:
                case 0xad:
                case 0xae:
                case 0xaf:
                case 0xb0:
                case 0xb1:
                case 0xb2:
                case 0xb3:
                case 0xb4:
                case 0xb5:
                case 0xb6:
                case 0xb7:
                case 0xb8:
                case 0xb9:
                case 0xba:
                case 0xbb:
                case 0xbc:
                case 0xbd:
                case 0xbe:
                case 0xbf: return 1;
                case 0xc0:
                case 0xc1: return 1;
                case 0xc2:
                case 0xc3:
                case 0xc4: return 3;
                case 0xc5: return 1;
                case 0xc6: return 2;
                case 0xc7:
                case 0xc8:
                case 0xc9: return 1;
                case 0xca: return 3;
                case 0xcb: return 3;
                case 0xcc: return 3;
                case 0xcd: return 3;
                case 0xce: return 2;
                case 0xcf: 
                case 0xd0:
                case 0xd1: return 1;
                case 0xd2: return 3;
                case 0xd3: return 2;
                case 0xd4: return 3;
                case 0xd5: return 1;
                case 0xd6: return 2;
                case 0xd7: 
                case 0xd8:
                case 0xd9: return 1;
                case 0xda: return 3;
                case 0xdb: return 2;
                case 0xdc: return 3;
                case 0xdd: return 3;
                case 0xde: return 2;
                case 0xdf: return 1;
                case 0xe0: return 1;
                case 0xe1: return 1;
                case 0xe2: return 3;
                case 0xe3: return 1;
                case 0xe4: return 3;
                case 0xe5: return 1;
                case 0xe6: return 2;
                case 0xe7: return 1;
                case 0xe8: return 1;
                case 0xe9: return 1;
                case 0xea: return 3;
                case 0xeb: return 1;
                case 0xec: return 3;
                case 0xed: return 3;
                case 0xee: return 2;
                case 0xef: return 1;
                case 0xf0: return 1;
                case 0xf1: return 1;
                case 0xf2: return 3;
                case 0xf3: return 1;
                case 0xf4: return 3;
                case 0xf5: return 1;
                case 0xf6: return 2;
                case 0xf7: return 1;
                case 0xf8: return 1;
                case 0xf9: return 1;
                case 0xfa: return 3;
                case 0xfb: return 1;
                case 0xfc: return 3;
                case 0xfd: return 3;
                case 0xfe: return 2;
                case 0xff: return 1;
                default: return 0;
            }
        }

        string SRC_REG(byte cmd)
        {
            cmd &= 0x07;
            switch (cmd)
            {
                case 0:
                    return "B";
                case 1:
                    return "C";
                case 2:
                    return "D";
                case 3:
                    return "E";
                case 4:
                    return "H";
                case 5:
                    return "L";
                case 6:
                    return "M";
                case 7:
                    return "A";
                default: return "";
            }
        }

        string DST_REG(byte cmd)
        {
            cmd >>= 3;
            return SRC_REG(cmd);
        }

        string memto16hex(UInt16 addr)
        {

            string addrhex = (memory[addr]|(memory[addr+1]<<8)).ToString("X");

            while (addrhex.Length < 4) addrhex = '0' + addrhex;
            return addrhex;
        }

        string memto8hex(UInt16 addr)
        {

            string addrhex = (memory[addr]).ToString("X");

            while (addrhex.Length < 2) addrhex = '0' + addrhex;
            return addrhex;
        }

        UInt16 memto16(UInt16 addr)
        {
            return (UInt16)(memory[addr] | (memory[addr + 1] << 8));
        }

        void memfrom16(UInt16 addr,UInt16 data)
        {
            memory[addr] = (byte)(data & 0xff);
            memory[addr + 1] = (byte)(data >> 8);
        }


        public string instruction_str(byte cmd)
        {
            string str = "";
            
            if (cmd == 0x00) str = "NOP";
            else if (cmd == 0x01) str = "LXI B, " + "0000";
            else if (cmd == 0x02) str = "STAX B";
            else if (cmd == 0x03) str = "INX B";
            else if (cmd == 0x04) str = "INR B";
            else if (cmd == 0x05) str = "DCR B";
            else if (cmd == 0x06) str = "MVI B, " + "00";
            else if (cmd == 0x07) str = "RLC";
            else if (cmd == 0x08) str = "*NOP";
            else if (cmd == 0x09) str = "DAD B";
            else if (cmd == 0x0a) str = "LDAX B";
            else if (cmd == 0x0b) str = "DCX B";
            else if (cmd == 0x0c) str = "INR C";
            else if (cmd == 0x0d) str = "DCR C";
            else if (cmd == 0x0e) str = "MVI C, " + "00";
            else if (cmd == 0x0f) str = "RRC";
            else if (cmd == 0x10) str = "*NOP";
            else if (cmd == 0x11) str = "LXI D, " + "0000";
            else if (cmd == 0x12) str = "STAX D";
            else if (cmd == 0x13) str = "INX D";
            else if (cmd == 0x14) str = "INR D";
            else if (cmd == 0x15) str = "DCR D";
            else if (cmd == 0x16) str = "MVI D, " + "00";
            else if (cmd == 0x17) str = "RAL";
            else if (cmd == 0x18) str = "*NOP";
            else if (cmd == 0x19) str = "DAD D";
            else if (cmd == 0x1a) str = "LDAX D";
            else if (cmd == 0x1b) str = "DCX D";
            else if (cmd == 0x1c) str = "INR E";
            else if (cmd == 0x1d) str = "DCR E";
            else if (cmd == 0x1e) str = "MVI E, " + "00";
            else if (cmd == 0x1f) str = "RAR";
            else if (cmd == 0x20) str = "*NOP";
            else if (cmd == 0x21) str = "LXI H, " + "0000";
            else if (cmd == 0x22) str = "SHLD " + "0000";
            else if (cmd == 0x23) str = "INX H";
            else if (cmd == 0x24) str = "INR H";
            else if (cmd == 0x25) str = "DCR H";
            else if (cmd == 0x26) str = "MVI H, " + "00";
            else if (cmd == 0x27) str = "DAA";
            else if (cmd == 0x28) str = "*NOP";
            else if (cmd == 0x29) str = "DAD H";
            else if (cmd == 0x2a) str = "LHLD " + "0000";
            else if (cmd == 0x2b) str = "DCX H";
            else if (cmd == 0x2c) str = "INR L";
            else if (cmd == 0x2d) str = "DCR L";
            else if (cmd == 0x2e) str = "MVI L, " + "00";
            else if (cmd == 0x2f) str = "CMA";
            else if (cmd == 0x30) str = "*NOP";
            else if (cmd == 0x31) str = "LXI SP, " + "0000";
            else if (cmd == 0x32) str = "STA " + "0000";
            else if (cmd == 0x33) str = "INX SP";
            else if (cmd == 0x34) str = "INR M";
            else if (cmd == 0x35) str = "DCR M";
            else if (cmd == 0x36) str = "MVI M, " + "00";
            else if (cmd == 0x37) str = "STC";
            else if (cmd == 0x38) str = "*NOP";
            else if (cmd == 0x39) str = "DAD SP";
            else if (cmd == 0x3a) str = "LDA " + "0000";
            else if (cmd == 0x3b) str = "DCX SP";
            else if (cmd == 0x3c) str = "INR A";
            else if (cmd == 0x3d) str = "DCR A";
            else if (cmd == 0x3e) str = "MVI A, " + "00";
            else if (cmd == 0x3f) str = "CMC";
            else if (cmd == 0x76) str = "HLT";
            else if ((cmd & 0xc0) == 0x40)
            {
                str += "MOV ";
                str += DST_REG(cmd);
                str += ", ";
                str += SRC_REG(cmd);

            }
            else if ((cmd & 0xf8) == 0x80)
            {
                str += "ADD ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0x88)
            {
                str += "ADC ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0x90)
            {
                str += "SUB ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0x98)
            {
                str += "SBB ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0xa0)
            {
                str += "ANA ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0xa8)
            {
                str += "XRA ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0xb0)
            {
                str += "ORA ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0xb8)
            {
                str += "CMP ";
                str += SRC_REG(cmd);
            }
            else if (cmd == 0xc0) str = "RNZ";
            else if (cmd == 0xc1) str = "POP B";
            else if (cmd == 0xc2) str = "JNZ " + "0000";
            else if (cmd == 0xc3) str = "JMP " + "0000";
            else if (cmd == 0xc4) str = "CNZ " + "0000";
            else if (cmd == 0xc5) str = "PUSH B";
            else if (cmd == 0xc6) str = "ADI " + "00";
            else if (cmd == 0xc7) str = "RST 0";
            else if (cmd == 0xc8) str = "RZ";
            else if (cmd == 0xc9) str = "RET";
            else if (cmd == 0xca) str = "JZ " + "0000";
            else if (cmd == 0xcb) str = "*JMP " + "0000";
            else if (cmd == 0xcc) str = "CZ " + "0000";
            else if (cmd == 0xcd) str = "CALL " + "0000";
            else if (cmd == 0xce) str = "ACI " + "00";
            else if (cmd == 0xcf) str = "RST 1";
            else if (cmd == 0xd0) str = "RNC";
            else if (cmd == 0xd1) str = "POP D";
            else if (cmd == 0xd2) str = "JNC " + "0000";
            else if (cmd == 0xd3) str = "OUT " + "00";
            else if (cmd == 0xd4) str = "CNC " + "0000";
            else if (cmd == 0xd5) str = "PUSH D";
            else if (cmd == 0xd6) str = "SUI " + "00";
            else if (cmd == 0xd7) str = "RST 2";
            else if (cmd == 0xd8) str = "RC";
            else if (cmd == 0xd9) str = "*RET";
            else if (cmd == 0xda) str = "JC " + "0000";
            else if (cmd == 0xdb) str = "IN " + "00";
            else if (cmd == 0xdc) str = "CC " + "0000";
            else if (cmd == 0xdd) str = "*CALL " + "0000";
            else if (cmd == 0xde) str = "SBI " + "00";
            else if (cmd == 0xdf) str = "RST 3";
            else if (cmd == 0xe0) str = "RNC";
            else if (cmd == 0xe1) str = "POP H";
            else if (cmd == 0xe2) str = "JPO " + "0000";
            else if (cmd == 0xe3) str = "XTHL";
            else if (cmd == 0xe4) str = "CPO " + "0000";
            else if (cmd == 0xe5) str = "PUSH H";
            else if (cmd == 0xe6) str = "ANI " + "00";
            else if (cmd == 0xe7) str = "RST 4";
            else if (cmd == 0xe8) str = "RPE";
            else if (cmd == 0xe9) str = "PCHL";
            else if (cmd == 0xea) str = "JPE " + "0000";
            else if (cmd == 0xeb) str = "XCHG";
            else if (cmd == 0xec) str = "CPE " + "0000";
            else if (cmd == 0xed) str = "*CALL " + "0000";
            else if (cmd == 0xee) str = "XRI " + "00";
            else if (cmd == 0xef) str = "RST 5";
            else if (cmd == 0xf0) str = "RNC";
            else if (cmd == 0xf1) str = "POP PSW";
            else if (cmd == 0xf2) str = "JP " + "0000";
            else if (cmd == 0xf3) str = "DI";
            else if (cmd == 0xf4) str = "CP " + "0000";
            else if (cmd == 0xf5) str = "PUSH PSW";
            else if (cmd == 0xf6) str = "ORI " + "00";
            else if (cmd == 0xf7) str = "RST 6";
            else if (cmd == 0xf8) str = "RM";
            else if (cmd == 0xf9) str = "SPHL";
            else if (cmd == 0xfa) str = "JM " + "0000";
            else if (cmd == 0xfb) str = "EI";
            else if (cmd == 0xfc) str = "CM " + "0000";
            else if (cmd == 0xfd) str = "*CALL " + "0000";
            else if (cmd == 0xfe) str = "CPI " + "00";
            else if (cmd == 0xff) str = "RST 7";
            else str = "ERR";

            return str;
        }


        public string instruction_str(UInt16 addr)
        {
            string str = "";

            byte cmd = memory[addr];
            if (cmd == 0x00) str = "NOP";
            else if (cmd == 0x01) str = "LXI B, " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0x02) str = "STAX B";
            else if (cmd == 0x03) str = "INX B";
            else if (cmd == 0x04) str = "INR B";
            else if (cmd == 0x05) str = "DCR B";
            else if (cmd == 0x06) str = "MVI B, " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0x07) str = "RLC";
            else if (cmd == 0x08) str = "*NOP";
            else if (cmd == 0x09) str = "DAD B";
            else if (cmd == 0x0a) str = "LDAX B";
            else if (cmd == 0x0b) str = "DCX B";
            else if (cmd == 0x0c) str = "INR C";
            else if (cmd == 0x0d) str = "DCR C";
            else if (cmd == 0x0e) str = "MVI C, " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0x0f) str = "RRC";
            else if (cmd == 0x10) str = "*NOP";
            else if (cmd == 0x11) str = "LXI D, " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0x12) str = "STAX D";
            else if (cmd == 0x13) str = "INX D";
            else if (cmd == 0x14) str = "INR D";
            else if (cmd == 0x15) str = "DCR D";
            else if (cmd == 0x16) str = "MVI D, " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0x17) str = "RAL";
            else if (cmd == 0x18) str = "*NOP";
            else if (cmd == 0x19) str = "DAD D";
            else if (cmd == 0x1a) str = "LDAX D";
            else if (cmd == 0x1b) str = "DCX D";
            else if (cmd == 0x1c) str = "INR E";
            else if (cmd == 0x1d) str = "DCR E";
            else if (cmd == 0x1e) str = "MVI E, " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0x1f) str = "RAR";
            else if (cmd == 0x20) str = "*NOP";
            else if (cmd == 0x21) str = "LXI H, " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0x22) str = "SHLD " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0x23) str = "INX H";
            else if (cmd == 0x24) str = "INR H";
            else if (cmd == 0x25) str = "DCR H";
            else if (cmd == 0x26) str = "MVI H, " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0x27) str = "DAA";
            else if (cmd == 0x28) str = "*NOP";
            else if (cmd == 0x29) str = "DAD H";
            else if (cmd == 0x2a) str = "LHLD " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0x2b) str = "DCX H";
            else if (cmd == 0x2c) str = "INR L";
            else if (cmd == 0x2d) str = "DCR L";
            else if (cmd == 0x2e) str = "MVI L, " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0x2f) str = "CMA";
            else if (cmd == 0x30) str = "*NOP";
            else if (cmd == 0x31) str = "LXI SP, " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0x32) str = "STA " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0x33) str = "INX SP";
            else if (cmd == 0x34) str = "INR M";
            else if (cmd == 0x35) str = "DCR M";
            else if (cmd == 0x36) str = "MVI M, " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0x37) str = "STC";
            else if (cmd == 0x38) str = "*NOP";
            else if (cmd == 0x39) str = "DAD SP";
            else if (cmd == 0x3a) str = "LDA " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0x3b) str = "DCX SP";
            else if (cmd == 0x3c) str = "INR A";
            else if (cmd == 0x3d) str = "DCR A";
            else if (cmd == 0x3e) str = "MVI A, " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0x3f) str = "CMC";
            else if (cmd == 0x76) str = "HLT";
            else if ((cmd & 0xc0) == 0x40)
            {
                str += "MOV ";
                str += DST_REG(cmd);
                str += ", ";
                str += SRC_REG(cmd);

            }
            else if ((cmd & 0xf8) == 0x80)
            {
                str += "ADD ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0x88)
            {
                str += "ADC ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0x90)
            {
                str += "SUB ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0x98)
            {
                str += "SBB ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0xa0)
            {
                str += "ANA ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0xa8)
            {
                str += "XRA ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0xb0)
            {
                str += "ORA ";
                str += SRC_REG(cmd);
            }
            else if ((cmd & 0xf8) == 0xb8)
            {
                str += "CMP ";
                str += SRC_REG(cmd);
            }
            else if (cmd == 0xc0) str = "RNZ";
            else if (cmd == 0xc1) str = "POP B";
            else if (cmd == 0xc2) str = "JNZ " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xc3) str = "JMP " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xc4) str = "CNZ " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xc5) str = "PUSH B";
            else if (cmd == 0xc6) str = "ADI " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0xc7) str = "RST 0";
            else if (cmd == 0xc8) str = "RZ";
            else if (cmd == 0xc9) str = "RET";
            else if (cmd == 0xca) str = "JZ " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xcb) str = "*JMP " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xcc) str = "CZ " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xcd) str = "CALL " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xce) str = "ACI " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0xcf) str = "RST 1";
            else if (cmd == 0xd0) str = "RNC";
            else if (cmd == 0xd1) str = "POP D";
            else if (cmd == 0xd2) str = "JNC " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xd3) str = "OUT " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0xd4) str = "CNC " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xd5) str = "PUSH D";
            else if (cmd == 0xd6) str = "SUI " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0xd7) str = "RST 2";
            else if (cmd == 0xd8) str = "RC";
            else if (cmd == 0xd9) str = "*RET";
            else if (cmd == 0xda) str = "JC " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xdb) str = "IN " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0xdc) str = "CC " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xdd) str = "*CALL " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xde) str = "SBI " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0xdf) str = "RST 3";
            else if (cmd == 0xe0) str = "RNC";
            else if (cmd == 0xe1) str = "POP H";
            else if (cmd == 0xe2) str = "JPO " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xe3) str = "XTHL";
            else if (cmd == 0xe4) str = "CPO " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xe5) str = "PUSH H";
            else if (cmd == 0xe6) str = "ANI " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0xe7) str = "RST 4";
            else if (cmd == 0xe8) str = "RPE";
            else if (cmd == 0xe9) str = "PCHL";
            else if (cmd == 0xea) str = "JPE " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xeb) str = "XCHG";
            else if (cmd == 0xec) str = "CPE " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xed) str = "*CALL " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xee) str = "XRI " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0xef) str = "RST 5";
            else if (cmd == 0xf0) str = "RNC";
            else if (cmd == 0xf1) str = "POP PSW";
            else if (cmd == 0xf2) str = "JP " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xf3) str = "DI";
            else if (cmd == 0xf4) str = "CP " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xf5) str = "PUSH PSW";
            else if (cmd == 0xf6) str = "ORI " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0xf7) str = "RST 6";
            else if (cmd == 0xf8) str = "RM";
            else if (cmd == 0xf9) str = "SPHL";
            else if (cmd == 0xfa) str = "JM " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xfb) str = "EI";
            else if (cmd == 0xfc) str = "CM " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xfd) str = "*CALL " + memto16hex((UInt16)(addr + 1));
            else if (cmd == 0xfe) str = "CPI " + memto8hex((UInt16)(addr + 1));
            else if (cmd == 0xff) str = "RST 7";
            else str = "ERR";

            return str;
        }

        void stack_push(UInt16 data)
        {
            memory[registers.SP] = (byte)(data >> 8);
            memory[registers.SP-1] = (byte)(data &0xff);
            registers.SP -= 2;
        }

        UInt16 stack_pop()
        {
            UInt16 data;
            registers.SP += 2;
            data = (UInt16)(memory[registers.SP - 1] | (memory[registers.SP] << 8));
            return data;
        }

        bool calculate_parity(byte data)
        {
            int ones = 0;
            while (data!=0)
            {
                if ((data & 0x01)==0x01) ones++;
                data >>= 1;
            }
            if ((ones % 2) == 0) return true;
            else return false;
        }

        public void inst_step()
        {
            byte instruction = memory[registers.PC];

            switch (instruction)
            {
                case 0x0: //NOP
                case 0x10:
                case 0x20:
                case 0x30:
                case 0x08:
                case 0x18:
                case 0x28:
                case 0x38:
                    break;


                case 0x1: // LXI B
                case 0x11: // LXI D
                case 0x21: // LXI H
                case 0x31: // LXI SP
                    {
                        UInt16 data = memto16((UInt16)(registers.PC + 1));
                        registers.set16((instruction >> 4) & 0x03, data);
                    }
                    break;


                case 0x02: // STAX B
                case 0x12: // STAX D
                    {
                        UInt16 addr = registers.get16((instruction >> 4) & 0x03);
                        memory[addr] = registers.a;
                    }
                    break;
                case 0x22: // SHLD
                    {
                        UInt16 addr = memto16((UInt16)(registers.PC + 1));
                        UInt16 value = registers.hl;
                        memfrom16(addr, value);
                    }
                    break;
                case 0x32: // STA
                    {
                        UInt16 addr = memto16((UInt16)(registers.PC + 1));
                        memory[addr] = registers.a;
                    }
                    break;

                case 0x03: // INX B
                case 0x13: // INX D
                case 0x23: // INX H
                case 0x33: // INX SP
                    {
                        UInt16 tmp= registers.get16((instruction >> 4) & 0x03);
                        tmp++;
                        registers.set16((instruction >> 4) & 0x03,tmp);
                    }
                    break;

                case 0x04: // INR
                case 0x0c:
                case 0x14:
                case 0x1c:
                case 0x24:
                case 0x2c:
                case 0x34:
                case 0x3c:
                    {

                        byte data = registers.get((instruction >> 3) & 0x07);

                        int result = data+1;

                        //if (result > 255) registers.flags.C = true;
                       // else registers.flags.C = false;

                        if ( (data & 0xf) == 15) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);

                        registers.set((instruction >> 3) & 0x07, (byte)result);

                    }
                    break;

                case 0x05: // DCR
                case 0x0d:
                case 0x15:
                case 0x1d:
                case 0x25:
                case 0x2d:
                case 0x35:
                case 0x3D:
                    {

                        byte data = registers.get((instruction >> 3) & 0x07);

                        int result = data-1;

                        //if (result > 255) registers.flags.C = true;
                        // else registers.flags.C = false;

                        if (((result & 0xf)) == 0xf) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);

                        registers.set((instruction >> 3) & 0x07, (byte)result);
                    }
                    break;

                case 0x06: // MVI
                case 0x0e:
                case 0x16:
                case 0x1e:
                case 0x26:
                case 0x2e:
                case 0x36:
                case 0x3e:
                    {
                        byte tmp = memory[registers.PC + 1];
                        registers.set((instruction >> 3) & 0x07, (byte)tmp);
                    }
                    break;

                case 0x07: // RLC
                    {
                        bool tmp = false;
                        if ((registers.a & 0x80) == 0x80) tmp = true;

                        registers.a <<= 1;

                        if (registers.flags.C) registers.a |= 1;

                        registers.flags.C = tmp;

                    }
                    break;

                case 0x0f: // RRC
                    {
                        bool tmp=false;
                        if ((registers.a & 0x01) == 0x01) tmp = true;

                        registers.a >>= 1;

                        if (registers.flags.C) registers.a |= 0x80;

                        registers.flags.C = tmp;

                    }
                    break;

                case 0x17: // RAL
                    {
                        //bool tmp = registers.flags.C;

                        if ((registers.a & 0x80) == 0x80) registers.flags.C = true;
                        else registers.flags.C = false;

                        registers.a <<= 1;

                        if (registers.flags.C) registers.a |= 1;

                    }
                    break;

                case 0x1f:
                    {
                        //bool tmp = registers.flags.C;

                        if ((registers.a & 0x01) == 0x01) registers.flags.C = true;
                        else registers.flags.C = false;

                        registers.a >>= 1;

                        if (registers.flags.C) registers.a |= 0x80;
                    }
                    break;

                case 0x27: // DAA
                    if (!registers.flags.AC) registers.a = 0;
                    else
                    {

                    }
                    break;

                case 0x2F: // CMA
                    registers.a = (byte) ~registers.a;
                    break;

                case 0x37: // STC
                    registers.flags.C = true;
                    break;

                case 0x3F: // CMC
                    registers.flags.C = !registers.flags.C;
                    break;

                case 0x09: // DAD 
                case 0x19:
                case 0x29:
                case 0x39:
                    registers.hl+=registers.get16((instruction >> 4) & 0x03);
                    break;


                case 0x0b: // DCX B
                case 0x1b: // DCX D
                case 0x2b: // DCX H
                case 0x3b: // DCX SP
                    {
                        UInt16 tmp = registers.get16((instruction >> 4) & 0x03);
                        tmp--;
                        registers.set16((instruction >> 4) & 0x03, tmp);
                    }
                    break;

                case 0x0a:
                case 0x1a:
                    {
                        UInt16 addr = registers.get16((instruction >> 4) & 0x03);
                        registers.a = memory[addr];
                    }
                    break;

                case 0x2a: // lhld
                    {
                        UInt16 addr = memto16((UInt16)(registers.PC + 1));
                        UInt16 value = memto16(addr);
                        registers.hl = value;
                    }
                    break;
                case 0x3a: // LDA
                    {
                        UInt16 addr = memto16((UInt16)(registers.PC + 1));
                        registers.a = memory[addr] ;
                    }
                    break;


                case 0x40:  // MOV
                case 0x41:
                case 0x42:
                case 0x43:
                case 0x44:
                case 0x45:
                case 0x46:
                case 0x47:
                case 0x48:
                case 0x49:
                case 0x4a:
                case 0x4b:
                case 0x4c:
                case 0x4d:
                case 0x4e:
                case 0x4f:
                case 0x50:
                case 0x51:
                case 0x52:
                case 0x53:
                case 0x54:
                case 0x55:
                case 0x56:
                case 0x57:
                case 0x58:
                case 0x59:
                case 0x5a:
                case 0x5b:
                case 0x5c:
                case 0x5d:
                case 0x5e:
                case 0x5f:
                case 0x60:
                case 0x61:
                case 0x62:
                case 0x63:
                case 0x64:
                case 0x65:
                case 0x66:
                case 0x67:
                case 0x68:
                case 0x69:
                case 0x6a:
                case 0x6b:
                case 0x6c:
                case 0x6d:
                case 0x6e:
                case 0x6f:
                case 0x70:
                case 0x71:
                case 0x72:
                case 0x73:
                case 0x74:
                case 0x75:
                case 0x77:
                case 0x78:
                case 0x79:
                case 0x7a:
                case 0x7b:
                case 0x7c:
                case 0x7d:
                case 0x7e:
                case 0x7f:
                    {
                        byte data = registers.get(instruction & 0x07);
                        registers.set((instruction >> 3) & 0x07, data);
                    }
                    break;
                case 0x80: // ADD
                case 0x81:
                case 0x82:
                case 0x83:
                case 0x84:
                case 0x85:
                case 0x86:
                case 0x87:
                    { 
                        byte data = registers.get(instruction & 0x07);
                        int result = data + registers.a;
                        if (result > 255) registers.flags.C = true;
                        else registers.flags.C = false;

                        if (((data & 0xf) + (registers.a & 0xf)) > 15) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);

                        registers.a = (byte)result;
                    }
                    break;
                case 0x88: // ADC
                case 0x89:
                case 0x8a:
                case 0x8b:
                case 0x8c:
                case 0x8d:
                case 0x8e:
                case 0x8f:
                    {
                        byte data = registers.get(instruction & 0x07);
                        int carry = (registers.flags.C) ? 1 : 0;

                        int result = data + registers.a + carry;


                        if (result > 255) registers.flags.C = true;
                        else registers.flags.C = false;

                        if (((data & 0xf) + (registers.a & 0xf) + carry) > 15) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                        registers.a = (byte)result;
                    }
                    break;
                case 0x90: // SUB
                case 0x91:
                case 0x92:
                case 0x93:
                case 0x94:
                case 0x95:
                case 0x96:
                case 0x97:
                    {
                        byte data = registers.get(instruction & 0x07);

                        int result = registers.a - data;


                        if (result < 0) registers.flags.C = true;
                        else registers.flags.C = false;

                        if (((registers.a & 0xf) - (data & 0xf)) < 0) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                        registers.a = (byte)(result & 0xff);
                    }
                    break;
                case 0x98: // SBB
                case 0x99:
                case 0x9a:
                case 0x9b:
                case 0x9c:
                case 0x9d:
                case 0x9e:
                case 0x9f:
                    {
                        byte data = registers.get(instruction & 0x07);
                        int carry = (registers.flags.C) ? 1 : 0;

                        int result = registers.a - data - carry;


                        if (result < 0) registers.flags.C = true;
                        else registers.flags.C = false;

                        if (((registers.a & 0xf) - (data & 0xf) - carry) < 0) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);

                        registers.a = (byte)(result & 0xff);
                    }
                    break;
                case 0xa0: // ANA
                case 0xa1:
                case 0xa2:
                case 0xa3:
                case 0xa4:
                case 0xa5:
                case 0xa6:
                case 0xa7:
                    {
                        byte data = registers.get(instruction & 0x07);
                        int result = data & registers.a;

                        registers.a = (byte)result;

                        registers.flags.C = false;
                        registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                    }
                    break;
                case 0xa8: // XRA
                case 0xa9:
                case 0xaa:
                case 0xab:
                case 0xac:
                case 0xad:
                case 0xae:
                case 0xaf:
                    {
                        byte data = registers.get(instruction & 0x07);
                        int result = data ^ registers.a;

                        registers.a = (byte)result;

                        registers.flags.C = false;
                        registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                    }
                    break;
                case 0xb0: // ORA
                case 0xb1:
                case 0xb2:
                case 0xb3:
                case 0xb4:
                case 0xb5:
                case 0xb6:
                case 0xb7:
                    {
                        byte data = registers.get(instruction & 0x07);
                        int result = data | registers.a;

                        registers.a = (byte)result;

                        registers.flags.C = false;
                        registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                    }
                    break;
                case 0xb8: // CMP
                case 0xb9:
                case 0xba:
                case 0xbb:
                case 0xbc:
                case 0xbd:
                case 0xbe:
                case 0xbf: // CMP
                    {
                        byte data = registers.get(instruction & 0x07);

                        int result = registers.a - data;

                        if (result < 0) registers.flags.C = true;
                        else registers.flags.C = false;

                        if (((registers.a & 0xf) - (data & 0xf)) < 0) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                    }
                    break;
                case 0xc0: // RNZ
                    if (registers.flags.Z == false)
                    {
                        UInt16 data = stack_pop();
                        registers.PC = data;
                        return;
                    }
                    break;
                case 0xc1: // POP B
                    registers.bc = stack_pop();
                    break;
                case 0xc2: // JNZ
                    if (registers.flags.Z==false) {
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xc3: // JMP
                    {
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                case 0xc4: // CNZ
                    if (registers.flags.Z == false)
                    {
                        stack_push((UInt16)(registers.PC+3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xc5: // PUSH B
                    stack_push(registers.bc);
                    break;
                case 0xc6: // ADI d8
                    {
                        byte data = memory[registers.PC+1];
                        int result = data + registers.a;
                        if (result > 255) registers.flags.C = true;
                        else registers.flags.C = false;

                        if (((data & 0xf) + (registers.a & 0xf)) > 15) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);

                        registers.a = (byte)result;
                    }
                    break;
                case 0xc7: // RST 0
                    stack_push(registers.PC);
                    registers.PC = 0x00;
                    return;
                case 0xc8: // RZ
                    if (registers.flags.Z == true)
                    {
                        UInt16 data = stack_pop();
                        registers.PC = data;
                        return;
                    }
                    break;
                case 0xc9: // RET
                    {
                        UInt16 data = stack_pop();
                        registers.PC = data;
                        return;
                    }
                case 0xca: // JZ
                    if (registers.flags.Z == true)
                    {
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xcb: // *JMP
                    {
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                case 0xcc: // CZ
                    if (registers.flags.Z == true)
                    {
                        stack_push((UInt16)(registers.PC + 3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xcd: // call
                    {
                        stack_push((UInt16)(registers.PC + 3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                case 0xce: // ACI
                    {
                        byte data = memory[registers.PC + 1];
                        int carry = (registers.flags.C) ? 1 : 0;

                        int result = data + registers.a + carry;


                        if (result > 255) registers.flags.C = true;
                        else registers.flags.C = false;

                        if (((data & 0xf) + (registers.a & 0xf) + carry) > 15) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                        registers.a = (byte)result;
                    }
                    break;
                case 0xcf: // RST 1
                    stack_push((UInt16)(registers.PC + 3));
                    registers.PC = 0x08;
                    return;
                case 0xd0: // RNC
                    if (registers.flags.C == false)
                    {
                        UInt16 data = stack_pop();
                        registers.PC = data;
                        return;
                    }
                    break;
                case 0xd1: // POP D
                    registers.de = stack_pop();
                    break;
                case 0xd2: //  JNC
                    if (registers.flags.C == false)
                    {
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xd3: // OUT
                    port_set(memory[registers.PC + 1], registers.a);
                    break;
                case 0xd4: // CNC
                    if (registers.flags.C == false)
                    {
                        stack_push((UInt16)(registers.PC + 3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xd5: // PUSH D
                    stack_push(registers.de);
                    break;
                case 0xd6:  // SUI
                    {
                        byte data = memory[registers.PC + 1];

                        int result = registers.a - data;


                        if (result < 0) registers.flags.C = true;
                        else registers.flags.C = false;

                        if (((registers.a & 0xf) - (data & 0xf)) < 0) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                        registers.a = (byte)(result & 0xff);
                    }
                    break;
                case 0xd7: // RST 2
                    stack_push((UInt16)(registers.PC + 3));
                    registers.PC = 0x10;
                    return;
                case 0xd8:
                    if (registers.flags.C == true)
                    {
                        UInt16 data = stack_pop();
                        registers.PC = data;
                        return;
                    }
                    break;
                case 0xd9:
                    {
                        UInt16 data = stack_pop();
                        registers.PC = data;
                        return;
                    }
                case 0xda: // JC
                    if (registers.flags.C == true)
                    {
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xdb: // IN
                    registers.a = port_get(memory[registers.PC + 1]);
                    break;
                case 0xdc: // CC
                    if (registers.flags.C == true)
                    {
                        stack_push((UInt16)(registers.PC + 3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xdd:
                    {
                        stack_push((UInt16)(registers.PC + 3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                case 0xde:  // SBI
                    {
                        byte data = memory[registers.PC + 1];
                        int carry = (registers.flags.C) ? 1 : 0;

                        int result = registers.a - data - carry;


                        if (result < 0) registers.flags.C = true;
                        else registers.flags.C = false;

                        if (((registers.a & 0xf) - (data & 0xf) - carry) < 0) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);

                        registers.a = (byte)(result & 0xff);
                    }
                    break;
                case 0xdf: // RST 3
                    stack_push((UInt16)(registers.PC + 3));
                    registers.PC = 0x18;
                    return;
                case 0xe0: // RPO
                    if (registers.flags.P == false)
                    {
                        UInt16 data = stack_pop();
                        registers.PC = data;
                        return;
                    }
                    break;
                case 0xe1: // POP H
                    registers.hl = stack_pop();
                    break;
                case 0xe2:
                    if (registers.flags.P == false)
                    {
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xe3: // XTHL
                    {
                        UInt16 tmp;
                        tmp = registers.hl;
                        registers.hl = stack_pop();
                        stack_push(tmp);
                    }
                    break;
                case 0xe4:  // CPO
                    if (registers.flags.P == false)
                    {
                        stack_push((UInt16)(registers.PC + 3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xe5: // PUSH H
                    stack_push(registers.hl);
                    break;
                case 0xe6:  // ANI
                    {
                        byte data = memory[registers.PC + 1];
                        int result = data & registers.a;

                        registers.a = (byte)result;

                        registers.flags.C = false;
                        registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                    }
                    break;
                case 0xe7: // RST 4
                    stack_push((UInt16)(registers.PC + 3));
                    registers.PC = 0x20;
                    return;
                case 0xe8: // RPE
                    if (registers.flags.P == true)
                    {
                        UInt16 data = stack_pop();
                        registers.PC = data;
                        return;
                    }
                    break;
                case 0xe9: // PCHL
                    registers.PC = registers.hl;
                    return;
                case 0xea: // JPE
                    if (registers.flags.P == true)
                    {
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xeb: // XCHG
                    {
                        UInt16 tmp = registers.de;
                        registers.de = registers.hl;
                        registers.hl = tmp;
                    }
                    break;
                case 0xec: // CPE
                    if (registers.flags.P == true)
                    {
                        stack_push((UInt16)(registers.PC + 3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xed:
                    {
                        stack_push((UInt16)(registers.PC + 3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                case 0xee:  // XRI
                    {
                        byte data = memory[registers.PC + 1];
                        int result = data ^ registers.a;

                        registers.a = (byte)result;

                        registers.flags.C = false;
                        registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                    }
                    break;
                case 0xef: // RST 5 
                    stack_push((UInt16)(registers.PC + 3));
                    registers.PC = 0x28;
                    return;
                case 0xf0: // RP
                    if (registers.flags.S == false)
                    {
                        UInt16 data = stack_pop();
                        registers.PC = data;
                        return;
                    }
                    break;
                case 0xf1: // POP PSW
                    registers.PSW = stack_pop();
                    break;
                case 0xf2: // JP
                    if (registers.flags.S == false)
                    {
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xf3: // DI
                    break;
                case 0xf4: // CP
                    if (registers.flags.S == false)
                    {
                        stack_push((UInt16)(registers.PC + 3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xf5: // PUSH PSW
                    stack_push(registers.PSW);
                    break;
                case 0xf6: // ORI
                    {
                        byte data = memory[registers.PC + 1];
                        int result = data | registers.a;

                        registers.a = (byte)result;

                        registers.flags.C = false;
                        registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                    }
                    break;
                case 0xf7: // RST 6
                    stack_push((UInt16)(registers.PC + 3));
                    registers.PC = 0x30;
                    return;
                case 0xf8: // RM
                    if (registers.flags.S == true)
                    {
                        UInt16 data = stack_pop();
                        registers.PC = data;
                        return;
                    }
                    break;
                case 0xf9: // SPHL
                    registers.SP = registers.hl;
                    break;
                case 0xfa: // JM
                    if (registers.flags.S == true)
                    {
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xfb: // EI
                    break;
                case 0xfc: // CM
                    if (registers.flags.S == true)
                    {
                        stack_push((UInt16)(registers.PC + 3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                    break;
                case 0xfd: // CALL
                    {
                        stack_push((UInt16)(registers.PC + 3));
                        UInt16 addr = (UInt16)(memory[registers.PC + 1] | (memory[registers.PC + 2] << 8));
                        registers.PC = addr;
                        return;
                    }
                case 0xfe: // CPI
                    {
                        byte data = memory[registers.PC + 1];

                        int result = registers.a - data;


                        if (result < 0) registers.flags.C = true;
                        else registers.flags.C = false;

                        if (((registers.a & 0xf) - (data & 0xf)) < 0) registers.flags.AC = true;
                        else registers.flags.AC = false;

                        if ((result & 0xff) == 0) registers.flags.Z = true;
                        else registers.flags.Z = false;

                        if ((result & 0x80) == 0x80) registers.flags.S = true;
                        else registers.flags.S = false;

                        registers.flags.P = calculate_parity((byte)result);
                    }
                    break;
                case 0xff: // RST 7
                    stack_push((UInt16)(registers.PC + 3));
                    registers.PC = 0x38;
                    return;

                case 0x76: // HLT
                    return;
                default:
                    break;
            }

            registers.PC += (UInt16)ist_length(instruction);
        }

    }


}
