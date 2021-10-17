package main

import (
	"fmt"
)

func twoSum(nums []int, target int) []int {
	numsPositions := map[int]int{}
	for i, el := range nums {
		searchEl := target - el
		if searchIndex, ok := numsPositions[searchEl]; ok && searchIndex != i {
			return []int{searchIndex, i}
		}
		numsPositions[el] = i
	}

	return nil
}

func main() {
	fmt.Println(twoSum([]int{2, 7, 11, 15}, 9))
}
