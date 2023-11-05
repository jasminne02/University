package com.example.recipesapp.services;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;
import java.util.Scanner;

public class RecipesService {
    private static final String url = "https://food-recipes-with-images.p.rapidapi.com/";
    private static final String api_key = "X-RapidAPI-Key";
    private static final String api_key_value = "f39104a00fmsh6c3951d094ee116p18250cjsn8c60fb7352a5";

    public static JSONObject getRecipes(String queryParams) throws IOException {
        URLConnection connection = new URL(url + "?q=" + queryParams.replace(' ', '+'))
                .openConnection();
        connection.setRequestProperty(api_key, api_key_value);
        InputStream response = connection.getInputStream();

        try (Scanner scanner = new Scanner(response)) {
            String responseBody = scanner.useDelimiter("\\A").next();
            return new JSONObject(responseBody);
        } catch (JSONException e) {
            throw new RuntimeException(e);
        }
    }
}
