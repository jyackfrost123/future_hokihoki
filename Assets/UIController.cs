using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using unityroom.Api;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
        
    [SerializeField]
    private TextMeshProUGUI timerText;
    
    [SerializeField]
    private TextMeshProUGUI gameOverText;

    [SerializeField]
    private GameObject endSE;

    [SerializeField]
    private GameObject gameoverButtons;

    [field: SerializeField] public bool isGameStart;
    [field: SerializeField] public bool isGameFinished;
    [field: SerializeField] public float time; 

    [SerializeField] public int score;

    [SerializeField] private GameObject walkBGMs;
    [SerializeField] private GameObject JumpButtons;
    [SerializeField] private gamingBackController back;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        isGameStart = false;
        isGameFinished = false;

        gameoverButtons.SetActive(false);
        
        score = 0;
    }

    void Update()
    {
        if (isGameStart)
        {
           /* time -= Time.deltaTime;
            if (time < 0.0f)
            {
                time = 0;
                isGameStart = false;
                GameFinish();
                //DOVirtual.DelayedCall (3.0f, ()=> DoChangeScene());  
                //GameFinish();
            }
            */
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "スコア: "+ score +" ホキホキ";
        timerText.text = "";

    }
    
    //ゲーム終了時の処理
    void GameFinish()
    {
        gameOverText.text = "お寿司になった…";
        gameOverText.color = Color.yellow;
        //para.TotalScore = player.AnimalTotalHight;
        //para.TotalAnimalNum = player.AnimalNum;
        isGameFinished = true;
        
        /* TODO: ランキング送信の処理を入れる*/
        UnityroomApiClient.Instance.SendScore(1, (float)score, ScoreboardWriteMode.HighScoreDesc);

        gameoverButtons.SetActive(true);
        Instantiate(endSE, Vector3.zero, Quaternion.identity);
        walkBGMs.SetActive(false);
        JumpButtons.SetActive(false);
        //background.SetActive(false);
        back.speed = 0;
    }

    void DoChangeScene()
    {
        //フェード遷移とか入れる
        //FadeManager.Instance.LoadScene ("Ending", 1.5f);
    }

    public void AddScore(){
        if(isGameStart && !isGameFinished ) score++;
    }

    public void GameOver(){
        GameFinish();
    }
}
