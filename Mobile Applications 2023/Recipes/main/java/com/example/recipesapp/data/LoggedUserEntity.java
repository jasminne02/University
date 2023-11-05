package com.example.recipesapp.data;

public class LoggedUserEntity {
    private static int id;
    private static String name;
    private static String email;

    public static void logUser(int Id, String Email, String Name){
        id = Id;
        name = Name;
        email = Email;
    }

    public static void logoutUser(){
        id = -1;
        name = "";
        email = "";
    }

    public static int getUserId(){
        return id;
    }

    public static String getUserName(){
        return name;
    }

    public static String getUserEmail(){
        return email;
    }

    public static void setUserEmail(String email){
        LoggedUserEntity.email = email;
    }
}
