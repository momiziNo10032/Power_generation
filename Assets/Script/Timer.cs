using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
        //　トータル制限時間
        private float totalTime;
        //　制限時間（分）
        [SerializeField]
        private int minute;
        //　制限時間（秒）
        [SerializeField]
        private float seconds;
        //　前回Update時の秒数
        private float oldSeconds;
        private Text timerText;
        public static bool[] Timer_swich={false,false};//タイマーをスタートするスイッチ
        private int original_minute;//タイマーを再設定するときの目安
        private float original_second;
        public GameObject Button;
        void Start () {
                totalTime = minute * 60 + seconds;
                oldSeconds = 0f;
                timerText = GetComponentInChildren<Text>();
                original_minute=minute;
                original_second=seconds;
        }

        void Update () {
                if(StaRrt_Button.button_swich==false) return; //startボタンが押されてなければreturn
                //　制限時間が0秒以下なら何もしない
                if (totalTime <= 0f) {
                        Sound.Mswich=4;//BGMを止める
                        minute=original_minute; //時間を戻す
                        seconds=original_second;
                        totalTime = minute * 60 + seconds;
                        //Debug.Log(minute+":"+seconds);
                        StaRrt_Button.button_swich=false;//Retryボタンを出す
                        Main_System.elect_power=0;//電気を0に
                        Button.gameObject.SetActive(true);
                        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (Score.point);//得点を登録
                        return;
                }
                //　一旦トータルの制限時間を計測；
                totalTime = minute * 60 + seconds;
                totalTime -= Time.deltaTime;

                //　再設定
                minute = (int) totalTime / 60;
                seconds = totalTime - minute * 60;

                //　タイマー表示用UIテキストに時間を表示する
                if((int)seconds != (int)oldSeconds) {
                        timerText.text = minute.ToString("00") + "," + ((int) seconds).ToString("00");
                }
                oldSeconds = seconds;
                //　制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
                if(totalTime <= 0f) {
                        Debug.Log("制限時間終了");
                }
        }
}
