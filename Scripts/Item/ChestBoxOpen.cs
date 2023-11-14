using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �򿪱��书��
/// </summary>
public class ChestBoxOpen : MonoBehaviour
{
    private bool canOpen;
    private bool isOpened;
    public GameObject ui_E; // ��E����ʾUI
    public GameObject openObj; // �򿪵ı���
    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenIt();
        }
        ui_E.SetActive(canOpen);
    }

    private void OpenIt()
    {
        if (canOpen && !isOpened)
        {
            // �����Ӷ����е�һ������
            Transform childToHide = transform.Find("ChestBoxClose");
            if (childToHide != null)
            {
                childToHide.gameObject.SetActive(false);
            }

            // ���Լ����Ӷ��������� �򿪵ı���
            GameObject newOpenObj = Instantiate(openObj, transform.position, Quaternion.identity);
            newOpenObj.transform.parent = transform; // ���ø�����

            isOpened = true; // ����Ϊfalse����Ȼһֱ��
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            canOpen = false;
        }
    }
}
