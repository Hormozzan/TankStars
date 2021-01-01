using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public float BulletForce = 100.0f;
    public float Damage = 10.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FirePoint") {
            GetComponent<Rigidbody2D>().AddForce(collision.transform.right * BulletForce);
        }
    }

}
