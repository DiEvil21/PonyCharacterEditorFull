using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Чем отличается от AnchorsActivator
public class SelfAnchorActivator : MonoBehaviour
{
    CharacterInfo characterInfo;
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
        characterInfo = GameObject.FindGameObjectWithTag("character").GetComponent<CharacterInfo>();
    }
    // А зачем так?
    public void ActivateAnchors()
    {
        GetComponentInParent<ScrollAreaController>().anchor.SetActive(true);
        if (GetComponentInParent<ScrollAreaController>().anchorForDelete != null) 
        {
            GetComponentInParent<ScrollAreaController>().anchorForDelete.SetActive(false);
        }
        

    }

    private void OnClick()
    {
        Debug.Log("Clicked on self");

        ActivateAnchors();
    }
}

