#pragma once
#include <iostream>
using namespace std;

class Indexer
{
private:
	double* arr;
	int start; 
	int length;

	bool Index(int);

public:
	Indexer(double*, int, int, int);
	int Length();
	double& operator[] (int);
};

Indexer::Indexer(double* _arr, int _start, int _length, int arrLength)
{
	if (_start < 0 || _length <= 0 || _start + _length >= arrLength)
		throw invalid_argument("Error");
	arr = _arr;
	start = _start;
	length = _length;
}

int Indexer::Length()
{
	return length;
}

bool Indexer::Index(int index)
{
	if (index < 0 || index >= Length())
		return false;
	else
		return true;
}

double& Indexer::operator[] (const int i)
{
	if (!Index(i))
		throw out_of_range("Error");
	else
		return arr[i + start];
}