// ATMCD64CS, Version=2.104.30084.0, Culture=neutral, PublicKeyToken=null
// ATMCD64CS.AndorSDK
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;

namespace ATMCD64CS
{
    public static class AndorSDK
    {
        public enum AT_VersionInfoId
        {
            AT_SDKVersion = 1073741824,
            AT_DeviceDriverVersion
        }

        public struct AndorCapabilities
        {
            public uint ulSize;

            public uint ulAcqModes;

            public uint ulReadModes;

            public uint ulTriggerModes;

            public uint ulCameraType;

            public uint ulPixelMode;

            public uint ulSetFunctions;

            public uint ulGetFunctions;

            public uint ulFeatures;

            public uint ulPCICard;

            public uint ulEMGainCapability;

            public uint ulFTReadModes;

            public uint ulFeatures2;
        }

        public struct ColorDemosaicInfo
        {
            public int iX;

            public int iY;

            public int iAlgorithm;

            public int iXPhase;

            public int iYPhase;

            public int iBackground;
        }

        public struct WhiteBalanceInfo
        {
            public int iSize;

            public int iX;

            public int iY;

            public int iAlgorithm;

            public int iROI_left;

            public int iROI_right;

            public int iROI_top;

            public int iROI_bottom;

            public int iOperation;
        }

        public struct ReadMode
        {
            public const int Full_Vertical_Binning = 0;
            public const int Multi_Track = 1;
            public const int Random_Track = 2;
            public const int Single_Track = 3;
            public const int Image = 4;
        }

        public struct AcquisitionMode
        {
            public const int Single_Scan = 1;
            public const int Accumulate = 2;
            public const int Kinetics = 3;
            public const int Fast_Kinetics = 4;
            public const int Runt_Till_Abort = 5;
        }

        public struct TriggerMode
        {
            public const int Internal = 0;
            public const int External = 1;
            public const int External_Start = 6;
            public const int External_Exposure = 7;
            public const int Software_Trigger = 10;
            public const int External_Charge_Shifting = 12;
        }

        public struct SYSTEMTIME
        {
            [MarshalAs(UnmanagedType.U2)]
            public short Year;

            [MarshalAs(UnmanagedType.U2)]
            public short Month;

            [MarshalAs(UnmanagedType.U2)]
            public short DayOfWeek;

            [MarshalAs(UnmanagedType.U2)]
            public short Day;

            [MarshalAs(UnmanagedType.U2)]
            public short Hour;

            [MarshalAs(UnmanagedType.U2)]
            public short Minute;

            [MarshalAs(UnmanagedType.U2)]
            public short Second;

            [MarshalAs(UnmanagedType.U2)]
            public short Milliseconds;
        }

        private const string dllPath = "atmcd64d.dll";

        private const int iStringLength = 2048;

        public const uint DRV_ERROR_CODES = 20001u;

        public const uint DRV_SUCCESS = 20002u;

        public const uint DRV_VXDNOTINSTALLED = 20003u;

        public const uint DRV_ERROR_SCAN = 20004u;

        public const uint DRV_ERROR_CHECK_SUM = 20005u;

        public const uint DRV_ERROR_FILELOAD = 20006u;

        public const uint DRV_UNKNOWN_FUNCTION = 20007u;

        public const uint DRV_ERROR_VXD_INIT = 20008u;

        public const uint DRV_ERROR_ADDRESS = 20009u;

        public const uint DRV_ERROR_PAGELOCK = 20010u;

        public const uint DRV_ERROR_PAGEUNLOCK = 20011u;

        public const uint DRV_ERROR_BOARDTEST = 20012u;

        public const uint DRV_ERROR_ACK = 20013u;

        public const uint DRV_ERROR_UP_FIFO = 20014u;

        public const uint DRV_ERROR_PATTERN = 20015u;

        public const uint DRV_ACQUISITION_ERRORS = 20017u;

        public const uint DRV_ACQ_BUFFER = 20018u;

        public const uint DRV_ACQ_DOWNFIFO_FULL = 20019u;

        public const uint DRV_PROC_UNKONWN_INSTRUCTION = 20020u;

        public const uint DRV_ILLEGAL_OP_CODE = 20021u;

        public const uint DRV_KINETIC_TIME_NOT_MET = 20022u;

        public const uint DRV_ACCUM_TIME_NOT_MET = 20023u;

        public const uint DRV_NO_NEW_DATA = 20024u;

        public const uint DRV_PCI_DMA_FAIL = 20025u;

        public const uint DRV_SPOOLERROR = 20026u;

        public const uint DRV_SPOOLSETUPERROR = 20027u;

        public const uint DRV_FILESIZELIMITERROR = 20028u;

        public const uint DRV_ERROR_FILESAVE = 20029u;

        public const uint DRV_TEMPERATURE_CODES = 20033u;

        public const uint DRV_TEMPERATURE_OFF = 20034u;

        public const uint DRV_TEMPERATURE_NOT_STABILIZED = 20035u;

        public const uint DRV_TEMPERATURE_STABILIZED = 20036u;

        public const uint DRV_TEMPERATURE_NOT_REACHED = 20037u;

        public const uint DRV_TEMPERATURE_OUT_RANGE = 20038u;

        public const uint DRV_TEMPERATURE_NOT_SUPPORTED = 20039u;

        public const uint DRV_TEMPERATURE_DRIFT = 20040u;

        public const uint DRV_TEMP_CODES = 20033u;

        public const uint DRV_TEMP_OFF = 20034u;

        public const uint DRV_TEMP_NOT_STABILIZED = 20035u;

        public const uint DRV_TEMP_STABILIZED = 20036u;

        public const uint DRV_TEMP_NOT_REACHED = 20037u;

        public const uint DRV_TEMP_OUT_RANGE = 20038u;

        public const uint DRV_TEMP_NOT_SUPPORTED = 20039u;

        public const uint DRV_TEMP_DRIFT = 20040u;

        public const uint DRV_GENERAL_ERRORS = 20049u;

        public const uint DRV_INVALID_AUX = 20050u;

        public const uint DRV_COF_NOTLOADED = 20051u;

        public const uint DRV_FPGAPROG = 20052u;

        public const uint DRV_FLEXERROR = 20053u;

        public const uint DRV_GPIBERROR = 20054u;

        public const uint DRV_EEPROMVERSIONERROR = 20055u;

        public const uint DRV_DATATYPE = 20064u;

        public const uint DRV_DRIVER_ERRORS = 20065u;

        public const uint DRV_P1INVALID = 20066u;

        public const uint DRV_P2INVALID = 20067u;

        public const uint DRV_P3INVALID = 20068u;

        public const uint DRV_P4INVALID = 20069u;

        public const uint DRV_INIERROR = 20070u;

        public const uint DRV_COFERROR = 20071u;

        public const uint DRV_ACQUIRING = 20072u;

        public const uint DRV_IDLE = 20073u;

        public const uint DRV_TEMPCYCLE = 20074u;

        public const uint DRV_NOT_INITIALIZED = 20075u;

        public const uint DRV_P5INVALID = 20076u;

        public const uint DRV_P6INVALID = 20077u;

        public const uint DRV_INVALID_MODE = 20078u;

        public const uint DRV_INVALID_FILTER = 20079u;

        public const uint DRV_I2CERRORS = 20080u;

        public const uint DRV_I2CDEVNOTFOUND = 20081u;

        public const uint DRV_I2CTIMEOUT = 20082u;

        public const uint DRV_P7INVALID = 20083u;

        public const uint DRV_P8INVALID = 20084u;

        public const uint DRV_P9INVALID = 20085u;

        public const uint DRV_P10INVALID = 20086u;

        public const uint DRV_P11INVALID = 20087u;

        public const uint DRV_USBERROR = 20089u;

        public const uint DRV_IOCERROR = 20090u;

        public const uint DRV_VRMVERSIONERROR = 20091u;

        public const uint DRV_GATESTEPERROR = 20092u;

        public const uint DRV_USB_INTERRUPT_ENDPOINT_ERROR = 20093u;

        public const uint DRV_RANDOM_TRACK_ERROR = 20094u;

        public const uint DRV_INVALID_TRIGGER_MODE = 20095u;

        public const uint DRV_LOAD_FIRMWARE_ERROR = 20096u;

        public const uint DRV_DIVIDE_BY_ZERO_ERROR = 20097u;

        public const uint DRV_INVALID_RINGEXPOSURES = 20098u;

        public const uint DRV_BINNING_ERROR = 20099u;

        public const uint DRV_INVALID_AMPLIFIER = 20100u;

        public const uint DRV_INVALID_COUNTCONVERT_MODE = 20101u;

        public const uint DRV_USB_INTERRUPT_ENDPOINT_TIMEOUT = 20102u;

        public const uint DRV_ERROR_NOCAMERA = 20990u;

        public const uint DRV_NOT_SUPPORTED = 20991u;

        public const uint DRV_NOT_AVAILABLE = 20992u;

        public const uint DRV_ERROR_MAP = 20115u;

        public const uint DRV_ERROR_UNMAP = 20116u;

        public const uint DRV_ERROR_MDL = 20117u;

        public const uint DRV_ERROR_UNMDL = 20118u;

        public const uint DRV_ERROR_BUFFSIZE = 20119u;

        public const uint DRV_ERROR_NOHANDLE = 20121u;

        public const uint DRV_GATING_NOT_AVAILABLE = 20130u;

        public const uint DRV_FPGA_VOLTAGE_ERROR = 20131u;

        public const uint DRV_OW_CMD_FAIL = 20150u;

        public const uint DRV_OWMEMORY_BAD_ADDR = 20151u;

        public const uint DRV_OWCMD_NOT_AVAILABLE = 20152u;

        public const uint DRV_OW_NO_SLAVES = 20153u;

        public const uint DRV_OW_NOT_INITIALIZED = 20154u;

        public const uint DRV_OW_ERROR_SLAVE_NUM = 20155u;

        public const uint DRV_MSTIMINGS_ERROR = 20156u;

        public const uint DRV_OA_NULL_ERROR = 20173u;

        public const uint DRV_OA_PARSE_DTD_ERROR = 20174u;

        public const uint DRV_OA_DTD_VALIDATE_ERROR = 20175u;

        public const uint DRV_OA_FILE_ACCESS_ERROR = 20176u;

        public const uint DRV_OA_FILE_DOES_NOT_EXIST = 20177u;

        public const uint DRV_OA_XML_INVALID_OR_NOT_FOUND_ERROR = 20178u;

        public const uint DRV_OA_PRESET_FILE_NOT_LOADED = 20179u;

        public const uint DRV_OA_USER_FILE_NOT_LOADED = 20180u;

        public const uint DRV_OA_PRESET_AND_USER_FILE_NOT_LOADED = 20181u;

        public const uint DRV_OA_INVALID_FILE = 20182u;

        public const uint DRV_OA_FILE_HAS_BEEN_MODIFIED = 20183u;

        public const uint DRV_OA_BUFFER_FULL = 20184u;

        public const uint DRV_OA_INVALID_STRING_LENGTH = 20185u;

        public const uint DRV_OA_INVALID_CHARS_IN_NAME = 20186u;

        public const uint DRV_OA_INVALID_NAMING = 20187u;

        public const uint DRV_OA_GET_CAMERA_ERROR = 20188u;

        public const uint DRV_OA_MODE_ALREADY_EXISTS = 20189u;

        public const uint DRV_OA_STRINGS_NOT_EQUAL = 20190u;

        public const uint DRV_OA_NO_USER_DATA = 20191u;

        public const uint DRV_OA_VALUE_NOT_SUPPORTED = 20192u;

        public const uint DRV_OA_MODE_DOES_NOT_EXIST = 20193u;

        public const uint DRV_OA_CAMERA_NOT_SUPPORTED = 20194u;

        public const uint DRV_OA_FAILED_TO_GET_MODE = 20195u;

        public const uint DRV_OA_CAMERA_NOT_AVAILABLE = 20196u;

        public const uint DRV_PROCESSING_FAILED = 20211u;

        public const uint AC_ACQMODE_SINGLE = 1u;

        public const uint AC_ACQMODE_VIDEO = 2u;

        public const uint AC_ACQMODE_ACCUMULATE = 4u;

        public const uint AC_ACQMODE_KINETIC = 8u;

        public const uint AC_ACQMODE_FRAMETRANSFER = 16u;

        public const uint AC_ACQMODE_FASTKINETICS = 32u;

        public const uint AC_ACQMODE_OVERLAP = 64u;

        public const uint AC_ACQMODE_TDI = 128u;

        public const uint AC_READMODE_FULLIMAGE = 1u;

        public const uint AC_READMODE_SUBIMAGE = 2u;

        public const uint AC_READMODE_SINGLETRACK = 4u;

        public const uint AC_READMODE_FVB = 8u;

        public const uint AC_READMODE_MULTITRACK = 16u;

        public const uint AC_READMODE_RANDOMTRACK = 32u;

        public const uint AC_READMODE_MULTITRACKSCAN = 64u;

        public const uint AC_TRIGGERMODE_INTERNAL = 1u;

        public const uint AC_TRIGGERMODE_EXTERNAL = 2u;

        public const uint AC_TRIGGERMODE_EXTERNAL_FVB_EM = 4u;

        public const uint AC_TRIGGERMODE_CONTINUOUS = 8u;

        public const uint AC_TRIGGERMODE_EXTERNALSTART = 16u;

        public const uint AC_TRIGGERMODE_EXTERNALEXPOSURE = 32u;

        public const uint AC_TRIGGERMODE_INVERTED = 64u;

        public const uint AC_TRIGGERMODE_EXTERNAL_CHARGESHIFTING = 128u;

        public const uint AC_TRIGGERMODE_BULB = 32u;

        public const uint AC_CAMERATYPE_PDA = 0u;

        public const uint AC_CAMERATYPE_IXON = 1u;

        public const uint AC_CAMERATYPE_ICCD = 2u;

        public const uint AC_CAMERATYPE_EMCCD = 3u;

        public const uint AC_CAMERATYPE_CCD = 4u;

        public const uint AC_CAMERATYPE_ISTAR = 5u;

        public const uint AC_CAMERATYPE_VIDEO = 6u;

        public const uint AC_CAMERATYPE_IDUS = 7u;

        public const uint AC_CAMERATYPE_NEWTON = 8u;

        public const uint AC_CAMERATYPE_SURCAM = 9u;

        public const uint AC_CAMERATYPE_USBICCD = 10u;

        public const uint AC_CAMERATYPE_LUCA = 11u;

        public const uint AC_CAMERATYPE_RESERVED = 12u;

        public const uint AC_CAMERATYPE_IKON = 13u;

        public const uint AC_CAMERATYPE_INGAAS = 14u;

        public const uint AC_CAMERATYPE_IVAC = 15u;

        public const uint AC_CAMERATYPE_UNPROGRAMMED = 16u;

        public const uint AC_CAMERATYPE_CLARA = 17u;

        public const uint AC_CAMERATYPE_USBISTAR = 18u;

        public const uint AC_CAMERATYPE_SIMCAM = 19u;

        public const uint AC_CAMERATYPE_NEO = 20u;

        public const uint AC_CAMERATYPE_IXONULTRA = 21u;

        public const uint AC_CAMERATYPE_VOLMOS = 22u;

        public const uint AC_CAMERATYPE_IVAC_CCD = 23u;

        public const uint AC_CAMERATYPE_ASPEN = 24u;

        public const uint AC_CAMERATYPE_ASCENT = 25u;

        public const uint AC_CAMERATYPE_ALTA = 26u;

        public const uint AC_CAMERATYPE_ALTAF = 27u;

        public const uint AC_CAMERATYPE_IKONXL = 28u;

        public const uint AC_CAMERATYPE_RES1 = 29u;

        public const uint AC_CAMERATYPE_ISTAR_SCMOS = 30u;

        public const uint AC_CAMERATYPE_IKONLR = 31u;

        public const uint AC_PIXELMODE_8BIT = 1u;

        public const uint AC_PIXELMODE_14BIT = 2u;

        public const uint AC_PIXELMODE_16BIT = 4u;

        public const uint AC_PIXELMODE_32BIT = 8u;

        public const uint AC_PIXELMODE_MONO = 0u;

        public const uint AC_PIXELMODE_RGB = 65536u;

        public const uint AC_PIXELMODE_CMY = 131072u;

        public const uint AC_SETFUNCTION_VREADOUT = 1u;

        public const uint AC_SETFUNCTION_HREADOUT = 2u;

        public const uint AC_SETFUNCTION_TEMPERATURE = 4u;

        public const uint AC_SETFUNCTION_MCPGAIN = 8u;

        public const uint AC_SETFUNCTION_EMCCDGAIN = 16u;

        public const uint AC_SETFUNCTION_BASELINECLAMP = 32u;

