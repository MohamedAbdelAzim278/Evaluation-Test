/*
	TUIO C# Demo - part of the reacTIVision project
	http://reactivision.sourceforge.net/

	Copyright (c) 2005-2009 Martin Kaltenbrunner <martin@tuio.org>

	This program is free software; you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation; either version 2 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
*/

using System;
using System.Drawing;
using TUIO;

public class TuioDemoObject : TuioObject 
{

	SolidBrush black = new SolidBrush(Color.Black);
	SolidBrush white = new SolidBrush(Color.White);
	SolidBrush red = new SolidBrush(Color.Red);
	public TuioDemoObject(long s_id, int f_id, float xpos, float ypos, float angle) : base(s_id, f_id, xpos, ypos, angle)
	{
	}

	public TuioDemoObject(TuioObject o) : base(o)
	{
	}

	public void paint(Graphics g, int check1, int check2, int check3)
	{
		int check4 = 0;
		int xRocket;
		int Xpos = (int)(xpos * TuioDemo.width);
		int Ypos = (int)(ypos * TuioDemo.height);
		int size = TuioDemo.height / 10;
		if (symbol_id == 1)
		{
			g.TranslateTransform(Xpos, Ypos);
			
			g.RotateTransform((float)(angle / Math.PI * 180.0f));
			g.TranslateTransform(-1 * Xpos, -1 * Ypos);

            g.FillRectangle(red, new Rectangle(Xpos - size / 2, Ypos - size / 2, size, size));

			g.TranslateTransform(Xpos, Ypos);
			g.RotateTransform(-1 * (float)(angle / Math.PI * 180.0f));
			g.TranslateTransform(-1 * Xpos, -1 * Ypos);
			//if (Xpos + size / 2 > 400) 
			//	g.Clear(Color.Yellow);
		}
		if (symbol_id == 2)
		{
			g.TranslateTransform(Xpos, Ypos);
			g.RotateTransform((float)(angle / Math.PI * 180.0f));
			g.TranslateTransform(-1 * Xpos, -1 * Ypos);
			g.FillRectangle(black, new Rectangle(Xpos - size / 2, Ypos - size / 2, size, size));

			g.TranslateTransform(Xpos, Ypos);
			g.RotateTransform(-1 * (float)(angle / Math.PI * 180.0f));
			g.TranslateTransform(-1 * Xpos, -1 * Ypos);
		}
		if (symbol_id == 3)
		{
			g.TranslateTransform(Xpos, Ypos);
			g.RotateTransform((float)(angle / Math.PI * 180.0f));
			g.TranslateTransform(-1 * Xpos, -1 * Ypos);

			g.FillRectangle(black, new Rectangle(Xpos - size / 2, Ypos - size / 2, size, size));

			g.TranslateTransform(Xpos, Ypos);
			g.RotateTransform(-1 * (float)(angle / Math.PI * 180.0f));
			g.TranslateTransform(-1 * Xpos, -1 * Ypos);
		}
		if(symbol_id==4)
		{
			check4 = 1;
			Pen pen = new Pen(Color.Blue);
			g.DrawLine(pen, 400, 0, 400, 1000);
			g.TranslateTransform(Xpos, Ypos);
			g.RotateTransform((float)(angle / Math.PI * 180.0f));
			g.TranslateTransform(-1 * Xpos, -1 * Ypos);
			g.FillRectangle(black, new Rectangle(Xpos - size / 2, Ypos - size / 2, size, size));

			g.TranslateTransform(Xpos, Ypos);
			g.RotateTransform(-1 * (float)(angle / Math.PI * 180.0f));
			g.TranslateTransform(-1 * Xpos, -1 * Ypos);
			if (Xpos + size / 2 > 400)
				check4 = 2;
		}
			Font font = new Font("Arial", 10.0f);
			g.DrawString(symbol_id + "", font, white, new PointF(Xpos - 10, Ypos - 10));
		if (check1 == 1 && check2 == 1 && check3 == 1)
        {
			Bitmap im2 = new Bitmap("Ruined.png");
			im2.MakeTransparent(im2.GetPixel(0, 0));
			g.DrawImage(im2, 400, 400, 250, 80);
			 im2 = new Bitmap("Rocket2.png");
			im2.MakeTransparent(im2.GetPixel(0, 0));
			g.DrawImage(im2, 400, 400, 50, 50);
			check2 = 0; check3 = 0;
		}
		drawScene(g, check1, check2, check3,check4);
	}
	public void drawScene(Graphics g, int check1, int check2, int check3, int check4)
	{
		if (check1 == 1)
		{
			Bitmap im2 = new Bitmap("Tank.jpg");
			im2.MakeTransparent(im2.GetPixel(0, 0));
			g.DrawImage(im2, 0, 400, 150, 100);
		}
		if(check2==1)
        {
			Bitmap im2 = new Bitmap("Building.jpg");
			im2.MakeTransparent(im2.GetPixel(0, 0));
			g.DrawImage(im2, 400, 400, 250, 80);
		}
		if(check3==1)
        {
			Bitmap im2 = new Bitmap("Rocket.png");
			im2.MakeTransparent(im2.GetPixel(0, 0));
			g.DrawImage(im2, 150, 400, 50, 50);
		}
		if (check4 == 1)
		{
			Bitmap im2 = new Bitmap("boy.png");
			im2.MakeTransparent(im2.GetPixel(0, 0));
			g.DrawImage(im2, 100, 200,200,200);
		}
		if (check4 == 2)
		{
			Bitmap im2 = new Bitmap("bean.png");
			im2.MakeTransparent(im2.GetPixel(0, 0));
			g.DrawImage(im2, 100, 200, 200, 200);
		}

	}
}
