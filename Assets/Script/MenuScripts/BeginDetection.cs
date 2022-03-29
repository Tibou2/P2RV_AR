using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class BeginDetection : MonoBehaviour
{
    public GameObject GuideView;
    public GameObject ToggleButton;

    public void BeginDetectionWithThisGuide()
    {
        if (GameObject.FindGameObjectWithTag("GuideView") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("GuideView").gameObject);
        }
        Instantiate(GuideView);
    }

    public void ActivateToogleButton()
    {
        if (ToggleButton.activeSelf == false)
        {
            ToggleButton.SetActive(true);
        }
        ToggleButton.GetComponent<Interactable>().IsToggled = true;
    }

    public void StopDetection()
    {
        Destroy(GameObject.FindGameObjectWithTag("GuideView").gameObject);
    }
}
