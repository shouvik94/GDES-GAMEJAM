using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeDeath : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.CompareTag("Player")){
            gameManager.GameOver();
        }
    }
}
