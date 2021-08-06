using System;

namespace PEProcesser
{
    public partial class PEPParser
    {
        public enum ParserError : int
        {
            Success,
            Unvalid,
            FileUnLoaded,
            FileNotExist,
            PEDamaged,
            NullObject,
            UnableWrite
        };

        public enum PEStructType : int
        {
            IMAGE_DOS_HEADER,
            IMAGE_FILE_HEADER,
            IMAGE_NT_HEADERS,
            IMAGE_OPTIONAL_HEADER,
            IMAGE_DATA_DIRECTORY,
            IMAGE_SECTION_HEADER,
            IMAGE_IMPORT_DESCRIPTOR,
            IMAGE_EXPORT_DIRECTORY,
            IMAGE_IMPORT_BY_NAME,
            IMAGE_BASE_RELOCATION,
            IMAGE_RESOURCE_DIRECTORY,
            IMAGE_COR20_HEADER,

            IMAGE_THUNK_DATA,
            IMAGE_DATA_DIRECTORY_Content,
            IMAGE_RESOURCE_DIRECTORY_ENTRY,
            IMAGE_RESOURCE_DATA_ENTRY,
            IMAGE_RESOURCE_DIR_STRING_U,

            IMAGE_DEBUG_DIRECTORY,
            STORAGESIGNATURE,
            STORAGEHEADER,
            STORAGESTREAM,
            MDStreamHeader,
            DotNetModule,
            DotNetTypeRef,
            DotNetTypeDef,
            DotNetField,
            DotNetMethodDef,
            DotNetParam,
            DotNetInterfaceImpl,
            DotNetMemberRef,
            DotNetConstant,
            DotNetCustomAttribute,
            DotNetFieldMarshal,
            DotNetDeclSecurity,
            DotNetClassLayout,
            DotNetFieldLayout,
            DotNetStandAloneSig,
            DotNetEventMap,
            DotNetEvent,
            DotNetPropertyMap,
            DotNetProperty,
            DotNetMethodSemantics,
            DotNetMethodImpl,
            DotNetModuleRef,
            DotNetTypeSpec,
            DotNetImplMap,
            DotNetFieldRVA,
            DotNetAssembly,
            DotNetAssemblyProcessor,
            DotNetAssemblyOS,
            DotNetAssemblyRef,
            DotNetAssemblyRefProcessor,
            DotNetAssemblyRefOS,
            DotNetFile,
            DotNetExportedType,
            DotNetManifestResource,
            DotNetNestedClass,
            DotNetGenericParam,
            DotNetGenericParamConstraint
        }

        public enum DirectoryEntries : int
        {
            IMAGE_DIRECTORY_ENTRY_EXPORT,  // Export Directory
            IMAGE_DIRECTORY_ENTRY_IMPORT, // Import Directory
            IMAGE_DIRECTORY_ENTRY_RESOURCE, // Resource Directory
            IMAGE_DIRECTORY_ENTRY_EXCEPTION, // Exception Directory
            IMAGE_DIRECTORY_ENTRY_SECURITY,// Security Directory
            IMAGE_DIRECTORY_ENTRY_BASERELOC,  // Base Relocation Table
            IMAGE_DIRECTORY_ENTRY_DEBUG,  // Debug Directory

            //      IMAGE_DIRECTORY_ENTRY_COPYRIGHT       7   // (X86 usage)
            IMAGE_DIRECTORY_ENTRY_ARCHITECTURE, // Architecture Specific Data

            IMAGE_DIRECTORY_ENTRY_GLOBALPTR,   // RVA of GP
            IMAGE_DIRECTORY_ENTRY_TLS, // TLS Directory
            IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG, // Load Configuration Directory
            IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT,   // Bound Import Directory in headers
            IMAGE_DIRECTORY_ENTRY_IAT,  // Import Address Table
            IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT, // Delay Load Import Descriptors
            IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR,  // COM Runtime descriptor（.Net Used）
        }

        public enum ResourceType : int
        {
            Cursor = 1,
            Bitmap = 2,
            Icon = 3,
            Menu = 4,
            Dialog = 5,
            String = 6,
            FontDir = 7,
            Font = 8,
            Accelerate = 9,
            RCData = 10,
            MessageTable = 11,
            GroupCursor = 12,
            GroupIcon = 14,
            Verson = 16,
            AniCursor = 21,
            AniIcon = 22,
            Html = 23,
            Manifest = 24,
            Ribbon = 28
        }

