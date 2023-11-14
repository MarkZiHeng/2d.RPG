using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float horizontal; // 水平
    public float vertical; // 垂直
    public float speed = 3; // 速度
    public SpriteRenderer spriteRenderer;

    public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 如果玩家死亡，直接返回
        if (!GameManager.instance.isLive)
        {
            return;
        }

        PlayerMove();
    }

    private void PlayerMove()
    {
        this.horizontal = Input.GetAxis("Horizontal"); // 获取水平
        this.vertical = Input.GetAxis("Vertical"); // 获取垂直

        Vector3 inputVec = new Vector3(horizontal, vertical, 0);
        this.transform.position = this.transform.position + inputVec * speed * Time.deltaTime; // 移动

        // 转向
        if (inputVec.x != 0)
            spriteRenderer.flipX = inputVec.x < 0;

        animator.SetFloat("GameSpeed", inputVec.magnitude); // inputVec.magnitude返回的向量的长度，移动的长度
    }
}
