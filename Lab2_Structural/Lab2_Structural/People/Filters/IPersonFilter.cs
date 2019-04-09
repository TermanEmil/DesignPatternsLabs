using System.Collections.Generic;

namespace Lab2_Structural.People.Filters
{
    public interface IPersonFilter
    {
        IEnumerable<IPerson> Filter(IEnumerable<IPerson> people);
    }
}
