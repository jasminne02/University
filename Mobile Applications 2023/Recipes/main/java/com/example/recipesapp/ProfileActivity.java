package com.example.recipesapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;

import com.example.recipesapp.data.UserRepositoryManager;
import com.example.recipesapp.data.LoggedUserEntity;

public class ProfileActivity extends AppCompatActivity {

    protected Button btnLogout, btnChangePassword, btnChangeEmail, btnDeleteAccount;
    protected ImageButton btnNavFavorite, btnNavSearch;
    protected TextView tvSavedRecipes, tvEmail, tvName;

    protected UserRepositoryManager db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);

        tvSavedRecipes = findViewById(R.id.tvSavedRecipes);
        tvEmail = findViewById(R.id.tvEmail);
        tvName = findViewById(R.id.tvName);
        btnChangeEmail = findViewById(R.id.btnChangeEmail);
        btnChangePassword = findViewById(R.id.btnChangePassword);
        btnLogout = findViewById(R.id.btnLogout);
        btnDeleteAccount = findViewById(R.id.btnDeleteAccount);
        btnNavSearch = findViewById(R.id.btnNavSearch);
        btnNavFavorite = findViewById(R.id.btnNavFavorite);

        db = new UserRepositoryManager(getApplicationContext());

        tvName.setText(LoggedUserEntity.getUserName());
        tvEmail.setText(LoggedUserEntity.getUserEmail());
        tvSavedRecipes.setText(String.valueOf(db.getUserFavList(LoggedUserEntity.getUserId()).size()));

        btnLogout.setOnClickListener(onClickLogout);
        btnChangeEmail.setOnClickListener(onClickChangeEmail);
        btnChangePassword.setOnClickListener(onClickChangePassword);
        btnDeleteAccount.setOnClickListener(onClickDeleteAccount);

        btnNavFavorite.setOnClickListener(onClickGoToFav);
        btnNavSearch.setOnClickListener(onClickGoToSearch);
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

    private final View.OnClickListener onClickGoToFav = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            db.close();
            Intent intent = new Intent(ProfileActivity.this, FavoriteRecipesActivity.class);
            view.getContext().startActivity(intent);
        }
    };

    private final View.OnClickListener onClickGoToSearch = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            db.close();
            Intent intent = new Intent(ProfileActivity.this, SearchActivity.class);
            view.getContext().startActivity(intent);
        }
    };
}
