using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// һ�����أ��ȵ��˴���ˢ��
/// </summary>
public class TriggerTrap : MonoBehaviour
{
    public GameObject spawner; // ˢ����
    public GameObject airWall; // ����ǽ
    // public GameObject spawner; // ˢ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            spawner.SetActive(true);
            airWall.SetActive(true);
        }
    }
}
