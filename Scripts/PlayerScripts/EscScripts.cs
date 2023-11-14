using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esc��ͣ����
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
        Time.timeScale = 0f; // ��ͣ��Ϸ
        isPaused = true;
        // ��ͣ����
        escMenu.SetActive(true);
    }

    private void ResumeGame()
    {
        // Time.timeScale = 1f; // �ָ���Ϸ������ֱ��д���� GamingMenu�ű���OnDisable()�У���ʧ���ʱ�����
        isPaused = false;
        // ������������������ͣ����Ĵ���
        escMenu.SetActive(false);
    }
}
