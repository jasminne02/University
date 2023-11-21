package com.example.doggygame.view;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.view.MotionEvent;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.VelocityTracker;
import android.view.ViewGroup;

import com.example.doggygame.R;
import com.example.doggygame.models.Bee;
import com.example.doggygame.models.Biscuit;
import com.example.doggygame.models.GiftBone;
import com.example.doggygame.models.ObjectBase;
import com.example.doggygame.models.Player;
import com.example.doggygame.models.Score;

import java.util.ArrayList;


@SuppressLint("ViewConstructor")
public class GameView extends SurfaceView implements Runnable {

    Context context;
    private Thread thread;
    private boolean isPlaying;

    SurfaceHolder surfaceHolder;
    Canvas canvas;
    Paint paint;
    Bitmap background;

    Player player;
    int score;
    int missedGiftBones;

    int screenSizeX;
    int screenSizeY;

    VelocityTracker velocityTracker;

    int biscuitSleepCounter, biscuitSleepNumber;
    int giftBoneSleepCounter, giftBoneSleepNumber;
    int beeSleepCounter, beeSleepNumber;
    ArrayList<ObjectBase> biscuitArray;
    ArrayList<ObjectBase> giftBoneArray;
    ArrayList<ObjectBase> beeArray;

    public GameView(Context context, int screenSizeX, int screenSizeY) {
        super(context);
        this.context = context;
        this.screenSizeX = screenSizeX;
        this.screenSizeY = screenSizeY;

        Bitmap backgroundImage = BitmapFactory.decodeResource(getResources(), R.drawable.background);
        background = Bitmap.createScaledBitmap(backgroundImage, screenSizeX, screenSizeY, true);
        player = new Player(context, screenSizeX, screenSizeY);

        surfaceHolder = getHolder();
        paint = new Paint();

        biscuitSleepNumber = 70;
        giftBoneSleepNumber = 250;
        beeSleepNumber = 300;

        giftBoneArray = new ArrayList<>();
        beeArray = new ArrayList<>();
        biscuitArray = new ArrayList<>();
        Biscuit biscuit = new Biscuit(context, screenSizeX, screenSizeY);
        biscuitArray.add(biscuit);

        thread = new Thread(this);
        thread.start();
    }

    @Override
    public void run() {
        while (isPlaying){
            draw();
            update();
            refreshRate();
        }
    }

