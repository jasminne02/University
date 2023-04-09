import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class WelcomeFrame extends JFrame{
    private JButton loginButton;
    private JButton registerButton;
    private JPanel WelcomePanel;

    public WelcomeFrame() {
        setContentPane(WelcomePanel);
        setSize(500, 500);
        setLocationRelativeTo(null);
        this.setDefaultCloseOperation(EXIT_ON_CLOSE);

        loginButton.addActionListener(new LoginAction());
        registerButton.addActionListener(new RegisterAction());

        this.setVisible(true);
    }

    private void closeWindow(){
        this.dispose();
    }

    class LoginAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            new LoginFrame();
            closeWindow();
        }
    }

    class RegisterAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            new RegisterFrame();
            closeWindow();
        }
    }

}
