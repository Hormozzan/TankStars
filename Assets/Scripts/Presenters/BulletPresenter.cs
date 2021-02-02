using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPresenter : MonoBehaviour
{
    private BulletModel BulletModelObj;
    public BulletConfig BulletConfigObj;
    private float Force;
    private float Damage;
    private float ColisionRadius;
    public bool Colided = false;
    public LayerMask ColidedWith;
    public void Awake()
    {
        BulletModelObj = new BulletModel();
        Force = BulletConfigObj.force;
        Damage = BulletConfigObj.damage;
        ColisionRadius = BulletConfigObj.colision_radius;
    }

    void Update()
    {
        Colided = Physics2D.OverlapCircle(transform.position, ColisionRadius, ColidedWith);

        if (Colided ||
            !GetComponent<Renderer>().isVisible ||
            transform.position.y <= -1.9 ||
            transform.position.x >= 8.9 ||
            transform.position.x <= -8.9)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FirePoint")
        {
            GetComponent<Rigidbody2D>().AddForce(collision.transform.right * Force);
        }
    }
    public void SetForce(float force)
    {
        Force = force;
    }
    public float GetDamage()
    {
        return Damage;
    }
}
