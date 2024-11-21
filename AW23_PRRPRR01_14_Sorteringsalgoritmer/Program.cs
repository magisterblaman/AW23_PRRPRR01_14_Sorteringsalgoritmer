using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW23_PRRPRR01_14_Sorteringsalgoritmer {
	internal class Program {
		static bool IsSorted(int[] inputArray) {
			for (int i = 1; i < inputArray.Length; i++) {
				if (inputArray[i] < inputArray[i - 1]) {
					return false;
				}
			}
			return true;
		}

		static void BubbleSort(int[] inputArray) {
			for (int j = inputArray.Length; j > 0; j--) {
				for (int i = 1; i < j; i++) {
					if (inputArray[i] < inputArray[i - 1]) {
						int temp = inputArray[i];
						inputArray[i - 1] = inputArray[i];
						inputArray[i] = temp;
					}
				}
			}
		}

		static int MinIndex(int[] inputArray, int startIndex) {
			int minValue = int.MaxValue;
			int minIndex = -1;
			for (int i = startIndex; i < inputArray.Length; i++) {
				if (inputArray[i] < minValue) {
					minValue = inputArray[i];
					minIndex = i;
				}
			}
			return minIndex;
		}

		static void SelectionSort(int[] inputArray) {
			for (int i = 0; i < inputArray.Length; i++) {
				int min = MinIndex(inputArray, i);

				int temp = inputArray[i];
				inputArray[i] = inputArray[min];
				inputArray[min] = temp;
			}
		}

		static void InsertionSort(int[] inputArray) {
			for (int i = 1; i < inputArray.Length; i++) {
				int value = inputArray[i];

				int j = i - 1;
				while (j >= 0 && inputArray[j] > value) {
					inputArray[j + 1] = inputArray[j];
					j--;
				}
				inputArray[j + 1] = value;
			}
		}

		static void Main(string[] args) {
			int[] myArray = new int[] { 7, 5, -3, 1, 5465, 76, 4, 3, -3 };

			Console.WriteLine(IsSorted(myArray));

			InsertionSort(myArray);

			Console.WriteLine(IsSorted(myArray));

			//for (int j = myArray.Length; j > 0; j--) {
			//	for (int i = 1; i < j; i++) {
			//		if (myArray[i] < myArray[i - 1]) {
			//			int temp = myArray[i];
			//			myArray[i - 1] = myArray[i];
			//			myArray[i] = temp;
			//		}
			//	}
			//}

			//for (int i = 1; i < myArray.Length - 0; i++) {
			//	if (myArray[i] < myArray[i - 1]) {
			//		int temp = myArray[i];
			//		myArray[i - 1] = myArray[i];
			//		myArray[i] = temp;
			//	}
			//}

			//for (int i = 1; i < myArray.Length - 1; i++) {
			//	if (myArray[i] < myArray[i - 1]) {
			//		int temp = myArray[i];
			//		myArray[i - 1] = myArray[i];
			//		myArray[i] = temp;
			//	}
			//}

			//for (int i = 1; i < myArray.Length - 2; i++) {
			//	if (myArray[i] < myArray[i - 1]) {
			//		int temp = myArray[i];
			//		myArray[i - 1] = myArray[i];
			//		myArray[i] = temp;
			//	}
			//}

			//Console.WriteLine(IsSorted(myArray));

			//int temp = myArray[3];
			//myArray[3] = myArray[1];
			//myArray[1] = temp;



			//Console.WriteLine(IsSorted(myArray));
		}
	}
}
