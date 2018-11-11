using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UpGS.Data;


namespace UpGS.Pattern
{

	public class EventSubscriberUI: EventSubscriber
	{

		override public void Notify(string data)
		{
			Text txt = gameObject.GetComponent<Text> ();
			if (txt)
				txt.text = data;
		}

		override public void Notify(bool data)
		{
			gameObject.SetActive (data);
		}

	}
	
}