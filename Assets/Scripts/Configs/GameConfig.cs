using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TankStarsConfig")]
public class GameConfig : ScriptableObject
{
    public float Speed;
    public float InitialHealth;
    public float InitialFuel;
    public int VictorySceneID1;
    public int VictorySceneID2;

}
