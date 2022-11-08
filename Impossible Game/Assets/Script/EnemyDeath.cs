using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Destroy (gameObject);
        }
    }
}
