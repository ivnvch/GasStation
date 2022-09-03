using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Station.BusinessLogic.Interfaces;
using Station.Common.Mapper;
using Station.Models;
using Station.Parser;

namespace Station.BusinessLogic.Implementations
{
    public class RefuellingService : IRefuellingService
    {
        IMapper _mapper;
        DataContext _context;

        public RefuellingService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public RefuellingDTO Get(int name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RefuellingDTO> Gets()
        {
            return _mapper.Map<List<RefuellingDTO>>(_context.Refuellings.AsNoTracking().ToList());
        }

        public void Parser()
        {
            AutoParser parsers = new AutoParser();
            var DTOlList = parsers.Print();
            if (DTOlList == null) throw new Exception();

            var totalList = _mapper.Map<List<RefuellingDTO>, List<Refuelling>>(DTOlList);
            _context.AddRange(totalList);
            _context.SaveChanges();
        }
    }
}
