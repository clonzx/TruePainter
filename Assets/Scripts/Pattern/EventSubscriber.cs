using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UpGS.Data;


namespace UpGS.Pattern
{
	public interface IEventSubscriber
	{
		void Notify(string data);
		void Notify(bool data);
	}
	
	public class EventSubscriber: MonoBehaviour, IEventSubscriber
	{
		public string m_subscription;

		public void Awake()
		{
			if (m_subscription != "")
				EventChannel.instance.Subscribe (m_subscription, this);
		}

		virtual public void Notify(string data)
		{
			if (GameControll.gameControll.DebugLog)
				Debug.Log ("Subscriber " + gameObject.name + " notify: " + data);
		}

		virtual public void Notify(bool data)
		{
			if (GameControll.gameControll.DebugLog)
				Debug.Log ("Subscriber " + gameObject.name + " notify: " + data);
		}

	}
	
}