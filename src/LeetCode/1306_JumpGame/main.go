package main

import (
	"fmt"
)

func canVisit(newIndex int, visited []bool) bool {
	if newIndex < 0 {
		return false
	}

	if newIndex >= len(visited) {
		return false
	}

	if visited[newIndex] {
		return false
	}

	return true
}

func canReach(arr []int, start int) bool {
	visited := make([]bool, len(arr))
	curIndexes := []int{start}
	for len(curIndexes) > 0 {
		newIndexes := []int{}
		for _, el := range curIndexes {
			jumpForward := el + arr[el]
			if canVisit(jumpForward, visited) {
				if arr[jumpForward] == 0 {
					return true
				}

				visited[jumpForward] = true
				newIndexes = append(newIndexes, jumpForward)
			}

			jumpBack := el - arr[el]
			if canVisit(jumpBack, visited) {
				if arr[jumpBack] == 0 {
					return true
				}

				visited[jumpBack] = true
				newIndexes = append(newIndexes, jumpBack)
			}
		}

		curIndexes = newIndexes
	}

	return false
}

func main() {
	nums := []int{4, 2, 3, 0, 3, 1, 2}
	fmt.Println(canReach(nums, 5))
}
