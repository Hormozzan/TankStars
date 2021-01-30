using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject Bullet;
    public Transform SpanwBullet;
    public float SpawnAngle;
    public float MinRot;
    public float MaxRot;
    public float RotSpeed;
    public float BulletForce = 700.0f;
    private void Start()
    {
        SpawnAngle = SpanwBullet.transform.eulerAngles.z;
    }

    private void Update()
    {
        if (GetComponent<Movement>().turn == 1)
        {
            SpawnAngle += (Input.GetAxis("Horizontal") * RotSpeed);
            SpawnAngle = Mathf.Clamp(SpawnAngle, MinRot, MaxRot);
            SpanwBullet.rotation = Quaternion.Euler(0, 0, SpawnAngle);

            BulletForce += Input.GetAxis("Vertical");
            BulletForce = Mathf.Clamp(BulletForce, 500, 1000);
        }
        if (Input.GetKeyDown(KeyCode.Return) && GetComponent<Movement>().turn == 0)
        {
            var BulletObj = Instantiate(Bullet, SpanwBullet.position, SpanwBullet.rotation);
            BulletObj.GetComponent<BulletFire>().BulletForce = BulletForce;
        }
    }
}
