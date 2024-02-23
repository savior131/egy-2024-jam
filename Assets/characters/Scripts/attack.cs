using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField]private Transform swordTransform;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] AudioSource attackSfx;
    Collider2D col;
    Animator anim;
    int attackIDX=0;
    bool canAttack=true;

    int damage = 10;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)&&canAttack) 
        {
            attackSfx.Play();

            if(attackIDX==0)
            {
            anim.SetTrigger("attack");
                attackIDX = 1;
            }
            else
            {
                anim.SetTrigger("attack2");
                attackIDX = 0;
            }
            StartCoroutine(attackHold());
        }
    

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(swordTransform.position, radius);
    }
    IEnumerator attackHold()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.2f);
        col = Physics2D.OverlapCircle(swordTransform.position, radius, whatIsEnemy);
        if(col!=null)
        {
            //col.gameObject.SetActive(false
            col.GetComponent<EnemyPatrollingAI>().decreaseHealth(damage);
        }
        canAttack = true;
        yield return new WaitForSeconds(0.4f);
        attackIDX = 0;
    }
}
