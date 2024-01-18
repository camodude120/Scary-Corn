using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAnimation : MonoBehaviour
{

    private Animator playerAnimator;

    public string currentState;
    public string playerIdle = "playerIdle";
    public string playerWalk = "playerWalk";
    public string playerJump = "playerJump";
    public string playerHit1 = "playerHit1";
    public string playerHit2 = "playerHit2";
    public string playerHit3 = "playerHit3";

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }


    void NextHit()
    {
        for (int i = 0; i < playerVariable.isHitting.Length - 1; i++)
        {
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("playerHit" + (i + 1).ToString()) && playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                playerVariable.isHitting[i] = false;
                if (playerVariable.isHitting[i + 1])
                {
                    PlayAnimation("playerHit" + (i + 2).ToString());
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        NextHit();

        if(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(playerHit3) && playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            playerVariable.isHitting[2] = false;
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(playerJump))
        {
            playerVariable.isHitting[0] = false;
            playerVariable.isHitting[1] = false;
            playerVariable.isHitting[2] = false;
        }

        if(playerVariable.isWalking && !playerVariable.isJumping && !playerVariable.isHitting[0] && !playerVariable.isHitting[1] && !playerVariable.isHitting[2])
        {
            PlayAnimation(playerWalk);
        }
        else if(!playerVariable.isWalking && !playerVariable.isJumping && !playerVariable.isHitting[0] && !playerVariable.isHitting[1] && !playerVariable.isHitting[2])
        {
            PlayAnimation(playerIdle);
        }
        else if (playerVariable.isJumping)
        {
            PlayAnimation(playerJump);
        }
        else if (playerVariable.isHitting[0] && !playerVariable.isHitting[1] && !playerVariable.isHitting[2])
        {
            PlayAnimation(playerHit1);
        }
    }

    public void PlayAnimation(string newState)
    {
        if (currentState == newState) return;
        playerAnimator.Play(newState);
        currentState = newState;
    }

}
