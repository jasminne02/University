package uni.fmi;

public class Faculty extends Employee{
    private String position;

    public Faculty(String name, int age, String personalNumber, String joinDate, String position) {
        super(name, age, personalNumber, joinDate);
        this.position = position;
    }

    @Override
    public String toString() {
        return "Faculty{" + super.toString() +
                ", position='" + position + '\'' +
                '}';
    }

    public void setPosition(String position) {
        this.position = position;
    }

    public String getPosition() {
        return position;
    }
}
