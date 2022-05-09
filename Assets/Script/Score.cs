using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
        public static int point=0;
        Text Display_point;
        public static int pointin=0;
        void Start()
        {
                point=0;
                Display_point=GetComponent<Text>();
        }

        void Update()
        {
                if(pointin!=0) {
                        point+=pointin*10;
                        if(pointin>10) point+=1000;
                        if(pointin>13) point+=1000;
                        pointin=0;
                }
                if(point<0) point=0;
                Display_point.text="Score:"+point.ToString("D5");
        }
}
