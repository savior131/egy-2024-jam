using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    private Collider2D col;
    private bool enemy = false;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private GameObject panel;
    private Vector2 vec;
    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        vec = col.bounds.center + new Vector3(distance, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
       
        if ( hit=Physics2D.Raycast(col.bounds.center, Vector2.right, distance, whatIsEnemy))
        {

            
                panel.SetActive(true);
                enemy = true;
                StartCoroutine(freezeTime());
            hit.collider.gameObject.SetActive(false);
            
        }
    }
    private IEnumerator freezeTime()
    {
        Time.timeScale = 0.4f;
        yield return new WaitForSeconds(1f);
        panel.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 1f;
    }
    private void OnDrawGizmos()
    {
        if (col != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(col.bounds.center, Vector2.right * distance);
        }
    }
}
