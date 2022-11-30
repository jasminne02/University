# Generated by Django 2.1.15 on 2022-11-26 12:29

import django.core.validators
from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('calorie_counter', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='Exercise',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=100)),
                ('metabolic_equivalent', models.FloatField(validators=[django.core.validators.MinValueValidator(0)])),
                ('daily_data_pk', models.ManyToManyField(blank=True, to='calorie_counter.DailyData')),
            ],
            options={
                'ordering': ('name',),
            },
        ),
        migrations.CreateModel(
            name='Food',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=100)),
                ('calories_per_100g', models.FloatField(validators=[django.core.validators.MinValueValidator(0)])),
                ('fats_per_100g', models.FloatField(validators=[django.core.validators.MinValueValidator(0)])),
                ('protein_per_100g', models.FloatField(validators=[django.core.validators.MinValueValidator(0)])),
                ('carbs_per_100g', models.FloatField(validators=[django.core.validators.MinValueValidator(0)])),
                ('daily_data_pk', models.ManyToManyField(blank=True, to='calorie_counter.DailyData')),
            ],
            options={
                'ordering': ('name',),
            },
        ),
        migrations.CreateModel(
            name='FoodPlan',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=150)),
                ('details', models.TextField(blank=True, null=True)),
                ('image_url', models.URLField()),
                ('daily_data_pk', models.ManyToManyField(blank=True, to='calorie_counter.DailyData')),
                ('food', models.ManyToManyField(blank=True, to='core.Food')),
            ],
            options={
                'ordering': ('pk',),
            },
        ),
        migrations.CreateModel(
            name='Meal',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=100)),
                ('calories', models.FloatField(validators=[django.core.validators.MinValueValidator(1)])),
                ('grams', models.PositiveIntegerField()),
                ('fats_grams', models.FloatField(validators=[django.core.validators.MinValueValidator(1)])),
                ('protein_grams', models.FloatField(validators=[django.core.validators.MinValueValidator(1)])),
                ('carbs_grams', models.FloatField(validators=[django.core.validators.MinValueValidator(1)])),
                ('daily_data_pk', models.ManyToManyField(blank=True, to='calorie_counter.DailyData')),
            ],
            options={
                'ordering': ('name',),
            },
        ),
        migrations.CreateModel(
            name='Motivation',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('quote', models.CharField(max_length=450)),
                ('description', models.TextField()),
            ],
            options={
                'ordering': ('pk',),
            },
        ),
        migrations.AddField(
            model_name='foodplan',
            name='meals',
            field=models.ManyToManyField(to='core.Meal'),
        ),
    ]