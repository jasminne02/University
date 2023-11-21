package com.example.doggygame.data;

import android.annotation.SuppressLint;
import android.content.Context;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

import androidx.annotation.Nullable;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.Arrays;

public class UserRepositoryManager extends DatabaseContext {

    public UserRepositoryManager(@Nullable Context context) {
        super(context);
    }

    public void insertUser(String Name, String Email, String Password, int BestScore) {
        String insertQ = "INSERT INTO user(" +
                "Name, Email, Password, BestScore" +
                ") VALUES(?, ?, ?, ?)";
        _myDB.execSQL(insertQ, new Object[]{
                Name, Email, Password, BestScore
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

    public void updateUserBestScore(int UserId, int Score) {
        String updateQ = "UPDATE user " +
                "SET BestScore = '" + Score + "' " +
                "WHERE ID = " + UserId + ";";
        _myDB.execSQL(updateQ);
    }

    public void updateUserAvatar(int Id, Bitmap image) {
        ByteArrayOutputStream stream = new ByteArrayOutputStream();
        image.compress(Bitmap.CompressFormat.PNG, 0, stream);

        String updateQ = "UPDATE user " +
                "SET Avatar = '" + Arrays.toString(stream.toByteArray()) + "' " +
                "WHERE ID = " + Id + ";";
        _myDB.execSQL(updateQ);
    }

    public void deleteUser(int id) {
        String deleteQ = "DELETE FROM user " +
                "WHERE ID = " + id + ";";
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

    public Bitmap getUserAvatar(int id){
        String readQ = "SELECT Avatar FROM user " +
                "WHERE ID = " + id + ";";

        @SuppressLint("Recycle") Cursor result = _myDB.rawQuery(readQ, null);
        ArrayList<String> resultArrayList = convertToArrayList(result, 1);
        if (resultArrayList.size() == 0 || resultArrayList.get(0) == null){return null;}

        String[] data = resultArrayList.get(0).split(", ");

        byte[] image = new byte[data.length];
        data[0] = data[0].replace("[", "");
        data[data.length-1] = data[data.length-1].replace("]", "");

        for (int i = 0; i < data.length; i++) {
            image[i] = (byte) Integer.parseInt(data[i]);
        }

        return BitmapFactory.decodeByteArray(image, 0, image.length);
    }

    public ArrayList<String> getAllUserEmails() {
        String readQ = "SELECT Email FROM user;";
        @SuppressLint("Recycle") Cursor result = _myDB.rawQuery(readQ, null);

        return convertToArrayList(result, 1);
    }

    public ArrayList<String> getAllUsersBestScore() {
        String readQ = "SELECT Name, BestScore FROM user ORDER BY BestScore DESC;";
        @SuppressLint("Recycle") Cursor result = _myDB.rawQuery(readQ, null);

        return convertToArrayList(result, 2);
    }

    public int getUserBestScore(int UserId){
        String readQ = "SELECT BestScore FROM user " +
                "WHERE ID = " + UserId + ";";

        @SuppressLint("Recycle") Cursor result = _myDB.rawQuery(readQ, null);

        ArrayList<String> resultArrayList = convertToArrayList(result, 1);
        if (resultArrayList.size() == 0){return 0;}

        return Integer.parseInt(resultArrayList.get(0));
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
