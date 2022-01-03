using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curves
{
	public static Vector3[] generateCubicBezier(Vector3 startingPoint, Vector3 controlPoint_1, Vector3 controlPoint_2, Vector3 endPoint, int detail)
	{

		List<Vector3> result = new List<Vector3>();
		result.Add(startingPoint);

		for (int i = 0; i <= detail; i++)
		{
			float t = (float) i / (float)detail;
			float t2 = t * t;
			float tsub = 1 - t;
			float tsub2 = tsub * tsub; 
			result.Add((tsub2 * tsub * (startingPoint)) + (3 * t * tsub2 * (controlPoint_1)) + (3 * t2 * tsub * (controlPoint_2)) + (t * t2 * endPoint));
		}
		result.Add(endPoint);
		return result.ToArray();
	}

	public static Vector3[] generateQuadraticBezier(Vector3 startingPoint, Vector3 controlPoint, Vector3 endPoint, int detail)
	{
		List<Vector3> result = new List<Vector3>();
		result.Add(startingPoint);

		for (int i = 0; i <= detail; i++)
		{
			
			float t =  (float) i / (float) detail;
			float t2 = t * t;
			float tsub = 1 - t;
			float tsub2 = tsub * tsub;

			result.Add(controlPoint + (tsub2 * (startingPoint - controlPoint)) + (t2 *(endPoint - controlPoint)));
		}
		result.Add(endPoint);
		return result.ToArray();
	}
}
