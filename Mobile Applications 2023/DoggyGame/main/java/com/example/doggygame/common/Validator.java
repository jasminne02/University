package com.example.doggygame.common;

import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Validator {

    private static final Pattern namePattern = Pattern.compile("^[A-Z][a-z]+(\\s[A-Z][a-z]+)?$");
    private static final Pattern emailPattern = Pattern.compile("^[\\w0-9\\.]+@[\\w]+\\.[\\w]{2,4}$");
    private static final Pattern passwordPattern =
            Pattern.compile("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}");

    public static boolean isNameValid(String name){
        Matcher matcher = namePattern.matcher(name);
        return matcher.find();
    }

    public static boolean isEmailValid(String email){
        Matcher matcher = emailPattern.matcher(email);
        return matcher.find();
    }

    public static boolean isPasswordValid(String password){
        Matcher matcher = passwordPattern.matcher(password);
        return matcher.find();
    }

    public static boolean validateEmailDoesNotExist(String email, ArrayList<String> allEmails){
        for (String userEmail:allEmails) {
            if (email.equals(userEmail)){
                return false;
            }
        }
        return true;
    }

}

