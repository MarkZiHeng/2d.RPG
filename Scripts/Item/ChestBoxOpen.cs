using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 打开宝箱功能
/// </summary>
public class ChestBoxOpen : MonoBehaviour
{
    private bool canOpen;
    private bool isOpened;
    public GameObject ui_E; // 按E的提示UI
    public GameObject openObj; // 打开的宝箱
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
            // 隐藏子对象中的一个物体
            Transform childToHide = transform.Find("ChestBoxClose");
            if (childToHide != null)
            {
                childToHide.gameObject.SetActive(false);
            }

            // 在自己的子对象下生成 打开的宝箱
            GameObject newOpenObj = Instantiate(openObj, transform.position, Quaternion.identity);
            newOpenObj.transform.parent = transform; // 设置父对象

            isOpened = true; // 设置为false，不然一直打开
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
