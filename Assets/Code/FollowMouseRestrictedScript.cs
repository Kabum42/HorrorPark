using UnityEngine;
using System.Collections;

public class FollowMouseRestrictedScript : MonoBehaviour {

    //private Vector3 originGlobal;
	public GameObject eyeball;
    private Vector3 originLocal;
	private TrembleScript tremble;

	// Use this for initialization
	void Start () {

        //originGlobal = this.transform.position;
        originLocal = this.transform.localPosition;
		tremble = this.gameObject.AddComponent<TrembleScript> ();
		tremble.strength = 0.025f;
		tremble.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {

		if (Camera.main.gameObject.GetComponent<FattyScript> ().currentMode == "normal") {

			float aux = Mathf.Lerp (this.gameObject.transform.localScale.x, 1.5f, Time.deltaTime * 5f);
			this.gameObject.transform.localScale = new Vector3 (aux, aux, this.gameObject.transform.localScale.z);
			eyeball.GetComponent<SpriteRenderer> ().color = Color.Lerp (eyeball.GetComponent<SpriteRenderer> ().color, new Color (1f, 1f, 1f), Time.deltaTime * 5f);
			tremble.enabled = false;

		} else if (Camera.main.gameObject.GetComponent<FattyScript> ().currentMode == "blood") {

			float aux = Mathf.Lerp (this.gameObject.transform.localScale.x, 1f, Time.deltaTime * 5f);
			this.gameObject.transform.localScale = new Vector3 (aux, aux, this.gameObject.transform.localScale.z);
			eyeball.GetComponent<SpriteRenderer> ().color = Color.Lerp (eyeball.GetComponent<SpriteRenderer> ().color, new Color (1f, 0.85f, 0.85f), Time.deltaTime * 5f);
			tremble.enabled = true;

		} else if (Camera.main.gameObject.GetComponent<FattyScript> ().currentMode == "rainbow") {

			float aux = Mathf.Lerp (this.gameObject.transform.localScale.x, 3f, Time.deltaTime * 5f);
			this.gameObject.transform.localScale = new Vector3 (aux, aux, this.gameObject.transform.localScale.z);
			eyeball.GetComponent<SpriteRenderer> ().color = Color.Lerp (eyeball.GetComponent<SpriteRenderer> ().color, new Color (1f, 1f, 1f), Time.deltaTime * 5f);
			tremble.enabled = true;

		}

        //Vector3 target = Input.mousePosition;
        Vector3 target;


        if (GlobalData.grabbedObject != null)
        {
            target = GlobalData.grabbedObject.transform.position;

            Vector2 mouseIn2D = new Vector2(target.x, target.y);
            //Vector2 mouseIn2D = new Vector2(Camera.main.ScreenToWorldPoint(target).x, Camera.main.ScreenToWorldPoint(target).y);
            Vector2 aux = new Vector2(0f, 2f);

            if (mouseIn2D.y > 3f && Vector2.Distance(mouseIn2D, aux) < 8f && GlobalData.grabbedObject != null)
            {
                Vector3 mouseIn3DLocal = this.transform.InverseTransformPoint(new Vector3(mouseIn2D.x, mouseIn2D.y, 0f));
                Vector2 direction2 = new Vector2(mouseIn3DLocal.x, mouseIn3DLocal.y) - new Vector2(originLocal.x, originLocal.y);

                if (direction2.magnitude > 0.4f)
                {
                    direction2.Normalize();
                    direction2 *= 0.4f;
                }

                Vector3 targetLocalPosition = originLocal + new Vector3(direction2.x, direction2.y, 0f);

                if (targetLocalPosition.y < 0f)
                {
                    targetLocalPosition = new Vector3(targetLocalPosition.x, 0f, targetLocalPosition.z);
                }

                this.transform.localPosition = Hacks.LerpVector3(this.transform.localPosition, targetLocalPosition, Time.deltaTime * 10f);

            }
            else
            {
                this.transform.localPosition = Hacks.LerpVector3(this.transform.localPosition, originLocal + new Vector3(0f, 0.1f, 0f), Time.deltaTime * 5f);
            }
        }
        else
        {
            this.transform.localPosition = Hacks.LerpVector3(this.transform.localPosition, originLocal + new Vector3(0f, 0.1f, 0f), Time.deltaTime * 5f);
        }

        

        

	}
}
