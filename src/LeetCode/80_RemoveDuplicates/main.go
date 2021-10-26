package main

/*
Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice. The relative order of the elements should be kept the same.

Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.

Return k after placing the final result in the first k slots of nums.

Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.

Custom Judge:

The judge will test your solution with the following code:

int[] nums = [...]; // Input array
int[] expectedNums = [...]; // The expected answer with correct length

int k = removeDuplicates(nums); // Calls your implementation

assert k == expectedNums.length;
for (int i = 0; i < k; i++) {
    assert nums[i] == expectedNums[i];
}
If all assertions pass, then your solution will be accepted.

*/

import (
	"fmt"
)

func removeDuplicates(nums []int) int {
	curIndex := 0
	skippedCnt := 0
	for curIndex < len(nums) {
		if curIndex == len(nums)-1 {
			nums[curIndex-skippedCnt] = nums[curIndex]
			curIndex++
			break
		}

		nums[curIndex-skippedCnt] = nums[curIndex]
		if nums[curIndex] == nums[curIndex+1] {
			nums[curIndex-skippedCnt+1] = nums[curIndex]
			curIndex += 2
			for curIndex < len(nums) && nums[curIndex-1] == nums[curIndex] {
				curIndex++
				skippedCnt++
			}
		} else {
			curIndex++
		}
	}
	return len(nums) - skippedCnt
}

func main() {
	nums := []int{0, 0, 1, 1, 1, 2, 3, 3}
	fmt.Println(removeDuplicates(nums))
	fmt.Println(nums)
}
