using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GunController gun;
    private float playerRange;

    
    public void SetPlayerRange(float radius) {    playerRange = radius;     }


    public Vector3 Getplayerlocation()  {   return player.Getplayerlocation();   }
    public float GetPlayerCharge() { return player.GetPlayerCharge();  }
    public float GetPlayerRange()       
    {
        playerRange = player.GetPlayerRange();
        return playerRange;   
    }
    public bool IsGunActivated()
    {
        return gun.IsGunActivated();
    }
     
    public float GetBulletDamage()
    {
        return gun.GetBulletDamge();
    }


}
