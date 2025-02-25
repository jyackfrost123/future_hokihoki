using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShinkansenGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;

    [SerializeField] private float enemyX;
    [SerializeField] private float enemyY;

    [SerializeField] private float generateTime;

    [SerializeField] private UIController ui;

    float time;

    bool isGenerate = false;

    void Start()
    {
        time = -1.5f;//カウント2秒+2秒

        isGenerate = false;
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= generateTime){
            isGenerate = true;
            time = 0;
        }
    }

    void FixedUpdate()
    {
        if(isGenerate && !ui.isGameFinished){
            GenerateEnemy();
            isGenerate = false;
        }
    }

    public void GenerateEnemy(){

        Vector3 tmp_pos = new Vector3(enemyX, enemyY, -4.0f);

        int rand = Random.Range(0, enemy.Length);

        GameObject obj = Instantiate(enemy[rand], tmp_pos, Quaternion.identity);
        ShinkanseController e = obj.GetComponent<ShinkanseController>();
        e.moveXDif = e.moveXDif - ( (0.1f * ((float)ui.score / 8.0f)) * Random.Range(0.0f, 1.5f) );
        
    }


}
