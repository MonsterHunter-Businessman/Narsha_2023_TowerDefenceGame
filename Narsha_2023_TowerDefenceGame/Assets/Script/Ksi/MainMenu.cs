using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text.RegularExpressions;

public class MainMenu : MonoBehaviour
{
    public int userLv = 1;
    public float userExp = 0;
    public TMP_Text UserLv;

    public Image TestImage;
    public Sprite[] TestSprite;

    public TMP_Text ExpText;
    public string[] testText = new string[3];

    public TMP_InputField playerNameInput;

    private int spriteIndex = 0;

    public TMP_Text tmp;


    public void ChangeCharacter(string direction)
    {
        if (direction == "Right")
        {
            Debug.Log("Right " + spriteIndex);
            spriteIndex = spriteIndex >= TestSprite.Length - 1 ? 0 : spriteIndex + 1;
            ExpText.text = testText[spriteIndex];
        }
        else if (direction == "Left")
        {
            Debug.Log("Left " + spriteIndex);
            spriteIndex = spriteIndex <= 0 ? TestSprite.Length - 1 : spriteIndex - 1;
            ExpText.text = testText[spriteIndex];
        }
        TestImage.GetComponent<Image>().sprite = TestSprite[spriteIndex];
    }

    public void GotoDeck()
    {
        Debug.Log("GotoDeck");
        //SceneManager.LoadScene("Deck");
    }

    public void ChangeUserName()
    {
        if(playerNameInput.GetComponent<TMP_InputField>().text == "")
        {
            Debug.Log("이름은 비워놓을 수 없습니다.");
            return;
        }
        tmp.text = playerNameInput.GetComponent<TMP_InputField>().text;
        playerNameInput.GetComponent<TMP_InputField>().text = "";
        Debug.Log("새로 바뀐 이름 : " + tmp.text);
    }

    public void CancleChangeName()
    {
        playerNameInput.GetComponent<TMP_InputField>().text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        ExpText.text = testText[spriteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
