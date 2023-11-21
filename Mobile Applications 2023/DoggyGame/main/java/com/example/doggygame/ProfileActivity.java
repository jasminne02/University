package com.example.doggygame;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.doggygame.data.LoggedUserEntity;
import com.example.doggygame.data.UserRepositoryManager;

public class ProfileActivity extends AppCompatActivity {

    protected Button btnLogout, btnChangePassword, btnChangeEmail, btnDeleteAccount, btnSetAvatar;
    protected TextView tvBestScore, tvEmail, tvName;
    protected ImageView imageViewAvatar;

    protected UserRepositoryManager db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);

        tvBestScore = findViewById(R.id.tvBestScore);
        tvEmail = findViewById(R.id.tvEmail);
        tvName = findViewById(R.id.tvName);
        btnChangeEmail = findViewById(R.id.btnChangeEmail);
        btnChangePassword = findViewById(R.id.btnChangePassword);
        btnLogout = findViewById(R.id.btnLogout);
        btnDeleteAccount = findViewById(R.id.btnDeleteAccount);
        btnSetAvatar = findViewById(R.id.btnSetAvatar);
        imageViewAvatar = findViewById(R.id.imageViewAvatar);

        db = new UserRepositoryManager(getApplicationContext());

        tvBestScore.setText(String.valueOf(db.getUserBestScore(LoggedUserEntity.getUserId())));
        tvName.setText(LoggedUserEntity.getUserName());
        tvEmail.setText(LoggedUserEntity.getUserEmail());

        Bitmap imageAvatar = LoggedUserEntity.getUserAvatar();
        if (imageAvatar != null){
            imageViewAvatar.setImageBitmap(imageAvatar);
        }

        btnLogout.setOnClickListener(onClickLogout);
        btnChangeEmail.setOnClickListener(onClickChangeEmail);
        btnChangePassword.setOnClickListener(onClickChangePassword);
        btnDeleteAccount.setOnClickListener(onClickDeleteAccount);
        btnSetAvatar.setOnClickListener(onClickSetAvatar);
    }

    private final View.OnClickListener onClickLogout = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            LoggedUserEntity.logoutUser();
            db.close();
            Intent intent = new Intent(ProfileActivity.this, MainActivity.class);
            view.getContext().startActivity(intent);
        }
    };

    private final View.OnClickListener onClickDeleteAccount = view -> {
        Intent intent = new Intent(ProfileActivity.this, DeleteAccountActivity.class);
        view.getContext().startActivity(intent);
    };

    private final View.OnClickListener onClickChangeEmail = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            db.close();
            Intent intent = new Intent(ProfileActivity.this, ChangeEmailActivity.class);
            view.getContext().startActivity(intent);
        }
    };

    private final View.OnClickListener onClickChangePassword = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            db.close();
            Intent intent = new Intent(ProfileActivity.this, ChangePasswordActivity.class);
            view.getContext().startActivity(intent);
        }
    };

    private final View.OnClickListener onClickSetAvatar= new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            db.close();
            Intent intent = new Intent(ProfileActivity.this, SetAvatarActivity.class);
            view.getContext().startActivity(intent);
        }
    };

}