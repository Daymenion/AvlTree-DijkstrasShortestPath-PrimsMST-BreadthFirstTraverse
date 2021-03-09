using System;

namespace projeMain
{
    class AvlTree
    {
        class Node
        {
            public int data,height;
            public Node SolNode;
            public Node SagNode;
            public Node(int data)
            {
                this.data = data;
                height = 1;
            }
        }
        Node root;
        public AvlTree()
        {
        }
        public void Add(int data)
        {
            Node yenitem = new Node(data);
            if (root == null)
            {
                root = yenitem;
            }
            else
            {
                root = RecursiveInsert(root, yenitem);
            }
        }
        private Node RecursiveInsert(Node current, Node n) //büyüklük küçüklük ilişkisine göre sağ veya sol node olarak fonksıyonun yenıden gönderimleri
        {                                                  //ve balance tree fonk gonderım yapılıyor, boylece nodelar arası denge saglanıyor
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.data < current.data)   //ata nodun verisinden küçükse verimiz sol nodlara 
            {
                current.SolNode = RecursiveInsert(current.SolNode, n);
                current = balance_tree(current);
            }
            else if (n.data > current.data)   //ata nodun verisinden büyükse verimiz sag nodlara
            {
                current.SagNode = RecursiveInsert(current.SagNode, n);
                current = balance_tree(current);
            }
            current.height = 1 + maximum(GetHeight(current.SolNode), GetHeight(current.SagNode)); //ilk yüksekliğin verilmesi

            return current;
        }
        private Node balance_tree(Node current) //agacin dengesine gore eklememiz gereken nodenin eklenmesi
        {
            int bFactor = balance_factor(current);
            if (bFactor > 1)     //Sol node derinliği daha büyükse
            {
                if (balance_factor(current.SolNode) > 0)
                {
                    current = RotateSolSol(current);
                }
                else
                {
                    current = RotateSolSag(current);
                }
            }
            else if (bFactor < -1) //Sağ node derinliği daha büyükse
            {
                if (balance_factor(current.SagNode) > 0)
                {
                    current = RotateSagSol(current);
                }
                else
                {
                    current = RotateSagSag(current);
                }
            }
            return current;  //node derinlikleri eşitse
        }
        private int balance_factor(Node current)
        {
            if (current == null)
                return 0;
            return GetHeight(current.SolNode) - GetHeight(current.SagNode);
        }
        private int maximum(int l, int r) //Basit maximum döndüren fonksiyonu
        {
            return l > r ? l : r;
        }
        private int GetHeight(Node N) //yukseklik alma foksiyonumuz
        {
            if (N == null)
                return 0;
            return N.height;
        }
        //Sağ ve sol nodeların değiştirilmesi böylece agacın dengelenmesi için fonksiyonlar
        private Node RotateSolSol(Node parent)
        {
            Node pivot = parent.SolNode;
            parent.SolNode = pivot.SagNode;
            pivot.SagNode = parent;
            parent.height = maximum(GetHeight(parent.SolNode), GetHeight(parent.SagNode)) + 1;
            pivot.height = maximum(GetHeight(pivot.SolNode), GetHeight(pivot.SagNode)) + 1;

            return pivot;
        }
        private Node RotateSagSag(Node parent)
        {
            Node pivot = parent.SagNode;
            parent.SagNode = pivot.SolNode;
            pivot.SolNode = parent;
            parent.height = maximum(GetHeight(parent.SolNode), GetHeight(parent.SagNode)) + 1;
            pivot.height = maximum(GetHeight(pivot.SolNode), GetHeight(pivot.SagNode)) + 1;

            return pivot;
        }
        private Node RotateSolSag(Node parent)
        {
            Node pivot = parent.SolNode;
            parent.SolNode = RotateSagSag(pivot);
            return RotateSolSol(parent);
        }
        private Node RotateSagSol(Node parent)
        {
            Node pivot = parent.SagNode;
            parent.SagNode = RotateSolSol(pivot);
            return RotateSagSag(parent);
        }
        public void DisplayTree() //Klasik ağacı sergileme fonksiyonu
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            Console.WriteLine("Avl Tree Inorder Traversal Output of constructed tree is :");
            InOrder(root);
            Console.WriteLine("\nAvl Tree Preorder traversal Output of constructed tree is :");
            PreOrder(root);
            Console.WriteLine();
        }
        private void PreOrder(Node current) //preorder duzeni
        {
            if (current != null)
            {
                Console.Write("\n\t({0})    \theight: {1} ", current.data, current.height);
                PreOrder(current.SolNode);
                PreOrder(current.SagNode);
            }
        }

        private void InOrder(Node current) //İnorder düzeni
        {
            if (current != null)
            {
                InOrder(current.SolNode);
                Console.Write("\n\t({0})    \theight: {1} ", current.data, current.height);
                InOrder(current.SagNode);
            }
        }

    }
}
