using UnityEngine;

[System.Serializable]
public struct CostumePartData 
{
    public CostumePartData(int costumePartSpriteID, Color costumePartSpriteColor)
    {
        this.costumePartSpriteID    = costumePartSpriteID;
        this.costumePartSpriteColor = costumePartSpriteColor;
    }

    public int      costumePartSpriteID;
    public Color    costumePartSpriteColor;
}
