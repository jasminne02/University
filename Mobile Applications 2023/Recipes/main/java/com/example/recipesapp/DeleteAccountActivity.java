package com.example.recipesapp;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.example.recipesapp.data.UserRepositoryManager;
import com.example.recipesapp.data.LoggedUserEntity;

public class DeleteAccountActivity extends AppCompatActivity {

    protected Button btnDeleteAccount;

    protected TextView tvStatus;
    protected EditText editPassword;
    protected UserRepositoryManager db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_delete_account);

        btnDeleteAccount = findViewById(R.id.btnDeleteAccount);
        tvStatus = findViewById(R.id.tvStatus);
        editPassword = findViewById(R.id.editPassword);

        db = new UserRepositoryManager(getApplicationContext());

        btnDeleteAccount.setOnClickListener(onClickDeleteAccount);
    }

    private final View.OnClickListener onClickDeleteAccount = new View.OnClickListener() {
        @SuppressLint("SetTextI18n")
        @Override
        public void onClick(View view) {
            if(!editPassword.getText().toString().equals(db.getUserPassword(LoggedUserEntity.getUserId()))){
                tvStatus.setText("The password is not correct!");
            } else {
                db.deleteUser(LoggedUserEntity.getUserId());
                LoggedUserEntity.logoutUser();
                db.close();
                Intent intent = new Intent(DeleteAccountActivity.this, MainActivity.class);
                view.getContext().startActivity(intent);
            }
        }
    };
}
