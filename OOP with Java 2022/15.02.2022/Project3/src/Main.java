import java.util.Scanner;

public class Main {
    public static void main(String[] args){
        Scanner input = new Scanner(System.in);
        int number;

        do{
            System.out.print("Колко числа на Фибоначи да ви покажа? ");
            number = input.nextInt();
        } while (number < 1);
        System.out.println();

        System.out.println("Метод с цикъл");
        FibonacciLoop(number);
        System.out.println("\n");

        System.out.println("Метод с рекурсия");
        for(int i = 0; i < number; i++) {
            System.out.print(FibonacciRecursion(i) + " ");
        }
    }

    public static void FibonacciLoop(int number){
        int[] fibonacci = new int[number];

        if(number == 1){
            fibonacci[0] = 0;
        } else if(number == 2){
            fibonacci[0] = 0;
            fibonacci[1] = 1;
        } else if(number >= 2){
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for(int i = 2; i < number; i++){
                fibonacci[i] = fibonacci[i-1] + fibonacci[i-2];
            }
        }

        for(int i = 0; i < number; i++){
            System.out.print(fibonacci[i] + " ");
        }
    }

    public static long FibonacciRecursion(int number){
        long[] fibonacci = new long[number + 1];

        if(number <= 1){
            return number;
        }
        if(fibonacci[number] != 0){
            return fibonacci[number];
        }
        long fibonacciNumber = (FibonacciRecursion(number-1) + FibonacciRecursion(number-2));
        fibonacci[number] = fibonacciNumber;
        return fibonacciNumber;
    }
}
