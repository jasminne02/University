package com.example.recipesapp;

import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.ScrollView;
import android.widget.TextView;

import com.example.recipesapp.data.LoggedUserEntity;
import com.example.recipesapp.data.UserRepositoryManager;

import java.util.ArrayList;

public class FavoriteRecipesActivity extends AppCompatActivity {

    protected ImageButton btnNavProfile, btnNavSearch;
    protected ScrollView scrollViewFav;

    protected UserRepositoryManager db;

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_favorite_recipes);

        btnNavSearch = findViewById(R.id.btnNavSearch);
        btnNavProfile = findViewById(R.id.btnNavProfile);
        scrollViewFav = findViewById(R.id.scroll_fav);

        db = new UserRepositoryManager(getApplicationContext());
        loadFavRecipes();

        btnNavProfile.setOnClickListener(onClickGoToProfile);
        btnNavSearch.setOnClickListener(onClickGoToSearch);
    }

    private final View.OnClickListener onClickGoToProfile = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            db.close();
            Intent intent = new Intent(FavoriteRecipesActivity.this, ProfileActivity.class);
            view.getContext().startActivity(intent);
        }
    };

    private final View.OnClickListener onClickGoToSearch = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            db.close();
            Intent intent = new Intent(FavoriteRecipesActivity.this, SearchActivity.class);
            view.getContext().startActivity(intent);
        }
    };

    private void loadFavRecipes() {
        ArrayList<String> favRecipes = db.getUserFavList(LoggedUserEntity.getUserId());

        for (String recipeId : favRecipes) {
            int id = Integer.parseInt(recipeId);
            ArrayList<String> recipeData = db.getRecipe(id);

            CardView cardview = new CardView(getApplicationContext());

            ViewGroup.LayoutParams layoutparams = new ViewGroup.LayoutParams(
                    ViewGroup.LayoutParams.WRAP_CONTENT,
                    ViewGroup.LayoutParams.WRAP_CONTENT
            );

            cardview.setLayoutParams(layoutparams);
            cardview.setRadius(15);
            cardview.setPadding(25, 25, 25, 25);
            cardview.setCardBackgroundColor(Color.MAGENTA);
            cardview.setMaxCardElevation(30);
            cardview.setMaxCardElevation(6);

            scrollViewFav.addView(cardview);
        }

    }
}

