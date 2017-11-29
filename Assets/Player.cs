using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10f;
        transform.Translate(x, 0f, 0f, Space.World);

        var spriteRenderer = GetComponent<SpriteRenderer>();
        var r2d = GetComponent<Rigidbody2D>();

        if (Mathf.Abs(Mathf.Sign(r2d.velocity.x) - Mathf.Sign(x)) > 0.1f)
        {
            r2d.velocity = new Vector2(0f, r2d.velocity.y);
        }

        if (!Mathf.Approximately(x, 0))
        {
            spriteRenderer.flipX = x > 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            r2d.velocity = new Vector2(r2d.velocity.x, 5f);
            r2d.AddTorque(-10f, ForceMode2D.Impulse);
            GetComponent<Animator>().SetTrigger("Jump");
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
