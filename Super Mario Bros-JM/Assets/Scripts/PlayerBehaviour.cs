using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public SpriteRenderer smallRenderer;
    public SpriteRenderer bigRenderer;
    private Animator smallAnimator;
    public bool big;
    // Start is called before the first frame update
    private void Start()
    {
        smallAnimator = smallRenderer.gameObject.GetComponent<Animator>(); // gets a reference of small animator to the small renderer
        big = false;// sets big to false
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit() // if its big and it gets hit than it will shrink, othrwise it would be small and die.
    {
        if(big)
        {
            Shrink();
        } else
        {
            Death();
        }
    }

    private void Shrink()// will shrink and make sure the sprite renderer is correct and not wrong
    {
        smallRenderer.enabled = true;
        bigRenderer.enabled = false;

        GetComponent<CapsuleCollider2D>().size = Vector2.one;
        GetComponent<CapsuleCollider2D>().offset = Vector2.zero;

        big = false;
        StartCoroutine("ChangeSize");// creates a coroutine when changing size
    }

    public void Grow() // if its big than it would enable the big renderer and startthe couritine for the big prefab
    {
        if(big)
        {
            return;
        }

        smallRenderer.enabled = false;
        bigRenderer.enabled = true;

        GetComponent<CapsuleCollider2D>().size = new Vector2(1f, 2f);
        GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.5f);

        big = true;
        StartCoroutine("ChaneSize");
    }

    private void Death()// will cause the characvter to not able to move and play the animation for death and will destroy the object.
    {
        smallAnimator.SetTrigger("death");

        GetComponent<CapsuleCollider2D>().enabled = false;

        GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
        GetComponent<PlayerMovement>().enabled = false;
        Destroy(gameObject, 0.5f);
    }
    private IEnumerator ChangeSize() // IEnumerator will be red untill something is added // also sets it so it has a couroutine to redo after one run.
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 velocity = rb.velocity;

        for (int i = 0; i < 8; i++) // will loop back from the big to small and ends on the opposite of the sprite right now
        {
            bigRenderer.enabled ^= true;// ^= means to the power of
            smallRenderer.enabled ^= true;
            yield return new WaitForSeconds(0.25f);// will pause a squater of a second before switches
        }

        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        


    }
}
