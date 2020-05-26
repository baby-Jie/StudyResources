// 获取全部元素的全排列 使用方法：GetPermutations(_myList);
private List<List<int>> _resList = new List<List<int>>();

void Permutation(List<int> list,  List<bool> flags, List<int> temps)
{
    if (temps.Count == list.Count)
    {
        _resList.Add(new List<int>(temps));
        return;
    }

    for (int i = 0; i < list.Count; i++)
    {
        if (!flags[i])
        {
            temps.Add(list[i]);
            flags[i] = true;
            Permutation(list, flags, temps);
            temps.Remove(list[i]);
            flags[i] = false;
        }
    }
}

List<List<int>> GetPermutations(List<int> list)
{
    if (!list.Any())
    {
        return new List<List<int>>();
    }
    List<bool> flags = new List<bool>();

    for (int i = 0; i < list.Count; i++)
    {
        flags.Add(false);
    }
    List<int> temps = new List<int>();

    Permutation(list, flags, temps);

    return null;
}

// 获取全部元素 个数递增的全排列

private List<List<int>> retLists = new List<List<int>>();

        public void Permutations(List<int> list, List<int> tempList)
        {
            if (!tempList.Any())
            {
                return;
            }

            int length = list.Count;

            // 可能重复的问题
            foreach (var val in tempList)
            {
                for (int i = length; i >= 0; i--)
                {
                    var retList = new List<int>(list);
                    if (i == length)
                    {
                        retList.Add(val);
                        AddList(retList);
                    }
                    else
                    {
                        retList.Insert(i, val);
                        AddList(retList);
                    }

                    var arg = new List<int>(tempList);
                    arg.Remove(val);
                    Permutations(retList, arg);
                }
            }
        }

        public void AddList(List<int> li)
        {
            var str = string.Join("-", li);
            if (!retLists.Any(li1 => string.Join("-", li1).Equals(str)))
            {
                retLists.Add(li);
            }
        }