using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] canvas;

    public static int OpenLevel;

    [SerializeField] private int sceneNum;

    [SerializeField] private Button[] changeButton;
    [SerializeField] private Button startButton;

    void Start()
    {
        OpenLevel = 0;
        OpenLevel = PlayerPrefs.GetInt("OpenLevel");
        if(OpenLevel == 0)
        {
            OpenLevel = 0;
            PlayerPrefs.SetInt("OpenLevel", 0);
        }
        sceneNum = 1;
        for (int i = 0; i < changeButton.Length; i++)
        {
            if (i>OpenLevel)
            {
                changeButton[i].interactable = false;
            }
        }
    }

    public void ChangeCanvas (int num)
    {
        for (int i = 0; i < canvas.Length; i++)
        {
            if(i!=num)
            {
                canvas[i].SetActive(false);
            }
        }

        canvas[num].SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeScene (int num)
    {
        changeButton[sceneNum-1].interactable = true;
        sceneNum = num;
        changeButton[sceneNum-1].interactable = false;
        startButton.interactable = true;
    }

    public void StartScene ()
    {
        SceneManager.LoadScene(sceneNum);
    }


}
