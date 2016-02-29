using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour
{

	void OnMouseOver() {
		GlobalData.hoverObject = 2;
	}

    void OnMouseDown()
    {
        GlobalData.grabbedObject = this.gameObject;
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GlobalData.offset = new Vector2(mouseInWorld.x, mouseInWorld.y) - this.gameObject.GetComponent<Rigidbody2D>().position;
    }

    void OnMouseUp()
    {
        if (GlobalData.grabbedObject == this.gameObject)
        {
            Vector2 direction = new Vector2(GlobalData.lastMouseInertia.x, GlobalData.lastMouseInertia.y);
            if (direction.magnitude > 20f)
            {
                direction = direction.normalized * 20f;
            }
            GlobalData.grabbedObject.GetComponent<Rigidbody2D>().velocity = direction;
            GlobalData.grabbedObject = null;
        }
    }

}