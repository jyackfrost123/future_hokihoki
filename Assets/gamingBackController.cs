using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;


public class gamingBackController : MonoBehaviour
{
    //RectTransformを取得する
    Transform animalTansform;

    private Vector3 firstPos;
    

    [SerializeField] private float hightpoint;
    [SerializeField] public float speed = 0.1f;

    private UIController ui;

    private void Start()
    {
        animalTansform = this.transform;
        firstPos = animalTansform.position;
        //animalTansform.DOMoveX(firstPos.x + hightpoint, durationTime).SetLoops(-1, LoopType.Yoyo);
        //this.gameObject.SetActive(true);
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    private void FixedUpdate() {
        if(!ui.isGameFinished){
            this.transform.Translate(speed - 0.1f * ((float)ui.score / 12.0f) , 0.0f, 0.0f);

            if(this.transform.position.x <= firstPos.x - hightpoint){
                this.transform.position = firstPos;
            }

        }
        
    }
    
}
