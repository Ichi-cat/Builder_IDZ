using Notes.Application.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidating : IValidating<CreateNoteCommand>
    {
        public override void Valid(CreateNoteCommand command)
        {
            builder.RuleFor(x => x.Name).SetMaxLength(6).SetMinLength(3).SetIsNull(false).SetName("Name").Build().Validate(command);
            builder.RuleFor(x => x.Text).SetMaxLength(6).SetMinLength(3).SetIsNull(false).SetName("Text").Build().Validate(command);
        }
    }
}
