using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // this variable is used to update position of enemy, according to the player's position
    private Transform playerTransform;

    // Use this for initialization
    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // -------------------------------------------------------------------------
    public void Update()
    {
        float directionMagnitude = 0;
        if (playerTransform.position.x < transform.position.x)
        {
            directionMagnitude = (float) -0.02;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            directionMagnitude = (float) 0.02;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.position = new Vector3(transform.position.x + directionMagnitude, transform.position.y, transform.position.z);
    }
    // -------------------------------------------------------------------------
    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // get objec that hit this enemy
        Player player = collision.collider.GetComponent<Player>();
        if (player)
        {
            // if player hit this enemy
            if (collision.contacts[0].normal.y < -0.5)
            {
                // the contact force is downward
                // that's mean, the player hit this enemy from the top
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
                Destroy(gameObject);
            }
            else
            {
                player.OnHurtByEnemy();
            }
        }
    }
}
