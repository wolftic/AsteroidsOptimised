using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	private Rigidbody2D _rigidbody;
	private float xInput;
	private float yInput;
	private Vector2 movement;

	void Awake()
	{
		_rigidbody = GetComponent <Rigidbody2D> ();
	}

	void Update()
	{
		xInput = Input.GetAxis ("Horizontal");
		yInput = Input.GetAxis ("Vertical");
	}

	void FixedUpdate()
	{
		Vector2 direction = new Vector2 (xInput, yInput);
		Vector2 velocity = direction.normalized * speed * Time.fixedDeltaTime;
		_rigidbody.MovePosition (_rigidbody.position + velocity);
	}
}
