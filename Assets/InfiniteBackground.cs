using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour {

    public SpriteRenderer background1;
    public SpriteRenderer background2;

    [Range(0f, 1f)]
    public float scrollY;

    private SpriteRenderer fixedBackground;
    private SpriteRenderer movableBackground;

    private float initialY;
    private float offsetY;

    // Use this for initialization
    void Start () {
        initialY = Camera.main.transform.position.y;
        offsetY = background1.transform.position.y - initialY;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        var delta1 = Camera.main.transform.position.x - background1.transform.position.x;
        var delta2 = Camera.main.transform.position.x - background2.transform.position.x;
        float closestDelta;

        if (Mathf.Abs(delta1) < Mathf.Abs(delta2))
        {
            fixedBackground = background1;
            movableBackground = background2;
            closestDelta = delta1;
        } else
        {
            fixedBackground = background2;
            movableBackground = background1;
            closestDelta = delta2;
        }

        if (closestDelta > 0 && movableBackground.transform.position.x < fixedBackground.transform.position.x)
        {
            var movablePosition = movableBackground.transform.position;
            movablePosition.x = fixedBackground.transform.position.x + fixedBackground.size.x;
            movableBackground.transform.position = movablePosition;
        }

        if (closestDelta < 0 && movableBackground.transform.position.x > fixedBackground.transform.position.x)
        {
            var movablePosition = movableBackground.transform.position;
            movablePosition.x = fixedBackground.transform.position.x - fixedBackground.size.x;
            movableBackground.transform.position = movablePosition;
        }

        var deltaY = Camera.main.transform.position.y - initialY;
        var background1Position = background1.transform.position;
        background1Position.y = Camera.main.transform.position.y + offsetY - deltaY * scrollY;
        background1.transform.position = background1Position;
        var background2Position = background2.transform.position;
        background2Position.y = background1Position.y;
        background2.transform.position = background2Position;
    }
}
