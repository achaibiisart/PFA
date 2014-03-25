using UnityEngine;
using System.Collections;

public class Collisionaura : MonoBehaviour {
	rockete script;
	// Use this for initialization
	void Start () {
		script=GameObject.Find("viseearme").GetComponent<rockete>();

	}
	
	void OnCollisionEnter(Collision other){
	if (other.gameObject.tag=="enncube"&& script.randomnum==1)
		{
				Debug.Log("pasaiecube");
			script.selection+=3;
		}
	else if(ohter.gameObject.tag=="enncube")
	{
		Debug.Log("aouch");
	}
	if (other.gameObject.tag=="ennsphere"&& script.randomnum==0)
			{
				Debug.Log("pasaisphere");
						script.selection+=2;

		}
		if (other.gameObject.tag=="enncyl"&& script.randomnum==2)
			{
				Debug.Log("pasaiecyl");	
						script.selection+=3;

		}
	}
		
	// Update is called once per frame
	void Update () {
	}
}
