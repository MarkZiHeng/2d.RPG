using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// �˵�����
/// </summary>
public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen; // ������UI
    public Slider slider; // 
    public Text progreassText; // ����
    public GameObject mainMenu; // ��ʾ

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(AsyncLoadLevel(sceneIndex));
    }

    IEnumerator AsyncLoadLevel(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); // �첽���볡��
        loadingScreen.SetActive(true); // ��ʾ
        mainMenu.SetActive(false); // �����˵���������

        // �ȴ�һ��
        while (!operation.isDone)
        {
            // ��ֵ�������������
            float progress = operation.progress / 0.9f; // ��Ϊ operation.progress ��Χ��ֵ��0-0.9֮�䣬����������Χ��0-1֮�䣬����/0.9�������ͽ������ı���ƥ�����
            slider.value = progress;
            progreassText.text = Mathf.FloorToInt(progress * 100f).ToString() + "%"; // ��Ϊ������С��������תΪ����
            yield return null;
        }
    }

    public void Help()
    {

    }

    public void ExitGame()
    {
        Application.Quit(); // �˳���Ϸ
    }
}
