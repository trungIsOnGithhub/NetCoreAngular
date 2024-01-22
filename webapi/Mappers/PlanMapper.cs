using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers
{
    public static class PlanMappers
    {
        public static Plan ToPlan(this PlanCreateDto plan)
        {
            return new Plan
            {
                HotelName = plan.HotelName,
                Location = plan.Location,
                AgencyId = plan.AgencyId,
                Country = plan.Country,
            };
        }

        public static PlanListDto ToPlanListDto(this Plan plan)
        {
            return new PlanListDto
            {
                Id = plan.Id,
                Country = plan.Country,
                Location = plan.Location,
                HotelName = plan.HotelName,
            };
        }
    }
}