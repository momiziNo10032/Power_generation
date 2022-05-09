using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
        // 位置座標
        private Vector3 position;
        // スクリーン座標をワールド座標に変換した位置座標
        private Vector3 screenToWorldPointPosition;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
                // Vector3でマウス位置座標を取得する
                position = Input.mousePosition;
                // マウス位置座標をスクリーン座標からワールド座標に変換する
                screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
                var rotation = Quaternion.LookRotation(Vector3.forward, screenToWorldPointPosition);
                transform.localRotation = rotation;
        }
}
