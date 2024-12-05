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
						int temp = inputArray[i - 1];
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

		static int MaxValue(int[] inputArray) {
			int max = int.MinValue;
			for (int i = 0; i < inputArray.Length; i++) {
				if (inputArray[i] > max) {
					max = inputArray[i];
				}
			}
			return max;
		}

		static int[] CountingSort(int[] inputArray) {
			int max = MaxValue(inputArray);

			int[] countingArray = new int[max + 1];

			for (int i = 0; i < inputArray.Length; i++) {
				int number = inputArray[i];
				countingArray[number]++;
			}

			for (int i = 1; i < countingArray.Length; i++) {
				countingArray[i] += countingArray[i - 1];
			}

			for (int i = countingArray.Length - 1; i > 0; i--) {
				countingArray[i] = countingArray[i - 1];
			}
			countingArray[0] = 0;

			int[] output = new int[inputArray.Length];
			for (int i = 0; i < inputArray.Length; i++) {
				int number = inputArray[i];
				int index = countingArray[number];
				output[index] = inputArray[i];
				countingArray[number]++;
			}

			return output;
		}

		static void QuickSort(int[] inputArray, int startIndex, int endIndex) {
			int left = startIndex;
			int right = endIndex;

			int partition = inputArray[(startIndex + endIndex) / 2];

			while (left <= right) {

				while (inputArray[left] < partition) {
					left++;
				}

				while (inputArray[right] > partition) {
					right--;
				}

				if (left <= right) {
					int temp = inputArray[left];
					inputArray[left] = inputArray[right];
					inputArray[right] = temp;

					left++;
					right--;
				}

			}

			if (startIndex < right) {
				QuickSort(inputArray, startIndex, right);
			}

			if (left < endIndex) {
				QuickSort(inputArray, left, endIndex);
			}
		}

		static void Main(string[] args) {
			//int[] myArray = new int[] { 2, 1, 2, 0, 3, 2, 0 };
			int[] aLotOfInts = new int[] { 328, 530, 501, 736, 231, 684, 34, 827, 217, 393, 467, 455, 355, 427, 978, 728, 42, 325, 906, 914, 553, 571, 215, 531, 915, 665, 397, 84, 836, 600, 345, 455, 152, 506, 581, 6, 289, 607, 441, 372, 377, 878, 324, 876, 345, 669, 22, 606, 203, 313, 478, 991, 522, 148, 86, 1, 633, 892, 294, 451, 411, 924, 261, 277, 475, 17, 340, 578, 89, 846, 913, 395, 929, 844, 978, 536, 227, 572, 453, 499, 510, 953, 176, 206, 356, 833, 79, 834, 779, 880, 800, 495, 901, 812, 770, 807, 902, 700, 283, 620, 673, 87, 567, 503, 755, 105, 678, 407, 237, 664, 141, 23, 878, 352, 416, 135, 560, 284, 71, 258, 166, 886, 911, 39, 721, 975, 737, 384, 992, 691, 107, 163, 782, 454, 769, 671, 532, 33, 546, 537, 613, 219, 177, 899, 953, 468, 636, 355, 337, 914, 144, 427, 148, 249, 39, 263, 229, 922, 72, 412, 889, 137, 420, 453, 400, 622, 778, 955, 188, 59, 290, 524, 132, 767, 567, 403, 172, 872, 135, 858, 874, 302, 993, 442, 355, 879, 636, 41, 223, 777, 944, 832, 324, 250, 148, 100, 491, 5, 217, 46, 584, 874, 34, 879, 905, 477, 717, 722, 107, 442, 634, 446, 190, 601, 272, 291, 553, 283, 267, 692, 669, 104, 12, 838, 753, 180, 696, 777, 706, 437, 297, 575, 936, 983, 275, 678, 60, 703, 391, 821, 956, 753, 798, 47, 486, 882, 553, 896, 775, 208, 648, 485, 593, 470, 248, 670, 410, 707, 938, 289, 287, 778, 123, 846, 583, 110, 134, 919, 526, 339, 944, 626, 507, 357, 636, 493, 538, 206, 207, 913, 413, 259, 759, 916, 606, 431, 634, 454, 471, 903, 29, 485, 4, 577, 794, 641, 309, 669, 405, 69, 260, 12, 540, 988, 525, 601, 261, 463, 593, 566, 223, 89, 100, 174, 814, 332, 133, 745, 92, 642, 334, 310, 26, 394, 395, 622, 165, 728, 789, 158, 587, 554, 305, 778, 765, 346, 675, 826, 841, 595, 42, 7, 568, 388, 889, 153, 585, 766, 958, 85, 100, 392, 890, 67, 64, 413, 2, 819, 226, 554, 71, 217, 687, 846, 118, 130, 19, 688, 150, 830, 735, 150, 339, 169, 960, 688, 36, 39, 0, 339, 272, 148, 590, 932, 248, 762, 531, 171, 190, 973, 559, 283, 962, 257, 899, 105, 242, 442, 485, 935, 750, 965, 476, 397, 793, 88, 123, 63, 132, 819, 44, 821, 128, 569, 452, 145, 406, 462, 220, 416, 915, 370, 661, 364, 711, 318, 646, 625, 82, 491, 82, 409, 292, 772, 194, 192, 218, 757, 885, 437, 875, 716, 543, 560, 93, 360, 733, 4, 727, 964, 402, 298, 111, 793, 594, 395, 216, 288, 493, 416, 215, 885, 304, 332, 361, 519, 828, 734, 928, 884, 293, 888, 808, 826, 462, 260, 565, 119, 652, 27, 899, 284, 653, 745, 774, 703, 243, 215, 15, 425, 910, 904, 152, 781, 518, 24, 244, 94, 19, 272, 540, 771, 886, 59, 808, 267, 274, 783, 986, 304, 400, 549, 796, 756, 223, 197, 694, 170, 229, 17, 976, 619, 690, 303, 784, 115, 819, 304, 496, 974, 892, 683, 251, 753, 847, 285, 505, 977, 251, 692, 237, 346, 440, 487, 163, 322, 571, 943, 561, 827, 695, 98, 470, 811, 653, 567, 463, 605, 242, 578, 789, 259, 703, 636, 566, 856, 570, 625, 784, 560, 228, 877, 9, 347, 106, 768, 328, 777, 602, 558, 182, 784, 831, 631, 610, 415, 641, 428, 202, 433, 980, 699, 559, 240, 35, 97, 898, 112, 252, 907, 360, 298, 144, 889, 141, 467, 103, 877, 650, 217, 652, 643, 958, 940, 175, 613, 503, 58, 654, 965, 806, 30, 284, 787, 553, 280, 916, 104, 165, 708, 669, 737, 325, 901, 871, 568, 677, 757, 340, 847, 24, 856, 235, 678, 507, 625, 385, 376, 978, 88, 384, 778, 512, 956, 838, 824, 477, 8, 687, 650, 674, 142, 755, 28, 540, 126, 540, 570, 246, 149, 381, 513, 297, 861, 959, 805, 10, 939, 605, 7, 788, 33, 904, 596, 815, 429, 823, 773, 785, 894, 804, 128, 680, 179, 540, 315, 602, 918, 669, 854, 492, 302, 595, 844, 143, 256, 180, 113, 427, 209, 742, 949, 745, 802, 794, 196, 431, 999, 960, 539, 592, 927, 678, 452, 978, 551, 314, 765, 976, 990, 290, 934, 726, 164, 177, 460, 819, 889, 169, 661, 754, 77, 2, 568, 95, 336, 919, 856, 624, 743, 484, 865, 332, 616, 711, 625, 624, 779, 622, 750, 681, 356, 946, 929, 46, 535, 217, 499, 761, 478, 532, 107, 72, 15, 324, 259, 67, 729, 8, 750, 463, 873, 618, 945, 657, 810, 532, 588, 800, 350, 580, 172, 421, 107, 598, 429, 443, 715, 435, 361, 454, 787, 151, 622, 680, 80, 346, 784, 312, 866, 728, 662, 897, 264, 288, 478, 259, 297, 17, 121, 691, 680, 727, 198, 129, 320, 564, 313, 336, 785, 301, 250, 325, 277, 362, 0, 752, 722, 465, 313, 388, 485, 183, 88, 454, 18, 312, 479, 710, 688, 60, 336, 285, 731, 36, 367, 505, 506, 263, 425, 588, 644, 687, 535, 291, 698, 516, 44, 336, 473, 55, 891, 234, 603, 426, 44, 818, 810, 664, 770, 814, 510, 72, 459, 834, 197, 129, 283, 792, 594, 581, 289, 908, 718, 974, 890, 35, 808, 112, 356, 843, 403, 859, 475, 649, 501, 602, 10, 247, 942, 267, 717, 459, 972, 22, 177, 901, 68, 121, 884, 437, 232, 975, 171, 790, 801, 98, 683, 841, 735, 618, 229, 164, 777, 167, 930, 159, 633, 442, 32, 26, 566, 684, 117, 877, 335, 693, 119, 118, 965, 729, 89, 505, 223, 903, 287, 328, 292, 474, 220, 902, 534, 573, 852, 473, 955, 53, 557, 994, 167, 224, 461, 472, 426, 552, 475, 239, 742, 352, 887, 197, 651, 731, 135, 464, 826, 107, 317, 86, 925, 139, 394, 436, 969, 810, 953, 378, 932, 34, 823 };

			//for (int i = 0; i < myArray.Length; i++) {
			//	Console.WriteLine(myArray[i]);
			//}
			//Console.WriteLine(IsSorted(myArray));

			//Console.WriteLine("====");

			QuickSort(aLotOfInts, 0, aLotOfInts.Length - 1);

			for (int i = 0; i < aLotOfInts.Length; i++) {
				Console.WriteLine(aLotOfInts[i]);
			}
			Console.WriteLine(IsSorted(aLotOfInts));

			//for (int j = myArray.Length; j > 0; j--) {
			//	for (int i = 1; i < j; i++) {
			//		if (myArray[i] < myArray[i - 1]) {
			//			int temp = myArray[i - 1];
			//			myArray[i - 1] = myArray[i];
			//			myArray[i] = temp;
			//		}
			//	}
			//}

			//for (int i = 1; i < myArray.Length - 0; i++) {
			//	if (myArray[i] < myArray[i - 1]) {
			//		int temp = myArray[i - 1];
			//		myArray[i - 1] = myArray[i];
			//		myArray[i] = temp;
			//	}
			//}

			//for (int i = 1; i < myArray.Length - 1; i++) {
			//	if (myArray[i] < myArray[i - 1]) {
			//		int temp = myArray[i - 1];
			//		myArray[i - 1] = myArray[i];
			//		myArray[i] = temp;
			//	}
			//}

			//for (int i = 1; i < myArray.Length - 2; i++) {
			//	if (myArray[i] < myArray[i - 1]) {
			//		int temp = myArray[i - 1];
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
