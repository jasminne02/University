package uni.fmi;

public class Student extends Person{
    private int facultyNumber;
    private String speciality;

    public Student(String name, int age, int facultyNumber, String speciality){
        super(name, age);
        this.facultyNumber = facultyNumber;
        this.speciality = speciality;
    }

    @Override
    public String toString() {
        return "Student{" + super.toString() +
                ", facultyNumber=" + facultyNumber +
                ", speciality='" + speciality + '\'' +
                '}';
    }

    public void setFacultyNumber(int facultyNumber) {
        this.facultyNumber = facultyNumber;
    }

    public void setSpeciality(String speciality) {
        this.speciality = speciality;
    }

    public int getFacultyNumber() {
        return facultyNumber;
    }

    public String getSpeciality() {
        return speciality;
    }
}
