import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class AlbumFrame extends JFrame{
    private JPanel MusicPanel;
    private JTextField nameField;
    private JButton saveAlbumButton;
    private JButton deleteAlbumButton;
    private JLabel totalSongsField;
    private JPanel AlbumPanel;

    public static String username;

    public static String albumName;
    Connection connection;
    PreparedStatement preparedStatement;

    public AlbumFrame(){
        setContentPane(AlbumPanel);
        setSize(500, 400);
        setLocationRelativeTo(null);

        // if no username set
        if(username == null && albumName != null){
            username = Queries.getUsernameById(Queries.getAlbumAuthorId(albumName));
        }

        // if album is not chosen to be created
        if(albumName != null){
            nameField.setText(albumName);

            int albumId = Queries.getAlbumId(albumName);
            totalSongsField.setText(String.valueOf(Queries.getAlbumTotalSongs(albumId)));

            MusicPanel.updateUI();
        }

        saveAlbumButton.addActionListener(new SaveAction());
        deleteAlbumButton.addActionListener(new DeleteAction());

        this.setVisible(true);
    }

    class SaveAction implements ActionListener {

        String name;
        Integer userId;


        @Override
        public void actionPerformed(ActionEvent e) {
            if(User.isAdmin || User.username.equals(username) || (User.isMusician && username == null)){
                name = nameField.getText();
                connection = DataBaseConnection.getConnection();

                if(username == null){
                    userId = Queries.getUserId(User.username);
                } else {
                    userId = Queries.getUserId(username);
                }

                if(Queries.isAlbumNameExisting(name)){
                    updateAlbum();
                } else {
                    createAlbum();
                }

                MusicPanel.updateUI();
                dispose();
            } else {
                JOptionPane.showMessageDialog(null, "You have no permissions to change music info!");

            }
        }

        private void createAlbum(){
            if(!User.isMusician){
                JOptionPane.showMessageDialog(null, "You have no permissions to create music");
            } else if(!Queries.isAlbumNameExisting(name)){
                try {
                    String sql = "insert into album(name, user_id) values(?,?)";

                    preparedStatement= connection.prepareStatement(sql);
                    preparedStatement.setString(1, name);
                    preparedStatement.setInt(2, userId);
                    preparedStatement.execute();
                    System.out.println("Album created");
                } catch (SQLException exception) {
                    exception.printStackTrace();
                }
            } else {
                JOptionPane.showMessageDialog(null, "That music name is already taken");
            }
        }

        private void updateAlbum(){

            if(!User.isMusician || !User.username.equals(username)){
                JOptionPane.showMessageDialog(null, "You have no permissions to update music");
            } else if(albumName.equals(nameField.getText())){

                try {
                    String updateSQL = "update album set name=?, user_id=? where id=?";

                    preparedStatement= connection.prepareStatement(updateSQL);
                    preparedStatement.setString(1, name);
                    preparedStatement.setInt(2, userId);
                    preparedStatement.setInt(3, Queries.getAlbumId(albumName));
                    preparedStatement.executeUpdate();

                    System.out.println("Album updated");
                } catch (SQLException exception) {
                    exception.printStackTrace();
                }
            } else {
                JOptionPane.showMessageDialog(null, "That album name is already taken");
            }
        }
    }

    class DeleteAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if(User.isAdmin || User.username.equals(username)){
                connection = DataBaseConnection.getConnection();

                String sql ="delete from album where id=?";
                int musicID = Queries.getAlbumId(nameField.getText());

                try {
                    preparedStatement= connection.prepareStatement(sql);
                    preparedStatement.setInt(1, musicID);
                    preparedStatement.executeUpdate();
                    System.out.println("Album deleted");

                    dispose();
                } catch (SQLException exception) {
                    exception.printStackTrace();
                }
            } else {
                JOptionPane.showMessageDialog(null, "You have no permissions to change music info!");
            }
        }
    }

}
