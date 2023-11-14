using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �ı�������
public class HUD : MonoBehaviour
{
    public Text kill; // ������ʾ�������������UI�ı����
    public Text time; // ������ʾʣ��ʱ���UI�ı����
    public Text level; // ������ʾ��ǰ�ȼ���UI�ı����
    public Slider exp; // ������ʾ����ֵ���ȵĻ��������

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // ����UI�ı��ͻ�������ֵ
        this.kill.text = GameManager.instance.kill.ToString(); // ����������������ı�
        this.level.text = GameManager.instance.level.ToString(); // ���µ�ǰ�ȼ��ı�

        // ���㵱ǰ����ֵ����һ���ȼ�����ľ���ֵ�������»�������ֵ
        float curExp = GameManager.instance.exp;
        float maxExp = GameManager.instance.nextExp[Mathf.Min(GameManager.instance.level, GameManager.instance.nextExp.Length - 1)];
        exp.value = curExp / maxExp;

        // ����ʣ��ʱ�䣬�������ʽ��Ϊ����:���ӵ���ʽ������ʱ���ı�
        float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
        int min = Mathf.FloorToInt(remainTime / 60);
        int sec = Mathf.FloorToInt(remainTime % 60);
        time.text = string.Format("{0:D2}:{1:D2}", min, sec);
    }
}
