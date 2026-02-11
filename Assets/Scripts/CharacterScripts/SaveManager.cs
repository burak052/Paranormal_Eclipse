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

    string savePath;

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

        savePath = Application.persistentDataPath + "/save.json";
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
            generator = gen
        };

        File.WriteAllText(savePath, JsonUtility.ToJson(CurrentSaveData, true));
    }


    // OYUN VAR MI?
    public bool HasSave()
    {
        return File.Exists(savePath);
    }

    // OYUNU Y�KLE
    public SaveData LoadGame()
    {
        if (!HasSave()) return null;
        IsLoadingFromSave = true;

        string json = File.ReadAllText(savePath);
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
    }


}