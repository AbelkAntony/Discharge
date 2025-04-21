using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GunController gun;
    [SerializeField] DropboxController dropbox;
    //[SerializeField] TextMesh uiScore;
    [SerializeField] TextMeshPro uiScoreText;
    private float playerRange;
    private int score;


    
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
     
    public int GetBulletDamage()
    {
        return gun.GetBulletDamge();
    }
    public void AddScore(int _score)
    {
        score += _score;
    }
    public void DropBox()
    {

    }

}
