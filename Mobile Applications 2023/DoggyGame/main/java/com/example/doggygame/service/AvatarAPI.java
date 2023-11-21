package com.example.doggygame.service;


import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.StrictMode;

import com.example.doggygame.R;

import java.io.IOException;
import java.net.URL;

public class AvatarAPI {
    private String urlString = "https://robohash.org/";
    private final Context context;

    public AvatarAPI(Context context){
        this.context = context;
    }

    public Bitmap getAvatar(String search, int setNumber) {
        urlString = urlString + search + "?set=set" + Integer.toString(setNumber);

        int SDK_INT = android.os.Build.VERSION.SDK_INT;
        if (SDK_INT > 8)
        {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder()
                    .permitAll().build();
            StrictMode.setThreadPolicy(policy);

            try{
                URL url = new URL(urlString);
                return BitmapFactory.decodeStream(url.openConnection().getInputStream());
            } catch (IOException e){
                e.printStackTrace();
            }
        }

        return BitmapFactory.decodeResource(context.getResources(), R.drawable.person);
    }
}
