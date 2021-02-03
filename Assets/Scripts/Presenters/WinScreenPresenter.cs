using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinScreenPresenter : MonoBehaviour
{
    public Text Player1CoinText;
    public Text Player2CoinText;
    public GameConfig GameConfigObj;
    private GameModel GameModelObj;


    private void Awake()
    {
        GameModelObj = new GameModel(GameConfigObj.InitialHealth, GameConfigObj.InitialFuel);

        Player1CoinText.text = GameModelObj.tank1.coin.ToString();
        Player2CoinText.text = GameModelObj.tank2.coin.ToString();
    }
}
