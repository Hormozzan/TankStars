using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public GameObject Tank1;
    public GameObject Tank2;
    public int VictorySceneID1;
    public int VictorySceneID2;

    void Start()
    {
        Tank1.GetComponent<Movement>().turn = 1;
        Tank2.GetComponent<Movement>().turn = 0;
    }

    void Update()
    {
        float health1 = Tank1.GetComponent<Movement>().Health;
        float health2 = Tank2.GetComponent<Movement>().Health;

        if (health1 <= 0)
        {
            GetComponent<SceneSwitcher>().Switch(VictorySceneID2);
        }

        if (health2 <= 0)
        {
            GetComponent<SceneSwitcher>().Switch(VictorySceneID1);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Tank1.GetComponent<Movement>().turn = 1 - Tank1.GetComponent<Movement>().turn;
            Tank2.GetComponent<Movement>().turn = 1 - Tank2.GetComponent<Movement>().turn;
        }
    }
}
