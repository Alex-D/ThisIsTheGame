using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

    public event Action<int> OnScoreChanged;

    private int score = 0;
    private Rigidbody2D r2d;

    private static Player instance;
    
	void Awake () {
        instance = this;
	}

    public static Player GetInstance()
    {
        return instance;
    }

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var x = 0f;

#if UNITY_STANDALONE || UNITY_WEBGL
        x = Input.GetAxis("Horizontal") * Time.deltaTime * 10f;
        transform.Translate(x, 0f, 0f, Space.World);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
#else
        x = Time.deltaTime * 10f;
        foreach (var touch in Input.touches)
        {
            if (touch.position.x > Screen.width * 0.5f)
            {
                transform.Translate(x, 0f, 0f, Space.World);
            } else if (touch.phase == TouchPhase.Began)
            {
                Jump();
            }
        }
#endif

        if (Mathf.Abs(Mathf.Sign(r2d.velocity.x) - Mathf.Sign(x)) > 0.1f)
        {
            r2d.velocity = new Vector2(0f, r2d.velocity.y);
        }

        if (!Mathf.Approximately(x, 0))
        {
            spriteRenderer.flipX = x > 0;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().kill();
            score += 100;
            if (OnScoreChanged != null)
            {
                OnScoreChanged(score);
            }
        }
    }

    private void Jump()
    {
        r2d.velocity = new Vector2(r2d.velocity.x, 5f);
        r2d.AddTorque(-10f, ForceMode2D.Impulse);
        GetComponent<Animator>().SetTrigger("Jump");
        GetComponent<AudioSource>().Play();
    }
}
