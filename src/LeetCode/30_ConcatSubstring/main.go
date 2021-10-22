package main

import "fmt"

func findSubstring(s string, words []string) []int {
	out := []int{}
	totalWords := len(words)
	if totalWords == 0 {
		return out
	}

	eachWordLength := len(words[0])
	stringLength := len(s)

	wordsCountMap := map[string]int{}

	for _, word := range words {
		wordsCountMap[word]++
	}

	for i := 0; i < eachWordLength; i++ {
		start := i

		for start+(eachWordLength*totalWords) <= stringLength {

			sub := s[start : start+(eachWordLength*totalWords)]
			visited := map[string]int{}
			j := totalWords
			for j > 0 {
				subString := sub[eachWordLength*(j-1) : eachWordLength*j]

				visited[subString]++

				if visited[subString] > wordsCountMap[subString] {
					break
				}

				j--
			}

			if j == 0 {
				out = append(out, start)
			}

			max := 1
			if j > max {
				max = j
			}

			start += eachWordLength * max
		}
	}

	return out
}

func main() {
	result := findSubstring("barfoothefoobarman", []string{"foo", "bar"})
	fmt.Println(result)
}
