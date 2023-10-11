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
    SaveInfo,
    ReStart,
    Main
}

public class BtnManager : MonoBehaviour
{
/*    public GameObject Popup;
    public GameObject Panel;*/
    public Btntype Currenttype;
    public Cards card;


    private int cardIndex;

    void Start()
    {

        if (card != null) {
            cardIndex = (int)card.TowerCard;
        }

        // Popup.SetActive(false);
    }

    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "StartPage" && Input.GetMouseButtonDown(0))
        {
            SceneLoad.LoadScene("MainMenu");
        }

       
    }

    public void OnBtnClick()
    {



        switch (Currenttype)
        {
            case Btntype.Start:
                SceneLoad.LoadScene("OneStage");
                break;

            case Btntype.Quit:
                Application.Quit();
                break;

            case Btntype.accept:
                break;

            case Btntype.SaveInfo:
                GameDataManager.Instance.PlayerInfoSave();
                break;

            case Btntype.ReStart:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1f;
                break;

            case Btntype.Main:
                SceneLoad.LoadScene("MainMenu");
                Time.timeScale = 1f;
                break;


            case Btntype.None:
                break;
        }
    }
}
