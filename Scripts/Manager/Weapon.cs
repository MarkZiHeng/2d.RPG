using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet; // �ӵ���Ԥ����
    public GameObject dialogBox; // ˵����
    public bool say; // ˵����

    float timer; // ��ʱ��
    float sayTime; // ���

    float spawnTime = 1f; // �����ӵ���ʱ����

    public float damage = 1f; // �������˺�ֵ

    public Player player; // ��Ҷ���

    // Start is called before the first frame update
    void Start()
    {
        say = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 1; // ���¼�ʱ��(������cd)

        KeyDown_J();

        sayTime += Time.deltaTime * 1; // �����
        if (sayTime > 3f)
        {
            dialogBox.SetActive(false);
            sayTime = 0; // ����
            say = false;
        }
    }

    // ��������
    private void KeyDown_J()
    {
        // ��������й���͹���
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("K");
            Debug.Log(timer);
            if (timer > spawnTime) // �����ʱ����������ʱ����
            {
                Debug.Log("����");
                timer = 0; // ���ü�ʱ��
                Fire(); // �����ӵ�
            }
        }
    }

    private void Fire()
    {
        Debug.LogWarning("����");
        // ���Ŀ��λ�գ�����ʾ dialogBox
        if (player.scanner.nearestTarget == null)
        {
            sayTime = 0; // ����
            dialogBox.SetActive(true);
            return;
        }

        Vector3 dir = player.scanner.nearestTarget.position - transform.position; // �����ӵ����з���
        dir = dir.normalized; // ��һ����������
        GameObject go = Instantiate(bullet); // ʵ�����ӵ�Ԥ����
        go.transform.position = transform.position; // �����ӵ��ĳ�ʼλ��

        go.GetComponent<Bullet>().Init(GameManager.instance.playerDamage + damage, dir); // ��ʼ���ӵ����˺��ͷ��з���
    }
}
