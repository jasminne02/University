public final class User {
    public static String username;
    public static String name;
    public static int age;

    public static boolean isMusician;
    public static boolean isAdmin;

    public static void setCurrentUser(String u){
        username = u;
        name = Queries.getUserFullName(username);
        age = Queries.getUserAge(username);
        isMusician = Queries.isMusician(username);
        isAdmin = username.equals("admin");
    }

    public static void removeCurrentUser(){
        username = null;
        name = null;
        age = 0;
        isAdmin = false;
        isMusician = false;
    }
}
