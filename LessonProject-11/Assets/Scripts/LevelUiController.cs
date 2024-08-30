using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelUiController : MonoBehaviour
{
    bool go;

    Image obj;

    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private Sprite[] timeType;

    [SerializeField] private GameObject plate;
    void Start()
    {
        if(levelText!=null)
        {
            LevelText();
            go = true;
            obj = GetComponent<Image>();
        }
        
    }

    public void Click ()
    {
        plate.SetActive (go);
        go = !go;
        if (go)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        
        obj.sprite = timeType[Convert.ToInt32(Time.timeScale)];
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene (int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    private void LevelText ()
    {
        levelText.text = "LEVEL: " + SceneManager.GetActiveScene().buildIndex+"\n";
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                levelText.text += "RIVER";
                break;
            case 2:
                levelText.text += "ENCHANTED FOREST";
                break;
            case 3:
                levelText.text += "MOUNTAINS";
                break;
            case 4:
                levelText.text += "DUNGEON";
                break;
            case 5:
                levelText.text += "TREASURY";
                break;
            case 6:
                levelText.text += "SICK MIND";
                break;
            case 7:
                levelText.text += "???";
                break;
        }
    }
}
