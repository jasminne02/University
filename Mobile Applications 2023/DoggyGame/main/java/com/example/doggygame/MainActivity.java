package com.example.doggygame;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {

    protected Button btnRegister, btnSignIn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnRegister = findViewById(R.id.btnRegister);
        btnSignIn = findViewById(R.id.btnSignIn);

        btnRegister.setOnClickListener(onClickRegister);
        btnSignIn.setOnClickListener(onClickSignIn);

    }

    private final View.OnClickListener onClickRegister = view -> {
        Intent intent = new Intent(MainActivity.this, RegisterActivity.class);
        view.getContext().startActivity(intent);
    };


    private final View.OnClickListener onClickSignIn = view -> {
        Intent intent = new Intent(MainActivity.this, SignInActivity.class);
        view.getContext().startActivity(intent);
    };
}
