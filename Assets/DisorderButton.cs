using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DisorderButton : MonoBehaviour {

    [SerializeField]
    private bool isReturnButton;

    [SerializeField]
    private GameObject selectionMenu;

    [SerializeField]
    private GameObject disorderMenu;

    [SerializeField]
    private Text disorderTitle;

    [SerializeField]
    private Text disorderText;

    [SerializeField]
    private string disorderName;

    [SerializeField]
    private string disorderDescription;

    [SerializeField]
    private UnityEvent eventOnSelect;



	// Use this for initialization
	void Start () {
		



	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateButton()
    {

        if (isReturnButton)
        {

            disorderMenu.SetActive(false);
            selectionMenu.SetActive(true);

        }
        else
        {
            selectionMenu.SetActive(false);
            disorderMenu.SetActive(true);
            disorderTitle.text = disorderName;
            disorderText.text = disorderDescription;
        }

        if (eventOnSelect != null)
        {
            eventOnSelect.Invoke();
        }
    }
}
