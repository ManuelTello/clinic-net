using Clinic.NET.Application.Commands;
using Clinic.NET.WebAPI.Contracts.Patient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.NET.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediatrSender;

        public PatientController(IMediator mediatrSender)
        {
            this._mediatrSender = mediatrSender;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreatePatient([FromBody] CreatePatientContract patientContract)
        {
            var command = new CreatePatientCommand(patientContract.Name, patientContract.DateOfBirth, patientContract.PhoneNumber, patientContract.Email, patientContract.Identification,
                patientContract.InsuranceType);
            var result = this._mediatrSender.Send(command);
            return Ok("Hola");
        }
    }
}