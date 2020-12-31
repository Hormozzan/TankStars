using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public GameObject Tank1;
    public GameObject Tank2;

    void Start()
    {
        Tank1.GetComponent<Movement>().turn = 1;
        Tank2.GetComponent<Movement>().turn = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Tank1.GetComponent<Movement>().turn = 1 - Tank1.GetComponent<Movement>().turn;
            Tank2.GetComponent<Movement>().turn = 1 - Tank2.GetComponent<Movement>().turn;

        }
        
    }
}
