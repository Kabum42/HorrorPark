using UnityEngine;
using System.Collections;
using System.Linq;
//using System;
//using System.Collections.Generic;

public class FattyScript : MonoBehaviour {

    private static float cooldownRespawnMax = 2f;
    private float cooldownRespawn = 0f;
    private Vector3 respawnLocation = new Vector3(-20f, -0.23f, -3f);

    private GameObject[] normalItems;
    private GameObject[] creepyItems;

    public SpringJoint2D fattyJawSpring1;
    public SpringJoint2D fattyJawSpring2;
    public SpringJoint2D fattyJawSpring3;
    public SpringJoint2D fattyJawSpring4;
    public GameObject fatController;

    public AnimationCurve vomitAmount;

    private float deformation = 1f;
    private Vector2 targetFatScale = new Vector2(0f, 0f);

    private static float maxFat = 1.3f;

	// Use this for initialization
	void Start () {

        targetFatScale = new Vector2(fatController.transform.localScale.x, fatController.transform.localScale.y);
        deformation = 1f;
        normalItems = Resources.LoadAll<GameObject>("Sprites/Fatty/Items/Prefabs/Normal");
        creepyItems = Resources.LoadAll<GameObject>("Sprites/Fatty/Items/Prefabs/Creepy");
        GlobalData.lastMousePosition = Input.mousePosition;

	}

    public void AddFat()
    {
        deformation = 1.2f;
        targetFatScale = new Vector2(Mathf.Clamp(fatController.transform.localScale.x*1.05f, 0f, maxFat), Mathf.Clamp(fatController.transform.localScale.y*1.05f, 0f, maxFat));
    }

    
    void FixedUpdate()
    {

        if (GlobalData.grabbedObject != null)
        {
            GlobalData.grabbedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            Vector2 targetPosition = GlobalData.grabbedObject.GetComponent<Rigidbody2D>().position;

            
            if (Vector2.Distance(GlobalData.grabbedObject.GetComponent<Rigidbody2D>().position, new Vector2(worldPosition.x, worldPosition.y)) > 0.7f)
            {
                Vector2 direction = (new Vector2(worldPosition.x, worldPosition.y) - GlobalData.grabbedObject.GetComponent<Rigidbody2D>().position).normalized;
                targetPosition = GlobalData.grabbedObject.GetComponent<Rigidbody2D>().position + direction * 0.7f;
            }
            else
            {
                targetPosition = new Vector2(worldPosition.x, worldPosition.y);
            }
            

            GlobalData.grabbedObject.GetComponent<Rigidbody2D>().MovePosition(targetPosition);

        }

        GlobalData.lastMouseInertia = GlobalData.lastMouseInertia*0.9f + (Input.mousePosition - GlobalData.lastMousePosition)*0.1f;
        GlobalData.lastMousePosition = Input.mousePosition;

    }
    
	
	// Update is called once per frame
	void Update () {

        CheckRespawn();

        UpdateFat();

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fattyJawSpring1.enabled)
            {
                OpenMouth();
            }
            else
            {
                CloseMouth();
            }
        }
        */

        if (GlobalData.eatableObjects > 0 && fattyJawSpring1.enabled)
        {
            OpenMouth();
        }
        else if (GlobalData.eatableObjects == 0 && !fattyJawSpring1.enabled)
        {
            CloseMouth();
        }

	}

    void UpdateFat()
    {
        if (deformation > 1f)
        {
            if (fatController.transform.localScale.x >= targetFatScale.x)
            {
                deformation = Mathf.Lerp(deformation, 0.99f, Time.deltaTime * 10f);
                if (deformation <= 1f) { deformation = 1f; }
            }

            float scaleX = Mathf.Lerp(fatController.transform.localScale.x, targetFatScale.x*deformation, Time.deltaTime*10f);
            float scaleY = Mathf.Lerp(fatController.transform.localScale.y, targetFatScale.y * deformation, Time.deltaTime*10f);
            fatController.transform.localScale = new Vector3(scaleX, scaleY, fatController.transform.localScale.z);
        }
    }

    void OpenMouth()
    {
        fattyJawSpring1.enabled = false;
        fattyJawSpring2.enabled = false;
        fattyJawSpring3.enabled = false;
        fattyJawSpring4.enabled = false;
    }

    void CloseMouth()
    {
        fattyJawSpring1.enabled = true;
        fattyJawSpring2.enabled = true;
        fattyJawSpring3.enabled = true;
        fattyJawSpring4.enabled = true;
    }

    void CheckRespawn()
    {

        cooldownRespawn -= Time.deltaTime;

        if (cooldownRespawn <= 0f)
        {
            cooldownRespawn = cooldownRespawnMax;
            GameObject g = Instantiate(normalItems[Random.Range(0, normalItems.Length)]);
            g.transform.position = respawnLocation;
        }

    }

}
