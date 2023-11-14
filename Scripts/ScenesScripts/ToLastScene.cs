using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �л�����
/// </summary>
public class ToLastScene : MonoBehaviour
{
    private bool canGoToLast;
    public GameObject ui_E;
    // Start is called before the first frame update
    void Start()
    {
        canGoToLast = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToNextScene();
        }
        ui_E.SetActive(canGoToLast);
    }
    private void ToNextScene()
    {
        if (canGoToLast)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    // ���봥�������ı� canGoToNext ��״̬
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            canGoToLast = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            canGoToLast = false;
        }
    }
}

