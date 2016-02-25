using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

    public bool digested = false;
    public float letGo = 0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update()
    {
        if (letGo > 0f)
        {
            letGo -= Time.deltaTime;
            if (letGo <= 0f)
            {
                letGo = 0f;
                GlobalData.grabbedObject = null;
            }
        }

        if (digested && this.transform.position.y < -1.5f)
        {
            if (this.transform.position.x > -2f && this.transform.position.x < 2f) {
                Destroy(this.gameObject);
                Camera.main.gameObject.GetComponent<FattyScript>().AddFat();
            }
            else {
                this.gameObject.layer = LayerMask.NameToLayer("Default");
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -3f);
                digested = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Gordo_Head" && GlobalData.grabbedObject == this.gameObject /* && GlobalData.lastMouseDifference.magnitude > 5f*/)
        {
            letGo = 0.05f;
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!digested && this.gameObject.layer == LayerMask.NameToLayer("Default") && other.gameObject.layer == LayerMask.NameToLayer("EatableTrigger"))
        {
            this.gameObject.layer = LayerMask.NameToLayer("Eatable");
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -0.5f);
            GlobalData.eatableObjects++;
            //this.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
        }
        else if (!digested && this.gameObject.layer == LayerMask.NameToLayer("Eatable") && other.gameObject.layer == LayerMask.NameToLayer("DigestTrigger"))
        {
            if (GlobalData.grabbedObject == this.gameObject)
            {
                GlobalData.grabbedObject = null;
            }
            digested = true;
            GlobalData.eatableObjects--;
        }
    }
    

    void OnTriggerExit2D(Collider2D other)
    {
        if (!digested && this.gameObject.layer == LayerMask.NameToLayer("Eatable") && other.gameObject.layer == LayerMask.NameToLayer("EatableTrigger"))
        {
            this.gameObject.layer = LayerMask.NameToLayer("Default");
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -3f);
            GlobalData.eatableObjects--;
            //this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        }
    }
    

}
