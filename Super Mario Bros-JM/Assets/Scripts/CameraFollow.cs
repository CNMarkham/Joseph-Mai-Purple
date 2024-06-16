using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;// tracks the player

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z); //  will track the player position with x y andz
        }
    }
}
