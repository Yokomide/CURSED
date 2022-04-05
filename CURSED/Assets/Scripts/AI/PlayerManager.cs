using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    public Animator animator;
    public bool isUsingRightHand;
    public bool isUsingLeftHand;
    private void Awake()
    {
        isUsingRightHand = animator.GetBool("isUsingRightHand");
        isUsingLeftHand = animator.GetBool("isUsingLeftHand");
    }

}
