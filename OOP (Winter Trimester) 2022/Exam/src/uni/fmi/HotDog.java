package uni.fmi;

public class HotDog extends Food{
    private boolean withKetchup;

    public HotDog(double price, int grams, String name, boolean withKetchup) {
        super(price, grams, name);
        this.withKetchup = withKetchup;
    }

    @Override
    public String toString() {
        return "HotDog{" + super.toString() +
                "withKetchup=" + withKetchup +
                '}';
    }

    public boolean isWithKetchup() {
        return withKetchup;
    }

    public void setWithKetchup(boolean withKetchup) {
        this.withKetchup = withKetchup;
    }
}
