using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenSpawn : MonoBehaviour
{
    public float rate= 2;
    public int waves = 1;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }


    void SpawnEnemy()
    {   for (int i = 0; i < waves; i++)
            Instantiate(enemies[Random.Range(0,enemies.Length)],new Vector3(Random.Range(-8f,8f),7,0),Quaternion.identity);
    }
}
