using UnityEngine;
using System.Collections;

public class MouseIconScript : MonoBehaviour {

	public GameObject mouseNormal;
	public GameObject mouseHover;
	public GameObject mouseGrabbed;

	// Use this for initialization
	void Start () {
	
		//Cursor.visible = false;
		mouseHover.SetActive (false);
		mouseGrabbed.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {

		mouseNormal.SetActive (false);
		mouseHover.SetActive (false);
		mouseGrabbed.SetActive (false);

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		this.transform.position = new Vector3 (mousePosition.x, mousePosition.y, this.transform.position.z);

		if (GlobalData.grabbedObject != null) {
			mouseGrabbed.SetActive (true);
		} else if (GlobalData.hoverObject > 0) {
			mouseHover.SetActive (true);
		} else {
			mouseNormal.SetActive (true);
		}
	
	}
}
