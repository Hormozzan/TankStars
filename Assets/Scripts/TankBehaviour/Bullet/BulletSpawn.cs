using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject Bullet;
    public Transform SpanwBullet;
    public string Direction;
    private void Update()
    {
        bool shoot = Input.GetKeyDown(KeyCode.Return);

        if (shoot)
        {
            if (GetComponent<Movement>().turn == 0) {
                var bullet_obj = Instantiate(Bullet, SpanwBullet.position, SpanwBullet.rotation);
                bullet_obj.GetComponent<BulletFire>().Direction = Direction;
            }

        }
    }
}
