using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
    public GameObject destination;
    public bool goingUp;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D collider)
    {
        Vector3 pos = collider.gameObject.transform.position;

        if (goingUp && collider.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y > 0
            || !goingUp && collider.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            pos.y = destination.transform.position.y;
            collider.gameObject.transform.position = pos;
        }
    }
}
