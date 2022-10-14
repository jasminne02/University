package com.uni.myapplication102;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.app.Dialog;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Random;

public class MainActivity extends AppCompatActivity {

    TextView triesSoFarTV;
    TextView hiddenNumberTV;
    ImageView hintIV;
    TextView numbersTV;
    EditText numberET;
    Button guessB;
    Button restartB;

    Dialog dialog;

    Random random = new Random();
    int hiddenNumber;
    int triesSoFar;
    int maxTries = 5;

    @SuppressLint("SetTextI18n")
    private void endGame(boolean isWinner){
        hiddenNumberTV.setText(String.valueOf(hiddenNumber));
        guessB.setEnabled(false);

        TextView titleTV =
                dialog.findViewById(R.id.customDialogTitleTextView);

        TextView message = dialog.findViewById(R.id.customDialogMessageText);

        ImageView image = dialog.findViewById(R.id.customDialogImageView);

        if(isWinner){
            titleTV.setText("Winner!");
            image.setImageResource(R.drawable.winner_img);
            message.setText("Congratulations");
        } else {
            titleTV.setText("Loseeeer!!!");
            image.setImageResource(R.drawable.loser_img);
            message.setText("Try again!");
        }

        dialog.show();

    }

    @SuppressLint("SetTextI18n")
    private void restartGame(){
        hiddenNumber = random.nextInt(101);
        triesSoFar = 0;
        triesSoFarTV.setText("Tries 0 /" + maxTries);
        numbersTV.setText("");
        numberET.setText("");
        hiddenNumberTV.setText("?");
        hintIV.setImageResource(R.drawable.hello_img);

        guessB.setEnabled(true);

        Log.wtf("cheat", hiddenNumber+" ");
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        triesSoFarTV = findViewById(R.id.triesTextView);
        hiddenNumberTV = findViewById(R.id.hiddenNumberTextView);
        hintIV = findViewById(R.id.hintImageView);
        numbersTV = findViewById(R.id.numbersTextView);
        numberET = findViewById(R.id.editTextNumber);
        guessB = findViewById(R.id.guessButton);
        restartB = findViewById(R.id.restartButton);
        dialog = new Dialog(this);
        dialog.setContentView(R.layout.activity_dialog);

        guessB.setOnClickListener(onClickListener);
        restartB.setOnClickListener(onClickListener);

        restartGame();

    }

    View.OnClickListener onClickListener = new View.OnClickListener() {
        @SuppressLint("SetTextI18n")
        @Override
        public void onClick(View view) {

            if (view.getId() == R.id.restartButton) {
                restartGame();
                return;
            }

            int playerNumber;

            try{
                playerNumber = Integer.parseInt(numberET.getText().toString());
            } catch (NumberFormatException e){
                Toast.makeText(MainActivity.this, "Invalid input!", Toast.LENGTH_LONG).show();
                return;
            }

            triesSoFar++;

            numbersTV.append(playerNumber + " ");
            triesSoFarTV.setText(triesSoFar + " / " + maxTries);

            if (playerNumber == hiddenNumber){
                endGame(true);
                return;
            } else if (playerNumber > hiddenNumber){
                hintIV.setImageResource(R.drawable.down_arrow);
            } else {
                hintIV.setImageResource(R.drawable.up_arrow);
            }

            if (triesSoFar >= maxTries){
                endGame(false);
            }

        }
    };

}
