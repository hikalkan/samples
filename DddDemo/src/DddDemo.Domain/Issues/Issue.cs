using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using DddDemo.Users;
using JetBrains.Annotations;

namespace DddDemo.Issues
{
    public class Issue //Aggregate Root
    {
        [NotNull]
        public string Id { get; protected set; }

        [NotNull]
        public string Title { get; protected set; }

        [CanBeNull]
        public string Body { get; protected set; }

        public bool IsClosed { get; protected set; }

        public IssueCloseReason Reason { get; protected set; }

        [NotNull]
        public string CreatorUserId { get; protected set; } //No navigation property to another aggregate root!

        [CanBeNull]
        public string AssignedUserId { get; protected set; } //No navigation property to another aggregate root!

        [NotNull]
        public IReadOnlyList<IssueComment> Comments => _comments.ToImmutableList();
        protected ICollection<IssueComment> _comments { get; set; }

        protected Issue()
        {
            
        }

        public Issue([NotNull] string creatorUserId, [NotNull] string title, string body = null) //Can not get AssignedUserId into constructor!
        {
            Check.NotNull(creatorUserId, nameof(creatorUserId));
            Check.NotNull(title, nameof(title));

            Id = Guid.NewGuid().ToString("D");

            CreatorUserId = creatorUserId;
            Title = title;
            Body = body;

            _comments = new Collection<IssueComment>();
        }

        public void AssignTo([NotNull] User user, [NotNull] IIssueAssignmentPolicy policy)
        {
            Check.NotNull(user, nameof(user));
            Check.NotNull(policy, nameof(policy));

            policy.CheckAssignment(this, user);

            AssignedUserId = user.Id;
        }

        public void ClearAssignment()
        {
            AssignedUserId = null;
        }

        //TODO: Add/delete comments!
    }
}
