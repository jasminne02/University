import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class MyFrame  extends JFrame{

    Connection connection;
    PreparedStatement statement;
    ResultSet result;

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

        addButton.addActionListener(new AddAction());

        // downPanel ----------------------------------------


        this.setVisible(true);
    }

    class AddAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {

            connection = DataBaseConnection.getConnection();
            String sql="insert into person(firstName, lastName, gender, age, salary ) values(?,?,?,?,?)";

            try {
                statement= connection.prepareStatement(sql);
                statement.setString(1, firstNameTF.getText());
                statement.setString(2, lastNameTF.getText());
                statement.setString(3, genderComboBox.getSelectedItem().toString());
                statement.setInt(4, Integer.parseInt(ageTF.getText()));
                statement.setFloat(5, Float.parseFloat(salaryTF.getText()));
                statement.execute();
            } catch (SQLException exception) {
                // TODO Auto-generated catch block
                exception.printStackTrace();
            }

        }
    }

}
