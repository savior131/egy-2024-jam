using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeFall : MonoBehaviour
{
    [SerializeField] Rigidbody2D slime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            slime.gravityScale = 3;
            gameObject.SetActive(false);
        }
    }
}
