namespace Codeparts.Frameplate.Domain.Sorting
{
    public class SortState
    {
        public SortState(SortOrder order, string property)
        {
            Order = order;
            Property = property;
        }

        public SortOrder Order { get; private set; }

        public string Property { get; private set; }
    }
}