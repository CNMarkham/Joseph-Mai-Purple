using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction = Vector2.left;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // makes a rigid body for the enemies
    }
    private void OnBecameVisible() // when it is visible
    {
        rb.velocity = direction * speed; // sets velocity for the enemies
    }
}
