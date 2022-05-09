using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaRrt_Button : MonoBehaviour
{
        public static bool button_swich=false;
        public Text Button_txt;//ボタンのテキスト
        void Start()
        {
                //Button_txt=GetComponent<Text>();
                Button_txt.text="Start";
        }
        public void Click() {
                Debug.Log("Start_Button");
                //スタートボタンを押したら
                Button_txt.text="Retry";
                Sound.Mswich=5;                //BGMStart
                button_swich=true;
                Score.point=0;//得点をリセット
                this.gameObject.SetActive (false); //
        }
}
