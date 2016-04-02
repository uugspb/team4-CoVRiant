using UnityEngine;
using System.Collections;

public class PrefabManager : MonoBehaviour {
    public enum ModelType
    {
        Figure = 0
    }

    public enum MaterialType
    {
        CorrectFigure = 0
    }

    public GameObject [] Models;

    public Material [] Materials;
}
