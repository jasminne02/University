#include <iostream>

using namespace std;

void func1(int a, int b, int c) {
	// Въведете 3 числа от клавиатурата, изведете броя на положителните числа и сумата им
	int positives_count = 0;
	int sum = 0;

	__asm {
		mov eax, 0
		add eax, a
		add eax, b
		add eax, c
		mov sum, eax


		mov ecx, 0
		mov eax, a
		cmp eax, 0
		jg done
		mov eax, b
		cmp eax, 0
		jg done
		mov eax, c
		cmp eax, 0
		jg done

		done :
			add ecx, 1

		return:

			
		mov positives_count, ecx
	}

	cout << "positive numbers count: " << positives_count << "\n";
	cout << "sum: " << sum << "\n";

}


void func2(int a, int b, int c) {
	// Намерете най-голямото число от 3 , въведени от клавиатурата.

	int biggest = 0;

	__asm {
		mov eax, a
		cmp eax, b
		jg check_third_num
		mov eax, c
		cmp eax, b
		jg third_is_bigger
		jl second_is_bigger

		check_third_num:
		    cmp eax, c
			jg return
			mov eax, c
			jmp return

		third_is_bigger:
		    mov eax, c
			jmp return

		second_is_bigger:
		    mov eax, b
			jmp return

		return:
	    
		mov biggest, eax
	}

	cout << "biggest number: " << biggest << "\n\n";
}

void func3(int a, int b, int c) {
	// Подредете 3 числа в низходящ ред с вложени if на асемблер.
	int array[3];

	__asm {
		mov eax, a
		cmp eax, b
		jg cmp_first_and_third
		jl cmp_second_and_third

		cmp_first_and_third :
		   cmp eax, c
		   jg first_biggest
		   jl third_biggest

		   first_biggest :
		       mov array[0], eax
			   mov eax, b
			   cmp eax, c
			   jg second_bigger
			   jl third_bigger

			   second_bigger:
			       mov array[1], eax
				   mov eax, c
				   mov array[2], eax
				   jmp return
				
			   third_bigger:
				   mov array[2], eax
				   mov eax, c
				   mov array[1], eax
				   jmp return

		    third_biggest:
			   mov eax, c
			   mov array[0], eax
			   mov eax, a
			   mov array[1], eax
			   mov eax, c
			   mov array[2], eax
			   jmp return


		cmp_second_and_third :
		   mov eax, b
		   cmp eax, c
		   jg second_biggest
		   jl third_is_biggest

		   second_biggest:
		       mov array[0], eax
			   mov eax, a
			   cmp eax, c
			   jg first_bigger
			   jl third_is_bigger

			   first_bigger:
			       mov array[1], eax
				   mov eax, c
				   mov array[2], eax
				   jmp return

			   third_is_bigger:
			       mov array[2], eax
			       mov eax, c
				   mov array[1], eax
				   jmp return

		   third_is_biggest:
			   mov array[1], eax
			   mov eax, c
			   mov array[0], eax
			   mov eax, a
			   mov array[2], eax
			   jmp return

		return:
	}

	cout << "Sorted numbers in desc order: " << array[0] << " " << array[1] << " " << array[2] << "\n\n";
}


int main() {
	int a, b, c;
	cout << "Enter a number: ";
	cin >> a;
	cout << "Enter a number: ";
	cin >> b;
	cout << "Enter a number: ";
	cin >> c;

	func1(a, b, c);
	func2(a, b, c);
	func3(a, b, c);
	return 1;
}

