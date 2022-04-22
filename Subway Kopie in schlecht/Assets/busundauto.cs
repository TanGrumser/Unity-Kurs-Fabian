using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busundauto : MonoBehaviour {

    public float speed = 40f;
    Rigidbody2D rigidbody;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate() {
        rigidbody.MovePosition(transform.position + Vector3.left * speed * Time.fixedDeltaTime);

        
        if (transform.position.x <-100){
            Destroy(gameObject);
        }
    }
}

