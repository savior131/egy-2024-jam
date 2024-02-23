using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public static bool enemeybeaten;
    [SerializeField] GameObject lightSword, brokenSwoard,swordInScene ;
    [SerializeField] GameObject enemy;

  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);

            if (!enemeybeaten)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    text.text = "can't pull the sword";
                    enemy.SetActive(true);
                }
                else
                {
                    text.text = "press E to interact";
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                  lightSword.SetActive(true);
                    brokenSwoard.SetActive(false);
                    text.gameObject.SetActive(false);
                    swordInScene.SetActive(false);
                }
                
            }
        }
    }


    /*   private void OnTriggerExit2D(Collider2D collision)
       {
           if (collision.gameObject.CompareTag("Player"))
           {
               text.gameObject.SetActive(false);
           }

       }
   */
}