using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public Transform bullet;
    public float ColisionRadius = 0.4f;
    public bool Colided = false;
    public LayerMask ColidedWith;
    
    void Update()
    {
        Colided = Physics2D.OverlapCircle(bullet.position, ColisionRadius, ColidedWith);

        if (Colided ||
            !GetComponent<Renderer>().isVisible ||
            gameObject.transform.position.y <= -1.9 ||
            gameObject.transform.position.x >= 8.9 ||
            gameObject.transform.position.x <= -8.9)
        { 
            Destroy(gameObject);
        }
    }
}
