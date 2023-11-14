using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����������С�Ĵ���
/// </summary>
public class GridItemSize : MonoBehaviour
{
    private int previousChildCount; // ��ʼ����������
    private int timer; // ��ʱ��
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        // ��¼��ʼ����������
        previousChildCount = transform.childCount;
        Resize(); // �޸ĳ�ʼ����������ͼƬ��С
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        // ��15֡�ж�һ�Σ��������ܿ���
        if (timer > 15)
        {
           Resize();
        }
    }

    /*private void Check()
    {
        // ��������������Ƿ��б仯
        if (transform.childCount > previousChildCount)
        {
            // ��ȡ����ӵ�������
            Transform newChild = transform.GetChild(transform.childCount - 1);

            // �������ӵ��������Ƿ���� Image ���
            Image imageComponent = newChild.GetComponent<Image>();
            if (imageComponent != null)
            {
                // �޸�����ӵ�ͼƬ������� RectTransform ����
                RectTransform rectTransform = newChild.GetComponent<RectTransform>(); // ��ȡ���
                rectTransform.localScale = new Vector2(0.7f, 0.7f); // ����Ϊ���������
            }

            // ���¼�¼������������
            previousChildCount = transform.childCount;
        }
    }*/

    // ��ȡ��ǰ����Ʒ���޸Ĵ�С
    private void Resize()
    {
        // ��ȡ��ǰ������Ӷ�������
        int childCount = transform.childCount;

        // ѭ�����������Ӷ���
        for (int i = 0; i < childCount; i++)
        {
            // ��ȡ��Ʒ�� RectTransform ���
            RectTransform childRectTransform = transform.GetChild(i).GetComponent<RectTransform>();
            // �޸���Ʒ��ͼƬ����
            childRectTransform.localScale = new Vector2(0.7f, 0.7f); // ����Ϊ���������

            // �޸�����չʾ��λ��
            Transform childToHide = transform.GetChild(i).Find("Number");
            RectTransform numPos = childToHide.GetComponent<RectTransform>();
            numPos.anchoredPosition = new Vector2(5.6f, -7.2f);
        }
    }
    
}
