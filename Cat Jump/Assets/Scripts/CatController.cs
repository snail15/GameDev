using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour {

    float jumpForce = 660.0f;
    Rigidbody2D rigid2D;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    Animator animator;
    float thereshold = 2.0f; // for android 

	// Use this for initialization
	void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        //      {
        //          this.rigid2D.AddForce(transform.up * this.jumpForce);
        //      }

        if (Input.GetMouseButton(0) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }


        int catDirection = 0;

        //if (Input.GetKey(KeyCode.RightArrow)) catDirection = 1;
        //if (Input.GetKey(KeyCode.LeftArrow)) catDirection = -1;

        if (Input.acceleration.x > this.thereshold) catDirection = 1;
        if (Input.acceleration.x < -1 * this.thereshold) catDirection = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * catDirection * this.walkForce);
        }

        if (catDirection != 0)
        {
            transform.localScale = new Vector3(catDirection, 1, 1);
        }

        this.animator.speed = speedx / 1.0f;

        if (transform.position.y < -8)
            SceneManager.LoadScene("ClearScene");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("ClearScene");
    }
}
