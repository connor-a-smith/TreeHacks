using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {

    [SerializeField]
    private OptionButton testButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(0))
        {

            testButton.PressButton();            
        }

        if (Input.GetMouseButtonUp(0))
        {


            testButton.ReleaseButton();


        }
		
	}
}
