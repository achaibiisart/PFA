using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
 
	public float speed = 10.0f;
		public float speedrun = 14f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = false;
	public int maxHealth = 100;
	 public int curHealth = 100; 
	public GameObject trigger;
		//public int randomnum;


	  void OnGUI() 
 {
  
  if (curHealth <1) // sinon division par zero et ca plante
  {
   curHealth =1;
  }
  
  GUI.Box(new Rect(10, 10, Screen.width / 2 /(maxHealth / curHealth), 20),"life" + curHealth + "/" + maxHealth);
  
 }
	
	
	
		
	
	
	void Awake () {
	    rigidbody.freezeRotation = true;
	    rigidbody.useGravity = false;
	}

	void FixedUpdate () {

				if (Input.GetKeyDown(KeyCode.LeftShift))
		{speed = speedrun;}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
	{speed=10.0f;}
	    if (grounded) {
	   
	        Vector3 targetVelocity = 
	        new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	        targetVelocity = transform.TransformDirection(targetVelocity);
	        targetVelocity *= speed;
 
	      
	        Vector3 velocity = rigidbody.velocity;
	        Vector3 velocityChange = (targetVelocity - velocity);
	        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
	        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
	        velocityChange.y = 0;
	        rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
 
	        
	        if (canJump && Input.GetButton("Jump")) {
	            rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
	        }
	    }
 
	    rigidbody.AddForce(new Vector3 (0, -gravity * rigidbody.mass, 0));
 
	    grounded = false;
	}
	void OnCollisionStay () {
	    grounded = true;    
	}
	
 
	float CalculateJumpVerticalSpeed () {

	    return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}