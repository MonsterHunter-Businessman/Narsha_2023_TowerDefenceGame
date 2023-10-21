using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text.RegularExpressions;

public class MainMenu : MonoBehaviour
{
    public int userLv = 2;
    public float userExp = 0;
    public TMP_Text UserLv;

    public Image CharaImg;
    public Sprite[] CharaSprite;

    public Image CharaDes;
    public Sprite[] DesSprite;

    public TMP_InputField playerNameInput;

    public int spriteIndex = 0;

    public TMP_Text tmp;

    public TMP_Text userName;

    SaveManager save = new SaveManager();


    public void ChangeCharacter(string direction)
    {
        if (direction == "Right")
        {
            Debug.Log("Right " + spriteIndex);
            spriteIndex = spriteIndex >= CharaSprite.Length - 1 ? 0 : spriteIndex + 1;
        }
        else if (direction == "Left")
        {
            Debug.Log("Left " + spriteIndex);
            spriteIndex = spriteIndex <= 0 ? CharaSprite.Length - 1 : spriteIndex - 1;
        }
        CharaImg.GetComponent<Image>().sprite = CharaSprite[spriteIndex];
        CharaDes.GetComponent<Image>().sprite = DesSprite[spriteIndex];
        save.SaveUserData(tmp.text, userLv, 0, spriteIndex);

    }

    public void GotoDeck()
    {
        SceneManager.LoadScene("Deck");
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
        userName.text = tmp.text;
        save.SaveUserData(tmp.text, userLv, 0, spriteIndex);
    }

    public void CancleChangeName()
    {
        playerNameInput.GetComponent<TMP_InputField>().text = "";
    }


    // Start is called before the first frame update
    void Start()
    {
        /*tmp.text = SaveManager.instance._userData.Name;*/
        userLv = SaveManager.instance._userData.UserLv;
        UserLv.text = userLv.ToString();
        tmp.text = SaveManager.instance._userData.Name;
        userName.text = tmp.text;
        spriteIndex = SaveManager.instance._userData.charaIdx;
        CharaImg.GetComponent<Image>().sprite = CharaSprite[spriteIndex];
        CharaDes.GetComponent<Image>().sprite = DesSprite[spriteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
