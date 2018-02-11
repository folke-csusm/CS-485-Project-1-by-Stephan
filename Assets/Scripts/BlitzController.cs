using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlitzController : MonoBehaviour {

	public float speed;
	private Rigidbody ColoBody;
	private Vector3 direction;
	public Rigidbody bullets;
	public Transform BulletPoint;
	public AudioSource audio1;

	public float jumpingHeight;
	public LayerMask grounding;
	public Transform ColonelFeet;
	public Collider enemy1;

	public Text CountText;
	public Text winText;
	private int count;


	private float rotateSpeed = 1.5f;
	private float miniY = -60f;
	private float maxiY = 60f;
	private float rotateY = 0f;
	private float rotateX = 0f;

	// Use this for initialization
	void Start () {
	
		speed = 5f;
		jumpingHeight = 3.0f;
		ColoBody = GetComponent<Rigidbody>();
		audio1 = GetComponent<AudioSource>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	// Update is called once per frame
	void Update () {
		bool OnGround = Physics.CheckSphere (ColonelFeet.position, 0.1f, grounding, QueryTriggerInteraction.Ignore);
	
		direction = Vector3.zero;
		direction.x = Input.GetAxis ("Horizontal");
		direction.z = Input.GetAxis ("Vertical");
		direction = direction.normalized;

		if(direction.x != 0)
			ColoBody.MovePosition(ColoBody.position + transform.right * direction.x * speed * Time.deltaTime);
		if(direction.z != 0)
			ColoBody.MovePosition(ColoBody.position + transform.forward * direction.z * speed * Time.deltaTime);
		

		rotateX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotateSpeed;
		rotateY += Input.GetAxis("Mouse Y") * rotateSpeed;
		rotateY = Mathf.Clamp(rotateY, miniY, maxiY);
		transform.localEulerAngles = new Vector3(-rotateY, rotateX, 0);


		if(Input.GetButtonDown("Fire1") ){
			Rigidbody body;
			body = (Rigidbody)Instantiate(bullets, BulletPoint.position, bullets.rotation);
			audio1.Play ();
			body.velocity = BulletPoint.TransformDirection (Vector3.forward*20);

		}

		if (Input.GetButton ("Jump") && OnGround) {
		
			ColoBody.AddForce (Vector3.up * Mathf.Sqrt (jumpingHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		
		if ((other.gameObject.CompareTag ("Void")) || (other.gameObject.CompareTag ("Enemy")))
		{
			BlitzDeath();
		}

		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();
		}

	}

	void BlitzDeath()
	{
		ColoBody.gameObject.SetActive (false);
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);

	}

	void SetCountText(){
		CountText.text = "Count: " + count.ToString ();
		if (count >= 8) {
			winText.text = "Excellent!\nYou are the true Colonel!";
		}
	}
}
