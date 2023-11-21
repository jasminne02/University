package com.example.doggygame.models;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Rect;

import com.example.doggygame.R;

import java.util.Random;

public class Biscuit extends ObjectBase {

    public Biscuit(Context context, int sizeX, int sizeY){
        super(context, sizeX, sizeY);

        score = 5;
        speed = 20;

        Bitmap image = BitmapFactory.decodeResource(context.getResources(), R.drawable.biscuit);
        bitmap = Bitmap.createScaledBitmap(image, screenX/7, screenY/13, true);

        collisionDetection = new Rect(x, y, x + bitmap.getWidth(), y + bitmap.getHeight());
    }
}

