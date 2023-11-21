package com.example.doggygame;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.example.doggygame.data.LoggedUserEntity;
import com.example.doggygame.data.UserRepositoryManager;
import com.example.doggygame.models.Score;

import org.w3c.dom.Text;

public class GameOverActivity extends AppCompatActivity {

    protected Button startAgainButton, btnGoToMenu;
    protected TextView scoreTextView;
    protected TextView bestScoreTextView;

    protected UserRepositoryManager db;


    @SuppressLint("SetTextI18n")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_game_over);

        db = new UserRepositoryManager(getApplicationContext());

        scoreTextView = findViewById(R.id.scoreTV);
        scoreTextView.setText("Score: " + Score.getCurrentScore());

        bestScoreTextView = findViewById(R.id.bestScoreTV);
        bestScoreTextView.setText("Best score: " + Score.getBestScore());

        if(LoggedUserEntity.getBestScore() < Score.getBestScore()) {
            db.updateUserBestScore(LoggedUserEntity.getUserId(), Score.getBestScore());
            LoggedUserEntity.setBestScore(Score.getBestScore());
        }

        startAgainButton = findViewById(R.id.startAgainButton);
        startAgainButton.setOnClickListener(onClickRestartGame);

        btnGoToMenu = findViewById(R.id.btnGoToMenu);
        btnGoToMenu.setOnClickListener(onClickGoToMenu);
    }

    private final View.OnClickListener onClickRestartGame = view -> {
        Intent intent = new Intent(GameOverActivity.this, GameActivity.class);
        startActivity(intent);
    };

    private final View.OnClickListener onClickGoToMenu = view -> {
        Intent intent = new Intent(GameOverActivity.this, MenuActivity.class);
        startActivity(intent);
    };
}
