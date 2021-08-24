using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HexExplorer
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class ConstInfo
    {
        [DisplayName("BYTE"),ReadOnly(true)]
        public byte? Char { get; set; }

        [DisplayName("short"), ReadOnly(true)]
        public short? Int16 { get; set; } 

        [DisplayName("WORD"), ReadOnly(true)]
        public ushort? UInt16 { get; set; }

        [DisplayName("int"), ReadOnly(true)]
        public int? Int { get; set; }

        [DisplayName("DWORD"), ReadOnly(true)]
        public uint? UInt { get; set; }

        [DisplayName("int64"), ReadOnly(true)]
        public long? Long { get; set; }

        [DisplayName("QWORD"), ReadOnly(true)]
        public ulong? ULong { get; set; }
       
    }
}
