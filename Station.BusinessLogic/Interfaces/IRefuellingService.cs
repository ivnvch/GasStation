using Station.Common.Mapper;


namespace Station.BusinessLogic.Interfaces
{
    public interface IRefuellingService
    {
        IEnumerable<RefuellingDTO> Gets();
        RefuellingDTO Get(int name);
        void Parser();
    }
}
