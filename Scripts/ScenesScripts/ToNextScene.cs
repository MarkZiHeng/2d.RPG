using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 切换场景
/// </summary>
public class ToNextScene : MonoBehaviour
{
    private bool canGoToNext;
    public GameObject ui_E;
    // Start is called before the first frame update
    void Start()
    {
        canGoToNext = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GoToNextScene();
        }
        ui_E.SetActive(canGoToNext);
    }
    private void GoToNextScene()
    {
        if (canGoToNext)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // 进入触发器，改变 canGoToNext 的状态
    private void OnTriggerEnter2D(Collider2D other)
    {
        canGoToNext = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canGoToNext = false;
    }
}

