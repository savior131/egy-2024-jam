using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;


public class exorcism : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject lightSim;
    [SerializeField] GameObject soul;
    [SerializeField] GameObject soulReturn;
    GameObject soulInstant;
    [SerializeField] GameObject target;
    bool canExorcist;
    bool alreadyExorcist;
    bool isExorcisting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !alreadyExorcist)
        {
            text.gameObject.SetActive(true);
            StartCoroutine(delayTime());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && canExorcist && !alreadyExorcist)
        {
            isExorcisting = true;
            lightSim.gameObject.SetActive(true);
            soulInstant = Instantiate(soul, lightSim.transform.position, Quaternion.identity);
            alreadyExorcist = true;
        }

        if (isExorcisting)
        {
            soulInstant.transform.position = Vector2.MoveTowards(soulInstant.transform.position, target.transform.position, 5 * Time.deltaTime);
            if (Mathf.Abs(soulInstant.transform.position.x - target.transform.position.x) <= 1.5f)
            {
                target.GetComponent<EnemyPatrollingAI>().decreaseHealth(110);
                soulReturn.transform.position = soulInstant.transform.position;
                soulInstant.gameObject.SetActive(false);
                soulReturn.SetActive(true);
                isExorcisting = false;
            }
            
        }
        if(alreadyExorcist)
            text.gameObject.SetActive(false);
    }

    IEnumerator delayTime()
    {
        canExorcist = true;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            lightSim.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            lightSim.gameObject.SetActive(false);
            if (alreadyExorcist)
            {
                break;
            }
        }
    }
}
