import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class HomeFrame extends JFrame{
    private JPanel HomePanel;
    private JLabel welcomeLabel;
    private JButton profileButton;
    private JButton searchProfilesButton;
    private JButton searchMusicButton;
    private JButton searchAlbumsButton;
    private JButton myPlaylistsButton;

    public HomeFrame(){
        setContentPane(HomePanel);
        setSize(600, 300);
        setLocationRelativeTo(null);
        this.setDefaultCloseOperation(EXIT_ON_CLOSE);

        if(User.isAdmin){
            welcomeLabel.setText("Welcome, Admin");
        } else {
            welcomeLabel.setText("Welcome, " + User.name);
        }

        profileButton.addActionListener(new ProfileAction());
        searchProfilesButton.addActionListener(new ProfilesSearchAction());
        searchMusicButton.addActionListener(new MusicSearchAction());

        this.setVisible(true);
    }

    static class ProfileAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            ProfileFrame.username = User.username;
            new ProfileFrame();
        }
    }

    static class ProfilesSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            new ProfilesSearchFrame();
        }
    }

    static class MusicSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            new MusicSearchFrame();
        }
    }

}
