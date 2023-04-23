import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.List;
import java.util.Vector;

public class PlaylistFrame extends JFrame{
    private JPanel PlaylistPanel;
    private JTextField nameField;
    private JList<String> allMusicList;
    private JButton deleteButton;
    private JButton saveButton;
    private JLabel totalPlayTime;

    public static String playlistName;
    Connection connection;
    PreparedStatement preparedStatement;

    public PlaylistFrame(){
        setContentPane(PlaylistPanel);
        setSize(500, 400);
        setLocationRelativeTo(null);

        if(playlistName != null){
            List<String> resultList = Queries.getAllPlaylistInfo(playlistName, Queries.getUserId(User.username));
            Vector<String> vector = new Vector<>(Queries.getAllMusicInPlaylist(playlistName, Queries.getUserId(User.username)));
            float totalTime =  Queries.getTotalMusicPlayTime(vector);

            nameField.setText(resultList.get(1));
            totalPlayTime.setText(String.format(java.util.Locale.US, "%.2f", totalTime));
            allMusicList.setListData(vector);
            PlaylistPanel.updateUI();
        }

        saveButton.addActionListener(new SaveAction());
        deleteButton.addActionListener(new DeleteAction());

        this.setVisible(true);
    }

    class SaveAction implements ActionListener {

        String name;

        @Override
        public void actionPerformed(ActionEvent e) {
            name = nameField.getText();
            connection = DataBaseConnection.getConnection();

            if(Queries.isMusicNameExisting(name)){
                updatePlaylist(Queries.getMusicId(name, Queries.getUserId(User.username)));
            } else {
                createPlaylist();
            }

            PlaylistPanel.updateUI();
            dispose();
        }

        private void createPlaylist(){
            if(!Queries.isPlaylistNameExisting(name)){
                try {
                    String sql;
                    sql = "insert into playlist(name, account_id) values(?,?)";

                    preparedStatement= connection.prepareStatement(sql);
                    preparedStatement.setString(1, name);
                    preparedStatement.setInt(2, Queries.getUserId(User.username));
                    preparedStatement.execute();
                    System.out.println("Playlist created");
                } catch (SQLException exception) {
                    exception.printStackTrace();
                }
            } else {
                JOptionPane.showMessageDialog(null, "That playlist name is already taken");
            }
        }

        private void updatePlaylist(int playlistId){

            if(Queries.isPlaylistNameExisting(playlistName)){

                try {
                    String updateSQL;

                    updateSQL = "update playlist set name=?, account_id=? where id=?";

                    preparedStatement= connection.prepareStatement(updateSQL);
                    preparedStatement.setString(1, name);
                    preparedStatement.setInt(2, Queries.getUserId(User.username));
                    preparedStatement.setInt(3, playlistId);
                    preparedStatement.executeUpdate();

                    System.out.println("Playlist updated");
                } catch (SQLException exception) {
                    exception.printStackTrace();
                }
            } else {
                JOptionPane.showMessageDialog(null, "That playlist name is already taken");
            }
        }
    }

    class DeleteAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            connection = DataBaseConnection.getConnection();

            String sql ="delete from playlist where id=?";
            int playlistID = Queries.getPlaylistId(nameField.getText(), Queries.getUserId(User.username));

            try {
                preparedStatement= connection.prepareStatement(sql);
                preparedStatement.setInt(1, playlistID);
                preparedStatement.executeUpdate();
                System.out.println("Playlist deleted");

                dispose();
            } catch (SQLException exception) {
                exception.printStackTrace();
            }
        }
    }
}
