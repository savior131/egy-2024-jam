using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueEnable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject dialogue;

    // Update is called once per frame
    void Update()
    {
        if (Rock.enemeybeaten)
        {
            dialogue.SetActive(true);
        }
    }
}
