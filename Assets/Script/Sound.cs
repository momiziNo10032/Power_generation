using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
        public AudioClip sound1;//タイトルBGM
        public AudioClip sound2;//BGM
        public AudioClip sound3;//PP
        public AudioClip sound4;//電気get音
        public AudioClip sound5;//pointget音
        public AudioClip sound6;//警告音
        public static int Mswich=0;//０:デフォルト 1: 2:
        private AudioSource[] sources;//0:BGM用 1:SE用
        public bool DontDestroyEnabled = true; //シーンを切り替えても破壊されない
        void Start()
        {
                sources = GetComponents<AudioSource>();
                if (DontDestroyEnabled) {
                        // Sceneを遷移してもオブジェクトが消えないようにする
                        DontDestroyOnLoad (this);
                }
                //sources[0].Stop();
                sources[0].volume=0.1f;
                //sources[0].clip = sound1; //BGM変更
                //sources[0].Play();
                sources[1].volume=0.3f;
        }

        // Update is called once per frame
        void Update()
        {
                if(Mswich!=0) {
                        SE(Mswich);
                }
                //Debug.Log(sources[0].volume);
        }
        void SE(int se){
                if(se==1) sources[1].PlayOneShot(sound4); //電気get音
                if(se==2) sources[1].PlayOneShot(sound5); //pointget音
                if(se==3) {
                        sources[0].volume=0.0f;
                        sources[1].PlayOneShot(sound6); //警告音
                        Invoke("sound_stop", 3.5f);//3.5秒後に関数を呼び出す
                }
                if(se==4) {
                        sources[1].PlayOneShot(sound3); //時間終了音
                        sources[0].Stop();//BGMを止めてリトライ画面へ
                }
                if(se==5) {//タイトルからメインへBGM変更
                        sources[0].Stop();
                        sources[0].clip = sound2;                        //BGMをメイン用へ
                        sources[0].Play();
                }

                if(se==6) {//タイトルからメインへBGM変更
                        sources[0].Stop();
                        sources[0].clip = sound2;
                        sources[0].volume=0.1f;
                        sources[0].Play();
                }
                Mswich =0;
        }
        void sound_stop(){
                sources[0].volume=0.1f;
                sources[1].Stop();
        }
}
