using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class jump : MonoBehaviour {

    
    private float power = 0.0f;         //
    private float powerScale = 100.0f;  //パワーにかける倍率

    private float p2 = 0;

    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
        //右コントローラーと左コントローラーの差を取得
        power = InputTracking.GetLocalPosition(VRNode.RightHand).y - InputTracking.GetLocalPosition(VRNode.LeftHand).y;
 
        //このオブジェクトのY軸に力を加える
        this.transform.GetComponent<Rigidbody>().AddForce(0, power * powerScale, 0);

        //前方向の力
        //p2 = InputTracking.GetLocalPosition(VRNode.RightHand).z - InputTracking.GetLocalPosition(VRNode.LeftHand).z;
        //オブジェクトに前方向の力を加える
        //this.transform.GetComponent<Rigidbody>().AddForce(p2 * powerScale * Mathf.Sin(this.transform.rotation.y), 0, p2 * powerScale * Mathf.Cos(this.transform.rotation.y));


        if (this.transform.position.y <= 1)
        {
            //地面を貫通させない処置
            this.transform.position = new Vector3( 0, 1, 0);
        }
    }
}
