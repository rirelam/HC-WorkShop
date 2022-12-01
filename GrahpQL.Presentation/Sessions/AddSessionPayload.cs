
using GrahpQL.Presentation.Shared;
using GraphQL.Entities;

namespace GrahpQL.Presentation.Sessions
{
    public class AddSessionPayload : SessionPayloadBase
    {
        public AddSessionPayload(UserError error)
                    : base(new[] { error })
        {
        }

        public AddSessionPayload(Session session) : base(session)
        {
        }

        public AddSessionPayload(IReadOnlyList<UserError> errors) : base(errors)
        {
        }
    }
}