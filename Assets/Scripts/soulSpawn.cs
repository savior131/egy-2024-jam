using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulSpawn : MonoBehaviour
{
    Animator soulAnim;
    [SerializeField] Transform swordPos;
    Vector2 pos;
    bool canEnter = false;

    private void Awake()
    {
        soulAnim = GetComponent<Animator>();
        soulAnim.SetTrigger("spawn");

    }

    private void OnEnable()
    {
        soulAnim.SetTrigger("spawn");
        StartCoroutine(enterSword());


    }
    //private void Start()
    //{
    //    Debug.Log("coroutine started");
    //}

    private void Update()
    {
        if (!canEnter)
            return;
        pos = new Vector2(swordPos.position.x, swordPos.position.y);
        transform.position = Vector2.MoveTowards(transform.position, pos, 9 * Time.deltaTime);

    }

    IEnumerator enterSword()
    {
        yield return new WaitForSeconds(3f);
        canEnter = true;
        soulAnim.SetTrigger("enter");
        yield return new WaitForSecondsRealtime(3f);
        canEnter = false;
        gameObject.SetActive(false);
        gameObject.transform.localScale = new Vector2(1, 1);
    }
}
