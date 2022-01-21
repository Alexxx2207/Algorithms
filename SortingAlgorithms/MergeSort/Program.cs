

static void Merge(int[] arr, int leftIndex, int middleIndex, int rightIndex)
{
    int leftSize = middleIndex - leftIndex + 1;
    int rightSize = rightIndex - middleIndex;

    int[] leftArr = new int[leftSize];
    int[] rightArr = new int[rightSize];

    for (int i = 0; i < leftSize; i++)
        leftArr[i] = arr[leftIndex + i];

    for (int i = 0; i < rightSize; i++)
        rightArr[i] = arr[middleIndex + i + 1];


    int currentLeftIndex = 0, currentRightIndex = 0;

    int currentPlaceInMainArray = leftIndex;

    while (currentLeftIndex < leftSize && currentRightIndex < rightSize)
    {
        if (leftArr[currentLeftIndex] < rightArr[currentRightIndex])
        {
            arr[currentPlaceInMainArray++] = leftArr[currentLeftIndex++];
        }
        else
        {
            arr[currentPlaceInMainArray++] = rightArr[currentRightIndex++];
        }
    }

    while (currentLeftIndex < leftSize)
    {
        arr[currentPlaceInMainArray++] = leftArr[currentLeftIndex++];
    }

    while (currentRightIndex < rightSize)
    {
        arr[currentPlaceInMainArray++] = rightArr[currentRightIndex++];
    }
}

static void MergeSort(int[] arr, int leftIndex, int rightIndex)
{
    if (leftIndex < rightIndex)
    {
        int middle = leftIndex + (rightIndex - leftIndex) / 2;

        MergeSort(arr, leftIndex, middle);
        MergeSort(arr, middle + 1, rightIndex);

        Merge(arr, leftIndex, middle, rightIndex);
    }
}




int[] nums2 = { 2, 3, 2, 1, 3, 4, 634, 65434, 324, 32423, 4, 32, 4324, 876, 1, 3, 313, 12, 3, 12, 31 };

MergeSort(nums2, 0, nums2.Length - 1);

Console.WriteLine(string.Join(' ', nums2));