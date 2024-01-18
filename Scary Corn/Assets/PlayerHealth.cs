using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float totalHp;
    public float HP;
    public GameObject hpBar;

    // Start is called before the first frame update
    void Start()
    {
        HP = totalHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hpBar != null)
        {
            hpBar.transform.localScale = new Vector2(HP / totalHp, hpBar.transform.localScale.y);
        }
    }
}