    private void refreshRate() {
        try {
            Thread.sleep(42);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    private void update(){
        player.update();
        biscuitSleepCounter += 1;
        giftBoneSleepCounter += 1;
        beeSleepCounter += 1;

        if (missedGiftBones == 1){
            endGame();
        }

        if (score > 1000){
            beeSleepNumber = 50;
        } else if (score > 500){
            giftBoneSleepNumber = 100;
            beeSleepNumber = 100;
        } else if (score > 200){
            giftBoneSleepNumber = 150;
            beeSleepNumber = 200;
        }

        for(int i = 0; i < biscuitArray.size(); i++){
            if(biscuitArray.get(i).collisionDetection.intersect(player.collisionDetection)){
                score += biscuitArray.get(i).score;
                biscuitArray.remove(i);
                break;
            }
        }

        for(int i = 0; i < giftBoneArray.size(); i++){
            if(giftBoneArray.get(i).collisionDetection.intersect(player.collisionDetection)){
                score += giftBoneArray.get(i).score;
                giftBoneArray.remove(i);
                break;
            } else if (giftBoneArray.get(i).y + giftBoneArray.get(i).bitmap.getHeight() >= screenSizeY) {
                missedGiftBones += 1;
                giftBoneArray.remove(giftBoneArray.get(i));
            }
        }

        for(int i = 0; i < beeArray.size(); i++){
            if(beeArray.get(i).collisionDetection.intersect(player.collisionDetection)) {
                endGame();
            } else if (beeArray.get(i).y >= screenSizeY){
                beeArray.remove(beeArray.get(i));
            }
        }
    }

    private void draw() {
        if (getHolder().getSurface().isValid()){

            canvas = getHolder().lockCanvas();

            canvas.drawBitmap(background, 0, 0, null);
            canvas.drawBitmap(player.bitmap, player.x, player.y, paint);

            String scoreText = "Score: " + score;
            String bestScoreText = "Missed gifts: " + missedGiftBones + "/5";
            paint.setColor(Color.WHITE);
            paint.setTextSize(55);
            canvas.drawText(bestScoreText, 50, 60, paint);
            canvas.drawText(scoreText, 700, 60, paint);

            createBiscuit();
            createGiftBiscuit();
            createBee();

            drawObject(canvas, biscuitArray);
            drawObject(canvas, giftBoneArray);
            drawObject(canvas, beeArray);

            surfaceHolder.unlockCanvasAndPost(canvas);
        }
    }

    @SuppressLint("ClickableViewAccessibility")
    @Override
    public boolean onTouchEvent(MotionEvent event) {
        int action = event.getActionIndex();
        int pointer = event.getPointerId(action);

        switch (event.getActionMasked()){

            case MotionEvent.ACTION_DOWN:
                if(velocityTracker == null){
                    velocityTracker = VelocityTracker.obtain();
                }else{
                    velocityTracker.clear();
                }

                velocityTracker.addMovement(event);

                break;

            case MotionEvent.ACTION_MOVE:

                velocityTracker.addMovement(event);
                velocityTracker.computeCurrentVelocity(1000);

                float xVelocity = velocityTracker.getXVelocity();
                float yVelocity = velocityTracker.getYVelocity();

                if(Math.abs(xVelocity) > Math.abs(yVelocity)){
                    if(xVelocity > 0){
                        player.direction = "right";
                        player.x += player.speed;
                        if (player.x >= background.getWidth() - player.speed){
                            player.x = - player.speed * 2;
                        }
                    }else {
                        player.direction = "left";
                        player.x -= player.speed;
                        if (player.x <= - player.bitmap.getWidth() / 2){
                            player.x = background.getWidth() - player.speed * 2;
                        }
                    }
                }

                break;
        }

        return true;
    }

    public void resume() {
        isPlaying = true;
        thread = new Thread(this);
        thread.start();
    }

    public void pause() {
        try {
            thread.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    private void drawObject(Canvas canvas, ArrayList<ObjectBase> arrayList){
        for (ObjectBase object: arrayList) {
            canvas.drawBitmap(object.bitmap, object.x, object.y, paint);
            object.y += object.speed;
            object.collisionDetection.bottom = object.y + object.bitmap.getHeight() - 50;
            object.collisionDetection.left = object.x + 50;
            object.collisionDetection.right = object.x + object.bitmap.getWidth() - 50;
        }
    }

    private void createBiscuit() {
        if (biscuitSleepCounter == biscuitSleepNumber){
            Biscuit biscuit = new Biscuit(context, screenSizeX, screenSizeY);
            biscuitArray.add(biscuit);
            canvas.drawBitmap(biscuit.bitmap, biscuit.x, biscuit.y, paint);

            biscuitSleepCounter = 0;
        }
    }

    private void createGiftBiscuit() {
        if (giftBoneSleepCounter == giftBoneSleepNumber){
            GiftBone giftBone = new GiftBone(context, screenSizeX, screenSizeY);
            giftBoneArray.add(giftBone);
            canvas.drawBitmap(giftBone.bitmap, giftBone.x, giftBone.y, paint);

            giftBoneSleepCounter = 0;
        }
    }

    private void createBee() {
        if (beeSleepCounter == beeSleepNumber){
            Bee bee = new Bee(context, screenSizeX, screenSizeY);
            beeArray.add(bee);
            canvas.drawBitmap(bee.bitmap, bee.x, bee.y, paint);

            beeSleepCounter = 0;
        }
    }

    private void endGame(){
        Score.setCurrentScore(score);
        isPlaying = false;
        ((Activity) context).finish();
    }
}

