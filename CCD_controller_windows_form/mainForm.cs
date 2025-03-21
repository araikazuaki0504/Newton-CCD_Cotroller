﻿using ATMCD64CS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using MessageBox = System.Windows.Forms.MessageBox;
using ReadMode = ATMCD64CS.AndorSDK.ReadMode;
using AcquisitionMode = ATMCD64CS.AndorSDK.AcquisitionMode;
using System.Runtime.InteropServices;
using System.Data;
using System.Windows;

namespace CCD_controller_windows_form
{
    public partial class mainForm : Form
    {
        private static Mutex mutex;
        private bool isSameAppRunning = false;
        private CancellationTokenSource exposure_tokenSource = new CancellationTokenSource();

        private const int defult_CCD_Temp = -60;
        private string unit = "Pixel";
        private string CSV_Save_Path = @"C:\CCD_controller_windows_form(Newton)\CSV\";

        private AndorSDK.AndorCapabilities caps;
        private string model_number;
        private int xpixcel;
        private int ypixcel;
        private int Snumber;
        private float speed;
        private float STemp;
        private int HSNumber;
        private int ADNumber;
        private int nAD;
        private int iSpeed;
        private int index;
        private int n_component = 5;
        private int Fiber_qty;
        private uint CCD_Data_Size;

        private bool errorFlag;
        private uint errorValue;
        private string errorLog;

        private int max_CCD_Temp;
        private int min_CCD_Temp;
        private int CCD_Temperature;
        private bool iscooling = false;
        private bool now_AutomaticallyShutdown = false;

        private ushort[] CCD_Data;
        private ushort[] background_CCD_Data;
        private float[] CSV_CCD_Data;
        private float[,] Several_Spectrum_Datum;
        private double[] Sequential_number_ZeroToXpixcel;
        private double[] Spectrum;
        private double[] fitting_C;
        private double[] fitting_St;

        private SerialFiberAcquisitionForm serialFiberAquisitionForm;
        private DisplayGraphForm camera_datagraphform;
        private Import_Image_Viewer CCDImage_viewer;
        private ImageForm camera_imageform;
        private TriggerModeSettingForm triggerModeSettingForm;
        private SeveralSpectrumForm SeveralSpectrumForm;
        private MCRSettingcs MCRSettingcs;

        public mainForm()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            errorFlag = false;
            mutex = new Mutex(true, "AndorSDK_Application", out isSameAppRunning);

