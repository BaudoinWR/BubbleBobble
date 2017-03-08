using UnityEngine;
using System.Collections;

public class BubbleInterractScript : MonoBehaviour {
    public float pushForce = 0.1f;
    public bool canPop = false;
    public bool stopsFire = false;
    public bool invertsPush = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("BubbleFullTag"))
        {
            if (collider.gameObject.CompareTag("BrickTag"))
            {
                return;
            }
                Vector3 move;
            if (collider.transform.position.x < transform.position.x)
            {
                if (!invertsPush)
                {
                    move = Vector3.left;
                }
                else
                {
                    move = Vector3.right;
                }
            }
            else
            {
                if (invertsPush)
                {
                    move = Vector3.left;
                }
                else
                {
                    move = Vector3.right;
                }
            }
            collider.gameObject.transform.position += move * pushForce;
            move = (collider.transform.position.y < transform.position.y) ? Vector3.down : Vector3.up;
            collider.gameObject.transform.position += move * collider.GetComponent<BubbleScript>().speedFull * Time.deltaTime;
        }
        if (canPop && collider.gameObject.CompareTag("BubbleBurstTag"))
        {
            collider.gameObject.GetComponent<BubbleBurstScript>().Burst();
        }
        if (stopsFire && collider.gameObject.CompareTag("BubbleFireTag"))
        {
            Vector3 move = (collider.transform.position.x < transform.position.x) ? Vector3.left : Vector3.right;
            collider.gameObject.transform.position += move * collider.GetComponent<BubbleScript>().speedFiring * Time.deltaTime;

        }
    }

}
