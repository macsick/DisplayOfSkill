using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBullet : MonoBehaviour
{
    float speed = 5f;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
        if (transform.position.y < -5f)
            Destroy(gameObject);
        if (transform.position.y > 5f)
            Destroy(gameObject);
        if (transform.position.x > 10f)
            Destroy(gameObject);
        if (transform.position.x < -10f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Spaceship>().Damage();
            
        }
    }
}
