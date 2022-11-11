package com.uni.plovdiv.pieman;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.util.Log;
import android.view.MotionEvent;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.VelocityTracker;

import java.util.ArrayList;

public class GameView extends SurfaceView implements Runnable{

    boolean isRunning = true;
    int screenSizeX;
    int screenSizeY;

    Player player;

    SurfaceHolder surfaceHolder;
    Canvas canvas;
    Paint paint;
    Thread gameThread;

    ArrayList<Block> blocks = new ArrayList<>();
    ArrayList<Pie> pies = new ArrayList<>();

    int score = 0;

    public GameView(Context context, int screenSizeX, int screenSizeY) {
        super(context);
        this.screenSizeX = screenSizeX;
        this.screenSizeY = screenSizeY;

        player = new Player(context, screenSizeX, screenSizeY);

        int blockSizeX = player.bitmap.getWidth();
        int blockSizeY = player.bitmap.getHeight();
        int blocksX = screenSizeX / blockSizeX;
        int blocksY = (screenSizeY / blockSizeY) / 3 * 2;

        for(int i = 0; i < blocksX; i++){
            for(int j = 0; j < blocksY; j++){
                if(i == 0 || j == 0 || i == blocksX - 1 || j == blocksY - 1)
                {
                    Block b = new Block(context,blockSizeX * i , blockSizeY * j);
                    blocks.add(b);
                }else{
                    pies.add(new Pie(context, blockSizeX * i + 5 , blockSizeY * j + 5));
                }
            }
        }

        surfaceHolder = getHolder();
        paint = new Paint();

        gameThread = new Thread(this);
        gameThread.start();
    }

    @Override
    public void run() {
        while (isRunning){
            update();//опреснява състояните на играта
            draw();//прерисува играта
            refreshRate();//определя frame-rate
        }
    }

    private void refreshRate() {

        try {
            gameThread.sleep(42);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    private void draw() {
        if(surfaceHolder.getSurface().isValid()){
            canvas = surfaceHolder.lockCanvas();

            paint.setColor(Color.YELLOW);
            canvas.drawColor(Color.BLACK);

            for(Block b : blocks){
                canvas.drawBitmap(b.image, b.x, b.y, paint);
            }

            for(Pie p : pies){
                if(p.visible){
                    canvas.drawBitmap(p.image, p.x, p.y, paint);
                }
            }

            canvas.drawBitmap(player.bitmap, player.x, player.y, paint);

            String scoreText = "Score: " + score;

            paint.setTextSize(40);
            canvas.drawText(scoreText, 50, ((screenSizeY/3) * 2) + 100, paint);

            surfaceHolder.unlockCanvasAndPost(canvas);
        }
    }
    private void update() {
        player.update();

        for(Block b : blocks){
            if(b.collisionDetection.intersect(player.collisionDetection)){

                switch (player.direction){
                    case "up":
                        player.y = b.y + b.image.getHeight() + 1;
                        break;

                    case "down":
                        player.y = b.y - player.bitmap.getHeight() - 1;
                        break;

                    case "left":
                        player.x = b.x + b.image.getWidth() + 1;
                        break;

                    case "right":
                        player.x = b.x - player.bitmap.getWidth() - 1;
                        break;
                }

                player.direction = "stop";
                break;
            }
        }

        for(int i = 0; i < pies.size(); i++){
            if(pies.get(i).collisionDetection.intersect(player.collisionDetection)){
                pies.remove(i);
                score++;
                break;
            }
        }
    }

    VelocityTracker velocityTracker;

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
                    }else {
                        player.direction = "left";
                    }
                }else{
                    if(yVelocity < 0){
                        player.direction = "up";
                    }else{
                        player.direction = "down";
                    }
                }

                Log.wtf("moved", velocityTracker.getXVelocity() + "");
                break;

        }


        return true;
    }
}
