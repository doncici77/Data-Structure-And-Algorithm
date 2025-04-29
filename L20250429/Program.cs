namespace L20250429
{
    class Node
    {
        private int data; // 데이터
        private Node? left; // 왼쪽 자식 노드
        private Node? right; // 오른쪽 자식 노드
        private Node? parent; // 부모 노드
        private BSTree? tree; // 트리

        public Node(int _data, Node _parent, BSTree _tree)
        {
            data = _data;
            parent = _parent;
            tree = _tree;
        }

        // Insert : 새로운 데이터를 노드에 삽입한다. => 자시본다 작은 갑이면 외쪽에 삽입하고, 큰값이면 오른쪽에 삽입한다.
        // 입력 : 새로운 정수 데이터
        // 출력 : X
        public void Insert(int newData)
        {
            if (data >= newData)
            {
                if (left != null)
                {
                    left.Insert(newData);
                    return;
                }

                left = new Node(newData, this, tree);
            }
            else
            {
                if (right != null)
                {
                    right.Insert(newData);
                    return;
                }

                right = new Node(newData, this, tree);
            }
        }

        public void InorderSearch()
        {
            if (left != null)
            {
                left.InorderSearch();
            }

            Console.Write(data + " ");

            if (right != null)
            {
                right.InorderSearch();
            }
        }

        public void LevelOrderSearch(Queue<Node> queue)
        {
            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();
                Console.Write(currentNode.data + " ");

                if(currentNode.left != null)
                {
                    queue.Enqueue(currentNode.left);
                }

                if(currentNode.right != null)
                {
                    queue.Enqueue(currentNode.right);
                }
            }
        }

        public bool Contains(int searchData)
        {
            if(data == searchData)
            {
                return true;
            }

            if (data > searchData)
            {
                if (left != null)
                {
                    if (left.Contains(searchData) == true)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (right != null)
                {
                    if (right.Contains(searchData) == true)
                    {
                        return true;
                    }
                }
            }
            

            return false;
        }
    }

    class BSTree
    {
        // 루트 노드
        static Node root;

        // Insert : 새로운 데이터를 트리에 추가한다.
        // 입력 : 새로운 정수 데이터
        // 출력 : X
        public void Insert(int newData)
        {
            if (root == null)
            {
                root = new Node(newData, null, this);
            }
            else
            {
                root.Insert(newData);
            }
        }

        // InorderSearch : 트리를 중위 순회한다. (내부에서 바로 출력한다.)
        // 입력 : X
        // 출력 : X
        public void InorderSearch()
        {
            if(root == null)
            {
                return;
            }

            root.InorderSearch();
            Console.WriteLine();
        }

        // LevelOrderSearch
        Queue<Node> queue = new Queue<Node>();
        public void LevelOrderSearch()
        {
            if (root == null)
            {
                return;
            }

            queue.Enqueue(root);
            root.LevelOrderSearch(queue);
            Console.WriteLine();
        }

        // Contains() : 주어진 데이터가 트리에 존재하는지 검사한다.
        // 입력 : 검사할 데이터(int)
        // 출력 : 존재 여부(bool)
        public bool Contains(int searchData)
        {
            if(root == null)
            {
                return false;
            }

            return root.Contains(searchData);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BSTree tree1 = new BSTree();
            tree1.Insert(8);
            tree1.Insert(3);
            tree1.Insert(10);
            tree1.Insert(1);
            tree1.Insert(6);
            tree1.Insert(14);
            tree1.Insert(4);
            tree1.Insert(7);
            tree1.Insert(13);

            BSTree tree2 = new BSTree();

            tree1.InorderSearch();
            tree1.LevelOrderSearch();

            Console.WriteLine(tree1.Contains(13));
        }
    }
}
