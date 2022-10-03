using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollison : MonoBehaviour
{
    public playerMovement movement;

    
    
    public void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Enemy")
        {
            // Two ways to do this first one is commented
            // movement.enabled = false;
           // GetComponent<playerMovement>().enabled = false;
             FindObjectOfType<GameManager>().Endgame();
          // FindObjectOfType<GameManager>().Restart();

          
        }
        // The below code does not work 
        /*if (collisionInfo.GetComponent<playerMovement>() != null)
           { collisionInfo.transform.position = collisionInfo.FindObjectOfType<playerMovement>().startPos;}
           */ 

        
        
    }
}
