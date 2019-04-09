using System.Collections.Generic;
using System.Linq;

namespace Lab2_Structural.People.Filters
{
    public class GenderFilter : IPersonFilter
    {
        private readonly Gender genderToFilter;

        public GenderFilter(Gender genderToFilter)
        {
            this.genderToFilter = genderToFilter;
        }

        public IEnumerable<IPerson> Filter(IEnumerable<IPerson> people)
        {
            return people.Where(x => x.Gender == genderToFilter);
        }
    }
}
