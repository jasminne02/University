package com.example.doggygame;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import com.example.doggygame.common.Validator;
import com.example.doggygame.data.LoggedUserEntity;

public class MenuActivity extends AppCompatActivity {

    protected Button btnStartGame, btnDashboard, btnProfile;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);

        btnDashboard = findViewById(R.id.btnDashboard);
        btnProfile = findViewById(R.id.btnProfile);
        btnStartGame = findViewById(R.id.btnStartGame);

        btnStartGame.setOnClickListener(onClickStartGame);
        btnDashboard.setOnClickListener(onClickGoToDashboard);
        btnProfile.setOnClickListener(onClickGoToProfile);
    }

    private final View.OnClickListener onClickStartGame= view -> {
            Intent intent = new Intent(MenuActivity.this, GameActivity.class);
            view.getContext().startActivity(intent);
    };

    private final View.OnClickListener onClickGoToProfile = view -> {
            Intent intent = new Intent(MenuActivity.this, ProfileActivity.class);
            view.getContext().startActivity(intent);
    };

    private final View.OnClickListener onClickGoToDashboard = view -> {
            Intent intent = new Intent(MenuActivity.this, DashboardActivity.class);
            view.getContext().startActivity(intent);
    };
}
