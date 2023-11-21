package com.example.doggygame.data;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

import com.example.doggygame.R;


public class LoggedUserEntity {
    private static int id;
    private static String name;
    private static String email;
    private static int bestScore;
    private static Bitmap avatar;

    public static void logUser(int Id, String Email, String Name, int BestScore, Context context){
        id = Id;
        name = Name;
        email = Email;
        bestScore = BestScore;
        avatar = BitmapFactory.decodeResource(context.getResources(), R.drawable.person);
    }

    public static void logoutUser(){
        id = -1;
        name = "";
        email = "";
        bestScore = 0;
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

    public static int getBestScore() { return bestScore; }

    public static Bitmap getUserAvatar(){return avatar;}

    public static void setUserEmail(String email){
        LoggedUserEntity.email = email;
    }

    public static void setUserAvatar(Bitmap image) { LoggedUserEntity.avatar = image; }
    public static void setBestScore(int bestScore) { LoggedUserEntity.bestScore = bestScore; }
}
