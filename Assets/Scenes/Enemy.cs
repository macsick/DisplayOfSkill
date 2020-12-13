using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bullet,explosion;
    public Color bulletColor;
    public int score;
    public float xSpeed;
    public float ySpeed;
    public bool canShoot;
    
    public float fireRate;
    public float health;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
        if (!canShoot) return;

        fireRate = fireRate + (Random.Range(fireRate / -2, fireRate / 2));
        InvokeRepeating("Shoot", fireRate,fireRate);
        
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed,ySpeed*-1);
        if (transform.position.y < -10f)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            Die();
            collision.gameObject.GetComponent<Spaceship>().Damage();

        }
    }
    void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        Destroy(gameObject);
        
    }
    public void Damage()
    {
        health--;
        if (health == 0)
        {
            Die();
        }
    }
    void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<bullet>().ChangeDirection();
        temp.GetComponent<bullet>().ChangeColor(bulletColor);
    }
}
