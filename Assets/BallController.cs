using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;
    //得点を加算
    int scorepoint = 0;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    //得点を表示する
    private GameObject SCORE;

    // Use this for initialization
    void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //シーン中のSCOREオブジェクトを取得
        this.SCORE = GameObject.Find("SCORE");
    }

    // Update is called once per frame
    void Update () {
        //ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }


    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        //ボールがオブジェクトに接触した場合
        if (collision.gameObject.tag == "LargeStarTag")
        {
            //得点を加算
            this.scorepoint += 20;
        }
        else if(collision.gameObject.tag == "SmallStarTag")
        {
            //得点を加算
            this.scorepoint += 10;
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            //得点を加算
            this.scorepoint += 5;
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            //得点を加算
            this.scorepoint += 1;
        }

        //表示
        this.SCORE.GetComponent<Text>().text = scorepoint.ToString();
    }
}
