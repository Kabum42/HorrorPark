using UnityEngine;
using System.Collections;

public class CustomAreaEffector2D : MonoBehaviour {

    public float velocityX = 3f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Rigidbody2D>() != null && !other.gameObject.GetComponent<Rigidbody2D>().isKinematic)
        {
            Vector2 velocity = other.gameObject.GetComponent<Rigidbody2D>().velocity;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocity.y);
        }
    }

}
