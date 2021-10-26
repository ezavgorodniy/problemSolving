package main

import (
	"fmt"
)

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}

func jump(nums []int) int {
	// dp is N^2, greedy N
	if len(nums) <= 1 {
		return 0
	}

	var (
		steps          int
		farthest       int
		currentJumpEnd int
	)

	for i := 0; i < len(nums)-1; i++ {
		farthest = max(farthest, i+nums[i])

		if i == currentJumpEnd {
			steps++
			currentJumpEnd = farthest

			if farthest >= len(nums) {
				break
			}
		}
	}

	return steps
}

func main() {
	nums := []int{1, 2, 3}
	fmt.Println(jump(nums))
}
