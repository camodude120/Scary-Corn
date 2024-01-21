using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTeleport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleport"))
        {
            Debug.Log("Away we go!");
        }
    }
}
