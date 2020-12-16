using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSpiral : MonoBehaviour
{
    public float direction = 1;
    public float totaltime = 0;
    public float angle = 0f;
    //private Vector2 bulletMoveDirection;
    public GameObject bullet;
    public float startTime = 10f;
    public float shotDelay = 0.05f;
    private float endDelay = 0;
    public AudioClip shootFX;
    AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        endDelay = Time.time;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        totaltime += Time.deltaTime;
        if (Recharged() && (totaltime > startTime))
        {
            audioSource.PlayOneShot(shootFX);
            Fire();
        }
    }
    public bool Recharged()
    {
        return (Time.time > endDelay);
    }
    private void Fire()
    {
        endDelay = Time.time + shotDelay;
        for (int i = 0; i <= 0; i++)
        {
            //float bulDirX = transform.position.x + direction * Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            //float bulDirY = transform.position.y + direction * Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            //Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            //Vector2 bulDir = (bulMoveVector - transform.position).normalized;
            
            Instantiate(bullet, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.80f), Quaternion.Euler(0,0,angle*direction));




        }

        angle += 20f;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
