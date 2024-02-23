using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossHealth : MonoBehaviour
{
    int health = 100;
    // Start is called before the first frame update

    // Update is called once per frame
    public void damage(int damage)
    {
           health -= damage;
        if(health < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
