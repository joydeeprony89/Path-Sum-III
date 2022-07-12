using System;
using System.Collections.Generic;

namespace Path_Sum_III
{
  class Program
  {
    static void Main(string[] args)
    {
      //TreeNode root = new TreeNode(10);
      //root.left = new TreeNode(5);
      //root.left.right = new TreeNode(2);
      //root.left.right.right = new TreeNode(1);
      //root.left.left = new TreeNode(3);
      //root.left.left.right = new TreeNode(-2);
      //root.left.left.left = new TreeNode(3);
      //root.right = new TreeNode(-3);
      //root.right.right = new TreeNode(11);
      TreeNode root = new TreeNode(1);
      root.left = new TreeNode(-2);
      root.right = new TreeNode(-3);
      Solution s = new Solution();
      var answer = s.PathSum(root, -1);
      Console.WriteLine(answer);
    }
  }

  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
      this.val = val;
      this.left = left;
      this.right = right;
    }
  }

  public class Solution
  {
    // dictionary is used to store all the prefix sum to a node from the root
    Dictionary<int, int> freq = new Dictionary<int, int>();
    public int PathSum(TreeNode root, int targetSum)
    {
      // if we found a prefix sum as 8, so 8 - 8(targetSum) = 0, we should get 1 path that has 8 as the target Sum
      freq.Add(0, 1);
      return Helper(root, targetSum, 0);
    }

    private int Helper(TreeNode root, int targetSum, int currentSum)
    {
      // base case
      if (root == null) return 0;

      // currentSum will always have the prefix sum
      currentSum += root.val;
      // if the currentSum - target the result element is present in the freq which meanswe have a path found
      int key = currentSum - targetSum;
      int count = freq.ContainsKey(key) ? freq[key] : 0;
      // add the current prefix sum in the freq
      if (!freq.ContainsKey(currentSum))
        freq.Add(currentSum, 0);
      freq[currentSum] += 1;

      int result = count + Helper(root.left, targetSum, currentSum) + Helper(root.right, targetSum, currentSum);
      // decrement the current sum afer use
      freq[currentSum] -= 1;
      return result;
    }
  }
}
