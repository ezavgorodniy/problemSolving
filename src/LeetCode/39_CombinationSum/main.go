package main

import "fmt"

func combinationSum(candidates []int, target int) [][]int {
	res := [][]int{}

	backTrack(candidates, 0, target, make([]int, 0), &res)

	return res
}

func backTrack(candidates []int, start int, target int, curList []int, results *[][]int) {
	if target < 0 {
		return
	}

	if target == 0 {
		combination := make([]int, len(curList))
		copy(combination, curList)
		*results = append(*results, combination)
		return
	}

	for i := start; i < len(candidates); i++ {
		curList = append(curList, candidates[i])
		backTrack(candidates, i, target-candidates[i], curList, results)
		curList = curList[:len(curList)-1]
	}
}

func main() {
	result := combinationSum([]int{2, 3, 6, 7}, 7)
	fmt.Println(result)
}
