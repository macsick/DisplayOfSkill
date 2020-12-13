using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float rate;
    public int waves = 1;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {   for (int i = 0; i < waves; i++)
            Instantiate(enemies[Random.Range(0,enemies.Length)],new Vector3(Random.Range(-8f,8f),7,0),Quaternion.identity);
    }
}
