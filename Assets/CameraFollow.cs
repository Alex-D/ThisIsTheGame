using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour {

    public Player player;
    public Vector2 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// LateUpdate is called once per frame after all Updates
	void LateUpdate () {
        var playerPosition = player.transform.position;
        var destination = new Vector3(
            playerPosition.x + offset.x,
            playerPosition.y + offset.y,
            transform.position.z
        );
        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * 8f);
    }
}
