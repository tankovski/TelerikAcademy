using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeRepresentedLikeSetOfNodes
{
    class ThreeRepresentedLikeSetOfNodes
    {
        public static int FindRoot(List<int> parentNodes, List<int> childNodes)
        {
            int root = 0;
            for (int i = 0; i < parentNodes.Count; i++)
            {
                if (!childNodes.Contains(parentNodes[i]))
                {
                    root = parentNodes[i];
                    break;
                }
            }

            return root;
        }

        public static List<int> FindLeafNodes(List<int> parentNodes, List<int> childNodes)
        {
            List<int> leafNodes = new List<int>();
            for (int i = 0; i < childNodes.Count; i++)
            {
                if (!parentNodes.Contains(childNodes[i]))
                {
                    leafNodes.Add(childNodes[i]);
                }
            }

            return leafNodes;
        }

        public static List<int> FindMiddleNodes(List<int> parentNodes, List<int> childNodes)
        {
            int root = FindRoot(parentNodes, childNodes);
            List<int> leafNodes = FindLeafNodes(parentNodes, childNodes);
            List<int> middleNodes = new List<int>();
            for (int i = 0; i < parentNodes.Count; i++)
            {
                if (!leafNodes.Contains(parentNodes[i]) && parentNodes[i] != root)
                {
                    if (!middleNodes.Contains(parentNodes[i]))
                    {
                        middleNodes.Add(parentNodes[i]);                        
                    }
                }
            }

            return middleNodes;
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            List<int> parentNodes = new List<int>();
            List<int> childNodes = new List<int>();

            var nodes = new Node<int>[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++)
            {
                nodes[i] = new Node<int>(i);
            }
            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                string nodePair = Console.ReadLine();
                string[] pairs = nodePair.Split(' ');
                parentNodes.Add(int.Parse(pairs[0]));
                childNodes.Add(int.Parse(pairs[1]));

                nodes[parentNodes[i]].Children.Add(nodes[childNodes[i]]);
                nodes[childNodes[i]].HasParent = true;
            }

            int root = FindRoot(parentNodes, childNodes);
            Console.WriteLine("The root is: " + root);

            List<int> leafNodes = FindLeafNodes(parentNodes, childNodes);
            Console.WriteLine("Leaf nodes are: ");
            for (int i = 0; i < leafNodes.Count; i++)
            {
                Console.Write(leafNodes[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Middle nodes are: ");
            List<int> middleNodes = FindMiddleNodes(parentNodes, childNodes);
            foreach (var item in middleNodes)
            {
                Console.WriteLine(item + " ");
            }

            int longestPath = FindLongestPath(nodes[root]);
            Console.WriteLine("Longest path is: "+ longestPath);
        }
    }
}
