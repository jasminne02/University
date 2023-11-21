package com.example.doggygame;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.example.doggygame.data.LoggedUserEntity;
import com.example.doggygame.data.UserRepositoryManager;
import com.example.doggygame.common.Validator;


public class RegisterActivity extends AppCompatActivity {

    protected EditText editName, editEmail, editPassword1, editPassword2;
    protected Button btnRegister;
    protected TextView tvStatus;

    protected UserRepositoryManager db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        editName = findViewById(R.id.editName);
        editEmail = findViewById(R.id.editEmail);
        editPassword1 = findViewById(R.id.editPassword1);
        editPassword2 = findViewById(R.id.editPassword2);
        btnRegister = findViewById(R.id.btnRegister);
        tvStatus = findViewById(R.id.tvStatus);

        db = new UserRepositoryManager(getApplicationContext());

        btnRegister.setOnClickListener(onClickRegister);

    }


    private final View.OnClickListener onClickRegister = new View.OnClickListener() {
        @SuppressLint("SetTextI18n")
        @Override
        public void onClick(View view) {
            String name = editName.getText().toString();
            String email = editEmail.getText().toString().toLowerCase();
            String password1 = editPassword1.getText().toString();
            String password2 = editPassword2.getText().toString();

            if (email.equals("") || name.equals("") || password1.equals("") || password2.equals("")){
                tvStatus.setText("All fields are required!");
            } else if (!Validator.isNameValid(name)) {
                tvStatus.setText("The name is not valid!");
            } else if (!Validator.isEmailValid(email)){
                tvStatus.setText("The Email is not in a valid format!");
            } else if (!password1.equals(password2)){
                tvStatus.setText("The passwords are not the same!");
            } else if (!Validator.isPasswordValid(password1)){
                tvStatus.setText("The password should contain at least 8 characters,\n " +
                        "one number and one capital letter!");
            } else if (!Validator.validateEmailDoesNotExist(email, db.getAllUserEmails())){
                tvStatus.setText("A user with the given email already exists!");
            } else {
                db.insertUser(name, email, password1, 0);
                String userId = db.getUserId(email);
                LoggedUserEntity.logUser(Integer.parseInt(userId), email, name,
                        0, RegisterActivity.this);

                db.close();
                 db = null;
                Intent intent = new Intent(RegisterActivity.this, MenuActivity.class);
                view.getContext().startActivity(intent);
            }
        }
    };
}
