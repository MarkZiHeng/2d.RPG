using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��������
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

    // ��/�ر� ����
    void OpenBag()
    {
        // ���ж��Ƿ��ڼ���״̬
        // ����ʹ�����رգ� isOpenBag ���Ǵ��� true ״̬
        if (myBag != null && myBag.activeSelf)
        {
            isOpenBag = true;
        }
        else
        {
            isOpenBag = false;
        }

        // ����
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOpenBag = !isOpenBag;
            myBag.SetActive(isOpenBag);
        }
    }
}
