using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InTurnScript : MonoBehaviour
{
    private bool canShowDia; // 是否可以显示文字框
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

    // 按下E键，显示 DialogBox
    private void ShowDia()
    {
        if (canShowDia)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.0f); // 获取半径为1.0的范围内的所有碰撞器
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Interactive")) // 检查是否为可交互对象
                {
                    Transform parentObject = collider.transform;

                    // 在父级对象下遍历子对象
                    foreach (Transform child in parentObject)
                    {
                        // 如果找到名字为 DialogBox 的话，就显示
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
        // Interactive 可交互的
        if (other.gameObject.CompareTag("Interactive") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            // 获取触发器内部物体的父级对象
            Transform parentObject = other.transform;

            // 遍历触发器内部物体的子对象，查找名称为 "E" 的对象并将其显示出来
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
                    Debug.Log("离开");
                    canShowDia = true;
                    child.gameObject.SetActive(false);
                }
            }

            foreach (Transform child in parentObject)
            {
                if (child.name == "DialogBox")
                {
                    Debug.Log("不显示");
                    canShowDia = true;
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
}
