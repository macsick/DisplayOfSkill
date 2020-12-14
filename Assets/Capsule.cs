using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    Rigidbody2D CapsuleRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        CapsuleRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CapsuleRB.velocity = new Vector2(0,-1 );
        if (transform.position.y < -10f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Spaceship>().AddHP();
            Destroy(gameObject);
        }
    }
}
