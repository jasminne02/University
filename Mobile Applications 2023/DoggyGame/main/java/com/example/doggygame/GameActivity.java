package com.example.doggygame;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Point;
import android.os.Bundle;

import com.example.doggygame.view.GameView;

public class GameActivity extends AppCompatActivity {

    private GameView gameView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Point point = new Point();
        getWindowManager().getDefaultDisplay().getSize(point);

        gameView = new GameView(this, point.x, point.y);

        setContentView(gameView);
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
    }


    @Override
    protected void onPause() {
        super.onPause();
        gameView.pause();
        Intent intent = new Intent(GameActivity.this, GameOverActivity.class);
        startActivity(intent);
    }

    @Override
    protected void onResume() {
        super.onResume();
        gameView.resume();
    }
}
