using System;
using System.Runtime.InteropServices;

namespace CCD_controller_windows_form
{
    internal static class import_DLL
    {
        [DllImport("MCR_ALS_64.dll")]
        public static extern void showMatrix(double[] Matrix, int colunm, int row, bool allShow = false);

        [DllImport("MCR_ALS_64.dll")]
        public static extern void SVD_float(float[] Matrix, int Matrix_colunm, int Matrix_row, float[] U, float[] S, float[] V);

        [DllImport("MCR_ALS_64.dll")]
        public static extern void SVD_double(double[] Matrix, int Matrix_colunm, int Matrix_row, double[] U, double[] S, double[] V);

        [DllImport("MCR_ALS_64.dll")]
        public static extern void NMF(double[] Matrix, int Matrix_colunm, int Matrix_row, int n_components, double[] W, double[] H, double epsilon = 1e-10);

        [DllImport("MCR_ALS_64.dll")]
        public static extern void product(double[] Matrix_A, int Matrix_A_colunm_, int Matrix_A_row_, double[] Matrix_B, int Matrix_B_colunm_, int Matrix_B_row_, double[] Matrix);

        [DllImport("MCR_ALS_64.dll")]
        private static extern IntPtr Create_MCR_ALS_Instance();

        [DllImport("MCR_ALS_64.dll")]
        private static extern MCR_ALS changeRegressorType_forALL(IntPtr self, string C_RegressorType, string St_RegressorType);

        [DllImport("MCR_ALS_64.dll")]
        private static extern MCR_ALS changeRegressorType_forC(IntPtr self, string RegressorType);

        [DllImport("MCR_ALS_64.dll")]
        private static extern MCR_ALS changeRegressorType_forSt(IntPtr self, string RegressorType);

        [DllImport("MCR_ALS_64.dll")]
        private static extern MCR_ALS fit(IntPtr self, double[] D, int D_colunm, int D_row, double[] C = null, double[] ST = null, int targetMatrix_colunm = 0, int targetMatrix_row = 0);

        [DllImport("MCR_ALS_64.dll")]
        private static extern double[] get_C(IntPtr self);

        [DllImport("MCR_ALS_64.dll")]
        private static extern double[] get_St(IntPtr self);

        [DllImport("MCR_ALS_64.dll")]
        private static extern void Delete_MCR_ALS_Instance(IntPtr self);

        [DllImport("MCR_ALS_64.dll")]
        private static extern void Test(IntPtr self);


        public class MCR_ALS
        {
            private IntPtr _self;

            public MCR_ALS()
            {
                _self = Create_MCR_ALS_Instance();

            }

            ~MCR_ALS()
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

            public MCR_ALS fit(double[] D, int D_colunm, int D_row, double[] C = null, double[] ST = null, int targetMatrix_colunm = 0, int targetMatrix_row = 0)
            {
                import_DLL.fit(_self, D, D_colunm, D_row, C, ST, targetMatrix_colunm, targetMatrix_row);
                return this;
            }

            public double[] get_C()
            {
                return import_DLL.get_C(_self);
            }

            public double[] get_St()
            {
                return import_DLL.get_St(_self);
            }

            public void test()
            {
                import_DLL.Test(_self);
            }
        }


    }

}
