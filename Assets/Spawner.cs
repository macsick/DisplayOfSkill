using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float totaltime = 0;
    public float rate;
    int waves;
    public GameObject[] enemies;
    public string bossspawn = "n";
    public Transform Santa;
    public AudioClip Christmas;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        totaltime += Time.deltaTime;
        WaveCalculation();
        if (waves != 0)
            PlayerPrefs.SetInt("Wave", waves);
        else
        {
            PlayerPrefs.SetInt("Wave", 8055);
            if (bossspawn == "n")
            {
                bossspawn = "y";
                audioSource.PlayOneShot(Christmas);
                Instantiate(Santa, new Vector3(0, 10, 0), Santa.rotation);
            }
        }
    }

    private void WaveCalculation()
    {
        if (totaltime > 60)
            waves = 0;
        else if (totaltime > 48)
            waves = 4;
        else if (totaltime > 32)
            waves = 3;
        else if (totaltime > 16)
            waves = 2;
        else if (totaltime < 16)
            waves = 1;
    }

    void SpawnEnemy()
    {   for (int i = 0; i < waves; i++)
            Instantiate(enemies[Random.Range(0,enemies.Length)],new Vector3(Random.Range(-8f,8f),7,0),Quaternion.identity);
    }
}
