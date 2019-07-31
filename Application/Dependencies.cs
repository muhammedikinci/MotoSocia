using AutoMapper;

namespace Application
{
    public class Dependencies
    {
        public IMotoDBContext Context { get; set; }
        public IMapper Mapper { get; set; }
    }
}
