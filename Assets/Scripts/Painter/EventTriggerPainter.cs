using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UpGS.Data;
using UpGS.Manager;

namespace UpGS.Painter{
	public class EventTriggerPainter : EventTrigger {

		public override void OnBeginDrag(PointerEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnBeginDrag called.");
		}
		public override void OnCancel(BaseEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnCancel called.");
		}
		public override void OnDeselect(BaseEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnDeselect called.");
		}
		public override void OnDrag(PointerEventData data ) {
			EventRegister.PointerProcessorDrag (data);
			if (GameControll.gameControll.DebugLog) Debug.Log("OnDrag called. data="+data);
		}
		
		public override void OnDrop(PointerEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnDrop called. ");
		}
		public override void OnEndDrag(PointerEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnEndDrag called.");
		}
		public override void OnInitializePotentialDrag(PointerEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnInitializePotentialDrag called.");
		}
		public override void OnMove(AxisEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnMove called.");
		}
		public override void OnPointerClick(PointerEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnPointerClick called.");
		}
		public override void OnPointerDown(PointerEventData data ) {
			EventRegister.PointerProcessorDown(data);
			if (GameControll.gameControll.DebugLog) Debug.Log("OnPointerDown called. data="+data);
		}
		public override void OnPointerEnter(PointerEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnPointerEnter called.");
		}
		public override void OnPointerExit(PointerEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnPointerExit called.");
		}
		public override void OnPointerUp(PointerEventData data ) {
			EventRegister.PointerProcessorUp (data);
			if (GameControll.gameControll.DebugLog) Debug.Log("OnPointerUp called. data="+data);
		}
		
		public override void OnScroll(PointerEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnScroll called.");
		}
		public override void OnSelect(BaseEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnSelect called.");
		}
		public override void OnSubmit(BaseEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnSubmit called.");
		}
		public override void OnUpdateSelected(BaseEventData data ) {
			if (GameControll.gameControll.DebugLog) Debug.Log("OnUpdateSelected called.");
		}

	}
}