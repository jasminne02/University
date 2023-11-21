package com.example.doggygame.models;

public class Score {

    private static int bestScore;
    private static int currentScore;

    public static void setCurrentScore(int score){
        if (score > bestScore){
            bestScore = score;
        }
        currentScore = score;
    }

    public static int getBestScore(){
        return bestScore;
    }

    public static int getCurrentScore(){
        return currentScore;
    }

}
