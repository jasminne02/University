package com.example.recipesapp.data;

import android.annotation.SuppressLint;
import android.content.Context;
import android.database.Cursor;

import androidx.annotation.Nullable;

import java.util.ArrayList;

public class UserRepositoryManager extends DatabaseContext {

    public UserRepositoryManager(@Nullable Context context) {
        super(context);
    }

    public void insertUser(String Name, String Email, String Password) {
        String insertQ = "INSERT INTO user(" +
                "Name, Email, Password" +
                ") VALUES(?, ?, ?)";
        _myDB.execSQL(insertQ, new Object[]{
                Name, Email, Password
        });
    }

    public void insertRecipe(int Id, String Title, String Ingredients, String Instructions, String Image) {
        String insertQ = "INSERT INTO recipe(" +
                "ID, Title, Ingredients, Instructions, Image" +
                ") VALUES(?, ?, ?, ?, ?)";
        _myDB.execSQL(insertQ, new Object[]{
                Id, Title, Ingredients, Instructions, Image
        });
    }

    public void insertRecipeIntoFavList(int RecipeId, int UserId) {
        String insertQ = "INSERT INTO user(" +
                "RecipeID, UserID" +
                ") VALUES(?, ?)";
        _myDB.execSQL(insertQ, new Object[]{
                RecipeId, UserId
        });
    }


    public void updateUserEmail(int Id, String Email) {
        String updateQ = "UPDATE user " +
                "SET Email = '" + Email + "' " +
                "WHERE ID = " + Id + ";";
        _myDB.execSQL(updateQ);
    }


    public void updateUserPassword(int Id, String Password) {
        String updateQ = "UPDATE user " +
                "SET Password = '" + Password + "' " +
                "WHERE ID = " + Id + ";";
        _myDB.execSQL(updateQ);
    }

    public void deleteUser(int id) {
        String deleteQ = "DELETE FROM user " +
                "WHERE ID = " + id + ";";
        _myDB.execSQL(deleteQ);
    }


    public void deleteRecipeFromFavList(int userId, int recipeId) {
        String deleteQ = "DELETE FROM fav_list " +
                "WHERE UserID = " + userId + " AND RecipeID = " + recipeId + ";";
        _myDB.execSQL(deleteQ);
    }


    public String getUserPassword(int id) {
        String readQ = "SELECT Password FROM user WHERE ID = " + id + ";";
        @SuppressLint("Recycle") Cursor result = _myDB.rawQuery(readQ, null);

        ArrayList<String> resultArrayList = convertToArrayList(result, 1);
        if (resultArrayList.size() == 0){return "";}

        return resultArrayList.get(0);
    }

    public String getUserId(String email){
        String readQ = "SELECT ID FROM user " +
                "WHERE Email = '" + email + "';";

        @SuppressLint("Recycle") Cursor result = _myDB.rawQuery(readQ, null);

        ArrayList<String> resultArrayList = convertToArrayList(result, 1);
        if (resultArrayList.size() == 0){return "";}

        return resultArrayList.get(0);
    }

    public String getUserName(int id){
        String readQ = "SELECT Name FROM user " +
                "WHERE ID = " + id + ";";

        @SuppressLint("Recycle") Cursor result = _myDB.rawQuery(readQ, null);

        ArrayList<String> resultArrayList = convertToArrayList(result, 1);
        if (resultArrayList.size() == 0){return "";}

        return resultArrayList.get(0);
    }

    public ArrayList<String> getAllUserEmails() {
        String readQ = "SELECT Email FROM user;";
        @SuppressLint("Recycle") Cursor result = _myDB.rawQuery(readQ, null);

        return convertToArrayList(result, 1);
    }

    public ArrayList<String> getUserFavList(int userId) {
        String readQ = "SELECT * FROM fav_list WHERE UserID = " + userId + ";";
        @SuppressLint("Recycle") Cursor result = _myDB.rawQuery(readQ, null);
        return convertToArrayList(result, 2);
    }

    public ArrayList<String> getRecipe(int id) {
        String readQ = "SELECT * FROM recipe WHERE ID = " + id + ";";
        @SuppressLint("Recycle") Cursor result = _myDB.rawQuery(readQ, null);

        return convertToArrayList(result, 1);
    }

    private ArrayList<String> convertToArrayList(Cursor result, int columnCount){
        ArrayList<String> resultArrayList = new ArrayList<>();
        while (result.moveToNext()) {
            for (int index = 0; index < columnCount; index++){
                resultArrayList.add(result.getString(index));
            }
        }

        return resultArrayList;
    }

}
