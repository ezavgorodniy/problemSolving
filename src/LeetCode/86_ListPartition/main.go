package main

import (
   "fmt"
)
 type ListNode struct {
     Val int
     Next *ListNode
 }

func partition(head *ListNode, x int) *ListNode {
   var leftSideHead, leftSideTail, rightSideHead, rightSideTail *ListNode
   for curNode := head; curNode != nil; curNode = curNode.Next {
      if curNode.Val < x {
         if leftSideHead == nil {
            leftSideHead = curNode
         } else {
            leftSideTail.Next = curNode
         }
         leftSideTail = curNode
      } else {
         if rightSideHead == nil {
            rightSideHead = curNode
         } else {
            rightSideTail.Next = curNode
         }
         rightSideTail = curNode
      }
   }

   if leftSideHead == nil {
      rightSideTail.Next = nil
      return rightSideHead
   }

   leftSideTail.Next = rightSideHead

   if rightSideTail != nil {
      rightSideTail.Next = nil
   }

   return leftSideHead
}

func main() {
   head := ListNode {
      Val: 1,
      Next: &(ListNode {
         Val: 4,
         Next: &(ListNode {
            Val: 3,
            Next: &(ListNode {
               Val: 2,
               Next: &(ListNode {
                  Val: 5,
                  Next: &(ListNode {
                     Val: 2,
                  }),
               }),
            }),
         }),
      }),
   }

   fmt.Println(partition(&head, 3))
}