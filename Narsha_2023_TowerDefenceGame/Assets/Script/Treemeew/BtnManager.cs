using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum Btntype
{
    None,
    Start,
    Quit,
    accept,
    SaveInfo
}

public class BtnManager : MonoBehaviour
{
/*    public GameObject Popup;
    public GameObject Panel;*/
    public Btntype Currenttype;
    public Cards card;
    private DeckManager deckManager;
    private int cardIndex;

    private void Awake()
    {
        deckManager = FindObjectOfType<DeckManager>();
    }

void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartPage" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("시작화면임ㅇㅇ");
            SceneLoad.LoadScene("MainMenu");
        }    

    
    }

    public void OnBtnClick()
    {



        switch (Currenttype)
        {
            case Btntype.Start:
                SceneLoad.LoadScene("ReadyScene");
                Debug.Log("넘어갑니다");
                break;

            case Btntype.Quit:
                Debug.Log("종료합니다");
                Application.Quit();
                break;

            case Btntype.accept:
 
                SceneLoad.LoadScene("InGame"); 
                break;
            case Btntype.SaveInfo:
                GameDataManager.Instance.PlayerInfoSave();
                break;

            case Btntype.None:
                Debug.Log("실행함");
                break;
        }
    }
}
