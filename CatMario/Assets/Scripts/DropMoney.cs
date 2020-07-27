using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMoney : MonoBehaviour {

    [SerializeField] private GameObject _cloudParticlePrefap;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        Player hitPlayer = collision.collider.GetComponent<Player>();
        if (hitPlayer != null && collision.contacts[0].normal.y > 0)
        {
            // hit by the bird
            Instantiate(_cloudParticlePrefap, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        // hit by the box, check contact angle. If box is on the top, destroy the pig
        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticlePrefap, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        // hit by anything with velocity magnitude > 4
        if (collision.relativeVelocity.magnitude > 4)
        {
            Instantiate(_cloudParticlePrefap, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        */
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
