using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisorderSystem : MonoBehaviour {

    public static DisorderSystem instance;

    public GameObject cameraParent;

    private List<MonoBehaviour> activeDisorderComponents;

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

        foreach (UnityStandardAssets.ImageEffects.Grayscale comp in cameraParent.GetComponentsInChildren< UnityStandardAssets.ImageEffects.Grayscale>())
        {
            activeDisorderComponents.Add(comp);
            comp.enabled = true;
        }
    }

    public void PartialBlindness()
    {

        int random = Random.Range(0, 2);

        UnityStandardAssets.ImageEffects.BlurOptimized comp = cameraParent.GetComponentsInChildren<UnityStandardAssets.ImageEffects.BlurOptimized>()[random];

        activeDisorderComponents.Add(comp);
        comp.enabled = true;



    }

    public void LegalBlindness()
    {

        foreach (UnityStandardAssets.ImageEffects.BlurOptimized comp in cameraParent.GetComponentsInChildren<UnityStandardAssets.ImageEffects.BlurOptimized>())
        {
            activeDisorderComponents.Add(comp);
            comp.enabled = true;
        }


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
