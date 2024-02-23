using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingenemies : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    [SerializeField]Transform[] dropPoints;
    [SerializeField]GameObject drobObject;
    [SerializeField]float waitTime;
    GameObject instantiatedObject;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(shoot());
    }

    // Update is called once per frame
    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            animator.SetTrigger("shot");
            yield return new WaitForSeconds(1);
           instantiatedObject= Instantiate(drobObject);
            instantiatedObject.transform.position= dropPoints[Random.Range(0, dropPoints.Length)].position;
        }
        yield return null;
    }
}
