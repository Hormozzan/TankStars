using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank
{
    public float health;
    public float fuel;
    public int turn;
    public Tank(float health, float fuel, int turn)
    {
        this.health = health;
        this.fuel = fuel;
        this.turn = turn;
    }
}
public class GameModel
{
    public Tank tank1;
    public Tank tank2;
    float initial_fuel;
    public Action PlayerOneWin;
    public Action PlayerTwoWin;

    public GameModel(float initial_health, float initial_fuel)
    {
        this.initial_fuel = initial_fuel;
        tank1 = new Tank(initial_health, initial_fuel, 1);
        tank2 = new Tank(initial_health, initial_fuel, 0);    
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
        if (tank1.health <= 0) PlayerTwoWin();
        else if (tank2.health <= 0) PlayerOneWin();
    }
}
