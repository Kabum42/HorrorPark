using UnityEngine;
using System.Collections;

public class TrembleScript : MonoBehaviour {

    public float strength = 1f;
	
	// Update is called once per frame
	void FixedUpdate () {

		if (this.GetComponent<Rigidbody2D> () != null) {
			this.GetComponent<Rigidbody2D> ().MovePosition (this.GetComponent<Rigidbody2D> ().position + new Vector2 (Random.Range (-1f, 1f), Random.Range (-1f, 1f)) * strength);
		} else {
			this.transform.position =  this.transform.position + new Vector3 (Random.Range (-1f, 1f) * strength, Random.Range (-1f, 1f) * strength, 0f);
		}


	}
}
