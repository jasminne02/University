import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.ArrayList;
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

        if(username.isEmpty()){
            username = Queries.getMusicAuthorUsername(nameField.getText());
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

        if(!musicName.isEmpty()){
            List<String> resultList = Queries.getAllUserInfo(username);

            nameField = Integer.parseInt(resultList.get(0));
            durationField.setText(resultList.get(1));
            genreComboBox = resultList.get(1);
            albumComboBox = resultList.get(2);
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
            if(User.isAdmin || (User.isMusician && User.username.equals(Queries.getMusicAuthorUsername(name)))){
                name = nameField.getText();
                try{
                    duration = Float.parseFloat(durationField.getText());
                } catch (NumberFormatException exception){
                    JOptionPane.showMessageDialog(null, "The duration must be a number!");
                }
                genre = (String) genreComboBox.getSelectedItem();
                String item = (String) albumComboBox.getSelectedItem();
                albumID = Integer.parseInt(String.valueOf(albumIds.get(albumNames.indexOf(item))));
                userId = Queries.getUserId(username);

                if(Queries.isMusicNameExisting(name, userId)){
                    updateMusic(Queries.getMusicId(name, userId));
                } else {
                    createMusic();
                }

                MusicPanel.updateUI();
            } else {
                JOptionPane.showMessageDialog(null, "You have no permissions change music info!");

            }
        }

        private void createMusic(){
            String sql="insert into music(name, duration, genre, user_id, album_id) values(?,?,?,?,?)";

            try {
                preparedStatement= connection.prepareStatement(sql);
                preparedStatement.setString(1, name);
                preparedStatement.setFloat(2, duration);
                preparedStatement.setString(3, genre);
                preparedStatement.setInt(4, userId);
                preparedStatement.setInt(5, albumID);
                preparedStatement.execute();
                System.out.println("Music created");
            } catch (SQLException exception) {
                exception.printStackTrace();
            }
        }

        private void updateMusic(int musicId){

            String updateSQL ="update music set name=?, duration=?, genre=?, album_id=? where id=?";

            try {
                preparedStatement= connection.prepareStatement(updateSQL);
                preparedStatement.setString(1, name);
                preparedStatement.setFloat(2, duration);
                preparedStatement.setString(3, genre);
                preparedStatement.setInt(4, albumID);
                preparedStatement.setInt(5, musicId);
                preparedStatement.executeUpdate();
                System.out.println("Music updated");
            } catch (SQLException exception) {
                exception.printStackTrace();
            }
        }
    }

    class DeleteAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if(User.isAdmin || (User.isMusician && User.username.equals(Queries.getMusicAuthorUsername(nameField.getText())))){
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
                JOptionPane.showMessageDialog(null, "You have no permissions change music info!");
            }
        }
    }
}
