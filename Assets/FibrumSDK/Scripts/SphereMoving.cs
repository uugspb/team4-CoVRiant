using UnityEngine;
using System.Collections;

public class SphereMoving : MonoBehaviour {
	private float inp_x;
	private float inp_z;
	private float camSpeed = 1;
	private Vector3 newScale;

	public float maxDistance = 10;
	public float minDistance = 5;


	void Start (){
		newScale = gameObject.transform.localScale;

	}

	void Update () {


		inp_x = Input.GetAxis("Horizontal");
		inp_z = Input.GetAxis("Vertical");

		transform.Rotate (-Vector3.up * inp_z * camSpeed - Vector3.right * inp_x * camSpeed );

		if(Input.GetButton("Jump") || Input.GetKey(KeyCode.Q)) {

			newScale.x -= 0.1f;
			newScale.y -= 0.1f;
			newScale.z -= 0.1f;

			gameObject.transform.localScale = newScale;
		}
		if(Input.GetButton("Fire1") || Input.GetKey(KeyCode.E))
        {

			newScale.x += 0.1f;
			newScale.y += 0.1f;
			newScale.z += 0.1f;

			gameObject.transform.localScale = newScale;
		}

		newScale.x = Mathf.Clamp(transform.localScale.x, minDistance, maxDistance);
		newScale.y = Mathf.Clamp(transform.localScale.y, minDistance, maxDistance);
		newScale.z = Mathf.Clamp(transform.localScale.z, minDistance, maxDistance);

	}
	void FixedUpdate() {

	}
}
