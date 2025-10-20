using Remaza.Api.Dtos;
using Remaza.Visitas.Application.Interfaces;
using Remaza.Visitas.Domain.Entities;
using Remaza.Visitas.Application.Utils;

namespace Remaza.Visitas.Application.Services
{
    public class CheckInService
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly ICheckInRepository _checkInRepository;

        public CheckInService(IVisitorRepository visitorRepository, ICheckInRepository checkInRepository)
        {
            _visitorRepository = visitorRepository;
            _checkInRepository = checkInRepository;
        }

        public async Task<CheckInResponseDto> HandleCheckInAsync(string name, string document, string type, string visitPurpose)
        {
            var visitor = await _visitorRepository.GetByDocumentAsync(document);
            bool isNewVisitor = visitor == null;

            DateTimeOffset currentBrazilTime = DateTimeUtils.GetBrazilTime();

            if (isNewVisitor)
            {
                visitor = new Visitor
                {
                    Name = name,
                    Document = document,
                    VisitCount = 0
                };
                await _visitorRepository.AddAsync(visitor);
                await _visitorRepository.SaveChangesAsync();
            }
            else
            {
                visitor.Name = name;
            }

            var newCheckIn = new CheckIn
            {
                VisitorId = visitor.Id,
                Type = type,
                VisitPurpose = visitPurpose,
                CheckInTime = currentBrazilTime
            };

            if (type.Equals("cliente_consorcio", StringComparison.OrdinalIgnoreCase))
            {
                newCheckIn.ServicePassword = GenerateServicePassword();
                newCheckIn.WifiToken = GenerateWifiToken();
            }

            await _checkInRepository.AddAsync(newCheckIn);

            visitor.VisitCount += 1;
            visitor.LastVisit = currentBrazilTime;

            await _visitorRepository.UpdateAsync(visitor);
            await _visitorRepository.SaveChangesAsync();

            return new CheckInResponseDto
            {
                Name = visitor.Name,
                Document = visitor.Document,
                Type = newCheckIn.Type,
                VisitPurpose = newCheckIn.VisitPurpose,
                VisitCount = visitor.VisitCount,
                CheckInTime = newCheckIn.CheckInTime.ToString("HH:mm:ss"),
                CredentialId = newCheckIn.Id.ToString(),
                ServicePassword = newCheckIn.ServicePassword,
                WifiToken = newCheckIn.WifiToken
            };
        }

        private string GenerateServicePassword() => new Random().Next(10, 99).ToString();
        private string GenerateWifiToken() => Guid.NewGuid().ToString().Substring(0, 8);
    }
}