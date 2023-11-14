using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 文本管理器
public class HUD : MonoBehaviour
{
    public Text kill; // 用于显示消灭敌人数量的UI文本组件
    public Text time; // 用于显示剩余时间的UI文本组件
    public Text level; // 用于显示当前等级的UI文本组件
    public Slider exp; // 用于显示经验值进度的滑动条组件

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 更新UI文本和滑动条的值
        this.kill.text = GameManager.instance.kill.ToString(); // 更新消灭敌人数量文本
        this.level.text = GameManager.instance.level.ToString(); // 更新当前等级文本

        // 计算当前经验值和下一个等级所需的经验值，并更新滑动条的值
        float curExp = GameManager.instance.exp;
        float maxExp = GameManager.instance.nextExp[Mathf.Min(GameManager.instance.level, GameManager.instance.nextExp.Length - 1)];
        exp.value = curExp / maxExp;

        // 计算剩余时间，并将其格式化为分钟:秒钟的形式，更新时间文本
        float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
        int min = Mathf.FloorToInt(remainTime / 60);
        int sec = Mathf.FloorToInt(remainTime % 60);
        time.text = string.Format("{0:D2}:{1:D2}", min, sec);
    }
}
