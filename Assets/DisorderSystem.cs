using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisorderSystem : MonoBehaviour {

    public static DisorderSystem instance;

    public GameObject cameraParent;

    private List<MonoBehaviour> activeVisualDisorders;
    private List<MonoBehaviour> activeCognitiveDisorders;
    private List<MonoBehaviour> activeAudioDisorders;

    public void Awake()
    {

        instance = this;

    }

	// Use this for initialization
	void Start () {

        activeVisualDisorders = new List<MonoBehaviour>();
        activeCognitiveDisorders = new List<MonoBehaviour>();
        activeAudioDisorders = new List<MonoBehaviour>();


    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Achromatopsia()
    {

        foreach (UnityStandardAssets.ImageEffects.Grayscale comp in cameraParent.GetComponentsInChildren< UnityStandardAssets.ImageEffects.Grayscale>())
        {
            activeVisualDisorders.Add(comp);
            comp.enabled = true;
        }
    }

    public void PartialBlindness()
    {

        int random = Random.Range(0, 2);

        UnityStandardAssets.ImageEffects.BlurOptimized comp = cameraParent.GetComponentsInChildren<UnityStandardAssets.ImageEffects.BlurOptimized>()[random];

        activeVisualDisorders.Add(comp);
        comp.enabled = true;



    }

    public void LegalBlindness()
    {

        foreach (UnityStandardAssets.ImageEffects.BlurOptimized comp in cameraParent.GetComponentsInChildren<UnityStandardAssets.ImageEffects.BlurOptimized>())
        {
            activeVisualDisorders.Add(comp);
            comp.enabled = true;
        }


    }

    public void ReturnVisual()
    {

        Return(DisorderButton.DisorderType.VISUAL);

    }

    public void ReturnAuditory()
    {

        Return(DisorderButton.DisorderType.AUDITORY);

    }
    public void ReturnCognitive()
    {

        Return(DisorderButton.DisorderType.COGNITIVE);

    }


    public void Return(DisorderButton.DisorderType type)
    {

        List<MonoBehaviour> listToRemove = null;

        if (type == DisorderButton.DisorderType.AUDITORY)
        {

            listToRemove = activeAudioDisorders;

        }
        if (type == DisorderButton.DisorderType.VISUAL)
        {

            listToRemove = activeVisualDisorders;

        }
        if (type == DisorderButton.DisorderType.COGNITIVE)
        {
            listToRemove = activeCognitiveDisorders;

        }

        while (listToRemove.Count > 0)
        {
            listToRemove[0].enabled = false;
            listToRemove.RemoveAt(0);

        }
    }
}
