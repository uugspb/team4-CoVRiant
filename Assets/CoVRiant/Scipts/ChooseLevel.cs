using UnityEngine;
using System.Collections;

public class ChooseLevel : MonoBehaviour {
    private GameObject[] levels;
    private Vector3[] distnces;
    public int countOfLevels;
    private GameObject lcamera;
    private int prevLevel = -1;
    private float startWatTime;
    private float CorrectWaitTime = 3;
    public Material defaultMaterial1;
    public Material defaultMaterial2;
    public Material defaultMaterial3;

    public Material onHighlightMaterial;

    // Use this for initialization
    void Start () {
        lcamera = GameObject.FindWithTag("lcamera");
        levels = new GameObject[countOfLevels];
        distnces = new Vector3[countOfLevels];
        for (int i = 0; i < countOfLevels; i++)
        {
            levels[i] = GameObject.FindWithTag("level" + (i + 1));
        }
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < countOfLevels; i++)
        {
            distnces[i] = levels[i].transform.position - lcamera.transform.position;
        }
        float minAngle = 20;
        int num = -1;
        for (int i = 0; i < countOfLevels; i++)
        {
            float nAngle = Vector3.Angle(distnces[i], lcamera.transform.forward);
            Debug.Log("nAngle :" + nAngle + " " + i);
            if (nAngle < minAngle)
            {
                minAngle = nAngle;
                num = i;
            }
        }
        if (prevLevel != num)
        {
            if (num != -1) levels[num].GetComponent<Renderer>().material = onHighlightMaterial;
            if (prevLevel == 0) levels[0].GetComponent<Renderer>().material = defaultMaterial1;
            if (prevLevel == 1) levels[1].GetComponent<Renderer>().material = defaultMaterial2;
            if (prevLevel == 2) levels[2].GetComponent<Renderer>().material = defaultMaterial3;

            startWatTime = Time.time;
            prevLevel = num;
        }
        if (Time.time > startWatTime + CorrectWaitTime && prevLevel != -1)
        {
            Debug.Log(prevLevel + 1);
            Application.LoadLevel("Level_0" + (prevLevel + 1));
        }

    }
}
