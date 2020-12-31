using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public float bullet_force = 100.0f;
    public string direction;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FirePoint") {
            if (direction == "right") GetComponent<Rigidbody2D>().AddForce(Vector2.right * bullet_force);
            else GetComponent<Rigidbody2D>().AddForce(-Vector2.right * bullet_force);
        }
    }

}