            if (!isSameAppRunning)
            {
                MessageBox.Show("このアプリケーションは1つのみ実行できます。", "return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            switch (MessageBox.Show("Load Camera?", "Camera Control", MessageBoxButtons.OKCancel))
            {
                case DialogResult.OK:
                    Initial_Camera_Setting();
                    if (errorFlag) return;//初期設定にエラーがあればここでストップ

                    errorValue = AndorSDK.GetTemperatureRange(ref min_CCD_Temp, ref max_CCD_Temp);//温度範囲取得
                    if (errorValue != AndorSDK.DRV_SUCCESS)
                    {
                        MessageBox.Show("CCDカメラの温度範囲が取得できません!!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        nmrcUpDwn_Setting_Temperature.Maximum = max_CCD_Temp;
                        nmrcUpDwn_Setting_Temperature.Minimum = min_CCD_Temp;
                        nmrcUpDwn_Setting_Temperature.Enabled = true;
                    }

                    if (min_CCD_Temp <= defult_CCD_Temp && defult_CCD_Temp <= max_CCD_Temp)
                    {
                        errorValue = AndorSDK.SetTemperature(defult_CCD_Temp);
                        if (errorValue != AndorSDK.DRV_SUCCESS) MessageBox.Show("初期温度を設定できませんでした。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("初期温度が範囲外でした。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    CCD_Cooling();
                    break;

                    //case DialogResult.Cancel:
                    //    this.Close();
                    //    return;
            }

        }

        /// <summary>
        /// カメラの初期設定を行う
        /// </summary>
        private void Initial_Camera_Setting()
        {
            errorValue = AndorSDK.Initialize(Environment.CurrentDirectory);
            errorLog = "Initialization errors:\n";

            if (errorValue != AndorSDK.DRV_SUCCESS)
            {
                errorLog += "Initialize Error\n";
                errorFlag = true;
            }

            errorValue = AndorSDK.GetCapabilities(ref caps);
            if (errorValue != AndorSDK.DRV_SUCCESS)
            {
                errorLog += "Get Andor Capabilities information Error\n";
                errorFlag = true;
            }

            errorValue = AndorSDK.GetHeadModel(ref model_number);
            if (errorValue != AndorSDK.DRV_SUCCESS)
            {
                errorLog += "Get Head Model information Error\n";
                errorFlag = true;
            }

            errorValue = AndorSDK.GetDetector(ref xpixcel, ref ypixcel);
            if (errorValue != AndorSDK.DRV_SUCCESS)
            {
                errorLog += "Get Detector information Error\n";
                errorFlag = true;
            }

            errorValue = AndorSDK.SetAcquisitionMode(AcquisitionMode.Single_Scan);
            if (errorValue != AndorSDK.DRV_SUCCESS)
            {
                errorLog += "Set Acquisition Mode Error\n";
                errorFlag = true;
            }

            errorValue = AndorSDK.SetReadMode(ReadMode.Image);
            if (errorValue != AndorSDK.DRV_SUCCESS)
            {
                errorLog += "Set Read Mode Error\n";
                errorFlag = true;
            }

            AndorSDK.GetFastestRecommendedVSSpeed(ref Snumber, ref speed);
            errorValue = AndorSDK.SetVSSpeed(Snumber);
            if (errorValue != AndorSDK.DRV_SUCCESS)
            {
                errorLog += "Set Vertical Speed Error\n";
                errorFlag = true;
            }

            STemp = 0;
            HSNumber = 0;
            ADNumber = 0;

            errorValue = AndorSDK.GetNumberADChannels(ref nAD);
            if (errorValue != AndorSDK.DRV_SUCCESS)
            {
                errorLog += "Get number AD Channel Error\n";
                errorFlag = true;
            }
            else
            {
                for (int iAD = 0; iAD < nAD; iAD++)
                {
                    AndorSDK.GetNumberHSSpeeds(iAD, 0, ref index);
                    for (iSpeed = 0; iSpeed < index; iSpeed++)
                    {
                        AndorSDK.GetHSSpeed(iAD, 0, iSpeed, ref speed);
                        if (speed > STemp)
                        {
                            STemp = speed;
                            HSNumber = iSpeed;
                            ADNumber = iAD;
                        }
                    }
                }
            }

            errorValue = AndorSDK.SetADChannel(ADNumber);
            if (errorValue != AndorSDK.DRV_SUCCESS)
            {
                errorLog += "Set AD Channel Error\n";
                errorFlag = true;
            }

            errorValue = AndorSDK.SetHSSpeed(0, HSNumber);
            if (errorValue != AndorSDK.DRV_SUCCESS)
            {
                errorLog += "Set Horizontal Speed Error\n";
                errorFlag = true;
            }

            if (caps.ulSetFunctions != AndorSDK.AC_SETFUNCTION_BASELINECLAMP)
            {
                errorValue = AndorSDK.SetBaselineClamp(1);
                if (errorValue != AndorSDK.DRV_SUCCESS)
                {
                    errorLog += "Set Baseline Clamp Error\n";
                    errorFlag = true;
                }
            }

            if (errorFlag) MessageBox.Show(errorLog, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// CCDの冷却設定・開始
        /// </summary>
        private void CCD_Cooling()
        {
            errorValue = AndorSDK.CoolerON();//冷却開始
            if (errorValue != AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("CCDカメラを冷却できていません!!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                iscooling = true;
            }

            Temperature_timer.Enabled = true;
            Temperature_timer.Start();//タイマースタート
        }

        /// <summary>
        /// CCDイメージ取得のための設定
        /// </summary>
        private bool Initial_Acquisition_Configuration()
        {
            if (camera_imageform != null)
            {
                xpixcel = camera_imageform.get_ROI_XSize();
                ypixcel = camera_imageform.get_ROI_YSize();
            }

            changedExposure(Convert.ToInt32(nmrcUpDwn_Exposure_Time.Value));

            //Gainについて書くならここへ   
            //if (rdBttn_Gain_Low.Checked)
            //{
            //    
            //}
            //else
            //{
            //    
            //}

            if (rdBttn_Image.Checked)
            {
                errorValue = AndorSDK.SetReadMode(ReadMode.Image);
                if (errorValue != AndorSDK.DRV_SUCCESS)
                {
                    MessageBox.Show("ReadModeをImageに変更できませんでした。", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                AndorSDK.SetImage(1, 1, 1, xpixcel, 1, ypixcel);

                CCD_Data_Size = (uint)(xpixcel * ypixcel);
                CCD_Data = new ushort[CCD_Data_Size];
            }
            else
            {
                errorValue = AndorSDK.SetReadMode(ReadMode.Full_Vertical_Binning);
                if (errorValue != AndorSDK.DRV_SUCCESS)
                {
                    MessageBox.Show("ReadModeをFVBに変更できませんでした。", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                CCD_Data_Size = (uint)xpixcel;
                CCD_Data = new ushort[CCD_Data_Size];

                if (Sequential_number_ZeroToXpixcel != null) Array.Clear(Sequential_number_ZeroToXpixcel, 0, Sequential_number_ZeroToXpixcel.Length);
                Sequential_number_ZeroToXpixcel = new double[CCD_Data_Size];

                for (int i = 0; i < xpixcel; i++) Sequential_number_ZeroToXpixcel[i] = i;
            }

            return true;
        }

        private void changedExposure(int time)
        {
            float set_time;
            string text;

            if (rdBttn_ms_forExpTime.Checked)
            {
                set_time = (float)nmrcUpDwn_Exposure_Time.Value / 1000;
            }
            else
            {
                set_time = (float)nmrcUpDwn_Exposure_Time.Value;
            }

            errorValue = AndorSDK.SetExposureTime(set_time);
            if (errorValue != AndorSDK.DRV_SUCCESS) MessageBox.Show("露光時間設定に失敗しました。", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            if (rdBttn_ms_forExpTime.Checked)
            {
                text = "Exposure set to " + nmrcUpDwn_Exposure_Time.Value.ToString() + " ms";
            }
            else
            {
                text = "Exposure set to " + nmrcUpDwn_Exposure_Time.Value.ToString() + " s";
            }

            lbl_Set_ExposureTime.Text = text;
        }

        private void displaySpectrum(double[] _spectrum)
        {
            if (camera_datagraphform == null || camera_datagraphform.Text == "")
            {
                camera_datagraphform = new DisplayGraphForm(Sequential_number_ZeroToXpixcel, _spectrum, "Spectrum", unit);
                camera_datagraphform.TopLevel = false;
                pnl_Window_Field.Controls.Add(camera_datagraphform);
                camera_datagraphform.Show();
            }
            else
            {
                camera_datagraphform.Unit = unit;
                camera_datagraphform.XarrayData = Sequential_number_ZeroToXpixcel;
                camera_datagraphform.YarrayData = _spectrum;
            }
        }

        private void displayImage(ushort[] ccd_Data)
        {
            if (CCDImage_viewer == null)
            {
                CCDImage_viewer = new Import_Image_Viewer(ccd_Data, xpixcel, ypixcel);
                CCDImage_viewer.TopLevel = false;
                pnl_Window_Field.Controls.Add(CCDImage_viewer);
                CCDImage_viewer.Show();
            }
            else
            {
                CCDImage_viewer.change_Image(ccd_Data, xpixcel, ypixcel);
            }
        }

        private void Temperature_timer_Tick(object sender, EventArgs e)
        {
            float CCD_Temp = 0;

            errorValue = AndorSDK.GetTemperatureF(ref CCD_Temp);
            if (errorValue == AndorSDK.DRV_TEMPERATURE_STABILIZED)
            {
                lbl_CCD_Temp.Text = CCD_Temp.ToString("0.00") + " ℃";
                CCD_Temperature = (int)CCD_Temp;
            }
            else if (errorValue == AndorSDK.DRV_TEMPERATURE_NOT_REACHED)
            {
                lbl_CCD_Temp.Text = CCD_Temp.ToString("0.00") + " ℃";
                CCD_Temperature = (int)CCD_Temp;
            }
            else
            {
                //MessageBox.Show("CCDの温度が取得できません!!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bttn_Setting_CCD_Temperature_Click(object sender, EventArgs e)
        {
            if (!(min_CCD_Temp <= nmrcUpDwn_Setting_Temperature.Value && nmrcUpDwn_Setting_Temperature.Value <= max_CCD_Temp)) return;
            errorValue = AndorSDK.SetTemperature((int)nmrcUpDwn_Setting_Temperature
                .Value);
            if (errorValue != AndorSDK.DRV_SUCCESS) MessageBox.Show("CCDの温度が設定できませんでした。", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void btton_Acuire_Frame_Click(object sender, EventArgs e)
        {
            int Status = 0;
            int frame_num = 0;
            float exposure_tim = 0;
            float accumulat_time = 0;
            float kinetic_time = 0;

            Temperature_timer.Stop();
            Temperature_timer.Enabled = false;
            bttn_Acquire_Frame.Enabled = false;
            bttn_Stop.Enabled = true;

            AndorSDK.GetStatus(ref Status);
            if (Status != AndorSDK.DRV_IDLE)
            {
                Temperature_timer.Enabled = true;
                Temperature_timer.Start();
                bttn_Acquire_Frame.Enabled = true;
                bttn_Stop.Enabled = false;

                return;
            }
            else
            {
                bool Is_Initialize = Initial_Acquisition_Configuration();
                if (!Is_Initialize)
                {
                    Temperature_timer.Enabled = true;
                    Temperature_timer.Start();
                    bttn_Acquire_Frame.Enabled = true;
                    bttn_Stop.Enabled = false;

                    return;
                }

                errorValue = AndorSDK.SetAcquisitionMode(AcquisitionMode.Single_Scan);
                if (errorValue != AndorSDK.DRV_SUCCESS)
                {
                    MessageBox.Show("AcquisitionModeをSingle Scanに変更できませんでした。", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Temperature_timer.Enabled = true;
                    Temperature_timer.Start();
                    bttn_Acquire_Frame.Enabled = true;
                    bttn_Stop.Enabled = false;

                    return;
                }
                else
                {
                    errorValue = AndorSDK.GetAcquisitionTimings(ref exposure_tim, ref accumulat_time, ref kinetic_time);
                    if (errorValue != AndorSDK.DRV_SUCCESS)
                    {
                        MessageBox.Show("AcqusitionTimingを取得できませんでした。", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Temperature_timer.Enabled = true;
                        Temperature_timer.Start();
                        bttn_Acquire_Frame.Enabled = true;
                        bttn_Stop.Enabled = false;
                    
                        return;
                    }

                    float TimeOut = (exposure_tim + accumulat_time + kinetic_time) * 1000;

                    while ((nmrcUpDwn_Number_of_Frame.Value > frame_num || chckBx_continuous.Checked) && !exposure_tokenSource.IsCancellationRequested)
                    {
                        errorValue = AndorSDK.StartAcquisition();
                        if (errorValue != AndorSDK.DRV_SUCCESS)
                        {
                            MessageBox.Show($"{frame_num}回目の測定を開始できませんでした。", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Temperature_timer.Enabled = true;
                            Temperature_timer.Start();
                            bttn_Acquire_Frame.Enabled = true;
                            bttn_Stop.Enabled = false;

                            return;
                        }

                        try
                        {
                            await Task.Delay(Convert.ToInt32(TimeOut), exposure_tokenSource.Token);
                        }
                        catch
                        {

                        }

                        errorValue = AndorSDK.GetAcquiredData16(CCD_Data, CCD_Data_Size);
                        if (errorValue != AndorSDK.DRV_SUCCESS)
                        {
                            MessageBox.Show("データの読み出しに失敗しました。", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Temperature_timer.Enabled = true;
                            Temperature_timer.Start();
                            bttn_Acquire_Frame.Enabled = true;
                            bttn_Stop.Enabled = false;

                            return;
                        }

                        if (rdBttn_FVB.Checked)
                        {
                            Spectrum = Array.ConvertAll(CCD_Data, (ushort x) => (double)x);
                            displaySpectrum(Spectrum);

                        }
                        else
                        {
                            displayImage(CCD_Data);
                        }

                        if (chckBx_Write_CSV.Checked && !chckBx_continuous.Checked)
                        {
                            DateTime Now_Date_Data = DateTime.Now;
                            string File_Name = "CCDImage_" + Now_Date_Data.Year.ToString() + Now_Date_Data.Month.ToString() + Now_Date_Data.Day.ToString() + Now_Date_Data.Hour.ToString() + Now_Date_Data.Minute.ToString() + frame_num.ToString() + ".csv";
                            StreamWriter csv_writer = new StreamWriter(CSV_Save_Path + File_Name);

                            for (int i = 0; i < ypixcel; i++)
                            {
                                string WriteLine = "";

                                for (int j = 0; j < xpixcel; j++)
                                {
                                    WriteLine += CCD_Data[i * xpixcel + j] + ",";
                                }

                                csv_writer.WriteLine(WriteLine.TrimEnd(','));
                            }

                            csv_writer.Close();
                        }

                        frame_num += 1;

                    }
                }
            }

            if (exposure_tokenSource.IsCancellationRequested)
            {
                exposure_tokenSource.Dispose();
                exposure_tokenSource = new CancellationTokenSource();
            }

            if (rdBttn_Image.Checked && chckBx_set_as_BackGround.Checked)
            {
                background_CCD_Data = new ushort[CCD_Data_Size];
                for (int i = 0; i < CCD_Data_Size; i++) background_CCD_Data[i] = CCD_Data[i];
            }

            Temperature_timer.Enabled = true;
            Temperature_timer.Start();
            bttn_Acquire_Frame.Enabled = true;
            bttn_Stop.Enabled = false;
            ROISettingToolStripMenuItem.Enabled = true;
        }

        private void bttn_Stop_Click(object sender, EventArgs e)
        {
            exposure_tokenSource.CancelAfter(200);
        }

        private void rdBttn_Image_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBttn_Image.Checked)
            {
                //chckBx_continuous.Enabled = false;
                serialFiberAquisitionToolStripMenuItem.Enabled = true;
                chckBx_set_as_BackGround.Checked = false;
                chckBx_set_as_BackGround.Enabled = true;
            }
            else
            {
                //chckBx_continuous.Enabled = true;
                serialFiberAquisitionToolStripMenuItem.Enabled = false;
                chckBx_set_as_BackGround.Checked = false;
                chckBx_set_as_BackGround.Enabled = false;
            }
        }

        private void chckBx_Enable_Active_Cooling_CheckedChanged(object sender, EventArgs e)
        {

            if (iscooling && !chckBx_Enable_Active_Cooling.Checked)
            {
                errorValue = AndorSDK.CoolerOFF();
                if (errorValue != AndorSDK.DRV_SUCCESS) MessageBox.Show("冷却がOFFになっていません!!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    iscooling = false;
                    nmrcUpDwn_Setting_Temperature.Enabled = false;
                    bttn_Setting_CCD_Temperature.Enabled = false;
                    Temperature_timer.Stop();
                    Temperature_timer.Enabled = false;
                    Temperature_timer_for_not_Cooling.Enabled = true;
                    Temperature_timer_for_not_Cooling.Start();
                }
            }
            else if (!iscooling && chckBx_Enable_Active_Cooling.Checked)
            {
                errorValue = AndorSDK.CoolerON();
                if (errorValue != AndorSDK.DRV_SUCCESS) MessageBox.Show("冷却がONになっていません!!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    iscooling = true;
                    nmrcUpDwn_Setting_Temperature.Enabled = true;
                    bttn_Setting_CCD_Temperature.Enabled = true;
                    Temperature_timer_for_not_Cooling.Stop();
                    Temperature_timer_for_not_Cooling.Enabled = false;
                    Temperature_timer.Enabled = true;
                    Temperature_timer.Start();

                }
            }
        }

        private void serialFiberAquisitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CCD_Data == null) return;

            if (CSV_CCD_Data != null && (CSV_CCD_Data.Max<float>() != 0 || CSV_CCD_Data.Min<float>() != 0) && serialFiberAquisitionForm == null)
            {
                serialFiberAquisitionForm = new SerialFiberAcquisitionForm(CSV_CCD_Data, xpixcel, ypixcel);
                serialFiberAquisitionForm.TopLevel = false;
                this.pnl_Window_Field.Controls.Add(serialFiberAquisitionForm);
                serialFiberAquisitionForm.BringToFront();
                serialFiberAquisitionForm.Show();

                serialFiberAquisitionForm.calculate_separetePoint();
                identificatePolymorphToolStripMenuItem.Enabled = true;
                Fiber_qty = serialFiberAquisitionForm.get_Fiber_qty();
            }
            else if(CSV_CCD_Data != null && (CSV_CCD_Data.Max<float>() != 0 || CSV_CCD_Data.Min<float>() != 0) && serialFiberAquisitionForm != null)
            {
                serialFiberAquisitionForm.Clear();
                serialFiberAquisitionForm.calculate_separetePoint();
                identificatePolymorphToolStripMenuItem.Enabled = true;
                Fiber_qty = serialFiberAquisitionForm.get_Fiber_qty();
                serialFiberAquisitionForm.Show();
            }
            else if ((CCD_Data.Max<ushort>() != 0 || CCD_Data.Min<ushort>() != 0) && serialFiberAquisitionForm == null)
            {
                serialFiberAquisitionForm = new SerialFiberAcquisitionForm(CCD_Data, xpixcel, ypixcel);
                serialFiberAquisitionForm.TopLevel = false;
                this.pnl_Window_Field.Controls.Add(serialFiberAquisitionForm);
                serialFiberAquisitionForm.BringToFront();
                serialFiberAquisitionForm.Show();
                serialFiberAquisitionForm.BringToFront();
                if (background_CCD_Data != null) serialFiberAquisitionForm.set_BackGround_Image_for_ushort(background_CCD_Data);

                serialFiberAquisitionForm.calculate_separetePoint();
                identificatePolymorphToolStripMenuItem.Enabled = true;
                Fiber_qty = serialFiberAquisitionForm.get_Fiber_qty();
            }
            else if ((CCD_Data.Max<ushort>() != 0 || CCD_Data.Min<ushort>() != 0) && serialFiberAquisitionForm != null)
            {
                if (background_CCD_Data != null) serialFiberAquisitionForm.set_BackGround_Image_for_ushort(background_CCD_Data);

                serialFiberAquisitionForm.Clear();
                serialFiberAquisitionForm.calculate_separetePoint();
                identificatePolymorphToolStripMenuItem.Enabled = true;
                Fiber_qty = serialFiberAquisitionForm.get_Fiber_qty();
                serialFiberAquisitionForm.Show();
            }
        }

        private void importCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string FilePath = openFileDialog.FileName;
            int col_index = 0;
            int row_index = 0;
            List<float> data = new List<float>();


            StreamReader reader = new StreamReader(FilePath);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                row_index = 0;
                if (line == "")
                {
                    continue;
                }
                else
                {
                    foreach (string rowNumber in line.Split(','))
                    {
                        data.Add(float.Parse(rowNumber));
                        row_index++;
                    }
                }
                col_index++;
            }

            if (row_index > col_index)
            {
                xpixcel = row_index;
                ypixcel = col_index;

                CCD_Data = Array.ConvertAll<float, ushort>((float[])data.ToArray().Clone(), (float i) => { return (ushort)Math.Abs(i); });
                Import_Image_Viewer import_Image = new Import_Image_Viewer(CCD_Data, row_index, col_index);
                import_Image.TopLevel = false;
                this.pnl_Window_Field.Controls.Add(import_Image);
                import_Image.BringToFront();
                import_Image.Show();
                import_Image.BringToFront();

                return;
            }
            else
            {
                float[] data_T = new float[col_index * row_index];
                float[] tmp_data = data.ToArray();

                for (int i = 0; i < col_index; i++)
                {
                    for (int j = 0; j < row_index; j++)
                    {
                        data_T[j * col_index + i] = data[i * row_index + j];
                    }
                }

                xpixcel = col_index;
                ypixcel = row_index;

                CCD_Data = Array.ConvertAll<float, ushort>((float[])data_T.ToArray().Clone(), (float i) => { return (ushort)Math.Abs(i); });
                Import_Image_Viewer import_Image = new Import_Image_Viewer(CCD_Data, col_index, row_index);
                import_Image.TopLevel = false;
                this.pnl_Window_Field.Controls.Add(import_Image);
                import_Image.BringToFront();
                import_Image.Show();
                import_Image.BringToFront();

                return;
            }
        }

        private void importBackGroundImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string FilePath = openFileDialog.FileName;
            int col_index = 0;
            int row_index = 0;
            List<float> data = new List<float>();


            StreamReader reader = new StreamReader(FilePath);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                row_index = 0;
                if (line == "")
                {
                    continue;
                }
                else
                {
                    foreach (string rowNumber in line.Split(','))
                    {
                        data.Add(float.Parse(rowNumber));
                        row_index++;
                    }
                }
                col_index++;
            }

            background_CCD_Data = Array.ConvertAll<float, ushort>((float[])data.ToArray().Clone(), (float i) => { return (ushort)i; });

            if (row_index > col_index)
            {
                Import_Image_Viewer import_Image = new Import_Image_Viewer(background_CCD_Data, row_index, col_index);
                import_Image.TopLevel = false;
                this.pnl_Window_Field.Controls.Add(import_Image);
                import_Image.BringToFront();
                import_Image.Show();
                import_Image.BringToFront();

                return;
            }
            else
            {
                float[] data_T = new float[col_index * row_index];
                float[] tmp_data = data.ToArray();

                for (int i = 0; i < col_index; i++)
                {
                    for (int j = 0; j < row_index; j++)
                    {
                        data_T[j * col_index + i] = data[i * row_index + j];
                    }
                }

                Import_Image_Viewer import_Image = new Import_Image_Viewer(background_CCD_Data, row_index, col_index);
                import_Image.TopLevel = false;
                this.pnl_Window_Field.Controls.Add(import_Image);
                import_Image.BringToFront();
                import_Image.Show();
                import_Image.BringToFront();

                return;
            }
        }

        private void ROISettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (camera_imageform == null || camera_imageform.Text == "")
            {
                camera_imageform = new ImageForm(CCD_Data, xpixcel, ypixcel);
                pnl_Window_Field.Controls.Add(camera_imageform);
                camera_imageform.Show();
            }
            else
            {
                camera_imageform.Dispose();
                camera_imageform = new ImageForm(CCD_Data, xpixcel, ypixcel);
                camera_imageform.changeImage(CCD_Data, xpixcel, ypixcel);
                camera_imageform.Show();
            }
        }

        private void chckBx_set_as_BackGround_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBx_set_as_BackGround.Checked)
            {
                chckBx_continuous.Checked = false;
            }
        }

        private void chckBx_continuous_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBx_continuous.Checked)
            {
                chckBx_set_as_BackGround.Checked = false;
                chckBx_Write_CSV.Checked = false;
            }
        }

        private void chckBx_Write_CSV_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBx_Write_CSV.Checked)
            {
                chckBx_continuous.Checked = false;
            }
        }

        private void triggerModeSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            triggerModeSettingForm = new TriggerModeSettingForm();
            triggerModeSettingForm.Show();
        }

        /// <summary>
        /// CoolOffのときGetTemperature関数を実行できない
        /// そのため、CoolOn->CoolOffを瞬時に行い、その間に温度を測定する関数
        /// これしかCoolOff時に温度を測るすべがない
        /// 0.1秒間隔でon、offを繰り返すとCCDカメラが冷却してしまいそうなので、1秒間隔とする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Temperature_timer_for_not_Cooling_Tick(object sender, EventArgs e)
        {
            int Temp = 0;

            AndorSDK.CoolerON();

            try
            {
                await Task.Delay(10);
            }
            catch
            {

            }

            AndorSDK.GetTemperature(ref Temp);


            AndorSDK.CoolerOFF();

            lbl_CCD_Temp.Text = Temp.ToString();
            CCD_Temperature = Temp;
        }

        private void automaticalShutDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (now_AutomaticallyShutdown)
            {
                AutomaticalShutdown_timer.Stop();
                AutomaticalShutdown_timer.Enabled = false;
                automaticalShutDownToolStripMenuItem.Text = "Automatical ShutDown";
            }
            else
            {
                AutomaticalShutdown_timer.Enabled = true;
                AutomaticalShutdown_timer.Start();
                automaticalShutDownToolStripMenuItem.Text = "Stop Shutdown";
            }
        }

        private void AutomaticalShutdown_timer_Tick(object sender, EventArgs e)
        {
            if (CCD_Temperature < 10) return;

            errorValue = AndorSDK.ShutDown();
            if (errorValue == AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("CCDカメラのシャットダウンに成功しました。", "成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                return;
            }

        }

        private void importSubstructImageCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string FilePath = openFileDialog.FileName;
            int col_index = 0;
            int row_index = 0;
            List<float> data = new List<float>();


            StreamReader reader = new StreamReader(FilePath);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                row_index = 0;
                if (line == "")
                {
                    continue;
                }
                else
                {
                    foreach (string rowNumber in line.Split(','))
                    {
                        data.Add(float.Parse(rowNumber));
                        row_index++;
                    }
                }
                col_index++;
            }

            if (row_index > col_index)
            {
                xpixcel = row_index;
                ypixcel = col_index;

                CCD_Data = Array.ConvertAll<float, ushort>((float[])data.ToArray().Clone(), (float i) => { return (ushort)Math.Abs(i); });
                CSV_CCD_Data = (float[])data.ToArray().Clone();

                Import_Image_Viewer import_Image = new Import_Image_Viewer(CCD_Data, row_index, col_index);
                import_Image.TopLevel = false;
                this.pnl_Window_Field.Controls.Add(import_Image);
                import_Image.BringToFront();
                import_Image.Show();
                import_Image.BringToFront();

                return;
            }
            else
            {
                float[] data_T = new float[col_index * row_index];
                float[] tmp_data = data.ToArray();

                for (int i = 0; i < col_index; i++)
                {
                    for (int j = 0; j < row_index; j++)
                    {
                        data_T[j * col_index + i] = data[i * row_index + j];
                    }
                }

                xpixcel = col_index;
                ypixcel = row_index;

                CCD_Data = Array.ConvertAll<float, ushort>((float[])data_T.ToArray().Clone(), (float i) => { return (ushort)Math.Abs(i); });
                CSV_CCD_Data = (float[])data_T.ToArray().Clone();

                Import_Image_Viewer import_Image = new Import_Image_Viewer(CCD_Data, col_index, row_index);
                import_Image.TopLevel = false;
                this.pnl_Window_Field.Controls.Add(import_Image);
                import_Image.BringToFront();
                import_Image.Show();
                import_Image.BringToFront();

                return;
            }
        }

        private void identificatePolymorphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MCRSettingcs = new MCRSettingcs();
            MCRSettingcs.TopLevel = false;
            MCRSettingcs.Calculate += calcurate;
            this.pnl_Window_Field.Controls.Add(MCRSettingcs);
            MCRSettingcs.BringToFront();
            MCRSettingcs.Show();
        }

        private void SeveralSpectrumForm_Button_Clicked(object sender, EventArgs e)
        {
            double[] tmp_array = new double[Fiber_qty];
            double[] Polymorph_Ratio = new double[Fiber_qty];
            int[] Selected_Spectrum_index = SeveralSpectrumForm.Get_Selected_Spectrum();
            int Picture_Width = 0;
            int Picture_Height = 0;

            for (int i = 0; i < Fiber_qty; i++)
            {
                double tmp = 0;

                foreach (int index in Selected_Spectrum_index)
                {
                    tmp += fitting_C[i * n_component + index] * 0.8;
                }

                tmp_array[i] = fitting_C[i * n_component + Selected_Spectrum_index[0]] / tmp;
            }

            for(int i = 0; i < Fiber_qty; i++)
            {
                Polymorph_Ratio[i] = (tmp_array[i] - tmp_array.Min()) / (tmp_array.Max() - tmp_array.Min());
            }


            import_DLL.DataToImage dataToImage = new import_DLL.DataToImage(Polymorph_Ratio, 500, 500);

            dataToImage.changeToImage();
            dataToImage.get_ImageSize(ref Picture_Width, ref Picture_Height);

            byte[] distribution = new byte[Picture_Width * Picture_Height * 3];

            dataToImage.get_Image(distribution);

            dataToImage.Delete();

            Import_Image_Viewer distributionImage = new Import_Image_Viewer(distribution, 500, 500);
            distributionImage.TopLevel = false;
            this.pnl_Window_Field.Controls.Add(distributionImage);
            distributionImage.BringToFront();
            distributionImage.Show();

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] Polymorph_Ratio = new double[37];
            int Picture_Width = 0;
            int Picture_Height = 0;


            Random rand = new Random();

            for (int i = 0; i < 37; i++)
            {
                Polymorph_Ratio[i] = rand.NextDouble();
            }

            import_DLL.DataToImage dataToImage = new import_DLL.DataToImage(Polymorph_Ratio, 500, 500);

            dataToImage.changeToImage();
            dataToImage.get_ImageSize(ref Picture_Width, ref Picture_Height);

            byte[] distribution = new byte[Picture_Width * Picture_Height * 3];

            dataToImage.get_Image(distribution);

            dataToImage.Delete();

            Import_Image_Viewer distributionImage = new Import_Image_Viewer(distribution, 500, 500);
            distributionImage.TopLevel = false;
            this.pnl_Window_Field.Controls.Add(distributionImage);
            distributionImage.BringToFront();
            distributionImage.Show();
        }

