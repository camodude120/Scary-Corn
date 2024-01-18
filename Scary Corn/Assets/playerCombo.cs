using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombo : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            if (!playerVariable.isJumping)
            {
                if (!playerVariable.isHitting[0] && !playerVariable.isHitting[1] && !playerVariable.isHitting[2])
                {
                    playerVariable.isHitting[0] = true;
                }
                else if (playerVariable.isHitting[0])
                {
                    playerVariable.isHitting[1] = true;
                    playerVariable.isHitting[0] = false;
                }
                else if (playerVariable.isHitting[1])
                {
                    playerVariable.isHitting[2] = true;
                    playerVariable.isHitting[1] = false;
                }
                else
                {
                    playerVariable.isHitting[2] = false;
                }

            }
        }



    }
}
