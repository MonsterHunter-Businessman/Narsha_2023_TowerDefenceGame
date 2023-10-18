using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private UserData _userData;

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

    void SaveUserData()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/userdata.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, _userData);
        file.Close();
    }

    void LoadUserData()
    {
        if (File.Exists(Application.persistentDataPath + "/userdata.dat"))
        {
            FileStream file = new FileStream(Application.persistentDataPath + "/userdata.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            _userData = (UserData)bf.Deserialize(file);
            file.Close();
        }
        else //catch (FileNotFoundException e)
        {
            _userData = new UserData();
        }
    }
    [Serializable]
    public class UserData
    {
        public string Name;
        public int UserLv;
        public int clearStage;
    }

}

