using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyPeasyFirstPersonController;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public SaveData CurrentSaveData { get; private set; }

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
    public void SaveGame(Transform playerTransform)
    {
        CurrentSaveData = new SaveData
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex,
            posX = playerTransform.position.x,
            posY = playerTransform.position.y,
            posZ = playerTransform.position.z
        };

        File.WriteAllText(savePath, JsonUtility.ToJson(CurrentSaveData, true));
    }


    // OYUN VAR MI?
    public bool HasSave()
    {
        return File.Exists(savePath);
    }

    // OYUNU YÜKLE
    public SaveData LoadGame()
    {
        if (!HasSave()) return null;

        string json = File.ReadAllText(savePath);
        return JsonUtility.FromJson<SaveData>(json);
    }
   
    public class SaveData
    {
        public int sceneIndex;
        public float posX, posY, posZ;
        public string checkpointID;
    }


}