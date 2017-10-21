using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Sensor : MonoBehaviour {

    public float x, y, z;
    public double yaw, pitch, roll, xF, yF, zF;
    public Quaternion MyRotation = Quaternion.identity;
    public bool ZoomSMART, SensitivityX2, SaveData, StartExperiment;
    //public float yRotation = 5.0F;
    private int j, i, h;
    SerialPort serial = new SerialPort("COM3", 250000);//7 3

    void Start() {
        /*serial.Open();
        serial.ReadTimeout = 50;//50*/

    }

    // Update is called once per frame
    void Update()
    {

        transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
         

		{
			try
			{

				//sp.Write("0");
				//print(serial.ReadByte());//esto imprime las opciones en arduino
			
				/*serial.Write ("a");
				GetdataFunctionPitch(serial.ReadByte());
				serial.Write("b");
				GetdataFunctionYaw(serial.ReadByte());*/




			}
			catch(System.Exception)
			{	
			}

//			x = x / 10;
//			y = y / 10;
			//yRotation += Input.GetAxis ("Horizontal");
			transform.eulerAngles = new Vector3 (y,x, 0);//y 0 z
			MyRotation.eulerAngles = new Vector3 (y,x, 0);//y 0 z
			transform.localScale = new Vector3 (0.01F, 0.01F, 0.01F);
			yaw   = (double) Mathf.Atan2(2.0f * (MyRotation.y*MyRotation.z+ MyRotation.x * MyRotation.w), MyRotation.x *MyRotation.x + MyRotation.y * MyRotation.y - MyRotation.z* MyRotation.z - MyRotation.w * MyRotation.w)*Mathf.Rad2Deg;   
			pitch = (double) -Mathf.Asin(2.0f * (MyRotation.y * MyRotation.w - MyRotation.x * MyRotation.z))*Mathf.Rad2Deg;
			roll  = (double) Mathf.Atan2(2.0f * (MyRotation.x  * MyRotation.y + MyRotation.z * MyRotation.w), MyRotation.x  * MyRotation.x - MyRotation.y  * MyRotation.y  - MyRotation.z * MyRotation.z  + MyRotation.w  * MyRotation.w)*Mathf.Rad2Deg; 			//print(transform.eulerAngles.x);
			if (yaw < 0)
				yaw = yaw * -1;
			if (pitch < 0)
			pitch = pitch * -1;
			if (roll < 0)
				roll = roll * -1;
			if (SaveData == true)
				Txt_Data ();
			if (ZoomSMART == true)
			transform.localScale = new Vector3 (0.02F, 0.02F, 0.02F);
			if (SensitivityX2 == true){
				transform.eulerAngles = new Vector3 ((y)*2F,(x)*2F, 0);//y 0 z
				MyRotation.eulerAngles = new Vector3 ((y)*2F,(x)*2F, 0);//y 0 z

			}
			if (StartExperiment == true) {
				Debug.Log ("Start Experiment");
				StartExperiment = false;
			}
			xF = (double) MyRotation.eulerAngles.x*Mathf.Rad2Deg;;
			yF = (double) MyRotation.eulerAngles.y*Mathf.Rad2Deg;;
			

		}	//if (!serial.IsOpen)


			}
	void GetdataFunctionPitch(float data){
		x = data;






	}
	void GetdataFunctionYaw(float data){
		y = data;



		}
	
	void Txt_Data()
	{
		 
		Debug.Log(pitch+"  "+yaw+"  "+roll+"  "+xF+"  "+yF+"  "+zF+"  "+MyRotation.x+"  "+MyRotation.y+"  "+MyRotation.z );//File.Write(xx[i].ToString()+"\r\n");
//		print(transform.localRotation.x);
       
	}
		//File.Close();
//		StreamWriter File = new StreamWriter ("TestTest1.txt");
//
//		SortedList<float,int> output = new SortedList<float,int> (){};
//		if (SaveData == true) {
//
//			j++;		
//			output.Add (x, j);
//				
//
//		}
//		foreach (KeyValuePair<float,int> listItem in output) {
//			File.WriteLine(listItem.ToString () + "\r\n");
//
//		}
//		File.Close();//
//		foreach (float listItem in output) {
//						File.Write(listItem.ToString()+"\r\n");
//		}


//		float [] output= new float[N];
//		for ( i = 0; i < output.Count; i++) 
//		{
//			output [i] = x;
//			File.Write(output[i].ToString()+"\r\n");
//		}
//
//		File.Close();


    


}

    