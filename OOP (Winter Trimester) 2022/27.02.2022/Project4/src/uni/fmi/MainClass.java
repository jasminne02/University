package uni.fmi;

public class MainClass {
    public static void main(String[] args){
        Student student = new Student("Alex", 16, 12342334, "Software Engineering");
        Faculty faculty = new Faculty("Ivan", 51, "234AA3B", "03.04.2021", "professor");
        Staff staff = new Staff("Anna", 32, "C234a", "24.11.2016", "secretary");

        System.out.println(student.toString());
        System.out.println(faculty.toString());
        System.out.println(staff.toString());
    }
}
