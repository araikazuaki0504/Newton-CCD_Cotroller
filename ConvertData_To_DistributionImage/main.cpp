#include <random>

#include "DataToImage.hpp"

int main()
{
	double* Data = new double[37];

	std::random_device rd;
	std::mt19937 gen(rd());
	std::uniform_real_distribution<> dis(0.0, 1.0);

	for (int i = 0; i < 37; i++)
	{
		Data[i] = dis(gen);
	}

	DataToImage Image(Data, 1000, 1000);
	Image.changeToImage().saveImage("C:\\CCD_controller_windows_form(Newton)\\Images\\TestImage.jpg");

	delete[] Data;
}