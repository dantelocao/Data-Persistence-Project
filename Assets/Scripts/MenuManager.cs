using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public void SetPlayerName()
    {
        // Buscar o InputField diretamente pelo nome do GameObject
        InputField inputField = GameObject.Find("PlayerInput").GetComponent<InputField>();

        // Acessar o texto digitado
        string inputText = inputField.text;
        //Debug.Log("Texto digitado: " + inputText);

        ScenesDataManager.instance.playerName = inputText;

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }

}
