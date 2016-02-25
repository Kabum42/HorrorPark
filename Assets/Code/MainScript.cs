using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GlobalData.grabbedObject != null) {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            if (Vector2.Distance(GlobalData.grabbedObject.GetComponent<Rigidbody2D>().position, new Vector2(worldPosition.x, worldPosition.y)) > 1f)
            {
                Vector2 direction = (new Vector2(worldPosition.x, worldPosition.y) - GlobalData.grabbedObject.GetComponent<Rigidbody2D>().position).normalized;
                GlobalData.grabbedObject.GetComponent<Rigidbody2D>().MovePosition(GlobalData.grabbedObject.GetComponent<Rigidbody2D>().position + direction * 1f);
            }
            else
            {
                GlobalData.grabbedObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(worldPosition.x, worldPosition.y));
            }
        }
	
	}
}
