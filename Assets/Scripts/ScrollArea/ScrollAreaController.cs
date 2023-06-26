using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollAreaController : MonoBehaviour
{
    public Sprite activeSprite;
    public Sprite defaultSprite;
    public Sprite defaultDeleteSprite;
    public GameObject delete_img;
    public GameObject item_icon;
    public GameObject anchor;
    public Sprite[] sprites_arr;
    public GameObject[] prefabs_arr;
    public Material mat;
    public GameObject anchorForDelete;
    void Start()
    {
        generateIcons(sprites_arr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateIcons(Sprite[] arr) 
    {
        for (int i = 0; i < gameObject.transform.childCount; i++) 
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
        GameObject delete_icon = Instantiate(delete_img);
        delete_icon.GetComponent<ItemIdCounter>().setId(999);
        delete_icon.transform.SetParent(transform, false);
        for (int i = 0; i < arr.Length; i++) 
        {
            GameObject icon = Instantiate(item_icon);
            icon.GetComponent<ItemIdCounter>().setId(i);
            icon.transform.GetChild(0).GetComponent<Image>().sprite = arr[i];
            icon.transform.GetChild(0).GetComponent<Image>().material = mat;
            icon.transform.SetParent(transform, false);
        }
    }

    public void spawnHair(int ID) 
    {   

        if (ID == 999)
        {
            if (anchor.transform.childCount > 0)
            {
                Object.Destroy(anchor.transform.GetChild(0).gameObject);
                for (int i = 1; i < transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<Image>().sprite = defaultSprite;
                }
                transform.GetChild(0).GetComponent<Image>().sprite = defaultDeleteSprite;
                CharacterInfo.anchorDict[anchor] = null;
            }
        }
        else 
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = defaultSprite;
            }
            transform.GetChild(0).GetComponent<Image>().sprite = defaultDeleteSprite;
            transform.GetChild(ID + 1).GetComponent<Image>().sprite = activeSprite;

            if (anchor.transform.childCount > 0)
            {
                Object.Destroy(anchor.transform.GetChild(0).gameObject);
            }
            GameObject hair = Instantiate(prefabs_arr[ID]);
            CharacterInfo.anchorDict[anchor] = prefabs_arr[ID].GetComponent<ItemUID>().id;
            if (hair.name.Contains("mask") && anchorForDelete != null)
            {
                if (anchorForDelete.transform.childCount > 0) 
                {   
                    if (anchorForDelete.transform.GetChild(0).gameObject.name.Contains("hair"))
                    Object.Destroy(anchorForDelete.transform.GetChild(0).gameObject);
                }
               
            }
            if (hair.name.Contains("hair") && anchorForDelete != null)
            {
                if (anchorForDelete.transform.childCount > 0)
                {
                    if (anchorForDelete.transform.GetChild(0).gameObject.name.Contains("mask"))
                    Object.Destroy(anchorForDelete.transform.GetChild(0).gameObject);
                }

            }
            hair.transform.SetParent(anchor.transform, false);
        }
        
    }
}
