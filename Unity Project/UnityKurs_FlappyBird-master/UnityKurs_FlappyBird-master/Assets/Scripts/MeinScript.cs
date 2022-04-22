using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeinScript : MonoBehaviour
{
    public float meineGeschwindigketit = 0.1f;
    public float sprunghöhe = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.RightArrow)) {
            rigidbody.AddForce(Vector2.right * meineGeschwindigketit, ForceMode2D.Force);
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            rigidbody.AddForce(Vector2.left * meineGeschwindigketit, ForceMode2D.Force);
        }

        // Wenn wir eine maximalgeschwindigekit erreicht haben wollen wir nicht weiter beschleuigen.
        if (rigidbody.velocity.x > 5) {
            rigidbody.velocity = new Vector2(5, rigidbody.velocity.y);
        } else if (rigidbody.velocity.x < -5) {
            rigidbody.velocity = new Vector2(-5, rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            // Give the player velocity in y direction.

            rigidbody.AddForce(Vector2.up * sprunghöhe, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        float federkraftVonSprungbrett = other.GetComponent<Sprungplattform>().federkrat;

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(other.transform.up * federkraftVonSprungbrett, ForceMode2D.Impulse);
    }
}
