using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("player dead");
    }
}
