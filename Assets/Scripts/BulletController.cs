using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float bulletSpeed = 5f;
    private Rigidbody2D bulletRb;
    public float maxLifeTime = 4f;
    private void Start()
    {
        bulletRb = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, maxLifeTime);
    }
    private void Update()
    {
        //this.transform.position += transform.forward * bulletSpeed * Time.deltaTime;

    }

    private void FixedUpdate()
    {
        //bulletRb.AddForce(Vector3.forward * bulletSpeed);
        bulletRb.velocity = transform.TransformDirection(Vector2.up*(bulletSpeed + bulletRb.velocity.magnitude));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
