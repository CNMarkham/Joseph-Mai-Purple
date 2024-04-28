using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Movement
{
    public GameObject body;
    public GameObject eyes;
    public GameObject blue;
    public GameObject white;
    public bool atHome;
    public float homeDuration;
    public bool frightened;
    protected override void ChildUpdate()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            SetDirection(node.availableDirections[index]);
        }
    }

   private void LeaveHome()
    {

    }

    private void Awake()
    {
        
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public void Frighten()
    {

    }

    private void Flash()
    {

    }

    private void Reset()
    {
        
    }

}
