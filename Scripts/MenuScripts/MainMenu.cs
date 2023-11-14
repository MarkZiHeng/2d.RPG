using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 菜单功能
/// </summary>
public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen; // 进度条UI
    public Slider slider; // 
    public Text progreassText; // 文字
    public GameObject mainMenu; // 显示

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(AsyncLoadLevel(sceneIndex));
    }

    IEnumerator AsyncLoadLevel(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); // 异步载入场景
        loadingScreen.SetActive(true); // 显示
        mainMenu.SetActive(false); // 把主菜单界面隐藏

        // 等待一下
        while (!operation.isDone)
        {
            // 把值传入进度条里面
            float progress = operation.progress / 0.9f; // 因为 operation.progress 范围的值是0-0.9之间，而进度条范围是0-1之间，所以/0.9，让他和进度条的比例匹配的上
            slider.value = progress;
            progreassText.text = Mathf.FloorToInt(progress * 100f).ToString() + "%"; // 因为可能是小数，所以转为整型
            yield return null;
        }
    }

    public void Help()
    {

    }

    public void ExitGame()
    {
        Application.Quit(); // 退出游戏
    }
}