        public const uint AC_SETFUNCTION_VSAMPLITUDE = 64u;

        public const uint AC_SETFUNCTION_HIGHCAPACITY = 128u;

        public const uint AC_SETFUNCTION_BASELINEOFFSET = 256u;

        public const uint AC_SETFUNCTION_PREAMPGAIN = 512u;

        public const uint AC_SETFUNCTION_CROPMODE = 1024u;

        public const uint AC_SETFUNCTION_DMAPARAMETERS = 2048u;

        public const uint AC_SETFUNCTION_HORIZONTALBIN = 4096u;

        public const uint AC_SETFUNCTION_MULTITRACKHRANGE = 8192u;

        public const uint AC_SETFUNCTION_RANDOMTRACKNOGAPS = 16384u;

        public const uint AC_SETFUNCTION_EMADVANCED = 32768u;

        public const uint AC_SETFUNCTION_GATEMODE = 65536u;

        public const uint AC_SETFUNCTION_DDGTIMES = 131072u;

        public const uint AC_SETFUNCTION_IOC = 262144u;

        public const uint AC_SETFUNCTION_INTELLIGATE = 524288u;

        public const uint AC_SETFUNCTION_INSERTION_DELAY = 1048576u;

        public const uint AC_SETFUNCTION_GATESTEP = 2097152u;

        public const uint AC_SETFUNCTION_GATEDELAYSTEP = 2097152u;

        public const uint AC_SETFUNCTION_TRIGGERTERMINATION = 4194304u;

        public const uint AC_SETFUNCTION_EXTENDEDNIR = 8388608u;

        public const uint AC_SETFUNCTION_SPOOLTHREADCOUNT = 16777216u;

        public const uint AC_SETFUNCTION_REGISTERPACK = 33554432u;

        public const uint AC_SETFUNCTION_PRESCANS = 67108864u;

        public const uint AC_SETFUNCTION_GATEWIDTHSTEP = 134217728u;

        public const uint AC_SETFUNCTION_EXTENDED_CROP_MODE = 268435456u;

        public const uint AC_SETFUNCTION_SUPERKINETICS = 536870912u;

        public const uint AC_SETFUNCTION_TIMESCAN = 1073741824u;

        public const uint AC_SETFUNCTION_CROPMODETYPE = 2147483648u;

        public const uint AC_SETFUNCTION_GAIN = 8u;

        public const uint AC_SETFUNCTION_ICCDGAIN = 8u;

        public const uint AC_GETFUNCTION_TEMPERATURE = 1u;

        public const uint AC_GETFUNCTION_TARGETTEMPERATURE = 2u;

        public const uint AC_GETFUNCTION_TEMPERATURERANGE = 4u;

        public const uint AC_GETFUNCTION_DETECTORSIZE = 8u;

        public const uint AC_GETFUNCTION_MCPGAIN = 16u;

        public const uint AC_GETFUNCTION_EMCCDGAIN = 32u;

        public const uint AC_GETFUNCTION_HVFLAG = 64u;

        public const uint AC_GETFUNCTION_GATEMODE = 128u;

        public const uint AC_GETFUNCTION_DDGTIMES = 256u;

        public const uint AC_GETFUNCTION_IOC = 512u;

        public const uint AC_GETFUNCTION_INTELLIGATE = 1024u;

        public const uint AC_GETFUNCTION_INSERTION_DELAY = 2048u;

        public const uint AC_GETFUNCTION_GATESTEP = 4096u;

        public const uint AC_GETFUNCTION_GATEDELAYSTEP = 4096u;

        public const uint AC_GETFUNCTION_PHOSPHORSTATUS = 8192u;

        public const uint AC_GETFUNCTION_MCPGAINTABLE = 16384u;

        public const uint AC_GETFUNCTION_BASELINECLAMP = 32768u;

        public const uint AC_GETFUNCTION_GATEWIDTHSTEP = 65536u;

        public const uint AC_GETFUNCTION_GAIN = 16u;

        public const uint AC_GETFUNCTION_ICCDGAIN = 16u;

        public const uint AC_FEATURES_POLLING = 1u;

        public const uint AC_FEATURES_EVENTS = 2u;

        public const uint AC_FEATURES_SPOOLING = 4u;

        public const uint AC_FEATURES_SHUTTER = 8u;

        public const uint AC_FEATURES_SHUTTEREX = 16u;

        public const uint AC_FEATURES_EXTERNAL_I2C = 32u;

        public const uint AC_FEATURES_SATURATIONEVENT = 64u;

        public const uint AC_FEATURES_FANCONTROL = 128u;

        public const uint AC_FEATURES_MIDFANCONTROL = 256u;

        public const uint AC_FEATURES_TEMPERATUREDURINGACQUISITION = 512u;

        public const uint AC_FEATURES_KEEPCLEANCONTROL = 1024u;

        public const uint AC_FEATURES_DDGLITE = 2048u;

        public const uint AC_FEATURES_FTEXTERNALEXPOSURE = 4096u;

        public const uint AC_FEATURES_KINETICEXTERNALEXPOSURE = 8192u;

        public const uint AC_FEATURES_DACCONTROL = 16384u;

        public const uint AC_FEATURES_METADATA = 32768u;

        public const uint AC_FEATURES_IOCONTROL = 65536u;

        public const uint AC_FEATURES_PHOTONCOUNTING = 131072u;

        public const uint AC_FEATURES_COUNTCONVERT = 262144u;

        public const uint AC_FEATURES_DUALMODE = 524288u;

        public const uint AC_FEATURES_OPTACQUIRE = 1048576u;

        public const uint AC_FEATURES_REALTIMESPURIOUSNOISEFILTER = 2097152u;

        public const uint AC_FEATURES_POSTPROCESSSPURIOUSNOISEFILTER = 4194304u;

        public const uint AC_FEATURES_DUALPREAMPGAIN = 8388608u;

        public const uint AC_FEATURES_DEFECT_CORRECTION = 16777216u;

        public const uint AC_FEATURES_STARTOFEXPOSURE_EVENT = 33554432u;

        public const uint AC_FEATURES_ENDOFEXPOSURE_EVENT = 67108864u;

        public const uint AC_FEATURES_CAMERALINK = 134217728u;

        public const uint AC_FEATURES_FIFOFULL_EVENT = 268435456u;

        public const uint AC_FEATURES_SENSOR_PORT_CONFIGURATION = 536870912u;

        public const uint AC_FEATURES_SENSOR_COMPENSATION = 1073741824u;

        public const uint AC_FEATURES_IRIG_SUPPORT = 2147483648u;

        public const uint AC_EMGAIN_8BIT = 1u;

        public const uint AC_EMGAIN_12BIT = 2u;

        public const uint AC_EMGAIN_LINEAR12 = 4u;

        public const uint AC_EMGAIN_REAL12 = 8u;

        public const uint AC_FEATURES2_ESD_EVENTS = 1u;

        public const uint AC_FEATURES2_DUAL_PORT_CONFIGURATION = 2u;

        public const int ACQMODE_SINGLESCAN = 1;

        public const int ACQMODE_ACCUMULATE = 2;

        public const int ACQMODE_KINETICS = 3;

        public const int ACQMODE_FASTKINETICS = 4;

        public const int ACQMODE_RUNTILLABORT = 5;

        public const int READMODE_FVB = 0;

        public const int READMODE_MULTITRACK = 1;

        public const int READMODE_RANDOMTRACK = 2;

        public const int READMODE_SINGLETRACK = 3;

        public const int READMODE_IMAGE = 4;

        public const int SHUTTERTYPE_LOW = 0;

        public const int SHUTTERTYPE_HIGH = 1;

        public const int SHUTTERMODE_AUTO = 0;

        public const int SHUTTERMODE_OPEN = 1;

        public const int SHUTTERMODE_CLOSE = 2;

        public const int SETNEXTADDRESSMODE_VIRTUALADDRESS = 0;

        public const int SETNEXTADDRESSMODE_PHYSICALADDRESS = 1;

        public const int STORAGEMODE_RAM = 0;

        public const int STORAGEMODE_MEMORY = 1;

        public const int TRIGGERMODE_INTERNAL = 0;

        public const int TRIGGERMODE_EXTERNAL = 1;

        public const int TRIGGERMODE_EXTERNALSTART = 6;

        public const int TRIGGERMODE_EXTERNALEXPOSURE = 7;

        public const int TRIGGERMODE_EXTERNAL_FVB_EM = 9;

        public const int TRIGGERMODE_SOFTWARE = 10;

        public const int FRAMETRANSFERMODE_OFF = 0;

        public const int FRAMETRANSFERMODE_ON = 1;

        [DllImport("atmcd64d.dll", EntryPoint = "AbortAcquisition")]
        private static extern uint AbortAcquisition_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint AbortAcquisition()
        {
            return AbortAcquisition_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "CancelWait")]
        private static extern uint CancelWait_cs();

