using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName = "Test";
    [SerializeField] private GameObject continueBotton;
    [SerializeField] UI_FadeScreen fadeScreen;

    private void Awake()
    {
    }

    private void Start()
    {
        if(SaveManager.instance.HasSavedData() == false)
            continueBotton.SetActive(false);    

    }
    
    public void SwitchMenuTo(GameObject uiMenu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        AudioManager.instance.PlaySFX(7,null);
        uiMenu.SetActive(true);

    }


    public void ContinueGame()
    {
        StartCoroutine(LoadSceneWithFadeEffect(1f));
    }   

    public void NewGame()
    {
        SaveManager.instance.DeleteSavedData();
        StartCoroutine(LoadSceneWithFadeEffect(1f));
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    IEnumerator LoadSceneWithFadeEffect(float _delay)
    {
        fadeScreen.FadeOut();

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(sceneName);
    }



}
