using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinkanseController : MonoBehaviour
{
    [SerializeField] public float moveXDif;
    [SerializeField] private float finalbackX;

    //[SerializeField] public int posNum = 0;

    [SerializeField] private GameObject explosionSE;

    private UIController ui;
    
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        Instantiate(explosionSE, this.transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate (moveXDif, 0, 0);
		if (transform.position.x <= finalbackX) {
            //Instantiate(explosionSE, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
            ui.AddScore();
		}
    }
}
