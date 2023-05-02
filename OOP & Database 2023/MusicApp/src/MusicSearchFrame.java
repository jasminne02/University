import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Objects;
import java.util.Vector;

public class MusicSearchFrame extends JFrame{
    private JPanel MusicSearchPanel;
    private JPanel SearchPanel;
    private JPanel firstNameSearchButton;
    private JTextField nameField;
    private JButton nameSearchButton;
    private JComboBox<String> genreField;
    private JTextField authorField;
    private JButton genreSearchButton;
    private JButton authorButton;
    private JList<Object> resultList;
    private JTextField musicNumberField;
    private JButton musicButton;
    private JButton createMusicButton;
    private JButton addToPlaylistButton;


    public MusicSearchFrame(){
        setContentPane(MusicSearchPanel);
        setSize(700, 500);
        setLocationRelativeTo(null);

        genreField.addItem("Rock");
        genreField.addItem("Jazz");
        genreField.addItem("Rock");
        genreField.addItem("Hip Hop");
        genreField.addItem("Pop music");
        genreField.addItem("Techno");
        genreField.addItem("Folk music");
        genreField.addItem("Metal");
        genreField.addItem("Classical");


        musicButton.addActionListener(new MusicSearchAction());
        createMusicButton.addActionListener(new CreateMusicAction());
        nameSearchButton.addActionListener(new MusicNameSearchAction());
        genreSearchButton.addActionListener(new GenreMusicSearchAction());
        authorButton.addActionListener(new MusicAuthorSearchAction());
        addToPlaylistButton.addActionListener(new AddToPlaylistAction());

        this.setVisible(true);
    }

    class MusicSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if(resultList.getSelectedValue() == null){
                JOptionPane.showMessageDialog(null, "Select music first!");
            } else {
                MusicFrame.musicName = (String) resultList.getSelectedValue();
                new MusicFrame();
            }
        }
    }

    static class CreateMusicAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            MusicFrame.musicName = null;
            new MusicFrame();
        }
    }

    class MusicNameSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if(Queries.isMusicNameExisting(nameField.getText())){
                MusicFrame.musicName = nameField.getText();
                new MusicFrame();
            } else {
                JOptionPane.showMessageDialog(null, "No search result!");
            }
        }
    }

    class MusicAuthorSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            String authorName = authorField.getText();
            int authorId = Queries.getUserIdByName(authorName);

            Vector<String> vector = new Vector<>(Queries.getMusicByAuthorID(authorId));
            resultList.setListData(vector);
            if(vector.size() == 0){
                JOptionPane.showMessageDialog(null, "No search result!");
            }
        }
    }

    class GenreMusicSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            String genre = Objects.requireNonNull(genreField.getSelectedItem()).toString();

            Vector<String> vector = new Vector<>(Queries.getMusicByGenre(genre));
            resultList.setListData(vector);
            if(vector.size() == 0){
                JOptionPane.showMessageDialog(null, "No search result!");
            }
        }

    }

    class AddToPlaylistAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if(resultList.getSelectedValue() == null){
                JOptionPane.showMessageDialog(null, "Select music first!");
            } else {
                AllPlaylistsFrame.addMusicToPlaylist = true;
                AllPlaylistsFrame.musicName = (String) resultList.getSelectedValue();
                new AllPlaylistsFrame();
            }
        }

    }

}
