using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerGetDamaged : MonoBehaviour
{
    int playerHealth;
    private void Start()
    {
        playerHealth = 100;
    }

    public void getDamage(int damage)
    {
        playerHealth -= damage;
     
        Debug.Log(playerHealth);
        if (playerHealth <= 0) {
            playerDie();        
        }
    }

    void playerDie()
    {
        SceneManager.LoadScene(0);
    }
}
