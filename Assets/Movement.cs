using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;
    private bool isDashing = false;
    private float dashTimer;
    private float cooldownTimer;
    private Vector2 dash;
    public Rigidbody2D rb;
    private Vector2 move;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && cooldownTimer <= 0f)
        {
            StartDash();
        }

        if (isDashing)
        {
            UpdateDash();
        }

        if(cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
        ProccessInputs();
    }

    void StartDash()
    {
        isDashing = true;
        dashTimer = dashDuration;
        cooldownTimer = dashCooldown;
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        dash = new Vector2(moveX, moveY).normalized;
    }

    void UpdateDash()
    {
        if (dashTimer > 0f)
        {
            GetComponent<Rigidbody2D>().velocity = dash * dashSpeed;
            dashTimer -= Time.deltaTime;
        }
        else
        {
            isDashing = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        Move();
    }


    void ProccessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        move = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2 (move.x * moveSpeed, move.y * moveSpeed);
    }
}
