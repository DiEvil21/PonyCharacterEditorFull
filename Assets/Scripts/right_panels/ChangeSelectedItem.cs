using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSelectedItem : MonoBehaviour
{
    public Image[] icons;
    public Sprite active;
    public Sprite defaultSprite;
    
    // А зачем так?
    void Start()
    {
        
    }
   
    // А зачем так?
    private void OnDisable()
    {
        // Remove your listener code here
        
    }
    // А зачем так?
    // Update is called once per frame
    void Update()
    {
        
    }
    // А зачем так?
    public void ChangeActiveBtn(int id)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].GetComponent<Image>().sprite = defaultSprite;
        }
        icons[id].GetComponent<Image>().sprite = active;
    }

}
