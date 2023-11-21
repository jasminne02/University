package com.example.doggygame.data;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class DatabaseContext extends SQLiteOpenHelper {

    public static final String DB_NAME = "gamedoggy.db";
    public static final int DB_VERSION = 1;

    protected final SQLiteDatabase _myDB;

    public static String DB_CREATE_USER = "" +
            "CREATE TABLE user( " +
            "ID integer PRIMARY KEY AUTOINCREMENT, " +
            "Name text not null, " +
            "Email text not null, " +
            "Password text not null, " +
            "BestScore int not null, " +
            "Avatar BLOB, " +
            "UNIQUE(Email) " +
            ");" +
            "";

    public DatabaseContext(@Nullable Context context) {
        super(context, DB_NAME, null, DB_VERSION);
        _myDB = this.getWritableDatabase();
    }


    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        sqLiteDatabase.execSQL(DB_CREATE_USER);
    }


    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {

        if(i1>i){
            sqLiteDatabase.execSQL("DROP TABLE user; ");
            sqLiteDatabase.execSQL(DB_CREATE_USER);
        }
    }
}
