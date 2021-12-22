using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float xSpeed;
    public float ySpeed;
    public int score;
    public GameObject bullet, explosion, ark;

    public bool canShoot;
    public float fireRate;
    public float health;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        if (!canShoot) return;
        fireRate = fireRate + (Random.Range(fireRate / -2, fireRate / 2));
        InvokeRepeating("Shoot", fireRate, fireRate);
        
    }

    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed * -1);
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<SpaceShip>().Damage();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            if ((int)Random.Range(0, 5) == 0) Instantiate(ark, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        }
        
    }
    public void Damage()
    {
        health--;
        if (health == 0)
        {
            Destroy(gameObject);
            if((int)Random.Range(0,5)==0) Instantiate(ark, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        }
        }
    
    void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
    }
}
