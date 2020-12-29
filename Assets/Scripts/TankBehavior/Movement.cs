using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject Tank1;
    public GameObject Tank2;
    public Text FuelText1;
    public Text FuelText2;
    public float speed = 2;
    public float initialFuel = 100;
    private int turn = 1;
    private float fuel1;
    private float fuel2;

    private void Start()
    {
        fuel1 = initialFuel;
        fuel2 = initialFuel;
    }

    private void Update()
    {
        if (fuel1 <= 33)
        {
            FuelText1.color = Color.red;
        }

        else if (fuel1 <= 66 && fuel1 > 33)
        {
            FuelText1.color = Color.yellow;
        }

        else
        {
            FuelText1.color = Color.green;
        }

        if (fuel2 <= 33)
        {
            FuelText2.color = Color.red;
        }

        else if (fuel2 <= 66 && fuel2 > 33)
        {
            FuelText2.color = Color.yellow;
        }

        else
        {
            FuelText2.color = Color.green;
        }

        FuelText1.text = Mathf.Round(fuel1).ToString();
        FuelText2.text = Mathf.Round(fuel2).ToString();

        if (turn == 1)
        {
            fuel1 = move(Tank1, fuel1);
        }

        else if(turn == 0)
        {
            fuel2 = move(Tank2, fuel2);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            turn = 1 - turn;

            if (turn == 1)
            {
                fuel1 = initialFuel;
            }

            else if (turn == 0)
            {
                fuel2 = initialFuel;
            }
        }
    }

    private float move(GameObject tank, float fuel)
    {
        if (fuel > 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                tank.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
                fuel -= speed / 10;
            }

            else if (Input.GetKey(KeyCode.A))
            {
                tank.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
                fuel -= speed / 10;
            }
        }

        return fuel;
    }
}
