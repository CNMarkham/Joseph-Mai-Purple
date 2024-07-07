using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float speed;
    public float previousTime;
    public float fallTime;
    public float tempTime;

    // Start is called before the first frame update
    void Start()
    {
        fallTime = 0.8f;
        tempTime = fallTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right);
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            tempTime = tempTime * 0.1f;
        }

        if (Time.time - previousTime > tempTime)
        {
            transform.Translate(Vector3.down);
            previousTime = Time.time;
        }
    }
}