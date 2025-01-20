#pragma once

#include <iostream>
#include <cstring>
#include <fstream>

#include "Regressors.hpp"

class MCR_ALS{
    public:
        MCR_ALS(int maxIter = 50);
        ~MCR_ALS();
        MCR_ALS& changeRegressorType_forALL(std::string C_RegressorType,std::string St_RegressorType);
        MCR_ALS& changeRegressorType_forC(std::string RegressorType);
        MCR_ALS& changeRegressorType_forSt(std::string RegressorType);
        MCR_ALS& fit(double* D, int D_colunm, int D_row, double* C = nullptr, double* ST = nullptr, int targetMatrix_colunm = 0, int targetMatrix_row = 0);
        double* get_C();
        double* get_St();
    private:
        const int tol_n_above_min = 10;
        const int tol_n_increase = 10;
        const double tol_increase = 0.0;
        LinerRegression* _C_regr = nullptr;
        LinerRegression* _St_regr = nullptr; 
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
    __declspec(dllexport) MCR_ALS* __stdcall Create_MCR_ALS_Instance()
    {
        return new MCR_ALS();
    }

    __declspec(dllexport) MCR_ALS& __stdcall changeRegressorType_forALL(MCR_ALS* self, std::string C_RegressorType, std::string St_RegressorType)
    {
        return self->changeRegressorType_forALL(C_RegressorType, St_RegressorType);
    }

    __declspec(dllexport) MCR_ALS& __stdcall changeRegressorType_forC(MCR_ALS* self, std::string RegressorType)
    {
        return self->changeRegressorType_forC(RegressorType);
    }

    __declspec(dllexport) MCR_ALS& __stdcall changeRegressorType_forSt(MCR_ALS* self, string RegressorType)
    {
        return self->changeRegressorType_forSt(RegressorType);
    }

    __declspec(dllexport) MCR_ALS& __stdcall fit(MCR_ALS* self, double* D, int D_colunm, int D_row, double* C = nullptr, double* ST = nullptr, int targetMatrix_colunm = 0, int targetMatrix_row = 0)
    {
        return self->fit(D, D_colunm, D_row, C, ST, targetMatrix_colunm, targetMatrix_row);
    }

    __declspec(dllexport) double* __stdcall get_C(MCR_ALS* self)
    {
        return self->get_C();
    }

    __declspec(dllexport) double* __stdcall get_St(MCR_ALS* self)
    {
        return self->get_St();
    }

    __declspec(dllexport) void  __stdcall Delete_MCR_ALS_Instance(MCR_ALS* self)
    {
        delete self;
    }
}