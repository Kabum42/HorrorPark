using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	public bool addFat = false;
    public bool bloody = false;
	public bool rainbow = false;
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

				if (addFat)
				{
					Camera.main.gameObject.GetComponent<FattyScript> ().AddFat();
					AudioSource aS = Camera.main.gameObject.GetComponent<FattyScript> ().GetUnusedAudioSource ();
					aS.clip = Resources.Load("Sound/Gulp") as AudioClip;
					aS.pitch = Random.Range (0.8f, 1.2f);
					aS.Play ();
				}
                if (bloody)
                {
                    Camera.main.gameObject.GetComponent<FattyScript>().Blood();
					AudioSource aS = Camera.main.gameObject.GetComponent<FattyScript> ().GetUnusedAudioSource ();
					aS.clip = Resources.Load("Sound/Knife") as AudioClip;
					aS.pitch = Random.Range (0.7f, 0.9f);
					aS.Play ();
                }
				if (rainbow)
				{
					Camera.main.gameObject.GetComponent<FattyScript> ().Rainbow();
				}

                
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
			if (GlobalData.eatableObjects < 0) {
				GlobalData.eatableObjects = 0;
			}
        }
    }
    

    void OnTriggerExit2D(Collider2D other)
    {
        if (!digested && this.gameObject.layer == LayerMask.NameToLayer("Eatable") && other.gameObject.layer == LayerMask.NameToLayer("EatableTrigger"))
        {
            this.gameObject.layer = LayerMask.NameToLayer("Default");
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -3f);
            GlobalData.eatableObjects--;
			if (GlobalData.eatableObjects < 0) {
				GlobalData.eatableObjects = 0;
			}
            //this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        }
    }
    

}
