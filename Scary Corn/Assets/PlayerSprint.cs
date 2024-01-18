using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    public float totalStamina;
    public float stamina;
    public GameObject staminaBar;

    // Start is called before the first frame update
    void Awake()
    {
        stamina = totalStamina;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            playerVariable.isSprinting = true;
            stamina -= 0.5f;
        }
        else
        {
            playerVariable.isSprinting = false;
        }

        if (stamina < 100 && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += 0.25f;
        }
        if (staminaBar != null)
        {
            staminaBar.transform.localScale = new Vector2 (stamina / totalStamina, staminaBar.transform.localScale.y);
        }
    }
}
