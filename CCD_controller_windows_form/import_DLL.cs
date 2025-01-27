using System;
using System.Data.Common;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.InteropServices;

namespace CCD_controller_windows_form
{
    internal static class import_DLL
    {
        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void showMatrix(double[] Matrix, int colunm, int row, bool allShow = false);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void SVD_float(float[] Matrix, int Matrix_colunm, int Matrix_row, float[] U, float[] S, float[] V);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void SVD_double(double[] Matrix, int Matrix_colunm, int Matrix_row, double[] U, double[] S, double[] V);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void NMF(double[] Matrix, int Matrix_colunm, int Matrix_row, int n_components, double[] W, double[] H, double epsilon = 1e-10);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void product(double[] Matrix_A, int Matrix_A_colunm_, int Matrix_A_row_, double[] Matrix_B, int Matrix_B_colunm_, int Matrix_B_row_, double[] Matrix);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr Create_MCR_ALS_Instance(int maxIter);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern ref IntPtr changeRegressorType_forALL(IntPtr self, string C_RegressorType, string St_RegressorType);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern ref IntPtr changeRegressorType_forC(IntPtr self, string RegressorType);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern ref IntPtr changeRegressorType_forSt(IntPtr self, string RegressorType);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern void fit(IntPtr self, double[] D, int D_colunm, int D_row, int n_component, double[] C, double[] ST);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern void get_C(IntPtr self, double* C, int C_colunm, int C_row);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern void get_St(IntPtr self, double* St, int St_colunm, int St_row);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern void Delete_MCR_ALS_Instance(IntPtr self);

        [DllImport("MCR_ALS_64.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern void Test(IntPtr self);

        [DllImport("ConvertData_To_DistributionImage.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern IntPtr Create_DataToImage_Instance(double[] Data, uint Image_width, uint Image_height);

        [DllImport("ConvertData_To_DistributionImage.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern void changeToImage(IntPtr self);

        [DllImport("ConvertData_To_DistributionImage.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern void getImage(IntPtr self, byte* Image);

        [DllImport("ConvertData_To_DistributionImage.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern void getImage_Size(IntPtr self, int* Image_width, int* Image_height);

        [DllImport("ConvertData_To_DistributionImage.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern void saveImage(IntPtr self, string outputPath);

        [DllImport("ConvertData_To_DistributionImage.dll", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern void Delete_DataToImage_Instance(IntPtr self);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern bool SetEnvironmentVariable(string lpName, string lpValue);

        public class MCR_ALS
        {
            private IntPtr _self;

            public MCR_ALS(int maxIter)
            {
                _self = Create_MCR_ALS_Instance(maxIter);
            }

            public void Delete()
            {
                Delete_MCR_ALS_Instance(_self);
            }

            public MCR_ALS changeRegressorType_forALL(string C_RegressorType, string St_RegressorType)
            {
                import_DLL.changeRegressorType_forALL(_self, C_RegressorType, St_RegressorType);
                return this;
            }

            public MCR_ALS changeRegressorType_C(string C_RegressorType)
            {
                import_DLL.changeRegressorType_forC(_self, C_RegressorType);
                return this;
            }

            public MCR_ALS changeRegressorType_St(string St_RegressorType)
            {
                import_DLL.changeRegressorType_forSt(_self, St_RegressorType);
                return this;
            }


            public MCR_ALS fit(double[] D, int D_colunm, int D_row, int n_component, double[] C, double[] ST)
            {
                SetEnvironmentVariable("OPENBLAS_MAIN_FREE", "1");
                SetEnvironmentVariable("OPENBLAS_NUM_THREADS", "4");
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

                import_DLL.fit(_self, D, D_colunm, D_row, n_component, C, ST);

                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;

                return this;
            }

            public unsafe void get_C(double[] C, int colunm, int row)
            {
                fixed(double* _C = C)import_DLL.get_C(_self, _C, colunm, row);

            }

            public unsafe void get_St(double[] St, int colunm, int row)
            {
                fixed(double* _St = St) import_DLL.get_St(_self, _St, colunm, row);
            }

            public void Test()
            {
                import_DLL.Test(_self);
            }
        }

        public class DataToImage
        {
            private IntPtr _self;
            public DataToImage(double[] Data, uint Image_width, uint Image_height)
            {
                _self = Create_DataToImage_Instance(Data, Image_width, Image_height);
            }
            public void Delete()
            {
                Delete_DataToImage_Instance(_self);
            }
            public DataToImage changeToImage()
            {
                import_DLL.changeToImage(_self);
                return this;
            }
            public unsafe void get_Image(byte[] Image)
            {
                fixed (byte* _Image = Image) import_DLL.getImage(_self, _Image);
            }
            public unsafe void get_ImageSize(ref int Image_width, ref int Image_height)
            {
                fixed (int* _Image_width = &Image_width, _Image_height = &Image_height) import_DLL.getImage_Size(_self, _Image_width, _Image_height);
            }

            public void saveImage(string outputPath)
            {
                import_DLL.saveImage(_self, outputPath);
            }
        }
    }

}