        public enum DotNetTables : int
        {
            Module,
            TypeRef,
            TypeDef,
            FiledPtr,
            Filed,
            MethodPtr,
            MethodDef,
            ParamPtr,
            Param,
            MethodImpl,
            MemberRef,
            Constant,
            CustomAttribute,
            FieldMarshal,
            DeclSecurity,
            ClassLayout,
            FieldLayout,
            StandAloneSig,
            EventMap,
            EventPtr,
            Event,
            PropertyMap,
            PropertyPtr,
            Property,
            MethodSemantics,
            Methodimpl,
            ModuleRef,
            TypeSpec,
            ImplMap,
            FiledRVA,
            ENCLog,
            ENCMap,
            AssemblyRef,
            AssemblyProcessor,
            AssemblyOS,
            Assembly,
            AssemblyRefProcessor,
            AssemblyRefOS,
            File,
            ExportedType,
            ManifestResource,
            NestedClass,
            GenericParam,
            MethodSpec,
            GenericParamConstraint
        }

        [Flags]
        public enum ReplacesCorHdrNumericDefines
        {
            // COM+ Header entry point flags.
            COMIMAGE_FLAGS_ILONLY = 0x00000001,

            COMIMAGE_FLAGS_32BITREQUIRED = 0x00000002,
            COMIMAGE_FLAGS_IL_LIBRARY = 0x00000004,
            COMIMAGE_FLAGS_STRONGNAMESIGNED = 0x00000008,
            COMIMAGE_FLAGS_NATIVE_ENTRYPOINT = 0x00000010,
            COMIMAGE_FLAGS_TRACKDEBUGDATA = 0x00010000,
            COMIMAGE_FLAGS_32BITPREFERRED = 0x00020000,

            // Version flags for image.
            COR_VERSION_MAJOR_V2 = 2,

            COR_VERSION_MAJOR = COR_VERSION_MAJOR_V2,
            COR_VERSION_MINOR = 5,
            COR_DELETED_NAME_LENGTH = 8,
            COR_VTABLEGAP_NAME_LENGTH = 8,

            // Maximum size of a NativeType descriptor.
            NATIVE_TYPE_MAX_CB = 1,

            COR_ILMETHOD_SECT_SMALL_MAX_DATASIZE = 0xFF,

            // #defines for the MIH FLAGS
            IMAGE_COR_MIH_METHODRVA = 0x01,

            IMAGE_COR_MIH_EHRVA = 0x02,
            IMAGE_COR_MIH_BASICBLOCK = 0x08,

            // V-table constants
            COR_VTABLE_32BIT = 0x01,          // V-table slots are 32-bits in size.

            COR_VTABLE_64BIT = 0x02,          // V-table slots are 64-bits in size.
            COR_VTABLE_FROM_UNMANAGED = 0x04,          // If set, transition from unmanaged.
            COR_VTABLE_FROM_UNMANAGED_RETAIN_APPDOMAIN = 0x08,  // If set, transition from unmanaged with keeping the current appdomain.
            COR_VTABLE_CALL_MOST_DERIVED = 0x10,          // Call most derived method described by

            // EATJ constants
            IMAGE_COR_EATJ_THUNK_SIZE = 32,            // Size of a jump thunk reserved range.

            // Max name lengths
            //@todo: Change to unlimited name lengths.
            MAX_CLASS_NAME = 1024,

            MAX_PACKAGE_NAME = 1024,
        }

        [Flags]
        public enum CorTypeAttr : uint
        {
            // Use this mask to retrieve the type visibility information.

            tdVisibilityMask = 0x00000007,
            tdNotPublic = 0x00000000,
            // Class is not public scope.

            tdPublic = 0x00000001,
            // Class is public scope.

            tdNestedPublic = 0x00000002,
            // Class is nested with public visibility.

            tdNestedPrivate = 0x00000003,
            // Class is nested with private visibility.

            tdNestedFamily = 0x00000004,
            // Class is nested with family visibility.

            tdNestedAssembly = 0x00000005,
            // Class is nested with assembly visibility.

            tdNestedFamANDAssem = 0x00000006,
            // Class is nested with family and assembly visibility.

            tdNestedFamORAssem = 0x00000007,
            // Class is nested with family or assembly visibility.

            // Use this mask to retrieve class layout information

            tdLayoutMask = 0x00000018,
            tdAutoLayout = 0x00000000,
            // Class fields are auto-laid out

            tdSequentialLayout = 0x00000008,
            // Class fields are laid out sequentially

