


/*

files which need udpating in code:

- DataBaseManager.cs
- Data (change to state)
- ID (not needed now - delete but keep in GitHub, perhaps in a "Library folder")
- like in the Andre Lamothe book, let's have a Game Library 
- change Tokens.cs "Data" to "State"
- each time change something compare / change on github
- add Singleton.cs to a GameLibrary repo, also include a how to use example, probably with settings, and also tokens, and even state, because we will likely be reusing those in every game
- once DataBaseManager is configured include really easy to use steps, that can be bundled in other projects, and also include this in the Game Library
- probably would like some sort of easy invent system (maybe take the Corgi one) instead of rolling your own, and include that in the Game Library, the Corgi engine probably has other good stuffy to put in library, and even has their own game library


*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



/*

Steps from Here


1. Make sure what we have here compiles first

2. Add SceneManager

3. Figure out where the GetPoints() method is coming from near the SceneManager code

4. Determine where the BaseItemScript and ItemsCollection are?

5. Anything else?






note: JsonUtility is a built in class (https://docs.unity3d.com/ScriptReference/JsonUtility.html)

1000 JSON data objects take 1 second to load / download




the way of updating data:

this._gameData is an instace of of the GameData class

- so which class does AddOrUpdateItem belong to? because i didn't see that in the GameData class? SceneData! So then GameData returning SceneData somehow grants access to this method, that's fine, if we don't understand exactly we can still use this no problem

this._gameData.sceneData.AddOrUpdateItem(item.instanceId, item.itemData.id, item.GetPositionX(), item.GetPositionZ());

batch update can be found in SaveScene(), which iterates with the method AddOrUpdateItem() (that's the one that needs the scene manager)

Then we can turn that into JSON data with SaveDataBase() a method of DataBaseMAnager

- in the above we can get all the items in the scene with the SceneManager's method: GetAllItems()

- basically understand DataBaseManager and then the derived classes such as BaseItemScript and ItemsCollection, and any others



- now that we have a better grip of the 4 classes in this file, let's go BaseItemScript and ItemsCollection

- first where are they called here?

- BaseItemScript - line 264, needs Scene Manager, i don't believe we've imported that one yet -- should be able to use Scene Manager with no conflicts
 
- The Scene Manager has what allows to GetAllItems()

- BaseItemScript.cs is the data script every item gets

- ItemsCollection.cs seems like the parent script

*/




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
and sceneData is our instance of our data

*/

// so the main way is to define SceneData (research this?) and type as DataBaseManager.instance


// needs BaseItemScript to operate

/*

4 classes 


ItemData - the essential 4 data features: instance ID, item ID, position x, and position z
SceneData - holds scene item data 
GameData - one liner simple class - returns one instance of SceneData - perhaps written this way to be expandable to other types of data


DataBaseManager - main class, which derives from MonoBehaviour


so now we need to add SceneManager - perhaps that will also correct the missing positions for the code below





*/


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

    private string gameDataFilePath = "/GameData/db.json"; // will return error if not properly created in the other class, did we name this GameData?
    
    private GameData _gameData;


    // this is what the actual data looks like!

    private string _defaultSceneData =
        "{\"items\":[" + 
        "{\"instanceId\":1,\"itemId\":3635,\"posX\":37,\"posZ\":19}," +
        "{\"instanceId\":25391,\"itemId\":5341,\"posX\":24,\"posZ\":40}]}";

       
    private string _enemySceneData =
        "{\"items\":[" +
        "{\"instanceId\":2,\"itemId\":2496,\"posX\":22,\"posZ\":22}," +
        "{\"instanceId\":31911,\"itemId\":3265,\"posX\":12,\"posZ\":12}]}";


    // make sure the data is there

    void Awake()
    {
        instance = this;
        this.EnsureGameDataFileExists();
    }

    // we should probably just have a string which is the path name instead of all these hardcoded references

    // what if we keep overriding data because we don't have the sring names right?

    public void EnsureGameDataFileExists()
    {

        // game data

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

            // here is the main line of getting our data 

            this._gameData = JsonUtility.FromJson<GameData>(jsonData);
        }
        else
        {
            this.SaveDataBase();
        }
    }

    public SceneData GetScene()
    {
        if (this._gameData.sceneData.items.Count == 0)  // what is this? do we just automatically assume we are not in a saved game with 0 items in the scene? could this conflict with anything?
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
        // this.SaveDataBase(); //  needs get positions corrected - in which file is GetPositions()?
    }

    public void RemoveItem(BaseItemScript item)
    {
        // this._gameData.sceneData.RemoveItem(item.instanceId);
        // this.SaveDataBase(); // needs get positions corrected - in which file is GetPositions()?
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
