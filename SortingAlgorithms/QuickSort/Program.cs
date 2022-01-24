//QUICKSORT

static int partition(int[] arr, int leftIndex, int rightIndex)
{
    int pivot = arr[rightIndex];

    int smallerNumsCount = leftIndex - 1;

    for (int currentNumIndex = leftIndex; currentNumIndex < rightIndex; currentNumIndex++)
    {
        if (arr[currentNumIndex] < pivot)
        {
            smallerNumsCount++;

            int innerTemp = arr[currentNumIndex];
            arr[currentNumIndex] = arr[smallerNumsCount];
            arr[smallerNumsCount] = innerTemp;
        }
    }

    int temp = arr[smallerNumsCount + 1];
    arr[smallerNumsCount + 1] = pivot;
    arr[rightIndex] = temp;

    return smallerNumsCount + 1;
}

static void QuickSort(int[] arr, int leftIndex, int rightIndex)
{
    if (leftIndex < rightIndex)
    {
        int middle = partition(arr, leftIndex, rightIndex);

        QuickSort(arr, leftIndex, middle - 1);
        QuickSort(arr, middle + 1, rightIndex);
    }
}


//Example Array
int[] nums = { 2, 3, 2, 1, 3, 4, 634, 65434, 324, 32423, 4, 32, 4324, 876, 1, 3, 313, 12, 3, 12, 31 };

//Insert:
//1.The array you want to sort
//2.From which index you want to sort (from left to right perspective) *inclusive*
//3.To which index you want to sort (from left to right perspective) *inclusive*
QuickSort(nums, 0, nums.Length - 1);

Console.WriteLine(string.Join(' ', nums));