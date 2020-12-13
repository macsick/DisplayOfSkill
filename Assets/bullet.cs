using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D rb;
    int dir = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, 5);
    }
    // Start is called before the first frame update
    public void ChangeDirection()
    {
        dir*= -1;
    }

    public void ChangeColor(Color col)
    {
        GetComponent<SpriteRenderer>().color = col;
    }

    void Update()
    {
        rb.velocity = new Vector2(0,10 * dir);
        if (transform.position.y < -10f)
            Destroy(gameObject);
        if (transform.position.y > 10f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dir == 1)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Enemy>().Damage();
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Spaceship>().Damage();
            }
        }
    }
}
