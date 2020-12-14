using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bullet,explosion,capsule;
    public Color bulletColor;
    public AudioClip shootFX;
    public AudioClip deathFX;
    public int score;
    public float xSpeed;
    public float ySpeed;
    public bool canShoot, oscillates;
    
    public float fireRate;
    public float health;
    AudioSource audioSource;
    [SerializeField] float movementVector = 5f;
    [SerializeField] float period = 2f;
    [Range(0, 1)]
    [SerializeField]
    float movementFactor;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
        if (!canShoot||!oscillates) return;

        fireRate = fireRate + (Random.Range(fireRate / -2, fireRate / 2));
        InvokeRepeating("Shoot", fireRate,fireRate);
        movementVector = movementVector + (Random.Range(movementVector / -2, movementVector / 2));

    }
    // Update is called once per frame
    void Update()
    { 
        if (oscillates == true)
        {
            if (period <= Mathf.Epsilon) { return; }
            float cycles = Time.time / period;

            const float tau = Mathf.PI * 2;
            float rawSinWave = Mathf.Sin(cycles * tau);

            movementFactor = movementVector*rawSinWave - 0.5f*rawSinWave*movementVector;
            rb.velocity = new Vector2(movementFactor, ySpeed * -1);
            if (transform.position.y < -10f)
                Destroy(gameObject);
        }
        else
        {
            rb.velocity = new Vector2(xSpeed, ySpeed * -1);
            if (transform.position.y < -10f)
                Destroy(gameObject);
        }
            
        

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
        if ((int)Random.Range(0,3)==0)
            Instantiate(capsule, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(deathFX, this.gameObject.transform.position);
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
        audioSource.PlayOneShot(shootFX);
        temp.GetComponent<bullet>().ChangeDirection();
        temp.GetComponent<bullet>().ChangeColor(bulletColor);
    }
}
