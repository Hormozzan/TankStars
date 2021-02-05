﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePresenter : MonoBehaviour
{
    public GameConfig GameConfigObj;
    public TanksConfig TanksConfigObj;
    public TankPresenter TankPresenterObj;
    public GameObject LeftTankSpawn;
    public GameObject RightTankSpawn;
    public Text RightFuelText;
    public Text LeftFuelText;
    public Text LeftHealthText;
    public Text RightHealthText;
    public Text LeftCoinText;
    public Text RightCoinText;
    public List<Sprite> Backgrounds;
    public GameObject Background;
    private GameModel GameModelObj;
    private TankPresenter tank1;
    private TankPresenter tank2;

    
    public void Awake()
    {
        GameObject[] MusicObjs = GameObject.FindGameObjectsWithTag("Music");
        if (MusicObjs.Length == 1)
        {
            MusicObjs[0].GetComponent<AudioSource>().Pause();
        }
        GameModelObj = new GameModel(GameConfigObj.InitialHealth, GameConfigObj.InitialFuel);
        GameModelObj.SetActions(PlayerOneWin, PlayerTwoWin);

        Background.GetComponent<Image>().sprite = Backgrounds[UnityEngine.Random.Range(0, 3)];

        tank1 = Instantiate(TankPresenterObj, LeftTankSpawn.transform);
        tank1.SetUp(TanksConfigObj.TanksSprites[PlayerPrefs.GetInt("SelectedTankP1")], LeftFuelText, LeftHealthText, LeftCoinText, GameConfigObj.Speed, "left", 0.1f, 20);
        tank1.SetCoinText(GameModelObj.tank1.coin);
        tank1.SetFuelText(GameModelObj.tank1.fuel);
        tank1.SetHealthText(GameModelObj.tank1.health);
        tank1.SetActions(FuelConsumption, OnCollisionBullet);
        
        tank2 = Instantiate(TankPresenterObj, RightTankSpawn.transform);
        tank2.SetUp(TanksConfigObj.TanksSprites[PlayerPrefs.GetInt("SelectedTankP2")], RightFuelText, RightHealthText, RightCoinText, GameConfigObj.Speed, "right", -0.1f, 160);
        tank2.SetCoinText(GameModelObj.tank2.coin);
        tank2.SetFuelText(GameModelObj.tank2.fuel);
        tank2.SetHealthText(GameModelObj.tank2.health);
        tank2.SetActions(FuelConsumption, OnCollisionBullet);
    }
    
    
    void FuelConsumption()
    {
        if (GameModelObj.tank1.turn == 1)
            GameModelObj.tank1.fuel -= GameConfigObj.Speed / 10;
        else if (GameModelObj.tank2.turn == 1)
            GameModelObj.tank2.fuel -= GameConfigObj.Speed / 10;   
    }
    
    
    public void PlayerOneWin()
    {
        GetComponent<SceneSwitcher>().Switch(GameConfigObj.VictorySceneID1);
    }
    
    
    public void PlayerTwoWin()
    {
        GetComponent<SceneSwitcher>().Switch(GameConfigObj.VictorySceneID2);
    }
    
    
    void OnCollisionBullet(float damage)
    {
        if (GameModelObj.tank1.turn == 1)
        {
            GameModelObj.tank1.health -= damage;
            tank1.SetHealthText(GameModelObj.tank1.health);
        }

        else if (GameModelObj.tank2.turn == 1)
        {
            GameModelObj.tank2.health -= damage;
            tank2.SetHealthText(GameModelObj.tank2.health);
        }
    }
    
    
    void PresenterTurn()
    {
        tank1.turn = 1 - tank1.turn;
        tank2.turn = 1 - tank2.turn;
    }
    
    
    void Update()
    {
        if (GameModelObj.tank1.turn == 1)
        {
            tank1.SetFuelText(GameModelObj.tank1.fuel);
            if (GameModelObj.tank1.fuel > 0) tank1.moving();
            tank1.Targeting();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                tank1.Shoot();
                PresenterTurn();
                GameModelObj.Turn();
                tank1.DeactivePoints();
                tank2.ActivePoints();
                tank1.MovementAudio.Pause();
            }
            if (GameModelObj.tank1.fuel <= 0) tank1.MovementAudio.Pause();
        }
        else if (GameModelObj.tank2.turn == 1)
        {
            tank2.SetFuelText(GameModelObj.tank2.fuel);
            if (GameModelObj.tank2.fuel > 0) tank2.moving();
            tank2.Targeting();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                tank2.Shoot();
                PresenterTurn();
                GameModelObj.Turn();
                tank2.DeactivePoints();
                tank1.ActivePoints();
                tank2.MovementAudio.Pause();
            }
            if (GameModelObj.tank2.fuel <= 0) tank2.MovementAudio.Pause();

        }
        GameModelObj.CheckStatus();
    }
}
