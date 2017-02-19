using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    [SerializeField] private SteamVR_TrackedObject controller;

    SteamVR_Controller.Device device;

    private LineRenderer raycastRenderer;

	// Use this for initialization
	void Start () {

        raycastRenderer = GetComponent<LineRenderer>();

	}

    // Update is called once per frame
    void Update() {

        raycastRenderer.SetPosition(0, transform.position);

        device = SteamVR_Controller.Input((int)controller.index);

        Ray raycastRay = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        Debug.DrawRay(raycastRay.origin, raycastRay.direction * 1000);

        if (Physics.Raycast(raycastRay, out hitInfo, Mathf.Infinity))
        {

            raycastRenderer.SetPosition(1, hitInfo.point);

            DisorderButton hitButton = hitInfo.collider.GetComponent<DisorderButton>();

            if (hitButton != null)
            {

                SetRaycastActive(true);

                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {

                    hitButton.ActivateButton();


                }
            }
            else
            {
                SetRaycastActive(false);

            }
        }
        else
        {

            raycastRenderer.SetPosition(1, transform.forward * 1000);
            SetRaycastActive(false);
        }
	}

    public void SetRaycastActive(bool active)
    {

        Color curColor = raycastRenderer.material.color;
        float alpha = curColor.a;

        if (active)
        {

            curColor = Color.blue;

        }
        else
        {

            curColor = Color.gray;

        }

        curColor.a = alpha;

        raycastRenderer.material.SetColor("_Color", curColor);

    }
}
