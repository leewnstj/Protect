using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float RaycastDistance;
    [SerializeField] private float dashPower;
    [SerializeField] LayerMask layer;

    private Rigidbody2D rigid;
    private PlayerAnimation anim;

    private float localScale;
    private float inputX;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = transform.Find("VisualSprite").GetComponent<PlayerAnimation>();

        localScale = transform.localScale.x;
    }

    private void Update()
    {
        Jump();
        Move();
        Dash();
    }

    private void Move()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        if(inputX != 0)
        {
            transform.localScale = new Vector2(inputX * localScale, transform.localScale.y);
        }

        rigid.velocity = new Vector2(inputX * speed, rigid.velocity.y);
    }

    private void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, RaycastDistance, layer);

        if(hit && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
            anim.JumpAnim();
        }
    }

    private void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            rigid.velocity = Vector2.zero;
            rigid.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        }
    }
}
