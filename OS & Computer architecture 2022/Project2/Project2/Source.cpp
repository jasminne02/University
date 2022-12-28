#include <iostream>

using namespace std;

int func1() {
	// ((2+2)*3)/(3-1) = 6

	int result;

	__asm {
		mov eax, 2
		add eax, 2
		imul eax, 3

		mov edx, 0
		mov ecx, 3
		sub ecx, 1
		div ecx
		mov result, eax
	}

	return result;
}

void func2() {
	__asm {
		mov edx, 0
		mov eax, 10
		add ecx, 2
		div ecx
	}
}

int main() {

	cout << "((2+2)*3)/(3-1) = " << func1() << "\n\n";

	func2();

	return 1;
}
