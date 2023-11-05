package com.example.recipesapp;

import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.graphics.Color;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.TextView;

import com.example.recipesapp.data.UserRepositoryManager;
import com.example.recipesapp.services.RecipesService;

import org.json.JSONException;
import org.json.JSONObject;
import org.w3c.dom.Text;

import java.io.IOException;
import java.net.URI;
import java.util.Objects;

public class RecipesResultsActivity extends AppCompatActivity {

    protected UserRepositoryManager db;
    protected ScrollView scrollViewSearch;

    protected ImageButton btnNavProfile, btnNavFav, btnNavSearch;
    protected String queryValue;
    protected LinearLayout linearLayoutScroll;


    @SuppressLint("SetTextI18n")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_recipes_results);

        queryValue = Objects.requireNonNull(getIntent().getExtras()).getString("query");

        btnNavFav = findViewById(R.id.btnNavFavorite);
        btnNavProfile = findViewById(R.id.btnNavProfile);
        btnNavSearch = findViewById(R.id.btnNavSearch);
        scrollViewSearch = findViewById(R.id.scroll_search);
        linearLayoutScroll = findViewById(R.id.linear_layout_scroll_search);

        db = new UserRepositoryManager(getApplicationContext());

        try {
            loadSearchData();
        } catch (IOException | JSONException e) {
            showNoResult();
        }

        btnNavProfile.setOnClickListener(onClickGoToProfile);
        btnNavFav.setOnClickListener(onClickGoToFav);
        btnNavSearch.setOnClickListener(onClickGoToSearch);
    }

    @SuppressLint("SetTextI18n")
    private void showNoResult(){
        TextView tvResult = new TextView(this);
        tvResult.setText("@string/no_search_results");
        linearLayoutScroll.addView(tvResult);
    }

    private void loadSearchData() throws IOException, JSONException {
        JSONObject result = RecipesService.getRecipes(queryValue);

        if (result.getString("s").equals("0")){
            showNoResult();
        } else {
            result = result.getJSONObject("d");
            while(result.keys().hasNext()){
                String title = result.getString("Title");
                Uri image = Uri.parse(result.getString("Image"));

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

                TextView titleView = new TextView(this);
                titleView.setText(title);
                ImageView imageView = new ImageView(this);
                imageView.setImageURI(image);

                cardview.addView(titleView);
                cardview.addView(imageView);

                linearLayoutScroll.addView(cardview);
            }

        }
    }

    private final View.OnClickListener onClickGoToProfile = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            db.close();
            Intent intent = new Intent(RecipesResultsActivity.this, ProfileActivity.class);
            view.getContext().startActivity(intent);
        }
    };

    private final View.OnClickListener onClickGoToFav = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            db.close();
            Intent intent = new Intent(RecipesResultsActivity.this, FavoriteRecipesActivity.class);
            view.getContext().startActivity(intent);
        }
    };

    private final View.OnClickListener onClickGoToSearch = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            db.close();
            Intent intent = new Intent(RecipesResultsActivity.this, SearchActivity.class);
            view.getContext().startActivity(intent);
        }
    };
}
