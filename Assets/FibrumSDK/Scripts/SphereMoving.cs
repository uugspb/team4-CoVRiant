using UnityEngine;
using System.Collections;

public class SphereMoving : MonoBehaviour {
	private float inp_x;
	private float inp_z;
	private float camSpeed = 1;

	//public Transform cam;
	//GameObject fire;


	// Use this for initialization
	void Start (){
		//oldPos = transform.position;
		//Physics.gravity = new Vector3(0, -75, 0);
	}

	// Update is called once per frame
	void Update () {

		//fire = GameObject.Find("fire");

		inp_x = Input.GetAxis("Horizontal");
		inp_z = Input.GetAxis("Vertical");
//
		transform.Rotate (-Vector3.forward * inp_z * camSpeed - Vector3.right * inp_x * camSpeed );

	}
	void FixedUpdate() {

//		Vector3 cp = transform.position - cam.position;
//		cp.y = 0f;
//		transform.Translate(Quaternion.LookRotation(cp) * inp * speed * Time.deltaTime, Space.World);
//
//		delta = oldPos - transform.position;
//
//		float ang = Mathf.Sin(delta.magnitude / diam / pi2) * Mathf.Rad2Deg;
//		transform.RotateAround(Vector3.Cross(delta, Vector3.up), ang);
//		oldPos = transform.position;

	}
}