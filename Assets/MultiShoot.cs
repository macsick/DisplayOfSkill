using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShoot : MonoBehaviour
{

    public GameObject bullet;

    public float startShotTime = 0.5f;
    public float delayShotTime = 0.5f;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("ShootMissle", startShotTime, delayShotTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShootMissle()
    {
        Instantiate(bullet, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.80f), Quaternion.identity);
    }
}