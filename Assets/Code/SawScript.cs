using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SawScript : MonoBehaviour {

    public List<SawingObject> currentSawingObjects = new List<SawingObject>();
    public static float timeToSaw = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        List<SawingObject> toErase = new List<SawingObject>();

        Vector3 direction = new Vector3(1f, -1f, 0f);
        direction.Normalize();

        foreach (SawingObject sO in currentSawingObjects)
	    {
	        sO.sawingProcess += Time.deltaTime * (1f / timeToSaw);

			if (sO.sawingProcess <= 1f && sO.root != null) {

                sO.root.transform.position = sO.origin + sO.sawingProcess * direction * 4f + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0f);

            }
            else {

                toErase.Add(sO);

            }
	    }

        foreach (SawingObject sO in toErase)
        {
            currentSawingObjects.Remove(sO);
            Destroy(sO.root);
        }

		toErase.Clear ();
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<ItemScript>() != null)
        {
            if (GlobalData.grabbedObject == other.gameObject)
            {
                GlobalData.grabbedObject = null;
            }
            SawingObject sO = new SawingObject(other.gameObject);
			//if (sO.root.GetComponent<Gusano> ()) { Destroy(sO.root.GetComponent<Gusano>()); }
			//if (sO.root.GetComponent<HingeJoint2D> ()) { Destroy(sO.root.GetComponent<HingeJoint2D>()); }
			//if (sO.root.GetComponent<SpringJoint2D> ()) { Destroy(sO.root.GetComponent<SpringJoint2D>()); }
            Destroy(sO.root.GetComponent<Collider2D>());
            //Destroy(sO.root.GetComponent<Rigidbody2D>());
            currentSawingObjects.Add(sO);
        }
        
    }

    public class SawingObject
    {

        public GameObject root;
        public float sawingProcess = 0;
        public Vector3 origin;

        public SawingObject(GameObject auxRoot)
        {
            root = auxRoot;
            sawingProcess = 0f;
            origin = root.transform.position;
        }

    }

}
