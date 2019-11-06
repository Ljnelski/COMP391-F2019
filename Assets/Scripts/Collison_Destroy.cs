using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison_Destroy : MonoBehaviour
{
    //public var
    public GameObject explosion;

    //private var
        
    void OnCollisionEnter2D(Collision2D other) //If there is a collison with another rigid body
    {
        Instantiate(explosion, transform.position, transform.rotation);        

        // Destroys the object script is attached to and the object that is collided with
        Destroy(other.gameObject); // destroys other object
        Destroy(this.gameObject); // destroys the object thst script is attached to
    }
}
