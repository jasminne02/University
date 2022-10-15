package uni.fmi;

public abstract class Person {
    private String name;
    private int age;

    public Person(String name, int age){
        this.name = name;
        this.age =age;
    }

    @Override
    public String toString() {
        return "name='" + name + '\'' +
                ", age=" + age;
    }

    public void setName(String name) {
        if (this.name == null) this.name = name;
    }

    public void setAge(int age) {
        if (age>0) this.age = age;
    }

    public String getName() {
        return name;
    }

    public int getAge() {
        return age;
    }
}
