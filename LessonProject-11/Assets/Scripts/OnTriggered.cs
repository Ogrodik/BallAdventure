using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OnTriggered : MonoBehaviour
{
    [SerializeField] private int insideType;
    [SerializeField] private int pressMin;

    [SerializeField] private TextMeshProUGUI infoText;

    [SerializeField] private ParticleSystem magic;

    public int presses;

    private void Start()
    {
        ChekPress();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (insideType)
            {
                case 0:                    
                    StartCoroutine(PortalCoroutine(true));
                    break;
                case 1:
                    StartCoroutine(PortalCoroutine(false));
                    break;
                case 2:
                    infoText.text = "Создайте себе мост из блоков";
                    break;
                case 3:
                    infoText.text = "Коснитесь батута";
                    break;
                case 4:
                    infoText.text = "Нажмите на обе кнопки, чтобы пройти дальше";
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (infoText != null&&other.CompareTag("Player"))
            infoText.text = "";
    }
    public void ChekPress()
    {
        if (presses >= pressMin)
        {
            gameObject.SetActive(true);
        }
        else if (pressMin!=0)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator PortalCoroutine(bool zero)
    {
        magic.Play();
        if (MainMenu.OpenLevel < SceneManager.GetActiveScene().buildIndex)
        {
            MainMenu.OpenLevel = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("OpenLevel", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
        }
        yield return new WaitForSeconds(0.7f);
        if (zero)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(7);
    }
}
