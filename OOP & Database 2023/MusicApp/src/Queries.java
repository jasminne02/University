import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class Queries {

    private static Connection connection;
    private static Statement statement;
    private static PreparedStatement preparedStatement;
    private static String query;
    private static ResultSet resultSet;

    public static boolean isUserExisting(String username) {

        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT username FROM account";
            statement = connection.createStatement();
            resultSet = statement.executeQuery(query);
            while (resultSet.next()){
                String existingUsername = resultSet.getString("username");
                if(username.equals(existingUsername)){
                    return true;
                }
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return false;
    }

    public static boolean isUserPasswordValid(String username, String password) {

        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT username, password FROM account";
            statement = connection.createStatement();
            resultSet = statement.executeQuery(query);
            while (resultSet.next()){
                String existingUsername = resultSet.getString("username");
                String existingPassword = resultSet.getString("password");
                if(username.equals(existingUsername) && password.equals(existingPassword)){
                    return true;
                }
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return false;
    }

    public static List<String> getAllUserInfo(String username){
        connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        try{
            query = "SELECT * FROM account WHERE username = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, username);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                result.add(resultSet.getString("id"));
                result.add(resultSet.getString("username"));
                result.add(resultSet.getString("password"));
                result.add(resultSet.getString("firstName"));
                result.add(resultSet.getString("lastName"));
                result.add(resultSet.getString("age"));
                result.add(resultSet.getString("gender"));
                result.add(resultSet.getString("isMusician"));
                return result;
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return result;
    }

    public static String getUserFullName(String username){
        connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT username, firstName, lastName FROM account WHERE username = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, username);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                String firstName = resultSet.getString("firstName");
                String lastName = resultSet.getString("lastName");
                return firstName + " " + lastName;
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return "";
    }

    public static int getUserAge(String username){
        connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT username, age FROM account WHERE username = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, username);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                return resultSet.getInt("age");
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return 0;
    }

    public static boolean isMusician(String username) {
        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT username, isMusician FROM account WHERE username = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, username);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                return resultSet.getBoolean("isMusician");
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return false;
    }

    public static List<String> getUserInfoByFirstName(String firstName){
        connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        try{
            query = "SELECT * FROM account WHERE firstname = ?";
            firstLastNameQueryExtracted(firstName, connection, result, query);
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return result;
    }

    public static List<String> getUserInfoByLastName(String lastName){
        connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        try{
            query = "SELECT * FROM account WHERE lastname = ?";
            firstLastNameQueryExtracted(lastName, connection, result, query);
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return result;
    }

    public static String getUsernameById(int id){
        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT id, username FROM account WHERE id = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setInt(1, id);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                return resultSet.getString("username");
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return "";
    }

    private static void firstLastNameQueryExtracted(String lastName, Connection connection, List<String> result, String query) throws SQLException {
        preparedStatement = connection.prepareStatement(query);
        preparedStatement.setString(1, lastName);
        resultSet = preparedStatement.executeQuery();
        while (resultSet.next()){
            result.add(resultSet.getString("username"));
            result.add(resultSet.getString("firstName"));
            result.add(resultSet.getString("lastName"));
            result.add(String.valueOf(resultSet.getInt("age")));
            result.add(resultSet.getString("gender"));
            result.add(resultSet.getString("isMusician"));

        }
    }

    public static int getUserId(String username){
        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT * FROM account WHERE username = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, username);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                return Integer.parseInt(resultSet.getString("id"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return 0;
    }

    public static int getUserIdByName(String name){
        connection = DataBaseConnection.getConnection();
        int resultID = -1;

        try{
            query = "SELECT * FROM account WHERE firstname = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, name);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                resultID = Integer.parseInt(resultSet.getString("id"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }

        if (resultID == -1){
            try{
                query = "SELECT * FROM account WHERE lastname = ?";
                preparedStatement = connection.prepareStatement(query);
                preparedStatement.setString(1, name);
                resultSet = preparedStatement.executeQuery();
                while (resultSet.next()){
                    resultID = Integer.parseInt(resultSet.getString("id"));
                }
            } catch (SQLException exception){
                exception.printStackTrace();
            }
        }

        return resultID;
    }

    public static int getMusicId(String name, int userId){
        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT * FROM music WHERE account_id = ? and name = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setInt(1, userId);
            preparedStatement.setString(2, name);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                return Integer.parseInt(resultSet.getString("id"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return 0;
    }

    public static List<String> getAllMusicAlbumNames(String username){
        connection = DataBaseConnection.getConnection();
        int userId = getUserId(username);
        List<String> names = new ArrayList<>();

        return getStrings(userId, names);
    }

    public static List<Integer> getAllMusicAlbumIds(String username){
        connection = DataBaseConnection.getConnection();
        int userId = getUserId(username);
        List<Integer> ids = new ArrayList<>();

        try{
            query = "SELECT * FROM album WHERE user_id = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setInt(1, userId);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                ids.add(Integer.parseInt(resultSet.getString("id")));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }

        return ids;
    }

    public static boolean isMusicNameExisting(String name){
        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT * FROM music WHERE name = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, name);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                if(name.equals(resultSet.getString("name"))){
                    return true;
                }
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }

        return false;
    }

    public static int getMusicAuthorId(String name){
        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT * FROM music WHERE name = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, name);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                return resultSet.getInt("account_id");
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }

        return -1;
    }

    public static List<String> getAllMusicInfo(String name){
        connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        try{
            query = "SELECT * FROM music WHERE name = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, name);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                result.add(resultSet.getString("id"));
                result.add(resultSet.getString("name"));
                result.add(resultSet.getString("duration_in_minutes"));
                result.add(resultSet.getString("genre"));
                result.add(resultSet.getString("album_id"));
                result.add(resultSet.getString("account_id"));
                return result;
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return result;
    }

    public static List<String> getMusicByGenre(String genre){
        connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        try{
            query = "SELECT * FROM music WHERE genre = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, genre);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                result.add(resultSet.getString("name"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return result;
    }

    public static List<String> getMusicByAuthorID(int userId){
        connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        try{
            query = "SELECT * FROM music WHERE account_id = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setInt(1, userId);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                result.add(resultSet.getString("name"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return result;
    }

    public static int getAlbumAuthorId(String name){
        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT * FROM album WHERE name = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, name);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                return resultSet.getInt("user_id");
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }

        return -1;
    }

    public static int getAlbumId(String name){
        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT * FROM album WHERE name = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, name);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                return Integer.parseInt(resultSet.getString("id"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }

        return -1;
    }

    public static int getAlbumTotalSongs(int album_id){
        connection = DataBaseConnection.getConnection();
        int count = 0;

        try{
            query = "SELECT * FROM music WHERE album_id = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setInt(1, album_id);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                count++;
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }

        return count;
    }

    public static boolean isAlbumNameExisting(String name){
        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT * FROM album WHERE name = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, name);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                if(name.equals(resultSet.getString("name"))){
                    return true;
                }
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }

        return false;
    }

    public static List<String> getAlbumByAuthorId(int userId){
        connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        return getStrings(userId, result);
    }

    private static List<String> getStrings(int userId, List<String> result) {
        try{
            query = "SELECT * FROM album WHERE user_id = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setInt(1, userId);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                result.add(resultSet.getString("name"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return result;
    }

    public static List<String> getAllPlaylistInfo(String name, int userId){
        connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        try{
            query = "SELECT * FROM playlist WHERE name = ? and account_id=?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, name);
            preparedStatement.setInt(2, userId);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                result.add(resultSet.getString("id"));
                result.add(resultSet.getString("name"));
                result.add(resultSet.getString("account_id"));
                return result;
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return result;
    }

    public static List<String> getAllMusicInPlaylist(String name, int userId){
        connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();
        int playlistId = getPlaylistId(name, userId);

        try{
            query = "SELECT * FROM music " +
                    "INNER JOIN music_playlist ON music.id = music_playlist.music_id " +
                    "WHERE music_playlist.playlist_id = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setInt(1, playlistId);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                result.add(resultSet.getString("name"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return result;
    }

    public static float getTotalMusicPlayTime(List<String> musicList){
        connection = DataBaseConnection.getConnection();
        float totalTime = 0;

        for (String name:musicList) {
            try{
                query = "SELECT duration_in_minutes FROM music WHERE name = ?";
                preparedStatement = connection.prepareStatement(query);
                preparedStatement.setString(1, name);
                resultSet = preparedStatement.executeQuery();
                while (resultSet.next()){
                    totalTime += resultSet.getInt("duration_in_minutes");
                }
            } catch (SQLException exception){
                exception.printStackTrace();
            }
        }
        return totalTime;
    }

    public static int getPlaylistId(String name, int userId){
        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT * FROM playlist WHERE account_id = ? and name = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setInt(1, userId);
            preparedStatement.setString(2, name);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                return Integer.parseInt(resultSet.getString("id"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return -1;
    }

    public static boolean isPlaylistNameExisting(String name){
        connection = DataBaseConnection.getConnection();
        boolean result = false;

        try{
            query = "SELECT name FROM playlist";
            preparedStatement = connection.prepareStatement(query);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                result = name.equals(resultSet.getString("name"));
            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

        return result;
    }

    public static List<String> getAllUserPlaylist(int id){
        List<String> result = new ArrayList<>();

        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT * FROM playlist WHERE account_id=?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setInt(1, id);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                result.add(resultSet.getString("name"));
            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

        return result;
    }

    public static boolean isUserMusicAuthor(String musicName, int userId){
        connection = DataBaseConnection.getConnection();

        try{
            query = "SELECT * FROM music WHERE name = ?";
            preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, musicName);
            resultSet = preparedStatement.executeQuery();
            while (resultSet.next()){
                int authorId = resultSet.getInt("account_id");
                return userId == authorId;
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return false;
    }

}
