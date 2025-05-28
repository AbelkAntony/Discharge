using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GunController gun;
    [SerializeField] DropboxController dropbox;
    [SerializeField] TextMeshProUGUI uiScore;
    [SerializeField] TextMeshProUGUI uiPlayerLife;
    [SerializeField] TextMeshProUGUI uiHighscore;
    [SerializeField] GameObject gameOver;
    private float playerRange;
    private int score;
    private int playerLife;
    private int highScore = 0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        uiHighscore.text = highScore.ToString();

    }
    public void StartGame()
    {

        SceneManager.LoadScene("Instructions");
    }

    public void ResetGame()
    {
        Debug.Log("resetgame");
        score = 0;
        uiScore.text = score.ToString();
        player.Reset();
        playerLife = player.GetPlyerLife();
        uiPlayerLife.text = playerLife.ToString();
    }

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
        uiScore.text = score.ToString();
    }

    public void PlayerTakeDamage()
    {
        player.TakeDamage();
    }

    public void UpdatePlyerLife(int playerLife)
    {
        uiPlayerLife.text = playerLife.ToString();
    }

    public void GameOver()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }
        SceneManager.LoadScene("Game Over");
        gameOver.SetActive(true);
        //loadgame over screen
    }

    public void GameMenu()
    {
        SceneManager.LoadScene("Game Menu");
    }
    public void DropBox()
    {

    }

}
