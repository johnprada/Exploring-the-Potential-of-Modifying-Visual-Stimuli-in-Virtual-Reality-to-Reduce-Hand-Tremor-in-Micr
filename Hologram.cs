using UnityEngine;
using System.Collections;

public class Hologram : MonoBehaviour {

	public GameObject Model ;
	public float xF,yF,zF;
	public bool SetPosition;
	public bool ZoomSMART;

	// Use this for initialization


	// Update is called once per frame
	void Update () {
		float[] Posx = new float [1];
		float[] Posy = new float [1];
		float[] Posz = new float [1];
//		float[] Posxx = new float [1];
//		float[] Posyy = new float [1];
//		float[] Poszz = new float [1];

		xF = (float)Model.transform.eulerAngles.x;
		yF = (float) Model.transform.eulerAngles.y;
		zF = (float)Model.transform.eulerAngles.z;
//				xxF = (float)Model.transform.rotation.x;
//				yyF = (float) Model.transform.rotation.y;
//				zzF = (float)Model.transform.rotation.z;
		Posx[0] = xF;
		Posy [0]= yF;
		Posz [0]= zF;
//		Posxx[0] = xxF;
//		Posyy [0]= yyF;
//		Poszz [0]= zzF;
		transform.position= Model.transform.position;
        transform.localScale = new Vector3(0.01F, 0.01F, 0.01F);
        if (SetPosition==true){
			transform.eulerAngles = new Vector3 (Posx[0],Posy[0],Posz[0]);//y 0 z
			transform.rotation= Model.transform.rotation;
			transform.position= Model.transform.position;
		}
		if( ZoomSMART==true)
            transform.localScale = new Vector3(0.02F, 0.02F, 0.02F);
    }
}
