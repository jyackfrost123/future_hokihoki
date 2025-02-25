using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] walkSprites;

    [SerializeField]
    private Sprite[] hideWalkSprites;

    [SerializeField]
    private Sprite endSprites;

    [SerializeField]
    private SpriteRenderer playerSprite;

    [SerializeField]
    private float jumpPower = 0.1f;

    [SerializeField]
    private float baseFlameTime = 0.3f;

    [SerializeField]
    private float baseJumpTime = 0.5f;

    [SerializeField]
    private float time;

    private int spriteNum = 0;

    private UIController ui;

    [SerializeField] private bool isJumped = false;

    [SerializeField] private GameObject jumpUpSE;
    [SerializeField] private GameObject jumpDownSE;
    
    void Start()
    {
        time = baseFlameTime;
        spriteNum = 0;

        playerSprite.sprite = walkSprites[spriteNum];

        ui  = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !isJumped){
            Jump();
        }
    }

    void FixedUpdate()
    {
        //ゲームオーバーではないなら、以下を実行
        if(!ui.isGameFinished){

            //アニメーション関係の処理
            time -= Time.deltaTime;
            if(time <= 0) {
                spriteNum++;
                if(spriteNum > walkSprites.Length - 1) {
                    spriteNum = 0;
                }
                playerSprite.sprite = walkSprites[spriteNum];

                time = baseFlameTime - (0.05f * ( (float)(ui.score) / 25.0f) );
            }

            if(isJumped){

            }

        }else{  

            //アニメーション関係の処理
            playerSprite.sprite = endSprites;
        }
        
    }

    public void Jump(){
        //isJumped = true;

        if(!isJumped)
        {
            Instantiate(jumpUpSE, Vector3.zero, Quaternion.identity);

            //this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.up * jumpPower;//ジャンプがもっさりしているのどうしよう
            transform.DOLocalJump(this.transform.position, 5, 1, 0.9f);
            // ★追加
            isJumped = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("YES");
        if (collision.gameObject.tag == "Shinkansen")
        {
            //collision.gameObject.GetComponent<SpriteRenderer>().sprite = null;//新幹線を見えなくする
            Destroy(collision.gameObject);
            ui.GameOver();

        }else if(collision.gameObject.tag == "SEEffect" && isJumped){
            Instantiate(jumpDownSE, Vector3.zero, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground" && isJumped){
            isJumped = false;
            //Instantiate(jumpDownSE, Vector3.zero, Quaternion.identity);
        }
    }






}
