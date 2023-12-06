using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCostumeManager : MonoBehaviour
{
    // Пока что будут магические цифры, потом можно будет переехать на Enum или Transform
    // но тут нужно будет потыкаться что будет лучше

    [SerializeField] private Dictionary<int, CostumePartData> costumeDataDictionary =
    new Dictionary<int, CostumePartData>
    {
        { 1 , new CostumePartData(0, Color.white) },
        { 2 , new CostumePartData(0, Color.white) },
        { 3 , new CostumePartData(0, Color.white) },
        { 4 , new CostumePartData(0, Color.white) },
        { 5 , new CostumePartData(0, Color.white) },
        { 6 , new CostumePartData(0, Color.white) },
        { 7 , new CostumePartData(0, Color.white) },
    };
    [SerializeField] private List<SpriteRenderer> costumePartSpriteRend;
    [SerializeField] private Sprite testSprite;

    public void SetNewCostumePart(int partID, CostumePartData costumePartData)
    {
        // Debug.Log("SetNewCostumePart");

        costumeDataDictionary[partID] = costumePartData;
    }

    private void ChangePlayerVisual()
    {
        for (int i = 0; i < costumePartSpriteRend.Count; i++)
        {
            costumePartSpriteRend[i].color  = costumeDataDictionary[i].costumePartSpriteColor;
            costumePartSpriteRend[i].sprite = GetSpriteByID(costumeDataDictionary[i].costumePartSpriteID);
        }
    }
    // заглушка
    private Sprite GetSpriteByID(int id)
    {
        Debug.Log($"Must return sprite with {id} id");
        return testSprite;
    }
}
