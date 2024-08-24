using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject bulletSpawnLocation;
    [SerializeField] GameObject bulletPrefab;
    //[SerializeField] float defaultSpeed = 10;
    //[SerializeField] GameObject bullet;
    private bool isGunActivate;
    private Vector3 playerlocation;
    private float distanceBetweenPlayerAndGun;
    private GameObject enemy;
    
    private void Start()
    {
        isGunActivate = false;
        playerlocation = gameManager.Getplayerlocation();
        InvokeRepeating("Fire", 0, 2);
    }
    private void Update()
    {
        playerlocation = gameManager.Getplayerlocation();
        distanceBetweenPlayerAndGun = Vector3.Distance(gameManager.Getplayerlocation(), this.transform.position);
        if (distanceBetweenPlayerAndGun <= gameManager.GetPlayerRange() && gameManager.GetPlayerCharge() > 0)
        {
            isGunActivate = true;
            RotateGun();
        }
        else 
        {
            isGunActivate = false;
        }
    }

    public bool IsGunActivated(){  return isGunActivate;   }


    private void Fire()
    {
        if(isGunActivate)
        {
            Transform enemyLocation = enemy.transform;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnLocation.transform.position, this.transform.rotation);
            //bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * 500,ForceMode2D.Force);
            //Destroy(bullet, 20);
        }
    }

    private void RotateGun()
    {
        if (enemy == null)
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        Vector3 targetDirection = enemy.transform.position - transform.position ;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.AngleAxis(angle +90 ,Vector3.forward);
        this.transform.rotation = rotate;   
    }
}
