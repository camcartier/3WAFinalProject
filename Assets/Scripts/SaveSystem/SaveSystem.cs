using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem 
{

    public static void SavePlayer(PlayerCurrentInfo playerCurrentInfo)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fishtreefile";
        FileStream stream = new FileStream(path, FileMode.Create);


        SaveData data = new SaveData(playerCurrentInfo);


        formatter.Serialize(stream, data);
        stream.Close();

    }


    public static SaveData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fishtreefile";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
;
        }
        else
        {
            Debug.LogError("save file not found in " + path);
            return null;
        }
    }

}
