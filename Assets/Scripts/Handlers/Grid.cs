using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
	public int horizontalSize;
	public int verticalSize;
	public List<Vector3> OccupiedCells = new List<Vector3>();

	private void Start()
	{

	}
	public Vector3 generateRandomCell()
	{
		Vector3 coords = new Vector3((int)Random.Range(-horizontalSize / 2, horizontalSize / 2), 0, (int)Random.Range(-verticalSize / 2, verticalSize / 2));
		if (!OccupiedCells.Contains(coords))
		{
			OccupiedCells.Add(coords);
			return coords;
		}
		else
		{
			return generateRandomCell();
		}
	}


	public List<Vector3> generateRandomRow()
	{
		List<Vector3> positions = new List<Vector3>();
		int index = (int)Random.Range(-verticalSize / 2, verticalSize / 2);
		for (int i = -horizontalSize / 2; i <= horizontalSize / 2; i += 1)
		{
			positions.Add(new Vector3(i, 0, index));
		}

		return positions;
	}
	public List<Vector3> generateRandomColumn()
	{
		List<Vector3> positions = new List<Vector3>();
		int index = (int)Random.Range(-verticalSize / 2, verticalSize / 2);
		for (int i = -verticalSize / 2  ; i <= verticalSize / 2; i += 1)
		{
			positions.Add(new Vector3(index, 0, i));
		}

		return positions;
	}

	public List<Vector3> generateRandomQuadrant()
	{
		List<Vector3> positions = new List<Vector3>();
		int index = Random.Range(0, 4);
		switch (index)
		{
			case 0:
				for (int j = 0; j <= horizontalSize / 2; j++)
				{
					for (int i = 0; i <= verticalSize / 2; i++)
					{
						positions.Add(new Vector3(j, 0, i));
					}
				}
				break;
			case 1:
				for (int j = 0; j <= horizontalSize / 2; j++)
				{
					for (int i = -verticalSize / 2; i <= 0; i += 1)
					{
						positions.Add(new Vector3(j, 0, i));
					}
				}
				break;
			case 2:
				for (int j = -horizontalSize / 2; j <= 0; j += 1)
				{
					for (int i = 0; i <= verticalSize / 2; i++)
					{
						positions.Add(new Vector3(j, 0, i));
					}
				}
				break;
			case 3:
				for (int j = -horizontalSize / 2; j <= 0; j += 1)
				{
					for (int i = -verticalSize / 2; i <= 0; i += 1)
					{
						positions.Add(new Vector3(j, 0,i));
					}
				}
				break;
			default:
				for (int j = 0; j <= horizontalSize / 2; j++)
				{
					for (int i = 0; i <= verticalSize / 2; i++)
					{
						positions.Add(new Vector3(j, 0, i));
					}
				}
				break;
		}


		return positions;
	}



	private void OnDrawGizmos()
	{
		for (int i = -horizontalSize / 2; i <= horizontalSize / 2; i += 1)
		{
			for (int j = -verticalSize / 2; j <= verticalSize / 2; j += 1)
			{
				Gizmos.DrawWireCube(new Vector3(i, 0, j), new Vector3(1, .15f, 1));

			}
		}
	}
}
