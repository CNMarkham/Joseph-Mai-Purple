using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetrominoes;// creates a array // arrays start counting at 0
    // Start is called before the first frame update
    void Start()
    {
        SpawnTetromino();
    }
    public void SpawnTetromino()
    {
        int randNum = Random.Range(0, tetrominoes.Length);//finds a tetromino by the tetrominoes added in the brackets from 0 to 7
        GameObject randomTetromino = tetrominoes[randNum];//gets a random tetromino from the array
        Instantiate(randomTetromino, transform.position, Quaternion.identity);
        return;
    }
}
