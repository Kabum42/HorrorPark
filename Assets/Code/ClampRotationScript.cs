using UnityEngine;
using System.Collections;

public class ClampRotationScript : MonoBehaviour {

    public float minZ;
    public float maxZ;

	// Use this for initialization
	
	// Update is called once per frame
	void FixedUpdate () {

        if (this.transform.eulerAngles.z < minZ && this.transform.eulerAngles.z > (minZ + maxZ) / 2f)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, minZ);
        }
        else if (this.transform.eulerAngles.z > maxZ && this.transform.eulerAngles.z <= (minZ + maxZ) / 2f)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, maxZ);
        }

        //this.transform.eulerAngles = new Vector3(Mathf.Clamp(this.transform.eulerAngles.x, minRotation.x, maxRotation.x), Mathf.Clamp(this.transform.eulerAngles.y, minRotation.y, maxRotation.y), Mathf.Clamp(this.transform.eulerAngles.z, minRotation.z, maxRotation.z));

	}
}
