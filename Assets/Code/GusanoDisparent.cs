using UnityEngine;
using System.Collections;

public class GusanoDisparent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (this.gameObject.transform.parent != null && this.GetComponent<HingeJoint2D>() == null)
        {
            this.gameObject.transform.parent = null;
            //Hacks.SetLayerRecursively(this.gameObject, LayerMask.NameToLayer("Default"));
            this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
			//this.gameObject.layer = LayerMask.NameToLayer("Default");
			ItemScript i = this.gameObject.AddComponent<ItemScript> ();
        }
	
	}
}
