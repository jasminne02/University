#include <iostream>

using namespace std;

int avg_int(int a, int b, int c) {
	int average;

	__asm {
		mov eax, a
		add eax, b
		add eax, c
		mov eax, eax
		mov edx, 0
		mov ebx, 3
		div ebx
		mov average, eax
	}

	return average;
}

int func(int a, int b) {
	int result;

	__asm {
		mov eax, a
		mov ebx, b

		cmp eax, ebx
		je return1
		jl return2
		jg return3

		return1:
		mov eax, 100
		jmp return

		return2:
		mov eax, 50
		jmp return

		return3:
		mov eax, 200
		jmp return

		return:

		mov result, eax
	}

	return result;
}

int main() {
	//cout << avg_int(1, 2, 3);
	cout << func(5, 3);
	return 1;
}

