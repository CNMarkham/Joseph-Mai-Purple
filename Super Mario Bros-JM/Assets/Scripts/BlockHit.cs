using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    public GameObject item;
    public int maxHits = -1;
    public Sprite emptyBlock;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();//gets the child of the object 
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Hit()
    {
        if(maxHits <= 0)//if maxHits is less or equal to 0 than return
        {
            return;
        }
        
        if(item != null)//checks if the item is there
        {
            Instantiate(item, transform); //spawns the item
            animator.SetTrigger("hit");//trigger hit on the block is hitable
            maxHits--;//changes max hits to decrease by 1
        }
        if(maxHits == 0)// checks if max hit is equal to 0
        {
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();//if it is than will change the sprite
            spriteRenderer.sprite = emptyBlock;//will change the empty block/s
        }
    }

}
