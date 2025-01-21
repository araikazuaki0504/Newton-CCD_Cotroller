using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTD2XX_NET;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CCD_controller_windows_form
{
    public partial class mainForm
    {
        #region PUBLIC SCOPE VARIABLES...

        private int ROI_Xsize;
        private int ROI_Ysize;

        private bool FullBin = true;
        private bool series = false;

        public CancellationTokenSource exposure_tokenSource = new CancellationTokenSource();
        private DisplayGraphForm camera_datagraphform;
        private Import_Image_Viewer CCDImage_viewer;
        private ImageForm camera_imageform;

        private double[] spectrum;
        private double[] calibratedXAxis;
        private string calibrationInfo = "";
        private string unit = "Pixel";

        UInt32 FtdiDeviceCount = 0;
        FTDI.FT_STATUS FtStatus = FTDI.FT_STATUS.FT_OK;
        bool bFTDI_error = false;

        FTDI.FT_DEVICE_INFO_NODE[] FtdiDeviceList;
        FTDI FtdiFIFO = new FTDI();
        FTDI FtdiUART = new FTDI();

        int CamSerialNo;
        float CamADCCal0, CamADCCal40, CamDACCal0, CamDACCal40;
        string CamBuildDate, CamBuildCode, CamFPGAVer, CamMSPVer;

        Int32 XDim, YDim, XSize, YSize, XBin, YBin;
        UInt16[] Frame_16bit;
        UInt16[] BackGround_Frame_16bit;
        FileStream Fs;
        BinaryWriter W;

        float TEC_DAC_gradient = 19.531f;
        float TEC_DAC_intercept = -47.248f;
        float TEC_ADC_gradient = 9.832f;
        float TEC_ADC_intercept = 163.77f;


        #endregion


        #region CONSTANTS

        static public class Constants
        {
            public const int GUI_VERSION_MAJOR = 1;
            public const int GUI_VERSION_MINOR = 0;
            public const int FT_PURGE_RX = 1;
            public const int FT_PURGE_TX = 2;
            public const int RX_BUF_LEN = 128;
            public const int INVALID_CMD = 255;
            public const int ACK_RXD = 0x50;
            public const int NACK_RXD = 254;
            public const int RX_TIMEOUT = 253;

            public const int ETX = 0x50;
            public const int ETX_SER_TIMEOUT = 0x51;
            public const int ETX_CK_SUM_ERR = 0x52;
            public const int ETX_I2C_ERR = 0x53;
            public const int ETX_UNKNOWN_CMD = 0x54;
            public const int ETX_DONE_LOW = 0x55;
            public const int CL_ERR_TIMEOUT = -10004;

            public const int EXP_SCALE = 40000;
            public const int EXP_SCALE_SECS = 40000000;

            public const int H_CLK_SPEED = 500;
            public const int V_CLK_SPEED = 32;
            public const int USB_SPEED = 8;
            public const int DARK_SMPL_CNT = 3048;

            public const string RAW_IMG_FILEPATH_DIR = @"C:\TOUCAN_FTDI_IMAGE\";
            public const string RAW_IMG_FILEPATH_EXT = ".data";
        }

        #endregion


        #region COMMAND ACK AND CHECKSUM...
        private int cmdAckInt()
        {
            int result = 0;
            if (true)
            {
                result = 1;
            }
            return result;
        }

        private int chkSumInt()
        {
            int result = 0;
            if (true)
            {
                result = 1;
            }
            return result;
        }

        private void getSerNoAndBuildData_FPGA_MSVVersion()
        {
            byte[] array = new byte[Constants.RX_BUF_LEN];
            bool flag = true;
            TxPacket("4F 53 50", 0);
            array = TxPacket("49 50", 1);
            if ((array[0] &= 4) == 0)
            {
                flag = false;
            }
            if (!flag)
            {
                TxPacket("4F 51 50", 0);
            }
            TxPacket("53 AE 05 01 00 00 02 00 50", 0);
            array = TxPacket("53 AF 12 50", 18);
            TxPacket("4F 52 50", 0);
            CamSerialNo = array[1] * 256 + array[0];
            CamBuildDate = array[2].ToString().PadLeft(2, '0') + "/" + array[3].ToString().PadLeft(2, '0') + "/" + array[4].ToString().PadLeft(2, '0');
            string[] array2 = new string[5];
            char c = (char)array[5];
            array2[0] = c.ToString();
            c = (char)array[6];
            array2[1] = c.ToString();
            c = (char)array[7];
            array2[2] = c.ToString();
            c = (char)array[8];
            array2[3] = c.ToString();
            c = (char)array[9];
            array2[4] = c.ToString();
            CamBuildCode = string.Concat(array2);
            CamADCCal0 = array[11] * 256 + array[10];
            CamADCCal40 = array[13] * 256 + array[12];
            CamDACCal0 = array[15] * 256 + array[14];
            CamDACCal40 = array[17] * 256 + array[16];
            array = TxPacket(i2cReadReg("7E"), 0);
            array = TxPacket(i2cRead(), 1);
            CamFPGAVer = Convert.ToString(array[0]);
            array = TxPacket(i2cReadReg("7F"), 0);
            array = TxPacket(i2cRead(), 1);
            CamFPGAVer = CamFPGAVer + "." + Convert.ToString(array[0]);
            array = TxPacket("56 50", 2);
            CamMSPVer = Convert.ToString(array[0]) + "." + Convert.ToString(array[1]);
            MessageBox.Show("Camera loaded!" + Environment.NewLine + "Camera Serial No.: " + CamSerialNo + Environment.NewLine + "Camera Build Date:" + CamBuildDate.ToString() + Environment.NewLine + "Camera Build Code" + CamBuildCode.ToString() + Environment.NewLine + "FPGA Firmware Version:" + CamFPGAVer.ToString() + Environment.NewLine + "MSP Firmware Vesrion:" + CamMSPVer.ToString());
        }

        #endregion


        #region GET REGISTER COMMANDS...
        private void getPCBTemp()
        {
            byte[] array = new byte[128];
            TxPacket(i2cWriteReg("70", "00"), 0);
            array = TxPacket(i2cRead(), 1);
            int num = array[0];
            TxPacket(i2cWriteReg("71", "00"), 0);
            array = TxPacket(i2cRead(), 1);
            num = num * 256 + array[0];
            array[1] = (byte)(num * 16);
            array[0] = (byte)(num / 16);
            if (array[0] < 128)
            {
                lbl_PCB_Temp.Text = Convert.ToString(array[0]) + "." + Convert.ToString(array[1] / 16 * 625).PadLeft(2, '0').Substring(0, 2);
            }
            else
            {
                lbl_PCB_Temp.Text = Convert.ToString("-" + (256 - array[0])) + "." + Convert.ToString((16 - array[1] / 16) * 625).PadLeft(2, '0').Substring(0, 2);
            }
        }

        private void getCCDTemp()
        {
            byte[] array = new byte[128];
            TxPacket(i2cWriteReg("6E", "00"), 0);
            array = TxPacket(i2cRead(), 1);
            int num = array[0];
            TxPacket(i2cWriteReg("6F", "00"), 0);
            array = TxPacket(i2cRead(), 1);
            num = num * 256 + array[0];
            lbl_CCD_Temp.Text = num.ToString();
            lbl_CCD_Temp.Text = ((float)num * TEC_ADC_gradient + TEC_ADC_intercept).ToString("F");
        }

        private string i2cWriteReg(string reg, string data)
        {
            return "53 E0 02 " + reg + " " + data + " 50";
        }

        private string i2cReadReg(string reg)
        {
            return "53 E0 01 " + reg + " 50";
        }

        private string i2cRead()
        {
            return "53 E1 01 50";
        }

        private byte setFPGAregbit(int bit, string reg)
        {
            int num = 1;
            byte[] array = new byte[128];
            TxPacket(i2cReadReg(reg), 0);
            array = TxPacket(i2cRead(), 1);
            array[0] |= Convert.ToByte(num << bit);
            byte b = array[0];
            TxPacket(i2cWriteReg(reg, b.ToString("X").PadLeft(2, '0')), 0);
            return array[0];
        }

        private byte resetFPGAregbit(int bit, string reg)
        {
            int num = 1;
            byte[] array = new byte[128];
            TxPacket(i2cReadReg(reg), 0);
            array = TxPacket(i2cRead(), 1);
            array[0] &= Convert.ToByte(0xFF ^ (num << bit));
            byte b = array[0];
            TxPacket(i2cWriteReg(reg, b.ToString("X").PadLeft(2, '0')), 0);
            return array[0];
        }

        private void getYDim()
        {
            byte[] array = new byte[128];
            TxPacket(i2cReadReg("B8"), 0);
            array = TxPacket(i2cRead(), 1);
            YSize = array[0] << 8;
            TxPacket(i2cReadReg("B9"), 0);
            array = TxPacket(i2cRead(), 1);
            YSize |= array[0];
            TxPacket(i2cReadReg("A2"), 0);
            array = TxPacket(i2cRead(), 1);
            YBin = array[0];
            if ((Convert.ToByte(YBin) & 0x80u) != 0)
            {
                YBin = 263;
            }
            YDim = YSize / (YBin + 1);
        }

        private void getXDim()
        {
            byte[] array = new byte[128];
            TxPacket(i2cReadReg("B4"), 0);
            array = TxPacket(i2cRead(), 1);
            XSize = array[0] << 8;
            TxPacket(i2cReadReg("B5"), 0);
            array = TxPacket(i2cRead(), 1);
            XSize |= array[0];
            TxPacket(i2cReadReg("A1"), 0);
            array = TxPacket(i2cRead(), 1);
            XBin = array[0];
            XDim = XSize / (XBin + 1);
        }

        #endregion


        #region FTDI SERIAL COMMS...
        private byte[] TxPacket(String txText, int rxLen)
        {
            int num = (txText.Length + 1) / 3 + chkSumInt();
            byte[] array = new byte[num];
            byte[] array2 = new byte[2];
            byte[] array3 = new byte[1];
            byte[] array4 = new byte[128];
            int num2 = 0;
            int num3 = 0;
            byte b = 0;
            array2[0] = 80;
            array2[1] = 80;
            array4[127] = 0;
            if (bFTDI_error)
            {
                return array4;
            }
            if (num2 < 2)
            {
                num = (txText.Length + 1) / 3 + chkSumInt();
                num3 = 0;
                FtStatus = FtdiUART.Purge(3u);
                for (int i = 0; i < num - chkSumInt(); i++)
                {
                    if (Regex.IsMatch(txText.Substring(i * 3, 2), "\\A\\b[0-9a-fA-F]+\\b\\Z"))
                    {
                        array[i] = (byte)Convert.ToInt32(txText.Substring(i * 3, 2), 16);
                        b ^= array[i];
                        continue;
                    }
                    
                    array4[127] = byte.MaxValue;
                    return array4;
                }

                if (true)
                {
                    array[num - 1] = b;
                }

                uint numBytesWritten = 0u;
                FtStatus = FtdiUART.Write(array, array.Length, ref numBytesWritten);
                if (FtStatus != 0)
                {
                    MessageBox.Show("Failed to write to serial port (error " + FtStatus.ToString() + ")", "Serial Port Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    bFTDI_error = true;
                    return array4;
                }
                FtStatus = FtdiUART.SetTimeouts(20u, 0u);
                while (rxLen + cmdAckInt() + chkSumInt() != 0 && num3 != rxLen + cmdAckInt() + chkSumInt())
                {
                    byte[] array5 = new byte[64];
                    uint numBytesRead = 0u;
                    FtStatus = FtdiUART.Read(array5, 1u, ref numBytesRead);
                    
                    if (FtStatus == FTDI.FT_STATUS.FT_OK && numBytesRead == 1)
                    {
                        array3[0] = array5[0];
                        array4[num3] = array3[0];
                        if (num3 < rxLen)
                        {
                            array4[num3] = array3[0];
                        }
                        num3++;
                    }
                }
                
                if (array[0] != 73)
                {
                    if (num3 == 0)
                    {
                        array4[127] = 254;
                        return array4;
                    }
                    if (num3 < 2)
                    {
                        return array4;
                    }
                    if (array4[num3 - 1 - chkSumInt()] == 81)
                    {
                        array4[127] = 254;
                        return array4;
                    }
                    if (array4[num3 - 1 - chkSumInt()] == 82)
                    {
                        array4[127] = 254;
                        return array4;
                    }
                    if (array4[num3 - 1 - chkSumInt()] == 83)
                    {
                        array4[127] = 254;
                        return array4;
                    }
                    if (array4[num3 - 1 - chkSumInt()] == 84)
                    {
                        array4[127] = 254;
                        return array4;
                    }
                    if (array4[num3 - 1 - chkSumInt()] == 85)
                    {
                        array4[127] = 254;
                        return array4;
                    }
                    if (array4[num3 - 1 - chkSumInt()] != 80)
                    {
                        array4[127] = 254;
                        return array4;
                    }
                    if (array4[num3 - 1] != b)
                    {
                        array4[127] = 254;
                        return array4;
                    }
                }
            }
            return array4;
        }
        #endregion


        #region initial set up...
        private void initializeXAxis()
        {
            calibratedXAxis = new double[XDim];
            spectrum = new double[XDim];
            for (int i = 0; i < XDim; i++)
            {
                calibratedXAxis[i] = i;
            }
        }

        private int loadCamera()
        {
            int num = 0;
            searchFTDIDevices();
            if (FtdiDeviceCount == 0)
            {
                MessageBox.Show("No devices detected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return -1;
            }
            num = autoOpenFTDIDevices();
            if (FtStatus != 0)
            {
                MessageBox.Show("FT Error Opening Device!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return -1;
            }
            num = setupFtdiUART();
            FtStatus = FtdiFIFO.Purge(3u);
            if (num != -1)
            {
                getCameraStatus();
                Binning_setting_for_load();
                regulary_timer.Enabled = true;
                rdBttn_ms_forExpTime.Checked = true;
                nmrcUpDwn_Exposure_Time.Value = 1m;
                changedExposure(Convert.ToInt32(nmrcUpDwn_Exposure_Time.Value));
            }
            return 0;
        }

        private void searchFTDIDevices()
        {
            FtStatus = FtdiUART.GetNumberOfDevices(ref FtdiDeviceCount);
            if (FtStatus == FTDI.FT_STATUS.FT_OK)
            {
                if (FtdiDeviceCount == 0)
                {
                    MessageBox.Show("Failed to detect any devices (error " + FtStatus.ToString() + ")", "No FTDI Devices Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                FtdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[FtdiDeviceCount];
                FtStatus = FtdiUART.GetDeviceList(FtdiDeviceList);
            }
            else
            {
                MessageBox.Show("Failed to get number of devices (error " + FtStatus.ToString() + ")", "FTDI Number of Devices Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private int autoOpenFTDIDevices()
        {
            bool flag = false;
            bool flag2 = false;
            for (int i = 0; i < FtdiDeviceCount; i++)
            {
                if (!FtdiDeviceList[i].Type.ToString().ToUpper().Contains("2232H"))
                {
                    continue;
                }
                if (FtdiDeviceList[i].SerialNumber.ToString().EndsWith("A") && !flag)
                {
                    FtStatus = FtdiUART.OpenBySerialNumber(FtdiDeviceList[i].SerialNumber);
                    if (FtStatus != 0)
                    {
                        MessageBox.Show("Failed to open device (error " + FtStatus.ToString() + ")", "FTDI Device Open Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return -1;
                    }

                    flag = true;
                }
                else if (FtdiDeviceList[i].SerialNumber.ToString().EndsWith("B") && !flag2)
                {
                    FtStatus = FtdiFIFO.OpenBySerialNumber(FtdiDeviceList[i].SerialNumber);
                    if (FtStatus != 0)
                    {
                        MessageBox.Show("Failed to open device (error " + FtStatus.ToString() + ")", "FTDI Device Open Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return -1;
                    }

                    flag2 = true;
                }
            }
            return 0;
        }

        private int setupFtdiUART()
        {
            byte[] array = new byte[128];
            FtStatus = FtdiUART.Purge(3u);
            FtStatus = FtdiUART.SetBaudRate(115200u);
            if (FtStatus != 0)
            {
                MessageBox.Show("Failed to open device (error " + FtStatus.ToString() + ")", "FTDI Device Open Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return -1;
            }
            FtStatus = FtdiUART.SetDataCharacteristics(8, 0, 0);
            if (FtStatus != 0)
            {
                MessageBox.Show("Failed to set data characteristics (error " + FtStatus.ToString() + ")", "FTDI Device Set Data Characteristics Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return -1;
            }
            FtStatus = FtdiUART.SetFlowControl(0, 17, 19);
            if (FtStatus != 0)
            {
                Console.WriteLine("Failed to set flow control (error " + FtStatus.ToString() + ")", "FTDI Device Flow Control Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Console.ReadKey();
                return -1;
            }
            FtStatus = FtdiUART.SetTimeouts(5000u, 0u);
            if (FtStatus != 0)
            {
                Console.WriteLine("Failed to set timeouts (error " + FtStatus.ToString() + ")", "FTDI Device Set Timeouts Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Console.ReadKey();
                return -1;
            }
            return 0;
        }
        private void CCDTempCal()
        {
            float num = 0f;
            float num2 = 40f;
            float camDACCal = CamDACCal0;
            float camDACCal2 = CamDACCal40;
            TEC_DAC_gradient = (num - num2) / (camDACCal - camDACCal2);
            TEC_DAC_intercept = num2 - TEC_DAC_gradient * camDACCal2;
            nmrcUpDwn_Setting_Temperature.Minimum = (int)(0f * TEC_DAC_gradient + TEC_DAC_intercept);
            nmrcUpDwn_Setting_Temperature.Maximum = (int)(4095f * TEC_DAC_gradient + TEC_DAC_intercept);
            num = 0f;
            num2 = 40f;
            camDACCal = CamADCCal0;
            camDACCal2 = CamADCCal40;
            TEC_ADC_gradient = (num - num2) / (camDACCal - camDACCal2);
            TEC_ADC_intercept = num2 - TEC_ADC_gradient * camDACCal2;
        }

        private void SetCameraTriggers()
        {
            setFPGAregbit(7, "D4");
            resetFPGAregbit(6, "D4");
            resetFPGAregbit(2, "D4");
            setFPGAregbit(1, "F2");
        }
        private void getFPGAStatus()
        {
            byte[] array = new byte[128];
            TxPacket(i2cReadReg("00"), 0);
            array = TxPacket(i2cRead(), 1);
            if ((array[0] & 0x80) == 0)
            {
                rdBttn_Gain_High.Checked = true;
            }
            else
            {
                rdBttn_Gain_Low.Checked = true;
            }
        }

        private void getCameraStatus()
        {
            getSerNoAndBuildData_FPGA_MSVVersion();
            getXDim();
            getYDim();
            getFPGAStatus();
            CCDTempCal();
            getPCBTemp();
            getCCDTemp();
            SetCameraTriggers();
        }

        #endregion


        #region etc...

        private void setTECSetPoint(int temperautre)
        {
            string txText = i2cWriteReg("03", ((byte)(temperautre >> 8)).ToString("X").PadLeft(2, '0'));

            TxPacket(txText, 0);
            txText = i2cWriteReg("04", ((byte)temperautre).ToString("X").PadLeft(2, '0'));
            TxPacket(txText, 0);
        }

        private int getTECSetPoint()
        {
            byte[] array = new byte[128];

            TxPacket(i2cReadReg("00"), 0);
            array = TxPacket(i2cRead(), 1);

            if (((uint)array[0] & (true ? 1u : 0u)) != 0)
            {
                chckBx_Enable_Active_Cooling.Checked = true;
            }

            TxPacket(i2cReadReg("03"), 0);
            array = TxPacket(i2cRead(), 1);
            array = TxPacket(i2cRead(), 1);

            int num = array[0];
            TxPacket(i2cReadReg("04"), 0);
            array = TxPacket(i2cRead(), 1);
            array = TxPacket(i2cRead(), 1);

            return (num << 8) + array[0];
        }

        private void changedExposure(int time)
        {
            long num = 0L;

            if (rdBttn_ms_forExpTime .Checked)
            {
                num += 40000 * (long)nmrcUpDwn_Exposure_Time.Value;
            }
            else if (rdBttn_s_forExpTime.Checked)
            {
                num += 40000000 * (long)nmrcUpDwn_Exposure_Time.Value;
            }

            setExposure(num);

            string text = "";
            num = getExposure();

            if (rdBttn_ms_forExpTime.Checked)
            {
                text = "Exposure set to " + num / 40000 + " ms";
            }
            else if (rdBttn_s_forExpTime.Checked)
            {
                text = "Exposure set to " + num / 40000000 + " s";
            }

            lbl_Set_ExposureTime.Text = text;
        }

        private void chanegFrameRate(int time)
        {
            long num = 0L;

            if (rdBttn_ms_forFrameRate.Checked)
            {
                num += 40000 * (long)nmrcUpDwn_Frame_Rate.Value;
            }
            else if (rdBttn_s_forFrameRate.Checked)
            {
                num += 40000000 * (long)nmrcUpDwn_Frame_Rate.Value;
            }

            setFrameRate(num);

            string text = "";
            num = getExposure();

            if (rdBttn_ms_forFrameRate.Checked)
            {
                text = "Frame Rate set to " + num / 40000 + " ms";
            }
            else if (rdBttn_s_forFrameRate.Checked)
            {
                text = "Frame Rate set to " + num / 40000000 + " s";
            }

            lbl_set_FrameRate.Text = text;
        }

        private void setExposure(long expCnt)
        {
            string txText = i2cWriteReg("ED", ((byte)(expCnt >> 32)).ToString("X").PadLeft(2, '0'));

            TxPacket(txText, 0);
            txText = i2cWriteReg("EE", ((byte)(expCnt >> 24)).ToString("X").PadLeft(2, '0'));
            TxPacket(txText, 0);
            txText = i2cWriteReg("EF", ((byte)(expCnt >> 16)).ToString("X").PadLeft(2, '0'));
            TxPacket(txText, 0);
            txText = i2cWriteReg("F0", ((byte)(expCnt >> 8)).ToString("X").PadLeft(2, '0'));
            TxPacket(txText, 0);
            txText = i2cWriteReg("F1", ((byte)expCnt).ToString("X").PadLeft(2, '0'));
            TxPacket(txText, 0);
        }

        private long getExposure()
        {
            long num = 0L;
            byte[] array = new byte[128];

            TxPacket(i2cReadReg("ED"), 0);
            array = TxPacket(i2cRead(), 1);
            num += Convert.ToInt64(array[0]);
            TxPacket(i2cReadReg("EE"), 0);
            array = TxPacket(i2cRead(), 1);
            num = (num << 8) + Convert.ToInt64(array[0]);
            TxPacket(i2cReadReg("EF"), 0);
            array = TxPacket(i2cRead(), 1);
            num = (num << 8) + Convert.ToInt64(array[0]);
            TxPacket(i2cReadReg("F0"), 0);
            array = TxPacket(i2cRead(), 1);
            num = (num << 8) + Convert.ToInt64(array[0]);
            TxPacket(i2cReadReg("F1"), 0);
            array = TxPacket(i2cRead(), 1);
            return (num << 8) + Convert.ToInt64(array[0]);
        }

        private void setFrameRate(long frameCnt)
        {
            toggleIdleMode(true);

            string txText = i2cWriteReg("DC", ((byte)(frameCnt >> 32)).ToString("X").PadLeft(2, '0'));

            TxPacket(txText, 0);
            txText = i2cWriteReg("DD", ((byte)(frameCnt >> 24)).ToString("X").PadLeft(2, '0'));
            TxPacket(txText, 0);
            txText = i2cWriteReg("DE", ((byte)(frameCnt >> 16)).ToString("X").PadLeft(2, '0'));
            TxPacket(txText, 0);
            txText = i2cWriteReg("DF", ((byte)(frameCnt >> 8)).ToString("X").PadLeft(2, '0'));
            TxPacket(txText, 0);
            txText = i2cWriteReg("E0", ((byte)frameCnt).ToString("X").PadLeft(2, '0'));
            TxPacket(txText, 0);

            toggleIdleMode(false);
        }

        private long getFrameRate()
        {
            long num = 0L;
            byte[] array = new byte[128];

            TxPacket(i2cReadReg("DC"), 0);
            array = TxPacket(i2cRead(), 1);
            num += Convert.ToInt64(array[0]);
            TxPacket(i2cReadReg("DD"), 0);
            array = TxPacket(i2cRead(), 1);
            num = (num << 8) + Convert.ToInt64(array[0]);
            TxPacket(i2cReadReg("DE"), 0);
            array = TxPacket(i2cRead(), 1);
            num = (num << 8) + Convert.ToInt64(array[0]);
            TxPacket(i2cReadReg("DF"), 0);
            array = TxPacket(i2cRead(), 1);
            num = (num << 8) + Convert.ToInt64(array[0]);
            TxPacket(i2cReadReg("E0"), 0);
            array = TxPacket(i2cRead(), 1);
            return (num << 8) + Convert.ToInt64(array[0]);
        }

        private void toggleIdleMode(bool mode_on)
        {
            byte Current_CaptureTriggerMode_byte = getCaptureTriggerMode();

            if(mode_on)
            {
                byte IdleMode_CaptureTriggerMode_byte = (byte)(Current_CaptureTriggerMode_byte & 0b10111101);
                string txText = i2cWriteReg("D4", IdleMode_CaptureTriggerMode_byte.ToString("X"));
                TxPacket(txText, 0);
            }
            else
            {
                byte IdleMode_CaptureTriggerMode_byte = (byte)(Current_CaptureTriggerMode_byte | 0b01000010);
                string txText = i2cWriteReg("D4", IdleMode_CaptureTriggerMode_byte.ToString("X"));
                TxPacket(txText, 0);
            }
        }

        private byte getCaptureTriggerMode()
        {
            TxPacket(i2cReadReg("D4"), 0);

            return TxPacket(i2cRead(), 1)[0];
        }

        private void SwitchImageFullBin()
        {
            if (FullBin)
            {
                string Binning_size = (YSize >= 255 ? "80" : (YSize - 1).ToString("X").PadLeft(2, '0'));//(YSize - 1).ToString("X").PadLeft(2, '0');
                TxPacket(i2cWriteReg("A2", Binning_size), 0);
            }
            else
            {
                TxPacket(i2cWriteReg("A2", "00"), 0);
            }
            getYDim();
        }

        private void Binning_setting_for_load()
        {
            TxPacket(i2cWriteReg("A2", "80"), 0);
            getYDim();
        }

        private uint GetExposureMs()
        {
            if (rdBttn_s_forExpTime .Checked)
            {
                return (uint)nmrcUpDwn_Exposure_Time.Value * 1000;
            }
            return (uint)nmrcUpDwn_Exposure_Time.Value;
        }

        private uint calcMaxDelayPerFrameMs(uint exposureMs, uint addedDelayMs)
        {
            double num = Convert.ToDouble(32) / 1000000.0 * 1000.0;
            double num2 = 1.0 / (Convert.ToDouble(500) * 1000.0) * 1000.0;
            double num3 = 1.0 / (Convert.ToDouble(8) * 1000000.0) * 1000.0;
            double num4 = exposureMs;
            double num5 = num2 * (double)Convert.ToInt32(3048);
            double num6 = num * (double)YSize;
            double num7 = num2 * (double)(XSize / (XBin + 1)) * (double)(YSize / (YBin + 1));
            double num8 = num * (double)YSize;
            double num9 = (double)(XSize / (XBin + 1) * (YSize / (YBin + 1))) * num3 * 2.0;
            uint num10;
            return num10 = (uint)(num4 + num5 + num6 + num7 + num8 + num9 + (double)addedDelayMs);
        }


        private void getSingleFrame()
        {
            uint num = (uint)(Frame_16bit.Length * 2);
            uint num2 = 0u;
            uint numBytesRead = 0u;
            uint num3 = 0u;
            uint num4 = 0u;
            uint num5 = 0u;
            byte[] array = new byte[65536];
            bool flag = false;
            uint num6 = 0u;
            uint num7 = 0u;
            Array.Clear(Frame_16bit, 0, Frame_16bit.Length);
            while (num3 < num)
            {
                num4 = num - num3;
                num2 = (((int)(num4 / array.Length) == 0) ? num4 : ((uint)array.Length));
                num6 = GetExposureMs();
                num7 = calcMaxDelayPerFrameMs(num6, 0u);
                FtStatus = FtdiFIFO.SetTimeouts(num7, 0u);
                FtStatus = FtdiFIFO.Read(array, num2, ref numBytesRead);
                
                num3 += Convert.ToUInt32(numBytesRead);
                for (int i = 0; i < num2; i++)
                {
                    if (num5 >= Frame_16bit.Length)
                    {
                        break;
                    }
                    flag = !flag;
                    if (i >= 1 && !flag)
                    {
                        int num8 = array[i - 1] << 8;
                        num8 += array[i];
                        Frame_16bit[num5] = (ushort)num8;
                        num5++;
                    }
                }
                num2 = 0u;
            }
        }

        private void displaySpectrum(double[] _spectrum)
        {
            if (camera_datagraphform == null || camera_datagraphform.Text == "")
            {
                camera_datagraphform = new DisplayGraphForm(calibratedXAxis, _spectrum, "Spectrum", unit);
                //pnl_Graph_Feild.Controls.Add(camera_datagraphform);
                camera_datagraphform.Show();
            }
            else
            {
                camera_datagraphform.Unit = unit;
                camera_datagraphform.XarrayData = calibratedXAxis;
                camera_datagraphform.YarrayData = _spectrum;
            }
        }

        private void displayImage(ushort[] ccd_Data)
        {
            if(CCDImage_viewer == null)
            {
                CCDImage_viewer = new Import_Image_Viewer(ccd_Data, XDim, YDim);
                CCDImage_viewer.Show();
            }
            else
            {
                CCDImage_viewer.change_Image(ccd_Data, XDim, YDim);
            }
        }

        public void ROI_setting(int X_offset, int Y_offset, int X_size, int Y_size)
        {
            XSize = X_size;
            YSize = Y_size;

            //X offset
            string X_offset_0_7bit = (~(15 << 8) & X_offset).ToString("X").PadLeft(2, '0');
            string X_offset_8_16bit = (X_offset >> 8).ToString("X").PadLeft(2, '0');

            //Y offfset
            string Y_offset_0_7bit = (~(15 << 8) & Y_offset).ToString("X").PadLeft(2, '0');
            string Y_offset_8_16bit = (Y_offset >> 8).ToString("X").PadLeft(2, '0');

            //X size
            string X_size_0_7bit = (~(15 << 8) & X_size).ToString("X").PadLeft(2, '0');
            string X_size_8_16bit = (X_size >> 8).ToString("X").PadLeft(2, '0');

            //Y size
            string Y_size_0_7bit = (~(15 << 8) & Y_size).ToString("X").PadLeft(2, '0');
            string Y_size_8_16bit = (Y_size >> 8).ToString("X").PadLeft(2, '0');

            //Debug.WriteLine($"X offset:{X_offset_0_7bit}-{X_offset_8_16bit},Y offset:{Y_offset_0_7bit}-{Y_offset_8_16bit},X size:{X_size_0_7bit}-{X_size_8_16bit},Y size:{Y_size_0_7bit}-{Y_size_8_16bit}");

            //X offset
            TxPacket(i2cWriteReg("B6", X_offset_8_16bit), 0);
            TxPacket(i2cWriteReg("B7", X_offset_0_7bit), 0);
            
            //Y offset
            TxPacket(i2cWriteReg("BA", Y_offset_8_16bit), 0);
            TxPacket(i2cWriteReg("BB", Y_offset_0_7bit), 0);
            
            //X size
            TxPacket(i2cWriteReg("B4", X_size_8_16bit), 0);
            TxPacket(i2cWriteReg("B5", X_size_0_7bit), 0);
            
            //Y size
            TxPacket(i2cWriteReg("B8", Y_size_8_16bit), 0);
            TxPacket(i2cWriteReg("B9", Y_size_0_7bit), 0);
        }

        #endregion

    }
}
