using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 moveTo;
    private GameObject[] player;
    private float speed = 1;
    private Vector3 spawnLocation;
    private float minSize = 1f;
    private float maxSize = 2f;
    private int life = 5;
    private float size = 1f;
    private GameObject attackingPlayer;
    private int numberOfPlayers;
    private int score;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        player = GameObject.FindGameObjectsWithTag("Player");
        numberOfPlayers = player.Length;
        attackingPlayer = player[Random.Range(0, numberOfPlayers)];
        spawnLocation = this.gameObject.transform.position;
        moveTo = attackingPlayer.transform.position;
    }

    private void Update()
    {
        speed = 1 * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, moveTo,speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if(collision.gameObject.tag == "Player")
        {
            Reset();
            gameManager.PlayerTakeDamage();
        }
        else if(collision.gameObject.name == "Bullet(Clone)")
        {
            //TakeDamage(GetComponent<GameManager>().GetBulletDamage());
            //Debug.Log("take damage");
            TakeDamage(FindAnyObjectByType<GameManager>().GetBulletDamage());
        }
    }

    private void Reset()
    {
        size = Random.Range(minSize, maxSize);
        this.transform.localScale = Vector3.one * this.size;
        this.gameObject.transform.position = spawnLocation;
        attackingPlayer = player[Random.Range(0, numberOfPlayers)];
        life = Random.Range(1, 6);
        score = life;
        moveTo = attackingPlayer.transform.position;
    }

    private void GetDirection()
    {

    }

    private void TakeDamage(int damage)
    {
        if(life > 0)
        {
            this.life = life - damage;
            //Debug.Log("Enemy life");
            //Debug.Log(life);
        }
        else //if (life <= 0)
        {
            Reset();
            gameManager.AddScore(score);
        }

    }
}
