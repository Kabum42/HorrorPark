using UnityEngine;
using System.Collections;

public class SpawnGusano : MonoBehaviour {
	public GameObject source;
	public HingeJoint2D hinge;
	private float time;
	private int ammo;
	[Range(0f,10f)]
	public int maxParticles;
	[Range(0f,5f)]
	public float cadenceParticles;
	[Range(0f,200f)]
	public float breakForceParticles;
	[Range(0f,10f)]
	public int initialParticles;
	[Range(0f,10f)]
	public int amountGusanos;

	// Use this for initialization
	void Start () {
		time = 0f;
		ammo = maxParticles;

		for (int i = 0; i < amountGusanos; i++) {

			GameObject newGameObject = Instantiate(source);            
			newGameObject.transform.parent = this.transform;
			newGameObject.transform.localPosition = Vector3.zero;
			newGameObject.SetActive(true);
		}

		for (int i = 0; i < initialParticles; i++) {

			GameObject newGameObject = Instantiate(source);            
			newGameObject.transform.parent = this.transform;
			newGameObject.transform.localPosition = Vector3.zero;

			HingeJoint2D newHingeJoint2D = newGameObject.GetComponent<HingeJoint2D> ();
			HingeJoint2D auxHinge = newHingeJoint2D;
			auxHinge.breakForce = breakForceParticles;
			newHingeJoint2D = auxHinge;

			newGameObject.SetActive(true);
		}


	}

	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;
		if ( time > cadenceParticles && ammo > 0 ) {

			GameObject newGameObject = Instantiate(source);            
			newGameObject.transform.parent = this.transform;
			newGameObject.transform.localPosition = Vector3.zero;

            HingeJoint2D newHingeJoint2D = newGameObject.GetComponent<HingeJoint2D>();
            HingeJoint2D auxHinge = newHingeJoint2D;
            auxHinge.breakForce = breakForceParticles;
            newHingeJoint2D = auxHinge;

			newGameObject.SetActive (true);

			ammo = ammo - 1; 
			time = 0f;

		}

	}
}
