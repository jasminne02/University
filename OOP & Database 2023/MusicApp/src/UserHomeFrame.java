import javax.swing.*;

public class UserHomeFrame extends JFrame {

    private JPanel UserHomePanel;
    private JLabel welcomeLabel;
    private JButton profileButton;
    private JButton searchContentButton;
    private JButton createPlaylistButton;
    private JButton editPlaylistButton;
    private JButton deletePlaylistButton;

    public UserHomeFrame(){
        setContentPane(UserHomePanel);
        setSize(400, 400);
        setLocationRelativeTo(null);
        this.setDefaultCloseOperation(EXIT_ON_CLOSE);

        welcomeLabel.setText("Welcome, " + User.name);

        this.setVisible(true);
    }

}
