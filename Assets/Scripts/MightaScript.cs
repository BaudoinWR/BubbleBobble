using UnityEngine;
using System.Collections;

public class MightaScript : ZenChanScript
{
    // Use this for initialization
    void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void FixedUpdate()
    {
        Vector3 position = transform.position;
        animator.SetBool("shooting", false);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.y != 0)
        {
            return;
        }
        float r = Random.Range(0, jumpRate);
        if (r > jumpRate - 1)
        {
            animator.SetBool("shooting", true);
            return;
        }
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("shoot"))
        {
            base.FixedUpdate();
        }
    }
}
