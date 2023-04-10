import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.*;

public class RegisterFrame extends JFrame{

    Connection connection;
    PreparedStatement preparedStatement;

    private JTextField usernameField;
    private JPasswordField passwordField1;
    private JPasswordField passwordField2;
    private JTextField firstNameField;
    private JTextField lastNameField;
    private JTextField ageFiled;
    private JComboBox<String> genderComboBox;
    private JCheckBox isMusicianCheckBox;
    private JButton submitButton;
    private JPanel RegisterPanel;
    private JLabel errorMessageLabel;

    public RegisterFrame() {
        setContentPane(RegisterPanel);
        setSize(650, 650);
        setLocationRelativeTo(null);
        this.setDefaultCloseOperation(EXIT_ON_CLOSE);

        genderComboBox.addItem("Male");
        genderComboBox.addItem("Female");

        submitButton.addActionListener(new SubmitAction());

        this.setVisible(true);
    }

    private void closeWindow(){
        this.dispose();
    }


    class SubmitAction implements ActionListener {

        private String username;
        private String password1;
        private String password2;
        private String firstName;
        private String lastName;
        private String gender;
        private Integer age;
        private boolean isMusician;

        @Override
        public void actionPerformed(ActionEvent e) {
            errorMessageLabel.setText("");
            username = usernameField.getText();
            password1 = String.valueOf(passwordField1.getPassword());
            password2 = String.valueOf(passwordField2.getPassword());
            firstName = firstNameField.getText();
            lastName = lastNameField.getText();
            gender = String.valueOf(genderComboBox.getSelectedItem());
            isMusician = isMusicianCheckBox.isSelected();

            connection = DataBaseConnection.getConnection();

            try {
                age = Integer.parseInt(ageFiled.getText());
            } catch (NumberFormatException exception){
                showErrorMessage("The age must be a number!");
            }

            if(fieldsEmptyCheck()) {
                showErrorMessage("All text fields are required!");
            } else if(!validUsername()){
                showErrorMessage("Invalid username - only letters, '_' and numbers allowed, min chars 3");
            } else if(Queries.isUserExisting(username)){
                showErrorMessage("This username is already taken");
            } else if(!equalPasswordsCheck()){
                showErrorMessage("The passwords are not the same!");
            } else if(!validPassword()){
                showErrorMessage("The password must be 5 symbols at least");
            }

            if((String.valueOf(errorMessageLabel.getText()).strip()).equals("")){
                createUser();
                closeWindow();
                User.setCurrentUser(username);
                new HomeFrame();
            }
        }

        private void createUser(){
            String sql="insert into account(username, password, firstName, lastName, age, gender, isMusician ) values(?,?,?,?,?,?,?)";

            try {
                preparedStatement= connection.prepareStatement(sql);
                preparedStatement.setString(1, username);
                preparedStatement.setString(2, password1);
                preparedStatement.setString(3, firstName);
                preparedStatement.setString(4, lastName);
                preparedStatement.setInt(5, age);
                preparedStatement.setString(6, gender);
                preparedStatement.setBoolean(7, isMusician);
                preparedStatement.execute();
                System.out.println("User created");
            } catch (SQLException exception) {
                exception.printStackTrace();
            }
        }

        private void showErrorMessage(String message){
            errorMessageLabel.setText(message);
            RegisterPanel.updateUI();
        }

        private boolean fieldsEmptyCheck() {
            return username.isEmpty() || password1.isEmpty() || password2.isEmpty() || firstName.isEmpty() ||
                    lastName.isEmpty();
        }

        private boolean equalPasswordsCheck(){
            return password1.equals(password2);
        }

        private boolean validUsername(){
            if (username.length() <= 2) {
                return false;
            }

            for (char element:username.toCharArray()) {
                if(!(Character.isAlphabetic(element) || Character.isDigit(element) || element == '_')){
                    return false;
                }
            }
            return true;
        }

        private boolean validPassword(){
            return password1.length() >= 5;
        }

    }
}
