package uni.fmi;

public abstract class Employee extends Person{
    private String personalNumber;
    private String joinDate;

    public Employee(String name, int age, String personalNumber, String joinDate){
        super(name, age);
        this.personalNumber = personalNumber;
        this.joinDate = joinDate;
    }

    @Override
    public String toString() {
        return super.toString() +
                ", personalNumber='" + personalNumber + '\'' +
                ", joinDate='" + joinDate + '\'';
    }

    public void setPersonalNumber(String personalNumber) {
        this.personalNumber = personalNumber;
    }

    public void setJoinDate(String joinDate) {
        this.joinDate = joinDate;
    }

    public String getPersonalNumber() {
        return personalNumber;
    }

    public String getJoinDate() {
        return joinDate;
    }
}
