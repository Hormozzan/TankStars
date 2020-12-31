using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 2;
    public Text FuelText;
    public Text HealthText;
    public float InitialFuel = 100;
    public float Fuel;
    public int turn = 0;
    public float Health;
    public float InitialHealth = 100;

    void Start()
    {
        Fuel = InitialFuel;
        Health = InitialHealth;
    }

    void Update()
    {
        if (Fuel <= 33) FuelText.color = Color.red;
        else if (Fuel <= 66 && Fuel > 33) FuelText.color = Color.yellow;
        else FuelText.color = Color.green;

        if (Health <= 33) HealthText.color = Color.red;
        else if (Health <= 66 && Health > 33) HealthText.color = Color.yellow;
        else HealthText.color = Color.green;

        FuelText.text = Mathf.Round(Fuel).ToString();
        HealthText.text = Mathf.Round(Health).ToString();

        if (turn == 1) Fuel = move(Fuel);
        if (Input.GetKeyDown(KeyCode.Return)) Fuel = InitialFuel;
    }
    private float move(float fuel)
    {

        if (fuel > 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
                fuel -= speed / 10;
            }

            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
                fuel -= speed / 10;
            }
        }

        return fuel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && turn == 1)
        {
            Destroy(collision.gameObject);
            Health -= 10;

        }
    }
}
