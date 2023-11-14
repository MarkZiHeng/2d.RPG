using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InTurnScript : MonoBehaviour
{
    private bool canShowDia; // �Ƿ������ʾ���ֿ�
    // Start is called before the first frame update
    void Start()
    {
        canShowDia = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowDia();
        }
    }

    // ����E������ʾ DialogBox
    private void ShowDia()
    {
        if (canShowDia)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.0f); // ��ȡ�뾶Ϊ1.0�ķ�Χ�ڵ�������ײ��
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Interactive")) // ����Ƿ�Ϊ�ɽ�������
                {
                    Transform parentObject = collider.transform;

                    // �ڸ��������±����Ӷ���
                    foreach (Transform child in parentObject)
                    {
                        // ����ҵ�����Ϊ DialogBox �Ļ�������ʾ
                        if (child.name == "DialogBox")
                        {
                            child.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Interactive �ɽ�����
        if (other.gameObject.CompareTag("Interactive") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            // ��ȡ�������ڲ�����ĸ�������
            Transform parentObject = other.transform;

            // �����������ڲ�������Ӷ��󣬲�������Ϊ "E" �Ķ��󲢽�����ʾ����
            foreach (Transform child in parentObject)
            {
                if (child.name == "E")
                {
                    canShowDia = true;
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactive") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            Transform parentObject = other.transform;

            foreach (Transform child in parentObject)
            {
                if (child.name == "E")
                {
                    Debug.Log("�뿪");
                    canShowDia = true;
                    child.gameObject.SetActive(false);
                }
            }

            foreach (Transform child in parentObject)
            {
                if (child.name == "DialogBox")
                {
                    Debug.Log("����ʾ");
                    canShowDia = true;
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
}
