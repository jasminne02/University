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
    private JButton logOutButton;

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
        searchAlbumsButton.addActionListener(new AlbumSearchAction());
        myPlaylistsButton.addActionListener(new ShowPlaylistAction());
        logOutButton.addActionListener(new LogOutAction());

        this.setVisible(true);
    }

    static class ProfileAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            ProfileFrame.username = User.username;
            new ProfileFrame();
        }
    }

    class LogOutAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            User.removeCurrentUser();
            dispose();
            new WelcomeFrame();
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

    static class AlbumSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            new AlbumSearchFrame();
        }
    }

    static class ShowPlaylistAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            new AllPlaylistsFrame();
        }
    }

}
