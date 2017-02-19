using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisorderSystem : MonoBehaviour {

    public static DisorderSystem instance;

    private List<MonoBehaviour> activeDisorderComponents;

    [SerializeField]
    private UnityStandardAssets.ImageEffects.Grayscale grayScale;
   

    public void Awake()
    {

        instance = this;

    }

	// Use this for initialization
	void Start () {

        activeDisorderComponents = new List<MonoBehaviour>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Achromatopsia()
    {

        activeDisorderComponents.Add(grayScale);
        grayScale.enabled = true;
    }

    public void Return()
    {
        while (activeDisorderComponents.Count > 0)
        {
            activeDisorderComponents[0].enabled = false;
            activeDisorderComponents.RemoveAt(0);

        }
    }
}
