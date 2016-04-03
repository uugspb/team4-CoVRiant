using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	void Update () {
		transform.eulerAngles = new Vector3(0, transform.rotation.y, transform.rotation.z);
	}
}
