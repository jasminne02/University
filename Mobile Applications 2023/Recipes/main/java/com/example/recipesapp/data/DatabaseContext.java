package com.example.recipesapp.data;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class DatabaseContext extends SQLiteOpenHelper {

    public static final String DB_NAME = "recipes.db";
    public static final int DB_VERSION = 1;

    protected final SQLiteDatabase _myDB;

    public static String DB_CREATE_USER = "" +
            "CREATE TABLE user( " +
            "ID integer PRIMARY KEY AUTOINCREMENT, " +
            "Name text not null, " +
            "Email text not null, " +
            "Password text not null, " +
            "UNIQUE(Email) " +
            ");" +
            "";

    public static String DB_CREATE_FAV_LIST = "" +
            "CREATE TABLE fav_list( " +
            "RecipeID integer," +
            "UserID integer," +
            "PRIMARY KEY (RecipeID, UserID)," +
            "FOREIGN KEY(UserID) REFERENCES user(ID)" +
            ");" +
            "";

    public static String DB_CREATE_RECIPE = "" +
            "CREATE TABLE recipe( " +
            "ID integer PRIMARY KEY, " +
            "Title text not null, " +
            "Ingredients text not null, " +
            "Instructions text not null, " +
            "Image text not null" +
            ");" +
            "";


    public DatabaseContext(@Nullable Context context) {
        super(context, DB_NAME, null, DB_VERSION);
        _myDB = this.getWritableDatabase();
    }


    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        sqLiteDatabase.execSQL(DB_CREATE_USER);
        sqLiteDatabase.execSQL(DB_CREATE_FAV_LIST);
        sqLiteDatabase.execSQL(DB_CREATE_RECIPE);
    }


    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {

        if(i1>i){
            sqLiteDatabase.execSQL("DROP TABLE user; ");
            sqLiteDatabase.execSQL("DROP TABLE fav_list; ");
            sqLiteDatabase.execSQL(DB_CREATE_USER);
            sqLiteDatabase.execSQL(DB_CREATE_FAV_LIST);
            sqLiteDatabase.execSQL(DB_CREATE_RECIPE);
        }
    }
}
