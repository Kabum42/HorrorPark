using UnityEngine;
using System.Collections;

public class Gusano : MonoBehaviour {

	public HingeJoint2D hinge;
	private bool settedMinMax = false;
	private Vector2 minMax = new Vector2 (0f, 0f);

	// Use this for initialization
	void Start () {

		minMax = new Vector2 (hinge.limits.min, hinge.limits.max);
		float rand = Random.Range (hinge.limits.min, hinge.limits.max);

		JointAngleLimits2D newLimits = hinge.limits;
		newLimits.min = rand;
		newLimits.max = rand;
		hinge.limits = newLimits;


	}
	
	// Update is called once per frame
	void Update () {

		if (!settedMinMax) {
			
			settedMinMax = true;
			JointAngleLimits2D newLimits = hinge.limits;
			newLimits.min = minMax.x;
			newLimits.max = minMax.y;
			hinge.limits = newLimits;

		}

		if (hinge.jointAngle >= hinge.limits.max) {
			
			JointMotor2D newMotor = hinge.motor;
			newMotor.motorSpeed = -Mathf.Abs(newMotor.motorSpeed);
			hinge.motor = newMotor;

			JointAngleLimits2D newLimits = hinge.limits;
			newLimits.min = -Random.Range(0f, 60f);
			hinge.limits = newLimits;

		} else if (hinge.jointAngle <= hinge.limits.min) {
			
			JointMotor2D newMotor = hinge.motor;
			newMotor.motorSpeed = Mathf.Abs(newMotor.motorSpeed);
			hinge.motor = newMotor;

			JointAngleLimits2D newLimits = hinge.limits;
			newLimits.max = Random.Range(0f, 60f);
			hinge.limits = newLimits;

		}
	
	}
}
