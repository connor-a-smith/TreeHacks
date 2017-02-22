using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisorderSystem : MonoBehaviour {

    public static DisorderSystem instance;

    public GameObject cameraParent;
    public GameObject earObject;

    private List<Behaviour> activeVisualDisorders;
    private List<Behaviour> activeCognitiveDisorders;
    private List<Behaviour> activeAudioDisorders;

    [SerializeField]
    private SkinnedMeshRenderer leftPersonRenderer;

    [SerializeField]
    private Object leftPersonBlankFace;

    [SerializeField]
    private SkinnedMeshRenderer rightPersonRenderer;

    [SerializeField]
    private Object rightPersonBlankFace;

    [SerializeField]
    private GameObject tinnitusSource;


    private Object correctLeftFace;
    private Object correctRightFace;

    public void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {

        activeVisualDisorders = new List<Behaviour>();
        activeCognitiveDisorders = new List<Behaviour>();
        activeAudioDisorders = new List<Behaviour>();

        correctLeftFace = leftPersonRenderer.material.mainTexture;
        correctRightFace = rightPersonRenderer.material.mainTexture;
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

    public void Protanopia()
    {
        foreach (ColorBlindFilter filter in cameraParent.GetComponentsInChildren<ColorBlindFilter>())
        {
            activeVisualDisorders.Add(filter);
            filter.mode = ColorBlindMode.Protanopia;
            filter.enabled = true;
        }
    }

    public void Deuteranopia()
    {
        foreach (ColorBlindFilter filter in cameraParent.GetComponentsInChildren<ColorBlindFilter>())
        {
            activeVisualDisorders.Add(filter);
            filter.mode = ColorBlindMode.Deuteranopia;
            filter.enabled = true;
        }
    }

    public void Tritanopia()
    {
        foreach (ColorBlindFilter filter in cameraParent.GetComponentsInChildren<ColorBlindFilter>())
        {
            activeVisualDisorders.Add(filter);
            filter.mode = ColorBlindMode.Tritanopia;
            filter.enabled = true;
        }
    }



    public void PartialBlindness()
    {

        int random = Random.Range(0, 2);

        UnityStandardAssets.ImageEffects.BlurOptimized comp = cameraParent.GetComponentsInChildren<UnityStandardAssets.ImageEffects.BlurOptimized>()[random];

        activeVisualDisorders.Add(comp);
        comp.enabled = true;



    }

    public void Prosopagnosia()
    {

        leftPersonRenderer.material.mainTexture = (Texture)leftPersonBlankFace;
        rightPersonRenderer.material.mainTexture = (Texture)rightPersonBlankFace;

    }

    public void LegalBlindness()
    {

        foreach (UnityStandardAssets.ImageEffects.BlurOptimized comp in cameraParent.GetComponentsInChildren<UnityStandardAssets.ImageEffects.BlurOptimized>())
        {
            activeVisualDisorders.Add(comp);
            comp.enabled = true;
        }
    }

    public void PanicAttack()
    {

        foreach (UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration comp in cameraParent.GetComponentsInChildren<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>()) 
        {
            activeCognitiveDisorders.Add(comp);
            comp.enabled = true;
        }

        GetComponent<AudioSource>().enabled = true;
        GetComponent<AudioSource>().Play();
        activeCognitiveDisorders.Add(GetComponent<AudioSource>());

        cameraParent.GetComponent<Animator>().enabled = true;
        cameraParent.GetComponent<Animator>().Play("PanicAnimation");
        activeCognitiveDisorders.Add(cameraParent.GetComponent<Animator>());

    }

    public void Deafness()
    {
        AudioLowPassFilter filter = earObject.GetComponent<AudioLowPassFilter>();

        activeAudioDisorders.Add(filter);
        filter.enabled = true;
    }

    public void Tinnitus()
    {
        AudioSource source = tinnitusSource.GetComponent<AudioSource>();

        activeAudioDisorders.Add(source);
        source.enabled = true;
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

        List<Behaviour> listToRemove = null;

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

            leftPersonRenderer.material.mainTexture = (Texture)correctLeftFace;
            rightPersonRenderer.material.mainTexture = (Texture)correctRightFace;

        }

        while (listToRemove.Count > 0)
        {
            listToRemove[0].enabled = false;
            listToRemove.RemoveAt(0);

        }
    }
}
