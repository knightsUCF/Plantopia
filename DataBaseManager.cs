using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


// basically understand DataBaseManager and then the derived classes such as BaseItemScript and ItemsCollection, and any others


// from cityopoly codebase in email

// what does an item have? an id? position?

/*
[System.Serializable]
public class ItemData
{
    public int instanceId;
    public int itemId;
    public int posX;
    public int posZ;

    // let's add a y also
    public int posY; // pk 

    // and why is this in integers? where is the conversion to float world space?
}

*/

// perhaps figure out what constitutes an item and then change to "object" or "thing"

// or split up into separate plant class, but that might be too much and going against thef lat stle



// calling in DataBaseManager.cs?
/*
DataBaseManager.instance.UpdateItemData(this);
DataBaseManager.instance.RemoveItem(SceneManager.instance.selectedItem);
DataBaseManager.instance.UpdateItemData (item);


SceneData sceneData = DataBaseManager.instance.GetScene();
SceneData sceneData = DataBaseManager.instance.GetEnemyScene();

so the GetScene() method in DataBaseManager.cs is our entry point

*/

// so the main way is to define SceneData (research this?) and type as DataBaseManager.instance


// needs BaseItemScript to operate




[System.Serializable]
public class ItemData
{
    public int instanceId;
    public int itemId;
    public int posX;
    public int posZ;
}





[System.Serializable]
public class SceneData
{
    public List<ItemData> items;

    public SceneData()
    {
        items = new List<ItemData>();
    }

    public void AddOrUpdateItem(int instanceId, int itemId, int posX, int posZ)
    {
        ItemData itemData = null;
        foreach (ItemData item in this.items)
        {
            if (item.instanceId == instanceId)
            {
                itemData = item;
            }
        }

        if (itemData == null)
        {
            itemData = new ItemData();
            itemData.instanceId = instanceId;
            itemData.itemId = itemId;
            this.items.Add(itemData);
        }

        itemData.posX = posX;
        itemData.posZ = posZ;
    }

    public void RemoveItem(int instanceId)
    {
        ItemData targetItem = this.GetItem(instanceId);

        if (targetItem != null)
        {
            this.items.Remove(targetItem);
        }
    }

    public ItemData GetItem(int instanceId)
    {
        ItemData targetItem = null;
        foreach (ItemData itemData in this.items)
        {
            if (itemData.instanceId == instanceId)
            {
                targetItem = itemData;
            }
        }
        return targetItem;
    }
}





[System.Serializable]
public class GameData
{
    public SceneData sceneData;
}




public class DataBaseManager : MonoBehaviour
{

    public static DataBaseManager instance;

    private string gameDataFilePath = "/StreamingAssets/db.json";
    private GameData _gameData;

    private string _defaultSceneData =
        "{\"items\":[" + 
        "{\"instanceId\":1,\"itemId\":3635,\"posX\":37,\"posZ\":19}," +
        "{\"instanceId\":25391,\"itemId\":5341,\"posX\":24,\"posZ\":40}]}";

       
    private string _enemySceneData =
        "{\"items\":[" +
        "{\"instanceId\":2,\"itemId\":2496,\"posX\":22,\"posZ\":22}," +
        "{\"instanceId\":31911,\"itemId\":3265,\"posX\":12,\"posZ\":12}]}";

    void Awake()
    {
        instance = this;
        this.EnsureGameDataFileExists();
    }

    public void EnsureGameDataFileExists()
    {
        this._gameData = new GameData();
        this._gameData.sceneData = new SceneData();

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            return;
        }

        string filePath = Application.persistentDataPath + gameDataFilePath;
        string directoryPath = Application.persistentDataPath + "/StreamingAssets";

        if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.LinuxEditor)
        {
            filePath = Application.dataPath + gameDataFilePath;
            directoryPath = Application.dataPath + "/StreamingAssets";
        }

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            this._gameData = JsonUtility.FromJson<GameData>(jsonData);
        }
        else
        {
            this.SaveDataBase();
        }
    }

    public SceneData GetScene()
    {
        if (this._gameData.sceneData.items.Count == 0)
        {
            this._gameData.sceneData = JsonUtility.FromJson<SceneData>(this._defaultSceneData);
            this.SaveDataBase();
        }
        return this._gameData.sceneData;
    }

    public SceneData GetEnemyScene()
    {
        SceneData sceneData = JsonUtility.FromJson<SceneData>(this._enemySceneData);
        return sceneData;
    }

    /* needs SceneManager
    public void SaveScene()
    {
        foreach (BaseItemScript item in SceneManager.instance.GetAllItems())
        {
            this._gameData.sceneData.AddOrUpdateItem(item.instanceId, item.itemData.id, item.GetPositionX(), item.GetPositionZ());
        }
        this.SaveDataBase();
    }
    */

    public void UpdateItemData(BaseItemScript item)
    {
        // this._gameData.sceneData.AddOrUpdateItem(item.instanceId, item.itemData.id, item.GetPositionX(), item.GetPositionZ());
        // this.SaveDataBase(); //  needs get positions corrected
    }

    public void RemoveItem(BaseItemScript item)
    {
        // this._gameData.sceneData.RemoveItem(item.instanceId);
        // this.SaveDataBase(); // needs get positions corrected 
    }

    public void SaveDataBase()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            return;
        }

        string filePath = Application.persistentDataPath + gameDataFilePath;

        if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.LinuxEditor)
        {
            filePath = Application.dataPath + gameDataFilePath;
        }

        string jsonData = JsonUtility.ToJson(this._gameData);
        File.WriteAllText(filePath, jsonData);
    }


}

