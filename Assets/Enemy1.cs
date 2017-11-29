using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

    public Vector2 speed;

    private Rigidbody2D r2d;

	// Use this for initialization
	void Start ()
    {
        r2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        r2d.velocity = Vector2.Lerp(r2d.velocity, speed, Time.deltaTime * 5f);
    }
}
