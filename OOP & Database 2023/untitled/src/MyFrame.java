import javax.swing.*;
import java.awt.*;

public class MyFrame  extends JFrame{

    JPanel upPanel = new JPanel();
    JPanel midPanel = new JPanel();
    JPanel downPanel = new JPanel();

    JLabel firstNameL = new JLabel("Име:");
    JLabel lastNameL = new JLabel("Фамилия:");
    JLabel genderL = new JLabel("Пол:");
    JLabel ageL = new JLabel("Години:");
    JLabel salaryL = new JLabel("Заплата:");

    JTextField firstNameTF = new JTextField();
    JTextField lastNameTF = new JTextField();
    JTextField ageTF = new JTextField();
    JTextField salaryTF = new JTextField();

    String[] item = {"Мъж", "Жена"};
    JComboBox<String> genderComboBox = new JComboBox<String>(item);

    JButton addButton = new JButton("Добавяне");
    JButton deleteButton = new JButton("Изтриване");
    JButton editButton = new JButton("Редактиране");

    public MyFrame() {
        this.setSize(400, 500);
        this.setDefaultCloseOperation(EXIT_ON_CLOSE);
        this.setLayout(new GridLayout(3, 1));

        // upPanel ------------------------------------------
        upPanel.setLayout(new GridLayout(5, 2));
        upPanel.add(firstNameL);
        upPanel.add(firstNameTF);
        upPanel.add(lastNameL);
        upPanel.add(lastNameTF);
        upPanel.add(genderL);
        upPanel.add(genderComboBox);
        upPanel.add(ageL);
        upPanel.add(ageTF);
        upPanel.add(salaryL);
        upPanel.add(salaryTF);

        this.add(upPanel);

        // midPanel -----------------------------------------
        midPanel.add(addButton);
        midPanel.add(deleteButton);
        midPanel.add(editButton);
        this.add(midPanel);

        // downPanel ----------------------------------------


        this.setVisible(true);
    }

}
