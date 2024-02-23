using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulSpawn : MonoBehaviour
{
    Animator soulAnim;

    private void Awake()
    {
        soulAnim = GetComponent<Animator>();
        soulAnim.SetTrigger("spawn");

    }
}
