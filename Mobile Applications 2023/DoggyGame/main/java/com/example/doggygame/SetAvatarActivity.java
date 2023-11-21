package com.example.doggygame;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.RadioGroup;

import com.example.doggygame.data.LoggedUserEntity;
import com.example.doggygame.data.UserRepositoryManager;
import com.example.doggygame.service.AvatarAPI;

public class SetAvatarActivity extends AppCompatActivity {

    protected Button btnSaveAvatar, btnSearch;
    protected ImageView imageViewAvatar;
    protected EditText editTextSearch;
    protected RadioButton radioBtnSet1, radioBtnSet2, radioBtnSet3, radioBtnSet4;

    protected UserRepositoryManager db;
    private Bitmap searchedAvatar;
    private AvatarAPI avatarAPI;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_set_avatar);

        imageViewAvatar = findViewById(R.id.imageViewAvatar);
        editTextSearch = findViewById(R.id.editTextSearch);
        radioBtnSet1 = findViewById(R.id.radioBtnSet1);
        radioBtnSet2 = findViewById(R.id.radioBtnSet2);
        radioBtnSet3 = findViewById(R.id.radioBtnSet3);
        radioBtnSet4 = findViewById(R.id.radioBtnSet4);
        btnSearch = findViewById(R.id.btnSearch);
        btnSaveAvatar = findViewById(R.id.btnSaveAvatar);

        db = new UserRepositoryManager(getApplicationContext());
        avatarAPI = new AvatarAPI(this);

        btnSaveAvatar.setOnClickListener(onClickSaveAvatar);
        btnSearch.setOnClickListener(onClickSearchAvatar);

    }

    private final View.OnClickListener onClickSaveAvatar = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            LoggedUserEntity.setUserAvatar(searchedAvatar);
            db.updateUserAvatar(LoggedUserEntity.getUserId(), searchedAvatar);
            db.close();
            Intent intent = new Intent(SetAvatarActivity.this, ProfileActivity.class);
            view.getContext().startActivity(intent);
        }
    };

    private final View.OnClickListener onClickSearchAvatar = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            String searchedText = String.valueOf(editTextSearch.getText());
            int setNumber;

            if (radioBtnSet1.isChecked()){
                setNumber = 1;
            } else if (radioBtnSet2.isChecked()) {
                setNumber = 2;
            } else if (radioBtnSet3.isChecked()) {
                setNumber = 3;
            } else {
                setNumber = 4;
            }

            searchedAvatar = avatarAPI.getAvatar(searchedText, setNumber);
            imageViewAvatar.setImageBitmap(searchedAvatar);
        }
    };
}