using System.Collections;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UpGS.Data;
using UnityEngine.UI;

namespace UpGS.Painter
{
    public class PainterDrawable:FreeDraw.Drawable 
    {



//clonx 19.10.2018 -->
		override public void ClearDragPosition()
		{
			previous_drag_position = Vector2.zero;
		}

/*
		void Start()
		{
			GameControll.gameControll.PointerProcessorUp=OnPointerUp;
			GameControll.gameControll.PointerProcessorDown=OnPointerDown;
			GameControll.gameControll.PointerProcessorDrag = OnPointerDrag;
			previous_drag_position = Vector2.zero;
	    }

		public void OnPointerUp(PointerEventData data ) {
			previous_drag_position = Vector2.zero;
		}


		public void OnPointerDown(PointerEventData data ) {
				Vector2 mouse_world_position = Camera.main.ScreenToWorldPoint(data.position);
					previous_drag_position = Vector2.zero;
					current_brush(mouse_world_position);
		}

		public void OnPointerDrag(PointerEventData data ) {
				Vector2 mouse_world_position = Camera.main.ScreenToWorldPoint(data.position);
				current_brush(mouse_world_position);
		}
*/

        void Update()
        {
        }

		override public void MarkPixelsToColour(Vector2 center_pixel, int pen_thickness, Color color_of_pen)
		{
			// Figure out how many pixels we need to colour in each direction (x and y)
			int center_x = (int)center_pixel.x;
			int center_y = (int)center_pixel.y;
			int extra_radius = Mathf.Min(0, pen_thickness - 2);
			
			for (int x = center_x - pen_thickness; x <= center_x + pen_thickness; x++)
			{
				// Check if the X wraps around the image, so we don't draw pixels on the other side of the image
				if (x >= (int)drawable_sprite.rect.width
				    || x < 0)
					continue;
				
				for (int y = center_y - pen_thickness; y <= center_y + pen_thickness; y++)
				{
					if (Mathf.Round(Vector2.Distance(center_pixel,new Vector2(x,y)))<=pen_thickness) //clonx 15.10.2018
						MarkPixelToChange(x, y, color_of_pen);
				}
			}
		}
		
		override public void MarkPixelToChange(int x, int y, Color color)
		{
			// Need to transform x and y coordinates to flat coordinates of array
			int array_pos = y * (int)drawable_sprite.rect.width + x;
			
			// Check if this is a valid position
			if (array_pos > cur_colors.Length || array_pos < 0)
				return;
			
			cur_colors[array_pos] = color;
		}

		override public void SetFillBrush()
		{
			current_brush = FillBrush;
		}


		public void FillBrush(Vector2 world_point)
		{

			Vector3	v3=rectTransform.InverseTransformPoint(new Vector3(world_point.x,world_point.y,0));
			Vector2 canvas_point=new Vector2(v3.x,v3.y)-rectTransform.offsetMin;
                         
			TextureExtension.FloodFillArea(drawable_texture,Convert.ToInt32(canvas_point.x),Convert.ToInt32(canvas_point.y) , FreeDraw.Drawable.Pen_Colour);
			drawable_texture.Apply();
			cur_colors = drawable_texture.GetPixels32 (); //TODO: Использовать внутри FloodFillArea, Можно убрать нужна только для корректной команды Undo 	
			previous_drag_position = world_point;
		}

		override public void ResetCanvas()
		{
			base.ResetCanvas ();
			cur_colors = drawable_texture.GetPixels32 (); //TODO: make run 1 time only in start always
		}

//clonx 19.10.2018 <--
    }
}