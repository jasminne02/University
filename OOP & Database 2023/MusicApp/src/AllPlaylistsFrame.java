import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.Vector;

public class AllPlaylistsFrame extends JFrame {
    private JPanel AllPlaylistsPanel;
    private JList<String> allPlaylistsList;
    private JButton createPlaylistButton;
    private JButton selectButton;
    public static boolean addMusicToPlaylist;
    public static String musicName;


    public AllPlaylistsFrame(){
        setContentPane(AllPlaylistsPanel);
        setSize(700, 500);
        setLocationRelativeTo(null);

        Vector<String> vector = new Vector<>(Queries.getAllUserPlaylist(Queries.getUserId(User.username)));
        allPlaylistsList.setListData(vector);

        createPlaylistButton.addActionListener(new CreateAction());
        selectButton.addActionListener(new SelectAction());

        this.setVisible(true);
    }

    static class CreateAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            PlaylistFrame.playlistName = null;
            new PlaylistFrame();
        }
    }

    class SelectAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if(addMusicToPlaylist){
                String name = allPlaylistsList.getSelectedValue();
                int userId = Queries.getUserId(User.username);
                int musicAuthorId = userId;

                if(!Queries.isUserMusicAuthor(musicName, userId)){
                    musicAuthorId = Queries.getMusicAuthorId(musicName);
                }

                int musicId = Queries.getMusicId(musicName, musicAuthorId);
                int playlistId = Queries.getPlaylistId(name, userId);

                try {
                    String updateSQL;
                    Connection connection = DataBaseConnection.getConnection();

                    updateSQL = "insert into music_playlist(music_id, playlist_id) values(?,?)";

                    PreparedStatement preparedStatement = connection.prepareStatement(updateSQL);
                    preparedStatement.setInt(1, musicId);
                    preparedStatement.setInt(2, playlistId);
                    preparedStatement.executeUpdate();

                    System.out.println("Playlist updated");
                } catch (SQLException exception) {
                    exception.printStackTrace();
                }

                addMusicToPlaylist = false;
                dispose();

            } else {
                PlaylistFrame.playlistName = allPlaylistsList.getSelectedValue();
                new PlaylistFrame();
            }
        }

    }
}
