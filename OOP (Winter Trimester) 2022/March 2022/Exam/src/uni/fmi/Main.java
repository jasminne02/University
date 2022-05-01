package uni.fmi;

import java.text.DecimalFormat;
import java.util.ArrayList;

public class Main {
    private static final DecimalFormat decimalFormat = new DecimalFormat("0.00");

    public static void main(String[] args){

        ArrayList<Food> food = new ArrayList<>();

        Burger b1 = new Burger(3.50, 250, "Cheeseburger", true);
        Burger b2 = new Burger(5.10, 500, "Big Mac", true);
        Burger b3 = new Burger(2.80, 150, "Hamburger", false);
        Burger b4 = new Burger(4.30, 350, "Spicy Burger", true);
        Burger b5 = new Burger(3.40, 300, "Chicken burger", false);

        food.add(b1);
        food.add(b2);
        food.add(b3);
        food.add(b4);
        food.add(b5);

        HotDog h1 = new HotDog(1.80, 200, "Original Hot dog", false);
        HotDog h2 = new HotDog(3.10, 350, "Double Hot dog", true);
        HotDog h3 = new HotDog(2.40, 250, "Original Hot dog with ketchup", true);

        food.add(h1);
        food.add(h2);
        food.add(h3);

        PrintFood(food);

        double profit = Profit(food);
        int orderedFries = Burger.getFriesCounter();

        System.out.println("The restaurant profit is: " + decimalFormat.format(profit));
        System.out.println("Ordered fries: " + orderedFries);

    }

    public static double Profit(ArrayList<Food> food){
        double profit = 0;

        for (Food x : food) {
            profit += x.getPrice();
        }

        return profit;
    }

    public static void PrintFood(ArrayList<Food> food){
        for (Food x : food) {
            System.out.println(x.toString());
        }
        System.out.println();
    }
}
