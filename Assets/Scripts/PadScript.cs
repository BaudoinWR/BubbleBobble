using UnityEngine;
using System.Collections;

public class PadScript : MonoBehaviour {
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckTouch (string tag) {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint((Input.GetTouch(i).position)), Vector2.zero);
                if (hits != null)
                {
                    foreach (RaycastHit2D hit in hits)
                    {
                        if (hit.collider.gameObject.CompareTag(tag))
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }


}
