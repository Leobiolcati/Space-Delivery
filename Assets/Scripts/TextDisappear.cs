using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisappear : MonoBehaviour{
	public float time = 10; //Seconds to read the text

	IEnumerator Start ()
	{
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}