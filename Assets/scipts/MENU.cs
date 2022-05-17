using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MENU : MonoBehaviour
{
    public GameObject pausemenu;
    public AudioMixer audiomixer;
    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quitgame()
    {
        Application.Quit();
    }
    public void Uienable()
    {
        GameObject.Find("Canvas/mainmenu/ui").SetActive(true);
    }
    public void Pausegame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;//游戏暂停
    }
    public void Returngame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;//游戏继续
    }
    public void Setvolume(float value)
    {
        audiomixer.SetFloat("Mainvolume", value);
    }
}
