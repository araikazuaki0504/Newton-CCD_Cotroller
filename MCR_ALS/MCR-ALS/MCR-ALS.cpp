#include "MCR-ALS.hpp"

MCR_ALS::MCR_ALS(int maxIter):_maxIter{maxIter}
{
    _C_regr = new OLS();
    _St_regr = new OLS();
}

MCR_ALS::~MCR_ALS()
{
    delete[] _C;
    delete[] _ST;
    delete _C_regr;
    delete _St_regr;
}

MCR_ALS& MCR_ALS::changeRegressorType_forALL(std::string C_RegressorType,std::string St_RegressorType)
{
    if(C_RegressorType == "OLS")
    {
        delete _C_regr;
        _C_regr = new OLS();
    }
    else if (C_RegressorType == "NNLS")
    {
        delete _C_regr;
        _C_regr = new NNLS();
    }

    if(St_RegressorType == "OLS")
    {
        delete _St_regr;
        _St_regr = new OLS();
    }
    else if (St_RegressorType == "NNLS")
    {
        delete _St_regr;
        _St_regr = new NNLS();
    }

    std::cout << "\e[32mChange To C_Regressor -> " << C_RegressorType << " & St_Regressor -> " << St_RegressorType << "\e[m" << std::endl;

    return *this;
}

MCR_ALS& MCR_ALS::changeRegressorType_forC(std::string RegressorType)
{
    if(RegressorType == "OLS")
    {
        delete _C_regr;
        _C_regr = new OLS();
    }
    else if (RegressorType == "NNLS")
    {
        delete _C_regr;
        _C_regr = new NNLS();
    }

    std::cout << "changeTo C_Regressor -> " << RegressorType <<  std::endl;

    return *this;
}

MCR_ALS& MCR_ALS::changeRegressorType_forSt(std::string RegressorType)
{
    if(RegressorType == "OLS")
    {
        delete _St_regr;
        _St_regr = new OLS();
    }
    else if (RegressorType == "NNLS")
    {
        delete _St_regr;
        _St_regr = new NNLS();
    }

    std::cout << "change To St_Regressor -> " << RegressorType <<  std::endl;

    return *this;
}

