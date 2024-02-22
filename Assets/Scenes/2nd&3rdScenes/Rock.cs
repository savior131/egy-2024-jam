using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
        }

    }
}
