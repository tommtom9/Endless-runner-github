using UnityEngine;
using System.Collections;

public class CamBehavior : MonoBehaviour {

	Transform player;
	public float horizontalOffset = 0f;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	

	void Update () {
		var x = player.position.x;

		transform.position = new Vector3 (x + horizontalOffset, transform.position.y, -10);
	}
}
