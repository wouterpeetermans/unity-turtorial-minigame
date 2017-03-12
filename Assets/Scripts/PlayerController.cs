using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text CountText;
	public Text WinText;
	private int count;
	public float Speed;
	private Rigidbody rb;

	void Start (){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		displayCount ();
		WinText.text = "";
	}

	void FixedUpdate (){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement*Speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Pick Up")) {
			Destroy (other.gameObject);
			count++;
			displayCount ();
		}
	}

	void displayCount(){
		CountText.text = "Count: " + count.ToString ();
		if (count>=13) {
			WinText.text = "You win!";
		}
	}
}
