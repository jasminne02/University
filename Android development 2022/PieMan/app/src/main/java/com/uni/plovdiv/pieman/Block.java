package com.uni.plovdiv.pieman;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Rect;

public class Block {

    Bitmap image;
    Context context;

    int x;
    int y;
    Rect collisionDetection;

    Block(Context context, int x, int y){
        this.context = context;

        image = BitmapFactory.decodeResource
                (context.getResources(), R.drawable.block);
        this.x = x;
        this.y = y;

        collisionDetection =
                new Rect(x, y, x + image.getWidth(), y + image.getHeight());

    }


}
