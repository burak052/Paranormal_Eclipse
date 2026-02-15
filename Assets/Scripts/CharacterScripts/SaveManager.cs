using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using EasyPeasyFirstPersonController;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public SaveData CurrentSaveData { get; private set; }
    public bool IsLoadingFromSave { get; set; }

    string savePath1,savePath2,savePath3,savePath4,savePath5,savePath6,savePath7;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        savePath1 = Application.persistentDataPath + "/save1.json";
        savePath2 = Application.persistentDataPath + "/save2.json";
        savePath3 = Application.persistentDataPath + "/save3.json";
        savePath4 = Application.persistentDataPath + "/save4.json";
        savePath5 = Application.persistentDataPath + "/save5.json";
        savePath6 = Application.persistentDataPath + "/save6.json";
        savePath7 = Application.persistentDataPath + "/save7.json";
    }

    // OYUNU KAYDET
    public void SaveGame(Transform playerTransform, int checkID, List<int> owned, bool gen = false)
    {
        CurrentSaveData = new SaveData
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex,
            posX = playerTransform.position.x,
            posY = playerTransform.position.y,
            posZ = playerTransform.position.z,
            checkpointID = checkID,
            ownedItemIDs = owned,
            generator = gen,
            saveDateTime = System.DateTime.Now.ToString("dd.MM.yyyy HH:mm")
        };

        if(checkID == 1)
            File.WriteAllText(savePath1, JsonUtility.ToJson(CurrentSaveData, true));
        if(checkID == 2)
            File.WriteAllText(savePath2, JsonUtility.ToJson(CurrentSaveData, true));
        if(checkID == 3)
            File.WriteAllText(savePath3, JsonUtility.ToJson(CurrentSaveData, true));
        if(checkID == 4)
            File.WriteAllText(savePath4, JsonUtility.ToJson(CurrentSaveData, true));
        if(checkID == 5)
            File.WriteAllText(savePath5, JsonUtility.ToJson(CurrentSaveData, true));
        if(checkID == 6)
            File.WriteAllText(savePath6, JsonUtility.ToJson(CurrentSaveData, true));
        if(checkID == 7)
            File.WriteAllText(savePath7, JsonUtility.ToJson(CurrentSaveData, true));
    }

    public void DeletePaths()
    {
        if(File.Exists(savePath1))
            File.Delete(savePath1);
        if(File.Exists(savePath2))
            File.Delete(savePath2);
        if(File.Exists(savePath3))
            File.Delete(savePath3);
        if(File.Exists(savePath4))
            File.Delete(savePath4);
        if(File.Exists(savePath5))
            File.Delete(savePath5);
        if(File.Exists(savePath6))
            File.Delete(savePath6);
        if(File.Exists(savePath7))
            File.Delete(savePath7);
    }

    // OYUN VAR MI?
    public bool HasSave()
    {
        return File.Exists(savePath1);
    }

    // OYUNU Y�KLE
    public SaveData LoadGame(int id)
    {
        if (!HasSave()) return null;
        string json;
        if(id == 1)
            json = File.ReadAllText(savePath1);
        else if(id == 2)
            json = File.ReadAllText(savePath2);
        else if(id == 3)
            json = File.ReadAllText(savePath3);
        else if(id == 4)
            json = File.ReadAllText(savePath4);
        else if(id == 5)
            json = File.ReadAllText(savePath5);
        else if(id == 6)
            json = File.ReadAllText(savePath6);
        else
            json = File.ReadAllText(savePath7);
        CurrentSaveData = JsonUtility.FromJson<SaveData>(json);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public SaveData LastGame()
    {
        if (!HasSave()) return null;
        string json;
        if(File.Exists(savePath7))
            json = File.ReadAllText(savePath7);
        else if(File.Exists(savePath6))
            json = File.ReadAllText(savePath6);
        else if(File.Exists(savePath5))
            json = File.ReadAllText(savePath5);
        else if(File.Exists(savePath4))
            json = File.ReadAllText(savePath4);
        else if(File.Exists(savePath3))
            json = File.ReadAllText(savePath3);
        else if(File.Exists(savePath2))
            json = File.ReadAllText(savePath2);
        else
            json = File.ReadAllText(savePath1);

        CurrentSaveData = JsonUtility.FromJson<SaveData>(json);
        return JsonUtility.FromJson<SaveData>(json);
    }
   
    public class SaveData
    {
        public int sceneIndex;
        public float posX, posY, posZ;
        public int checkpointID;
        public List<int> ownedItemIDs;
        public bool generator;
        public string saveDateTime;
    }


}