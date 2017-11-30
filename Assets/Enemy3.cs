using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    public Vector2 jumpForce;
    public float jumpTorque;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(Jump());
    }

    void Update()
    {
        
    }

    private IEnumerator Jump()
    {
        while(true)
        {
            while(r2d.velocity.magnitude > 0.01f || !spriteRenderer.isVisible)
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);
            r2d.AddForce(jumpForce, ForceMode2D.Impulse);
            r2d.AddTorque(jumpTorque, ForceMode2D.Impulse);
        }
    }
}
