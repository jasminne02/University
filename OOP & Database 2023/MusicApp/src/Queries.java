import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class Queries {

    public static boolean isUserExisting(String username) {

        Connection connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT username FROM account";
            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery(query);
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

        Connection connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT username, password FROM account";
            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery(query);
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
        Connection connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        try{
            String query = "SELECT * FROM account WHERE username = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setString(1, username);
            ResultSet resultSet = statement.executeQuery();
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
        Connection connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT username, firstName, lastName FROM account WHERE username = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setString(1, username);
            ResultSet resultSet = statement.executeQuery();
            while (resultSet.next()){
                String firstName = resultSet.getString("firstName");
                String lastName = resultSet.getString("lastName");
                return firstName + lastName;
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return "";
    }

    public static int getUserAge(String username){
        Connection connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT username, age FROM account WHERE username = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setString(1, username);
            ResultSet resultSet = statement.executeQuery();
            while (resultSet.next()){
                return resultSet.getInt("age");
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return 0;
    }

    public static boolean isMusician(String username) {
        Connection connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT username, isMusician FROM account WHERE username = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setString(1, username);
            ResultSet resultSet = statement.executeQuery();
            while (resultSet.next()){
                return resultSet.getBoolean("isMusician");
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return false;
    }

    public static List<String> getUserInfoByFirstName(String firstName){
        Connection connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        try{
            String query = "SELECT * FROM account WHERE firstname = ?";
            firstLastNameQueryExtracted(firstName, connection, result, query);
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return result;
    }

    public static List<String> getUserInfoByLastName(String lastName){
        Connection connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        try{
            String query = "SELECT * FROM account WHERE lastname = ?";
            firstLastNameQueryExtracted(lastName, connection, result, query);
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return result;
    }

    private static void firstLastNameQueryExtracted(String lastName, Connection connection, List<String> result, String query) throws SQLException {
        PreparedStatement statement = connection.prepareStatement(query);
        statement.setString(1, lastName);
        ResultSet resultSet = statement.executeQuery();
        while (resultSet.next()){
            result.add(resultSet.getString("username"));
            result.add(resultSet.getString("firstName"));
            result.add(resultSet.getString("lastName"));
        }
    }

    public static int getUserId(String username){
        Connection connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT * FROM account WHERE username = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setString(1, username);
            ResultSet resultSet = statement.executeQuery();
            while (resultSet.next()){
                return Integer.parseInt(resultSet.getString("id"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return 0;
    }

    public static int getMusicId(String name, int userId){
        Connection connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT * FROM music WHERE user_id = ? and name = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setInt(1, userId);
            statement.setString(2, name);
            ResultSet resultSet = statement.executeQuery();
            while (resultSet.next()){
                return Integer.parseInt(resultSet.getString("id"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return 0;
    }

    public static List<String> getAllMusicAlbumNames(String username){
        Connection connection = DataBaseConnection.getConnection();
        int userId = getUserId(username);
        List<String> names = new ArrayList<>();

        try{
            String query = "SELECT * FROM albums WHERE user_id = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setInt(1, userId);
            ResultSet resultSet = statement.executeQuery();
            while (resultSet.next()){
                names.add(resultSet.getString("name"));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }

        return names;
    }

    public static List<Integer> getAllMusicAlbumIds(String username){
        Connection connection = DataBaseConnection.getConnection();
        int userId = getUserId(username);
        List<Integer> ids = new ArrayList<>();

        try{
            String query = "SELECT * FROM albums WHERE user_id = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setInt(1, userId);
            ResultSet resultSet = statement.executeQuery();
            while (resultSet.next()){
                ids.add(Integer.parseInt(resultSet.getString("id")));
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }

        return ids;
    }

    public static boolean isMusicNameExisting(String name, Integer userId){
        Connection connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT * FROM music WHERE user_id = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            int userID = userId;
            statement.setInt(1, userID);
            ResultSet resultSet = statement.executeQuery();
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

    public static String getMusicAuthorUsername(String name){
        Connection connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT * FROM music WHERE name = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setString(1, name);
            ResultSet resultSet = statement.executeQuery();
            while (resultSet.next()){
                return resultSet.getString("name");
            }
        } catch (SQLException exception){
            exception.printStackTrace();
        }

        return "";
    }

    public static List<String> getAllMusicInfo(String name, ){
        Connection connection = DataBaseConnection.getConnection();
        List<String> result = new ArrayList<>();

        try{
            String query = "SELECT * FROM account WHERE username = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setString(1, username);
            ResultSet resultSet = statement.executeQuery();
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

}
