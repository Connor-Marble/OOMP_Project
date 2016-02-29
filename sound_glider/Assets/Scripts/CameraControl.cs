using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {


	public float speed = 1f;
	public float roll = 1f;
	public float drag = 0.1f;
	public float turn_speed = 0.1f;

	private Vector3 velocity;
	
	// Update is called once per frame
	void Update () {
		Vector2 movement = (Input.mousePosition - new Vector3 (Screen.width / 2, Screen.height / 2, 0))/Screen.width;
		velocity += (new Vector3(0, movement.y, movement.x) * speed*Time.deltaTime);
		Quaternion targetRot = Quaternion.LookRotation (-(Vector3.right * 100) + velocity);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRot, turn_speed);

		transform.RotateAround (transform.position, transform.forward, -velocity.z*roll);

		transform.position += velocity * Time.deltaTime;
		velocity *= (1f - drag);
	}
}
