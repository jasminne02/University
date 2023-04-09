import javax.swing.*;

public class HomeFrame extends JFrame{
    private JPanel HomePanel;
    private JLabel welcomeLabel;
    private JButton profileButton;
    private JButton searchContentButton;
    private JButton createMusicButton;
    private JButton createPlaylistButton;
    private JButton editPlaylistButton;
    private JButton deletePlaylistButton;
    private JButton editAlbumButton;
    private JButton createAlbumButton;
    private JButton deleteAlbumButton;
    private JButton editMusicButton;
    private JButton deleteMusicButton;

    public HomeFrame(){
        setContentPane(HomePanel);
        setSize(400, 400);
        setLocationRelativeTo(null);
        this.setDefaultCloseOperation(EXIT_ON_CLOSE);

        if(User.isAdmin){
            welcomeLabel.setText("Welcome, Admin");
        } else {
            welcomeLabel.setText("Welcome, " + User.name);
        }

        this.setVisible(true);
    }

}
