using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    // ɨ�����������Ҹ����ж��ٹ������ĵ���

    public float scanRange = 6f; // ɨ�跶Χ�ĳ�ʼֵ��������Χ
    RaycastHit2D[] targets; // �洢��ͨ�� CircleCastAll ������ָ����Χ����Ŀ��㣨targetLayer����ײ�Ľ����ʹ�� RaycastHit2D ���鱣�������е���ײ��Ϣ��
    public Transform nearestTarget; // ����������ĵ��˵� Transform ������������Ŀ��λ�á�

    public LayerMask targetLayer; // ��ʾ��Ҫ������ײ����Ŀ��㡣

    void FixedUpdate()
    {
        // ʹ��CircleCastAll������ָ����Χ�ڽ���Բ����ײ���
        // ������洢��targets������
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);

        // ��ȡ����ĵ���λ��
        nearestTarget = GetNearest();
    }

    private Transform GetNearest()
    {
        float diff = 100f; // ��ʼ����ֵ
        Transform result = null; // ���Ŀ���Transform���
        foreach (RaycastHit2D t in targets) // ����ÿ����ײ���
        {
            Vector3 myPos = transform.position; // ��ǰλ��
            Vector3 targetPos = t.transform.position; // Ŀ��λ��

            // ���㵱ǰĿ���뵱ǰλ�õľ���
            float curDiff = Vector3.Distance(myPos, targetPos);
            if (curDiff < diff) // ����������
            {
                diff = curDiff; // ������С����ֵ
                result = t.transform; // ���������Ŀ��λ��
            }
        }
        return result; // ���������Ŀ��λ��
    }
}
