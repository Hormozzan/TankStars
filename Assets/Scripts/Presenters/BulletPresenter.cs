using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPresenter : MonoBehaviour
{
    public BulletConfig BulletConfigObj;
    public bool Colided = false;
    public LayerMask ColidedWith;
    private BulletModel BulletModelObj;
    private float Force;
    private float Damage;
    private float ColisionRadius;
    private Rigidbody2D rb;
    
    
    public void Awake()
    {
        transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        rb = GetComponent<Rigidbody2D>();
        BulletModelObj = new BulletModel();
        Force = BulletConfigObj.force;
        Damage = BulletConfigObj.damage;
        ColisionRadius = BulletConfigObj.colision_radius;
    }

    
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Colided = Physics2D.OverlapCircle(transform.position, ColisionRadius, ColidedWith);
    
        if (Colided || !GetComponent<Renderer>().isVisible ||
            transform.position.y <= -1.9 || transform.position.x >= 8.9 || transform.position.x <= -8.9)
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
