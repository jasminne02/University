package com.example.recipesapp.data;

import com.example.recipesapp.services.RecipesService;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.Dictionary;
import java.util.Hashtable;

public class RecipeEntity {
    private final int id;
    private final String title;
    private final Dictionary<Integer, String> ingredients;
    private final String instructions;
    private final String image;

    public RecipeEntity(String searchParams) throws IOException, JSONException {
        JSONObject result = RecipesService.getRecipes(searchParams);
        this.id = Integer.parseInt(result.getString("id"));
        this.title = result.getString("Title");
        this.ingredients = loadIngredients(result.getJSONObject("Ingredients"));
        this.instructions = result.getString("Instructions");
        this.image = result.getString("Image");
    }

    private Dictionary<Integer, String> loadIngredients(JSONObject result) throws JSONException {
        Dictionary<Integer, String> resultDic = new Hashtable<>();
        for(int idx = 1; idx <= result.length(); idx++){
            resultDic.put(idx, result.getString(String.valueOf(idx)));
        }
        return resultDic;
    }

    public int getId(){
        return this.id;
    }

    public String getTitle(){
        return this.title;
    }

    public Dictionary<Integer, String> getIngredients(){
        return this.ingredients;
    }

    public String getInstructions(){
        return this.instructions;
    }

    public String getImage(){
        return this.image;
    }
}
