using System;

namespace Labb1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("G test begins" + "\n");
			Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
			Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
			Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
			Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");

			SortedPosList list1 = new SortedPosList();
			SortedPosList list2 = new SortedPosList();
			list1.Add(new Position(3, 7));
			list1.Add(new Position(1, 4));
			list1.Add(new Position(2, 6));
			list1.Add(new Position(2, 3));

			Console.WriteLine(list1 + "\n");
			list1.Remove(new Position(2, 6));
			Console.WriteLine(list1 + "\n");

			list2.Add(new Position(3, 7));
			list2.Add(new Position(1, 2));
			list2.Add(new Position(3, 6));
			list2.Add(new Position(2, 3));

			Console.WriteLine((list2 + list1) + "\n");

			SortedPosList circleList = new SortedPosList();
			circleList.Add(new Position(1, 1));
			circleList.Add(new Position(2, 2));
			circleList.Add(new Position(3, 3));
			Console.WriteLine(circleList.CircleContent(new Position(5, 5), 4) + "\n");
			Console.WriteLine("G Test end" + "\n");
			Console.WriteLine("VG test begins" + "\n");

			Console.WriteLine("Tests for subtraction operator. Removes positions in list 1 that exists in list2 " +
							  "and prints numbers in list1. Should return (1,4)");

			Console.WriteLine("End of comment" + "\n");
			Console.WriteLine(list1 - list2 + "\n");

			Console.WriteLine("Tests for subtraction operator. Removes positions in list2 that exists in list1 " +
							  "and prints numbers in list1. Should return (1,2) and (3,6)");

			Console.WriteLine("End of comment" + "\n");
			Console.WriteLine(list2 - list1 + "\n");

			Console.WriteLine("Test for adding positions to a synced list. Creates a new SortedPosList with filePath " +
							  "argument. Adds positions to the list and removes one position and then Loads the file " +
							  "and displays the file content in console. Should display (8, 2)(8,3)(8,7) first time" +
			                  "and 6 second time and so on");
			Console.WriteLine("End of comment" + "\n");


			SortedPosList list3 = new SortedPosList("test.txt");

			list3.Add(new Position(8, 7));
			list3.Add(new Position(8, 2));
			list3.Add(new Position(8, 6));
			list3.Add(new Position(8, 3));
			list3.Remove(new Position(8, 6));
			Console.WriteLine(list3);
			Console.WriteLine("\n");

			Console.WriteLine("Test for reading from file. Creates a new SortedPosList with filePath argument. Loads the file and " +
				"displays a list of positions. The file should display a list of positions written by the user.");
			Console.WriteLine("End of comment" + "\n");

			//You need a text2.txt filled with positions for this to work or it will not show anything.
			SortedPosList list4 = new SortedPosList("test2.txt");
			Console.WriteLine(list4);
			Console.WriteLine("\n");

			Console.WriteLine("VG test end" + "\n");

			list3.Add(new Position(5, 5));
			list3.Add(new Position(4, 5));
			list3.Add(new Position(33, 6));
			list3.Add(new Position(11, 3));

		}
	}
}
