using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ʒ�Ĺ���
/// </summary>
public class DropItem : MonoBehaviour
{
    public GameObject[] dropItems; // ������
    Vector2 dropPosition;
    private float range;
    // ��ָ��λ�ø���������ɵ�����Ʒ
    public void DropRandomItem(Vector2 dropPosition, float range)
    {
        if (dropItems != null && dropItems.Length > 0)
        {
            Vector2 randomOffset = new Vector2(Random.Range(-range, range), Random.Range(-range, range));
            Vector2 finalDropPosition = dropPosition + randomOffset;
            int randomIndex = Random.Range(0, dropItems.Length);
            GameObject randomItem = dropItems[randomIndex];
            Instantiate(randomItem, finalDropPosition, Quaternion.identity);
        }
    }

    private void Start()
    {
        // ��ʼ������
        dropPosition = this.transform.position;
        range = 1;
        // ����
        DropRandomItem(dropPosition, range);
    }
}
