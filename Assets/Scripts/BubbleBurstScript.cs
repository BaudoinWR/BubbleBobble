using UnityEngine;
using System.Collections;

public class BubbleBurstScript : MonoBehaviour {
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Burst()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
