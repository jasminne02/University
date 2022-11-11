package com.uni.plovdiv.pieman;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Rect;

public class Player {

    Context context;

    int x;
    int y;
    int sizeX;
    int sizeY;
    Bitmap bitmap;
    String direction = "up";
    int speed = 6;
    Rect collisionDetection;

    int frame = 0;

    int[] up = {R.drawable.pacman_up, R.drawable.pacman_up1,
            R.drawable.pacman_up2, R.drawable.pacman_up3,
            R.drawable.pacman_up2,R.drawable.pacman_up1};

    int[] down = {R.drawable.pacman_down, R.drawable.pacman_down1,
            R.drawable.pacman_down2, R.drawable.pacman_down3,
            R.drawable.pacman_down2,R.drawable.pacman_down1};

    int[] left = {R.drawable.pacman_left, R.drawable.pacman_left1,
            R.drawable.pacman_left2, R.drawable.pacman_left3,
            R.drawable.pacman_left2, R.drawable.pacman_left1};

    int[] right = {R.drawable.pacman_right, R.drawable.pacman_right1,
            R.drawable.pacman_right2, R.drawable.pacman_right3,
            R.drawable.pacman_right2, R.drawable.pacman_right1};

    public Player(Context context, int sizeX, int sizeY){
        this.context = context;
        this.sizeX = sizeX;
        this.sizeY = sizeY;

        bitmap = BitmapFactory.decodeResource
                (context.getResources(), R.drawable.pacman_up);

        x = sizeX / 2 - bitmap.getWidth() / 2;
        y = sizeY / 2 - bitmap.getHeight() / 2;

        collisionDetection = new Rect(x, y, x + bitmap.getWidth(), y + bitmap.getHeight());
    }

    public void update(){
        frame++;

        if(frame > 5)
        {
            frame = 0;
        }

        int imageId = 0;

        switch (direction){
            case "up":
                y -= speed;
                imageId = up[frame];
                break;
            case "down":
                y += speed;
                imageId = down[frame];
            break;
            case "left":
                x -= speed;
                imageId = left[frame];
                break;
            case "right":
                x += speed;
                imageId = right[frame];
                break;
        }

        if(imageId != 0)
            bitmap = BitmapFactory.decodeResource(context.getResources(), imageId);

        if(x < 0 - bitmap.getWidth()){
            x = sizeX;
        }else if(x > sizeX){
            x = 0 - bitmap.getWidth();
        }else if(y < 0 - bitmap.getHeight()){
            y = sizeY;
        }else if(y > sizeY){
            y = 0 - bitmap.getHeight();
        }

        collisionDetection.bottom = y + bitmap.getHeight();
        collisionDetection.top = y;
        collisionDetection.left = x;
        collisionDetection.right = x + bitmap.getWidth();
    }
}


