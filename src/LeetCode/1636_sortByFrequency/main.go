package main

import (
	"fmt"
	"sort"
)

func frequencySort(a []int) []int {
	m := make(map[int]int)
	for _, i := range a {
		m[i]++
	}
	sort.Slice(a, func(i, j int) bool {
		if m[a[i]] == m[a[j]] {
			return a[i] > a[j]
		} else {
			return m[a[i]] < m[a[j]]
		}
	})
	return a
}

func main() {
	fmt.Println(frequencySort([]int{-1, 1, -6, 4, 5, -6, 1, 4, 1}))
}