        private async void calcurate(object sender, EventArgs e)
        {
            var sw = new System.Diagnostics.Stopwatch();
            Several_Spectrum_Datum = serialFiberAquisitionForm.Get_Several_Spectrum_Datum();
            n_component = MCRSettingcs.get_component_number();

            double[] St = new double[n_component * xpixcel];
            fitting_C = new double[Fiber_qty * n_component];
            fitting_St = new double[n_component * xpixcel];

            Random random = new Random();

            for (int i = 0; i < n_component * xpixcel; i++)
            {
                St[i] = random.NextDouble();
            }

            double[] D = Array.ConvertAll<float, double>(Several_Spectrum_Datum.Cast<float>().ToArray(), (float i) => { return (double)i; });

            import_DLL.MCR_ALS mcr = new import_DLL.MCR_ALS(100000);

            sw.Start();
            await Task.Run(() => mcr.fit(D, Fiber_qty, xpixcel, n_component, null, St));
            sw.Stop();

            mcr.get_C(fitting_C, Fiber_qty, n_component);
            mcr.get_St(fitting_St, n_component, xpixcel);

            mcr.Delete();

            SeveralSpectrumForm = new SeveralSpectrumForm(fitting_St, n_component, xpixcel);
            SeveralSpectrumForm.Text = $"Pure Spectrum ({sw.ElapsedMilliseconds} ms)";
            SeveralSpectrumForm._Is_Button_Clicked += SeveralSpectrumForm_Button_Clicked;
            SeveralSpectrumForm.Show();
        }

        private void rdBttn_ms_forExpTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBttn_ms_forExpTime.Checked)
            {
                nmrcUpDwn_Exposure_Time.Maximum = 10000;
                nmrcUpDwn_Exposure_Time.Minimum = 20;
            }
            else
            {
                nmrcUpDwn_Exposure_Time.Maximum = 10;
                nmrcUpDwn_Exposure_Time.Minimum = 0.02M;
            }
        }
    }
}