            tdExplicitLayout = 0x00000010,
            // Layout is supplied explicitly

            // end layout mask

            // Use this mask to retrieve class semantics information.

            tdClassSemanticsMask = 0x00000060,
            tdClass = 0x00000000,
            // Type is a class.

            tdInterface = 0x00000020,
            // Type is an interface.

            // end semantics mask

            // Special semantics in addition to class semantics.

            tdAbstract = 0x00000080,
            // Class is abstract

            tdSealed = 0x00000100,
            // Class is concrete and may not be extended

            tdSpecialName = 0x00000400,
            // Class name is special. Name describes how.

            // Implementation attributes.

            tdImport = 0x00001000,
            // Class / interface is imported

            tdSerializable = 0x00002000,
            // The class is Serializable.

            // Use tdStringFormatMask to retrieve string information for native interop

            tdStringFormatMask = 0x00030000,
            tdAnsiClass = 0x00000000,
            // LPTSTR is interpreted as ANSI in this class

            tdUnicodeClass = 0x00010000,
            // LPTSTR is interpreted as UNICODE

            tdAutoClass = 0x00020000,
            // LPTSTR is interpreted automatically

            tdCustomFormatClass = 0x00030000,
            // A non-standard encoding specified by CustomFormatMask

            tdCustomFormatMask = 0x00C00000,
            // Use this mask to retrieve non-standard encoding

            // information for native interop.

            // The meaning of the values of these 2 bits is unspecified.

            // end string format mask

            tdBeforeFieldInit = 0x00100000,
            // Initialize the class any time before first static field access.

            tdForwarder = 0x00200000,
            // This ExportedType is a type forwarder.

            // Flags reserved for runtime use.

            tdReservedMask = 0x00040800,
            tdRTSpecialName = 0x00000800,
            // Runtime should check name encoding.

            tdHasSecurity = 0x00040000,
            // Class has security associate with it.
        }

        [Flags]
        public enum CorFieldAttr : ushort
        {
            // member access mask - Use this mask to retrieve

            // accessibility information.

            fdFieldAccessMask = 0x0007,
            fdPrivateScope = 0x0000,
            // Member not referenceable.

            fdPrivate = 0x0001,
            // Accessible only by the parent type.

            fdFamANDAssem = 0x0002,
            // Accessible by sub-types only in this Assembly.

            fdAssembly = 0x0003,
            // Accessibly by anyone in the Assembly.

            fdFamily = 0x0004,
            // Accessible only by type and sub-types.

            fdFamORAssem = 0x0005,
            // Accessibly by sub-types anywhere, plus anyone in assembly.

            fdPublic = 0x0006,
            // Accessibly by anyone who has visibility to this scope.

            // end member access mask

            // field contract attributes.

            fdStatic = 0x0010,
            // Defined on type, else per instance.

            fdInitOnly = 0x0020,
            // Field may only be initialized, not written to after init.

            fdLiteral = 0x0040,
            // Value is compile time constant.

            fdNotSerialized = 0x0080,
            // Field does not have to be serialized when type is remoted.

            fdSpecialName = 0x0200,
            // field is special. Name describes how.

            // interop attributes

            fdPinvokeImpl = 0x2000,
            // Implementation is forwarded through pinvoke.

            // Reserved flags for runtime use only.

            fdReservedMask = 0x9500,
            fdRTSpecialName = 0x0400,
            // Runtime(metadata internal APIs) should check name encoding.

            fdHasFieldMarshal = 0x1000,
            // Field has marshalling information.

            fdHasDefault = 0x8000,
            // Field has default.

            fdHasFieldRVA = 0x0100,
            // Field has RVA.
        }

        [Flags]
        public enum CorParamAttr
        {
            pdIn = 0x0001,     // Param is [In]

            pdOut = 0x0002,     // Param is [out]

            pdOptional = 0x0010,     // Param is optional

            // Reserved flags for Runtime use only.

            pdReservedMask = 0xf000,
            pdHasDefault = 0x1000,     // Param has default value.

            pdHasFieldMarshal = 0x2000,     // Param has FieldMarshal.

            pdUnused = 0xcfe0,
        }

        [Flags]
        public enum CorEventAttr
        {
            evSpecialName = 0x0200,
            // event is special. Name describes how.

            // Reserved flags for Runtime use only.

            evReservedMask = 0x0400,
            evRTSpecialName = 0x0400,
            // Runtime(metadata internal APIs) should check name encoding.
        }
    }
}