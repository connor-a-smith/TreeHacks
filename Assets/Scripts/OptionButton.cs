using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour {

    [SerializeField]
    private Animator screenAnimator;

    [SerializeField]
    private Animator buttonAnimator;

    [SerializeField]
    private bool useColliders = true;

    private bool screenOpen = false;

    public void PressButton()
    {
        buttonAnimator.Play("ButtonPress");

        if (!screenOpen)
        {
            screenAnimator.Play("ScreenOpen");
        }
        else
        {
            screenAnimator.Play("ScreenClose");
        }

        screenOpen = !screenOpen;

    }

    public void ReleaseButton()
    {

        buttonAnimator.Play("ButtonRelease");

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Selector>())
        {
            PressButton();
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Selector>())
        {
            ReleaseButton();
        }

    }
}
