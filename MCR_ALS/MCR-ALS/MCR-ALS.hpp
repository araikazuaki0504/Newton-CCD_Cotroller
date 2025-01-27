#pragma once

#include <iostream>
#include <cstring>
#include <fstream>

#include "Regressors.hpp"

class MCR_ALS{
    public:
        MCR_ALS(int maxIter = 50);
        ~MCR_ALS();
        MCR_ALS& changeRegressorType_forALL(const char* C_RegressorType, const char* St_RegressorType);
        MCR_ALS& changeRegressorType_forC(const char* RegressorType);
        MCR_ALS& changeRegressorType_forSt(const char* RegressorType);
        MCR_ALS& fit(double* D, int D_colunm, int D_row, int n_component, double* C, double* ST);
        double* get_C();
        double* get_St();
        void Test();
    private:
        const int tol_n_above_min = 10;
        const int tol_n_increase = 10;
        const double tol_increase = 0.0;
        LinerRegression* _C_regr = new OLS();
        LinerRegression* _St_regr = new NNLS(); 
        double* _C = nullptr;
        int _C_Colunm = 0;
        int _C_Row = 0;
        double* _ST = nullptr;
        int _ST_Colunm = 0;
        int _ST_Row = 0;
        int _maxIter = 0;
        std::vector<double> errs;
        bool ismin_err(double val);
};

extern "C"
{
    __declspec(dllexport) MCR_ALS* __stdcall Create_MCR_ALS_Instance(int maxIter = 50);

    __declspec(dllexport) MCR_ALS& __stdcall changeRegressorType_forALL(MCR_ALS* self, const char* C_RegressorType, const char* St_RegressorType);

    __declspec(dllexport) MCR_ALS& __stdcall changeRegressorType_forC(MCR_ALS* self, const char* RegressorType);

    __declspec(dllexport) MCR_ALS& __stdcall changeRegressorType_forSt(MCR_ALS* self, const char* RegressorType);

    __declspec(dllexport) void __stdcall fit(MCR_ALS* self, double* D, int D_colunm, int D_row, int n_component, double* C, double* ST);

    __declspec(dllexport) void __stdcall get_C(MCR_ALS* self,double* C, int C_colunm, int C_row);

    __declspec(dllexport) void __stdcall get_St(MCR_ALS* self, double* St, int St_colunm, int St_row);

    __declspec(dllexport) void __stdcall Delete_MCR_ALS_Instance(MCR_ALS* self);

    __declspec(dllexport) void __stdcall Test(MCR_ALS* self);

}