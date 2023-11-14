using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一个机关，踩到了触发刷怪
/// </summary>
public class TriggerTrap : MonoBehaviour
{
    public GameObject spawner; // 刷怪器
    public GameObject airWall; // 空气墙
    // public GameObject spawner; // 刷怪器

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            spawner.SetActive(true);
            airWall.SetActive(true);
        }
    }
}
