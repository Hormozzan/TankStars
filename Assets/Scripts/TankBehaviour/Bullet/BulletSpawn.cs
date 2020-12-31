using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawn_point;
    public string direction;
    private void Update()
    {
        bool shoot = Input.GetKeyDown(KeyCode.Return);

        if (shoot)
        {
            if (GetComponent<Movement>().turn == 0) {
                var bullet_obj = Instantiate(bullet, spawn_point.position, spawn_point.rotation);
                bullet_obj.GetComponent<BulletFire>().direction = direction;
            }

        }
    }
}
