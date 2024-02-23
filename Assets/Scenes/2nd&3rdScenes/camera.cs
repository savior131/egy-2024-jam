using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField]Transform player;
    [SerializeField] GameObject dust;
    void Update()
    {
        transform.position = new Vector3(player.position.x + 4f, transform.position.y, transform.position.z);
        dust.transform.position = transform.position;
    }
}
