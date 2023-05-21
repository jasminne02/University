import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class LoginFrame extends JFrame {

    private JTextField usernameField;
    private JPasswordField passwordField;
    private JButton submitButton;
    private JPanel LoginPanel;
    private JLabel statusLabel;
    private JButton goBackButton;

    public LoginFrame() {
        setContentPane(LoginPanel);
        setSize(400, 400);
        setLocationRelativeTo(null);
        this.setDefaultCloseOperation(EXIT_ON_CLOSE);

        submitButton.addActionListener(new SubmitAction());
        goBackButton.addActionListener(new GoBackAction());

        this.setVisible(true);
    }

    private void closeWindow(){
        this.dispose();
    }

    class SubmitAction implements ActionListener {

        String username;
        String password;

        @Override
        public void actionPerformed(ActionEvent e) {
            statusLabel.setText("");
            username = usernameField.getText();
            password = String.valueOf(passwordField.getPassword());

            if(!Queries.isUserExisting(username)){
                // checks if user with that username already exists
                statusLabel.setText("The user does not exist");
                LoginPanel.updateUI();
            } else if(!Queries.isUserPasswordValid(username, password)){
                // checks if correct password
                statusLabel.setText("The password is not correct");
            } else {
                statusLabel.setText("");
                closeWindow();
                User.setCurrentUser(username);
                new HomeFrame();

            }
        }
    }

    class GoBackAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            closeWindow();
            new WelcomeFrame();
        }
    }
}
