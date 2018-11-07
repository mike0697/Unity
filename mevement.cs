using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Rigidbody2D))]
public class movement : MonoBehaviour {

    Rigidbody2D body;
    Animator anim;
    // variabili upgrade
    [SerializeField] 
    float moveSpeed = 3f;

    bool isJumping = false;
    float jumpForce = 1.4f;
    int doppiosalto = 0;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent < Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        Jumping();
	}

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(Vector2.right.x * moveSpeed * h, body.velocity.y);

        body.velocity = velocity;
        if(velocity.x < 0)
        {
            body.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            body.transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("isMoving", Mathf.Abs(h));
    }
    void Jumping()
    {

        float h2 = Input.GetAxis("Jump");
        
        if (isJumping)
        {
            if(body.velocity.y == 0)
            {
                    isJumping = false;
                
            }

        }
        else
            {
                if(Input.GetAxis("Jump")> 0.1 )
                {
                    body.AddForce(Vector2.up * jumpForce* 10, ForceMode2D.Impulse);
                    
                    isJumping = true;
                    
            }
            
        }
        anim.SetFloat("isJump", Mathf.Abs(h2));

    }
    }

