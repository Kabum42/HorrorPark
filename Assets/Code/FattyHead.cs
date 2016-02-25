using UnityEngine;
using System.Collections;

public class FattyHead : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (GlobalData.grabbedObject == coll.gameObject) {
            GlobalData.grabbedObject = null;
        }
    }

}
