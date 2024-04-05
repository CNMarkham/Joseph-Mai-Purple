using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public float speed;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;

    protected Rigidbody2D rb;
    protected Vector2 direction;
    protected Vector2 nextDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(position + translation);
    }
    abstract protected void ChildUpdate();
}
