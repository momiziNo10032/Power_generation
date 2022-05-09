using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil_attack : MonoBehaviour
{
        public int coil_number=0;
        void Start()
        {
                if(gameObject.name=="coil_up") coil_number=1;
                if(gameObject.name=="coil_down") coil_number=2;
                if(gameObject.name=="coil_left") coil_number=3;
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
                Debug.Log(collision.gameObject.name);
                Main_System.elect_power++;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
                //Debug.Log(collision.gameObject.name);
                //Main_System.elect_power++;
                Main_System.elect_swich[coil_number]=true;
        }
}
