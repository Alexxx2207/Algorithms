
static void CountingSort(int[] arr, int left, int right)
{
    int[] workingArr = new int[right - left + 1];

    for (int i = 0; i < workingArr.Length; i++)
    {
        workingArr[i] = arr[left + i];
    }

    int[] counts = new int[workingArr.Max() + 1];

    for (int i = 0; i < workingArr.Length; i++)
    {
        counts[workingArr[i]]++;
    }

    for (int i = 1; i < counts.Length; i++)
    {
        counts[i] += counts[i - 1];
    }

    int[] result = new int[workingArr.Length];

    for (int i = 0; i < workingArr.Length; i++)
    {
        result[counts[workingArr[i]] - 1] = workingArr[i];
        counts[workingArr[i]]--;
    }

    for (int i = 0; i < workingArr.Length; i++)
    {
        arr[left + i] = result[i];
    }
}


//Example Array
int[] nums = { 2, 3, 2, 1, 3, 4, 634, 65434, 324, 32423, 4, 32, 4324, 876, 1, 3, 313, 12, 3, 12, 31 };

//Insert:
//1.The array you want to sort
//2.From which index you want to sort (from left to right perspective) *inclusive*
//3.To which index you want to sort (from left to right perspective) *inclusive*
CountingSort(nums, 0, nums.Length - 1);

Console.WriteLine(string.Join(' ', nums));