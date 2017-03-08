using System;
using System.Collections.Generic;
using System.IO;


namespace Labb1
{
	public class SortedPosList
	{

		private List<Position> posList = new List<Position>();

		private string SavedFilePath { get; set; }

		public Position this[int i]
		{
			get { return posList[i]; }
		}

		public int Count()
		{
			return posList.Count;
		}
		public void Add(Position pos)
		{
			for (int i = 0; i < Count(); i++)
			{
				if (pos < posList[i])
				{
					posList.Insert(i, pos);
					if (SavedFilePath != null)
					{
						Save();
					}
					return;
				}
			}
			posList.Add(pos);
		}
		public bool Remove(Position pos)
		{
			bool removed = false;
			for (int i = 0; i < Count(); i++)
			{
				if (pos.Equals(posList[i]))
				{
					posList.RemoveAt(i);
					i--;
					removed = true;
					if (SavedFilePath != null)
					{
						Save();
					}
				}
			}
            return removed;
		}
		public SortedPosList Clone()
		{
			SortedPosList newSortedPosList = new SortedPosList();
			foreach (Position p in posList)
			{
				newSortedPosList.Add(p.Clone());
			}
			return newSortedPosList;
        }

		public SortedPosList CircleContent(Position centerPos, double radius)
		{
			SortedPosList newSortedPList = new SortedPosList();
			double dis;
			foreach (Position p in posList)
			{
				dis = Math.Sqrt(Math.Pow(centerPos.XValue - p.XValue, 2) + (Math.Pow(centerPos.YValue - p.YValue, 2)));

				if (dis < radius)
				{
					newSortedPList.Add((p.Clone()));
				}
			}
			return newSortedPList;
		}

		public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
		{
			SortedPosList newSortedPList = sp1.Clone();

			for (int i = 0; i < sp2.Count(); i++)
			{
				newSortedPList.Add(sp2[i].Clone());
			}
            return newSortedPList;
		}

		public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
		{
			SortedPosList newSortedPList = sp1.Clone();

			for (int i = 0; i < sp2.Count(); i++)
			{
				newSortedPList.Remove(sp2[i]);
			}
			return newSortedPList;
		}

		public SortedPosList()
		{
			posList = new List<Position>();
			SavedFilePath = null;
		}

		public SortedPosList(string filePath)
		{
			SortedPosList syncedSortedPList = new SortedPosList();
			syncedSortedPList.SavedFilePath = filePath;
			SavedFilePath = filePath;

			if (File.Exists(filePath))
			{
                File.ReadAllText(SavedFilePath);
				Load();
            }
			else
			{
				File.Create(SavedFilePath).Dispose();
			}
		}

		public void Save()
		{
			File.WriteAllText(SavedFilePath, string.Join("\n", posList));

		}
		public void Load()
		{
			char[] sep1 = { '\n' };
			char[] sep2 = { ',', ')', '(' };
			string[] posArr;
			string file = File.ReadAllText(SavedFilePath);
			string[] posNr = file.Split(sep1, StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < posNr.Length; i++)
			{
				posArr = posNr[i].Split(sep2, StringSplitOptions.RemoveEmptyEntries);
				posList.Add(new Position(Int32.Parse(posArr[0]), Int32.Parse(posArr[1])));
            }
        }

		public override string ToString()
        {
            return string.Join(", ", posList);
        }
    }
}
