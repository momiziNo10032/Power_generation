using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Main_System : MonoBehaviour
{
        public GameObject elect;
        public static bool[] elect_swich={false,false,false,false};
        public static int elect_power=0;//右に表示する電気量
        int Max_elect_power=15;//メモリの最大値
        public GameObject canbas;  //親オブジェクトにするキャンバス
        GameObject[] elect_memory;//メモリを非表示表示を管理する配列
        Image[] memory_color;//メモリの色を管理するマテリアル配列
        public int adjust=0;//画面のどのくらい上まで電気メーターを上げるか
        bool[] elect_Mater_swich={false,false};//メーターの目盛りを挙げる処理を一度だけ行うようにするbool
        public ParticleSystem elec_effect;//電気のエフェクト
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (100);
        void Start()
        {
                elec_effect.Stop (true, ParticleSystemStopBehavior.StopEmitting);//電気のエフェクトを消す
                elect_memory=new GameObject[Max_elect_power];//配列を増やす
                memory_color=new Image[Max_elect_power];
                float electx=elect.transform.localPosition.x;//１つめのメモリの場所を取得
                float electy=elect.transform.localPosition.y;
                //Debug.Log(electx+":"+electy);
                for(int i=0; i<Max_elect_power; i++) {
                        elect_memory[i]=Instantiate(elect,new Vector3(electx,electy,0), Quaternion.identity);
                        //メモリを生成
                        elect_memory[i].transform.SetParent(canbas.transform,false);//canbasの子オブジェクトにする
                        elect_memory[i].transform.localPosition=new Vector3(electx,electy,0);
                        //canvasのRenderをcameraにしているのでlocalpositionで位置を調整する
                        //cameraにしないとparticleが背景の後ろに行く
                        //elect_memory[i].SetActive (true);
                        //Debug.Log (Screen.height);
                        electy+=400/(Max_elect_power)+adjust;
                        //この400をScreen.heightで取得したかったが無理だった
                        //画面サイズ÷メモリの数で画面サイズがいくつでも使える
                        //memory_color[i]=elect_memory[i].GetComponent<Image>();
                        //memory_color[i].color=new Color(255.0f,128.0f,0);
                        elect_memory[i].GetComponent<Image>().color=new Color(1f, 1f-1f/Max_elect_power*i, 0);
                }
                //Debug.Log("Screen Width : " + Screen.width);
                //Debug.Log("Screen  height: " + Screen.height);
        }
        void Update()
        {
                if(StaRrt_Button.button_swich==false) {
                        for(int i=0; i<Max_elect_power; i++) {
                                elect_memory[i].SetActive (false);
                        }
                        elec_effect.Stop (true, ParticleSystemStopBehavior.StopEmitting);//電気のエフェクトを消す
                        return; //startボタンが押されてなければreturn
                }
                //最大値を超えてしまったときの処理
                if(elect_power>=Max_elect_power) {
                        for(int j=0; j<elect_power; j++) {
                                elect_memory[j].SetActive(false);
                        }
                        elec_effect.Stop (true, ParticleSystemStopBehavior.StopEmitting);//電気のエフェクトを消す
                        Sound.Mswich=3;//SEを出す
                        elect_power=-5;//ペナルティ
                }
                //メモリを増やす
                for(int i=0; i<elect_power; i++) {
                        elect_memory[i].SetActive(true);
                }
                //すべてtrueなら一回転した処理に移行
                for(int i=0; i<elect_swich.Length; i++) {
                        if(elect_swich[i]==false) {//falseがあったらbreak
                                break;
                        }
                        if(i==elect_swich.Length-1) {//すべてtrueならメモリを増やす
                                elec_effect.Play (true);//カミナリのエフェクトを出す
                                elect_power++;
                                Sound.Mswich=1;//SEを出す
                                for(int j=0; j<elect_swich.Length; j++) {
                                        elect_swich[j]=false;
                                }
                        }
                }
                //クリック時の処理
                if (Input.GetMouseButtonDown(0)) {
                        if(elect_power==0) return;
                        for(int i=0; i<elect_power; i++) {
                                elect_memory[i].SetActive(false);
                        }
                        if(elect_power==Max_elect_power) Score.pointin=2;
                        Score.pointin=elect_power;
                        Sound.Mswich=2;//SEを出す
                        elect_power=0;
                }
        }
}
