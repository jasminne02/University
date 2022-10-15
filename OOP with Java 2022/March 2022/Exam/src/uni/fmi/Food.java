package uni.fmi;

public abstract class Food {
    private double price;
    private int grams;
    private String name;

    public Food(double price, int grams, String name){
        this.price = price;
        this.grams = grams;
        this.name = name;
    }

    public String toString() {
        return "price=" + price +
                ", grams=" + grams +
                ", name='" + name + '\'' + ", ";
    }

    public double getPrice() {
        return price;
    }

    public int getGrams() {
        return grams;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setGrams(int grams) {
        this.grams = grams;
    }

    public void setPrice(double price) {
        this.price = price;
    }
}
