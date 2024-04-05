using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : Movement 
{
    protected override void ChildUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
    }
    private bool Occupied(Vector2 newDirection)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, newDirection, 1.5f, obstacleLayer);
        return hit.collider != null;
    }

    protected void SetDirection(Vector2 newDirection)
    {
        if (!Occupied(newDirection))
        {
            direction = newDirection;
            nextDirection = Vector2.zero;

        }
        else
        {
            nextDirection = newDirection;
        }

    }

    private void Update()
    {
        if (nextDirection != Vector2.zero)
        {
            SetDirection(nextDirection);
        }

        ChildUpdate();
    }
    

}


