// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models;
using FailureAnalysis.Core.Api.Models.Exceptions;

namespace FailureAnalysis.Core.Api.Services.Foundations.Failures
{
    public partial class FailureService
    {
        private void ValidateFailureOnAdd(Failure failure)
        {
            ValidateFailureIsNotNull(failure);

            Validate(
                (Rule: IsInvalid(failure.Id), Parameter: nameof(Failure.Id)),
                (Rule: IsInvalid(failure.ProfileId), Parameter: nameof(Failure.ProfileId)),
                (Rule: IsInvalid(failure.State), Parameter: nameof(Failure.State)),
                (Rule: IsInvalid(failure.Title), Parameter: nameof(Failure.Title)),
                (Rule: IsInvalid(failure.AssignTo), Parameter: nameof(Failure.AssignTo)),
                (Rule: IsInvalid(failure.FailureArea), Parameter: nameof(Failure.FailureArea)),
                (Rule: IsInvalid(failure.SprintName), Parameter: nameof(Failure.SprintName)),
                (Rule: IsInvalid(failure.FailureIdString), Parameter: nameof(Failure.FailureIdString)),
                (Rule: IsInvalid(failure.CreatedDate), Parameter: nameof(Failure.CreatedDate)),
                (Rule: IsInvalid(failure.UpdatedDate), Parameter: nameof(Failure.UpdatedDate)),
                (Rule: IsInvalid(failure.Description), Parameter: nameof(Failure.Description)),
                (Rule: IsInvalid(failure.ErrorMessage), Parameter: nameof(Failure.ErrorMessage)),
                (Rule: IsInvalid(failure.Source), Parameter: nameof(Failure.Source)));
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(DateTimeOffset offset) => new
        {
            Condition = offset == DateTimeOffset.MinValue,
            Message = "Date is required"
        };

        private void ValidateFailureIsNotNull(Failure failure)
        {
            if(failure is null)
            {
                throw new NullFailureException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidFailureException = new InvalidFailureException();

            foreach (var validation in validations)
            {
                if(validation.Rule.Condition)
                {
                    invalidFailureException.UpsertDataList(
                        key: validation.Parameter,
                        value: validation.Rule.Message);
                }
            }

            invalidFailureException.ThrowIfContainsErrors();
        }
    }
}
