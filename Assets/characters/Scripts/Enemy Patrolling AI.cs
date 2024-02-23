using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrollingAI : MonoBehaviour
{
    [SerializeField] float enemyRange;
    [SerializeField] float speed;
    [SerializeField] float detectionDistance;
    [SerializeField] float AttackDistance;
    enum Type { Enemy1, Enemy2, Enemy3 };
    [SerializeField] Type enemyType;
    Transform player;
    Animator anim;
    //[SerializeField] UnityEvent attack;
    Rigidbody2D rb;
    
    float initPositionX;
    float[] points=new float[2];
    int pointIndex;
    bool inSight;
    bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initPositionX = transform.position.x;
        points[0] = initPositionX+enemyRange;
        points[1] = initPositionX-enemyRange;
        pointIndex=Random.Range(0,points.Length);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim=GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("velocity",Mathf.Abs(rb.velocity.x));
        if (!inSight)
        Patrol();
        if (attacking) return;
        Flip();
        FollowPlayer();

    }
    private void OnDisable()
    {
        Rock.enemeybeaten=true;
    }

    private void Patrol()
    {
        if (Mathf.Abs(transform.position.x - points[pointIndex])<0.1f)
        {
            pointIndex=(pointIndex+1) % 2;
        }
        float dir= points[pointIndex]-transform.position.x;
        if (dir > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(- speed, rb.velocity.y);
        }

    }
    private void Flip()
    {
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }
    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) <= AttackDistance)
        {
            if (!attacking)
            {
                switch (enemyType)
                {
                    case Type.Enemy1:
                        enemy13();
                        break;
                    case Type.Enemy2:
                        enemy2();
                        break;
                    case Type.Enemy3:
                        enemy13();
                        break;

                }
            }
            
        }
        else if (Vector2.Distance(transform.position, player.position) <= detectionDistance)
        {
            inSight = true;
            float dir = player.position.x - transform.position.x;
            if (dir > 0)
            {
                rb.velocity = new Vector2(speed*1.2f, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed* 1.2f, rb.velocity.y);
            }
        }
        else
        {
            inSight = false;
        }
    }
    private void enemy13()
    {
        StartCoroutine(Attack());
        anim.SetTrigger("attack");
    }
    IEnumerator Attack()
    {
        attacking = true;
        yield return new WaitForSeconds(2f);
        attacking = false;
    }
    private void enemy2()
    {
        StartCoroutine(Attack());
        anim.SetTrigger("jump");
        Vector2 direction = new Vector2(transform.localScale.x*15,12 );
        rb.velocity=direction;
    }
}
