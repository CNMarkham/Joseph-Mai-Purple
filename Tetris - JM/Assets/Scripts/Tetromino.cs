using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float speed;
    public float previousTime;
    public float fallTime;
    public float tempTime;

    public static int height;
    public static int width;

    public Vector3 rotationPoint;

    // Start is called before the first frame update
    void Start()
    {
        fallTime = 0.8f;
        tempTime = fallTime;
        height = 20;
        width = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);//converts the position of the tetro to 0 0 0
            transform.RotateAround(convertedPoint, Vector3.forward, 90); //rotates the point of the converted point which is 0 0 0 90 degrees
            if (!ValidMove())//if the rotate is not valid than it will go the other way which cancels each other out to regular position
            {
                transform.RotateAround(convertedPoint, Vector3.forward, -90);//rotates the other way
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))// checks if the lefrt key is clicked
        {
            transform.position += Vector3.left;// moves to the left
            if (!ValidMove())// checks if the move is valid
            {
                transform.position += Vector3.right;// trabsforn to the right
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            if (!ValidMove())
            {
                transform.position += Vector3.left;
            }
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            tempTime = tempTime * 0.1f;
        }

        if (Time.time - previousTime > tempTime)
        {
            transform.position += Vector3.down;
            previousTime = Time.time;
        }
    }

    public bool ValidMove()
    {// checks if the block is outside of the grid than it will return false if it is inside it would return true
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);//checks the position of the blocks of the tetro
            int y = Mathf.RoundToInt(child.transform.position.y);

            if (x < 0 || y < 0)//checks if the x or y position is less than 0
            {
                return false;// if the position is less than 0 tha it will return false
            } else if(x >= width  || y >= height)// checks if the x and y position os greagter than the height and width of the box and if it is than reutrn false
            {
                return false;
            }
        }
         
        return true;//otherwise return true
    }
}