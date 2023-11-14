using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��Ϸ��ʵ�ֲ˵���ť������ͣ��Ϸ
/// </summary>
public class GamingMenu : MonoBehaviour
{
    public GameObject escMenu;

    // ʧ���ʱ�����
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void Continue()
    {
        Time.timeScale = 1f; // �ָ���Ϸ
        // ������������������ͣ����Ĵ���
        escMenu.SetActive(false);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit(); // �˳���Ϸ
    }
}
