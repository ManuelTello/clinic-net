using Clinic.NET.Application.Responses;
using MediatR;

namespace Clinic.NET.Application.Commands
{
    public record CreatePatientCommand(
        string Name,
        DateTime DateOfBirth,
        string PhoneNumber,
        string Email,
        int Identification,
        string? InsuranceType) : IRequest<CreatePatientCommandResult>;
}