package com.example.doggygame.models;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Rect;

import com.example.doggygame.R;


public class GiftBone extends ObjectBase{

    public GiftBone(Context context, int sizeX, int sizeY){
        super(context, sizeX, sizeY);

        score = 25;
        speed = 25;

        Bitmap image = BitmapFactory.decodeResource(context.getResources(), R.drawable.gift_bone);
        bitmap = Bitmap.createScaledBitmap(image, screenX/7, screenY/13, true);

        collisionDetection = new Rect(x, y, x + bitmap.getWidth(), y + bitmap.getHeight());
    }
}
