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
            CancelInvoke("Fire");
        }
    }

    public bool IsGunActivated(){  return isGunActivate;   }


    private void Fire()
    {
       Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);     
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
