import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.List;

public class ProfileFrame extends JFrame{
    private JPanel ProfilePanel;
    private JTextField usernameField;
    private JTextField firstNameField;
    private JTextField lastNameField;
    private JTextField ageField;
    private JButton editProfileButton;
    private JButton deleteProfileButton;
    private JPasswordField currentPasswordField;
    private JPasswordField newPasswordField;
    private JLabel genderLabel;
    private JLabel isMusicianLabel;
    private JLabel errorMessageLabel;

    Connection connection;
    PreparedStatement preparedStatement;

    public static String username;
    private final int userID;
    private String currentPassword;
    private String currentUsername;
    private boolean updateCurrentUserInfo;

    public ProfileFrame(){
        setContentPane(ProfilePanel);
        setSize(500, 400);
        setLocationRelativeTo(null);

        List<String> resultList = Queries.getAllUserInfo(username);

        userID = Integer.parseInt(resultList.get(0));
        usernameField.setText(resultList.get(1));
        currentUsername = resultList.get(1);
        currentPassword = resultList.get(2);
        firstNameField.setText(resultList.get(3));
        lastNameField.setText(resultList.get(4));
        ageField.setText(resultList.get(5));
        genderLabel.setText(resultList.get(6));
        isMusicianLabel.setText(resultList.get(7));
        ProfilePanel.updateUI();

        updateCurrentUserInfo = username.equals(User.username);

        editProfileButton.addActionListener(new EditProfile());
        deleteProfileButton.addActionListener(new DeleteAction());

        this.setVisible(true);
    }

    class EditProfile implements ActionListener {

        private String username;
        private String passwordCurrentEntered;
        private String passwordNewEntered;
        private String firstName;
        private String lastName;
        private int age;

        @Override
        public void actionPerformed(ActionEvent e) {
            errorMessageLabel.setText("");
            username = usernameField.getText();
            passwordCurrentEntered = String.valueOf(currentPasswordField.getPassword());
            passwordNewEntered = String.valueOf(newPasswordField.getPassword());
            firstName = firstNameField.getText();
            lastName = lastNameField.getText();

            connection = DataBaseConnection.getConnection();

            try {
                age = Integer.parseInt(ageField.getText());
            } catch (NumberFormatException exception){
                showErrorMessage("The age must be a number!");
            }

            if(fieldsEmptyCheck()) {
                showErrorMessage("All text fields are required (except new password)!");
            } else if(!currentUsername.equals(username)){
                if(!validUsername()){
                    showErrorMessage("Invalid username - only letters, '_' and numbers allowed, min chars 3");
                } else if(Queries.isUserExisting(username)){
                    showErrorMessage("This username is already taken");
                }
            } else if(username.length() <= 2){
                showErrorMessage("The password is too short, must be more than 2 symbols");
            }

            if(!passwordNewEntered.isEmpty() && !checkPasswordsChangingValidity()){
                showErrorMessage("The current password is not correct. The new one must be different!");
            } else if(username.length() < 5){
                showErrorMessage("The password must be 5 at least symbols");
            }

            if((String.valueOf(errorMessageLabel.getText()).strip()).equals("")){
                editUser();
                if(updateCurrentUserInfo){
                    User.setCurrentUser(username);
                }
                ProfilePanel.updateUI();
                updateCurrentUserInfo = false;
                currentUsername = username;
                currentPassword = passwordNewEntered;
            }
        }

        private void editUser(){
            if(passwordNewEntered.isEmpty()){
                passwordNewEntered = currentPassword;
            }

            String updateSQL ="update account set username=?, password=?, firstName=?, lastName=?, age=? where id=?";

            try {
                preparedStatement= connection.prepareStatement(updateSQL);
                preparedStatement.setString(1, username);
                preparedStatement.setString(2, passwordNewEntered);
                preparedStatement.setString(3, firstName);
                preparedStatement.setString(4, lastName);
                preparedStatement.setInt(5, age);
                preparedStatement.setInt(6, userID);
                preparedStatement.executeUpdate();
                System.out.println("User updated");
            } catch (SQLException exception) {
                exception.printStackTrace();
            }
        }

        private void showErrorMessage(String message){
            errorMessageLabel.setText(message);
            ProfilePanel.updateUI();
        }

        private boolean validUsername(){
            for (char element:username.toCharArray()) {
                if(!(Character.isAlphabetic(element) || Character.isDigit(element) || element == '_')){
                    return false;
                }
            }
            return true;
        }

        private boolean checkPasswordsChangingValidity(){
            return currentPassword.equals(passwordCurrentEntered) && !passwordNewEntered.equals(currentPassword);
        }

        private boolean fieldsEmptyCheck() {
            return username.isEmpty() || passwordCurrentEntered.isEmpty() || firstName.isEmpty() || lastName.isEmpty();
        }
    }

    class DeleteAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            connection = DataBaseConnection.getConnection();

            String sql ="delete from account where id=?";

            try {
                preparedStatement= connection.prepareStatement(sql);
                preparedStatement.setInt(1, userID);
                preparedStatement.executeUpdate();
                System.out.println("User deleted");

                if(updateCurrentUserInfo){
                    User.removeCurrentUser();
                    dispose();
                    for (Frame frame : JFrame.getFrames()) {
                        frame.dispose();}
                    new WelcomeFrame();
                }
            } catch (SQLException exception) {
                exception.printStackTrace();
            }
        }
    }
}

