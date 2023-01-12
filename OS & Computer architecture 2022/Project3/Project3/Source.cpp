#include <iostream>

using namespace std;

int solve(int m, int k, int n) {
	// ((n*k)!/(n-k)!)*m
	
	long result;

	__asm {
		mov eax, n
		mul k

		mov ebx, 1
		mov ecx, 1
		
		for1:
		imul ebx, ecx
		inc ecx
		cmp ecx, eax
		jle for1

		mov result, ebx
		
		mov eax, n
		sub eax, k

		mov ebx, 1
		mov ecx, 1

		for2:
		imul ebx, ecx
		inc ecx
		cmp ecx, eax
		jle for2

		mov eax, result
		div ebx
	    mul m

		mov result, eax

	}

	return result;
}

int main() {
	cout << solve(3, 2, 6);
	return 0;
}
