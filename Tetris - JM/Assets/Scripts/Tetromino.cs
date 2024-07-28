using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float speed;
    public float previousTime;
    public float fallTime;
    public float tempTime;

    public static int height = 20;
    public static int width = 10;
    public static Transform[,] grid = new Transform[width, height];

    public Vector3 rotationPoint;

    // Start is called before the first frame update
    void Start()
    {
        fallTime = 0.8f;
        tempTime = fallTime;

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

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            tempTime = tempTime * 0.9f;
        }

        if (Time.time - previousTime > tempTime)
        {
            transform.position += Vector3.down;
            previousTime = Time.time;
            if (!ValidMove())// checks if it is not possible to move down
            {
                transform.position += Vector3.up;
                AddToGrid();
                this.enabled = false;// disables the tetro
                FindObjectOfType<Spawner>().SpawnTetromino();// call the spawner from other script

            }
        }

        CheckLines();
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

            if (grid[x, y] != null)
            {
                return false;
            }
        }
         
        return true;//otherwise return true
    }

    public void AddToGrid()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);

            grid[x,y] = child;
        }
    }

    public void CheckLines()// checks for rows
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if(HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    public bool HasLine(int i)// checks if empty or not
    {
        for (int j=0; j < width; j++)
        {
            if(grid[j,i] == null)
            {
                return false;
            }
        }
        Debug.Log("Line made");
        return true;
    }
    public void DeleteLine(int i)// deletes the blocks from the row
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }
    public void RowDown(int i)// moves each row down one 
    {
        for (int y = i; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];//subtracts one from the y to move down and changes it to the regular grid
                    grid[x, y] = null;
                    grid[x, y - 1].transform.position += Vector3.down;
                }
            }
        }
    }
}