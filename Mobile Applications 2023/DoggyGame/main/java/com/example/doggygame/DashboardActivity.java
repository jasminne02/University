package com.example.doggygame;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import com.example.doggygame.data.UserRepositoryManager;

import java.util.ArrayList;

public class DashboardActivity extends AppCompatActivity {

    protected TableLayout dashboardTableLayout;
    protected UserRepositoryManager db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dashboard);

        db = new UserRepositoryManager(getApplicationContext());

        dashboardTableLayout = findViewById(R.id.dashboardTableLayout);
        loadDashboardData();
    }

    private void loadDashboardData(){
        ArrayList<String> result = db.getAllUsersBestScore();

        int stopLoop = 10;

        if (stopLoop > result.size() / 2){
            stopLoop = result.size() / 2;
        }

        for(int idx = 0; idx < stopLoop * 2; idx+=2){
            TableRow row = new TableRow(this);

            TextView userScore = new TextView(this);
            userScore.setText(String.valueOf(result.get(idx+1)));

            TextView userName = new TextView(this);
            userName.setText(result.get(idx));

            row.addView(userScore);
            row.addView(userName);
            dashboardTableLayout.addView(row);
        }
    }
}
