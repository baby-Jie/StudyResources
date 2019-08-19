     List<List<int>> retList = new List<List<int>>();
        private List<int> _globalList;
        private int targetNumbetr = 0;

        public List<List<int>> GetList(List<int> a)
        {
            _globalList = a;
            List<int> temp = new List<int>();

            Test(0, temp);

            return retList;
        }

        public void Test(int index, List<int> list)
        {
            if (index >= _globalList.Count)
            {
                return;
            }

            if (list.Count >= 3)
            {
                return;
            }

            // 选择
            list.Add(_globalList[index]);

            if (list.Count == 3 && GetListSum(list) == targetNumbetr)
            {
                retList.Add(new List<int>(list));
                return;
            }
            else
            {
                Test(index + 1, list);
            }

            list.RemoveAt(list.Count-1);
            // 不选择
            Test(index+1, list);
        }

        public int GetListSum(List<int> list)
        {
            int sum = 0;
            foreach (var number in list)
            {
                sum += number;
            }

            return sum;
        }