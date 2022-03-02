using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidParentheses
{
    /// <summary>
    /// 20-Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.<br></br>
    /// String is valid if <br></br>
    /// 1-Open brackets must be closed by the same type of brackets<br></br>
    /// 2-Open brackets must be closed in the correct order<br></br>
    /// Constraints<br></br>
    /// 1 &lt;= s.length &lt;= 10^4<br></br>
    /// s consists of parentheses only '() [] {}'
    /// </summary>
    class Solution
    {
        public Solution()
        {
            TestCases();
        }

        public void TestCases()
        {
            string s1 = "(){()[]}";
            Console.WriteLine(IsValid(s1));
            string s2 = "(){()][}";
            Console.WriteLine(IsValid(s2));
            string s3 = "}";
            Console.WriteLine(IsValid(s3));

        }


        //Use a Stack.
        //Time O(n) where n=s.Length (amortized)
        //Space O(n) where n=s.Length
        public bool IsValid(string s) //O(n) where n=s.Length
        {
            Stack<char> stack = new Stack<char>();
            stack.Push(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                if (stack.Count > 0)
                {
                    if (stack.Peek() == '(' && s[i] == ')')
                    {
                        stack.Pop();
                    }
                    else if (stack.Peek() == '[' && s[i] == ']')
                    {
                        stack.Pop();
                    }
                    else if (stack.Peek() == '{' && s[i] == '}')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(s[i]);
                    }
                }
                else
                {
                    stack.Push(s[i]);
                }


            }

            return stack.Count == 0 ? true : false;

        }

       
    }
}
