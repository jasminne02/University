package com.uni.fmi;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    TextView resultTV;
    EditText firstNumberET;
    EditText secondNumberET;
    Button plusButton;
    Button minusButton;
    Button multiplyButton;
    Button divideButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        resultTV = findViewById(R.id.result_textview);
        firstNumberET = findViewById(R.id.firstn_num_edittext);
        secondNumberET = findViewById(R.id.secondnum_edittext);
        plusButton = findViewById(R.id.plus_button);
        minusButton = findViewById(R.id.minus_button);
        multiplyButton = findViewById(R.id.multiply_button);
        divideButton = findViewById(R.id.div_button);

        plusButton.setOnClickListener(onClick);
        minusButton.setOnClickListener(onClick);
        multiplyButton.setOnClickListener(onClick);
        divideButton.setOnClickListener(onClick);

    }

    View.OnClickListener onClick = new View.OnClickListener() {
        @SuppressLint({"NonConstantResourceId", "SetTextI18n"})
        @Override
        public void onClick(View view) {
            String firstNumberText = firstNumberET.getText().toString();
            String secondNumberText = secondNumberET.getText().toString();

            if (firstNumberText.length() == 0 || secondNumberText.length() == 0){
                Toast.makeText(MainActivity.this, "Please enter BOTH numbers!", Toast.LENGTH_LONG).show();
                return;
            }

            double firstNumber = Double.parseDouble(firstNumberText);
            double secondNumber = Double.parseDouble(secondNumberText);

            double result = Double.NaN;

            switch (view.getId()){
                case R.id.plus_button:
                    result = firstNumber + secondNumber;
                    break;

                case R.id.minus_button:
                    result = firstNumber - secondNumber;
                    break;

                case R.id.multiply_button:
                    result = firstNumber * secondNumber;
                    break;

                case R.id.div_button:
                    if (secondNumber == 0){
                        Toast.makeText(MainActivity.this, "Cannot divide by 0!", Toast.LENGTH_LONG).show();
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;

            }

            resultTV.setText("Result: " + result);
        }
    };

}
