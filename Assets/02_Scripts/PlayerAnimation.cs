using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerController playerController;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void JumpAnim()
    {
        anim.SetTrigger("PlayerJump");
    }

    public void IdleAnim()
    {
        anim.SetTrigger("PlayerIdle");
    }
}
