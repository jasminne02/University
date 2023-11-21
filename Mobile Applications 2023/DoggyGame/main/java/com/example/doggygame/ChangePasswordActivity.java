package com.example.doggygame;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.example.doggygame.common.Validator;
import com.example.doggygame.data.LoggedUserEntity;
import com.example.doggygame.data.UserRepositoryManager;

public class ChangePasswordActivity extends AppCompatActivity {

    protected Button btnChangePassword;
    protected EditText editPasswordOld, editPasswordNew1, editPasswordNew2;
    protected TextView tvStatus;

    protected UserRepositoryManager db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_change_password);

        btnChangePassword = findViewById(R.id.btnChangePassword);
        tvStatus = findViewById(R.id.tvStatus);
        editPasswordOld = findViewById(R.id.editPasswordOld);
        editPasswordNew1 = findViewById(R.id.editPasswordNew1);
        editPasswordNew2 = findViewById(R.id.editPasswordNew2);

        db = new UserRepositoryManager(getApplicationContext());

        btnChangePassword.setOnClickListener(onClickChangePassword);
    }

    private final View.OnClickListener onClickChangePassword = new View.OnClickListener() {
        @SuppressLint("SetTextI18n")
        @Override
        public void onClick(View view) {
            String oldPassword = editPasswordOld.getText().toString();
            String newPassword1 = editPasswordNew1.getText().toString();
            String newPassword2 = editPasswordNew2.getText().toString();

            if (!oldPassword.equals(db.getUserPassword(LoggedUserEntity.getUserId()))){
                tvStatus.setText("The old password is not correct!");
            } else if (!newPassword1.equals(newPassword2)){
                tvStatus.setText("The new password is not the same in the two fields!");
            }else if (!Validator.isPasswordValid(newPassword1)){
                tvStatus.setText("The new password should contain at least 8 characters,\\n \" +\n" +
                        "\"one number and one capital letter!");
            } else{
                db.updateUserPassword(LoggedUserEntity.getUserId(), newPassword1);
                db.close();
                Intent intent = new Intent(ChangePasswordActivity.this, ProfileActivity.class);
                view.getContext().startActivity(intent);
            }
        }
    };
}