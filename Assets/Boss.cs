using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D rb;

    GameObject FastGunA, FastGunB, BigGunB, BigGunA;
    public GameObject bullet, explosion;
    public Color bulletColor;
    public AudioClip shootFX;
    public AudioClip deathFX;
    public int score;
    public float xSpeed;
    public float ySpeed;
    float cooldown;
    float cooldownSeconds = 0.5f;
    float nextFire;

    public float fireRate;
    public float health;
    AudioSource audioSource;
    [SerializeField] float movementVector = 5f;
    [SerializeField] float period = 5f;
    [Range(0, 1)]
    [SerializeField]
    float movementFactor;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        FastGunA = transform.Find("FastGunA").gameObject;
        FastGunB = transform.Find("FastGunB").gameObject;


    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ySpeed = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 3f)
        {
            ySpeed = 0f;
        }

        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = movementVector * rawSinWave - 0.5f * rawSinWave * movementVector;
        rb.velocity = new Vector2(movementFactor, ySpeed);
    }

    public void Damage()
    {
        health--;
        if (health == 0)
        {
            Die();
        }
    }
    void Die()
    {
        AudioSource.PlayClipAtPoint(deathFX, this.gameObject.transform.position);
        Instantiate(explosion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        Destroy(gameObject);
    }

}