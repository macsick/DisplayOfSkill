using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShoot : MonoBehaviour
{

    public GameObject bullet;
    public float startHeight= 4f;
    public float shotDelay = 1f;
    private float endDelay = 0;
    public AudioClip shootFX;
    AudioSource audioSource;

    // Use this for initialization
    void Awake()
    {
        endDelay = Time.time;
        audioSource = GetComponent<AudioSource>();
    }
    public bool Recharged()
    {
        return (Time.time > endDelay);
    }

    // Update is called once per frame
    void Update()
    {

        if (Recharged() && (transform.position.y < startHeight))
        {
            audioSource.PlayOneShot(shootFX);
            ShootMissle();
        }

    }

    void ShootMissle()
    {
        endDelay = Time.time + shotDelay;
        Instantiate(bullet, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.80f), gameObject.transform.rotation);

    }
}