using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float bulletSpeed = 1f;
    private Rigidbody2D bulletRb;
    public float maxLifeTime = 4f;
    private int bulletDamage = 1;
    private void Start()
    {
        bulletRb = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, maxLifeTime);
    }

    private void FixedUpdate()
    {
        bulletRb.velocity = transform.TransformDirection(Vector2.up*(bulletSpeed + bulletRb.velocity.magnitude));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        Destroy(this.gameObject);
    }


    public int GetBulletDamage()
    {
        return bulletDamage;
    }

    public void SetBulletDamage(int damage)
    {
        bulletDamage = damage;
    }
    public void SetBulletDamage()
    {
        bulletDamage = 1;
    }
   
}
