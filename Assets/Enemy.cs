using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public Vector2 speed;

    protected Rigidbody2D r2d;
    protected SpriteRenderer spriteRenderer;

	// Use this for initialization
	protected virtual void Start ()
    {
        r2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer.isVisible)
        {
            r2d.velocity = Vector2.Lerp(r2d.velocity, speed, Time.deltaTime * 5f);
        }
        else
        {
            r2d.velocity = Vector2.zero;
        }
    }

    public void kill()
    {
        Destroy(gameObject);
        var dieParticle = Resources.Load<ParticleSystem>("EnemyParticle");
        var particleSystemInstance = Instantiate<ParticleSystem>(dieParticle, transform.position, Quaternion.identity);
        Destroy(particleSystemInstance.gameObject, particleSystemInstance.main.duration);
    }
}
