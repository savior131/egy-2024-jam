using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    float PlayerDashNextTime = 2f;
    bool canDash = true;
    bool isDashing;
    [SerializeField] float playerDashTime = 0.2f;
    [SerializeField] float playerDashSpeed = 10f;
    [SerializeField] TrailRenderer trail;
    [SerializeField] AudioSource dashSfx;
    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        trail.emitting = false;
        playerRigidBody = GetComponent<Rigidbody2D>();  
        playerAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        PlayerDash();
    }
    void PlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.K) && canDash)
        {
            dashSfx.Play();
            StartCoroutine(Dash());
        }

    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float playerOriginalGravity = playerRigidBody.gravityScale;
        playerRigidBody.gravityScale = 0f;
        playerAnimator.SetFloat("dash", 3f);
      //  playerAnimtor.SetTrigger("dash");
        playerRigidBody.velocity = new Vector2(transform.localScale.x * playerDashSpeed, playerRigidBody.velocity.y);
        trail.emitting = true;
        yield return new WaitForSeconds(playerDashTime);
        playerAnimator.SetFloat("dash", 1f);
        trail.emitting = false;
        playerRigidBody.gravityScale = playerOriginalGravity;
        isDashing = false;
        yield return new WaitForSeconds(PlayerDashNextTime);

        canDash = true;

    }
}
