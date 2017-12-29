﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedPoint : Point{
	public List<Point> Parents = new List<Point>();

	public LinkedPoint() : base(){
	}
	public LinkedPoint(float xi, float zi) : base(xi, zi){
	}
	public LinkedPoint(Point p) : base(p){
	}
}

public class Point {
	public int x;
	public int z;
	public Point Father;
	public float Depth = 0;

	public static Point pivot;
	public static Point Limits;

	public Point(){
		x = 0;
		z = 0;
	}
	public Point(GameObject go){
		x = (int) go.transform.position.x;
		z = (int) go.transform.position.z;
	}
	public Point(Monster mon){
		x = (int) mon.Point.x;
		z = (int) mon.Point.z;
	}
	public Point(Point p){
		x = p.x;
		z = p.z;
	}

	public Point(float xi, float zi, float Depth = 0){
		this.Depth = Depth;
		x = (int) xi;
		z = (int) zi;
	}

	public bool WithinLimits(){
		return (this.x >= 0 && this.x < Limits.x && this.z >= 0 && this.z < Limits.z);
	}

	public static int Distance(Point a, Point b){
		return (int) (Mathf.Abs(b.x - a.x) + Mathf.Abs(b.z - a.z));
	}

	public static Point operator + (Point a, Point b){
		return new Point(a.x + b.x, a.z + b.z);
	}
	public static Point operator - (Point a, Point b){
		return new Point(a.x - b.x, a.z - b.z);
	}
	public static bool operator == (Point a, Point b){
		if(((object) a == null) || ((object) b == null)) return ((object) a == (object) b);
		return ((a.x == b.x) && (a.z == b.z));
	}
	public static bool operator != (Point a, Point b){
		if(((object) a == null) || ((object) b == null)) return !((object) a == (object) b);
		return !((a.x == b.x) && (a.z == b.z));
	}

	public static int DistancePivot(Point a, Point b){
		int da = Distance(a, pivot);
		int db = Distance(b, pivot);
		return da.CompareTo(db);
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		Point b = (Point) obj;
		return ((this.x == b.x) && (this.z == b.z));
	}
	
	public override string ToString(){
		return "("+x+", "+z+")";
	}


}
