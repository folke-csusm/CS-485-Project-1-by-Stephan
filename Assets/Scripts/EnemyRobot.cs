using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobot : MonoBehaviour {

	private Rigidbody enemybody;
	public Rigidbody target;
	public Rigidbody Pickup;
	public float speed;
	public AudioSource audio2;

	private int health;


	// Use this for initialization
	void Start () {
		enemybody = GetComponent<Rigidbody>();
		speed = 0.5f;
		health = 3;
		audio2 = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		transform.LookAt (target.transform, Vector3.up);
		float dist = Vector3.Distance(target.position, transform.position);
		if (dist <= 500)
			transform.position += transform.forward * speed * Time.deltaTime;

	}

	void OnTriggerEnter(Collider other) 
	{

		if (other.gameObject.CompareTag ("Projectile")) {
			audio2.Play ();

			if (health > 0) {
				health = health - 1;
				other.gameObject.SetActive (false);
			}
			else {
				other.gameObject.SetActive (false);
				Rigidbody body;
				body = (Rigidbody)Instantiate(Pickup, transform.position, Pickup.rotation);
				body.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
				enemybody.gameObject.SetActive (false);
			}
		
		}

		if (other.gameObject.CompareTag ("Void"))
		{
			enemybody.gameObject.SetActive (false);
		}
	}



}
