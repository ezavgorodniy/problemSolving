package main

import (
	"fmt"
	"sort"
)

func allCombinations(candidates []int, start int, curList []int, target int, results *[][]int) {
	if target == 0 {
		combination := make([]int, len(curList))
		copy(combination, curList)
		*results = append(*results, combination)
		return
	}

	if target < 0 {
		return
	}

	for i := start; i < len(candidates) && candidates[i] <= target; i++ {
		if i > start && candidates[i] == candidates[i-1] {
			continue
		}

		curList = append(curList, candidates[i])
		allCombinations(candidates, i+1, curList, target-candidates[i], results)
		curList = curList[:len(curList)-1]
	}
}

func combinationSum2(candidates []int, target int) [][]int {
	result := [][]int{}
	sort.Ints(candidates)
	allCombinations(candidates, 0, []int{}, target, &result)
	return result
}

func main() {
	// nums := []int{10, 1, 2, 7, 6, 1, 5}
	// target := 8
	nums := []int{2, 5, 2, 1, 2}
	target := 5
	fmt.Println(combinationSum2(nums, target))
}
