package uni.fmi;

public class Burger extends Food{
    private boolean fries;
    private static int friesCounter;

    public Burger(double price, int grams, String name, boolean fries) {
        super(price, grams, name);
        this.fries = fries;

        if (fries){
            friesCounter ++;
        }
    }

    @Override
    public String toString() {
        return "Burger{" + super.toString() +
                "fries=" + fries +
                '}';
    }

    public boolean isFries() {
        return fries;
    }

    public static int getFriesCounter() {
        return friesCounter;
    }

    private static void setFriesCounter(int friesCounter) {
        Burger.friesCounter = friesCounter;
    }

    public void setFries(boolean fries) {
        this.fries = fries;
    }
}
