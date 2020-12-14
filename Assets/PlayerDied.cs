using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour
{
    
    void Update()
    {
        print(GameObject.FindGameObjectsWithTag("Player"));
           
            //Invoke("LoadFirstScene", 2f);
    }
    private void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }
}
 