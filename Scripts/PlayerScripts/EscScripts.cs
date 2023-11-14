using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esc暂停界面
/// </summary>
public class EscScripts : MonoBehaviour
{
    private bool isPaused;
    public GameObject escMenu;
    void Start()
    {
        isPaused = false;
    }
    void Update()
    {
        KeyDown_E();
    }

    private void KeyDown_E()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused && escMenu.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // 暂停游戏
        isPaused = true;
        // 暂停界面
        escMenu.SetActive(true);
    }

    private void ResumeGame()
    {
        // Time.timeScale = 1f; // 恢复游戏，这里直接写在了 GamingMenu脚本的OnDisable()中，在失活的时候调用
        isPaused = false;
        // 在这里可以添加隐藏暂停界面的代码
        escMenu.SetActive(false);
    }
}
