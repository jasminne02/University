import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DataBaseConnection {

    static Connection connection = null;

    static Connection getConnection() {

        try {
            Class.forName("org.postgresql.Driver");
            connection = DriverManager.getConnection(
                    "jdbc:postgresql://localhost:5432/postgres",
                    "postgres", "root");
            System.out.println("Connection to SQLite has been established.");
        } catch (ClassNotFoundException | SQLException e) {
            e.printStackTrace();
        }

        return connection;
    }
}
