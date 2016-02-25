using UnityEngine;
using System.Collections;

public class SpawnGusano : MonoBehaviour {
	public GameObject source;
	public SpringJoint2D spring;
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

			SpringJoint2D newSpringJoint2D = newGameObject.GetComponent<SpringJoint2D> ();
			SpringJoint2D auxSpring = newSpringJoint2D;
			auxSpring.breakForce = breakForceParticles;
			newSpringJoint2D = auxSpring;

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

			SpringJoint2D newSpringJoint2D = newGameObject.GetComponent<SpringJoint2D> ();
			SpringJoint2D auxSpring = newSpringJoint2D;
			auxSpring.breakForce = breakForceParticles;
			newSpringJoint2D = auxSpring;

			newGameObject.SetActive (true);

			ammo = ammo - 1; 
			time = 0f;

		}

	}
}
