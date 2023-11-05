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

public class SignInActivity extends AppCompatActivity {

    protected EditText editEmail, editPassword;
    protected Button btnSignin;
    protected TextView tvStatus;

    protected UserRepositoryManager db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_in);

        editEmail = findViewById(R.id.editEmail);
        editPassword = findViewById(R.id.editPassword);
        btnSignin = findViewById(R.id.btnSignin);
        tvStatus = findViewById(R.id.tvStatus);

        db = new UserRepositoryManager(getApplicationContext());

        btnSignin.setOnClickListener(onClickSignin);
    }

    private final View.OnClickListener onClickSignin = new View.OnClickListener() {
        @SuppressLint("SetTextI18n")
        @Override
        public void onClick(View view) {
            String email = editEmail.getText().toString();
            String password = editPassword.getText().toString();

            String userId = db.getUserId(email);

            if(Validator.validateEmailDoesNotExist(email, db.getAllUserEmails())){
                tvStatus.setText("User with the given email does not exist!");
            } else if (userId.equals("")){
                tvStatus.setText("User with the given email does not exist!");
            } else if (!password.equals(db.getUserPassword(Integer.parseInt(userId)))) {
                tvStatus.setText("Incorrect password!");
            } else {
                String userName = db.getUserName(Integer.parseInt(userId));
                LoggedUserEntity.logUser(Integer.parseInt(userId), email, userName);

                db.close();
                Intent intent = new Intent(SignInActivity.this, FavoriteRecipesActivity.class);
                view.getContext().startActivity(intent);
            }
        }
    };
}
