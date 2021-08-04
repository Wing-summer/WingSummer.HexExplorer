using System.Collections.Generic;
using System.ComponentModel;
using System.IO.MemoryMappedFiles;

namespace PEProcesser
{
    public partial class PEPParser
    {
        [DefaultValue(null)]
        public string FileName { get; private set; }

        [DefaultValue(false)]
        public bool LoadedFile { get; private set; }

        [DefaultValue(false)]
        public bool IsdotNetFile { get; private set; }

        [DefaultValue(false)]
        public bool Processed { get; private set; }

        public IMAGE_DOS_HEADER IMAGE_DOS_HEADER_ { get; private set; }
        public MemoryMappedViewAccessor ViewAccessor { get { return _viewAccessor; } }
        private MemoryMappedViewAccessor _viewAccessor = null;
        public PEStructData PEData { get { return peData; } }
        private PEStructData peData;
        public bool Is32Bit { get; private set; }

        [DefaultValue(null)]
        public IMAGE_DATA_DIRECTORY[] IMAGE_DATA_DIRECTORIES { get; private set; }

        [DefaultValue(null)]
        public IMAGE_SECTION_HEADER[] IMAGE_SECTION_HEADERS { get { return _SECTION_HEADERS; } }

        private IMAGE_SECTION_HEADER[] _SECTION_HEADERS;

        [DefaultValue(null)]
        public List<ExportTable> ExportTables { get { return exportTables; } }

        private List<ExportTable> exportTables;

        [DefaultValue(null)]
        public List<ImportTable> ImportTables { get { return importTables; } }

        private List<ImportTable> importTables;

        [DefaultValue(null)]
        public List<RelocateTable> RelocateTables { get { return relocateTables; } }

        private List<RelocateTable> relocateTables;

        [DefaultValue(null)]
        public List<ResourceTable> ResourceTables { get { return resourceTables; } }

        private List<ResourceTable> resourceTables;

        [DefaultValue(null)]
        public DotNetMetaInfo DotNetMeta { get { return netMeta; } }

        private DotNetMetaInfo netMeta;

        [DefaultValue(null)]
        public Dictionary<string, STORAGESTREAM> STORAGESTREAMS { get { return iStreams; } }

        private Dictionary<string, STORAGESTREAM> iStreams;
    }
}