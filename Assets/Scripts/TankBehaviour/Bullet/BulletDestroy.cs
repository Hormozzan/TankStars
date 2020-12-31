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

        if (Colided) Destroy(gameObject);
        if (!GetComponent<Renderer>().isVisible) Destroy(gameObject);
    }
}
