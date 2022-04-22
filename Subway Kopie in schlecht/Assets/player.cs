using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class player : MonoBehaviour
    

    {
        public float Sprungkraft = 10f;
        public float Geschwindigkeit = 1f;
        public LayerMask layermask;
        int jumps = 1;
        Rigidbody2D rigidbody;
        BoxCollider2D boxcollider;
        Animator animator;
        SpriteRenderer sr;


        // Start is called before the first frame update
        void Start()
        {
       rigidbody = GetComponent<Rigidbody2D>();
       boxcollider = GetComponent<BoxCollider2D>();
       animator = GetComponentInChildren<Animator>();
       sr = GetComponentInChildren<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()  {
            VericaleBewegung();
            HorizontaleBewegung();

            if (Input.GetKey(KeyCode.LeftShift))  {
                animator.Play("liegen");
            } else {
                animator.Play("sprint");
            }
        }
        void VericaleBewegung() {
            if (Input.GetKey(KeyCode.W))  {
                rigidbody.gravityScale = 6;
            }
            else {
                rigidbody.gravityScale = 3;
            }
            if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)  {
            rigidbody.AddForce(Vector2.up * Sprungkraft, ForceMode2D.Impulse);
            jumps--;
            } 
            Checkjumps();
        if (Input.GetKey(KeyCode.LeftShift))  {
            MakeSmaller();
        }
        else /*if (Input.GetKeyUp(KeyCode.LeftShift))*/  {
            Makebigger();
        }
    }
        void HorizontaleBewegung()  {
            if (Input.GetKey(KeyCode.D)) {
                rigidbody.AddForce(Vector2.right * Geschwindigkeit, ForceMode2D.Force);
            } else if (Input.GetKey(KeyCode.A))  {
                rigidbody.AddForce(Vector2.left * Geschwindigkeit, ForceMode2D.Force);
                if (rigidbody.velocity.x > 5) {
                rigidbody.velocity = new Vector2(5, rigidbody.velocity.y);
            } else if (rigidbody.velocity.x < -5){
                rigidbody.velocity = new Vector2(-5, rigidbody.velocity.y);
            }
        }
    }
        void Checkjumps() {
             RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, layermask);

        if (hit.collider != null && rigidbody.velocity.y <= 0) {
            jumps = 1;
        }
    }
        void OnTriggerEnter2D(Collider2D other)  {
            rigidbody.AddForce(other.transform.up * Sprungkraft * 2, ForceMode2D.Impulse);

            if (other.tag == "lava")  {
        SceneManager.LoadScene(1);
        }

        if (other.tag == "jumppad")  {
        rigidbody.AddForce(other.transform.up * Sprungkraft * 0.75f, ForceMode2D.Impulse);
        }
    }
        void MakeSmaller()  {
            boxcollider.size = new Vector2(boxcollider.size.x, 0.08045235f);
            boxcollider.offset = new Vector2(boxcollider.offset.x, -0.0401943f);
        }
        void Makebigger()  {
            boxcollider.size = new Vector2(boxcollider.size.x, 0.26f);
            boxcollider.offset = new Vector2(boxcollider.offset.x, 0f);
        }   
}