MCR_ALS& MCR_ALS::fit(double* D, int D_colunm, int D_row, double* C, double* ST, int targetMatrix_colunm, int targetMatrix_row)
{
    std::cout << "start MCR fitting.." << std::endl;
    if(C == nullptr && ST == nullptr)return *this;
    if(_C != nullptr)delete[] _C;
    if(_ST != nullptr)delete[] _ST;

    _C_Colunm = D_colunm;
    _C_Row = (C != nullptr ?  targetMatrix_row : targetMatrix_colunm);

    _ST_Colunm = (ST != nullptr ? targetMatrix_colunm : targetMatrix_row);
    _ST_Row = D_row;

    double* D_T = new double[D_colunm * D_row];
    double* Matrix_T = new double[_ST_Colunm * _ST_Row];
    double* cal_D = new double[D_colunm * D_row];

    int n_increase = 0;
    int n_above_min = 0;
    int n_iter = 0;

    bool loop_flag = true;

    errs.clear();

    _C  = (C != nullptr  ? copyMatrix(C,_C_Colunm,_C_Row,new double[_C_Colunm * _C_Row]) : new double[_C_Colunm *  _C_Row]);
    _ST = (ST != nullptr ? copyMatrix(ST,_ST_Colunm,_ST_Row,new double[_ST_Colunm * _ST_Row]) : new double[_ST_Colunm *  _ST_Row]);

    //std::cout << "D : " << std::endl;
    showMatrix(D,D_colunm,D_row);

    for(int i = 0; i < _maxIter; i++)
    {
        n_iter = i + 1;
        if(_ST != nullptr)
        {
            std::cout << "ST : " << "(" << _ST_Colunm << "," << _ST_Row << ")" << std::endl;
            showMatrix(_ST,_ST_Colunm,_ST_Row);
            transpose(D,D_colunm,D_row,D_T);
            transpose(_ST,_ST_Colunm,_ST_Row,Matrix_T);
            
            //showMatrix(D_T,D_row,D_colunm);
            //showMatrix(Matrix_T,targetMatrix_colunm,targetMatrix_row);
            _C_regr->fit(Matrix_T,_ST_Row,_ST_Colunm,D_T,D_row,D_colunm);

            showMatrix(Matrix_T,targetMatrix_row,targetMatrix_colunm);
            showMatrix(D_T,D_row,D_colunm);

            double* C_tmp = _C_regr->getCoef();
            std::cout << "C_tmp" << std::endl;
            showMatrix(C_tmp,_C_Colunm,_C_Row);

            constraints(C_tmp,_C_Colunm,_C_Row);
            //showMatrix(C_tmp,_C_Colunm,_C_Row);

            cal_D = product(C_tmp,_C_Colunm,_C_Row,_ST,_ST_Colunm,_ST_Row,cal_D);
            double tmp_err = meanSquareError(cal_D,D,D_colunm,D_row);

            if(ismin_err(tmp_err))n_above_min = 0;
            else n_above_min += 1;

            if(n_above_min > tol_n_above_min)
            {
                std::cout << "break 1" << std::endl;
                break;
            }

            std::cout << tmp_err << std::endl << (1 + tol_increase) << std::endl;
            if(errs.size() == 0)
            {
                errs.push_back(tmp_err);
                _C = copyMatrix(C_tmp,_C_Colunm,_C_Row,_C);
            }
            else if (tmp_err <= errs.end()[-1] * (1 + tol_increase))
            {
                errs.push_back(tmp_err);
                _C = copyMatrix(C_tmp,_C_Colunm,_C_Row,_C);;
            }
            else
            {
                std::cout << "break 2" << std::endl;
                break;
            }

            if(errs.size() > 1)
            {
                if(errs.end()[-1] > errs.end()[-2])n_increase += 1;
                else n_increase *= 0;
            }

            if(n_increase > tol_n_increase)
            {
                std::cout << "break 3" << std::endl;
                break;
            }
        }

        if (_C != nullptr)
        {
            std::cout << "C : " << "(" << _C_Colunm << "," << _C_Row << ")" << std::endl;
            showMatrix(_C,_C_Colunm,_C_Row);
            //showMatrix(_C,D_row,D_colunm);
            //showMatrix(D,D_colunm,D_row);
            _St_regr->fit(_C,_C_Colunm,_C_Row,D,D_colunm,D_row);
            double* ST_tmp = _St_regr->getCoef(false);
            std::cout << "ST_tmp" << std::endl;
            showMatrix(ST_tmp,_ST_Colunm,_ST_Row);

            constraints(ST_tmp,_ST_Colunm,_ST_Row);
            //showMatrix(ST_tmp,_ST_Colunm,_ST_Row);

            cal_D = product(_C,_C_Colunm,_C_Row,ST_tmp,_ST_Colunm,_ST_Row,cal_D);
            double tmp_err = meanSquareError(cal_D,D,D_colunm,D_row);

            if(ismin_err(tmp_err))n_above_min = 0;
            else n_above_min += 1;

            if(n_above_min > tol_n_above_min)
            {
                std::cout << "break 4" << std::endl;
                break;
            }

            std::cout << tmp_err << std::endl << errs.end()[-1] << std::endl << (1 + tol_increase) << std::endl;
            if(errs.size() == 0)
            {
                errs.push_back(tmp_err);
                _ST = copyMatrix(ST_tmp,_ST_Colunm,_ST_Row,_ST);
            }
            else if (tmp_err <= errs.end()[-1] * (1 + tol_increase))
            {
                errs.push_back(tmp_err);
                _ST = copyMatrix(ST_tmp,_ST_Colunm,_ST_Row,_ST);
            }
            else if (loop_flag)
            {
                loop_flag = true;
            }
            else
            {
                std::cout << "break 5" << std::endl;
                break;
            }

            if(errs.size() > 1)
            {
                if(errs.end()[-1] > errs.end()[-2])n_increase += 1;
                else n_increase *= 0;
            }

            if(n_increase > tol_n_increase)
            {
                std::cout << "break 6" << std::endl;
                break;
            }

            if(n_iter >= _maxIter)
            {
                std::cout << "break 7" << std::endl;
                break;
            }

            n_iter = i + 1;

        }
    }
    delete[] D_T;
    delete[] Matrix_T;
    delete[] cal_D;

    return *this;
}

bool MCR_ALS::ismin_err(double val)
{
    if(errs.size() == 0)return true;
    else
    {
        bool tmp = false;
        for(double err : errs)tmp |= (val > err);
        return !tmp;
    }
}

double* MCR_ALS::get_C()
{
    return _C;
}


double* MCR_ALS::get_St()
{
    return _ST;
}