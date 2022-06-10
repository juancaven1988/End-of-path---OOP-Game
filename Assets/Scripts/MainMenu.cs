using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioSource audioSource;

  public void newStart()
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(1);
        
    }

    public void Exit()
    {

        audioSource.PlayOneShot(clickSound);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
