using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UpGS.Data;


namespace UpGS.Pattern
{

	public interface IEventChannel
	{
		void Publish(string topic, string data);
		void Publish(string topic, bool data);
		void Subscribe(string topic, IEventSubscriber subscriber);
	}


	public class EventChannel:MonoSingleton<EventChannel>,IEventChannel
	{
		private Dictionary<string, List<IEventSubscriber>> _topics = 
			new Dictionary<string, List<IEventSubscriber>>();
		
		public void Publish(string topic, string data)
		{
			if(!_topics.ContainsKey(topic)) return;
			foreach(var subscriber in _topics[topic])
				subscriber.Notify(data);
		}

		public void Publish(string topic, bool data)
		{
			if(!_topics.ContainsKey(topic)) return;
			foreach(var subscriber in _topics[topic])
				subscriber.Notify(data);
		}

		
		public void Subscribe(string topic, IEventSubscriber subscriber)
		{
			if(_topics.ContainsKey(topic))
				_topics[topic].Add(subscriber);
			else
				_topics.Add(topic, new List<IEventSubscriber>() { subscriber });
		}
	}
	

}