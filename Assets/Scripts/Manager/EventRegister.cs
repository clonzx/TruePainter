using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UpGS.Manager
{
	public delegate void PointerProcessor(PointerEventData data );

	public class EventRegister : MonoSingleton<EventRegister> {
		protected PointerProcessor m_PointerProcessorUp;
		protected PointerProcessor m_PointerProcessorDown;
		protected PointerProcessor m_PointerProcessorDrag;


		public static void SetPointerProcessorUp(PointerProcessor _delegate)
		{
			instance.m_PointerProcessorUp = _delegate;
		}

		public static  void SetPointerProcessorDown(PointerProcessor _delegate)
		{
			instance.m_PointerProcessorDown = _delegate;
		}

		public static  void SetPointerProcessorDrag(PointerProcessor _delegate)
		{
			instance.m_PointerProcessorDrag = _delegate;
		}

		public static void PointerProcessorUp(PointerEventData data)
		{
			if (instance.m_PointerProcessorUp!=null)
				instance.m_PointerProcessorUp (data); 
		}

		public static  void PointerProcessorDown(PointerEventData data)
		{
			if (instance.m_PointerProcessorDown!=null)
				instance.m_PointerProcessorDown (data); 
		}

		public static  void PointerProcessorDrag(PointerEventData data)
		{
			if (instance.m_PointerProcessorDrag!=null)
				instance.m_PointerProcessorDrag (data); 
		}

	}
}