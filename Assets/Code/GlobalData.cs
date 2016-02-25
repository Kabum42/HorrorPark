using UnityEngine;
using System.Collections;

public static class GlobalData {

    public static SpringJoint2D grabbedObjectSpringJoint;
    public static GameObject grabbedObject;
    public static Vector2 offset = new Vector2(0f, 0f);
    public static Vector3 lastMousePosition = new Vector2(0f, 0f);
    public static Vector3 lastMouseInertia = new Vector2(0f, 0f);
    public static int eatableObjects = 0;

}
