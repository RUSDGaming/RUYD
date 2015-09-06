using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

	private float speed = 10f;

	private float jumpSpeed = 10f;

	public LayerMask collideMask; 

	private float horizontal;
	private BoxCollider boxCollider;
	private float raycastRange = 2;

	public Transform respawn;
	public float velY;
	public float velX;
	public bool grounded; 

	private float gravity = -15f;
	[SerializeField]
	private float
		groundDistance;
	private float sideDistance;

	// Use this for initialization
	void Start ()
	{	
		Debug.Log ("Logan is a tool, KappaPride no rage");
		//body = gameObject.GetComponent<Rigidbody> ();
		boxCollider = gameObject.GetComponent<BoxCollider> ();
		groundDistance = boxCollider.size.y / 2f - .01f;
		sideDistance = boxCollider.size.x / 2f - .01f;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (isLocalPlayer) {
			horizontal = Input.GetAxisRaw ("Horizontal");
			if (Input.GetButtonDown ("Jump") && grounded) {
				velY = jumpSpeed;
			}	
		}
	}

	void FixedUpdate ()
	{
		if (isLocalPlayer) {

		}
		DoPhysics ();
	}


	// I made this because we don't need reall physics for our game, besides real physics don't feel right for a platformer... 
	// lol this is getting complicated fml kappachino
	void DoPhysics ()
	{
		Vector3 vel = new Vector3 (velX * Time.fixedDeltaTime, velY * Time.fixedDeltaTime, 0);

		velX = horizontal * speed;

		for (int i = -1; i< 2; i++) {
			Vector3 pos = transform.position;
			pos = new Vector3 (pos.x + (i * sideDistance), pos.y, pos.z);
			// check to see if you are hitting the ground.
			RaycastHit hit; 

			if (velY > 0) {
				if (Physics.Raycast (pos, Vector3.up, out hit, raycastRange, collideMask)) {
					if (hit.distance < groundDistance + velY * Time.fixedDeltaTime) {
						velY = 0f;
						vel = new Vector3 (velX * Time.fixedDeltaTime, +hit.distance - groundDistance + 0.01f, 0);
						break;						
					} 
				}
			}

			//if (velY <= 0) {
			if (Physics.Raycast (pos, Vector3.down, out hit, raycastRange, collideMask)) {
				if (hit.distance < groundDistance - velY * Time.fixedDeltaTime) {
					if (velY <= 0f) {
						velY = 0f;
						grounded = true;
						vel = new Vector3 (velX * Time.fixedDeltaTime, -hit.distance + groundDistance - 0.01f, 0);
						break;
					}
				} else {
					grounded = false;
				}	
			
			} else {
				//Debug.Log ("3");
				grounded = false;
			}	
			//}
			
			vel = new Vector3 (velX * Time.fixedDeltaTime, velY * Time.fixedDeltaTime, 0);

		}

		// dont bother checking for collisions if the character isnt moving... Keepo
		if (velX != 0) {		
			for (int i = -1; i < 2; i++) {
				Vector3 pos = transform.position;
				pos = new Vector3 (pos.x, pos.y + (i * (groundDistance - .02f)), pos.z);
				RaycastHit hitSide;
				if (velX > 0) {
					if (Physics.Raycast (pos, Vector3.right, out hitSide, raycastRange, collideMask)) {
						if (hitSide.distance <= sideDistance + velX * Time.fixedDeltaTime) {
							vel = new Vector3 (+hitSide.distance - sideDistance - 0.01f, vel.y, 0);
							velX = 0f;
							Debug.Log ("Hit the side");
							break;
						}
					}
				} else if (velX < 0) {

					if (Physics.Raycast (pos, Vector3.left, out hitSide, raycastRange, collideMask)) {
						if (hitSide.distance <= sideDistance - velX * Time.fixedDeltaTime) {
							vel = new Vector3 (-hitSide.distance + sideDistance + 0.01f, vel.y, 0);
							velX = 0f;
							Debug.Log ("Hit the side");
							break;
						}
					}
				}
			}
		}

	
		// move the character;
		transform.Translate (vel);

		if (!grounded) {
			if (Input.GetButton ("Jump")) {
				velY += gravity * Time.fixedDeltaTime;
			} else {
				velY += gravity * Time.fixedDeltaTime * 2;

			}
		}

	}


	void renderRays ()
	{
		for (int i = -1; i < 2; i++) {
			Vector3 pos = transform.position;
			pos = new Vector3 (pos.x, pos.y + (i * (groundDistance - .02f)), pos.z);
			
			if (velX > 0) {
				Debug.DrawRay (pos, Vector3.right);
				
			} else if (velX < 0) {
				Debug.DrawRay (pos, Vector3.left);
			}
		}
		
		for (int i = -1; i< 2; i++) {
			Vector3 pos = transform.position;
			pos = new Vector3 (pos.x + (i * sideDistance), pos.y, pos.z);
			// check to see if you are hitting the ground.
			if (velY < 0) {
				Debug.DrawRay (pos, Vector3.down);
			}
			
		}
	}

	public void ResetPlayer ()
	{
		GameObject go = GameObject.FindGameObjectWithTag ("Respawn");
		if (go != null) {
			respawn = go.transform;
			transform.position = respawn.position;
			velX = 0f;
			velY = 0f;
		}
	}

}
