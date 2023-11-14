using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 背包代码
public class PlayerBag : MonoBehaviour
{
    bool isOpenBag;
    public GameObject myBag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenBag();
    }

    // 打开/关闭 背包
    void OpenBag()
    {
        // 先判断是否处于激活状态
        // 避免使用鼠标关闭， isOpenBag 还是处于 true 状态
        if (myBag != null && myBag.activeSelf)
        {
            isOpenBag = true;
        }
        else
        {
            isOpenBag = false;
        }

        // 按键
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOpenBag = !isOpenBag;
            myBag.SetActive(isOpenBag);
        }
    }
}
