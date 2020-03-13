using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;
    private int LeftID = -1;
    private int RightID = -1;

    // Use this for initialization
    void Start () {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

        //画面サイズの取得
        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen Height: " + Screen.height);

    }

    // Update is called once per frame
    void Update () {
        //左矢印キーを押した時左フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
                
        //タッチの座標を取得
        for(int i = 0; i < Input.touchCount; i++)
        {            
            var pos = Input.touches[i].position;
            var phase = Input.touches[i].phase;
            var ID = Input.touches[i].fingerId;
            //座標とフリッパーの連動
            //画面左半分を押した時左フリッパーを動かす
            if (pos.x <= Screen.width/ 2 && tag == "LeftFripperTag" && phase == TouchPhase.Began && LeftID == -1)
            {
                LeftID = ID;
                SetAngle(this.flickAngle);
            }
            //画面右半分を押した時右フリッパーを動かす
            else if (pos.x > Screen.width/2 && tag == "RightFripperTag" && phase == TouchPhase.Began && RightID == -1)
            {
                RightID = ID;
                SetAngle(this.flickAngle);
            }

            //画面左半分を離した時左フリッパーを元に戻す
            if (phase == TouchPhase.Ended && ID == LeftID && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
                LeftID = -1;
            }
            //画面右半分を離した時右フリッパーを元に戻す
            else if (phase == TouchPhase.Ended && ID == RightID && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
                RightID = -1;
            }
        }

    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
