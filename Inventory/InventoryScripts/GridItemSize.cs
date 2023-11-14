using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用来调整大小的代码
/// </summary>
public class GridItemSize : MonoBehaviour
{
    private int previousChildCount; // 初始子物体数量
    private int timer; // 计时器
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        // 记录初始子物体数量
        previousChildCount = transform.childCount;
        Resize(); // 修改初始背包东西的图片大小
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        // 隔15帧判断一次，减少性能开销
        if (timer > 15)
        {
           Resize();
        }
    }

    /*private void Check()
    {
        // 检查子物体数量是否有变化
        if (transform.childCount > previousChildCount)
        {
            // 获取新添加的子物体
            Transform newChild = transform.GetChild(transform.childCount - 1);

            // 检查新添加的子物体是否包含 Image 组件
            Image imageComponent = newChild.GetComponent<Image>();
            if (imageComponent != null)
            {
                // 修改新添加的图片子物体的 RectTransform 缩放
                RectTransform rectTransform = newChild.GetComponent<RectTransform>(); // 获取组件
                rectTransform.localScale = new Vector2(0.7f, 0.7f); // 设置为所需的缩放
            }

            // 更新记录的子物体数量
            previousChildCount = transform.childCount;
        }
    }*/

    // 获取当前子物品，修改大小
    private void Resize()
    {
        // 获取当前对象的子对象数量
        int childCount = transform.childCount;

        // 循环遍历所有子对象
        for (int i = 0; i < childCount; i++)
        {
            // 获取物品的 RectTransform 组件
            RectTransform childRectTransform = transform.GetChild(i).GetComponent<RectTransform>();
            // 修改物品的图片缩放
            childRectTransform.localScale = new Vector2(0.7f, 0.7f); // 设置为所需的缩放

            // 修改数量展示的位置
            Transform childToHide = transform.GetChild(i).Find("Number");
            RectTransform numPos = childToHide.GetComponent<RectTransform>();
            numPos.anchoredPosition = new Vector2(5.6f, -7.2f);
        }
    }
    
}
