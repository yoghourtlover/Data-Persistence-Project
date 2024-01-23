using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField NameInputField;
    bool canStartGame;
    // Start is called before the first frame update
    void Start()
    {
        NameInputField.onEndEdit.AddListener(delegate { checkName(NameInputField); });
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
    //Check the validity of the name
    public void checkName(TMP_InputField name)
    {
        if (name.text.Length == 0)
        {
            Debug.Log("Please enter your name");
            canStartGame = false;
        }
        else if (name.text.Length < 3)
        {
            Debug.Log("Please enter more than two characters");
            canStartGame = false;
        }
        else
        {
            canStartGame = true;
            DataManager.Instance.PlayerName = name.text;
        }
    }
    public void startGame()
    {
        if(canStartGame)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Incorrect input content");
        }

    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
