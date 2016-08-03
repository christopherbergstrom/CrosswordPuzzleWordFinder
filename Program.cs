using System;
using System.Linq;
using System.Collections;

namespace CrosswordFinder
{
	public static class PuzzleSolver
	{
		public static string[] DICTIONARY = { "OX", "CAT", "TOY", "AT", "DOG", "CATAPULT", "T" };
		public static int count = 0;
		public static bool first = true;
		public static string wordsFound = "";
		public static ArrayList coorArray = new ArrayList();

		public static void Main(string[] args)
		{
			char[,] c = new char[3, 3] {
			{'C', 'A', 'T'},
			{'X', 'Z', 'T'},
			{'Y', 'O', 'T'}
		};
			//char[,] c = new char[3, 8] {
			//	{'C', 'A', 'T', 'A', 'P', 'U', 'L', 'T'},
			//	{'X', 'Z', 'T', 'T', 'O', 'Y', 'O', 'O'},
			//	{'Y', 'O', 'T', 'O', 'X', 'T', 'X', 'X'}
			//};

			FindWords(c);
			Console.WriteLine("Total words found: " + count);
			Console.WriteLine(wordsFound);
		}

		public static string ReverseString(string s)
		{
			char[] arr = s.ToCharArray();
			Array.Reverse(arr);
			return new string(arr);
		}
		static bool IsWord(string testWord)
		{
			if (DICTIONARY.Contains(testWord))
				return true;
			return false;
		}
		static bool IsCoor(string testCoor)
		{
			if (coorArray.Contains(testCoor))
			{
				return true;
			}
			return false;
		}
		public static int FindWords(char[,] puzzle)
		{
			int x = (puzzle.GetLength(0));
			int y = (puzzle.GetLength(1));
			for (int i = 0; i < puzzle.GetLength(0); i++)
			{
				for (int j = 0; j < puzzle.GetLength(1); j++)
				{
					for (int k = 1; k <= Math.Max(x, y); k++)
					{
						calcCheck(puzzle, i, j, k, x, y, first);
					}
					first = true;
				}
			}
			return count;
		}
		public static void calcCheck(char[,] puzzle, int x, int y, int inc, int xMax, int yMax, bool firstTime)
		{
			Console.WriteLine("\n[" + x + "," + y + "] in " + inc + "\n");

			string lettersToCheck = "";
			if (firstTime)
			{
				// single letter
				first = false;
				lettersToCheck = puzzle[x, y].ToString();
				Console.WriteLine("in first");
				checkForWord(lettersToCheck, "", "");
				lettersToCheck = "";
			}
			else
			{
				// up
				if (x - inc >= -1)
				{
					Console.WriteLine("in up");
					string[] tempCoor = new string[inc];
					for (int i = 0; i < inc; i++)
					{
						tempCoor[i] = (x - i) + "" + y;
						lettersToCheck += puzzle[x - i, y].ToString();
					}
					string[] tempCoorRev = tempCoor;
					Array.Reverse(tempCoorRev);
					checkForWord(lettersToCheck, string.Join("", tempCoor), string.Join("", tempCoorRev));
					lettersToCheck = "";
				}
				// down
				if (x + inc <= xMax)
				{
					Console.WriteLine("in down");
					string[] tempCoor = new string[inc];
					for (int i = 0; i < inc; i++)
					{
						tempCoor[i] = (x + i) + "" + y;
						lettersToCheck += puzzle[x + i, y].ToString();
					}
					string[] tempCoorRev = tempCoor;
					Array.Reverse(tempCoorRev);
					checkForWord(lettersToCheck, string.Join("", tempCoor), string.Join("", tempCoorRev));
					lettersToCheck = "";
				}
				// left
				if (y - inc >= -1)
				{
					Console.WriteLine("in left");
					string[] tempCoor = new string[inc];
					for (int i = 0; i < inc; i++)
					{
						tempCoor[i] = x + "" + (y - i);
						lettersToCheck += puzzle[x, y - i].ToString();
					}
					string[] tempCoorRev = tempCoor;
					Array.Reverse(tempCoorRev);
					checkForWord(lettersToCheck, string.Join("", tempCoor), string.Join("", tempCoorRev));
					lettersToCheck = "";
				}
				// right
				if (y + inc <= yMax)
				{
					Console.WriteLine("in right");
					string[] tempCoor = new string[inc];
					for (int i = 0; i < inc; i++)
					{
						tempCoor[i] = x + "" + (y + i);
						lettersToCheck += puzzle[x, y + i].ToString();
					}
					string[] tempCoorRev = tempCoor;
					Array.Reverse(tempCoorRev);
					checkForWord(lettersToCheck, string.Join("", tempCoor), string.Join("", tempCoorRev));
					lettersToCheck = "";
				}
				// up left
				if (x - inc >= -1 && y - inc >= -1)
				{
					Console.WriteLine("in upLeft");
					string[] tempCoor = new string[inc];
					for (int i = 0; i < inc; i++)
					{
						tempCoor[i] = (x - i) + "" + (y - i);
						lettersToCheck += puzzle[x - i, y - i].ToString();
					}
					string[] tempCoorRev = tempCoor;
					Array.Reverse(tempCoorRev);
					checkForWord(lettersToCheck, string.Join("", tempCoor), string.Join("", tempCoorRev));
					lettersToCheck = "";
				}
				// up right
				if (x - inc >= -1 && y + inc <= yMax)
				{
					Console.WriteLine("in upRight");
					string[] tempCoor = new string[inc];
					for (int i = 0; i < inc; i++)
					{
						tempCoor[i] = (x - i) + "" + (y + i);
						lettersToCheck += puzzle[x - i, y + i].ToString();
					}
					string[] tempCoorRev = tempCoor;
					Array.Reverse(tempCoorRev);
					checkForWord(lettersToCheck, string.Join("", tempCoor), string.Join("", tempCoorRev));
					lettersToCheck = "";
				}
				// down left
				if (x + inc <= xMax && y - inc >= -1)
				{
					Console.WriteLine("in downLeft");
					string[] tempCoor = new string[inc];
					for (int i = 0; i < inc; i++)
					{
						tempCoor[i] = (x + i) + "" + (y - i);
						lettersToCheck += puzzle[x + i, y - i].ToString();
					}
					string[] tempCoorRev = tempCoor;
					Array.Reverse(tempCoorRev);
					checkForWord(lettersToCheck, string.Join("", tempCoor), string.Join("", tempCoorRev));
					lettersToCheck = "";
				}
				// down right
				if (x + inc <= xMax && y + inc <= yMax)
				{
					Console.WriteLine("in downRight");
					string[] tempCoor = new string[inc];
					for (int i = 0; i < inc; i++)
					{
						tempCoor[i] = (x + i) + "" + (y + i);
						lettersToCheck += puzzle[x + i, y + i].ToString();
					}
					string[] tempCoorRev = tempCoor;
					Array.Reverse(tempCoorRev);
					checkForWord(lettersToCheck, string.Join("", tempCoor), string.Join("", tempCoorRev));
					lettersToCheck = "";
				}
			}
		}
		public static bool checkForWord(string word, string tempCoor, string tempCoorRev)
		{
			Console.WriteLine("WORD: " + word);
			if (IsWord(word) && !IsCoor(tempCoor))
			{
				Console.WriteLine("!!! FOUND WORD !!!");
				Console.WriteLine("WORD: " + word);
				wordsFound += (" " + word);
				count++;
				return true;
			}
			else
				return false;
		}
	}

}
