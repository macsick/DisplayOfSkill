using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{
    GameObject Barrel;
    Rigidbody2D rb;
    public GameObject bullet,explosion,ding;
    public AudioClip shootFX,deathFX;
    public float speed;
    public float fireRate = 0.5F;
    float nextFire = 0.0f;
    int health = 3;
    AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Barrel = transform.Find("Barrel").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        health++;
        PlayerPrefs.SetInt("HP", health);
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical") * speed));

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
            
            Shoot();
           
    }
    public void Damage()
    {
        health-= 1;
        PlayerPrefs.SetInt("HP", health);
        Instantiate(ding, transform.position, Quaternion.identity);
        if (health == 0f)
        {
            AudioSource.PlayClipAtPoint(deathFX, this.gameObject.transform.position);
            Instantiate(explosion, transform.position, Quaternion.identity);
            PlayerDied();
            transform.position = transform.position +new Vector3 (100f, 100f,0);
            
            

        }
    }
    void Shoot()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bullet, Barrel.transform.position, Quaternion.identity);
        audioSource.PlayOneShot(shootFX);
    }
    public void AddHP()
    {
        health++;
        PlayerPrefs.SetInt("HP",health);
    }
    private void PlayerDied()
    {
        Invoke("LoadFirstScene", 1);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }
}
