package com.example.doggygame.models;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Rect;

import com.example.doggygame.R;

public class Bee extends ObjectBase {

    public Bee(Context context, int sizeX, int sizeY){
        super(context, sizeX, sizeY);

        speed = 30;
        score = 0;

        Bitmap image = BitmapFactory.decodeResource(context.getResources(), R.drawable.bee);
        bitmap = Bitmap.createScaledBitmap(image, screenX/7, screenY/15, true);

        collisionDetection = new Rect(x, y, x + bitmap.getWidth(), y + bitmap.getHeight());
    }
}
