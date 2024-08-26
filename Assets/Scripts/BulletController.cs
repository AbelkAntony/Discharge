using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float bulletSpeed = 1000f;
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
        //Vector3.bulletRb.velocity +=  Vector3.forward;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
