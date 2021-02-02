using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank
{
    public float health;
    public float fuel;
    public int coin;
    public int turn;
    
    
    public Tank(float health, float fuel, int coin, int turn)
    {
        this.health = health;
        this.fuel = fuel;
        this.coin = coin;
        this.turn = turn;
    }
}
public class GameModel
{
    public class Score
    {
        public int Player1Score;
        public int Player2Score;
    }

    public Tank tank1;
    public Tank tank2;
    public Action PlayerOneWin;
    public Action PlayerTwoWin;
    public Score score;
    private float initial_fuel;
    private string playerPrefsKey = "Score";

    public GameModel(float initial_health, float initial_fuel)
    {
        this.initial_fuel = initial_fuel;
        score = PlayerPrefs.HasKey(playerPrefsKey) ? JsonUtility.FromJson<Score>(PlayerPrefs.GetString(playerPrefsKey)) : new Score();
        tank1 = new Tank(initial_health, initial_fuel, score.Player1Score, 1);
        tank2 = new Tank(initial_health, initial_fuel, score.Player2Score, 0);
    }
    public void SetActions(Action PlayerOneWin, Action PlayerTwoWin)
    {
        this.PlayerOneWin = PlayerOneWin;
        this.PlayerTwoWin = PlayerTwoWin;
    }
    public void Turn()
    {
        tank1.turn = 1 - tank1.turn;
        tank2.turn = 1 - tank2.turn;
        tank1.fuel = initial_fuel;
        tank2.fuel = initial_fuel;
    }
    public void CheckStatus()
    {
        if (tank1.health <= 0)
        {
            PlayerTwoWin();
            score.Player1Score += 100;
            score.Player2Score += 200;
            PlayerPrefs.SetString(playerPrefsKey, JsonUtility.ToJson(score));
            PlayerPrefs.Save();
        }

        else if (tank2.health <= 0) 
        { 
            PlayerOneWin();
            score.Player1Score += 200;
            score.Player2Score += 100;
            PlayerPrefs.SetString(playerPrefsKey, JsonUtility.ToJson(score));
            PlayerPrefs.Save();
        }
    }
}
