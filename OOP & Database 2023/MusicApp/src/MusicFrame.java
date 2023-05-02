import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.List;

public class MusicFrame extends JFrame{
    private JTextField nameField;
    private JTextField durationField;
    private JButton saveMusicButton;
    private JButton deleteMusicButton;
    private JPanel MusicPanel;
    private JComboBox<String> albumComboBox;
    private JComboBox<String> genreComboBox;

    public static String username;

    public static String musicName;

    private final List<String> albumNames;
    private final List<Integer> albumIds;

    Connection connection;
    PreparedStatement preparedStatement;

    public MusicFrame(){
        setContentPane(MusicPanel);
        setSize(500, 400);
        setLocationRelativeTo(null);

        // gets music author username
        if(musicName != null){
            username = Queries.getUsernameById(Queries.getMusicAuthorId(musicName));
        }

        albumNames = Queries.getAllMusicAlbumNames(username);
        albumIds = Queries.getAllMusicAlbumIds(username);

        for(String name : albumNames){
            albumComboBox.addItem(name);
        }

        genreComboBox.addItem("Rock");
        genreComboBox.addItem("Jazz");
        genreComboBox.addItem("Rock");
        genreComboBox.addItem("Hip Hop");
        genreComboBox.addItem("Pop music");
        genreComboBox.addItem("Techno");
        genreComboBox.addItem("Folk music");
        genreComboBox.addItem("Metal");
        genreComboBox.addItem("Classical");

        // gets music info if not new music to be created
        if(musicName != null){
            List<String> resultList = Queries.getAllMusicInfo(musicName);

            nameField.setText(resultList.get(1));
            durationField.setText(String.format(java.util.Locale.US,"%.2f", Float.parseFloat(resultList.get(2))));
            genreComboBox.setSelectedItem(resultList.get(3));
            albumComboBox.setSelectedItem(resultList.get(4));
            MusicPanel.updateUI();
        }

        saveMusicButton.addActionListener(new SaveAction());
        deleteMusicButton.addActionListener(new DeleteAction());

        this.setVisible(true);
    }

    class SaveAction implements ActionListener {

        String name;
        Float duration;
        String genre;
        Integer albumID;
        Integer userId;


        @Override
        public void actionPerformed(ActionEvent e) {
            // checks if user has permissions to save data og this music
            if(User.isAdmin || username == null || User.username.equals(username)){
                name = nameField.getText();
                connection = DataBaseConnection.getConnection();
                try{
                    duration = Float.parseFloat(durationField.getText());
                } catch (NumberFormatException exception){
                    JOptionPane.showMessageDialog(null, "The duration must be a number!");
                }
                genre = (String) genreComboBox.getSelectedItem();
                String item = (String) albumComboBox.getSelectedItem();
                if(albumNames.size() > 0){
                    int idx = albumNames.indexOf(item);
                    albumID = albumIds.get(idx);
                }

                if(username == null){
                    userId = Queries.getUserId(User.username);
                } else {
                    userId = Queries.getUserId(username);
                }

                // checks if name already exists
                if(Queries.isMusicNameExisting(name)){
                    updateMusic(Queries.getMusicId(name, userId));
                    dispose();
                } else {
                    createMusic();
                    dispose();
                }

                MusicPanel.updateUI();
            } else {
                JOptionPane.showMessageDialog(null, "You have no permissions to change music info!");

            }
        }

        private void createMusic(){
            // only musicians can create music
            if(!User.isMusician){
                JOptionPane.showMessageDialog(null, "You have no permissions to create music");
            } else if(!Queries.isMusicNameExisting(name)){
                try {
                    String sql;
                    if(albumID != null){
                        sql = "insert into music(name, duration_in_minutes, genre, account_id, album_id) values(?,?,?,?,?)";

                        preparedStatement= connection.prepareStatement(sql);
                        preparedStatement.setString(1, name);
                        preparedStatement.setFloat(2, duration);
                        preparedStatement.setString(3, genre);
                        preparedStatement.setInt(4, userId);
                        preparedStatement.setInt(5, albumID);
                    } else {
                        sql = "insert into music(name, duration_in_minutes, genre, account_id) values(?,?,?,?)";

                        preparedStatement= connection.prepareStatement(sql);
                        preparedStatement.setString(1, name);
                        preparedStatement.setFloat(2, duration);
                        preparedStatement.setString(3, genre);
                        preparedStatement.setInt(4, userId);
                    }
                    preparedStatement.execute();
                    System.out.println("Music created");
                } catch (SQLException exception) {
                    exception.printStackTrace();
                }
            } else {
                JOptionPane.showMessageDialog(null, "That music name is already taken");
            }
        }

        private void updateMusic(int musicId){
            // checks if user has permissions to update this music
            if(!User.isMusician || !User.username.equals(username)){
                JOptionPane.showMessageDialog(null, "You have no permissions to update music");
            } else if(musicName.equals(nameField.getText())){

                try {
                    String updateSQL;

                    if(albumID != null){
                        updateSQL = "update music set name=?, duration_in_minutes=?, genre=?, album_id=? where id=?";

                        preparedStatement= connection.prepareStatement(updateSQL);
                        preparedStatement.setString(1, name);
                        preparedStatement.setFloat(2, duration);
                        preparedStatement.setString(3, genre);
                        preparedStatement.setInt(4, albumID);
                        preparedStatement.setInt(5, musicId);
                        preparedStatement.executeUpdate();
                    } else {
                        updateSQL = "update music set name=?, duration_in_minutes=?, genre=? where id=?";

                        preparedStatement= connection.prepareStatement(updateSQL);
                        preparedStatement.setString(1, name);
                        preparedStatement.setFloat(2, duration);
                        preparedStatement.setString(3, genre);
                        preparedStatement.setInt(4, musicId);
                        preparedStatement.executeUpdate();
                    }

                    System.out.println("Music updated");
                } catch (SQLException exception) {
                    exception.printStackTrace();
                }
            } else {
                JOptionPane.showMessageDialog(null, "That music name is already taken");
            }
        }
    }

    class DeleteAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            // checks if user has permissions to delete this music
            if(User.isAdmin || (User.isMusician && User.username.equals(username))){
                connection = DataBaseConnection.getConnection();

                String sql ="delete from music where id=?";
                int musicID = Queries.getMusicId(nameField.getText(), Queries.getUserId(username));

                try {
                    preparedStatement= connection.prepareStatement(sql);
                    preparedStatement.setInt(1, musicID);
                    preparedStatement.executeUpdate();
                    System.out.println("Music deleted");

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
