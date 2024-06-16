using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)// to check collisiosn with characters
    {
        if(collision.gameObject.CompareTag("Player"))// checks collision with player
        {
             if(collision.transform.position.y > transform.position.y + 0.4f)// to check if the transformation of the goomba
                                                                             // is higher than the playerr or the player is
                                                                             // higher than the goomba

            {
                GetComponent<Animator>().SetTrigger("death");// sets the animation for the death
                GetComponent<CircleCollider2D>().enabled = false;// disabled the circle collider
                GetComponent<EnemyMovement>().enabled = false;// disables the movement
                Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();// makes the player jump up for a little big
                playerRB.velocity = new Vector2(playerRB.velocity.x, 10);

                Destroy(gameObject, 0.5f); // destroyed the goomba at a delay

            }
            else
            {
                collision.gameObject.GetComponent<PlayerBehaviour>().Hit();// calls the hit function for death in player if player is hit
            }
        }
    }
}
