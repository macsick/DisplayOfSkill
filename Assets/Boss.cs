using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    Rigidbody2D rb;


    public GameObject bullet, explosion;
    public Color bulletColor;
    public AudioClip shootFX;
    public AudioClip deathFX;
    public int score;
    public float xSpeed;
    public float ySpeed;


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



    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ySpeed = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 4f)
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
        BossDead();
        transform.position = transform.position + new Vector3(100f, 100f, 0);
    }
    private void BossDead()
    {
        Invoke("LoadFirstScene", 1);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(2);
    }

}