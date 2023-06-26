using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class DataHandler
{
    private static string dirPath = "D:\\"; /*Application.persistentDataPath*/
    private static string dirFileName = "data";

    public static void Save(CharacterData data)
    {
        string fullPath = Path.Combine(dirPath, dirFileName);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
        string dataStore = JsonUtility.ToJson(data, true);

        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(dataStore);
            }
        }
        Debug.Log("Uspeh");
    }

    public static CharacterData Load()
    {
        string fullPath = Path.Combine(dirPath, dirFileName);
        string data;

        using (FileStream stream = new FileStream(fullPath, FileMode.Open))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                data = reader.ReadToEnd();
            }
        }
        CharacterData returnData = JsonUtility.FromJson<CharacterData>(data);
        return returnData;
    }
}
