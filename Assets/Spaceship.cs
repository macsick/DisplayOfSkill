﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    GameObject Barrel;
    Rigidbody2D rb;
    public GameObject bullet,explosion,ding;

    public float speed;
    float health = 3;
    int delay = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Barrel = transform.Find("Barrel").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical") * speed));

        if (Input.GetKey(KeyCode.Space)&&delay>50)
            Shoot();
        delay++;
    }
    public void Damage()
    {
        health-= 1f;
        Instantiate(ding, transform.position, Quaternion.identity);
        if (health == 0f)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void Shoot()
    {
        delay = 0;
        Instantiate(bullet, Barrel.transform.position, Quaternion.identity);
    }
}
