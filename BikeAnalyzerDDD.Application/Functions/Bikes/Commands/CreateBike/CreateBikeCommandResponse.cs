using BikeAnalyzerDDD.Application.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Application.Functions.Bikes.Commands.CreateBike
{
    public class CreateBikeCommandResponse : BaseResponse
    {
        public int? Id { get; set; }

        public CreateBikeCommandResponse() : base()
        { }

        public CreateBikeCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreateBikeCommandResponse(string message)
        : base(message)
        { }

        public CreateBikeCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreateBikeCommandResponse(int id)
        {
            Id = id;
        }
    }
}