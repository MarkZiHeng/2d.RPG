using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏中实现菜单按钮，并暂停游戏
/// </summary>
public class GamingMenu : MonoBehaviour
{
    public GameObject escMenu;

    // 失活的时候调用
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void Continue()
    {
        Time.timeScale = 1f; // 恢复游戏
        // 在这里可以添加隐藏暂停界面的代码
        escMenu.SetActive(false);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit(); // 退出游戏
    }
}
