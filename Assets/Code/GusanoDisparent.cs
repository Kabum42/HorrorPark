using UnityEngine;
using System.Collections;

public class GusanoDisparent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (this.gameObject.transform.parent != null && this.GetComponent<SpringJoint2D>() == null)
        {
            this.gameObject.AddComponent<DestructibleScript>();
            this.gameObject.transform.parent = null;
        }
	
	}
}
