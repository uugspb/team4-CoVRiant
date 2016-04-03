using UnityEngine;
using System.Collections;

public class RaycastAccept : MonoBehaviour {

	public Material defaultMaterial;
	public Material onHighlightMaterial;
	public Transform identityTransform;

	private bool isSetHighlighted = false;

	void Start() {
		identityTransform = gameObject.transform;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.H) && isSetHighlighted) {
			var cam = GameObject.Find ("Sphere");
//			var difference = cam.gameObject.transform.localScale * 7 - gameObject.transform.lossyScale;
//			var realDifference = Mathf.Max (Mathf.Max(difference.x, difference.y), difference.z);
//			var dx = cam.gameObject.transform.localScale.x / gameObject.transform.localScale.x;
//			var dy = cam.gameObject.transform.localScale.y / gameObject.transform.localScale.y;
//			var dz = cam.gameObject.transform.localScale.z / gameObject.transform.localScale.z;
//			if (dx < 2 && dy < 2 && dz < 2) {
//				iTween.ScaleAdd (cam, iTween.Hash ("amount", (gameObject.transform.localScale - cam.gameObject.transform.localScale) * 10, "time", 2.0F, "looptype", "none", "easetype", "easeInOutExpo"));
//			} 
			//cam.gameObject.transform.localScale = gameObject.transform.localScale * 10;
			// iTween.ScaleTo (cam, iTween.Hash ("x", 230,"y",230,"z",230, "time", 2.0F, "easetype", "easeInOutExpo"));
			iTween.ScaleTo (cam, iTween.Hash ("scale", 9 * gameObject.transform.localScale, "time", 2.0F, "looptype", "none", "easetype", "easeInOutExpo"));
			iTween.MoveTo (cam, iTween.Hash ("position", gameObject.transform.position, "time", 2.0F, "easetype", "easeInOutExpo"));
		}
	}

	void HitByMenuCameraRay () {
		Debug.Log("Raycasted!!!");
		var menuElements = GameObject.FindGameObjectsWithTag ("Menu");
		foreach(GameObject menuElement in menuElements) {
			if (menuElement != gameObject) {
				RaycastAccept guestScript = (RaycastAccept) menuElement.GetComponent (typeof(RaycastAccept));
				guestScript.setHighlighted (false);
			} else {
				setHighlighted (true);
			}
		}
	}

	public void setHighlighted (bool setHighlighted) {
		if (setHighlighted) {
			//gameObject.transform.localScale += new Vector3 (0.1F, 0.1F, 0.1F);
//				iTween.ScaleBy (gameObject, iTween.Hash ("amount", gameObject.transform.localScale * 0.05F, "time", 1.0F, "easeType", "easeIn", "looptype", "none"));
			iTween.MoveBy(gameObject, iTween.Hash("y", gameObject.transform.localScale.y, "time", 0.6F, "looptype", "none", "easetype", "easeInOutExpo"));
			iTween.RotateBy (gameObject, iTween.Hash("x", 1.0F, "time", 0.3F, "easetype", "easeInOutExpo", "looptype", "none"));
			iTween.ScaleTo (gameObject, iTween.Hash("scale", identityTransform.localScale * 1.3F, "time", 0.3F, "easetype", "easeInOutExpo", "looptype", "none"));
			iTween.ScaleTo (gameObject, iTween.Hash("scale", identityTransform.localScale, "time", 0.3F, "delay", 0.3F, "easetype", "easeInOutExpo", "looptype", "none"));
			iTween.MoveTo(gameObject, iTween.Hash("position", identityTransform.position, "time", 0.3F, "delay", 0.6F,"looptype", "none", "easetype", "easeInOutExpo"));
			gameObject.GetComponent<Renderer> ().material = onHighlightMaterial;
				isSetHighlighted = true;
		} else {
//			iTween.ScaleTo (gameObject, iTween.Hash("scale", identityTransform.localScale, "time", 1.0F, "easeType", "easeInOutExpo", "looptype", "none"));
			//gameObject.transform.localScale = identityTransform.localScale;
			gameObject.GetComponent<Renderer> ().material = defaultMaterial;
			isSetHighlighted = false;
		}
	}

//	public void fixScale() {
//		var cam = GameObject.Find ("Sphere");
//		cam.gameObject.transform.localScale = gameObject.transform.localScale * 10;
//	}
}
