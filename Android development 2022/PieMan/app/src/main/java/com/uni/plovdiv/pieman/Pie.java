package com.uni.plovdiv.pieman;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Rect;

import java.util.Random;

public class Pie {

    int x;
    int y;
    Context context;
    Bitmap image;
    Rect collisionDetection;
    boolean visible;
    Random random = new Random();
    int[] sprites = {R.drawable.pie1, R.drawable.pie2};

    Pie(Context context, int x, int y){
        this.context = context;
        this.x = x;
        this.y = y;
        visible = true;
        image = BitmapFactory.decodeResource
                (context.getResources(), sprites[random.nextInt(sprites.length)]);
        collisionDetection = new Rect(x, y, x + image.getWidth(), y + image.getHeight());
    }



}
