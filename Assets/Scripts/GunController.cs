using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject bulletSpawnLocation;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float defaultSpeed = 10;
    //[SerializeField] GameObject bullet;
    private bool isGunActivate;
    private Vector3 playerlocation;
    private float distance;
    private GameObject enemy;
    
    private void Start()
    {
        isGunActivate = false;
        playerlocation = gameManager.Getplayerlocation();
    }
    private void Update()
    {
        if(playerlocation != gameManager.Getplayerlocation())
        {
            playerlocation = gameManager.Getplayerlocation();
            distance = Vector3.Distance(gameManager.Getplayerlocation(), this.transform.position);
            if (distance <= gameManager.GetPlayerRange())
            {
                isGunActivate = true;
                Fire();
            }
            else { isGunActivate = false; }
            
        }
        if(enemy == null)
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        RotateGun();

    }

    public bool IsGunActivated(){   return isGunActivate;   }


    private void Fire()
    {
        if (isGunActivate)
        {
            Debug.Log("gun activated");
        }
    }

    private void RotateGun()
    {
        
        Vector3 targetDirection = enemy.transform.position - transform.position ;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.AngleAxis(angle +90 ,Vector3.forward);
        this.transform.rotation = rotate;
        
    }
}
