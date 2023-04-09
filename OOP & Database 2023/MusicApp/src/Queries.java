import java.sql.*;

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

    public static String getUserFullName(String username){
        Connection connection = DataBaseConnection.getConnection();

        try{
            String query = "SELECT username, firstName, lastName FROM account WHERE username = ?";
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setString(1, username);
            ResultSet resultSet = statement.executeQuery(query);
            String firstName = resultSet.getString("firstName");
            String lastName = resultSet.getString("lastName");
            return firstName + lastName;
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
            ResultSet resultSet = statement.executeQuery(query);
            return resultSet.getInt("age");
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
            ResultSet resultSet = statement.executeQuery(query);
            return resultSet.getBoolean("isMusician");
        } catch (SQLException exception){
            exception.printStackTrace();
        }
        return false;
    }

}
