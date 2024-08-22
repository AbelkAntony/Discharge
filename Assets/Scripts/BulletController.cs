using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float bulletSpeed = 1f;
    private Rigidbody2D bulletRb;
    public float maxLifeTime = 4f;
    private void Start()
    {
        bulletRb = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, maxLifeTime);
    }
    private void Update()
    {
        this.transform.position += this.transform.position * bulletSpeed * Time.deltaTime;

    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
