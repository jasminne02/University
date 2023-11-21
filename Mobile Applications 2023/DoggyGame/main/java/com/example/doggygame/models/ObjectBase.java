package com.example.doggygame.models;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Rect;

import java.util.Random;

public class ObjectBase {
    Context context;

    public int x, y;
    public int screenX, screenY;
    public Bitmap bitmap;
    public int speed;
    public int score;
    public Rect collisionDetection;
    public Random random;

    public ObjectBase(Context context, int sizeX, int sizeY){
        this.context = context;
        this.screenX = sizeX;
        this.screenY = sizeY;

        random = new Random();
        x = random.nextInt(screenX - 200);
        y = 70;
    }

    public Rect getCollisionDetection() {
        return collisionDetection;
    }
}