        public static uint CancelWait()
        {
            return CancelWait_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "CoolerOFF")]
        private static extern uint CoolerOFF_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint CoolerOFF()
        {
            return CoolerOFF_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "CoolerON")]
        private static extern uint CoolerON_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint CoolerON()
        {
            return CoolerON_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "DemosaicImage")]
        private unsafe static extern uint DemosaicImage_cs(ushort* _input, ushort* _red, ushort* _green, ushort* _blue, ColorDemosaicInfo* _info);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint DemosaicImage(ushort[] _input, ushort[] _red, ushort[] _green, ushort[] _blue, ref ColorDemosaicInfo _info)
        {
            uint result;
            ColorDemosaicInfo colorDemosaicInfo = default(ColorDemosaicInfo);
            fixed (ushort* input = _input)
            {
                fixed (ushort* red = _red)
                {
                    fixed (ushort* green = _green)
                    {
                        fixed (ushort* blue = _blue)
                        {
                            result = DemosaicImage_cs(input, red, green, blue, &colorDemosaicInfo);
                        }
                    }
                }
            }
            _info = colorDemosaicInfo;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "EnableKeepCleans")]
        private static extern uint EnableKeepCleans_cs(int iMode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint EnableKeepCleans(int iMode)
        {
            return EnableKeepCleans_cs(iMode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "EnableSensorCompensation")]
        private static extern uint EnableSensorCompensation_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint EnableSensorCompensation(int mode)
        {
            return EnableSensorCompensation_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "FreeInternalMemory")]
        private static extern uint FreeInternalMemory_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint FreeInternalMemory()
        {
            return FreeInternalMemory_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetAcquiredData")]
        private unsafe static extern uint GetAcquiredData_cs(int* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public  unsafe static uint GetAcquiredData(int[] array, uint size)
        {
            uint acquiredData_cs;
            fixed (int* array2 = array)
            {
                acquiredData_cs = GetAcquiredData_cs(array2, size);
            }
            return acquiredData_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetAcquiredData16")]
        private unsafe static extern uint GetAcquiredData16_cs(ushort* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetAcquiredData16(ushort[] array, uint size)
        {
            uint acquiredData16_cs;
            fixed (ushort* array2 = array)
            {
                acquiredData16_cs = GetAcquiredData16_cs(array2, size);
            }
            return acquiredData16_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetAcquiredFloatData")]
        private unsafe static extern uint GetAcquiredFloatData_cs(float* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetAcquiredFloatData(float[] array, uint size)
        {
            uint acquiredFloatData_cs;
            fixed (float* array2 = array)
            {
                acquiredFloatData_cs = GetAcquiredFloatData_cs(array2, size);
            }
            return acquiredFloatData_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetAcquisitionProgress")]
        private unsafe static extern uint GetAcquisitionProgress_cs(int* acc, int* series);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetAcquisitionProgress(ref int acc, ref int series)
        {
            int num = default(int);
            int num2 = default(int);
            uint acquisitionProgress_cs = GetAcquisitionProgress_cs(&num, &num2);
            acc = num;
            series = num2;
            return acquisitionProgress_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetAcquisitionTimings")]
        private unsafe static extern uint GetAcquisitionTimings_cs(float* exposure, float* accumulate, float* kinetic);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetAcquisitionTimings(ref float exposure, ref float accumulate, ref float kinetic)
        {
            float num = default(float);
            float num2 = default(float);
            float num3 = default(float);
            uint acquisitionTimings_cs = GetAcquisitionTimings_cs(&num, &num2, &num3);
            exposure = num;
            accumulate = num2;
            kinetic = num3;
            return acquisitionTimings_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetAdjustedRingExposureTimes")]
        private unsafe static extern uint GetAdjustedRingExposureTimes_cs(int _inumTimes, float* _fptimes);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetAdjustedRingExposureTimes(int _inumTimes, float[] _fptimes)
        {
            uint adjustedRingExposureTimes_cs;
            fixed (float* fptimes = _fptimes)
            {
                adjustedRingExposureTimes_cs = GetAdjustedRingExposureTimes_cs(_inumTimes, fptimes);
            }
            return adjustedRingExposureTimes_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetAllDMAData")]
        private unsafe static extern uint GetAllDMAData_cs(int* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetAllDMAData(int[] array, uint size)
        {
            uint allDMAData_cs;
            fixed (int* array2 = array)
            {
                allDMAData_cs = GetAllDMAData_cs(array2, size);
            }
            return allDMAData_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetAmpDesc")]
        private unsafe static extern uint GetAmpDesc_cs(int index, sbyte* name, int len);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetAmpDesc(int index, ref string name, int len)
        {
            sbyte[] array = new sbyte[len];
            uint ampDesc_cs;
            fixed (sbyte* name2 = array)
            {
                ampDesc_cs = GetAmpDesc_cs(index, name2, len);
            }
            for (int i = 0; i < 2048 && array[i] != 0; i++)
            {
                name += (char)array[i];
            }
            return ampDesc_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetAmpMaxSpeed")]
        private unsafe static extern uint GetAmpMaxSpeed_cs(int index, float* speed);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetAmpMaxSpeed(int index, ref float speed)
        {
            float num = default(float);
            uint ampMaxSpeed_cs = GetAmpMaxSpeed_cs(index, &num);
            speed = num;
            return ampMaxSpeed_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetAvailableCameras")]
        private unsafe static extern uint GetAvailableCameras_cs(int* totalCameras);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetAvailableCameras(ref int totalCameras)
        {
            int num = default(int);
            uint availableCameras_cs = GetAvailableCameras_cs(&num);
            totalCameras = num;
            return availableCameras_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetBackground")]
        private unsafe static extern uint GetBackground_cs(int* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetBackground(int[] array, uint size)
        {
            uint background_cs;
            fixed (int* array2 = array)
            {
                background_cs = GetBackground_cs(array2, size);
            }
            return background_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetBaselineClamp")]
        private unsafe static extern uint GetBaselineClamp_cs(int* state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetBaselineClamp(ref int state)
        {
            int num = default(int);
            uint baselineClamp_cs = GetBaselineClamp_cs(&num);
            state = num;
            return baselineClamp_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetBitDepth")]
        private unsafe static extern uint GetBitDepth_cs(int channel, int* depth);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetBitDepth(int channel, ref int depth)
        {
            int num = default(int);
            uint bitDepth_cs = GetBitDepth_cs(channel, &num);
            depth = num;
            return bitDepth_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetBitsPerPixel")]
        private unsafe static extern uint GetBitsPerPixel_cs(int readout_index, int index, int* value);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetBitsPerPixel(int readout_index, int index, ref int value)
        {
            int num = default(int);
            uint bitsPerPixel_cs = GetBitsPerPixel_cs(readout_index, index, &num);
            value = num;
            return bitsPerPixel_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetCameraEventStatus")]
        private unsafe static extern uint GetCameraEventStatus_cs(int* cam_status);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetCameraEventStatus(ref int cam_status)
        {
            int num = default(int);
            uint cameraEventStatus_cs = GetCameraEventStatus_cs(&num);
            cam_status = num;
            return cameraEventStatus_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetESDEventStatus")]
        private unsafe static extern uint GetESDEventStatus_cs(int* cam_status);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetESDEventStatus(ref int cam_status)
        {
            int num = default(int);
            uint eSDEventStatus_cs = GetESDEventStatus_cs(&num);
            cam_status = num;
            return eSDEventStatus_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetCameraHandle")]
        private unsafe static extern uint GetCameraHandle_cs(int cameraIndex, int* cameraHandle);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetCameraHandle(int cameraIndex, ref int cameraHandle)
        {
            int num = default(int);
            uint cameraHandle_cs = GetCameraHandle_cs(cameraIndex, &num);
            cameraHandle = num;
            return cameraHandle_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetCameraInformation")]
        private unsafe static extern uint GetCameraInformation_cs(int index, int* information);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetCameraInformation(int index, ref int information)
        {
            int num = default(int);
            uint cameraInformation_cs = GetCameraInformation_cs(index, &num);
            information = num;
            return cameraInformation_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetCameraSerialNumber")]
        private unsafe static extern uint GetCameraSerialNumber_cs(int* number);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetCameraSerialNumber(ref int number)
        {
            int num = default(int);
            uint cameraSerialNumber_cs = GetCameraSerialNumber_cs(&num);
            number = num;
            return cameraSerialNumber_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetCapabilities")]
        private unsafe static extern uint GetCapabilities_cs(AndorCapabilities* caps);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetCapabilities(ref AndorCapabilities caps)
        {
            AndorCapabilities andorCapabilities = default(AndorCapabilities);
            andorCapabilities.ulSize = caps.ulSize;
            uint capabilities_cs = GetCapabilities_cs(&andorCapabilities);
            caps = andorCapabilities;
            return capabilities_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetControllerCardModel")]
        private unsafe static extern uint GetControllerCardModel_cs(sbyte* controllerCardModel);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetControllerCardModel(ref string controllerCardModel)
        {
            sbyte[] array = new sbyte[2048];
            uint controllerCardModel_cs;
            fixed (sbyte* controllerCardModel2 = array)
            {
                controllerCardModel_cs = GetControllerCardModel_cs(controllerCardModel2);
            }
            for (int i = 0; i < 2048 && array[i] != 0; i++)
            {
                controllerCardModel += (char)array[i];
            }
            return controllerCardModel_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetCountConvertWavelengthRange")]
        private unsafe static extern uint GetCountConvertWavelengthRange_cs(float* minval, float* maxval);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetCountConvertWavelengthRange(ref float minval, ref float maxval)
        {
            float num = default(float);
            float num2 = default(float);
            uint countConvertWavelengthRange_cs = GetCountConvertWavelengthRange_cs(&num, &num2);
            minval = num;
            maxval = num2;
            return countConvertWavelengthRange_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetCurrentCamera")]
        private unsafe static extern uint GetCurrentCamera_cs(int* cameraHandle);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetCurrentCamera(ref int cameraHandle)
        {
            int num = default(int);
            uint currentCamera_cs = GetCurrentCamera_cs(&num);
            cameraHandle = num;
            return currentCamera_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetCYMGShift")]
        private unsafe static extern uint GetCYMGShift_cs(int* _iXshift, int* _iYshift);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetCYMGShift(ref int _iXshift, ref int _iYshift)
        {
            int num = default(int);
            int num2 = default(int);
            uint cYMGShift_cs = GetCYMGShift_cs(&num, &num2);
            _iXshift = num;
            _iYshift = num2;
            return cYMGShift_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGExternalOutputEnabled")]
        private unsafe static extern uint GetDDGExternalOutputEnabled_cs(uint index, uint* state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGExternalOutputEnabled(uint index, ref uint state)
        {
            uint num = default(uint);
            uint dDGExternalOutputEnabled_cs = GetDDGExternalOutputEnabled_cs(index, &num);
            state = num;
            return dDGExternalOutputEnabled_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGExternalOutputPolarity")]
        private unsafe static extern uint GetDDGExternalOutputPolarity_cs(uint index, uint* state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGExternalOutputPolarity(uint index, ref uint state)
        {
            uint num = default(uint);
            uint dDGExternalOutputPolarity_cs = GetDDGExternalOutputPolarity_cs(index, &num);
            state = num;
            return dDGExternalOutputPolarity_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGExternalOutputStepEnabled")]
        private unsafe static extern uint GetDDGExternalOutputStepEnabled_cs(uint index, uint* state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGExternalOutputStepEnabled(uint index, ref uint state)
        {
            uint num = default(uint);
            uint dDGExternalOutputStepEnabled_cs = GetDDGExternalOutputStepEnabled_cs(index, &num);
            state = num;
            return dDGExternalOutputStepEnabled_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGExternalOutputTime")]
        private unsafe static extern uint GetDDGExternalOutputTime_cs(uint uiIndex, ulong* uiDelay, ulong* uiWidth);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGExternalOutputTime(uint uiIndex, ref ulong uiDelay, ref ulong uiWidth)
        {
            ulong num = default(ulong);
            ulong num2 = default(ulong);
            uint dDGExternalOutputTime_cs = GetDDGExternalOutputTime_cs(uiIndex, &num, &num2);
            uiDelay = num;
            uiWidth = num2;
            return dDGExternalOutputTime_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGGateTime")]
        private unsafe static extern uint GetDDGGateTime_cs(ulong* uiDelay, ulong* uiWidth);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGGateTime(ref ulong uiDelay, ref ulong uiWidth)
        {
            ulong num = default(ulong);
            ulong num2 = default(ulong);
            uint dDGGateTime_cs = GetDDGGateTime_cs(&num, &num2);
            uiDelay = num;
            uiWidth = num2;
            return dDGGateTime_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGInsertionDelay")]
        private unsafe static extern uint GetDDGInsertionDelay_cs(uint* mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGInsertionDelay(ref uint mode)
        {
            uint num = default(uint);
            uint dDGInsertionDelay_cs = GetDDGInsertionDelay_cs(&num);
            mode = num;
            return dDGInsertionDelay_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGIntelligate")]
        private unsafe static extern uint GetDDGIntelligate_cs(uint* mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGIntelligate(ref uint mode)
        {
            uint num = default(uint);
            uint dDGIntelligate_cs = GetDDGIntelligate_cs(&num);
            mode = num;
            return dDGIntelligate_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGIOC")]
        private unsafe static extern uint GetDDGIOC_cs(uint* mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGIOC(ref uint mode)
        {
            uint num = default(uint);
            uint dDGIOC_cs = GetDDGIOC_cs(&num);
            mode = num;
            return dDGIOC_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGIOCFrequency")]
        private unsafe static extern uint GetDDGIOCFrequency_cs(double* frequency);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGIOCFrequency(ref double frequency)
        {
            double num = default(double);
            uint dDGIOCFrequency_cs = GetDDGIOCFrequency_cs(&num);
            frequency = num;
            return dDGIOCFrequency_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGIOCNumber")]
        private unsafe static extern uint GetDDGIOCNumber_cs(uint* number_pulses);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGIOCNumber(ref uint number_pulses)
        {
            uint num = default(uint);
            uint dDGIOCNumber_cs = GetDDGIOCNumber_cs(&num);
            number_pulses = num;
            return dDGIOCNumber_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGIOCNumberRequested")]
        private unsafe static extern uint GetDDGIOCNumberRequested_cs(uint* number_pulses);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGIOCNumberRequested(ref uint number_pulses)
        {
            uint num = default(uint);
            uint dDGIOCNumberRequested_cs = GetDDGIOCNumberRequested_cs(&num);
            number_pulses = num;
            return dDGIOCNumberRequested_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGIOCPeriod")]
        private unsafe static extern uint GetDDGIOCPeriod_cs(ulong* pulses);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGIOCPeriod(ref ulong pulses)
        {
            ulong num = default(ulong);
            uint dDGIOCPeriod_cs = GetDDGIOCPeriod_cs(&num);
            pulses = num;
            return dDGIOCPeriod_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGIOCPulses")]
        private unsafe static extern uint GetDDGIOCPulses_cs(int* pulses);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGIOCPulses(ref int pulses)
        {
            int num = default(int);
            uint dDGIOCPulses_cs = GetDDGIOCPulses_cs(&num);
            pulses = num;
            return dDGIOCPulses_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGPulse")]
        private unsafe static extern uint GetDDGPulse_cs(double width, double resolution, double* Delay, double* Width);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGPulse(double width, double resolution, ref double Delay, ref double Width)
        {
            double num = default(double);
            double num2 = default(double);
            uint dDGPulse_cs = GetDDGPulse_cs(width, resolution, &num, &num2);
            Delay = num;
            Width = num2;
            return dDGPulse_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGStepCoefficients")]
        private unsafe static extern uint GetDDGStepCoefficients_cs(uint uiIndex, double* p1, double* p2);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGStepCoefficients(uint uiIndex, ref double p1, ref double p2)
        {
            double num = default(double);
            double num2 = default(double);
            uint dDGStepCoefficients_cs = GetDDGStepCoefficients_cs(uiIndex, &num, &num2);
            p1 = num;
            p2 = num2;
            return dDGStepCoefficients_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGStepMode")]
        private unsafe static extern uint GetDDGStepMode_cs(uint* mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGStepMode(ref uint mode)
        {
            uint num = default(uint);
            uint dDGStepMode_cs = GetDDGStepMode_cs(&num);
            mode = num;
            return dDGStepMode_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDetector")]
        private unsafe static extern uint GetDetector_cs(int* xpixels, int* ypixels);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDetector(ref int xpixels, ref int ypixels)
        {
            int num = default(int);
            int num2 = default(int);
            uint detector_cs = GetDetector_cs(&num, &num2);
            xpixels = num;
            ypixels = num2;
            return detector_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDICameraInfo")]
        private unsafe static extern uint GetDICameraInfo_cs(void* info);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDICameraInfo(ref IntPtr info)
        {
            IntPtr intPtr = default(IntPtr);
            uint dICameraInfo_cs = GetDICameraInfo_cs(&intPtr);
            info = intPtr;
            return dICameraInfo_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDualExposureTimes")]
        private unsafe static extern uint GetDualExposureTimes_cs(float* exposure1, float* exposure2);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDualExposureTimes(ref float exposure1, ref float exposure2)
        {
            float num = default(float);
            float num2 = default(float);
            uint dualExposureTimes_cs = GetDualExposureTimes_cs(&num, &num2);
            exposure1 = num;
            exposure2 = num2;
            return dualExposureTimes_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetEMAdvanced")]
        private unsafe static extern uint GetEMAdvanced_cs(int* state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetEMAdvanced(ref int state)
        {
            int num = default(int);
            uint eMAdvanced_cs = GetEMAdvanced_cs(&num);
            state = num;
            return eMAdvanced_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetEMCCDGain")]
        private unsafe static extern uint GetEMCCDGain_cs(int* gain);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetEMCCDGain(ref int gain)
        {
            int num = default(int);
            uint eMCCDGain_cs = GetEMCCDGain_cs(&num);
            gain = num;
            return eMCCDGain_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGTTLGateWidth")]
        private unsafe static extern uint GetDDGTTLGateWidth_cs(ulong* opticalWidth, ulong* ttlWidth);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGTTLGateWidth(ref ulong opticalWidth, ref ulong ttlWidth)
        {
            ulong num = default(ulong);
            ulong num2 = default(ulong);
            uint dDGTTLGateWidth_cs = GetDDGTTLGateWidth_cs(&num, &num2);
            opticalWidth = num;
            ttlWidth = num2;
            return dDGTTLGateWidth_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGIOCTrigger")]
        private unsafe static extern uint GetDDGIOCTrigger_cs(uint* trigger);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGIOCTrigger(ref uint trigger)
        {
            uint num = default(uint);
            uint dDGIOCTrigger_cs = GetDDGIOCTrigger_cs(&num);
            trigger = num;
            return dDGIOCTrigger_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetDDGIOCTGetDDGOpticalWidthEnabledrigger")]
        private unsafe static extern uint GetDDGOpticalWidthEnabled_cs(uint* puiEnabled);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetDDGOpticalWidthEnabled(ref uint puiEnabled)
        {
            uint num = default(uint);
            uint dDGOpticalWidthEnabled_cs = GetDDGOpticalWidthEnabled_cs(&num);
            puiEnabled = num;
            return dDGOpticalWidthEnabled_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetEMGainRange")]
        private unsafe static extern uint GetEMGainRange_cs(int* low, int* high);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetEMGainRange(ref int low, ref int high)
        {
            int num = default(int);
            int num2 = default(int);
            uint eMGainRange_cs = GetEMGainRange_cs(&num, &num2);
            low = num;
            high = num2;
            return eMGainRange_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetExternalTriggerTermination")]
        private unsafe static extern uint GetExternalTriggerTermination_cs(uint* mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetExternalTriggerTermination(ref uint mode)
        {
            uint num = default(uint);
            uint externalTriggerTermination_cs = GetExternalTriggerTermination_cs(&num);
            mode = num;
            return externalTriggerTermination_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetFastestRecommendedVSSpeed")]
        private unsafe static extern uint GetFastestRecommendedVSSpeed_cs(int* index, float* speed);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetFastestRecommendedVSSpeed(ref int index, ref float speed)
        {
            int num = default(int);
            float num2 = default(float);
            uint fastestRecommendedVSSpeed_cs = GetFastestRecommendedVSSpeed_cs(&num, &num2);
            index = num;
            speed = num2;
            return fastestRecommendedVSSpeed_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetFIFOUsage")]
        private unsafe static extern uint GetFIFOUsage_cs(int* FIFOusage);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetFIFOUsage(ref int FIFOusage)
        {
            int num = default(int);
            uint fIFOUsage_cs = GetFIFOUsage_cs(&num);
            FIFOusage = num;
            return fIFOUsage_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetFilterMode")]
        private unsafe static extern uint GetFilterMode_cs(int* mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetFilterMode(ref int mode)
        {
            int num = default(int);
            uint filterMode_cs = GetFilterMode_cs(&num);
            mode = num;
            return filterMode_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetFKExposureTime")]
        private unsafe static extern uint GetFKExposureTime_cs(float* time);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetFKExposureTime(ref float time)
        {
            float num = default(float);
            uint fKExposureTime_cs = GetFKExposureTime_cs(&num);
            time = num;
            return fKExposureTime_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetFKVShiftSpeed")]
        private unsafe static extern uint GetFKVShiftSpeed_cs(int index, int* speed);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetFKVShiftSpeed(int index, ref int speed)
        {
            int num = default(int);
            uint fKVShiftSpeed_cs = GetFKVShiftSpeed_cs(index, &num);
            speed = num;
            return fKVShiftSpeed_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetFKVShiftSpeedF")]
        private unsafe static extern uint GetFKVShiftSpeedF_cs(int index, float* speed);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetFKVShiftSpeedF(int index, ref float speed)
        {
            float num = default(float);
            uint fKVShiftSpeedF_cs = GetFKVShiftSpeedF_cs(index, &num);
            speed = num;
            return fKVShiftSpeedF_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetFrontEndStatus")]
        private unsafe static extern uint GetFrontEndStatus_cs(int* status);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetFrontEndStatus(ref int status)
        {
            int num = default(int);
            uint frontEndStatus_cs = GetFrontEndStatus_cs(&num);
            status = num;
            return frontEndStatus_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetGateMode")]
        private unsafe static extern uint GetGateMode_cs(int* mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetGateMode(ref int mode)
        {
            int num = default(int);
            uint gateMode_cs = GetGateMode_cs(&num);
            mode = num;
            return gateMode_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetHardwareVersion")]
        private unsafe static extern uint GetHardwareVersion_cs(uint* PCB, uint* Decode, uint* dummy1, uint* dummy2, uint* CameraFirmwareVersion, uint* CameraFirmwareBuild);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetHardwareVersion(ref uint PCB, ref uint Decode, ref uint dummy1, ref uint dummy2, ref uint CameraFirmwareVersion, ref uint CameraFirmwareBuild)
        {
            uint num = default(uint);
            uint num2 = default(uint);
            uint num3 = default(uint);
            uint num4 = default(uint);
            uint num5 = default(uint);
            uint num6 = default(uint);
            uint hardwareVersion_cs = GetHardwareVersion_cs(&num, &num2, &num3, &num4, &num5, &num6);
            PCB = num;
            Decode = num2;
            dummy1 = num3;
            dummy2 = num4;
            CameraFirmwareVersion = num5;
            CameraFirmwareBuild = num6;
            return hardwareVersion_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetCurrentPreAmpGain")]
        private unsafe static extern uint GetCurrentPreAmpGain_cs(int* index, sbyte* name, int length);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetCurrentPreAmpGain(ref int index, ref string name, int length)
        {
            sbyte[] array = new sbyte[2048];
            uint currentPreAmpGain_cs;
            int num = default(int);
            fixed (sbyte* name2 = array)
            {
                currentPreAmpGain_cs = GetCurrentPreAmpGain_cs(&num, name2, length);
            }
            for (int i = 0; i < 2048 && array[i] != 0; i++)
            {
                name += (char)array[i];
            }
            index = num;
            return currentPreAmpGain_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetHeadModel")]
        private unsafe static extern uint GetHeadModel_cs(sbyte* name);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetHeadModel(ref string name)
        {
            sbyte[] array = new sbyte[2048];
            uint headModel_cs;
            fixed (sbyte* name2 = array)
            {
                headModel_cs = GetHeadModel_cs(name2);
            }
            for (int i = 0; i < 2048 && array[i] != 0; i++)
            {
                name += (char)array[i];
            }
            return headModel_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetHorizontalSpeed")]
        private unsafe static extern uint GetHorizontalSpeed_cs(int index, int* speed);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetHorizontalSpeed(int index, ref int speed)
        {
            int num = default(int);
            uint horizontalSpeed_cs = GetHorizontalSpeed_cs(index, &num);
            speed = num;
            return horizontalSpeed_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetHSSpeed")]
        private unsafe static extern uint GetHSSpeed_cs(int channel, int type, int index, float* speed);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetHSSpeed(int channel, int type, int index, ref float speed)
        {
            float num = default(float);
            uint hSSpeed_cs = GetHSSpeed_cs(channel, type, index, &num);
            speed = num;
            return hSSpeed_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetHVflag")]
        private unsafe static extern uint GetHVflag_cs(int* bFlag);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetHVflag(ref int bFlag)
        {
            int num = default(int);
            uint hVflag_cs = GetHVflag_cs(&num);
            bFlag = num;
            return hVflag_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetID")]
        private unsafe static extern uint GetID_cs(int devNum, int* id);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetID(int devNum, ref int id)
        {
            int num = default(int);
            uint iD_cs = GetID_cs(devNum, &num);
            id = num;
            return iD_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetImageFlip")]
        private unsafe static extern uint GetImageFlip_cs(int* iHFlip, int* iVFlip);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetImageFlip(ref int iHFlip, ref int iVFlip)
        {
            int num = default(int);
            int num2 = default(int);
            uint imageFlip_cs = GetImageFlip_cs(&num, &num2);
            iHFlip = num;
            iVFlip = num2;
            return imageFlip_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetImageRotate")]
        private unsafe static extern uint GetImageRotate_cs(int* iRotate);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetImageRotate(ref int iRotate)
        {
            int num = default(int);
            uint imageRotate_cs = GetImageRotate_cs(&num);
            iRotate = num;
            return imageRotate_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetImages")]
        private unsafe static extern uint GetImages_cs(int first, int last, int* array, uint size, int* validfirst, int* validlast);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetImages(int first, int last, int[] array, uint size, ref int validfirst, ref int validlast)
        {
            uint images_cs;
            int num = default(int);
            int num2 = default(int);
            fixed (int* array2 = array)
            {
                images_cs = GetImages_cs(first, last, array2, size, &num, &num2);
            }
            validfirst = num;
            validlast = num2;
            return images_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetImages16")]
        private unsafe static extern uint GetImages16_cs(int first, int last, ushort* array, uint size, int* validfirst, int* validlast);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetImages16(int first, int last, ushort[] array, uint size, ref int validfirst, ref int validlast)
        {
            uint images16_cs;
            int num = default(int);
            int num2 = default(int);
            fixed (ushort* array2 = array)
            {
                images16_cs = GetImages16_cs(first, last, array2, size, &num, &num2);
            }
            validfirst = num;
            validlast = num2;
            return images16_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetImagesPerDMA")]
        private unsafe static extern uint GetImagesPerDMA_cs(uint* images);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetImagesPerDMA(ref uint images)
        {
            uint num = default(uint);
            uint imagesPerDMA_cs = GetImagesPerDMA_cs(&num);
            images = num;
            return imagesPerDMA_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetKeepCleanTime")]
        private unsafe static extern uint GetKeepCleanTime_cs(float* KeepCleanTime);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetKeepCleanTime(ref float KeepCleanTime)
        {
            float num = default(float);
            uint keepCleanTime_cs = GetKeepCleanTime_cs(&num);
            KeepCleanTime = num;
            return keepCleanTime_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMaximumBinning")]
        private unsafe static extern uint GetMaximumBinning_cs(int ReadMode, int HorzVert, int* MaxBinning);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMaximumBinning(int ReadMode, int HorzVert, ref int MaxBinning)
        {
            int num = default(int);
            uint maximumBinning_cs = GetMaximumBinning_cs(ReadMode, HorzVert, &num);
            MaxBinning = num;
            return maximumBinning_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMaximumExposure")]
        private unsafe static extern uint GetMaximumExposure_cs(float* MaxExp);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMaximumExposure(ref float MaxExp)
        {
            float num = default(float);
            uint maximumExposure_cs = GetMaximumExposure_cs(&num);
            MaxExp = num;
            return maximumExposure_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMCPGain")]
        private unsafe static extern uint GetMCPGain_cs(int* iVoltage);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMCPGain(ref int iVoltage)
        {
            int num = default(int);
            uint mCPGain_cs = GetMCPGain_cs(&num);
            iVoltage = num;
            return mCPGain_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMCPGainRange")]
        private unsafe static extern uint GetMCPGainRange_cs(int* iLow, int* iHigh);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMCPGainRange(ref int iLow, ref int iHigh)
        {
            int num = default(int);
            int num2 = default(int);
            uint mCPGainRange_cs = GetMCPGainRange_cs(&num, &num2);
            iLow = num;
            iHigh = num2;
            return mCPGainRange_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMCPGainTable")]
        private unsafe static extern uint GetMCPGainTable_cs(int iNum, int* iGain, float* fPhotoepc);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMCPGainTable(int iNum, ref int iGain, ref float fPhotoepc)
        {
            int num = default(int);
            float num2 = default(float);
            uint mCPGainTable_cs = GetMCPGainTable_cs(iNum, &num, &num2);
            iGain = num;
            fPhotoepc = num2;
            return mCPGainTable_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMCPVoltage")]
        private unsafe static extern uint GetMCPVoltage_cs(int* iVoltage);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMCPVoltage(ref int iVoltage)
        {
            int num = default(int);
            uint mCPVoltage_cs = GetMCPVoltage_cs(&num);
            iVoltage = num;
            return mCPVoltage_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMetaDataInfo")]
        private unsafe static extern uint GetMetaDataInfo_cs(SYSTEMTIME* _timeOfStart, float* _pf_timeFromStart, int _i_index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMetaDataInfo(ref SYSTEMTIME _timeOfStart, ref float _pf_timeFromStart, int _i_index)
        {
            SYSTEMTIME sYSTEMTIME = default(SYSTEMTIME);
            float num = default(float);
            uint metaDataInfo_cs = GetMetaDataInfo_cs(&sYSTEMTIME, &num, _i_index);
            _timeOfStart = sYSTEMTIME;
            _pf_timeFromStart = num;
            return metaDataInfo_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMinimumImageLength")]
        private unsafe static extern uint GetMinimumImageLength_cs(int* MinImageLength);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMinimumImageLength(ref int MinImageLength)
        {
            int num = default(int);
            uint minimumImageLength_cs = GetMinimumImageLength_cs(&num);
            MinImageLength = num;
            return minimumImageLength_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMinimumNumberInSeries")]
        private unsafe static extern uint GetMinimumNumberInSeries_cs(int* _i_number);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMinimumNumberInSeries(ref int _i_number)
        {
            int num = default(int);
            uint minimumNumberInSeries_cs = GetMinimumNumberInSeries_cs(&num);
            _i_number = num;
            return minimumNumberInSeries_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMostRecentColorImage16")]
        private unsafe static extern uint GetMostRecentColorImage16_cs(uint size, int algorithm, ushort* red, ushort* green, ushort* blue);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMostRecentColorImage16(uint size, int algorithm, ushort[] red, ushort[] green, ushort[] blue)
        {
            uint mostRecentColorImage16_cs;
            fixed (ushort* red2 = red)
            {
                fixed (ushort* green2 = green)
                {
                    fixed (ushort* blue2 = blue)
                    {
                        mostRecentColorImage16_cs = GetMostRecentColorImage16_cs(size, algorithm, red2, green2, blue2);
                    }
                }
            }
            return mostRecentColorImage16_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMostRecentImage")]
        private unsafe static extern uint GetMostRecentImage_cs(int* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMostRecentImage(int[] array, uint size)
        {
            uint mostRecentImage_cs;
            fixed (int* array2 = array)
            {
                mostRecentImage_cs = GetMostRecentImage_cs(array2, size);
            }
            return mostRecentImage_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMostRecentImage16")]
        private unsafe static extern uint GetMostRecentImage16_cs(ushort* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMostRecentImage16(ushort[] array, uint size)
        {
            uint mostRecentImage16_cs;
            fixed (ushort* array2 = array)
            {
                mostRecentImage16_cs = GetMostRecentImage16_cs(array2, size);
            }
            return mostRecentImage16_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMSTimingsData")]
        private unsafe static extern uint GetMSTimingsData_cs(SYSTEMTIME* TimeOfStart, float* _pfDifferences, int _inoOfimages);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetMSTimingsData(ref SYSTEMTIME TimeOfStart, float[] _pfDifferences, int _inoOfimages)
        {
            uint mSTimingsData_cs;
            SYSTEMTIME sYSTEMTIME = default(SYSTEMTIME);
            fixed (float* pfDifferences = _pfDifferences)
            {
                mSTimingsData_cs = GetMSTimingsData_cs(&sYSTEMTIME, pfDifferences, _inoOfimages);
            }
            TimeOfStart = sYSTEMTIME;
            return mSTimingsData_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetMSTimingsEnabled")]
        private static extern uint GetMSTimingsEnabled_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint GetMSTimingsEnabled()
        {
            return GetMSTimingsEnabled_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNewData")]
        private unsafe static extern uint GetNewData_cs(int* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNewData(int[] array, uint size)
        {
            uint newData_cs;
            fixed (int* array2 = array)
            {
                newData_cs = GetNewData_cs(array2, size);
            }
            return newData_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNewData16")]
        private unsafe static extern uint GetNewData16_cs(ushort* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNewData16(ushort[] array, uint size)
        {
            uint newData16_cs;
            fixed (ushort* array2 = array)
            {
                newData16_cs = GetNewData16_cs(array2, size);
            }
            return newData16_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNewData8")]
        private unsafe static extern uint GetNewData8_cs(byte* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNewData8(byte[] array, uint size)
        {
            uint newData8_cs;
            fixed (byte* array2 = array)
            {
                newData8_cs = GetNewData8_cs(array2, size);
            }
            return newData8_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetIRIGData")]
        private unsafe static extern uint GetIRIGData_cs(byte* data, uint index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetIRIGData(byte[] data, uint index)
        {
            uint iRIGData_cs;
            fixed (byte* data2 = data)
            {
                iRIGData_cs = GetIRIGData_cs(data2, index);
            }
            return iRIGData_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNewFloatData")]
        private unsafe static extern uint GetNewFloatData_cs(float* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNewFloatData(float[] array, uint size)
        {
            uint newFloatData_cs;
            fixed (float* array2 = array)
            {
                newFloatData_cs = GetNewFloatData_cs(array2, size);
            }
            return newFloatData_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberADChannels")]
        private unsafe static extern uint GetNumberADChannels_cs(int* channels);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberADChannels(ref int channels)
        {
            int num = default(int);
            uint numberADChannels_cs = GetNumberADChannels_cs(&num);
            channels = num;
            return numberADChannels_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberAmp")]
        private unsafe static extern uint GetNumberAmp_cs(int* amp);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberAmp(ref int amp)
        {
            int num = default(int);
            uint numberAmp_cs = GetNumberAmp_cs(&num);
            amp = num;
            return numberAmp_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberAvailableImages")]
        private unsafe static extern uint GetNumberAvailableImages_cs(int* first, int* last);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberAvailableImages(ref int first, ref int last)
        {
            int num = default(int);
            int num2 = default(int);
            uint numberAvailableImages_cs = GetNumberAvailableImages_cs(&num, &num2);
            first = num;
            last = num2;
            return numberAvailableImages_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberDDGExternalOutputs")]
        private unsafe static extern uint GetNumberDDGExternalOutputs_cs(int* numDevs);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberDDGExternalOutputs(ref int numDevs)
        {
            int num = default(int);
            uint numberDDGExternalOutputs_cs = GetNumberDDGExternalOutputs_cs(&num);
            numDevs = num;
            return numberDDGExternalOutputs_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberDevices")]
        private unsafe static extern uint GetNumberDevices_cs(int* numDevs);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberDevices(ref int numDevs)
        {
            int num = default(int);
            uint numberDevices_cs = GetNumberDevices_cs(&num);
            numDevs = num;
            return numberDevices_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberFKVShiftSpeeds")]
        private unsafe static extern uint GetNumberFKVShiftSpeeds_cs(int* number);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberFKVShiftSpeeds(ref int number)
        {
            int num = default(int);
            uint numberFKVShiftSpeeds_cs = GetNumberFKVShiftSpeeds_cs(&num);
            number = num;
            return numberFKVShiftSpeeds_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberHorizontalSpeeds")]
        private unsafe static extern uint GetNumberHorizontalSpeeds_cs(int* number);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberHorizontalSpeeds(ref int number)
        {
            int num = default(int);
            uint numberHorizontalSpeeds_cs = GetNumberHorizontalSpeeds_cs(&num);
            number = num;
            return numberHorizontalSpeeds_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberHSSpeeds")]
        private unsafe static extern uint GetNumberHSSpeeds_cs(int channel, int type, int* speeds);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberHSSpeeds(int channel, int type, ref int speeds)
        {
            int num = default(int);
            uint numberHSSpeeds_cs = GetNumberHSSpeeds_cs(channel, type, &num);
            speeds = num;
            return numberHSSpeeds_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberMissedExternalTriggers")]
        private unsafe static extern uint GetNumberMissedExternalTriggers_cs(uint first, uint last, ushort* arr);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberMissedExternalTriggers(uint first, uint last, ushort[] arr)
        {
            uint numberMissedExternalTriggers_cs;
            fixed (ushort* arr2 = arr)
            {
                numberMissedExternalTriggers_cs = GetNumberMissedExternalTriggers_cs(first, last, arr2);
            }
            return numberMissedExternalTriggers_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberNewImages")]
        private unsafe static extern uint GetNumberNewImages_cs(int* first, int* last);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberNewImages(ref int first, ref int last)
        {
            int num = default(int);
            int num2 = default(int);
            uint numberNewImages_cs = GetNumberNewImages_cs(&num, &num2);
            first = num;
            last = num2;
            return numberNewImages_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberPhotonCountingDivisions")]
        private unsafe static extern uint GetNumberPhotonCountingDivisions_cs(uint* noOfDivisions);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberPhotonCountingDivisions(uint[] noOfDivisions)
        {
            uint numberPhotonCountingDivisions_cs;
            fixed (uint* noOfDivisions2 = noOfDivisions)
            {
                numberPhotonCountingDivisions_cs = GetNumberPhotonCountingDivisions_cs(noOfDivisions2);
            }
            return numberPhotonCountingDivisions_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberPreAmpGains")]
        private unsafe static extern uint GetNumberPreAmpGains_cs(int* noGains);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberPreAmpGains(ref int noGains)
        {
            int num = default(int);
            uint numberPreAmpGains_cs = GetNumberPreAmpGains_cs(&num);
            noGains = num;
            return numberPreAmpGains_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberRingExposureTimes")]
        private unsafe static extern uint GetNumberRingExposureTimes_cs(int* _ipnumTimes);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberRingExposureTimes(ref int _ipnumTimes)
        {
            int num = default(int);
            uint numberRingExposureTimes_cs = GetNumberRingExposureTimes_cs(&num);
            _ipnumTimes = num;
            return numberRingExposureTimes_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberIO")]
        private unsafe static extern uint GetNumberIO_cs(int* iNumber);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberIO(ref int iNumber)
        {
            int num = default(int);
            uint numberIO_cs = GetNumberIO_cs(&num);
            iNumber = num;
            return numberIO_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberVerticalSpeeds")]
        private unsafe static extern uint GetNumberVerticalSpeeds_cs(int* number);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberVerticalSpeeds(ref int number)
        {
            int num = default(int);
            uint numberVerticalSpeeds_cs = GetNumberVerticalSpeeds_cs(&num);
            number = num;
            return numberVerticalSpeeds_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberVSAmplitudes")]
        private unsafe static extern uint GetNumberVSAmplitudes_cs(int* number);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberVSAmplitudes(ref int number)
        {
            int num = default(int);
            uint numberVSAmplitudes_cs = GetNumberVSAmplitudes_cs(&num);
            number = num;
            return numberVSAmplitudes_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetNumberVSSpeeds")]
        private unsafe static extern uint GetNumberVSSpeeds_cs(int* speeds);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetNumberVSSpeeds(ref int speeds)
        {
            int num = default(int);
            uint numberVSSpeeds_cs = GetNumberVSSpeeds_cs(&num);
            speeds = num;
            return numberVSSpeeds_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetOldestImage")]
        private unsafe static extern uint GetOldestImage_cs(int* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetOldestImage(int[] array, uint size)
        {
            uint oldestImage_cs;
            fixed (int* array2 = array)
            {
                oldestImage_cs = GetOldestImage_cs(array2, size);
            }
            return oldestImage_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetOldestImage16")]
        private unsafe static extern uint GetOldestImage16_cs(ushort* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetOldestImage16(ushort[] array, uint size)
        {
            uint oldestImage16_cs;
            fixed (ushort* array2 = array)
            {
                oldestImage16_cs = GetOldestImage16_cs(array2, size);
            }
            return oldestImage16_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetPhosphorStatus")]
        private unsafe static extern uint GetPhosphorStatus_cs(int* status);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetPhosphorStatus(ref int status)
        {
            int num = default(int);
            uint phosphorStatus_cs = GetPhosphorStatus_cs(&num);
            status = num;
            return phosphorStatus_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetPhysicalDMAAddress")]
        private unsafe static extern uint GetPhysicalDMAAddress_cs(uint* Address1, uint* Address2);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetPhysicalDMAAddress(ref uint Address1, ref uint Address2)
        {
            uint num = default(uint);
            uint num2 = default(uint);
            uint physicalDMAAddress_cs = GetPhysicalDMAAddress_cs(&num, &num2);
            Address1 = num;
            Address2 = num2;
            return physicalDMAAddress_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetPixelSize")]
        private unsafe static extern uint GetPixelSize_cs(float* xSize, float* ySize);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetPixelSize(ref float xSize, ref float ySize)
        {
            float num = default(float);
            float num2 = default(float);
            uint pixelSize_cs = GetPixelSize_cs(&num, &num2);
            xSize = num;
            ySize = num2;
            return pixelSize_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetReadOutTime")]
        private unsafe static extern uint GetReadOutTime_cs(float* ReadoutTime);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetReadOutTime(ref float ReadoutTime)
        {
            float num = default(float);
            uint readOutTime_cs = GetReadOutTime_cs(&num);
            ReadoutTime = num;
            return readOutTime_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetPreAmpGain")]
        private unsafe static extern uint GetPreAmpGain_cs(int index, float* gain);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetPreAmpGain(int index, ref float gain)
        {
            float num = default(float);
            uint preAmpGain_cs = GetPreAmpGain_cs(index, &num);
            gain = num;
            return preAmpGain_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetPreAmpGainText")]
        private unsafe static extern uint GetPreAmpGainText_cs(int index, sbyte* name, int len);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetPreAmpGainText(int index, ref string name, int len)
        {
            sbyte[] array = new sbyte[len];
            uint preAmpGainText_cs;
            fixed (sbyte* name2 = array)
            {
                preAmpGainText_cs = GetPreAmpGainText_cs(index, name2, len);
            }
            for (int i = 0; i < 2048 && array[i] != 0; i++)
            {
                name += (char)array[i];
            }
            return preAmpGainText_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetQE")]
        private unsafe static extern uint GetQE_cs(string sensor, float wavelength, uint mode, float* QE);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetQE(string sensor, float wavelength, uint mode, ref float QE)
        {
            float num = default(float);
            uint qE_cs = GetQE_cs(sensor, wavelength, mode, &num);
            QE = num;
            return qE_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetRegisterDump")]
        private unsafe static extern uint GetRegisterDump_cs(int* mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetRegisterDump(ref int mode)
        {
            int num = default(int);
            uint registerDump_cs = GetRegisterDump_cs(&num);
            mode = num;
            return registerDump_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetRelativeImageTimes")]
        private unsafe static extern uint GetRelativeImageTimes_cs(uint first, uint last, ulong* arr, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetRelativeImageTimes(uint first, uint last, ulong[] arr, uint size)
        {
            uint relativeImageTimes_cs;
            fixed (ulong* arr2 = arr)
            {
                relativeImageTimes_cs = GetRelativeImageTimes_cs(first, last, arr2, size);
            }
            return relativeImageTimes_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetRingExposureRange")]
        private unsafe static extern uint GetRingExposureRange_cs(float* _fpMin, float* _fpMax);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetRingExposureRange(ref float _fpMin, ref float _fpMax)
        {
            float num = default(float);
            float num2 = default(float);
            uint ringExposureRange_cs = GetRingExposureRange_cs(&num, &num2);
            _fpMin = num;
            _fpMax = num2;
            return ringExposureRange_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetSensitivity")]
        private unsafe static extern uint GetSensitivity_cs(int channel, int horzShift, int amplifier, int pa, float* sensitivity);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetSensitivity(int channel, int horzShift, int amplifier, int pa, ref float sensitivity)
        {
            float num = default(float);
            uint sensitivity_cs = GetSensitivity_cs(channel, horzShift, amplifier, pa, &num);
            sensitivity = num;
            return sensitivity_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetShutterMinTimes")]
        private unsafe static extern uint GetShutterMinTimes_cs(int* minclosingtime, int* minopeningtime);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetShutterMinTimes(ref int minclosingtime, ref int minopeningtime)
        {
            int num = default(int);
            int num2 = default(int);
            uint shutterMinTimes_cs = GetShutterMinTimes_cs(&num, &num2);
            minclosingtime = num;
            minopeningtime = num2;
            return shutterMinTimes_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetSizeOfCircularBuffer")]
        private unsafe static extern uint GetSizeOfCircularBuffer_cs(int* index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetSizeOfCircularBuffer(ref int index)
        {
            int num = default(int);
            uint sizeOfCircularBuffer_cs = GetSizeOfCircularBuffer_cs(&num);
            index = num;
            return sizeOfCircularBuffer_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetSlotBusDeviceFunction")]
        private unsafe static extern uint GetSlotBusDeviceFunction_cs(int* dwSlot, int* dwBus, int* dwDevice, int* dwFunction);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetSlotBusDeviceFunction(ref int dwSlot, ref int dwBus, ref int dwDevice, ref int dwFunction)
        {
            int num = default(int);
            int num2 = default(int);
            int num3 = default(int);
            int num4 = default(int);
            uint slotBusDeviceFunction_cs = GetSlotBusDeviceFunction_cs(&num, &num2, &num3, &num4);
            dwSlot = num;
            dwBus = num2;
            dwDevice = num3;
            dwFunction = num4;
            return slotBusDeviceFunction_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetSoftwareVersion")]
        private unsafe static extern uint GetSoftwareVersion_cs(uint* eprom, uint* coffile, uint* vxdrev, uint* vxdver, uint* dllrev, uint* dllver);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetSoftwareVersion(ref uint eprom, ref uint coffile, ref uint vxdrev, ref uint vxdver, ref uint dllrev, ref uint dllver)
        {
            uint num = default(uint);
            uint num2 = default(uint);
            uint num3 = default(uint);
            uint num4 = default(uint);
            uint num5 = default(uint);
            uint num6 = default(uint);
            uint softwareVersion_cs = GetSoftwareVersion_cs(&num, &num2, &num3, &num4, &num5, &num6);
            eprom = num;
            coffile = num2;
            vxdrev = num3;
            vxdver = num4;
            dllrev = num5;
            dllver = num6;
            return softwareVersion_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetSpoolProgress")]
        private unsafe static extern uint GetSpoolProgress_cs(int* index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetSpoolProgress(ref int index)
        {
            int num = default(int);
            uint spoolProgress_cs = GetSpoolProgress_cs(&num);
            index = num;
            return spoolProgress_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetStartUpTime")]
        private unsafe static extern uint GetStartUpTime_cs(float* time);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetStartUpTime(ref float time)
        {
            float num = default(float);
            uint startUpTime_cs = GetStartUpTime_cs(&num);
            time = num;
            return startUpTime_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetStatus")]
        private unsafe static extern uint GetStatus_cs(int* status);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetStatus(ref int status)
        {
            int num = default(int);
            uint status_cs = GetStatus_cs(&num);
            status = num;
            return status_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetTECStatus")]
        private unsafe static extern uint GetTECStatus_cs(int* status);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetTECStatus(ref int status)
        {
            int num = default(int);
            uint tECStatus_cs = GetTECStatus_cs(&num);
            status = num;
            return tECStatus_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetTemperature")]
        private unsafe static extern uint GetTemperature_cs(int* temperature);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetTemperature(ref int temperature)
        {
            int num = default(int);
            uint temperature_cs = GetTemperature_cs(&num);
            temperature = num;
            return temperature_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetTemperatureF")]
        private unsafe static extern uint GetTemperatureF_cs(float* temperature);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetTemperatureF(ref float temperature)
        {
            float num = default(float);
            uint temperatureF_cs = GetTemperatureF_cs(&num);
            temperature = num;
            return temperatureF_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetTemperatureRange")]
        private unsafe static extern uint GetTemperatureRange_cs(int* mintemp, int* maxtemp);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetTemperatureRange(ref int mintemp, ref int maxtemp)
        {
            int num = default(int);
            int num2 = default(int);
            uint temperatureRange_cs = GetTemperatureRange_cs(&num, &num2);
            mintemp = num;
            maxtemp = num2;
            return temperatureRange_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetTemperatureStatus")]
        private unsafe static extern uint GetTemperatureStatus_cs(float* SensorTemp, float* TargetTemp, float* AmbientTemp, float* CoolerVolts);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetTemperatureStatus(ref float SensorTemp, ref float TargetTemp, ref float AmbientTemp, ref float CoolerVolts)
        {
            float num = default(float);
            float num2 = default(float);
            float num3 = default(float);
            float num4 = default(float);
            uint temperatureStatus_cs = GetTemperatureStatus_cs(&num, &num2, &num3, &num4);
            SensorTemp = num;
            TargetTemp = num2;
            AmbientTemp = num3;
            CoolerVolts = num4;
            return temperatureStatus_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetUSBDeviceDetails")]
        private unsafe static extern uint GetUSBDeviceDetails_cs(ushort* VendorID, ushort* ProductID, ushort* FirmwareVersion, ushort* SpecificationNumber);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetUSBDeviceDetails(ref ushort VendorID, ref ushort ProductID, ref ushort FirmwareVersion, ref ushort SpecificationNumber)
        {
            ushort num = default(ushort);
            ushort num2 = default(ushort);
            ushort num3 = default(ushort);
            ushort num4 = default(ushort);
            uint uSBDeviceDetails_cs = GetUSBDeviceDetails_cs(&num, &num2, &num3, &num4);
            VendorID = num;
            ProductID = num2;
            FirmwareVersion = num3;
            SpecificationNumber = num4;
            return uSBDeviceDetails_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetTotalNumberImagesAcquired")]
        private unsafe static extern uint GetTotalNumberImagesAcquired_cs(int* index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetTotalNumberImagesAcquired(ref int index)
        {
            int num = default(int);
            uint totalNumberImagesAcquired_cs = GetTotalNumberImagesAcquired_cs(&num);
            index = num;
            return totalNumberImagesAcquired_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetIODirection")]
        private unsafe static extern uint GetIODirection_cs(int index, int* iDirection);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetIODirection(int index, ref int iDirection)
        {
            int num = default(int);
            uint iODirection_cs = GetIODirection_cs(index, &num);
            iDirection = num;
            return iODirection_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetIOLevel")]
        private unsafe static extern uint GetIOLevel_cs(int index, int* iLevel);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetIOLevel(int index, ref int iLevel)
        {
            int num = default(int);
            uint iOLevel_cs = GetIOLevel_cs(index, &num);
            iLevel = num;
            return iOLevel_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetTriggerLevelRange")]
        private unsafe static extern uint GetTriggerLevelRange_cs(float* _fpMin, float* _fpMax);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetTriggerLevelRange(ref float _fpMin, ref float _fpMax)
        {
            float num = default(float);
            float num2 = default(float);
            uint triggerLevelRange_cs = GetTriggerLevelRange_cs(&num, &num2);
            _fpMin = num;
            _fpMax = num2;
            return triggerLevelRange_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetVersionInfo")]
        private unsafe static extern uint GetVersionInfo_cs(AT_VersionInfoId _id, sbyte* _sz_versionInfo, uint _ui32_bufferLen);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetVersionInfo(AT_VersionInfoId _id, ref string _sz_versionInfo, uint _ui32_bufferLen)
        {
            sbyte[] array = new sbyte[_ui32_bufferLen];
            uint versionInfo_cs;
            fixed (sbyte* sz_versionInfo = array)
            {
                versionInfo_cs = GetVersionInfo_cs(_id, sz_versionInfo, _ui32_bufferLen);
            }
            for (int i = 0; i < 2048 && array[i] != 0; i++)
            {
                _sz_versionInfo += (char)array[i];
            }
            return versionInfo_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetVerticalSpeed")]
        private unsafe static extern uint GetVerticalSpeed_cs(int index, int* speed);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetVerticalSpeed(int index, ref int speed)
        {
            int num = default(int);
            uint verticalSpeed_cs = GetVerticalSpeed_cs(index, &num);
            speed = num;
            return verticalSpeed_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetVSAmplitudeString")]
        private unsafe static extern uint GetVSAmplitudeString_cs(int index, sbyte* text);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetVSAmplitudeString(int index, ref string text)
        {
            sbyte[] array = new sbyte[2048];
            uint vSAmplitudeString_cs;
            fixed (sbyte* text2 = array)
            {
                vSAmplitudeString_cs = GetVSAmplitudeString_cs(index, text2);
            }
            for (int i = 0; i < 2048 && array[i] != 0; i++)
            {
                text += (char)array[i];
            }
            return vSAmplitudeString_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetVSAmplitudeFromString")]
        private unsafe static extern uint GetVSAmplitudeFromString_cs(string text, int* index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetVSAmplitudeFromString(string text, ref int index)
        {
            int num = default(int);
            uint vSAmplitudeFromString_cs = GetVSAmplitudeFromString_cs(text, &num);
            index = num;
            return vSAmplitudeFromString_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetVSAmplitudeValue")]
        private unsafe static extern uint GetVSAmplitudeValue_cs(int index, int* value);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetVSAmplitudeString(int index, ref int value)
        {
            int num = default(int);
            uint vSAmplitudeValue_cs = GetVSAmplitudeValue_cs(index, &num);
            value = num;
            return vSAmplitudeValue_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GetVSSpeed")]
        private unsafe static extern uint GetVSSpeed_cs(int index, float* speed);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GetVSSpeed(int index, ref float speed)
        {
            float num = default(float);
            uint vSSpeed_cs = GetVSSpeed_cs(index, &num);
            speed = num;
            return vSSpeed_cs;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GPIBReceive")]
        private unsafe static extern uint GPIBReceive_cs(int id, short address, sbyte* text, int size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint GPIBReceive(int id, short address, ref string text, int size)
        {
            sbyte[] array = new sbyte[2048];
            uint result;
            fixed (sbyte* text2 = array)
            {
                result = GPIBReceive_cs(id, address, text2, size);
            }
            for (int i = 0; i < 2048 && array[i] != 0; i++)
            {
                text += (char)array[i];
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "GPIBSend")]
        private static extern uint GPIBSend_cs(int id, short address, string text);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint GPIBSend(int id, short address, string text)
        {
            return GPIBSend_cs(id, address, text);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "I2CBurstRead")]
        private static extern uint I2CBurstRead_cs(byte i2cAddress, int nBytes, byte[] data);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint I2CBurstRead(byte i2cAddress, int nBytes, byte[] data)
        {
            return I2CBurstRead_cs(i2cAddress, nBytes, data);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "I2CBurstWrite")]
        private static extern uint I2CBurstWrite_cs(byte i2cAddress, int nBytes, byte[] data);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint I2CBurstWrite(byte i2cAddress, int nBytes, byte[] data)
        {
            return I2CBurstWrite_cs(i2cAddress, nBytes, data);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "I2CRead")]
        private unsafe static extern uint I2CRead_cs(byte deviceID, byte intAddress, byte* pdata);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint I2CRead(byte deviceID, byte intAddress, ref byte pdata)
        {
            byte b = default(byte);
            uint result = I2CRead_cs(deviceID, intAddress, &b);
            pdata = b;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "I2CReset")]
        private static extern uint I2CReset_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint I2CReset()
        {
            return I2CReset_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "I2CWrite")]
        private static extern uint I2CWrite_cs(byte deviceID, byte intAddress, byte data);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint I2CWrite(byte deviceID, byte intAddress, byte data)
        {
            return I2CWrite_cs(deviceID, intAddress, data);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "IdAndorDll")]
        private static extern uint IdAndorDll_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint IdAndorDll()
        {
            return IdAndorDll_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "InAuxPort")]
        private unsafe static extern uint InAuxPort_cs(int port, int* state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint InAuxPort(int port, ref int state)
        {
            int num = default(int);
            uint result = InAuxPort_cs(port, &num);
            state = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Initialize")]
        private static extern uint Initialize_cs(string dir);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint Initialize(string dir)
        {
            return Initialize_cs(dir);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "InitializeDevice")]
        private static extern uint InitializeDevice_cs(string dir);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint InitializeDevice(string dir)
        {
            return InitializeDevice_cs(dir);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "IsAmplifierAvailable")]
        private static extern uint IsAmplifierAvailable_cs(int iamp);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint IsAmplifierAvailable(int iamp)
        {
            return IsAmplifierAvailable_cs(iamp);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "IsReadoutFlippedByAmplifier")]
        private unsafe static extern uint IsReadoutFlippedByAmplifier_cs(int iAmplifier, int* iFlipped);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint IsReadoutFlippedByAmplifier(int iAmplifier, ref int iFlipped)
        {
            int num = default(int);
            uint result = IsReadoutFlippedByAmplifier_cs(iAmplifier, &num);
            iFlipped = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "IsCoolerOn")]
        private unsafe static extern uint IsCoolerOn_cs(int* _iCoolerStatus);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint IsCoolerOn(ref int _iCoolerStatus)
        {
            int num = default(int);
            uint result = IsCoolerOn_cs(&num);
            _iCoolerStatus = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "IsCountConvertModeAvailable")]
        private unsafe static extern uint IsCountConvertModeAvailable_cs(int* mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint IsCountConvertModeAvailable(ref int mode)
        {
            int num = default(int);
            uint result = IsCountConvertModeAvailable_cs(&num);
            mode = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "IsInternalMechanicalShutter")]
        private unsafe static extern uint IsInternalMechanicalShutter_cs(int* InternalShutter);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint IsInternalMechanicalShutter(ref int InternalShutter)
        {
            int num = default(int);
            uint result = IsInternalMechanicalShutter_cs(&num);
            InternalShutter = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "IsPreAmpGainAvailable")]
        private unsafe static extern uint IsPreAmpGainAvailable_cs(int channel, int amplifier, int index, int pa, int* status);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint IsPreAmpGainAvailable(int channel, int amplifier, int index, int pa, ref int status)
        {
            int num = default(int);
            uint result = IsPreAmpGainAvailable_cs(channel, amplifier, index, pa, &num);
            status = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "IsTriggerModeAvailable")]
        private static extern uint IsTriggerModeAvailable_cs(int _itriggerMode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint IsTriggerModeAvailable(int _itriggerMode)
        {
            return IsTriggerModeAvailable_cs(_itriggerMode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Merge")]
        private unsafe static extern uint Merge_cs(int* array, int nOrder, int nPoint, int nPixel, float* coeff, int fit, int hbin, int* output, float* start, float* step);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint Merge(int[] array, int nOrder, int nPoint, int nPixel, ref float coeff, int fit, int hbin, ref int output, ref float start, ref float step)
        {
            uint result;
            float num = default(float);
            int num2 = default(int);
            float num3 = default(float);
            float num4 = default(float);
            fixed (int* array2 = array)
            {
                result = Merge_cs(array2, nOrder, nPoint, nPixel, &num, fit, hbin, &num2, &num3, &num4);
            }
            coeff = num;
            output = num2;
            start = num3;
            step = num4;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OutAuxPort")]
        private static extern uint OutAuxPort_cs(int port, int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint OutAuxPort(int port, int state)
        {
            return OutAuxPort_cs(port, state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "PrepareAcquisition")]
        private static extern uint PrepareAcquisition_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint PrepareAcquisition()
        {
            return PrepareAcquisition_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveAsBmp")]
        private static extern uint SaveAsBmp_cs(string path, string palette, int ymin, int ymax);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveAsBmp(string path, string palette, int ymin, int ymax)
        {
            return SaveAsBmp_cs(path, palette, ymin, ymax);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveAsCalibratedSif")]
        private static extern uint SaveAsCalibratedSif_cs(string path, int x_data_type, int x_unit, float[] x_cal, float rayleighWavelength);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveAsCalibratedSif(string path, int x_data_type, int x_unit, float[] x_cal, float rayleighWavelength)
        {
            return SaveAsCalibratedSif_cs(path, x_data_type, x_unit, x_cal, rayleighWavelength);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveAsCommentedSif")]
        private static extern uint SaveAsCommentedSif_cs(string path, string comment);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveAsCommentedSif(string path, string comment)
        {
            return SaveAsCommentedSif_cs(path, comment);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveAsEDF")]
        private static extern uint SaveAsEDF_cs(string _szPath, int _iMode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveAsEDF(string _szPath, int _iMode)
        {
            return SaveAsEDF_cs(_szPath, _iMode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveAsFITS")]
        private static extern uint SaveAsFITS_cs(string szFileTitle, int type);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveAsFITS(string szFileTitle, int type)
        {
            return SaveAsFITS_cs(szFileTitle, type);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveAsRaw")]
        private static extern uint SaveAsRaw_cs(string szFileTitle, int type);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveAsRaw(string szFileTitle, int type)
        {
            return SaveAsRaw_cs(szFileTitle, type);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveAsSif")]
        private static extern uint SaveAsSif_cs(string path);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveAsSif(string path)
        {
            return SaveAsSif_cs(path);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveAsSPC")]
        private static extern uint SaveAsSPC_cs(string path);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveAsSPC(string path)
        {
            return SaveAsSPC_cs(path);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveAsTiff")]
        private static extern uint SaveAsTiff_cs(string path, string palette, int position, int type);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveAsTiff(string path, string palette, int position, int type)
        {
            return SaveAsTiff_cs(path, palette, position, type);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveAsTiffEx")]
        private static extern uint SaveAsTiffEx_cs(string path, string palette, int position, int type, int _mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveAsTiffEx(string path, string palette, int position, int type, int _mode)
        {
            return SaveAsTiffEx_cs(path, palette, position, type, _mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveEEPROMToFile")]
        private static extern uint SaveEEPROMToFile_cs(string cFileName);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveEEPROMToFile(string cFileName)
        {
            return SaveEEPROMToFile_cs(cFileName);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SaveASaveToClipBoardsSif")]
        private static extern uint SaveToClipBoard_cs(string palette);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SaveToClipBoard(string palette)
        {
            return SaveToClipBoard_cs(palette);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SelectDevice")]
        private static extern uint SelectDevice_cs(int devNum);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SelectDevice(int devNum)
        {
            return SelectDevice_cs(devNum);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SendSoftwareTrigger")]
        private static extern uint SendSoftwareTrigger_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SendSoftwareTrigger()
        {
            return SendSoftwareTrigger_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetAccumulationCycleTime")]
        private static extern uint SetAccumulationCycleTime_cs(float time);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetAccumulationCycleTime(float time)
        {
            return SetAccumulationCycleTime_cs(time);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetAcqStatusEvent")]
        private static extern uint SetAcqStatusEvent_cs(IntPtr userevent);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetAcqStatusEvent(IntPtr userevent)
        {
            return SetAcqStatusEvent_cs(userevent);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetAcquisitionMode")]
        private static extern uint SetAcquisitionMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetAcquisitionMode(int mode)
        {
            return SetAcquisitionMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetAcquisitionType")]
        private static extern uint SetAcquisitionType_cs(int type);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetAcquisitionType(int type)
        {
            return SetAcquisitionType_cs(type);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetADChannel")]
        private static extern uint SetADChannel_cs(int channel);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetADChannel(int channel)
        {
            return SetADChannel_cs(channel);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetAdvancedTriggerModeState")]
        private static extern uint SetAdvancedTriggerModeState_cs(int _istate);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetAdvancedTriggerModeState(int _istate)
        {
            return SetAdvancedTriggerModeState_cs(_istate);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetBackground")]
        private unsafe static extern uint SetBackground_cs(int* array, uint size);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint SetBackground(int[] array, uint size)
        {
            uint result;
            fixed (int* array2 = array)
            {
                result = SetBackground_cs(array2, size);
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetBaselineClamp")]
        private static extern uint SetBaselineClamp_cs(int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetBaselineClamp(int state)
        {
            return SetBaselineClamp_cs(state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetBaselineOffset")]
        private static extern uint SetBaselineOffset_cs(int offset);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetBaselineOffset(int offset)
        {
            return SetBaselineOffset_cs(offset);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetBitsPerPixel")]
        private static extern uint SetBitsPerPixel_cs(int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetBitsPerPixel(int state)
        {
            return SetBitsPerPixel_cs(state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetCameraLinkMode")]
        private static extern uint SetCameraLinkMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetCameraLinkMode(int mode)
        {
            return SetCameraLinkMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetCameraStatusEnable")]
        private static extern uint SetCameraStatusEnable_cs(int Enable);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetCameraStatusEnable(int Enable)
        {
            return SetCameraStatusEnable_cs(Enable);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetChargeShifting")]
        private static extern uint SetChargeShifting_cs(uint NumberRows, uint NumberRepeats);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetChargeShifting(uint NumberRows, uint NumberRepeats)
        {
            return SetChargeShifting_cs(NumberRows, NumberRepeats);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetComplexImage")]
        private unsafe static extern uint SetComplexImage_cs(int numAreas, int* areas);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint SetComplexImage(int numAreas, ref int areas)
        {
            int num = default(int);
            uint result = SetComplexImage_cs(numAreas, &num);
            areas = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetCoolerMode")]
        private static extern uint SetCoolerMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetCoolerMode(int mode)
        {
            return SetCoolerMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetCountConvertMode")]
        private static extern uint SetCountConvertMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetCountConvertMode(int mode)
        {
            return SetCountConvertMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetCountConvertWavelength")]
        private static extern uint SetCountConvertWavelength_cs(float wavelength);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetCountConvertWavelength(float wavelength)
        {
            return SetCountConvertWavelength_cs(wavelength);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetCropMode")]
        private static extern uint SetCropMode_cs(int active, int cropheight, int reserved);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetCropMode(int active, int cropheight, int reserved)
        {
            return SetCropMode_cs(active, cropheight, reserved);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetCurrentCamera")]
        private static extern uint SetCurrentCamera_cs(int cameraHandle);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetCurrentCamera(int cameraHandle)
        {
            return SetCurrentCamera_cs(cameraHandle);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetCustomTrackHBin")]
        private static extern uint SetCustomTrackHBin_cs(int bin);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetCustomTrackHBin(int bin)
        {
            return SetCustomTrackHBin_cs(bin);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDACOutput")]
        private static extern uint SetDACOutput_cs(int iOption, int iResolution, int iValue);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDACOutput(int iOption, int iResolution, int iValue)
        {
            return SetDACOutput_cs(iOption, iResolution, iValue);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDACOutputScale")]
        private static extern uint SetDACOutputScale_cs(int iScale);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDACOutputScale(int iScale)
        {
            return SetDACOutputScale_cs(iScale);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDataType")]
        private static extern uint SetDataType_cs(int type);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDataType(int type)
        {
            return SetDataType_cs(type);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGAddress")]
        private static extern uint SetDDGAddress_cs(byte t0, byte t1, byte t2, byte tt, byte address);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGAddress(byte t0, byte t1, byte t2, byte tt, byte address)
        {
            return SetDDGAddress_cs(t0, t1, t2, tt, address);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGExternalOutputEnabled")]
        private static extern uint SetDDGExternalOutputEnabled_cs(uint uiIndex, uint state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGExternalOutputEnabled(uint uiIndex, uint state)
        {
            return SetDDGExternalOutputEnabled_cs(uiIndex, state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGExternalOutputPolarity")]
        private static extern uint SetDDGExternalOutputPolarity_cs(uint uiIndex, uint state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGExternalOutputPolarity(uint uiIndex, uint state)
        {
            return SetDDGExternalOutputPolarity_cs(uiIndex, state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGExternalOutputStepEnabled")]
        private static extern uint SetDDGExternalOutputStepEnabled_cs(uint uiIndex, uint state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGExternalOutputStepEnabled(uint uiIndex, uint state)
        {
            return SetDDGExternalOutputStepEnabled_cs(uiIndex, state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGExternalOutputTime")]
        private static extern uint SetDDGExternalOutputTime_cs(uint uiIndex, ulong uiDelay, ulong uiWidth);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGExternalOutputTime(uint uiIndex, ulong uiDelay, ulong uiWidth)
        {
            return SetDDGExternalOutputTime_cs(uiIndex, uiDelay, uiWidth);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGGain")]
        private static extern uint SetDDGGain_cs(int gain);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGGain(int gain)
        {
            return SetDDGGain_cs(gain);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGGateStep")]
        private static extern uint SetDDGGateStep_cs(double step);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGGateStep(double step)
        {
            return SetDDGGateStep_cs(step);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGGateTime")]
        private static extern uint SetDDGGateTime_cs(ulong uiDelay, ulong uiWidth);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGGateTime(ulong uiDelay, ulong uiWidth)
        {
            return SetDDGGateTime_cs(uiDelay, uiWidth);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGInsertionDelay")]
        private static extern uint SetDDGInsertionDelay_cs(int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGInsertionDelay(int state)
        {
            return SetDDGInsertionDelay_cs(state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGIntelligate")]
        private static extern uint SetDDGIntelligate_cs(int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGIntelligate(int state)
        {
            return SetDDGIntelligate_cs(state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGIOC")]
        private static extern uint SetDDGIOC_cs(int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGIOC(int state)
        {
            return SetDDGIOC_cs(state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGIOCFrequency")]
        private static extern uint SetDDGIOCFrequency_cs(double frequency);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGIOCFrequency(double frequency)
        {
            return SetDDGIOCFrequency_cs(frequency);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGIOCNumber")]
        private static extern uint SetDDGIOCNumber_cs(uint number_pulses);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGIOCNumber(uint number_pulses)
        {
            return SetDDGIOCNumber_cs(number_pulses);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGIOCPeriod")]
        private static extern uint SetDDGIOCPeriod_cs(ulong period);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGIOCPeriod(ulong period)
        {
            return SetDDGIOCPeriod_cs(period);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGIOCTrigger")]
        private static extern uint SetDDGIOCTrigger_cs(uint trigger);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGIOCTrigger(uint trigger)
        {
            return SetDDGIOCTrigger_cs(trigger);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGOpticalWidthEnabled")]
        private static extern uint SetDDGOpticalWidthEnabled_cs(uint uiEnabled);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGOpticalWidthEnabled(uint uiEnabled)
        {
            return SetDDGOpticalWidthEnabled_cs(uiEnabled);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGStepCoefficients")]
        private static extern uint SetDDGStepCoefficients_cs(uint mode, double p1, double p2);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGStepCoefficients(uint mode, double p1, double p2)
        {
            return SetDDGStepCoefficients_cs(mode, p1, p2);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGWidthStepCoefficients")]
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static extern uint SetDDGWidthStepCoefficients_cs(uint mode, double p1, double p2);

        public static uint SetDDGWidthStepCoefficients(uint mode, double p1, double p2)
        {
            return SetDDGWidthStepCoefficients_cs(mode, p1, p2);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGStepMode")]
        private static extern uint SetDDGStepMode_cs(uint mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGStepMode(uint mode)
        {
            return SetDDGStepMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGWidthStepMode")]
        private static extern uint SetDDGWidthStepMode_cs(uint mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGWidthStepMode(uint mode)
        {
            return SetDDGWidthStepMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGTimes")]
        private static extern uint SetDDGTimes_cs(double t0, double t1, double t2);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGTimes(double t0, double t1, double t2)
        {
            return SetDDGTimes_cs(t0, t1, t2);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGTriggerMode")]
        private static extern uint SetDDGTriggerMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGTriggerMode(int mode)
        {
            return SetDDGTriggerMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDDGVariableGateStep")]
        private static extern uint SetDDGVariableGateStep_cs(int mode, double p1, double p2);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDDGVariableGateStep(int mode, double p1, double p2)
        {
            return SetDDGVariableGateStep_cs(mode, p1, p2);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDelayGenerator")]
        private static extern uint SetDelayGenerator_cs(int board, short address, int type);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDelayGenerator(int board, short address, int type)
        {
            return SetDelayGenerator_cs(board, address, type);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDMAParameters")]
        private static extern uint SetDMAParameters_cs(int MaxImagesPerDMA, float SecondsPerDMA);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDMAParameters(int MaxImagesPerDMA, float SecondsPerDMA)
        {
            return SetDMAParameters_cs(MaxImagesPerDMA, SecondsPerDMA);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDriverEvent")]
        private static extern uint SetDriverEvent_cs(IntPtr driverevent);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDriverEvent(IntPtr driverevent)
        {
            return SetDriverEvent_cs(driverevent);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetESDEvent")]
        private static extern uint SetESDEvent_cs(IntPtr driverevent);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetESDEvent(IntPtr driverevent)
        {
            return SetESDEvent_cs(driverevent);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDualExposureMode")]
        private static extern uint SetDualExposureMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDualExposureMode(int mode)
        {
            return SetDualExposureMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetDualExposureTimes")]
        private static extern uint SetDualExposureTimes_cs(float expTime1, float expTime2);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetDualExposureTimes(float expTime1, float expTime2)
        {
            return SetDualExposureTimes_cs(expTime1, expTime2);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetEMAdvanced")]
        private static extern uint SetEMAdvanced_cs(int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetEMAdvanced(int state)
        {
            return SetEMAdvanced_cs(state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetEMCCDGain")]
        private static extern uint SetEMCCDGain_cs(int gain);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetEMCCDGain(int gain)
        {
            return SetEMCCDGain_cs(gain);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetEMClockCompensation")]
        private static extern uint SetEMClockCompensation_cs(int EMClockCompensationFlag);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetEMClockCompensation(int EMClockCompensationFlag)
        {
            return SetEMClockCompensation_cs(EMClockCompensationFlag);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetEMGainMode")]
        private static extern uint SetEMGainMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetEMGainMode(int mode)
        {
            return SetEMGainMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetExposureTime")]
        private static extern uint SetExposureTime_cs(float time);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetExposureTime(float time)
        {
            return SetExposureTime_cs(time);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetExternalTriggerTermination")]
        private static extern uint SetExternalTriggerTermination_cs(uint mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetExternalTriggerTermination(uint mode)
        {
            return SetExternalTriggerTermination_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFanMode")]
        private static extern uint SetFanMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFanMode(int mode)
        {
            return SetFanMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFastExtTrigger")]
        private static extern uint SetFastExtTrigger_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFastExtTrigger(int mode)
        {
            return SetFastExtTrigger_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFastKinetics")]
        private static extern uint SetFastKinetics_cs(int exposedRows, int seriesLength, float time, int mode, int hbin, int vbin);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFastKinetics(int exposedRows, int seriesLength, float time, int mode, int hbin, int vbin)
        {
            return SetFastKinetics_cs(exposedRows, seriesLength, time, mode, hbin, vbin);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFastKineticsEx")]
        private static extern uint SetFastKineticsEx_cs(int exposedRows, int seriesLength, float time, int mode, int hbin, int vbin, int offset);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFastKineticsEx(int exposedRows, int seriesLength, float time, int mode, int hbin, int vbin, int offset)
        {
            return SetFastKineticsEx_cs(exposedRows, seriesLength, time, mode, hbin, vbin, offset);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFastKineticsStorageMode")]
        private static extern uint SetFastKineticsStorageMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFastKineticsStorageMode(int mode)
        {
            return SetFastKineticsStorageMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFastKineticsTimeScanMode")]
        private static extern uint SetFastKineticsTimeScanMode_cs(int rows, int tracks, int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFastKineticsTimeScanMode(int rows, int tracks, int mode)
        {
            return SetFastKineticsTimeScanMode_cs(rows, tracks, mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFilterMode")]
        private static extern uint SetFilterMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFilterMode(int mode)
        {
            return SetFilterMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFilterParameters")]
        private static extern uint SetFilterParameters_cs(int width, float sensitivity, int range, float accept, int smooth, int noise);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFilterParameters(int width, float sensitivity, int range, float accept, int smooth, int noise)
        {
            return SetFilterParameters_cs(width, sensitivity, range, accept, smooth, noise);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFKVShiftSpeed")]
        private static extern uint SetFKVShiftSpeed_cs(int index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFKVShiftSpeed(int index)
        {
            return SetFKVShiftSpeed_cs(index);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFPDP")]
        private static extern uint SetFPDP_cs(int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFPDP(int state)
        {
            return SetFPDP_cs(state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFrameTransferMode")]
        private static extern uint SetFrameTransferMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFrameTransferMode(int mode)
        {
            return SetFrameTransferMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFrontEndEvent")]
        private static extern uint SetFrontEndEvent_cs(IntPtr driverevent);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFrontEndEvent(IntPtr driverevent)
        {
            return SetFrontEndEvent_cs(driverevent);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFullImage")]
        private static extern uint SetFullImage_cs(int hbin, int vbin);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFullImage(int hbin, int vbin)
        {
            return SetFullImage_cs(hbin, vbin);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetFVBHBin")]
        private static extern uint SetFVBHBin_cs(int bin);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetFVBHBin(int bin)
        {
            return SetFVBHBin_cs(bin);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetGain")]
        private static extern uint SetGain_cs(int gain);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetGain(int gain)
        {
            return SetGain_cs(gain);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetGate")]
        private static extern uint SetGate_cs(float delay, float width, float step);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetGate(float delay, float width, float step)
        {
            return SetGate_cs(delay, width, step);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetGateMode")]
        private static extern uint SetGateMode_cs(int gatemode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetGateMode(int gatemode)
        {
            return SetGateMode_cs(gatemode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetHighCapacity")]
        private static extern uint SetHighCapacity_cs(int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetHighCapacity(int state)
        {
            return SetHighCapacity_cs(state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetHorizontalSpeed")]
        private static extern uint SetHorizontalSpeed_cs(int index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetHorizontalSpeed(int index)
        {
            return SetHorizontalSpeed_cs(index);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetHSSpeed")]
        private static extern uint SetHSSpeed_cs(int type, int index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetHSSpeed(int type, int index)
        {
            return SetHSSpeed_cs(type, index);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetImage")]
        private static extern uint SetImage_cs(int hbin, int vbin, int hstart, int hend, int vstart, int vend);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetImage(int hbin, int vbin, int hstart, int hend, int vstart, int vend)
        {
            return SetImage_cs(hbin, vbin, hstart, hend, vstart, vend);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetImageFlip")]
        private static extern uint SetImageFlip_cs(int iHFlip, int iVFlip);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetImageFlip(int iHFlip, int iVFlip)
        {
            return SetImageFlip_cs(iHFlip, iVFlip);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetImageRotate")]
        private static extern uint SetImageRotate_cs(int iRotate);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetImageRotate(int iRotate)
        {
            return SetImageRotate_cs(iRotate);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetIRIGModulation")]
        private static extern uint SetIRIGModulation_cs(char mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetIRIGModulation(char mode)
        {
            return SetIRIGModulation_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetIsolatedCropMode")]
        private static extern uint SetIsolatedCropMode_cs(int active, int cropheight, int cropwidth, int vbin, int hbin);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetIsolatedCropMode(int active, int cropheight, int cropwidth, int vbin, int hbin)
        {
            return SetIsolatedCropMode_cs(active, cropheight, cropwidth, vbin, hbin);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetIsolatedCropModeEx")]
        private static extern uint SetIsolatedCropModeEx_cs(int active, int cropheight, int cropwidth, int vbin, int hbin, int cropleft, int cropbottom);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetIsolatedCropModeEx(int active, int cropheight, int cropwidth, int vbin, int hbin, int cropleft, int cropbottom)
        {
            return SetIsolatedCropModeEx_cs(active, cropheight, cropwidth, vbin, hbin, cropleft, cropbottom);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetIsolatedCropModeType")]
        private static extern uint SetIsolatedCropModeType_cs(int type);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetIsolatedCropModeType(int type)
        {
            return SetIsolatedCropModeType_cs(type);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetKineticCycleTime")]
        private static extern uint SetKineticCycleTime_cs(float time);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetKineticCycleTime(float time)
        {
            return SetKineticCycleTime_cs(time);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetMCPGain")]
        private static extern uint SetMCPGain_cs(int iGain);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetMCPGain(int iGain)
        {
            return SetMCPGain_cs(iGain);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetMCPGating")]
        private static extern uint SetMCPGating_cs(int gating);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetMCPGating(int gating)
        {
            return SetMCPGating_cs(gating);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetMessageWindow")]
        private static extern uint SetMessageWindow_cs(IntPtr wnd);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetMessageWindow(IntPtr wnd)
        {
            return SetMessageWindow_cs(wnd);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetMetaData")]
        private static extern uint SetMetaData_cs(int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetMetaData(int state)
        {
            return SetMetaData_cs(state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetMultiTrack")]
        private unsafe static extern uint SetMultiTrack_cs(int number, int height, int offset, int* bottom, int* gap);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint SetMultiTrack(int number, int height, int offset, ref int bottom, ref int gap)
        {
            int num = default(int);
            int num2 = default(int);
            uint result = SetMultiTrack_cs(number, height, offset, &num, &num2);
            bottom = num;
            gap = num2;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetMultiTrackHBin")]
        private static extern uint SetMultiTrackHBin_cs(int bin);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetMultiTrackHBin(int bin)
        {
            return SetMultiTrackHBin_cs(bin);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetMultiTrackHRange")]
        private static extern uint SetMultiTrackHRange_cs(int _iStart, int _iEnd);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetMultiTrackHRange(int _iStart, int _iEnd)
        {
            return SetMultiTrackHRange_cs(_iStart, _iEnd);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetNextAddress")]
        private unsafe static extern uint SetNextAddress_cs(int* data, int lowAdd, int highAdd, int len, int physical);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint SetNextAddress(int[] data, int lowAdd, int highAdd, int len, int physical)
        {
            uint result;
            fixed (int* data2 = data)
            {
                result = SetNextAddress_cs(data2, lowAdd, highAdd, len, physical);
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetNextAddress16")]
        private unsafe static extern uint SetNextAddress16_cs(int* data, int lowAdd, int highAdd, int len, int physical);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint SetNextAddress16(int[] data, int lowAdd, int highAdd, int len, int physical)
        {
            uint result;
            fixed (int* data2 = data)
            {
                result = SetNextAddress16_cs(data2, lowAdd, highAdd, len, physical);
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetNumberAccumulations")]
        private static extern uint SetNumberAccumulations_cs(int number);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetNumberAccumulations(int number)
        {
            return SetNumberAccumulations_cs(number);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetNumberKinetics")]
        private static extern uint SetNumberKinetics_cs(int number);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetNumberKinetics(int number)
        {
            return SetNumberKinetics_cs(number);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetNumberPrescans")]
        private static extern uint SetNumberPrescans_cs(int iNumber);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetNumberPrescans(int iNumber)
        {
            return SetNumberPrescans_cs(iNumber);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetOverlapMode")]
        private static extern uint SetOverlapMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetOverlapMode(int mode)
        {
            return SetOverlapMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetOutputAmplifier")]
        private static extern uint SetOutputAmplifier_cs(int type);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetOutputAmplifier(int type)
        {
            return SetOutputAmplifier_cs(type);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetPCIMode")]
        private static extern uint SetPCIMode_cs(int mode, int value);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetPCIMode(int mode, int value)
        {
            return SetPCIMode_cs(mode, value);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetPhosphorEvent")]
        private static extern uint SetPhosphorEvent_cs(IntPtr driverevent);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetPhosphorEvent(IntPtr driverevent)
        {
            return SetPhosphorEvent_cs(driverevent);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetPhotonCounting")]
        private static extern uint SetPhotonCounting_cs(int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetPhotonCounting(int state)
        {
            return SetPhotonCounting_cs(state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetPhotonCountingDivisions")]
        private unsafe static extern uint SetPhotonCountingDivisions_cs(uint noOfDivisions, int* divisions);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint SetPhotonCountingDivisions(uint noOfDivisions, int[] divisions)
        {
            uint result;
            fixed (int* divisions2 = divisions)
            {
                result = SetPhotonCountingDivisions_cs(noOfDivisions, divisions2);
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetPhotonCountingThreshold")]
        private static extern uint SetPhotonCountingThreshold_cs(int min, int max);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetPhotonCountingThreshold(int min, int max)
        {
            return SetPhotonCountingThreshold_cs(min, max);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetPixelMode")]
        private static extern uint SetPixelMode_cs(int bitdepth, int colormode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetPixelMode(int bitdepth, int colormode)
        {
            return SetPixelMode_cs(bitdepth, colormode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetPreAmpGain")]
        private static extern uint SetPreAmpGain_cs(int index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetPreAmpGain(int index)
        {
            return SetPreAmpGain_cs(index);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetRandomTracks")]
        private unsafe static extern uint SetRandomTracks_cs(int numTracks, int* areas);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint SetRandomTracks(int numTracks, int[] areas)
        {
            uint result;
            fixed (int* areas2 = areas)
            {
                result = SetRandomTracks_cs(numTracks, areas2);
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetReadMode")]
        private static extern uint SetReadMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetReadMode(int mode)
        {
            return SetReadMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetReadoutRegisterPacking")]
        private static extern uint SetReadoutRegisterPacking_cs(uint mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetReadoutRegisterPacking(uint mode)
        {
            return SetReadoutRegisterPacking_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetRegisterDump")]
        private static extern uint SetRegisterDump_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetRegisterDump(int mode)
        {
            return SetRegisterDump_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetRingExposureTimes")]
        private unsafe static extern uint SetRingExposureTimes_cs(int numTimes, float* times);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint SetRingExposureTimes(int numTimes, float[] times)
        {
            uint result;
            fixed (float* times2 = times)
            {
                result = SetRingExposureTimes_cs(numTimes, times2);
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetSaturationEvent")]
        private static extern uint SetSaturationEvent_cs(IntPtr userevent);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetSaturationEvent(IntPtr userevent)
        {
            return SetSaturationEvent_cs(userevent);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetShutter")]
        private static extern uint SetShutter_cs(int type, int mode, int closingtime, int openingtime);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetShutter(int type, int mode, int closingtime, int openingtime)
        {
            return SetShutter_cs(type, mode, closingtime, openingtime);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetShutterEx")]
        private static extern uint SetShutterEx_cs(int type, int mode, int closingtime, int openingtime, int ext_mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetShutterEx(int type, int mode, int closingtime, int openingtime, int ext_mode)
        {
            return SetShutterEx_cs(type, mode, closingtime, openingtime, ext_mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetShutters")]
        private static extern uint SetShutters_cs(int type, int mode, int closingtime, int openingtime, int ext_type, int ext_mode, int dummy1, int dummy2);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetShutters(int type, int mode, int closingtime, int openingtime, int ext_type, int ext_mode, int dummy1, int dummy2)
        {
            return SetShutters_cs(type, mode, closingtime, openingtime, ext_type, ext_mode, dummy1, dummy2);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetSifComment")]
        private static extern uint SetSifComment_cs(string comment);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetSifComment(string comment)
        {
            return SetSifComment_cs(comment);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetSingleTrack")]
        private static extern uint SetSingleTrack_cs(int centre, int height);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetSingleTrack(int centre, int height)
        {
            return SetSingleTrack_cs(centre, height);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetSingleTrackHBin")]
        private static extern uint SetSingleTrackHBin_cs(int bin);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetSingleTrackHBin(int bin)
        {
            return SetSingleTrackHBin_cs(bin);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetSpool")]
        private static extern uint SetSpool_cs(int active, int method, string path, int framebuffersize);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetSpool(int active, int method, string path, int framebuffersize)
        {
            return SetSpool_cs(active, method, path, framebuffersize);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetSpoolThreadCount")]
        private static extern uint SetSpoolThreadCount_cs(int count);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetSpoolThreadCount(int count)
        {
            return SetSpoolThreadCount_cs(count);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetStorageMode")]
        private static extern uint SetStorageMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetStorageMode(int mode)
        {
            return SetStorageMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetSensorPortMode")]
        private static extern uint SetSensorPortMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetSensorPortMode(int mode)
        {
            return SetSensorPortMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SelectSensorPort")]
        private static extern uint SelectSensorPort_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SelectSensorPort(int mode)
        {
            return SelectSensorPort_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SelectDualSensorPort")]
        private static extern uint SelectDualSensorPort_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SelectDualSensorPort(int mode)
        {
            return SelectDualSensorPort_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetTECEvent")]
        private static extern uint SetTECEvent_cs(IntPtr driverevent);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetTECEvent(IntPtr driverevent)
        {
            return SetTECEvent_cs(driverevent);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetTemperature")]
        private static extern uint SetTemperature_cs(int temperature);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetTemperature(int temperature)
        {
            return SetTemperature_cs(temperature);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetTriggerInvert")]
        private static extern uint SetTriggerInvert_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetTriggerInvert(int mode)
        {
            return SetTriggerInvert_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetTriggerLevel")]
        private static extern uint SetTriggerLevel_cs(float mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetTriggerLevel(float mode)
        {
            return SetTriggerLevel_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetTriggerMode")]
        private static extern uint SetTriggerMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetTriggerMode(int mode)
        {
            return SetTriggerMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetIODirection")]
        private static extern uint SetIODirection_cs(int index, int iDirection);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetIODirection(int index, int iDirection)
        {
            return SetIODirection_cs(index, iDirection);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetIOLevel")]
        private static extern uint SetIOLevel_cs(int index, int iLevel);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetIOLevel(int index, int iLevel)
        {
            return SetIOLevel_cs(index, iLevel);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetUserEvent")]
        private static extern uint SetUserEvent_cs(IntPtr userevent);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetUserEvent(IntPtr userevent)
        {
            return SetUserEvent_cs(userevent);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetUSGenomics")]
        private static extern uint SetUSGenomics_cs(int width, int height);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetUSGenomics(int width, int height)
        {
            return SetUSGenomics_cs(width, height);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetVerticalRowBuffer")]
        private static extern uint SetVerticalRowBuffer_cs(int rows);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetVerticalRowBuffer(int rows)
        {
            return SetVerticalRowBuffer_cs(rows);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetVerticalSpeed")]
        private static extern uint SetVerticalSpeed_cs(int index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetVerticalSpeed(int index)
        {
            return SetVerticalSpeed_cs(index);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetVirtualChip")]
        private static extern uint SetVirtualChip_cs(int state);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetVirtualChip(int state)
        {
            return SetVirtualChip_cs(state);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetVSAmplitude")]
        private static extern uint SetVSAmplitude_cs(int index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetVSAmplitude(int index)
        {
            return SetVSAmplitude_cs(index);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "SetVSSpeed")]
        private static extern uint SetVSSpeed_cs(int index);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint SetVSSpeed(int index)
        {
            return SetVSSpeed_cs(index);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "ShutDown")]
        private static extern uint ShutDown_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint ShutDown()
        {
            return ShutDown_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "StartAcquisition")]
        private static extern uint StartAcquisition_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint StartAcquisition()
        {
            return StartAcquisition_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "UnMapPhysicalAddress")]
        private static extern uint UnMapPhysicalAddress_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint UnMapPhysicalAddress()
        {
            return UnMapPhysicalAddress_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "UpdateDDGTimings")]
        private static extern uint UpdateDDGTimings_cs();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint UpdateDDGTimings()
        {
            return UpdateDDGTimings_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "WaitForAcquisition")]
        private static extern uint WaitForAcquisition_cs();

        public static uint WaitForAcquisition()
        {
            return WaitForAcquisition_cs();
        }

        [DllImport("atmcd64d.dll", EntryPoint = "WaitForAcquisitionByHandle")]
        private static extern uint WaitForAcquisitionByHandle_cs(int cameraHandle);

        public static uint WaitForAcquisitionByHandle(int cameraHandle)
        {
            return WaitForAcquisitionByHandle_cs(cameraHandle);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "WaitForAcquisitionByHandleTimeOut")]
        private static extern uint WaitForAcquisitionByHandleTimeOut_cs(int cameraHandle, int _iTimeOutMs);

        public static uint WaitForAcquisitionByHandleTimeOut(int cameraHandle, int _iTimeOutMs)
        {
            return WaitForAcquisitionByHandleTimeOut_cs(cameraHandle, _iTimeOutMs);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "WaitForAcquisitionTimeOut")]
        private static extern uint WaitForAcquisitionTimeOut_cs(int _iTimeOutMs);

        public static uint WaitForAcquisitionTimeOut(int _iTimeOutMs)
        {
            return WaitForAcquisitionTimeOut_cs(_iTimeOutMs);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "WhiteBalance")]
        private unsafe static extern uint WhiteBalance_cs(ushort* _wRed, ushort* _wGreen, ushort* _wBlue, float* _fRelR, float* _fRelB, WhiteBalanceInfo* _info);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint WhiteBalance(ushort[] _wRed, ushort[] _wGreen, ushort[] _wBlue, float[] _fRelR, float[] _fRelB, ref WhiteBalanceInfo _info)
        {
            uint result;
            WhiteBalanceInfo whiteBalanceInfo = default(WhiteBalanceInfo);
            fixed (ushort* wRed = _wRed)
            {
                fixed (ushort* wGreen = _wGreen)
                {
                    fixed (ushort* wBlue = _wBlue)
                    {
                        fixed (float* fRelR = _fRelR)
                        {
                            fixed (float* fRelB = _fRelB)
                            {
                                result = WhiteBalance_cs(wRed, wGreen, wBlue, fRelR, fRelB, &whiteBalanceInfo);
                            }
                        }
                    }
                }
            }
            _info = whiteBalanceInfo;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_Initialize")]
        private static extern uint OA_Initialize_cs(string dir, uint uiFileNameLen);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint OA_Initialize(string dir, uint uiFileNameLen)
        {
            return OA_Initialize_cs(dir, uiFileNameLen);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_EnableMode")]
        private static extern uint OA_EnableMode_cs(string pcModeName);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint OA_EnableMode(string pcModeName)
        {
            return OA_EnableMode_cs(pcModeName);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_IsPreSetModeAvailable")]
        private static extern uint OA_IsPreSetModeAvailable_cs(string pcModeName);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint OA_IsPreSetModeAvailable(string pcModeName)
        {
            return OA_IsPreSetModeAvailable_cs(pcModeName);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_GetModeAcqParams")]
        private unsafe static extern uint OA_GetModeAcqParams_cs(string pcModeName, sbyte* pcListOfParams);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint OA_GetModeAcqParams(string pcModeName, ref string pcListOfParams)
        {
            sbyte[] array = new sbyte[2048];
            uint result;
            fixed (sbyte* pcListOfParams2 = array)
            {
                result = OA_GetModeAcqParams_cs(pcModeName, pcListOfParams2);
            }
            for (int i = 0; i < 2048 && array[i] != 0; i++)
            {
                pcListOfParams += (char)array[i];
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_GetUserModeNames")]
        private unsafe static extern uint OA_GetUserModeNames_cs(sbyte* pcListOfModes);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint OA_GetUserModeNames(ref string pcListOfModes)
        {
            sbyte[] array = new sbyte[2048];
            uint result;
            fixed (sbyte* pcListOfModes2 = array)
            {
                result = OA_GetUserModeNames_cs(pcListOfModes2);
            }
            for (int i = 0; i < 2048 && array[i] != 0; i++)
            {
                pcListOfModes += (char)array[i];
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_GetPreSetModeNames")]
        private unsafe static extern uint OA_GetPreSetModeNames_cs(sbyte* pcListOfModes);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint OA_GetPreSetModeNames(ref string pcListOfModes)
        {
            sbyte[] array = new sbyte[2048];
            uint result;
            fixed (sbyte* pcListOfModes2 = array)
            {
                result = OA_GetPreSetModeNames_cs(pcListOfModes2);
            }
            for (int i = 0; i < 2048 && array[i] != 0; i++)
            {
                pcListOfModes += (char)array[i];
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_GetNumberOfUserModes")]
        private unsafe static extern uint OA_GetNumberOfUserModes_cs(uint* puiNumberOfModes);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint OA_GetNumberOfUserModes(ref uint puiNumberOfModes)
        {
            uint num = default(uint);
            uint result = OA_GetNumberOfUserModes_cs(&num);
            puiNumberOfModes = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_GetNumberOfPreSetModes")]
        private unsafe static extern uint OA_GetNumberOfPreSetModes_cs(uint* puiNumberOfModes);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint OA_GetNumberOfPreSetModes(ref uint puiNumberOfModes)
        {
            uint num = default(uint);
            uint result = OA_GetNumberOfPreSetModes_cs(&num);
            puiNumberOfModes = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_GetNumberOfAcqParams")]
        private unsafe static extern uint OA_GetNumberOfAcqParams_cs(string pcModeName, uint* puiNumberOfParams);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint OA_GetNumberOfAcqParams(string pcModeName, ref uint puiNumberOfParams)
        {
            uint num = default(uint);
            uint result = OA_GetNumberOfAcqParams_cs(pcModeName, &num);
            puiNumberOfParams = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_AddMode")]
        private static extern uint OA_AddMode_cs(string pcModeName, uint uiModeNameLen, string pcModeDescription, uint uiModeDescriptionLen);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint OA_AddMode(string pcModeName, uint uiModeNameLen, string pcModeDescription, uint uiModeDescriptionLen)
        {
            return OA_AddMode_cs(pcModeName, uiModeNameLen, pcModeDescription, uiModeDescriptionLen);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_WriteToFile")]
        private static extern uint OA_WriteToFile_cs(string pcFileName, uint uiFileNameLen);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint OA_WriteToFile(string pcFileName, uint uiFileNameLen)
        {
            return OA_WriteToFile_cs(pcFileName, uiFileNameLen);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_DeleteMode")]
        private static extern uint OA_DeleteMode_cs(string pcModeName, uint uiFModeNameLen);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint OA_DeleteMode(string pcModeName, uint uiModeNameLen)
        {
            return OA_DeleteMode_cs(pcModeName, uiModeNameLen);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_SetInt")]
        private static extern uint OA_SetInt_cs(string pcModeName, string pcModeParam, int iIntValue);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint OA_SetInt(string pcModeName, string pcModeParam, int iIntValue)
        {
            return OA_SetInt_cs(pcModeName, pcModeParam, iIntValue);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_SetFloat")]
        private static extern uint OA_SetFloat_cs(string pcModeName, string pcModeParam, float fFloatValue);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint OA_SetFloat(string pcModeName, string pcModeParam, float fFloatValue)
        {
            return OA_SetFloat_cs(pcModeName, pcModeParam, fFloatValue);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_SetString")]
        private static extern uint OA_SetString_cs(string pcModeName, string pcModeParam, string pcStringValue, uint uiStringLen);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint OA_SetString(string pcModeName, string pcModeParam, string pcStringValue, uint uiStringLen)
        {
            return OA_SetString_cs(pcModeName, pcModeParam, pcStringValue, uiStringLen);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_GetInt")]
        private unsafe static extern uint OA_GetInt_cs(string pcModeName, string pcModeParam, int* iIntValue);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint OA_GetInt(string pcModeName, string pcModeParam, ref int iIntValue)
        {
            int num = default(int);
            uint result = OA_GetInt_cs(pcModeName, pcModeParam, &num);
            iIntValue = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_GetFloat")]
        private unsafe static extern uint OA_GetFloat_cs(string pcModeName, string pcModeParam, float* fFloatValue);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint OA_GetFloat(string pcModeName, string pcModeParam, ref float fFloatValue)
        {
            float num = default(float);
            uint result = OA_GetFloat_cs(pcModeName, pcModeParam, &num);
            fFloatValue = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "OA_GetString")]
        private unsafe static extern uint OA_GetString_cs(string pcModeName, string pcModeParam, sbyte* pcStringValue, uint uiStringLen);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint OA_GetString(string pcModeName, string pcModeParam, ref string pcStringValue, uint uiStringLen)
        {
            sbyte[] array = new sbyte[uiStringLen];
            uint result;
            fixed (sbyte* pcStringValue2 = array)
            {
                result = OA_GetString_cs(pcModeName, pcModeParam, pcStringValue2, uiStringLen);
            }
            for (uint num = 0u; num < uiStringLen && array[num] != 0; num++)
            {
                pcStringValue += (char)array[num];
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Filter_SetMode")]
        private static extern uint Filter_SetMode_cs(uint mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint Filter_SetMode(uint mode)
        {
            return Filter_SetMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Filter_GetMode")]
        private unsafe static extern uint Filter_GetMode_cs(uint* mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint Filter_GetMode(ref uint mode)
        {
            uint num = default(uint);
            uint result = Filter_GetMode_cs(&num);
            mode = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Filter_SetThreshold")]
        private static extern uint Filter_SetThreshold_cs(float threshold);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint Filter_SetThreshold(float threshold)
        {
            return Filter_SetThreshold_cs(threshold);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Filter_GetThreshold")]
        private unsafe static extern uint Filter_GetThreshold_cs(float* threshold);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint Filter_GetThreshold(ref float threshold)
        {
            float num = default(float);
            uint result = Filter_GetThreshold_cs(&num);
            threshold = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Filter_SetDataAveragingMode")]
        private static extern uint Filter_SetDataAveragingMode_cs(int mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint Filter_SetDataAveragingMode(int mode)
        {
            return Filter_SetDataAveragingMode_cs(mode);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Filter_GetDataAveragingMode")]
        private unsafe static extern uint Filter_GetDataAveragingMode_cs(int* mode);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint Filter_GetDataAveragingMode(ref int mode)
        {
            int num = default(int);
            uint result = Filter_GetDataAveragingMode_cs(&num);
            mode = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Filter_SetAveragingFrameCount")]
        private static extern uint Filter_SetAveragingFrameCount_cs(int frames);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint Filter_SetAveragingFrameCount(int frames)
        {
            return Filter_SetAveragingFrameCount_cs(frames);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Filter_GetAveragingFrameCount")]
        private unsafe static extern uint Filter_GetAveragingFrameCount_cs(int* frames);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint Filter_GetAveragingFrameCount(ref int frames)
        {
            int num = default(int);
            uint result = Filter_GetAveragingFrameCount_cs(&num);
            frames = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Filter_SetAveragingFactor")]
        private static extern uint Filter_SetAveragingFactor_cs(int averagingFactor);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static uint Filter_SetAveragingFactor(int averagingFactor)
        {
            return Filter_SetAveragingFactor_cs(averagingFactor);
        }

        [DllImport("atmcd64d.dll", EntryPoint = "Filter_GetAveragingFactor")]
        private unsafe static extern uint Filter_GetAveragingFactor_cs(int* averagingFactor);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint Filter_GetAveragingFactor(ref int averagingFactor)
        {
            int num = default(int);
            uint result = Filter_GetAveragingFactor_cs(&num);
            averagingFactor = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "PostProcessNoiseFilter")]
        private unsafe static extern uint PostProcessNoiseFilter_cs(int* pInputImage, int* pOutputImage, int iOutputBufferSize, int iBaseline, int iMode, float fThreshold, int iHeight, int iWidth);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint PostProcessNoiseFilter(int[] pInputImage, int[] pOutputImage, int iOutputBufferSize, int iBaseline, int iMode, float fThreshold, int iHeight, int iWidth)
        {
            uint result;
            fixed (int* pInputImage2 = pInputImage)
            {
                fixed (int* pOutputImage2 = pOutputImage)
                {
                    result = PostProcessNoiseFilter_cs(pInputImage2, pOutputImage2, iOutputBufferSize, iBaseline, iMode, fThreshold, iHeight, iWidth);
                }
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "PostProcessCountConvert")]
        private unsafe static extern uint PostProcessCountConvert_cs(int* pInputImage, int* pOutputImage, int iOutputBufferSize, int iNumImages, int iBaseline, int iMode, int iEmGain, float fQE, float fSensitivity, int iHeight, int iWidth);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint PostProcessCountConvert(int[] pInputImage, int[] pOutputImage, int iOutputBufferSize, int iNumImages, int iBaseline, int iMode, int iEmGain, float fQE, float fSensitivity, int iHeight, int iWidth)
        {
            uint result;
            fixed (int* pInputImage2 = pInputImage)
            {
                fixed (int* pOutputImage2 = pOutputImage)
                {
                    result = PostProcessCountConvert_cs(pInputImage2, pOutputImage2, iOutputBufferSize, iNumImages, iBaseline, iMode, iEmGain, fQE, fSensitivity, iHeight, iWidth);
                }
            }
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "PostProcessPhotonCounting")]
        private unsafe static extern uint PostProcessPhotonCounting_cs(int* pInputImage, int* pOutputImage, int iOutputBufferSize, int iNumImages, int iNumframes, int iNumberOfThresholds, float* pfThreshold, int iHeight, int iWidth);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint PostProcessPhotonCounting(int[] pInputImage, int[] pOutputImage, int iOutputBufferSize, int iNumImages, int iNumframes, int iNumberOfThresholds, ref float pfThreshold, int iHeight, int iWidth)
        {
            uint result;
            float num = default(float);
            fixed (int* pInputImage2 = pInputImage)
            {
                fixed (int* pOutputImage2 = pOutputImage)
                {
                    result = PostProcessPhotonCounting_cs(pInputImage2, pOutputImage2, iOutputBufferSize, iNumImages, iNumframes, iNumberOfThresholds, &num, iHeight, iWidth);
                }
            }
            pfThreshold = num;
            return result;
        }

        [DllImport("atmcd64d.dll", EntryPoint = "PostProcessDataAveraging")]
        private unsafe static extern uint PostProcessDataAveraging_cs(int* pInputImage, int* pOutputImage, int iOutputBufferSize, int iNumImages, int iAveragingFilterMode, int iHeight, int iWidth, int iFrameCount, int iAveragingFactor);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public unsafe static uint PostProcessDataAveraging(int[] pInputImage, int[] pOutputImage, int iOutputBufferSize, int iNumImages, int iAveragingFilterMode, int iHeight, int iWidth, int iFrameCount, int iAveragingFactor)
        {
            uint result;
            fixed (int* pInputImage2 = pInputImage)
            {
                fixed (int* pOutputImage2 = pOutputImage)
                {
                    result = PostProcessDataAveraging_cs(pInputImage2, pOutputImage2, iOutputBufferSize, iNumImages, iAveragingFilterMode, iHeight, iWidth, iFrameCount, iAveragingFactor);
                }
            }
            return result;
        }
    }
}
