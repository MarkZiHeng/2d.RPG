using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem; // ��ȡ��Ʒ����
    public Inventory playerInventory; // ��ҵı���

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // ƥ���ǩ
        {
            AddNewItem(); // �����Ʒ

            Destroy(gameObject); // ������Ʒ
        }
    }

    private void AddNewItem()
    {
        // ���жϣ���ǰ�������Ʒ���Ƿ��ڱ�����
        if (!playerInventory.itemList.Contains(thisItem))
        {
            // �������û���������Ʒ
            playerInventory.itemList.Add(thisItem);
            // InventoryManager.CreateNewItem(thisItem); // ���÷��������ڱ���������
        }
        else
        {
            // ���������������������+1
            thisItem.itemHeld += 1;
        }

        InventoryManager.RefreshItem();
    }
}
