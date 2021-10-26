package main

import (
	"fmt"
	"sort"
)

type FrequencyDescription struct {
	appearance int
	char       byte
}

const charactersAmount = 26

func frequencySort(s string) string {
	frequency := make(map[byte]int)
	for _, el := range s {
		frequency[byte(el)]++
	}

	frequencyDescription := make([]FrequencyDescription, 0, charactersAmount)
	for k, v := range frequency {
		descr := FrequencyDescription{v, byte(k)}
		frequencyDescription = append(frequencyDescription, descr)
	}

	sort.Slice(frequencyDescription, func(i, j int) bool {
		return frequencyDescription[i].appearance > frequencyDescription[j].appearance
	})

	result := make([]byte, len(s))
	curI := 0
	for _, el := range frequencyDescription {
		for el.appearance > 0 {
			el.appearance--
			result[curI] = el.char
			curI++
		}
	}

	return string(result)
}

func main() {
	fmt.Println(frequencySort("tRee"))
}
