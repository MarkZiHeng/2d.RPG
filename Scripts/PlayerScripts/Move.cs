using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float horizontal; // ˮƽ
    public float vertical; // ��ֱ
    public float speed = 3; // �ٶ�
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
        // ������������ֱ�ӷ���
        if (!GameManager.instance.isLive)
        {
            return;
        }

        PlayerMove();
    }

    private void PlayerMove()
    {
        this.horizontal = Input.GetAxis("Horizontal"); // ��ȡˮƽ
        this.vertical = Input.GetAxis("Vertical"); // ��ȡ��ֱ

        Vector3 inputVec = new Vector3(horizontal, vertical, 0);
        this.transform.position = this.transform.position + inputVec * speed * Time.deltaTime; // �ƶ�

        // ת��
        if (inputVec.x != 0)
            spriteRenderer.flipX = inputVec.x < 0;

        animator.SetFloat("GameSpeed", inputVec.magnitude); // inputVec.magnitude���ص������ĳ��ȣ��ƶ��ĳ���
    }
}
