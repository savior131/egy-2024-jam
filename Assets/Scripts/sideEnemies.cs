using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideEnemies : MonoBehaviour
{
    [SerializeField]Transform[] sides;
    [SerializeField]GameObject enemy;
    [SerializeField]float waitTime;
    GameObject instantiatedObject;
    
   // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sideEnemiesHold());
    }
    IEnumerator sideEnemiesHold()
    {
        yield return new WaitForSeconds(waitTime);
        instantiatedObject = Instantiate(enemy);
        instantiatedObject.transform.position = sides[Random.Range(0, sides.Length)].position;
        
    }
}
