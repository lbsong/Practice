        //正数
        static void RadixSort(int[] array)
        {
            LinkedNode[] nodes = new LinkedNode[10];

            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            int r = max;
            int len = 1;

            while (r / 10 > 0)
            {
                len += 1;
                r /= 10;
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    int v = GetValue(array[j], i);
                    if (nodes[v] == null)
                    {
                        nodes[v] = new LinkedNode();
                        nodes[v].Value = array[j];
                    }
                    else
                    {
                        var p = nodes[v];

                        while (p.Next != null)
                        {
                            p = p.Next;
                        }

                        p.Next = new LinkedNode();
                        p.Next.Value = array[j];
                    }
                }

                int index = 0;

                for (int k = 0; k < nodes.Length; k++)
                {
                    var node = nodes[k];

                    while (node != null)
                    {
                        array[index++] = node.Value;
                        node = node.Next;
                    }

                    nodes[k] = null;
                }
            }
        }

        static int GetValue(int value, int index)
        {
            int result = value;

            for (int i = 0; i < index; i++)
            {
                result /= 10;
            }

            return result % 10;
        }
