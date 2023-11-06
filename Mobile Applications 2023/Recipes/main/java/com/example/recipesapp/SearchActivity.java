package com.example.recipesapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.SearchView;
import android.widget.TextView;


public class SearchActivity extends AppCompatActivity {

    protected ImageButton btnNavProfile, btnNavFav;
    protected SearchView searchView;

    protected TextView tvSpaghetti, tvBrownies, tvEggs, tvZucchini, tvCaesarSalad;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_search);

        searchView = findViewById(R.id.searchView);
        btnNavFav = findViewById(R.id.btnNavFavorite);
        btnNavProfile = findViewById(R.id.btnNavProfile);
        tvSpaghetti = findViewById(R.id.tvSpaghetti);
        tvBrownies = findViewById(R.id.tvBrownies);
        tvEggs = findViewById(R.id.tvEggs);
        tvZucchini = findViewById(R.id.tvZucchini);
        tvCaesarSalad = findViewById(R.id.tvCaesarSalad);

        btnNavProfile.setOnClickListener(onClickGoToProfile);
        btnNavFav.setOnClickListener(onClickGoToFav);

        searchView.setOnQueryTextListener(onQueryTextListener);

        tvBrownies.setOnClickListener(onClickBrownies);
        tvEggs.setOnClickListener(onClickEggs);
        tvZucchini.setOnClickListener(onClickZucchini);
        tvCaesarSalad.setOnClickListener(onClickCaesarSalad);
        tvSpaghetti.setOnClickListener(onClickSpaghetti);
    }

    private final SearchView.OnQueryTextListener onQueryTextListener = new SearchView.OnQueryTextListener() {
        @Override
        public boolean onQueryTextSubmit(String query) {
            Intent intent = new Intent(SearchActivity.this, RecipesResultsActivity.class);
            intent.putExtra("query", query);
            startActivity(intent);
            return false;
        }

        @Override
        public boolean onQueryTextChange(String newText) {
            return false;
        }
    };

    private final View.OnClickListener onClickGoToProfile = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Intent intent = new Intent(SearchActivity.this, ProfileActivity.class);
            view.getContext().startActivity(intent);
        }
    };

    private final View.OnClickListener onClickGoToFav = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Intent intent = new Intent(SearchActivity.this, FavoriteRecipesActivity.class);
            view.getContext().startActivity(intent);
        }
    };

    private final View.OnClickListener onClickSpaghetti = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Intent intent = new Intent(SearchActivity.this, RecipesResultsActivity.class);
            intent.putExtra("query", "spaghetti");
            startActivity(intent);
        }
    };

    private final View.OnClickListener onClickBrownies = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Intent intent = new Intent(SearchActivity.this, RecipesResultsActivity.class);
            intent.putExtra("query", "brownies");
            startActivity(intent);
        }
    };

    private final View.OnClickListener onClickCaesarSalad = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Intent intent = new Intent(SearchActivity.this, RecipesResultsActivity.class);
            intent.putExtra("query", "caesar salad");
            startActivity(intent);
        }
    };

    private final View.OnClickListener onClickZucchini = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Intent intent = new Intent(SearchActivity.this, RecipesResultsActivity.class);
            intent.putExtra("query", "zucchini");
            startActivity(intent);
        }
    };

    private final View.OnClickListener onClickEggs = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Intent intent = new Intent(SearchActivity.this, RecipesResultsActivity.class);
            intent.putExtra("query", "eggs");
            startActivity(intent);
        }
    };
}
