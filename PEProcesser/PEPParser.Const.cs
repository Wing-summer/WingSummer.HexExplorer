namespace PEProcesser
{
    public partial class PEPParser
    {
        public const int IMAGE_NUMBEROF_DIRECTORY_ENTRIES = 16;
        public const int IMAGE_SIZEOF_SHORT_NAME = 8;

        public const uint IMAGE_DOS_SIGNATURE = 0x5A4D;  // MZ
        public const uint IMAGE_NT_SIGNATURE = 0x4550;    // PE00

        public const uint IMAGE_SIZEOF_FILE_HEADER = 20;

        public const ushort IMAGE_NT_OPTIONAL_HDR32_MAGIC = 0x10b;
        public const ushort IMAGE_NT_OPTIONAL_HDR64_MAGIC = 0x20b;
    }
}