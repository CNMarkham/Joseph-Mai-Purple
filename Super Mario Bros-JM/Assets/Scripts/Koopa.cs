using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    private bool shelled;
    private bool shellMoving;
    public float shellSpeed = 15;
    // Start is called before the first frame update
    void Start()
    {
        shelled = false;// sets shelled to false
        shellMoving = false;// sets the shell moving to false
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)// checks collision
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (collision.transform.position.y > transform.position.y + 0.4f)//checks if the position of the koopa is higher than the original position
        {
            if (shelled)//if shelled than launch
            {
                Launch();
            }
            else //otherwise set to the shelled form
            {
                GetComponent<Animator>().SetTrigger("shell");//sets to the shell animator
                GetComponent<EnemyMovement>().speed = 0;//sets the speed of the enemy movement to 0
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;// gets a rigid body for the velocity
                shelled = true;// sets shelled to true
            }
        }
        else if (shelled && !shellMoving) // if it is shelled and it is not moving than call launch 
        {
            Launch();
        }
        else//otherwise it will call hit and destroy the koopa
        {
            collision.gameObject.GetComponent<PlayerBehaviour>().Hit();
        }

        Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();//makes it so it can bounce
        playerRB.velocity = new Vector2(playerRB.velocity.x, 10);// changes the velocity by a bit
    }
    private void Launch()
    {
        GetComponent<EnemyMovement>().speed = 15;//sets a speed so the koopa can move
        GetComponent<Rigidbody2D>().velocity = Vector3.right * 15;// changes the velocity of the movement
        shellMoving = true;
    }
}
