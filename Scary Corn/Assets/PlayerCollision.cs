using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public GameObject DeathExplosion;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weakpoint")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Popped")
        {
            Dead();
        }
    }

    private void Dead()
    {
        Instantiate(DeathExplosion, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }



}
