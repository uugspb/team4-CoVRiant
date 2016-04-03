using UnityEngine;
using System.Collections;

public class CorrectZone : MonoBehaviour {

    private float CorrectWaitTime = 5;
    private bool waitForCorrect = false;
    private float startWatTime;

    bool restart = false;
    float restartTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (restart)
        {
            if (Time.time > restartTime + 5)
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
        }
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

    void VisitTransform(Transform t, System.Action<Transform> onT)
    {
        onT(t);
        for (int i = 0; i < t.childCount; ++i)
        {
            onT(t.GetChild(i));
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
                    var prefabManager = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();

                    var figure = prefabManager.Models[(int)PrefabManager.ModelType.Figure];

                    var material = prefabManager.Materials[(int)PrefabManager.MaterialType.CorrectFigure];

                    VisitTransform(figure.transform, t => {
                        var renderer = t.GetComponent<MeshRenderer>();
                        if (renderer != null)
                            renderer.material = material;
                    });

                    if (restart == false)
                    {
                        restart = true;
                        restartTime = Time.time;
                    }

                    //Application.LoadLevel("Start");
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
