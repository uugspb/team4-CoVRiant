using UnityEngine;
using System.Collections;

public class CameraRaycasting : MonoBehaviour {

	private Camera menuCamera;

	private RaycastHit hit;
	private Ray ray;
	private GameObject previousHit;

	void Start () {
		menuCamera = GameObject.Find("VR_UI_dummyCamera").GetComponent<Camera>();
	}
	
	void Update () {

		ray = menuCamera.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast(ray, out hit)) {
			if (hit.transform.gameObject.CompareTag("Menu") && hit.transform.gameObject != previousHit) {
				hit.transform.SendMessage("HitByMenuCameraRay");
				previousHit = hit.transform.gameObject;
			}
		}


	}

}
