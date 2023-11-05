package com.example.recipesapp;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.example.recipesapp.common.Validator;
import com.example.recipesapp.data.UserRepositoryManager;
import com.example.recipesapp.data.LoggedUserEntity;

public class ChangeEmailActivity extends AppCompatActivity {

    protected Button btnChangeEmail;
    protected EditText editEmail, editPassword;
    protected TextView tvStatus;

    protected UserRepositoryManager db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_change_email);

        editEmail = findViewById(R.id.editEmail);
        editPassword = findViewById(R.id.editPassword);
        btnChangeEmail = findViewById(R.id.btnChangeEmail);
        tvStatus = findViewById(R.id.tvStatus);

        db = new UserRepositoryManager(getApplicationContext());

        btnChangeEmail.setOnClickListener(onClickChangeEmail);
    }

    private final View.OnClickListener onClickChangeEmail = new View.OnClickListener() {
        @SuppressLint("SetTextI18n")
        @Override
        public void onClick(View view) {
            String email = editEmail.getText().toString().toLowerCase();

            if (!editPassword.getText().toString().equals(db.getUserPassword(LoggedUserEntity.getUserId()))){
                tvStatus.setText("The password is not correct!");
            } else if (!Validator.isEmailValid(email)){
                tvStatus.setText("The email format is not valid!");
            } else{
                LoggedUserEntity.setUserEmail(email);
                db.updateUserEmail(LoggedUserEntity.getUserId(), email);
                db.close();
                Intent intent = new Intent(ChangeEmailActivity.this, ProfileActivity.class);
                view.getContext().startActivity(intent);
            }
        }
    };
}
