namespace NumOrdering.Contract
{
    public interface IOrderingEngine
    {
        public IList<int> SortMerge(IList<int> numbers);
        public IList<int> SortBubble(IList<int> num, int count);
        public IList<int> SortInsertion(IList<int> num, int count);
    }
}
