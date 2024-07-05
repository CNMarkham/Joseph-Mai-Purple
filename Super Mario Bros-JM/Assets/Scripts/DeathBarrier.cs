using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//if it is triggered
    {
       if(collision.gameObject.CompareTag("Player"))//if it collides with mario
       {
            collision.gameObject.GetComponent<PlayerBehaviour>().Hit();//if it is the mario than call hit
       }
       else //otherwise
       {
            Destroy(collision.gameObject);//destroys the other objects
       }
    }
}
