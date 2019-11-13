using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison_Destroy : MonoBehaviour
{
    //public var
    public GameObject explosion;
    public int scoreValue = 10;

    //private var
    private GameController gameControllerScript;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            // I found a GameController object with tag "GameController"
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
            if (gameControllerScript == null)
            {
                // Script is not attached to object
                Debug.Log("Cannot find GameController script on GameController object");
            }
        }

    }
    void OnCollisionEnter2D(Collision2D other) //If there is a collison with another rigid body
    {
        Instantiate(explosion, transform.position, transform.rotation);

        // Destroys the object script is attached to and the object that is collided with
        if (other.gameObject.CompareTag("Player"))
        {
            gameControllerScript.GameOver();
        }
        gameControllerScript.AddScore(scoreValue);
        Destroy(other.gameObject); // destroys other object Laser/Ship
        Destroy(this.gameObject); // destroys the object thst script is attached to Asteroid
    }
}
