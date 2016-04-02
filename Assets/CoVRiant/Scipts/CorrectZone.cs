using UnityEngine;
using System.Collections;

public class CorrectZone : MonoBehaviour {

    private float CorrectWaitTime = 2;
    private bool waitForCorrect = false;
    private float startWatTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(string.Format("OnTriggerEnter {0}", other.name));
        //if (other.gameObject == Camera.main.gameObject)
        {
            if (true/*correct angle*/)
            {
                waitForCorrect = true;
                startWatTime = Time.time;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(string.Format("OnTriggerStay {0}", other.name));
        //if (other.gameObject == Camera.main.gameObject)
        {
            if (true/*correct angle*/)
            {
                if (!waitForCorrect)
                {
                    waitForCorrect = true;
                    startWatTime = Time.time;
                }
                else if (Time.time > startWatTime + CorrectWaitTime)
                {
                    Application.LoadLevel("Start");
                }
            }
            else
            {
                waitForCorrect = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(string.Format("OnTriggerExit {0}", other.name));
        //if (other.gameObject == Camera.main.gameObject)
        {
            waitForCorrect = false;
        }
    }
}
