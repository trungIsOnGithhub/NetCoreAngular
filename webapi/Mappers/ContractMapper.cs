using webapi.Models;

namespace webapi.Mappers
{
    public static class ContractMappers
    {
        public static Contract ToContract(this ContractCreateDto dto)
        {
            return new Contract {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                TotalPrice = dto.TotalPrice,
                AmmountPaid = dto.AmmountPaid,
                RoomType = dto.RoomType,
                ServiceType = dto.ServiceType,
                TransportationType = dto.TransportationType,
                ContractLocation = dto.ContractLocation,
                IsArchived = false,
                IsPaid = dto.TotalPrice == dto.AmmountPaid
            };
        }

        public static Contract ToContract(this ContractCreateWithPlanDto dto)
        {
            return new Contract {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                ContractLocation = dto.ContractLocation,
                StartDate = DateTime.Parse(dto.StartDate),
                EndDate = DateTime.Parse(dto.EndDate),
                // use primitve value of enum in dto, casting later for real object
                PaymentMethod = (PaymentMethods)dto.PaymentMethod,
                DepartureTime = dto.DepartureTime ?? DateTime.Parse(dto.DepartureTime) : null,
                TotalPrice = dto.TotalPrice,
                Note = dto.Note,
                Footer = dto.Footer,
                Insurance = dto.Insurance,
                AmmountPaid = dto.AmmountPaid,
                IsPaid = dto.TotalPrice == dto.AmmountPaid,
                RoomType = dto.RoomType,
                ServiceType = dto.ServiceType,
                TransportationType = dto.TransportationType,
                Plan = dto.Plan.ToPlan(),
                IsArchived = false
            };
        }
    }
}