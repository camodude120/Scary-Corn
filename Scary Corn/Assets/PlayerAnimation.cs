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

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerVariable.isWalking && !playerVariable.isJumping)
        {
            PlayAnimation(playerWalk);
        }
        else if(!playerVariable.isWalking && !playerVariable.isJumping)
        {
            PlayAnimation(playerIdle);
        }
        else if (playerVariable.isJumping)
        {
            PlayAnimation(playerJump);
        }
    }

    public void PlayAnimation(string newState)
    {
        if (currentState == newState) return;
        playerAnimator.Play(newState);
        currentState = newState;
    }

}
