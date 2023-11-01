using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance = null;
    string path;
    public UserData _userData = new UserData();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadUserData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveUserData(string Name, int userLv, int clearStage, int charaIdx)
    {
        _userData.Name = Name;
        _userData.UserLv = userLv;
        _userData.clearStage = clearStage;
        _userData.charaIdx = charaIdx;
        path = Application.dataPath + "/Resources/Json/UserData.Json";
        string json = JsonUtility.ToJson(_userData);
        Debug.Log(json);

        FileStream file = new FileStream(path, FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(json);
        file.Write(data, 0, data.Length);
        file.Close();
        LoadUserData();
    }

    public void LoadUserData()
    {
        path = Application.dataPath + "/Resources/Json/UserData.Json";
        FileStream file = new FileStream(path, FileMode.Open);
        byte[] data = new byte[file.Length];
        file.Read(data, 0, data.Length);
        file.Close();
        string json = Encoding.UTF8.GetString(data);

        _userData = JsonUtility.FromJson<UserData>(json);
    }

}


[Serializable]
public class UserData
{
    public string Name;
    public int UserLv;
    public int clearStage;
    public int charaIdx;
}