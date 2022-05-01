import java.util.Scanner;

public class Main {
    public static void main(String[] args){
        Scanner input = new Scanner(System.in);

        System.out.println("Опции");
        System.out.println("1. Намиране на перфектни числа");
        System.out.println("2. Намиране на сума и средна стойност на интервал от числа");
        System.out.println("0. Изход");

        int number;
        do{
            System.out.print("Изберете една от опциите: ");
            number = input.nextInt();
        } while(number < 0 || number > 2);
        System.out.println();

        if(number == 1 || number == 2){
            int firstNumber, lastNumber;
            System.out.println("Въведете числов интервал");
            System.out.print("Начало на интервала: ");
            firstNumber = input.nextInt();
            System.out.print("Край на интервала: ");
            lastNumber = input.nextInt();

            if(number == 1){
                System.out.printf("Перфектни числа в интервала [%d ; %d]: ", firstNumber, lastNumber);
                System.out.println();

                while(firstNumber <= lastNumber){
                    int divisorsSum = 0;
                    for(int i = 1; i < firstNumber; i++){
                        if(firstNumber % i == 0){
                            divisorsSum += i;
                        }
                    }

                    if(firstNumber == divisorsSum){
                        System.out.println(firstNumber);
                    }
                    firstNumber++;
                }
            } else {
                int sum = 0;
                int counter = 0;
                int i = firstNumber;

                while(i <= lastNumber){
                    sum += i;
                    counter++;
                    i++;
                }

                double average = sum / (double) counter;
                System.out.printf("Сбор от числата в интервала [%d ; %d]: %d", firstNumber, lastNumber, sum);
                System.out.println();
                System.out.println("Средна стойност на числата: " + average);
            }
        }
    }
}
