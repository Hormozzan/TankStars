using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TankPresenter : MonoBehaviour
{
    float speed;
    public Text FuelText;
    public Text HealthText;
    public Text CoinText;
    public AudioSource MovementAudio;
    public AudioSource ShootingAudio;
    public BulletPresenter BulletPresenterObj;
    public Transform BulletSpanwPoint;
    public float SpawnAngle;
    public Image TankImage;
    private Action FuelConsumption;
    private Action<float> OnCollisionBullet;
    public int turn = 0;
    public float RotSpeed;
    float Force = 700.0f;

    public GameObject point;
    GameObject[] poitns;
    public int numberOfPoints;
    public float SpaceBetweenPoints;
    private string tag;
    private void Start()
    {
        poitns = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            poitns[i] = Instantiate(point, BulletSpanwPoint.position, Quaternion.identity);
        }
    }
    Vector2 PointPosition(float t)
    {
        Vector2 angle = Vector2.one.normalized;
        Vector2 postion = (Vector2)BulletSpanwPoint.position + (angle * (Force/120) * t) + 0.5f * Physics2D.gravity * (t * t);
        if (tag == "right")
        {
            postion.x = (float)(BulletSpanwPoint.position.x - (angle.x * (Force / 120) * t) + 0.5f * Physics2D.gravity.x * (t * t));
            postion.y += (180 - SpawnAngle) * 0.07f * t;
        }
        else postion.y += SpawnAngle * 0.07f * t;
        return postion;
    }
    public void SetUp(Sprite sprite, Text fuel, Text health, Text coin, float speed, string positon, float rot_speed, float spawn_angle)
    {
        FuelText = fuel;
        HealthText = health;
        CoinText = coin;
        this.speed = speed;
        AudioSource[] TankSounds = GetComponents<AudioSource>();
        MovementAudio = TankSounds[0];
        ShootingAudio = TankSounds[1];
        TankImage.sprite = sprite;
        tag = positon;
        if (positon == "left")
        {
            transform.localScale = new Vector3(1, 1, 0);
            turn = 1;
        }
        else transform.localScale = new Vector3(-1, 1, 0);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 50);
        SpawnAngle = spawn_angle;
        BulletSpanwPoint.rotation = Quaternion.Euler(0, 0, SpawnAngle);
        RotSpeed = rot_speed;
    }

    
    public void SetActions(Action FuelConsumption, Action<float> OnCollisionBullet)
    {
        this.FuelConsumption = FuelConsumption;
        this.OnCollisionBullet = OnCollisionBullet;
    }

    
    
    public void SetFuelText(float fuel)
    {
        if (fuel <= 33) FuelText.color = Color.red;
        else if (fuel <= 66 && fuel > 33) FuelText.color = Color.yellow;
        else FuelText.color = Color.green;
        FuelText.text = Mathf.Round(fuel).ToString();
    }
    
    
    public void SetHealthText(float health)
    {
        if (health <= 33) HealthText.color = Color.red;
        else if (health <= 66 && health > 33) HealthText.color = Color.yellow;
        else HealthText.color = Color.green;
        HealthText.text = Mathf.Round(health).ToString();
    }


    public void SetCoinText(int coin)
    {
        CoinText.text = coin.ToString();
    }
    
    
    public void Shoot()
    {
        var BulletObj = Instantiate(BulletPresenterObj, BulletSpanwPoint.position, BulletSpanwPoint.rotation);
        BulletObj.SetForce(Force);
    }
    
    
    void Update()
    {
        if (turn == 1)
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                poitns[i].transform.position = PointPosition(i * SpaceBetweenPoints);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ShootingAudio.Play();
        }
    }

    
    
    public void moving()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            FuelConsumption();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            FuelConsumption();
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) MovementAudio.Play();
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) MovementAudio.Pause();
        //else MovementAudio.Pause();
    }
    
    
    public void Targeting()
    {
        gameObject.transform.localScale = SpawnAngle >= 90 ? new Vector3(-1, 1, 1) : gameObject.transform.localScale = new Vector3(1, 1, 1);

        SpawnAngle += (Input.GetAxis("Horizontal") * RotSpeed);
        SpawnAngle = Mathf.Clamp(SpawnAngle, 0, 180);
        BulletSpanwPoint.rotation = Quaternion.Euler(0, 0, SpawnAngle);

        Force += Input.GetAxis("Vertical");
        Force = Mathf.Clamp(Force, 500, 1000);
    }
    
    
    public void Turn()
    {
        turn = 1 - turn;
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && turn == 1)
        {
            OnCollisionBullet(collision.gameObject.GetComponent<BulletPresenter>().GetDamage());
            Destroy(collision.gameObject);

        }
    }
    public void DeactivePoints()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            poitns[i].SetActive(false);
        }
    }
    public void ActivePoints()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            poitns[i].SetActive(true);
        }
    }

}
