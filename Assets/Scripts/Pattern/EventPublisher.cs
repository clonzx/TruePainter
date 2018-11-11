using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UpGS.Data;


namespace UpGS.Pattern
{

	public interface IEventPublisher
	{
		void Publish(string data);
	}

	public class EventPublisher: MonoBehaviour, IEventPublisher
	{
		public string m_topic;

		public void Publish(string data)
		{
			EventChannel.instance.Publish(m_topic, data);
		}

		public void Publish(bool data)
		{
			EventChannel.instance.Publish(m_topic, data);
		}

	}

	public class EventPublisherSys:  IEventPublisher
		//if not need MonoBehaviour
	{
		public string m_topic;
		public EventPublisherSys(string _topic)
		{
			m_topic = _topic;
		}
		
		public void Publish(string data)
		{
			EventChannel.instance.Publish(m_topic, data);
		}
		
		public void Publish(bool data)
		{
			EventChannel.instance.Publish(m_topic, data);
		}
	}

	public class EventPublisherTopics
		//if not need MonoBehaviour and public many topics
	{
		public void Publish(string topic, string data)
		{
			EventChannel.instance.Publish(topic, data);
		}
		
		public void Publish(string topic, bool data)
		{
			EventChannel.instance.Publish(topic, data);
		}
	}
}